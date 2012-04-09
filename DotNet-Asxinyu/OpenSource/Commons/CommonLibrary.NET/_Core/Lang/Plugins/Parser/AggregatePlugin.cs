using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Aggregate plugin allows sum, min, max, avg, count aggregate functions to 
    // be applied to lists of objects.
    
    var numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    var result = 0;
    
    // Example 1: Using format sum of <expression>
    result = sum of numbers;
    result = avg of numbers;
    result = min of numbers;
    result = max of numbers;
    result = count of numbers;
    
    // Example 2: Using format sum(<expression>)
    result = sum( numbers );
    result = avg( numbers );
    result = min( numbers );
    result = max( numbers );
    result = count( numbers );    
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling comparisons.
    /// </summary>
    class AggregatePlugin : ExpressionPlugin
    {
        private static string[] _tokens = new string[] 
        { 
            "avg", "min", "max", "sum", "count", "number", 
            "Avg", "Min", "Max", "Sum", "Count", "Number"
        };


        /// <summary>
        /// Initialize
        /// </summary>
        public AggregatePlugin()
        {
            _canHandleExpression = true;
            _expressionTokens = _tokens;
        }


        /// <summary>
        /// run step 123.
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            // avg min max sum count
            string aggregate = _tokenIt.NextToken.Token.Text.ToLower();

            var next = _tokenIt.Peek().Token;
            Expression exp = null;

            // 1. sum( <expression> )
            if (next == Tokens.LeftParenthesis)
            {
                _tokenIt.Advance(2);
                exp = _parser.ParseExpressionPart(Terminators.ExpParenthesisEnd);
                _tokenIt.Expect(Tokens.RightParenthesis, false);
            }
            // 2. sum of <expression>
            else if (string.Compare(next.Text, "of", true) == 0)
            {
                _tokenIt.Advance(2);
                exp = _parser.ParseExpressionPart2(null, false, true);
            }
            
            AggregateExpression aggExp = new AggregateExpression(aggregate, exp);
            return aggExp;
        }
    }



    /// <summary>
    /// Expression to represent a Linq like query.
    /// </summary>
    public class AggregateExpression : Expression
    {        
        private string _aggregateType;
        private Expression _source;


        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="aggregateType">sum avg min max count total</param>
        /// <param name="source"></param>
        public AggregateExpression(string aggregateType, Expression source)
        {
            _aggregateType = aggregateType;
            _source = source;
        }


        /// <summary>
        /// Evaluate the aggregate expression.
        /// </summary>
        /// <returns></returns>
        public override object Evaluate()
        {
            object dataSource = _source.Evaluate();
            List<object> items = null;

            // Get the right type of list.
            if (dataSource is LArray)
                items = ((LArray)dataSource).Raw;
            else if (dataSource is List<object>)
                items = dataSource as List<object>;
            else
                throw new NotSupportedException(_aggregateType + " not supported for list type of " + dataSource.GetType());

            double val = 0;
            if (_aggregateType == "sum")
                val = items.Sum(item => item == null ? 0 : Convert.ToDouble(item));

            else if (_aggregateType == "avg")
                val = items.Average(item => item == null ? 0 : Convert.ToDouble(item));

            else if (_aggregateType == "min")
                val = items.Min(item => item == null ? 0 : Convert.ToDouble(item));

            else if (_aggregateType == "max")
                val = items.Max(item => item == null ? 0 : Convert.ToDouble(item));

            else if (_aggregateType == "count" || _aggregateType == "number")
                val = items.Count;
            
            return val;
        }
    }
}