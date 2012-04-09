using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;


namespace ComLib.Lang
{
    /// <summary>
    /// Base class for Expressions
    /// </summary>
    public class Expression : AstNode
    {
        /// <summary>
        /// Evaluate
        /// </summary>
        /// <returns></returns>
        public virtual object Evaluate()
        {
            object result = null;
            if (this.Ctx != null && this.Ctx.Callbacks.HasAny)
            {
                Ctx.Callbacks.Notify("expression-on-before-execute", this, this);
                result = DoEvaluate();
                Ctx.Callbacks.Notify("expression-on-after-execute", this, this);
                return result;
            }
            result = DoEvaluate();
            return result;
        }


        /// <summary>
        /// Evaluate and return as datatype T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T EvaluateAs<T>()
        {
            object result = Evaluate();
            return (T)Convert.ChangeType(result, typeof(T));
        }


        /// <summary>
        /// Internal method to wrap statement executions around the callbacks.
        /// </summary>
        public virtual object DoEvaluate()
        {
            return null;
        }
    }
}
