using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ComLib.Lang
{
    /// <summary>
    /// Converts script from a series of characters into a series of tokens.
    /// Main method is NextToken();
    /// A script can be broken down into a sequence of tokens.
    /// e.g.
    /// 
    /// 1. var name = "kishore";
    /// Tokens:
    /// 
    ///  TOKEN VALUE:         TOKEN TYPE:
    ///  var         keyword
    ///  ""          literal ( whitespace )
    ///  name        id
    ///  ""          literal ( whitespace )
    ///  =           operator
    ///  ""          literal ( whitespace )
    ///  "kishore"   literal
    ///  ;           operator
    /// </summary>
    public class Lexer
    {
        #region Private members
        private Context _ctx;
        private Scanner _scanner;
        private Token _lastToken;
        private TokenData _lastTokenData;
        private int _lineNumber = 1;
        private int _lineCharPosition = -1;
        private bool _hasReplacementsOrRemovals = false;
        private char _interpolatedStartChar = '#';
        private List<TokenData> _tokens;
        private Dictionary<string, string> _replacements = new Dictionary<string, string>();
        private Dictionary<string, Tuple<bool, string>> _inserts = new Dictionary<string, Tuple<bool, string>>();
        private Dictionary<string, bool> _removals = new Dictionary<string, bool>();
        private static IDictionary<char, bool> _opChars = new Dictionary<char, bool>()
        {
            { '*', true},
            { '/', true},
            { '+', true},
            { '-', true},
            { '%', true},
            { '<', true},
            { '>', true},
            { '=', true},
            { '!', true},
            { '&', true},
            { '|', true}             
        };
        #endregion


        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="ctx">The context containing plugins among other core integration components.</param>
        /// <param name="scanner"></param>
        public Lexer(Context ctx, Scanner scanner)
        {
            _ctx = ctx;
            _scanner = scanner;
        }


        /// <summary>
        /// The current line number.
        /// </summary>
        public int LineNumber { get { return _lineNumber; } }


        /// <summary>
        /// The char position on the current line.
        /// </summary>
        public int LineCharPos { get { return _lineCharPosition; } }


        /// <summary>
        /// Starting char which signifies the start of an expression in an interpolated string.
        /// </summary>
        public char IntepolatedStartChar { get { return _interpolatedStartChar; } set { _interpolatedStartChar = value; } }


        /// <summary>
        /// Replaces a token with another token.
        /// </summary>
        /// <param name="text">The text to replace</param>
        /// <param name="newValue">The replacement text</param>
        public void SetReplacement(string text, string newValue)
        {
            // check if replacements has a space. can do at most 2 words in a replacement for now.
            // e.g. can replace "number of" with "count".
            _replacements[text] = newValue;
            _hasReplacementsOrRemovals = true;
        }


        /// <summary>
        /// Removes a token during the lexing process.
        /// </summary>        
        /// <param name="text">The text to remove</param>
        public void SetRemoval(string text)
        {
            _removals[text] = true;
            _hasReplacementsOrRemovals = true;
        }


        /// <summary>
        /// Adds a token during the lexing process.
        /// </summary>
        /// <param name="before">whether to insert before or after</param>
        /// <param name="text">The text to check for inserting before/after</param>
        /// <param name="newValue">The new value to insert before/after</param>
        public void SetInsert(bool before, string text, string newValue)
        {
            _inserts[text] = new Tuple<bool, string>(before, newValue);
        }


        /// <summary>
        /// The current token.
        /// </summary>
        public Token LastToken { get { return _lastToken; } }


        /// <summary>
        /// The current token.
        /// </summary>
        public TokenData LastTokenData { get { return _lastTokenData; } }


        /// <summary>
        /// The list of parsed tokens.
        /// </summary>
        public List<TokenData> ParsedTokens { get { return _tokens; } }


        /// <summary>
        /// The scanner used for parsing.
        /// </summary>
        public Scanner Scanner { get { return _scanner; } }


        /// <summary>
        /// Returns a list of tokens of the entire script.
        /// </summary>
        /// <returns></returns>
        internal List<TokenData> Tokenize()
        {
            _tokens = new List<TokenData>();
            var hasPlugins = _ctx.Plugins.TotalLexical > 0;

            while (true)
            {
                var token = NextToken();

                // 1. End of script ?
                if (token.Token == Token.EndToken)
                {
                    _tokens.Add(token);
                    break;
                }

                // 2. Null token ?
                if (token.Token == null) 
                    continue;

                // 3. Plugins? 
                if ( hasPlugins && _ctx.Plugins.CanHandleLex(token.Token))
                {
                    var plugin = _ctx.Plugins.GetLex(token.Token);
                    plugin.Parse();
                }

                // 4. Can immediately add to tokens ?
                else if (!_hasReplacementsOrRemovals)
                    _tokens.Add(token);

                // 5. Special Handling Cases
                //    Case 1: Replace token ?
                else if (_replacements.ContainsKey(token.Token.Text))
                {
                    var replaceVal = _replacements[token.Token.Text];

                    // Replaces system token?
                    if (Tokens.AllTokens.ContainsKey(replaceVal))
                    {
                        Token t = Tokens.AllTokens[replaceVal];
                        token.Token = t;
                    }
                    else
                    {
                        token.Token.Replace(replaceVal);
                    }
                    _tokens.Add(token);
                }
                // Case 2: Remove token ?
                else if (!_removals.ContainsKey(token.Token.Text))
                    _tokens.Add(token);
            }
            return _tokens;
        }

        
        /// <summary>
        /// Reads the next token from the reader.
        /// </summary>
        /// <returns> A token, or <c>null</c> if there are no more tokens. </returns>
        public TokenData NextToken()
        {
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // LEXER ALWAYS READS NEXT CHAR
            char c = _scanner.ReadChar();
            char n = _scanner.PeekChar();
            _lineCharPosition++;

            if (_scanner.IsEnd())
            {
                _lastToken = Token.EndToken;
            }
            // Empty space.
            else if (c == ' ' || c == '\t')
            {
                _scanner.ConsumeWhiteSpace(false, false);
                _lastToken = Tokens.WhiteSpace;
            }
            // Variable
            else if (IsStartChar(c))
            {
                _lastToken = ReadWord();
            }
            // Operator ( Math, Compare, Increment ) * / + -, < < > >= ! =
            else if (IsOp(c) == true)
            {
                _lastToken = ReadOperator();
            }
            else if (c == '(')
            {
                _lastToken = Tokens.LeftParenthesis;
            }
            else if (c == ')')
            {
                _lastToken = Tokens.RightParenthesis;
            }
            else if (c == '[')
            {
                _lastToken = Tokens.LeftBracket;
            }
            else if (c == ']')
            {
                _lastToken = Tokens.RightBracket;
            }
            else if (c == '.')
            {
                _lastToken = Tokens.Dot;
            }
            else if (c == ',')
            {
                _lastToken = Tokens.Comma;
            }
            else if (c == ':')
            {
                _lastToken = Tokens.Colon;
            }
            else if (c == '{')
            {
                _lastToken = Tokens.LeftBrace;
            }
            else if (c == '}')
            {
                _lastToken = Tokens.RightBrace;
            }
            else if (c == ';')
            {
                _lastToken = Tokens.Semicolon;
            }
            else if (c == '$')
            {
                _lastToken = Tokens.Dollar;
            }
            // String literal
            else if (c == '"' || c == '\'')
            {
                _lastToken = ReadString();
            }
            else if (IsNumeric(c))
            {
                _lastToken = ReadNumber();
            }
            // Single line
            else if (c == '/' && n == '/')
            {
                var result = _scanner.ReadLine(false);
                if (result.Success) _lineNumber++;
                _lineCharPosition = -1;
                _lastToken = Tokens.CommentSLine;
            }
            // Multi-line
            else if (c == '/' && n == '*')
            {
                var result = _scanner.ReadUntilChars(false, '*', '/');
                if (result.Success)
                {
                    _lineNumber += result.Lines;
                }
                _lineCharPosition = -1;
                _lastToken = Tokens.CommentMLine;
            }
            else if (c == '\r' && n == '\n')
            {
                IncrementLine();
            }
            var t = new TokenData() { Token = _lastToken, Line = _lineNumber, CharPos = _lineCharPosition };
            _lastTokenData = t;

            // Before returning, set the next line char position.
            if (_lineCharPosition != -1 && _lastToken != null && !string.IsNullOrEmpty(_lastToken.Text))
            {
                _lineCharPosition += _lastToken.Text.Length;
            }
            return t;
        }


        /// <summary>
        /// Read word
        /// </summary>
        /// <returns></returns>
        public Token ReadWord()
        {
            var result = _scanner.ReadId(false, false);

            // true / false / null
            if (Tokens.IsLiteral(result.Text))
                return Tokens.ToLiteral(result.Text);

            // var / for / while
            if (Tokens.IsKeyword(result.Text))
                return Tokens.ToKeyWord(result.Text);

            return new IdToken(result.Text);
        }


        /// <summary>
        /// Read word
        /// </summary>
        /// <returns></returns>
        public Token ReadUntilWhiteSpace()
        {
            var result = _scanner.ReadUntilWhiteSpace(false, false);
            return new StringToken(result.Text, result.Text, false);
        }


        /// <summary>
        /// Reads a uri such as http, https, ftp, ftps, www.
        /// </summary>
        /// <returns></returns>
        public Token ReadUri()
        {
            var result = _scanner.ReadUri(false, false);
            return new StringToken(result.Text, result.Text, false);
        }


        /// <summary>
        /// Read number
        /// </summary>
        /// <returns></returns>
        public Token ReadNumber()
        {
            var result = _scanner.ReadNumber(false, false);
            return new NumberToken(result.Text, Convert.ToDouble(result.Text), false);
        }


        /// <summary>
        /// Read an operator
        /// </summary>
        /// <returns></returns>
        public Token ReadOperator()
        {
            var result = _scanner.ReadChars(_opChars, false, false);
            return Tokens.ToOperator(result.Text);
        }


        /// <summary>
        /// Reads a string either in quote or double quote format.
        /// </summary>
        /// <returns></returns>
        public Token ReadString(bool handleInterpolation = true)
        {
            char quote = _scanner.CurrentChar;
                
            // 1. Starts with either ' or "
            // 2. Handles interpolation "homepage of ${user.name} is ${url}"
            if (!handleInterpolation)
            {
                var result = _scanner.ReadCodeString(quote, setPosAfterToken: false);
                return new StringToken(result.Text, result.Text, false);
            }
            return ReadInterpolatedString(quote);
        }


        /// <summary>
        /// Reads string upto end of line.
        /// </summary>
        /// <returns></returns>
        public Token ReadLine()
        {
            return ReadInterpolatedString(Char.MinValue, true);
        }


        /// <summary>
        /// Reads an interpolated string in format "${variable} some text ${othervariable + 2}."
        /// </summary>
        /// <param name="quote"></param>
        /// <param name="readLine">Whether or not to only read to the end of the line.</param>
        /// <returns></returns>
        public Token ReadInterpolatedString(char quote, bool readLine = false)
        {
            var allTokens = new List<TokenData>();
            var interpolationCount = 0;
            // Only supporting following:
            // 1. id's abcd with "_"
            // 2. "."
            // 3. math ops ( + - / * %)
            // "name" 'name' "name\"s" 'name\'"
            var buffer = new StringBuilder();
            char curr = _scanner.ReadChar();
            char next = _scanner.PeekChar();
            bool matched = false;
            char escapeChar = '\\';
            Token token = null;
            while (_scanner.Position <= _scanner.LAST_POSITION)
            {
                // End string " or '
                if (!readLine && curr == quote)
                {
                    matched = true;
                    _scanner.MoveChars(1);
                    break;
                }
                // End of line.
                if (readLine && curr == '\r' && next == '\n' )
                {
                    IncrementLine();
                    token = Tokens.NewLine;
                    matched = true;
                    break;
                }
                // Interpolation.
                else if (curr == _interpolatedStartChar && next == '{')
                {
                    // Keep track of interpolations and their start positions.
                    interpolationCount++;
                    int interpolatedStringStartPos = LineCharPos + 2;
                    int interpolatedStringLinePos = LineNumber;

                    // Add any existing text before the interpolation as a token.
                    if (buffer.Length > 0)
                    {
                        string text = buffer.ToString();
                        token = new LiteralToken(text, text, false);
                        var t = new TokenData() { Token = token, CharPos = 0, Line = LineNumber };
                        allTokens.Add(t);
                        buffer.Clear();
                    }
                    _scanner.MoveChars(1);
                    var tokens = ReadInterpolatedTokens();
                    token = new InterpolatedToken(string.Empty, tokens);
                    var iTokenData = new TokenData() { Token = token, CharPos = interpolatedStringStartPos, Line = interpolatedStringLinePos };
                    allTokens.Add(iTokenData);
                }
                // Not an \ for escaping so just append.
                else if (curr != escapeChar)
                {
                    buffer.Append(curr);
                }
                // Escape \
                else if (curr == escapeChar)
                {
                    if (next == quote) buffer.Append("\"");
                    else if (next == 'r') buffer.Append('\r');
                    else if (next == 'n') buffer.Append('\n');
                    else if (next == 't') buffer.Append('\t');
                    _scanner.MoveChars(1);
                }

                curr = _scanner.ReadChar(); 
                next = _scanner.PeekChar();
            }
            // At this point the pos is already after token.
            // If matched and need to set at end of token, move back 1 char
            if (matched) _scanner.MoveChars(-1);
            if (interpolationCount == 0)
            {
                string text = buffer.ToString();
                return new StringToken(text, text, false);
            }
            if (buffer.Length > 0)
            {
                string text = buffer.ToString();
                token = new LiteralToken(text, text, false);
                allTokens.Add(new TokenData() { Token = token, CharPos = 0, Line = LineNumber });
                        
            }
            return new InterpolatedToken(string.Empty, allTokens);
        }


        private List<TokenData> ReadInterpolatedTokens()
        {            
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // LEXER ALWAYS READS NEXT CHAR
            char c = _scanner.ReadChar();
            char n = _scanner.PeekChar();
            _lineCharPosition++;
            List<TokenData> tokens = new List<TokenData>();

            while (c != '}' && !_scanner.IsAtEnd())
            {                
                // Variable
                if (IsStartChar(c))
                {
                    _lastToken = ReadWord();
                }
                // Empty space.
                else if (c == ' ' || c == '\t')
                {
                    _lastToken = Tokens.WhiteSpace;
                }
                else if (IsOp(c) == true)
                {
                    _lastToken = ReadOperator();
                }
                else if (c == '(')
                {
                    _lastToken = Tokens.LeftParenthesis;
                }
                else if (c == ')')
                {
                    _lastToken = Tokens.RightParenthesis;
                }
                else if (c == '[')
                {
                    _lastToken = Tokens.LeftBracket;
                }
                else if (c == ']')
                {
                    _lastToken = Tokens.RightBracket;
                }
                else if (c == '.')
                {
                    _lastToken = Tokens.Dot;
                }
                else if (c == ',')
                {
                    _lastToken = Tokens.Comma;
                }
                else if (c == ':')
                {
                    _lastToken = Tokens.Colon;
                }                
                else if (IsNumeric(c))
                {
                    _lastToken = ReadNumber();
                }
                else if (c == '\r' && n == '\n')
                {
                    IncrementLine();
                }
                else
                {
                    throw new LangException("syntax", "unexpected text in string", string.Empty, _lineNumber, _lineCharPosition);
                }
                                  
                var t = new TokenData() { Token = _lastToken, Line = _lineNumber, CharPos = _lineCharPosition };
                tokens.Add(t);
                
                // Before returning, set the next line char position.
                if (_lineCharPosition != -1 && _lastToken != null && !string.IsNullOrEmpty(_lastToken.Text))
                {
                    _lineCharPosition += _lastToken.Text.Length;
                }
                c = _scanner.ReadChar();
                n = _scanner.PeekChar();
            }
            return tokens;
        }


        private void IncrementLine()
        {
            _scanner.MoveChars(1);
            _lineNumber++;
            _lineCharPosition = -1;
            _lastToken = Tokens.NewLine;
        }        


        /// <summary>
        /// Whether the char is a valid char for an identifier.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsStartChar(int c)
        {
            return c == '_' || ('a' <= c && c <= 'z') || ('A' <= c && c <= 'Z');
        }


        /// <summary>
        /// Whether char is an operator.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsOp(char c)
        {
            return IsMathOp(c) || IsCompareOp(c) || IsLogicOp(c);
        }


        /// <summary>
        /// Whether char is a math operator * / + - %
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsMathOp(char c)
        {
            return  c == '*' || c == '/' || c == '+' || c == '-' || c == '%';
        }


        /// <summary>
        /// Whether char is a logical operator 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLogicOp(char c)
        {
            return c == '&' || c == '|';
        }


        /// <summary>
        /// Whether char is a compare operator 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsCompareOp(char c)
        {
            return c == '<' || c == '>' || c == '!' || c == '=';
        }


        /// <summary>
        /// Whether or not the char is a numeric char.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsNumeric(char c)
        {
            return c == '.' || (c >= '0' && c <= '9');
        }

        
        /// <summary>
        /// Whether char is a quote for start of strings.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsStringStart(char c)
        {
            return c == '"' || c == '\'';
        }


        /// <summary>
        /// Whether char is a whitespace or tab.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsWhiteSpace(char c)
        {
            return c == ' ' || c == '\t';
        }
    }
}
