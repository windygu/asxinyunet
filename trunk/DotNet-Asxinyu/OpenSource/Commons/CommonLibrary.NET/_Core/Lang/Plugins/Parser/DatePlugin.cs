﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>
    // Date plugin allows date expressions in a friendly format like January 1 2001;
    // Following formats are supported.
    
    var date = January 1st 2012;
    var date = Jan
    date = jan 10
    date = Jan 10 2012
    date = Jan 10, 2012
    date = Jan 10th
    date = Jan 10th 2012
    date = Jan 10th, 2012
    date = January 10
    date = January 10, 2012
    date = January 10th
    date = January 10th, 2012
    date = January 10th 2012 at 9:20 am; 
    
    if today is before December 25th 2011 then
	    print Still have time to buy gifts
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling dates.
    /// </summary>
    class DatePlugin : ExpressionPlugin
    {
        private static Dictionary<string, int> _months;


        static DatePlugin()
        {
            _months = new Dictionary<string, int>();
            _months["jan"] = 1;
            _months["feb"] = 2;
            _months["mar"] = 3;
            _months["apr"] = 4;
            _months["may"] = 5;
            _months["jun"] = 6;
            _months["jul"] = 7;
            _months["aug"] = 8;
            _months["sep"] = 9;
            _months["oct"] = 10;
            _months["nov"] = 11;
            _months["dec"] = 12;
            _months["january"] = 1;
            _months["february"] = 2;
            _months["march"] = 3;
            _months["april"] = 4;
            _months["may"] = 5;
            _months["june"] = 6;
            _months["july"] = 7;
            _months["august"] = 8;
            _months["september"] = 9;
            _months["october"] = 10;
            _months["november"] = 11;
            _months["december"] = 12;
        }


        private static string[] _tokens = new string[]
        { 
            "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec",             
            "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jjul", "Aug", "Sep", "Ooct", "Nov", "Dec", 
            
            "january",  "february", "march",    "april",    
            "may",      "june",     "july",     "august",   
            "september","october",  "november", "december",
            "January",  "February", "March",    "April",    
            "May",      "June",     "July",     "August",   
            "September","October",  "November", "December"
        };


        /// <summary>
        /// Whether or not this parser can handle the supplied token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override bool CanHandle(Token token)
        {
            // 1. 1st token is definitely month name in long or short form. "oct" or "october".
            string monthNameOrAbbr = token.Text.ToLower();
            return _months.ContainsKey(monthNameOrAbbr); 
        }


        /// <summary>
        /// The tokens that are supported for this combinator.
        /// </summary>
        public override string[] ExpressionTokens
        {
            get { return _tokens; }
        }


        /// <summary>
        /// Parses the date expression.
        /// - Oct 10
        /// - Oct 10 2011
        /// - Oct 10, 2011
        /// - Oct 10th
        /// - Oct 10th 2011
        /// - Oct 10th, 2011
        /// - October 10
        /// - October 10, 2011
        /// - October 10th
        /// - October 10th, 2011
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            DateTime date = ParseDate(this);
            Expression exp = new ConstantExpression(date);
            return exp;
        }


        /// <summary>
        /// Parses a date.
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        public static DateTime ParseDate(ILangParser parser)
        {
            int year = DateTime.Now.Year;
            TimeSpan time = new TimeSpan(0, 0, 0);
            var tokenIt = parser.TokenIt;

            // 1. 1st token is definitely month name in long or short form. "oct" or "october".
            var monthNameOrAbbr = tokenIt.ExpectId(true, true);
            int month = _months[monthNameOrAbbr.ToLower()];

            // 2. Check for "," after month.
            if (tokenIt.NextToken.Token == Tokens.Comma) tokenIt.Advance();

            // 3. 2nd token is the day 10.
            double day = tokenIt.ExpectNumber(false);

            // 4. Check for "st nd rd th" as in 1st, 2nd, 3rd 4th for the day part.
            var n = tokenIt.Peek();
            var text = n.Token.Text.ToLower();
            if (text == "st" || text == "nd" || text == "rd" || text == "th")
                tokenIt.Advance();

            // 5. Check for another "," after day part.
            n = tokenIt.Peek();
            if (n.Token == Tokens.Comma) tokenIt.Advance();

            // 6. another token after day?
            n = tokenIt.Peek();
            if (n.Token == Tokens.Comma) tokenIt.Advance();

            // 7. Finally check for year
            n = tokenIt.Peek();
            if (n.Token is LiteralToken && ((LiteralToken)n.Token).IsNumeric())
            {
                year = Convert.ToInt32(n.Token.Text);
                tokenIt.Advance();
            }

            // 8. Now check for time.
            n = tokenIt.Peek();
            if (n.Token.Text == "at")
                time = TimePlugin.ParseTime(parser, true, true);

            DateTime date = new DateTime(year, month, (int)day, time.Hours, time.Minutes, time.Seconds);
            return date;
        }
    }
}
