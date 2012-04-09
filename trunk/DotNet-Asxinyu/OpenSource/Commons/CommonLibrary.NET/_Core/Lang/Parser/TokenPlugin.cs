using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// A combinator to extend the parser
    /// </summary>
    public class TokenPlugin : ITokenPlugin
    {
        /// <summary>
        /// The starting tokens that are associated w/ the combinator.
        /// </summary>
        protected string[] _tokens;


        /// <summary>
        /// The core parser.
        /// </summary>
        protected Parser _parser;


        /// <summary>
        /// The token iterator
        /// </summary>
        protected TokenIterator _tokenIt;


        /// <summary>
        /// Whether or not this combinator can be made into a statemnt.
        /// </summary>
        protected bool _canHandleToken = false;


        /// <summary>
        /// Initialize the combinator.
        /// </summary>
        /// <param name="parser">The core parser</param>
        /// <param name="tokenIt">The token iterator</param>
        public virtual void Init(Parser parser, TokenIterator tokenIt)
        {
            _parser = parser;
            _tokenIt = tokenIt;
        }


        /// <summary>
        /// The token iterator.
        /// </summary>
        public TokenIterator TokenIt { get { return _tokenIt; } set { _tokenIt = value; } }
        

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
        public virtual Token Parse()
        {
            return null;
        }
    }
}
