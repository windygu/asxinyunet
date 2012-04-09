using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.Lang;


namespace ComLib.Lang.Extensions
{

    /* *************************************************************************
    <doc:example>	
    // Bool plugin allows aliases for true/false
    
    var result = on;
    var result = off;
    var result = yes;
    var result = no;
    </doc:example>
    ***************************************************************************/

    /// <summary>
    /// Combinator for handling boolean values in differnt formats (yes, Yes, no, No, off Off, on On).
    /// </summary>
    public class BoolPlugin : LexReplacePlugin
    {
        /// <summary>
        /// Initialize
        /// </summary>
        public BoolPlugin()
        {
            _tokens = new string[] { "yes", "Yes", "no", "No", "on", "On", "off", "Off" };

            var replacements = new string[,]
            {
                { "yes", "true" },
                { "Yes", "true" },
                { "on",  "true" },
                { "On",  "true" },
                { "no",  "false"},
                { "No",  "false"},
                { "off", "false"},
                { "Off", "false"}
            };
            base.Init(replacements);
        }
    }
}
