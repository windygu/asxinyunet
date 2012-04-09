using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// String token.
    /// </summary>
    class StringToken : LiteralToken
    {
        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public StringToken()
        {
        }


        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="text">The raw text value</param>
        /// <param name="value">The actual value of the literal</param>
        /// <param name="isKeyword">Whether this is a keyword</param>
        public StringToken(string text, object value, bool isKeyword)
            : base(text, value, isKeyword, false)
        {
        }
    }
}
