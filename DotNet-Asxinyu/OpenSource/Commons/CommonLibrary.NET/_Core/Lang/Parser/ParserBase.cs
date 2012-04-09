using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Base class for the parser
    /// </summary>
    public class ParserBase : ILangParser
    {
        #region Protected members
        /// <summary>
        /// Scope of the script
        /// </summary>
        protected Scope _scope = null;


        /// <summary>
        /// Context information about the script.
        /// </summary>
        protected Context _context = null;


        /// <summary>
        /// Scanner to parse characters
        /// </summary>
        protected Scanner _scanner = null;


        /// <summary>
        /// Lexer to parse tokens.
        /// </summary>
        protected Lexer _lexer = null;


        /// <summary>
        /// The script as text.
        /// </summary>
        protected string _script;


        /// <summary>
        /// The path to the script if script was provided as a file path instead of text
        /// </summary>
        protected string _scriptPath;


        /// <summary>
        /// The parsed statements from interpreting the tokens.
        /// </summary>
        protected List<Statement> _statements; 


        /// <summary>
        /// The state of the parser .. used in certain cases.
        /// </summary>
        protected ParserState _state;


        /// <summary>
        /// Settings of the lanaguage interpreter.
        /// </summary>
        protected LangSettings _settings;


        /// <summary>
        /// Token iterator.
        /// </summary>
        protected TokenIterator _tokenIt;
        #endregion


        /// <summary>
        /// Initialize
        /// </summary>
        public ParserBase(Context context)
        {
            _context = context;
            _scanner = new Scanner();
            _lexer = new Lexer(_context, _scanner);
        }


        #region Public properties
        /// <summary>
        /// Get the scope
        /// </summary>
        public Scope Scope { get { return _scope; } }


        /// <summary>
        /// Get/Set the context of the script.
        /// </summary>
        public Context Context { get { return _context; } set { _context = value; _scope = _context.Scope; } }


        /// <summary>
        /// Name of the current script being parsed.
        /// Set from the Interpreter object.
        /// </summary>
        public string ScriptName { get; set; }


        /// <summary>
        /// Get the lexer.
        /// </summary>
        public Lexer Lexer { get { return _lexer; } }


        /// <summary>
        /// Settings
        /// </summary>
        public LangSettings Settings { get { return _settings; } set { _settings = value; } }


        /// <summary>
        /// The token iterator.
        /// </summary>
        public TokenIterator TokenIt { get { return _tokenIt; } }


        /// <summary>
        /// The path to the script
        /// </summary>
        public string ScriptPath { get { return _scriptPath; } }

        #endregion


        #region Public methods
        /// <summary>
        /// Intialize.
        /// </summary>
        /// <param name="script"></param>
        /// <param name="scope"></param>
        protected virtual void Init(string script, Scope scope)
        {
            _script = script;
            _scriptPath = string.Empty;
            _statements = new List<Statement>();
            _scope = scope == null ? new Scope() : scope;
            _scanner.Init(_script);
            _state = new ParserState();
        }
        #endregion


        #region Helpers
        /// <summary>
        /// Convert the script into a series of tokens.
        /// </summary>
        protected void Tokenize()
        {
            _lexer.IntepolatedStartChar = _settings.InterpolatedStartChar;

            // Initialize the plugins.
            _context.Plugins.ForEach<ILexPlugin>( plugin => plugin.Init(_lexer));
            var tokens = _lexer.Tokenize();
            _tokenIt = new TokenIterator();
            _tokenIt.Init(tokens, _lexer.LineNumber, _lexer.LineCharPos);
        }        


        /// <summary>
        /// End of statement script.
        /// </summary>
        /// <param name="endOfStatementToken"></param>
        /// <returns></returns>
        protected bool IsEndOfStatementOrEndOfScript(Token endOfStatementToken)
        {
            return IsEndOfStatement(endOfStatementToken) || IsEndOfScript();
        }


        /// <summary>
        /// Whether at end of statement.
        /// </summary>
        /// <returns></returns>
        protected bool IsEndOfStatement(Token endOfStatementToken)
        {
            return (_tokenIt.NextToken.Token == endOfStatementToken);
        }


        /// <summary>
        /// Whether at end of script
        /// </summary>
        /// <returns></returns>
        protected bool IsEndOfScript()
        {
            return _tokenIt.NextToken.Token == Token.EndToken;
        }


        /// <summary>
        /// Parses a sequence of names/identifiers.
        /// </summary>
        /// <returns></returns>
        protected List<string> ParseNames()
        {
            var names = new List<string>();
            while (true)
            {
                // Case 1: () empty list
                if (IsEndOfStatementOrEndOfScript(Tokens.RightParenthesis))
                    break;

                // Case 2: name and auto-advance to next token
                var name = _tokenIt.ExpectId(true);
                names.Add(name);

                // Case 3: only 1 argument. 
                if (IsEndOfStatementOrEndOfScript(Tokens.RightParenthesis))
                    break;

                // Case 4: comma, more names to come
                if (_tokenIt.NextToken.Token == Tokens.Comma) _tokenIt.Advance();
            }
            return names;
        }


        /// <summary>
        /// Sets the script position of the node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="token"></param>
        public void SetScriptPosition(AstNode node, TokenData token = null)
        {
            if (token == null) token = _tokenIt.NextToken;
            node.Ref = new ScriptRef(ScriptName, token.Line, token.CharPos);
        }
        #endregion
    }
}
