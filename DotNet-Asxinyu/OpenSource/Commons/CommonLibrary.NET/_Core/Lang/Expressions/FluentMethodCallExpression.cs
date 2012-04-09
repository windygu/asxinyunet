using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Reflection;


namespace ComLib.Lang
{
    /// <summary>
    /// Function call expression data.
    /// </summary>
    public class FluentMethodCallExpression : Expression
    {
        private string _name1;
        private string _name2;


        /// <summary>
        /// Function call expression
        /// </summary>
        public FluentMethodCallExpression()
        {
        }


        /// <summary>
        /// Initialize using class / method or method / class names and args.
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <param name="args"></param>
        public FluentMethodCallExpression(string name1, string name2, List<Expression> args)
        {
            _name1 = name1;
            _name2 = name2;
        }


        /// <summary>
        /// Evalulate the fluent method call.
        /// </summary>
        /// <returns></returns>
        public override object DoEvaluate()
        {
            Console.WriteLine(_name1 + "." + _name2);
 	         return base.Evaluate();
        }
    }
}

