using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// String, number, bool(true/false), null
    /// </summary>
    public class LiteralToken : Token
    {
        /// <summary>
        /// The value of this literal
        /// </summary>
        protected object _value;


        /// <summary>
        /// Whether or not this literal is a numeric value.
        /// </summary>
        protected bool _isNumeric = false;


        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public LiteralToken()
        {
        }


        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="text">The raw text value</param>
        /// <param name="value">The actual value of the literal</param>
        /// <param name="isKeyword">Whether this is a keyword</param>
        public LiteralToken(string text, object value, bool isKeyword)
            : this(text, value, isKeyword, false)
        {
        }


        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="text">The raw text value</param>
        /// <param name="value">The actual value of the literal</param>
        /// <param name="isKeyword">Whether this is a keyword</param>
        /// <param name="isNumeric">Whether this is a numeric literal</param>
        public LiteralToken(string text, object value, bool isKeyword, bool isNumeric)
        {
            this._text = text;
            this._value = value;
            this._isKeyword = isKeyword;
            this._isNumeric = isNumeric;
        }


        /// <summary>
        /// Value of the literal
        /// </summary>
        public override object Value
        {
            get { return _value; }
        }


        /// <summary>
        /// Whether or not this literal is a numeric value.
        /// </summary>
        /// <returns></returns>
        public virtual bool IsNumeric()
        {
            return _isNumeric;
        }
    }
}
