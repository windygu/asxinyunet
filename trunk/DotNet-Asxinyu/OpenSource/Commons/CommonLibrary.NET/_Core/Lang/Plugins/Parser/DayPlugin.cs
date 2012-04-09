using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Day plugin allows days of the week to be used as words. 
    // lowercase and uppercase days are supported:
    // 1. Monday - Sunday
    // 2. monday - sunday
    
    var day = Monday;
    day = monday;
    
    if tommorrow is Saturday then
	    print Thank god it's Friday
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling days of the week.
    /// </summary>
    class DayPlugin : ExpressionPlugin
    {
        private static Dictionary<string, DayOfWeek> _days;
        private static Dictionary<string, Func<DateTime>> _dayAliases;


        static DayPlugin()
        {
            _days = new Dictionary<string, DayOfWeek>();            
            _days["monday"]     = DayOfWeek.Monday;
            _days["tuesday"]    = DayOfWeek.Tuesday;
            _days["wednesday"]  = DayOfWeek.Wednesday;
            _days["thursday"]   = DayOfWeek.Thursday;
            _days["friday"]     = DayOfWeek.Friday;
            _days["saturday"]   = DayOfWeek.Saturday;
            _days["sunday"]     = DayOfWeek.Sunday;

            _dayAliases = new Dictionary<string, Func<DateTime>>();
            _dayAliases["today"]     = () => DateTime.Now;
            _dayAliases["yesterday"] = () => DateTime.Now.AddDays(-1);
            _dayAliases["tomorrow"] = () => DateTime.Now.AddDays(1);
        }


        private static string[] _tokens = new string[]
        { 
            "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday",
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday",

            "today", "tomorrow", "yesterday",
            "Today", "Tomorrow", "Yesterday"
        };


        /// <summary>
        /// Initialize
        /// </summary>
        public DayPlugin()
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
            string name = token.Text.ToLower();
            if (_days.ContainsKey(name)) return true;
            if (_dayAliases.ContainsKey(name)) return true;

            return false;
        }


        /// <summary>
        /// Parses the day expression.
        /// Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        /// </summary>
        /// <returns></returns>
        public override Expression Parse()
        {
            var name = _tokenIt.ExpectId(false).ToLower();

            // 1. Day of week : "monday" or "Monday" etc.
            if (_days.ContainsKey(name))
                return new ConstantExpression(_days[name]);

            // 2. DateTime ( today, yesterday, tommorrow )
            var dateTime = _dayAliases[name]();
            return new ConstantExpression(dateTime);
        }
    }
}
