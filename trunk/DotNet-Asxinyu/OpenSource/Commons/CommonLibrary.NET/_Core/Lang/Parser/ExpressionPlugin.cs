using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// A combinator to extend the parser
    /// </summary>
    public class ExpressionPlugin : IExpressionPlugin
    {
        /// <summary>
        /// The token iterator
        /// </summary>
        protected TokenIterator _tokenIt;


        /// <summary>
        /// Tokens to handle the expression.
        /// </summary>
        protected string[] _expressionTokens;


        /// <summary>
        /// The core parser.
        /// </summary>
        protected Parser _parser;


        /// <summary>
        /// Whether or not this combinator can be made into a statemnt.
        /// </summary>
        protected bool _hasStatementSupport = false;


        /// <summary>
        /// Whether or not to handle a new line as end of this expression plugin and for statement support.
        /// </summary>
        protected bool _handleNewLineAsEndOfExpression = false;


        /// <summary>
        /// Whether or not this combinator can be made into a statemnt.
        /// </summary>
        protected bool _canHandleExpression = false;


        /// <summary>
        /// A number given to each plugin to give it an ordering compared to other plugins.
        /// </summary>
        protected int _precedence = 1;
        

        /// <summary>
        /// The token iterator.
        /// </summary>
        public TokenIterator TokenIt { get { return _tokenIt; } set { _tokenIt = value; } }
        

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
        /// A number given to each plugin to give it an ordering compared to other plugins.
        /// </summary>
        public virtual int Precedence { get { return _precedence; } }


        /// <summary>
        /// Whether or not this combinator can be made into a statement.
        /// </summary>
        public bool HasStatementSupport { get { return _hasStatementSupport; } }


        /// <summary>
        /// The tokens that are associated w/ this combinator.
        /// </summary>
        public virtual string[] ExpressionTokens
        {
            get { return _expressionTokens; }
        }


        /// <summary>
        /// Whether or not to handle a new line as end of statement/expression.
        /// </summary>
        public virtual bool IsNewLineEndOfExpression
        {
            get { return _handleNewLineAsEndOfExpression; }
        }


        /// <summary>
        /// Whether or not this parser can handle the supplied token.
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public virtual bool CanHandle(Token current)
        {
            return _canHandleExpression;
        }


        /// <summary>
        /// Parses the expression.
        /// </summary>
        /// <returns></returns>
        public virtual Expression Parse()
        {
            return null;
        }
    }
}
