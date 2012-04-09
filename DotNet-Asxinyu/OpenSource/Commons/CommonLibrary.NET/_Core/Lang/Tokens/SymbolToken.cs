using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Represents different non-alphanumeric chars on keyboard # $ % / * etc.
    /// </summary>
    internal class SymbolToken : Token
    {
        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="op"></param>
        public SymbolToken(string op)
        {
            this._text = op;
            this._isKeyword = false;
        }
    }
}
