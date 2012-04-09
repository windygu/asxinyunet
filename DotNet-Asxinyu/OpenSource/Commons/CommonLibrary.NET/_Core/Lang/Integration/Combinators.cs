using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Stores all the combinators.
    /// </summary>
    public class Combinators 
    {
        private Dictionary<string, ILangCombinator> _stmtCombinators;
        private Dictionary<string, ILangCombinator> _expCombinators;
        private Dictionary<string, ILangCombinator> _lexCombinators;
        private bool _hasLiteralCombinators = false;


        /// <summary>
        /// Initialize.
        /// </summary>
        public Combinators()
        {
            _stmtCombinators = new Dictionary<string, ILangCombinator>();
            _expCombinators = new Dictionary<string, ILangCombinator>();
            _lexCombinators = new Dictionary<string, ILangCombinator>();
        }


        /// <summary>
        /// The total number of combinators.
        /// </summary>
        public int Count
        {
            get { return _expCombinators.Count; }
        }


        /// <summary>
        /// Whether there exist combinators that handle generic literls aside from IdTokens.
        /// </summary>
        public bool HasLiteralTokenCombinators
        {
            get { return _hasLiteralCombinators; }
        }


        /// <summary>
        /// Registers a custom function callback.
        /// </summary>
        /// <param name="combinator">The function</param>
        public void Register(ILangCombinator combinator)
        {
            var tokens = combinator.ExpressionTokens;
            foreach (var token in tokens)
            {
                _expCombinators[token] = combinator;
                if (combinator.HasStatementSupport)
                    _stmtCombinators[token] = combinator;

                if (token == "$NumericLiteralToken")
                    _hasLiteralCombinators = true;
            }
        }


        /// <summary>
        /// Iterate through all the combinators
        /// </summary>
        /// <param name="callback"></param>
        public void ForEach(Action<KeyValuePair<string, ILangCombinator>> callback)
        {
            foreach (var pair in this._expCombinators)
            {
                callback(pair);
            }
        }


        /// <summary>
        /// Whether or not there is a combinator that can handle the token supplied.
        /// </summary>
        /// <param name="token">The token to check against combinators.</param>
        /// <returns></returns>
        public bool CanHandleExp(Token token)
        {
            var combinator = GetExpCombinator(token);
            if (combinator == null) return false;
            bool canHandle = combinator.CanHandle(token);
            return canHandle;
        }


        /// <summary>
        /// Whether or not there is a combinator for the token supplied.
        /// </summary>
        /// <param name="token">The token to check against combinators.</param>
        /// <returns></returns>
        public bool ContainsExpToken(Token token)
        {
            var combinator = GetExpCombinator(token);
            return combinator != null;
        }


        /// <summary>
        /// Whether or not the function call supplied is a custom function callback that is 
        /// outside of the script.
        /// </summary>
        /// <param name="name">Name of the function</param>
        /// <returns></returns>
        public bool ContainsExpToken(string name)
        {
            return _expCombinators.ContainsKey(name);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsStmtToken(string name)
        {
            return _stmtCombinators.ContainsKey(name);
        }


        /// <summary>
        /// Get the custom function callback
        /// </summary>
        /// <param name="name">Name of the function</param>
        /// <returns></returns>
        public ILangCombinator GetExpCombinator(string name)
        {
            name = name.ToLower();
            return _expCombinators[name];
        }


        /// <summary>
        /// Get the custom function callback
        /// </summary>
        /// <param name="token">The token to check against combinators.</param>
        /// <returns></returns>
        public ILangCombinator GetExpCombinator(Token token)
        {
            string name = token.Text.ToLower();
            if (_expCombinators.ContainsKey(name))
                return _expCombinators[name];

            // Check token type.
            string type = "$" + token.GetType().Name;
            if (_expCombinators.ContainsKey(type))
                return _expCombinators[type];

            return null;
        }


        /// <summary>
        /// Get the custom function callback
        /// </summary>
        /// <param name="name">Name of the function</param>
        /// <returns></returns>
        public ILangCombinator GetStmtCombinator(string name)
        {
            name = name.ToLower();
            return _stmtCombinators[name];
        }
    }
}
