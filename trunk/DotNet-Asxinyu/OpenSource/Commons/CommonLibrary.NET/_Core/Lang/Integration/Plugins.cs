using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang.Extensions;


namespace ComLib.Lang
{
    
    /// <summary>
    /// Stores all the combinators.
    /// </summary>
    public class Plugins 
    {
        private IDictionary<string, IExpressionPlugin> _stmtPlugins;
        private IDictionary<string, IExpressionPlugin> _expPlugins2;
        private IDictionary<string, IExpressionPlugin> _expPlugins;
        private IDictionary<string, ITokenPlugin> _tokPlugins; 
        private IDictionary<string, ILexPlugin> _lexPlugins;
        
        private bool _hasLiteralCombinators = false;
        private bool _hasTokenPlugins = false;


        /// <summary>
        /// Initialize.
        /// </summary>
        public Plugins()
        {
            _stmtPlugins = new Dictionary<string, IExpressionPlugin>();
            _expPlugins  = new Dictionary<string, IExpressionPlugin>();
            _expPlugins2 = new Dictionary<string, IExpressionPlugin>();
            _tokPlugins  = new Dictionary<string, ITokenPlugin>(); 
            _lexPlugins  = new Dictionary<string, ILexPlugin>();            
        }


        /// <summary>
        /// The total number of combinators.
        /// </summary>
        public int TotalExpressions
        {
            get { return _expPlugins.Count + _expPlugins2.Count; }
        }


        /// <summary>
        /// The total number of combinators.
        /// </summary>
        public int TotalLexical
        {
            get { return _lexPlugins.Count; }
        }


        /// <summary>
        /// The total number of token based plugins.
        /// </summary>
        public int TotalTokens
        {
            get { return _lexPlugins.Count; }
        }

        
        /// <summary>
        /// Whether there exist combinators that handle generic literls aside from IdTokens.
        /// </summary>
        public bool HasLiteralTokenPlugins
        {
            get { return _hasLiteralCombinators; }
        }


        /// <summary>
        /// Whether there exist token based plugins.
        /// </summary>
        public bool HasTokenBasedPlugins
        {
            get { return _hasTokenPlugins; }
        }


        /// <summary>
        /// Register all plugins within the commonlibrary
        /// </summary>
        public void RegisterAll()
        {
            this.Register(new AggregatePlugin());
            this.Register(new BoolPlugin());
            this.Register(new ComparePlugin());
            this.Register(new DatePlugin());
            this.Register(new DayPlugin());
            this.Register(new EnvPlugin());
            this.Register(new FluentPlugin());
            this.Register(new HolidayPlugin());
            this.Register(new LinqPlugin());
            this.Register(new MoneyPlugin());
            this.Register(new PrintPlugin());
            this.Register(new RoundPlugin());
            this.Register(new RunPlugin());
            this.Register(new SwapPlugin());
            this.Register(new TimePlugin());
            this.Register(new UriPlugin());
        }


        /// <summary>
        /// Registers a custom function callback.
        /// </summary>
        /// <param name="pluginToRegister">The function</param>
        public void Register(ILangPlugin pluginToRegister)
        {
            string[] tokens = null;
            if (pluginToRegister is IExpressionPlugin)
            {
                var plugin = pluginToRegister as IExpressionPlugin;
                tokens = plugin.ExpressionTokens;
                foreach (var token in tokens)
                {
                    if (plugin.Precedence == 1)
                    {
                        _expPlugins[token] = plugin;
                    }
                    else
                    {
                        _expPlugins2[token] = plugin;
                    }
                    if (plugin.HasStatementSupport)
                        _stmtPlugins[token] = plugin;

                    if (token == "$NumericLiteralToken")
                        _hasLiteralCombinators = true;
                }
            }
            else if (pluginToRegister is ITokenPlugin)
            {
                var plugin = pluginToRegister as ITokenPlugin;
                tokens = plugin.Tokens;
                if (tokens.Length > 0)
                {
                    foreach (var token in tokens)
                    {
                        _tokPlugins[token] = plugin;
                    }
                    _hasTokenPlugins = true;
                }
            }
            else if (pluginToRegister is ILexPlugin)
            {
                var plugin = pluginToRegister as ILexPlugin;
                tokens = plugin.Tokens;
                if (tokens.Length > 0)
                {
                    foreach (var token in tokens)
                    {
                        _lexPlugins[token] = plugin;
                    }
                }
            }
        }


        /// <summary>
        /// Iterate through all the combinators
        /// </summary>
        /// <param name="callback"></param>
        public void ForEach<T>(Action<T> callback)
        {
            IDictionary<string, T> map = null;
            if (typeof(T) == typeof(IExpressionPlugin))
                map = this._expPlugins as IDictionary<string, T>;

            else if (typeof(T) == typeof(ITokenPlugin))
                map = this._tokPlugins as IDictionary<string, T>;

            else if (typeof(T) == typeof(ILexPlugin))
                map = this._lexPlugins as IDictionary<string, T>;

            foreach (var pair in map) callback(pair.Value);

            if (typeof(T) == typeof(IExpressionPlugin))
            {
                map = this._expPlugins2 as IDictionary<string, T>;
                foreach (var p in map) callback(p.Value);
            }
        }


        /// <summary>
        /// Whether or not there is a combinator that can handle the token supplied.
        /// </summary>
        /// <param name="token">The token to check against combinators.</param>
        /// <returns></returns>
        public bool CanHandleExp(Token token)
        {
            var plugin = GetExp(token);
            if (plugin == null) return false;
            bool canHandle = plugin.CanHandle(token);
            return canHandle;
        }


        /// <summary>
        /// Whether or not there is a lex plugin that can handle the token supplied.
        /// </summary>
        /// <param name="token">The token to check against plugins.</param>
        /// <returns></returns>
        public bool CanHandleLex(Token token)
        {
            var plugin = GetLex(token);
            if (plugin == null) return false;
            bool canHandle = plugin.CanHandle(token);
            return canHandle;
        }


        /// <summary>
        /// Whether or not there is a lex plugin that can handle the token supplied.
        /// </summary>
        /// <param name="token">The token to check against plugins.</param>
        /// <returns></returns>
        public bool CanHandleTok(Token token)
        {
            var plugin = GetTok(token);
            if (plugin == null) return false;
            bool canHandle = plugin.CanHandle(token);
            return canHandle;
        }


        /// <summary>
        /// Whether or not there is an expression based plugin for the token supplied.
        /// </summary>
        /// <param name="token">The token to check against plugins.</param>
        /// <returns></returns>
        public bool ContainsExp(Token token)
        {
            var plugin = GetExp(token);
            return plugin != null;
        }


        /// <summary>
        /// Whether or not there is a token based plugin for the token supplied.
        /// </summary>
        /// <param name="token">The token to check against plugins.</param>
        /// <returns></returns>
        public bool ContainsTok(Token token)
        {
            var plugin = GetTok(token);
            return plugin != null;
        }


        /// <summary>
        /// Whether or not there is a lex based plugin for the token supplied.
        /// </summary>
        /// <param name="token">The token to check against plugins.</param>
        /// <returns></returns>
        public bool ContainsLex(Token token)
        {
            var plugin = GetLex(token);
            return plugin != null;
        }


        /// <summary>
        /// Whether or not the function call supplied is a custom function callback that is 
        /// outside of the script.
        /// </summary>
        /// <param name="name">Name of the function</param>
        /// <returns></returns>
        public bool ContainsExp(string name)
        {
            if (_expPlugins.ContainsKey(name)) return true;
            if (_expPlugins2.ContainsKey(name)) return true;
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsStmt(string name)
        {
            return _stmtPlugins.ContainsKey(name);
        }


        /// <summary>
        /// Get the custom function callback
        /// </summary>
        /// <param name="name">Name of the function</param>
        /// <returns></returns>
        public IExpressionPlugin GetExp(string name)
        {
            name = name.ToLower();
            return _expPlugins[name];
        }


        /// <summary>
        /// Get the expression based plugin associated with the token supplied
        /// </summary>
        /// <param name="token">The token to check against plugins.</param>
        /// <returns></returns>
        public IExpressionPlugin GetExp(Token token)
        {
            string name = token.Text.ToLower();
            if (_expPlugins.ContainsKey(name))
                return _expPlugins[name];
            if (_expPlugins2.ContainsKey(name))
                return _expPlugins2[name];

            // Check token type.
            string type = "$" + token.GetType().Name;
            if (_expPlugins.ContainsKey(type))
                return _expPlugins[type];

            if (_expPlugins2.ContainsKey(type))
                return _expPlugins2[type];
            return null;
        }


        /// <summary>
        /// Get the lex based plugin associated with the token supplied
        /// </summary>
        /// <param name="token">The token to check against plugins.</param>
        /// <returns></returns>
        public ILexPlugin GetLex(Token token)
        {
            string name = token.Text.ToLower();
            if (_lexPlugins.ContainsKey(name))
                return _lexPlugins[name];

            string type = "$" + token.GetType().Name;
            if (_lexPlugins.ContainsKey(type))
                return _lexPlugins[type];

            return null;
        }


        /// <summary>
        /// Get the token based plugin associated with the token supplied
        /// </summary>
        /// <param name="token">The token to check against plugins.</param>
        /// <returns></returns>
        public ITokenPlugin GetTok(Token token)
        {
            string name = token.Text.ToLower();
            if (_tokPlugins.ContainsKey(name))
                return _tokPlugins[name];

            return null;
        }


        /// <summary>
        /// Gets the statement based plugin associated with the token supplied.
        /// </summary>
        /// <param name="name">The name of the token.</param>
        /// <returns></returns>
        public IExpressionPlugin GetStmt(string name)
        {
            name = name.ToLower();
            return _stmtPlugins[name];
        }
    }
}
