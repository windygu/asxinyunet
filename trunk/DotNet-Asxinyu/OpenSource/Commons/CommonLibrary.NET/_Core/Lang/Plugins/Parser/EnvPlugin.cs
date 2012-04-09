using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Env plugin allows direct access to environment variables via the "env" object.
    
    // Example 1: Access to user variables only via the ".user" property of env.
    result = env.user.path;
    
    // Example 2: Access to system variables via the ".sys" property of env.
    result = env.sys.path;
    
    // Example 3: Access to environment variable without specifying sys or user.
    result = env.path;
    result = env.SystemRoot;
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for getting environment variables in format $env.name $env.user.name $env.sys.name.
    /// </summary>
    class EnvPlugin : ExpressionPlugin
    {
        private static string[] _tokens = new string[] { "env" };


        /// <summary>
        /// Whether or not this parser can handle the supplied token.
        /// </summary>
        /// <returns></returns>
        public EnvPlugin()
        {
            _canHandleExpression = true;
        }


        /// <summary>
        /// The tokens that are supported for this combinator.
        /// </summary>
        public override string[] ExpressionTokens
        {
            get { return _tokens; }
        }


        /// <summary>
        /// Parses the day expression.
        /// Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            // Move past $ in $env
            //if(_tokenIt.NextToken.Token.Text == "$") 
            //    _tokenIt.Advance();

            _tokenIt.ExpectIdText("env", true);
            _tokenIt.Expect(Tokens.Dot);
            var name = _tokenIt.ExpectId(false);
            name = name.ToLower();

            string val = "";
            
            // Case 1: $env.sys.systemroot
            // Case 2: $env.user.systemroot            
            if (name == "sys" || name == "user" )
            {
                EnvironmentVariableTarget target = (name == "sys")
                                                 ? EnvironmentVariableTarget.Machine
                                                 : EnvironmentVariableTarget.User;
                _tokenIt.Advance();
                name = _tokenIt.ExpectId(false);
                val = System.Environment.GetEnvironmentVariable(name, target);
                return new ConstantExpression(val);
            }
            // Case 3: $env.systemroot
            val = System.Environment.GetEnvironmentVariable(name);
            return new ConstantExpression(val);
        }
    }
}
