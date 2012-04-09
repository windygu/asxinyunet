using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Round plugin provides functions to round, round up or round down numbers.
    
    var a = 2.3;
    
    // Rounds the number using standing round technique of .4
    var b = round 2.3;
    
    // Gets rounded up to 3
    var c = round up 2.3; 
    
    // Gets rounded down to 2
    var d = round down 2.3;
    
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling swapping of variable values. swap a and b.
    /// </summary>
    public class RoundPlugin : ExpressionPlugin
    {
        private static string[] _tokens = new string[] { "Round", "round" };

        /// <summary>
        /// How to round
        /// </summary>
        public enum RoundMode
        {
            /// <summary>
            /// Normal rounding technique.
            /// </summary>
            Round,


            /// <summary>
            /// Rounds up to the nearest integer ( ceil )
            /// </summary>
            RoundUp,

            
            /// <summary>
            /// Rounds down to the nearest integer ( floor )
            /// </summary>
            RoundDown
        }


        /// <summary>
        /// Intialize.
        /// </summary>
        public RoundPlugin()
        {
            _hasStatementSupport = false;
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
            RoundMode mode = RoundMode.Round;
            Token t = _tokenIt.Peek().Token;
            if(string.Compare(t.Text, "up", true) == 0) 
            {
                mode = RoundMode.RoundUp;
                _tokenIt.Advance();
            }
            else if (string.Compare(t.Text, "down", true) == 0)
            {
                mode = RoundMode.RoundDown;
                _tokenIt.Advance();
            }
            _tokenIt.Advance();

            // The expression to round.
            var exp = _parser.ParseExpressionPart2(null, true, true);
            return new RoundExpression(mode, exp);
        }
    }


    /// <summary>
    /// Variable expression data
    /// </summary>
    public class RoundExpression : Expression
    {

        private RoundPlugin.RoundMode _mode;
        private Expression _exp;

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="mode">How to round</param>
        /// <param name="exp">The expression value to round</param>
        public RoundExpression(RoundPlugin.RoundMode mode, Expression exp)
        {
            _mode = mode;
            _exp = exp;
        }


        /// <summary>
        /// Evaluate
        /// </summary>
        /// <returns></returns>
        public override object Evaluate()
        {
            var result = _exp.Evaluate();
            double val = 0;
            if (result is double)
                val = (double)result;
            else if (result is int)
                val = (int)result;
            else
                throw new LangException("runtime", "Unexpected type to round", this.Ref.ScriptName, this.Ref.LineNumber, this.Ref.CharPosition);

            if (_mode == RoundPlugin.RoundMode.Round)
                val = Math.Round(val, MidpointRounding.AwayFromZero);
            else if (_mode == RoundPlugin.RoundMode.RoundDown)
                val = Math.Floor(val);
            else if (_mode == RoundPlugin.RoundMode.RoundUp)
                val = Math.Ceiling(val);

            return val;
        }
    }
}
