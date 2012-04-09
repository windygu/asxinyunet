using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Run plugin provides alternate way to call a function for fluid syntax.
    // Notes: 
    // 1. The keyword "function" can be aliased with the word "step"
    // 2. The name of a function can be in quotes with spaces.
    
    // This is a function with 0 parameters so parentheses are not required
    step Cleanup
    {
        // do something here.
    }
     
    
    // This is a function with string for name and 0 parameters so parentheses are not required
    step 'Clean up'
    {
        // do something here.
    }
    
    // Example 1: Call function normally
    Cleanup();
    
    // Example 2: Call function using Run keyword
    run Cleanup();
    
    // Example 3: Call function using run without parenthesis for function name.
    run Cleanup;
    
    // Example 4: Call function with spaces in name using run with quotes for function name.    
    run 'Clean up';
    
    // Example 5: Call function with spaces using run and keyword.
    run step 'Clean up';
    
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for function calls using "run" keyword first.
    /// </summary>
    class RunPlugin : ExpressionPlugin
    {
        private static string[] _tokens = new string[] { "run", "Run" };


        /// <summary>
        /// Initialize
        /// </summary>
        public RunPlugin()
        {
            _hasStatementSupport = true;
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
        /// run step 123.
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            string name = ParseRunExpressionName();
            Expression exp = _parser.ParseIdExpression(name);
            return exp;
        }


        /// <summary>
        /// Handles running of functions using syntax 
        /// 1. "run" function "functioname"(parameter_list);
        /// 2. "run "functionname"(parameter_list);
        /// </summary>
        /// <returns></returns>
        private string ParseRunExpressionName()
        {
            _tokenIt.Expect(Tokens.Run);

            // run function 'name';
            // run function touser();
            if (_tokenIt.NextToken.Token == Tokens.Function)
                _tokenIt.Advance();

            // 'username'
            if (!(_tokenIt.NextToken.Token is LiteralToken || _tokenIt.NextToken.Token is IdToken))
                _tokenIt.BuildSyntaxExpectedTokenException("identifier or string");

            string name = _tokenIt.NextToken.Token.Text;
            return name;
        }
    }
}
