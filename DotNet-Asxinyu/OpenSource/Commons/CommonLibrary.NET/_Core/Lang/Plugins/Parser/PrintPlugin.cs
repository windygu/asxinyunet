using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Print plugin derives from the "TakeoverPlugin"
    // Takeovers are keywords that consume the entire line of text in the script
    // after the keyword. 
    // In this case of the Print plugin, it consume the rest of the line and you
    // don't need to wrap text around quotes.
    
    var language = 'fluentscript';
    print No need for quotes in #{language} if text to print is on one line    
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling boolean values in differnt formats (yes, Yes, no, No, off Off, on On).
    /// </summary>
    public class PrintPlugin : LineReaderPlugin
    {
        /// <summary>
        /// Initialize
        /// </summary>
        public PrintPlugin()
        {
            _tokens = new string[] { "Print", "print" };
        }
    }



    /// <summary>
    /// Prints the next token.
    /// </summary>
    public class PrintExpressionPlugin : ExpressionPlugin
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        public PrintExpressionPlugin()
        {
            _canHandleExpression = true;
            _hasStatementSupport = true;
            _handleNewLineAsEndOfExpression = true;
            _expressionTokens = new string[] { "Print", "print" };
        }


        /// <summary>
        /// Parse the expression.
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            var printToken = _tokenIt.NextToken;
            var lineToken = _tokenIt.AdvanceAndGet<Token>();
            Expression lineExp = null;
            if (lineToken is InterpolatedToken)
                lineExp = _parser.ParseInterpolatedExpression((InterpolatedToken)lineToken);
            else
                lineExp = new ConstantExpression(lineToken.Value);

            var exp = new FunctionCallExpression();
            exp.Name = "print";
            exp.IsScopeVariable = false;            
            exp.ParamListExpressions.Add(lineExp);
            _parser.SetScriptPosition(exp, printToken);
            return exp;
        }
    }
}
