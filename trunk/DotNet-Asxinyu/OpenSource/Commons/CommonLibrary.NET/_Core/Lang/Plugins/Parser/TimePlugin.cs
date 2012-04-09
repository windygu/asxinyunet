using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Time plugin provides a convenient way to represent time in fluent syntax.
    
    var t = 12:30 pm;
    
    if t is 12:30 pm then
	    print it's time to go to lunch!
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling dates. noon afternoon. evening, nite midnight
    /// </summary>
    class TimePlugin : ExpressionPlugin
    {
        private static string[] _tokens = new string[] { "$NumberToken", "Noon", "noon", "midnight", "Midnight" };
        private static Dictionary<string, TimeSpan> _aliases;

        /// <summary>
        /// Initialize
        /// </summary>
        static TimePlugin()
        {
            _aliases = new Dictionary<string, TimeSpan>();
            _aliases["noon"] = new TimeSpan(12, 0, 0);
            _aliases["Noon"] = new TimeSpan(12, 0, 0);
            _aliases["midnight"] = new TimeSpan(0, 0, 0);
            _aliases["Midnight"] = new TimeSpan(0, 0, 0);
        }


        /// <summary>
        /// Whether or not this parser can handle the supplied token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool CanHandle(Token token)
        {
            if (_aliases.ContainsKey(token.Text.ToLower()))
                return true;

            // token has to be a literal token.
            if (!((LiteralToken)token).IsNumeric()) return false;

            var next = _tokenIt.Peek().Token;
            if ( next != Tokens.Colon && !( next.Text == "am" || next.Text == "pm" )) 
                return false;

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
        /// Parses the time expression.
        /// - 12pm
        /// - 12:30pm
        /// - 12:30 pm
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            var time = ParseTime(this, false, false);
            return new ConstantExpression(time);
        }

    
        /// <summary>
        /// Parses the time in format 12[:minutes:seconds] am|pm.
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="advance"></param>
        /// <param name="expectAt"></param>
        /// <returns></returns>
        public static TimeSpan ParseTime(ILangParser parser, bool advance, bool expectAt)
        {
            double minutes = 0;
            double seconds = 0;
            double hours = DateTime.Now.Hour;

            var tokenIt = parser.TokenIt;
            if(advance) tokenIt.Advance();

            if (expectAt)
            {
                // 1. Expect 'at"
                tokenIt.ExpectIdText("at", true);
            }

            string tokenText = tokenIt.NextToken.Token.Text.ToLower();
            if (_aliases.ContainsKey(tokenText))
                return _aliases[tokenText];
            
            // 3. Hour part
            hours = tokenIt.ExpectNumber(true);

            // 4. check for ":" for minutes
            if (tokenIt.NextToken.Token == Tokens.Colon)
            {
                tokenIt.Advance();

                // 5. Minutes part.
                minutes = tokenIt.ExpectNumber(true);

                if (tokenIt.NextToken.Token == Tokens.Colon)
                {
                    tokenIt.Advance();
                    seconds = tokenIt.ExpectNumber(true);
                }
            }

            var text = tokenIt.NextToken.Token.Text;

            if (text != "am" && text != "pm")
                throw tokenIt.BuildSyntaxExpectedTokenException("am/pm");

            if (text == "pm" && hours >= 1 && hours <= 11)
                hours += 12;
            return new TimeSpan((int)hours, (int)minutes, (int)seconds);
        }
    }
}
