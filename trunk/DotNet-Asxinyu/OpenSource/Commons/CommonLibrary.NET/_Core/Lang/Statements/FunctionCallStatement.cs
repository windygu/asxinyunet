﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.Lang
{
    /// <summary>
    /// Function call statement.
    /// </summary>
    public class FunctionCallStatement : Statement
    {
        /// <summary>
        /// The function call expression.
        /// </summary>
        public Expression Exp;


        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="exp"></param>
        public FunctionCallStatement(Expression exp)
        {
            this.Exp = exp;
        }
               

        /// <summary>
        /// Execute the function.
        /// </summary>
        public override void DoExecute()
        {
            this.Exp.Evaluate();
        }
    }
}
