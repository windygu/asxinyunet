using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Swap plugin provides 1 line statement to swap variables.
    
    var a = 1, b = 2;
    
    // Swap values in 1 statement.
    // Instead of needing a third variable.
    swap a with b;
    
    
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling swapping of variable values. swap a and b.
    /// </summary>
    public class SwapPlugin : ExpressionPlugin
    {
        private static string[] _tokens = new string[] { "swap", "Swap" };


        /// <summary>
        /// Intialize.
        /// </summary>
        public SwapPlugin()
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
            _tokenIt.Advance();
            var name1 = _tokenIt.ExpectId(true);
            _tokenIt.ExpectIdText("with", true);
            var name2 = _tokenIt.ExpectId(false);
            return new SwapExpression(name1, name2);
        }
    }


    /// <summary>
    /// Variable expression data
    /// </summary>
    public class SwapExpression : Expression
    {
        private string _name1;
        private string _name2;

        /// <summary>
        /// Initialize with names of variables to swap.
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        public SwapExpression(string name1, string name2)
        {
            _name1 = name1;
            _name2 = name2;
        }


        /// <summary>
        /// Evaluate
        /// </summary>
        /// <returns></returns>
        public override object Evaluate()
        {
            // var a = 1;
            // var b = 2;
            // swap a with b;
            // var temp = a;
            // a = b;
            // b = temp;
            object val1 = this.Ctx.Scope.Get<object>(_name1);
            object val2 = this.Ctx.Scope.Get<object>(_name2);
            this.Ctx.Scope.SetValue(_name1, val2);
            this.Ctx.Scope.SetValue(_name2, val1);
            return val2;
        }
    }
}
