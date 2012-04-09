using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>
    // Money plugin simply allows the $ to be prefixed to numbers.
    
    var salary = $225.50;
    if salary is more than $160 then
        print I worked overtime.
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling dates.
    /// </summary>
    class MoneyPlugin : ExpressionPlugin
    {
        private static string[] _tokens = new string[] { "$" };


        /// <summary>
        /// Whether or not this parser can handle the supplied token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool CanHandle(Token token)
        {
            // token has to be a literal token.
            var next = _tokenIt.Peek();
            if ( ! (next.Token is LiteralToken)) return false;
            if ( ! ((LiteralToken)next.Token).IsNumeric()) return false;

            return true;
        }


        /// <summary>
        /// The tokens that are supported for this combinator.
        /// </summary>
        public override string[] ExpressionTokens
        {
            get { return _tokens; }
        }


        /// <summary>
        /// Parses the money expression in form $number
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            // $<number>
            _tokenIt.Advance();
            var val = _tokenIt.ExpectNumber(false);
            return new ConstantExpression(val);
        }
    }
}
