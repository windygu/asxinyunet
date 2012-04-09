using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Used to represent a collection of tokesn comprising an expression inside of a string. e.g. "user name is ${user.name}".
    /// </summary>
    public class InterpolatedToken : Token
    {
        private List<TokenData> _tokens;
        private object _value;


        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="text">The raw text value</param>
        /// <param name="tokens">The list of tokens in the interpolation</param>
        public InterpolatedToken(string text, List<TokenData> tokens)
        {
            this._isKeyword = false;
            this._text = text;
            this._value = text;
            this._tokens = tokens;
        }


        /// <summary>
        /// Value of the literal
        /// </summary>
        public override object Value
        {
            get { return _value; }
        }


        /// <summary>
        /// Get tokens.
        /// </summary>
        public List<TokenData> Tokens
        {
            get { return _tokens; }
        }
    }
}
