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
using System.Data;
using System.Collections;
using System.Data.Common;

namespace MicroOrm
{
    public class Query : DynamicObject
    {
        private readonly IList<ClauseBase> _clauses;
        private readonly Database _database;
        private readonly Table _table;

        internal Query(Database database, Table table)
        {
            _clauses = new List<ClauseBase>();

            _database = database;
            _table = table;
        }

        public Query Select(params MathE[] maths)
        {
            IList<Column> columns = new List<Column>();
            foreach (var e in maths)
                columns.Add((new Column(_table, e)).As(e.Alias));

            _clauses.Add(new SelectClause(columns));
            return this;
        }

        public Query Select(params Column[] columns)
        {
            _clauses.Add(new SelectClause(columns));
            return this;
        }

        public Query Distinct()
        {
            if (_clauses.OfType<DistinctClause>().Count() != 0)
                throw new Exception("Execute 'Distinct' only once in 'Query'.");

            _clauses.Add(new DistinctClause());
            return this;
        }

        public Query Skip(int skip)
        {
            if (_clauses.OfType<SkipClause>().Count() != 0)
                throw new Exception("Execute 'Skip' only once in 'Query'.");

            if (skip < 0)
                throw new Exception("The argument of 'Skip' must be of type int.");

            _clauses.Add(new SkipClause(skip));
            return this;
        }

        public Query Take(int take)
        {
            if (_clauses.OfType<TakeClause>().Count() != 0)
                throw new Exception("Execute 'Take' only once in 'Query'.");

            if (take < 0)
                throw new Exception("The argument of 'Take' must be of type int.");

            _clauses.Add(new TakeClause(take));
            return this;
        }

        public Query Where(Expression criteria)
        {
            _clauses.Add(new WhereClause(criteria));
            return this;
        }

        //public Query OrderBy
        public Query OrderBy(params Column[] columns)
        {
            foreach(var c in columns)
            {
                OrderByImpl(c, OrderByDirection.Ascending);
            }
            return this;
        }

        public Query OrderByAsc(params Column[] columns)
        {
            foreach (var c in columns)
            {
                OrderByImpl(c, OrderByDirection.Ascending);
            }
            return this;
        }

        public Query OrderByDesc(params Column[] columns)
        {
            foreach (var c in columns)
            {
                OrderByImpl(c, OrderByDirection.Descending);
            }
            return this;
        }

        public Query GroupBy(params Column[] columns)
        {
            //if (_clauses.OfType<GroupByClause>().Count() != 0)
            //    throw new Exception("");

            _clauses.Add(new GroupByClause(columns));
            return this;
        }

        public Query Having(Expression criteria)
        {
            //if (_clauses.OfType<HavingClause>().Count() != 0)
            //    throw new Exception("");

            _clauses.Add(new HavingClause(criteria));
            return this;
        }

        private void OrderByImpl(Column column, OrderByDirection direction)
        {
            if (_clauses.OfType<OrderByClause>().Any(c => (c.Column.Table.TableName.Equals(column.Table.TableName, StringComparison.OrdinalIgnoreCase) 
                && c.Column.ColumnName.Equals(column.ColumnName, StringComparison.OrdinalIgnoreCase))))
                throw new Exception(string.Format("Column '{0}' already belongs to OrderBy clause.", column.ColumnName));

            _clauses.Add(new OrderByClause(column, direction));
        }

        public Query Join(Table joinTable, Expression on)
        {
            return JoinImpl(joinTable, on, JoinType.InnerJoin);
        }

        public Query InnerJoin(Table joinTable, Expression on)
        {
            return JoinImpl(joinTable, on, JoinType.InnerJoin);
        }

        public Query LeftJoin(Table joinTable, Expression on)
        {
            return JoinImpl(joinTable, on, JoinType.LeftJoin);
        }

        public Query LeftOuterJoin(Table joinTable, Expression on)
        {
            return JoinImpl(joinTable, on, JoinType.LeftJoin);
        }

        public Query RightJoin(Table joinTable, Expression on)
        {
            return JoinImpl(joinTable, on, JoinType.RightJoin);
        }

        public Query RightOuterJoin(Table joinTable, Expression on)
        {
            return JoinImpl(joinTable, on, JoinType.RightJoin);
        }

        private Query JoinImpl(Table joinTable, Expression on, JoinType joinType)
        {
            _clauses.Add(new JoinClause(joinTable, on, joinType));
            return this;
        }


        public dynamic First()
        {
            foreach (TakeClause clause in _clauses.OfType<TakeClause>().ToArray())
                _clauses.Remove(clause);

            _clauses.Add(new TakeClause(1));
            return Execute().First();
        }

        public T First<T>()
        {
            return First().To<T>();
        }

        public dynamic Last()
        {
            foreach (TakeClause clause in _clauses.OfType<TakeClause>().ToArray())
                _clauses.Remove(clause);
            foreach (SkipClause clause in _clauses.OfType<SkipClause>().ToArray())
                _clauses.Remove(clause);

            _clauses.Add(new TakeClause(-1));

            return Execute().Last();
        }

        public T Last<T>()
        {
            return Last().To<T>();
        }

        public IList ToList()
        {
            return Execute().ToList().ToList();
        }

        public dynamic[] ToArray()
        {
            return Execute().ToList().ToArray();
        }

        public IList<T> ToList<T>()
        {
            return Execute().ToList<T>().ToList();
        }

        public T[] ToArray<T>()
        {
            return Execute().ToList<T>().ToArray();
        }

        public IList ToScalarList()
        {
            return Execute().ToScalarList().ToList();
        }

        public object[] ToScalarArray()
        {
            return Execute().ToScalarList().ToArray();
        }

        public IList<T> ToScalarList<T>()
        {
            return Execute().ToScalarList<T>().ToList();
        }

        public T[] ToScalarArray<T>()
        {
            return Execute().ToScalarList<T>().ToArray();
        }

        public Result Execute()
        {
            try
            {
                ICommandProvider commandBuilder = CommandProviderFactory.GetCommandBuilder(_database, _table);
                IList<Table> usedTables = new List<Table>();
                IDbCommand command = commandBuilder.GetSelectCommand(usedTables, _clauses);
                if (_database.Transaction != null)
                    command.Transaction = _database.Transaction;

                //write command to output window.
                Extensions.WriteToOutput("---------------------------------------------------------------------------");
                Extensions.WriteToOutput(command.CommandText);
                foreach (DbParameter p in command.Parameters)
                {
                    Extensions.WriteToOutput(string.Format("Name:{0} | Value:{1} | Type:{2} | Direction:{3}", p.ParameterName, p.Value, p.DbType, p.Direction));
                }

                command.Connection.OpenIfClosed();

                IDataReader reader = command.ExecuteReader();
                IEnumerable<Dictionary<string, object>> records = GetRecords(usedTables, reader);

                if (!reader.IsClosed)
                    reader.Close();

                if (_database.Scope == null)
                    command.Connection.CloseIfOpened();

                return new Result(_database, records);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private IEnumerable<Dictionary<string, object>> GetRecords(IList<Table> usedTables, IDataReader reader)
        {
            IList<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                int i = reader.FieldCount;
                Dictionary<string, object> dict = new Dictionary<string, object>();

                for (int j = 0; j < i; j++)
                {
                    string fieldName = reader.GetName(j);
                    object fieldValue = reader.GetValue(j);
                    dict.Add(fieldName, fieldValue == DBNull.Value ? null : fieldValue);
                }

                list.Add(dict);
            }

            return list;
        }
    }
}