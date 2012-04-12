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
using System.Dynamic;

namespace MicroOrm
{
    public class Column : DynamicObject
    {
        private string _columnName;
        private Table _table;
        private Math _math;
        private Function _function;

        private string _alias;

        public Table Table
        {
            get { return _table; }
        }

        public string ColumnName
        {
            get { return _columnName; }
        }

        public string Alias
        {
            get { return _alias; }
        }

        public Math Math
        {
            get { return _math; }
        }

        public Function Function
        {
            get { return _function; }
        }

        public Column(Table table, string columnName)
            : this(table, columnName, null)
        {
        }

        public Column(Table table, string columnName, AggregateFunction function)
        {
            _table = table;
            _columnName = columnName;
            _function = function;
        }

        internal Column(Table table, Math math)
        {
            _table = table;
            _math = math;
        }

        public Column As(string alias)
        {
            _alias = alias;
            return this;
        }

        public Column Avg()
        {
            _function = new AggregateFunction(this, "AVG");
            return this;
        }

        public Column Count()
        {
            _function = new AggregateFunction(this, "COUNT");
            return this;
        }

        public Column Max()
        {
            _function = new AggregateFunction(this, "MAX");
            return this;
        }

        public Column Min()
        {
            _function = new AggregateFunction(this, "MIN");
            return this;
        }

        public Column Sum()
        {
            _function = new AggregateFunction(this, "SUM");
            return this;
        }

        public Expression Like(string value)
        {
            if(_function != null)
                throw new Exception("'Like' does not support the other functions.");

            Expression expresssion = new Expression(this, value, ExpressionOperator.Like);
            return expresssion;
        }

        public Expression IsNull()
        {
            if (_function != null)
                throw new Exception("'IsNull' does not support the other functions.");

            Expression expresssion = new Expression(this, null, ExpressionOperator.IsNull);
            return expresssion;
        }

        public Expression IsNotNull()
        {
            if (_function != null)
                throw new Exception("'IsNotNull' does not support the other functions.");

            Expression expresssion = new Expression(this, null, ExpressionOperator.IsNotNull);
            return expresssion;
        }

        public static Column operator +(Column column, object value)
        {
            Math e = new Math(column, value, MathOperator.Add);
            Column f = new Column(column.Table, e);
            return f;
        }

        public static Column operator -(Column column, object value)
        {
            Math e = new Math(column, value, MathOperator.Subtract);
            Column f = new Column(column.Table, e);
            return f;
        }

        public static Column operator *(Column column, object value)
        {
            Math e = new Math(column, value, MathOperator.Multiply);
            Column f = new Column(column.Table, e);
            return f;
        }

        public static Column operator /(Column column, object value)
        {
            Math e = new Math(column, value, MathOperator.Divide);
            Column f = new Column(column.Table, e);
            return f;
        }

        public static Expression operator ==(Column left, object right)
        {
            return new Expression(left, right, ExpressionOperator.Equal);
        }

        public static Expression operator !=(Column left, object right)
        {
            return new Expression(left, right, ExpressionOperator.NotEqual);
        }

        public static Expression operator <(Column left, object right)
        {
            return new Expression(left, right, ExpressionOperator.LessThan);
        }

        public static Expression operator <=(Column left, object right)
        {
            return new Expression(left, right, ExpressionOperator.LessThanOrEqual);
        }

        public static Expression operator >(Column left, object right)
        {
            return new Expression(left, right, ExpressionOperator.GreaterThan);
        }

        public static Expression operator >=(Column left, object right)
        {
            return new Expression(left, right, ExpressionOperator.GreaterThanOrEqual);
        }
    }
}