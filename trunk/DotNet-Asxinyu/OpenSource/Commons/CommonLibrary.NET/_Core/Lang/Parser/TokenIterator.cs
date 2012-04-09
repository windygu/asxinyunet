using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Iterates over a series of tokens.
    /// </summary>
    public class TokenIterator
    {
        private int _lastLineNumber;
        private int _lastCharPosition;
        private bool _isEnded;


        /// <summary>
        /// The parsed tokens from the script
        /// </summary>
        public List<TokenData> TokenList;


        /// <summary>
        /// The index position of the currrent token being processed
        /// </summary>
        protected int CurrentIndex;


        /// <summary>
        /// Last token parsed.
        /// </summary>
        public TokenData LastToken;


        /// <summary>
        /// The next token
        /// </summary>
        public TokenData NextToken;


        /// <summary>
        /// The path to the script.
        /// </summary>
        public string ScriptPath;


        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="tokens">The list of tokens</param>
        /// <param name="lastLineNumber">Last line number of script</param>
        /// <param name="lastCharPos">Last char position of script.</param>
        public void Init(List<TokenData> tokens, int lastLineNumber, int lastCharPos)
        {
            TokenList = tokens;
            CurrentIndex = -1;
            _lastCharPosition = lastCharPos;
            _lastLineNumber = lastLineNumber;
        }


        /// <summary>
        /// Indicates whether or not the token iteration is ended.
        /// </summary>
        /// <returns></returns>
        public bool IsEnded
        {
            get { return _isEnded; }
        }
        

        /// <summary>
        /// Advance to the next token
        /// </summary>
        public void Advance(int count = 1, bool passNewLine = true)
        {
            int advanced = 0;

            while (true)
            {               
                LastToken = NextToken;

                // Gaurd against empty or going past the last token
                if (TokenList.Count == 0 || CurrentIndex + 1 >= TokenList.Count)
                {
                    _isEnded = true;
                    return;
                }

                CurrentIndex++;
                NextToken = TokenList[CurrentIndex];

                // Is New line important ?
                if ( !passNewLine && NextToken.Token == Tokens.NewLine )
                    advanced++;

                else if (   NextToken.Token != Tokens.WhiteSpace 
                       && NextToken.Token != Tokens.CommentMLine
                       && NextToken.Token != Tokens.CommentSLine   
                       && NextToken.Token != Tokens.NewLine
                   )
                {
                    advanced++;
                }
                if (advanced == count)
                    break;
            }
        }


        /// <summary>
        /// Peek into and get the token ahead of the current token.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public TokenData Peek(int count = 1)
        {
            if (CurrentIndex >= TokenList.Count - 1)
                return new TokenData() { Token = Token.EndToken, Line = _lastLineNumber, CharPos = _lastCharPosition };

            int ndx = CurrentIndex + 1;
            TokenData next = null;
            int advanced = 0;
            while (ndx <= TokenList.Count - 1)
            {
                next = TokenList[ndx];
                if (next.Token != Tokens.WhiteSpace && next.Token != Tokens.CommentMLine
                    && next.Token != Tokens.CommentSLine && next.Token != Tokens.NewLine)
                    advanced++;

                if (advanced == count) break;
                ndx++;
            }
            return next;
        }


        #region Expect calls
        /// <summary>
        /// Advance to the next token and expect the token supplied.
        /// </summary>
        /// <param name="expectedToken"></param>
        /// <param name="advanceAfterExpectation">Whether or not to advance after making the expectaion of the next token.
        /// This basically does following: 1. advance 2. expect 3. advance again if this parameter is true</param>
        public void AdvanceAndExpect(Token expectedToken, bool advanceAfterExpectation = true)
        {
            Advance();
            Expect(expectedToken);
        }


        /// <summary>
        /// Advance and get the next token.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AdvanceAndGet<T>() where T: class
        {
            Advance();
            if (!(NextToken.Token is T)) throw BuildSyntaxExpectedTokenException(typeof(T).Name.Replace("Token", ""));
            if (NextToken.Token == Token.EndToken) throw BuildEndOfScriptException();

            T token = NextToken.Token as T;
            return token;
        }


        /// <summary>
        /// Expect the token supplied and advance to next token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="advance">Whether or not to advance to the next token after expecting token</param>
        public void Expect(Token token, bool advance = true)
        {
            if (NextToken.Token == Token.EndToken) throw BuildEndOfScriptException();
            if (NextToken.Token != token) throw BuildSyntaxExpectedTokenException(token.Text);
            if (advance) Advance();
        }


        /// <summary>
        /// Expect the token supplied and advance to next token
        /// </summary>
        /// <param name="token1">The 1st token to expect</param>
        /// <param name="token2">The 2nd token to expect</param>
        /// <param name="token3">The 3rd token to expect</param>
        /// <param name="advance">Whether or not to advance to the next token after expecting token</param>
        public void ExpectMany(Token token1, Token token2 = null, Token token3 = null, bool advance = true)
        {
            if (NextToken.Token == Token.EndToken) throw BuildEndOfScriptException();

            // ASSERT token 1 match
            if (NextToken.Token != token1) throw BuildSyntaxExpectedTokenException(token1.Text);

            // No token 2 ?
            if (token2 == null) { if (advance) Advance(); return; }

            // Advance to token 2
            Advance();

            // ASSERT token 2 match
            if (NextToken.Token != token2) throw BuildSyntaxExpectedTokenException(token2.Text);

            // No token 3
            if (token3 == null) { if (advance) Advance(); return; }

            // Advance to token 3.
            Advance();

            // ASSERT token 3 match
            if (NextToken.Token != token3) throw BuildSyntaxExpectedTokenException(token3.Text);

            if (advance) Advance();
        }


        /// <summary>
        /// Expect identifier
        /// </summary>
        /// <param name="advance">Whether or not to advance to next token</param>
        /// <param name="allowLiteralAsId">Whether or not to allow a literal as an identifier.</param>
        /// <returns></returns>
        public string ExpectId(bool advance = true, bool allowLiteralAsId = false)
        {
            if (NextToken.Token == Token.EndToken) throw BuildEndOfScriptException();
            if (!allowLiteralAsId && !(NextToken.Token is IdToken)) throw BuildSyntaxExpectedTokenException("identifier");

            string id = NextToken.Token.Text;

            if (advance)
                Advance();

            return id;
        }


        /// <summary>
        /// Expect identifier
        /// </summary>
        /// <param name="text">The text of the id token to expect</param>
        /// <param name="advance">Whether or not to advance to next token</param>
        /// <returns></returns>
        public string ExpectIdText(string text, bool advance = true)
        {
            if (NextToken.Token == Token.EndToken) throw BuildEndOfScriptException();
            if (!(NextToken.Token is IdToken)) throw BuildSyntaxExpectedTokenException("identifier");

            string id = NextToken.Token.Text;
            if (id != text) throw BuildSyntaxExpectedTokenException(text);

            if (advance)
                Advance();

            return id;
        }


        /// <summary>
        /// Expect identifier
        /// </summary>
        /// <param name="advance">Whether or not to advance to next token</param>
        /// <returns></returns>
        public double ExpectNumber(bool advance = true)
        {
            if (NextToken.Token == Token.EndToken) throw BuildEndOfScriptException();
            if (!(NextToken.Token is LiteralToken)) throw BuildSyntaxExpectedTokenException("number");

            string val = NextToken.Token.Text;
            double num = 0;
            if (!double.TryParse(val, out num)) throw BuildSyntaxExpectedTokenException("number");

            if (advance)
                Advance();

            return num;
        }
        #endregion


        #region Parser Errors
        /// <summary>
        /// Build a language exception due to the current token being invalid.
        /// </summary>
        /// <param name="expected"></param>
        /// <returns></returns>
        public LangException BuildSyntaxExpectedTokenException(string expected)
        {
            return new LangException("Syntax Error", string.Format("Expected {0} but found '{1}'", expected, NextToken.Token.Text), ScriptPath, NextToken.Line, NextToken.CharPos);
        }


        /// <summary>
        /// Build a language exception due to the current token being invalid.
        /// </summary>
        /// <returns></returns>
        public LangException BuildSyntaxUnexpectedTokenException()
        {
            return new LangException("Syntax Error", string.Format("Unexpected token found '{0}'", NextToken.Token.Text), ScriptPath, NextToken.Line, NextToken.CharPos);
        }

        /// <summary>
        /// Builds a language exception due to a specific limit being reached.
        /// </summary>
        /// <param name="error">Error message</param>
        /// <param name="limittype">FuncParameters</param>
        /// <param name="limit">Limit number</param>
        /// <returns></returns>
        public LangException BuildLimitException(string error, int limit, string limittype = "")
        {
            return new LangException("Limit Error", error, ScriptPath, NextToken.Line, NextToken.CharPos);
        }


        /// <summary>
        /// Builds a language exception due to the unexpected end of script.
        /// </summary>
        /// <returns></returns>
        public LangException BuildEndOfScriptException()
        {
            return new LangException("Syntax Error", "Unexpected end of script", ScriptPath, NextToken.Line, NextToken.CharPos);
        }
        #endregion
    }
}
