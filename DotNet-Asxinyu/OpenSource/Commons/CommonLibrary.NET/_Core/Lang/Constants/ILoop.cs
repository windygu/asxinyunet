﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Interface for a loop
    /// </summary>
    internal interface ILoop
    {
        /// <summary>
        /// Continue to next iteration.
        /// </summary>
        void Continue();


        /// <summary>
        /// Break the loop.
        /// </summary>
        void Break();
    }



    /// <summary>
    /// Interface for expression that uses parameters. right now "new" and "function".
    /// </summary>
    public interface IParameterExpression
    {
        /// <summary>
        /// List of evaluated parameters
        /// </summary>
        List<object> ParamList { get; set; }


        /// <summary>
        /// List of expressions representing the parameters.
        /// </summary>
        List<Expression> ParamListExpressions { get; set; }
    }
}
