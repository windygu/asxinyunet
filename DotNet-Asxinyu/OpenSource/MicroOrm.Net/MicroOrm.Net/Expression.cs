// Copyright 2012, mark.yang.d All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Author: mark.yang.d@gmail.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroOrm
{
    public enum ExpressionOperator
    {
        Equal,
        NotEqual,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
        And,
        Or,
        Like,
        IsNull,
        IsNotNull,
        Empty
    }

    public class Expression
    {
        private readonly object _left;
        private readonly object _right;
        private readonly ExpressionOperator _operator;

        public Expression()
        {
            _left = null;
            _right = null;
            _operator = ExpressionOperator.Empty;
        }

        public Expression(object left, object right, ExpressionOperator @operator)
        {
            _left = left;
            _operator = @operator;
            _right = right;
        }

        public object Left
        {
            get { return _left; }
        }

        public ExpressionOperator Operator
        {
            get { return _operator; }
        }

        public object Right
        {
            get { return _right; }
        }

        public static Expression operator ==(Expression left, Expression right)
        {
            return new Expression(left, right, ExpressionOperator.Equal);
        }

        public static Expression operator !=(Expression left, Expression right)
        {
            return new Expression(left, right, ExpressionOperator.NotEqual);
        }

        public static Expression operator <(Expression left, Expression right)
        {
            return new Expression(left, right, ExpressionOperator.LessThan);
        }

        public static Expression operator <=(Expression left, Expression right)
        {
            return new Expression(left, right, ExpressionOperator.LessThanOrEqual);
        }

        public static Expression operator >(Expression left, Expression right)
        {
            return new Expression(left, right, ExpressionOperator.GreaterThan);
        }

        public static Expression operator >=(Expression left, Expression right)
        {
            return new Expression(left, right, ExpressionOperator.GreaterThanOrEqual);
        }

        public static Expression operator &(Expression left, Expression right)
        {
            return new Expression(left, right, ExpressionOperator.And);
        }

        public static Expression operator |(Expression left, Expression right)
        {
            return new Expression(left, right, ExpressionOperator.Or);
        }

        public static bool operator true(Expression e)
        {
            //if (e.Left == null && e.Right == null)
            //    return true;
            //else
                return false;
        }

        public static bool operator false(Expression e)
        {
            //if (e.Left == null && e.Right == null)
            //    return true;
            //else
                return false;
        }

        public static string GetOperatorString(ExpressionOperator op)
        {
            if (op == ExpressionOperator.And)
                return "AND";
            else if (op == ExpressionOperator.Equal)
                return "=";
            else if (op == ExpressionOperator.GreaterThan)
                return ">";
            else if (op == ExpressionOperator.GreaterThanOrEqual)
                return ">=";
            else if (op == ExpressionOperator.LessThan)
                return "<";
            else if (op == ExpressionOperator.LessThanOrEqual)
                return "<=";
            else if (op == ExpressionOperator.NotEqual)
                return "!=";
            else if (op == ExpressionOperator.Like)
                return "LIKE";
            else if (op == ExpressionOperator.IsNull)
                return "IS NULL";
            else if (op == ExpressionOperator.IsNotNull)
                return "IS NOT NULL";
            else if (op == ExpressionOperator.Empty)
                return "";
            else
                return "OR";
        }
    }
}
