using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// A combinator to extend the parser
    /// </summary>
    public class LexerPlugin : ILexPlugin
    {
        /// <summary>
        /// The starting tokens that are associated w/ the combinator.
        /// </summary>
        protected string[] _tokens;


        /// <summary>
        /// The main lexer.
        /// </summary>
        protected Lexer _lexer;


        /// <summary>
        /// Whether or not this combinator can be made into a statemnt.
        /// </summary>
        protected bool _canHandleToken = false;


        /// <summary>
        /// Initialize the combinator.
        /// </summary>
        /// <param name="lexer">The main lexer</param>
        public virtual void Init(Lexer lexer)
        {
            _lexer = lexer;
        }


        /// <summary>
        /// get / set the lexer.
        /// </summary>
        public virtual Lexer Lexer
        {
            get { return _lexer; }
            set { _lexer = value; }
        }


        /// <summary>
        /// The tokens that are associated w/ this combinator.
        /// </summary>
        public virtual string[] Tokens
        {
            get { return _tokens; }
        }


        /// <summary>
        /// Whether or not this parser can handle the supplied token.
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public virtual bool CanHandle(Token current)
        {
            return _canHandleToken;
        }


        /// <summary>
        /// Parses the expression.
        /// </summary>
        /// <returns></returns>
        public virtual Token[] Parse()
        {
            return null;
        }
    }
}
