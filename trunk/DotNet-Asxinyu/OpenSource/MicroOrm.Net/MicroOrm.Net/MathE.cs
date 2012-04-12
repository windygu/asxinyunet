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
    public enum MathOperator
    {
        Equal,
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public class Math : IEquatable<Math>
    {
        private readonly object _left;
        private readonly object _right;
        private readonly MathOperator _operator;
        //private string _alias;

        internal Math(object left, object right, MathOperator @operator)
        {
            _left = left;
            _right = right;
            _operator = @operator;
        }

        //public Math As(string alias)
        //{
        //    _alias = alias;
        //    return this;
        //}

        public MathOperator Operator
        {
            get { return _operator; }
        }

        public object Right
        {
            get { return _right; }
        }

        public object Left
        {
            get { return _left; }
        }

        public static Math operator +(Math column, object value)
        {
            return new Math(column, value, MathOperator.Add);
        }

        public static Math operator -(Math column, object value)
        {
            return new Math(column, value, MathOperator.Subtract);
        }

        public static Math operator *(Math column, object value)
        {
            return new Math(column, value, MathOperator.Multiply);
        }

        public static Math operator /(Math column, object value)
        {
            return new Math(column, value, MathOperator.Divide);
        }

        public static string GetOperatorString(MathOperator op)
        {
            if (op == MathOperator.Add)
                return "+";
            else if (op == MathOperator.Divide)
                return "/";
            else if (op == MathOperator.Equal)
                return "=";
            else if (op == MathOperator.Multiply)
                return "*";
            else
                return "-";
        }

        public bool Equals(Math other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._left, _left) && Equals(other._right, _right) && Equals(other._operator, _operator);
        }
    }

    public class MathE : Math
    {
        private string _alias;

        public MathE(object left, object right, MathOperator @operator)
            : base(left, right, @operator)
        {
        }

        public MathE As(string alias)
        {
            _alias = alias;
            return this;
        }

        public string Alias
        {
            get { return _alias; }
        }
    }
}
