using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{

    /// <summary>
    /// Numeric token
    /// </summary>
    public class NumberToken : LiteralToken
    {
        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public NumberToken()
        {
        }


        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="text">The raw text value</param>
        /// <param name="value">The actual value of the literal</param>
        /// <param name="isKeyword">Whether this is a keyword</param>
        public NumberToken(string text, object value, bool isKeyword)
            : base(text, value, isKeyword, true)
        {
        }
    }
}
