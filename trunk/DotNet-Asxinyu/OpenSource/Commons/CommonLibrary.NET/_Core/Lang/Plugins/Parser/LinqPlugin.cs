using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Linq plugin is a Light-weight and partial version of Linq style queries and comprehensions
    // NOTE: This has limited functionality as of this release.
    var books = [ 
				    { name: 'book 1', pages: 200, author: 'homey' },
				    { name: 'book 2', pages: 120, author: 'kdog' },
				    { name: 'book 3', pages: 140, author: 'homeslice' }
			    ];
     
    // Case 1: start with source <books> and system auto creates variable <book>
    var favorites = books where book.pages < 150 and book.author == 'kdog';
    
    // Case 2: using from <variable> in <source>
    var favorities = from book in books where book.pages < 150 and book.author == 'kdog';
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling comparisons.
    /// </summary>
    class LinqPlugin : ExpressionPlugin
    {
        private static string[] _tokens = new string[] { "$IdToken", "select", "from", "where" };
        private static IDictionary<Token, bool> _terminators;


        private string _variableName;
        private Expression _source;
        private Expression _filter;


        static LinqPlugin()
        {
            _terminators = new Dictionary<Token, bool>();
            _terminators[new IdToken("order")] = true;
            _terminators[Tokens.Semicolon] = true;
            _terminators[Tokens.RightParenthesis] = true;
        }


        /// <summary>
        /// Initialize
        /// </summary>
        public LinqPlugin()
        {
            _expressionTokens = _tokens;
        }


        /// <summary>
        /// Whether or not this parser can handle the supplied token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool CanHandle(Token token)
        {
            // 1. set favorites = select book from books where Pages < 100.
            // 2. set favorites = select from books where Pages < 100
            // 3. set favorites = from books where Pages < 100
            // 4. set favorites = books where Pages < 100

            if (string.Compare(token.Text, "select", true) == 0) return true;
            if (string.Compare(token.Text, "from", true) == 0) return true;
            var next = _tokenIt.Peek();
            if (string.Compare(next.Token.Text, "where", true) == 0) return true;

            return false;
        }


        /// <summary>
        /// Handles sql like selections/comprehensions
        /// 1. set favorites = select book from books where Pages > 100.
        /// 2. set favorites = select from books where Pages > 100
        /// 3. set favorites = from books where Pages > 100
        /// 4. set favorites = books where Pages > 100
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            // Handle only 2 for now.
            // 1. from book in books where book.Pages > 100 and author is 'gladwell'
            // 2. books where Pages > 100 and author is 'gladwell'
            ParseFrom();
            _tokenIt.Advance();
            ParseWhere();

            if (_tokenIt.NextToken.Token.Text == "order")
                throw new NotSupportedException("order by not yet supported in Linq plugin for expressions");
            
            return new LinqExpression(_variableName, _source, _filter, null);
        }


        private void ParseFrom()
        {
            var token = _tokenIt.NextToken.Token;
            
            // 1. "from book in books where"            
            if (string.Compare(token.Text, "from", true) == 0)
            {
                _tokenIt.Advance();
                _variableName = _tokenIt.ExpectId();
                _tokenIt.Expect(Tokens.In);
                _source = _parser.ParseIdExpression();
                return;
            }

            // 2. books where
            // In this case autocreate variable "book" using variable name.
            _source = _parser.ParseIdExpression();
            if (_source is VariableExpression)
                _variableName = ((VariableExpression)_source).Name;
            else if (_source is MemberAccessExpression)
                _variableName = ((MemberAccessExpression)_source).MemberName;

            // get "book" from "books".
            _variableName = _variableName.Substring(0, _variableName.Length - 1);
        }


        private void ParseWhere()
        {
            _tokenIt.ExpectIdText("where");
            _filter = _parser.ParseExpressionPart2(_terminators, enablePlugins: false);
        }
    }



    /// <summary>
    /// Expression to represent a Linq like query.
    /// </summary>
    public class LinqExpression : Expression
    {
        private Expression _source = null;
        private string _varName = null;
        private Expression _filter = null;
        private List<Expression> _sorts = null;


        /// <summary>
        /// Initialize
        /// </summary>
        public LinqExpression()
        {
        }


        /// <summary>
        /// Initialize using values.
        /// </summary>
        /// <param name="varName">The name of the variable representing each item in the source</param>
        /// <param name="source">The data source being queried</param>
        /// <param name="filter">The filter to apply on the datasource</param>
        /// <param name="sorts">The sorting to apply after filtering.</param>
        public LinqExpression(string varName, Expression source, Expression filter, List<Expression> sorts)
        {
            _varName = varName;
            _sorts = sorts;
            _source = source;
            _filter = filter;
        }


        /// <summary>
        /// Evaluate the linq expression.
        /// </summary>
        /// <returns></returns>
        public override object Evaluate()
        {
            var array = _source.Evaluate();
            List<object> items = (array as LArray).Raw;
            List<object> results = new List<object>();

            for (int ndx = 0; ndx < items.Count; ndx++)
            {
                var val = items[ndx];
                this.Ctx.Scope.SetValue(_varName, val);
                var isMatch = _filter.EvaluateAs<bool>();
                if (isMatch)
                {
                    results.Add(val);
                }
            }
            return new LArray(this.Ctx, results);
        }
    }
}