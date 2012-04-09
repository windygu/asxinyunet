using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Represents keywords in the language.
    /// </summary>
    internal class KeywordToken : Token
    {
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="op"></param>
        public KeywordToken(string op)
        {
            this._text = op;
            this._isKeyword = true;
        }        
    }
}
