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
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Collections;

namespace MicroOrm
{
    public abstract class CommandBuilder : ICommandProvider
    {
        private readonly string _insertSql = "INSERT INTO $TABLE($COLUMNS) VALUES($VALUES)";
        private readonly string _updateSql = "UPDATE $TABLE SET $COLUMNVALUES $WHERE";
        private readonly string _deleteSql = "DELETE FROM $TABLE $WHERE";

        private readonly ISchemaProvider _schemaProvider;
        private readonly DbCommandBuilder _commandBuilder;
        private readonly Database _database;
        private readonly Table _table;
        private readonly string _tableAliasPrefix = "_#{0}_";
        private readonly string _selectColumnPrefix = "{0}_";
        private readonly string _charSeparator = "'";
        private readonly string _parameterFormatString = "{0}p{1}";

        private int _ti;
        private int _pi;

        public CommandBuilder(Database database, Table table)
        {
            _schemaProvider = database.SchemaProvider;
            _commandBuilder = database.CommandBuilder;
            _database = database;
            _table = table;

            _ti = 0;
            _pi = 0;
        }

        public Database Database
        {
            get { return _database; }
        }

        public Table Table
        {
            get { return _table; }
        }

        public string SelectColumnPrefix
        {
            get { return _selectColumnPrefix; }
        }

        internal void AddUsedTable(IList<Table> usedTables, Table table)
        {
            if (!usedTables.Any(t => t.TableName.Equals(table.TableName)))
                usedTables.Add(table);
        }

        public virtual string GetTableDefaultAlias(IList<Table> usedTables, Table table)
        {
            string alias = string.Format(_tableAliasPrefix, _ti);
            while (usedTables.Any(t => t.Alias.Equals(alias, StringComparison.OrdinalIgnoreCase)))
            {
                _ti++;
                alias = string.Format(_tableAliasPrefix, _ti);
            }
            _ti++;
            return alias;
        }

        //handle from
        public virtual string HandleFrom(IList<Table> usedTables)
        {
            string from = QuoteTableWithSchema(Table);
            if (string.IsNullOrEmpty(Table.Alias))
                Table.As(GetTableDefaultAlias(usedTables, Table));

            AddUsedTable(usedTables, Table);

            //AS
            from += " " + Quote(Table.Alias);
            return from;
        }

        //handle join
        public virtual string HandleJoin(IList<Table> usedTables, IList<DbParameter> parameters, object clauses)
        {
            string join = string.Empty;
            IList<JoinClause> joinClauses = ((IList<ClauseBase>)clauses).OfType<JoinClause>().ToList();
            foreach (var clause in joinClauses)
            {
                if (clause.JoinType == JoinType.InnerJoin)
                    join += " INNER JOIN " + QuoteTableWithSchema(clause.JoinTable);
                else if (clause.JoinType == JoinType.LeftJoin)
                    join += " LEFT JOIN " + QuoteTableWithSchema(clause.JoinTable);
                else
                    join += " RIGHT JOIN " + QuoteTableWithSchema(clause.JoinTable);

                if (string.IsNullOrEmpty(clause.JoinTable.Alias))
                    clause.JoinTable.As(GetTableDefaultAlias(usedTables, clause.JoinTable));

                AddUsedTable(usedTables, clause.JoinTable);

                //AS
                join += " " + Quote(clause.JoinTable.Alias);
                join += " ON ";

                //if (clause.On.Left is Column)
                //{
                //    Column left = (Column)clause.On.Left;
                //    string leftAlias = GetTableByNameOrAlias(usedTables, left.Table.TableName).Alias;
                //    join += QuoteColumnWithTable(leftAlias, left.ColumnName);
                //}
                //else if (clause.On.Left is Expression)
                //{
                //    Expression left = (Expression)clause.On.Left;
                //    string s = string.Empty;
                //    HandleExpressionImpl(usedTables, parameters, "where", left, ref s);
                //    join += s;
                //}

                //join += " " + Expression.GetOperatorString(clause.On.Operator) + " ";

                //if (clause.On.Right is Column)
                //{
                //    Column right = (Column)clause.On.Right;
                //    string rightAlias = GetTableByNameOrAlias(usedTables, right.Table.TableName).Alias;
                //    join += QuoteColumnWithTable(rightAlias, right.ColumnName);
                //}
                //else if (clause.On.Right is Expression)
                //{
                //    Expression right = (Expression)clause.On.Right;
                //    string s = string.Empty;
                //    HandleExpressionImpl(usedTables, parameters, "where", right, ref s);
                //    join += s;
                //}

                string s = string.Empty;
                HandleExpressionImpl(usedTables, parameters, "where", clause.On, ref s);
                join += s;
            }
            return join;
        }

        //handle where
        public virtual string HandleWhere(IList<Table> usedTables, IList<DbParameter> parameters, object clauses)
        {
            string where = string.Empty;
            IList<WhereClause> whereClauses = ((IList<ClauseBase>)clauses).OfType<WhereClause>().ToList<WhereClause>();
            foreach (var clause in whereClauses)
            {
                if (!string.IsNullOrEmpty(where))
                    where += " AND ";

                Expression expression = clause.Criteria;
                HandleExpressionImpl(usedTables, parameters, "where",  expression, ref where);
            }
            if (!string.IsNullOrEmpty(where))
                where = " WHERE " + where;
            return where;
        }

        public virtual string HandleDistinct(object clauses)
        {
            string distinct = string.Empty;
            IList<DistinctClause> takeClauses = ((IList<ClauseBase>)clauses).OfType<DistinctClause>().ToList<DistinctClause>();
            if (takeClauses.Count != 0)
                distinct = " DISTINCT ";

            return distinct;
        }

        public virtual string HandleTake(object clauses)
        {
            string take = string.Empty;
            IList<TakeClause> takeClauses = ((IList<ClauseBase>)clauses).OfType<TakeClause>().ToList<TakeClause>();
            if (takeClauses.Count != 0)
                take += " TOP " + takeClauses[0].Take;

            return take;
        }

        //handle select
        public virtual string HandleSelect(IList<Table> usedTables, object clauses)
        {
            string select = string.Empty;
            IList<SelectClause> selectClauses = ((IList<ClauseBase>)clauses).OfType<SelectClause>().ToList<SelectClause>();
            if (selectClauses.Count != 0)
            {
                IList<string> selectColumnNames = new List<string>();
                int i = 0;
                foreach (var clause in selectClauses)
                {
                    foreach (var column in clause.Columns)
                    {
                        string s = string.Empty;
                        HandleSelectImpl(usedTables, column, ref s);

                        string columnAlias = string.Empty;
                        if (!string.IsNullOrEmpty(column.Alias))
                            columnAlias = Quote(column.Alias);
                        else
                        {
                            if (column.Math != null)
                                columnAlias = Quote("c" + (++i).ToString());
                            else
                                columnAlias = Quote(column.ColumnName);
                        }

                        selectColumnNames.Add(columnAlias);
                        select += ((!string.IsNullOrEmpty(select)) ? "," : string.Empty) + s + " " + columnAlias;
                    }
                }
            }
            else
                select = JoinSeparator(Quote(Table.Alias), "*");

            return select;
        }

        //select impl
        private void HandleSelectImpl(IList<Table> usedTables, Column column, ref string select)
        {
            string s = string.Empty;
            if (column.Math != null)
            {
                s += "(";
                if (column.Math.Left is Column)
                    HandleSelectImpl(usedTables, (Column)column.Math.Left, ref s);
                else
                {
                    Type t = column.Math.Left.GetType();
                    if (t == typeof(Int32) || t == typeof(Int16) || t == typeof(Int64) || t == typeof(int))
                        s += column.Math.Left.ToString();
                    else if (t == typeof(Char) || t == typeof(String) || t == typeof(DateTime) || t == typeof(Guid))
                        s += _charSeparator + column.Math.Left.ToString() + _charSeparator;
                    else if (t == typeof(Boolean))
                        s += Convert.ToInt32((bool)column.Math.Left);
                    else
                        throw new Exception(string.Format("Column '{0}' does not support operator.", string.IsNullOrEmpty(column.Alias) ? column.ColumnName : column.Alias));
                }

                s += " " + Math.GetOperatorString(column.Math.Operator) + " ";

                if (column.Math.Right is Column)
                    HandleSelectImpl(usedTables, (Column)column.Math.Right, ref s);
                else
                {
                    Type t = column.Math.Right.GetType();
                    if (t == typeof(Int32) || t == typeof(Int16) || t == typeof(Int64) || t == typeof(int))
                        s += column.Math.Right.ToString();
                    else if (t == typeof(Char) || t == typeof(String) || t == typeof(DateTime) || t == typeof(Guid))
                        s += _charSeparator + column.Math.Right.ToString() + _charSeparator;
                    else if (t == typeof(Boolean))
                        s += Convert.ToInt32((bool)column.Math.Right);
                    else
                        throw new Exception(string.Format("Column '{0}' does not support operator.", string.IsNullOrEmpty(column.Alias) ? column.ColumnName : column.Alias));
                }

                s += ")";
                select += s;
            }
            else
            {
                string tableAlias = GetTableByNameOrAlias(usedTables, column.Table.TableName).Alias;
                string temp = !string.IsNullOrEmpty(tableAlias) ? QuoteColumnWithTable(Quote(tableAlias), column.ColumnName) : QuoteColumnWithTableSchema(column);
                if (column.Function != null)
                {
                    if (column.Function is AggregateFunction)
                        temp = string.Format("{0}({1})", column.Function.FunctionName, temp);
                }

                s = temp;
                select += s;
            }
        }

        //handle orderby
        public virtual string HandleOrderBy(IList<Table> usedTables, object clauses)
        {
            string s = string.Empty;
            IList<GroupByClause> groupByClauses = ((IList<ClauseBase>)clauses).OfType<GroupByClause>().ToList<GroupByClause>();
            IList<OrderByClause> orderByClauses = ((IList<ClauseBase>)clauses).OfType<OrderByClause>().ToList<OrderByClause>();
            foreach (var clause in orderByClauses)
            {
                if (!string.IsNullOrEmpty(s)) s += ",";

                Column column = clause.Column;
                string tableAlias = GetTableByNameOrAlias(usedTables, column.Table.TableName).Alias;
                string temp = !string.IsNullOrEmpty(tableAlias) ? QuoteColumnWithTable(Quote(tableAlias), column.ColumnName) : QuoteColumnWithTableSchema(column);
                if (column.Function != null)
                {
                    if (column.Function is AggregateFunction)
                        temp = string.Format("{0}({1})", column.Function.FunctionName, temp);
                }

                s += temp + " " + OrderByClause.GetDirectionString(clause.Direction);
            }

            return string.IsNullOrEmpty(s) ? s : " ORDER BY " + s;
        }

        //handle groupby
        public virtual string HandleGroupBy(IList<Table> usedTables, object clauses)
        {
            string groupBy = string.Empty;
            IList<GroupByClause> groupByClauses = ((IList<ClauseBase>)clauses).OfType<GroupByClause>().ToList<GroupByClause>();
            if (groupByClauses.Count == 0)
                return groupBy;

            GroupByClause groupByClause = groupByClauses.First();
            foreach (var column in groupByClause.Columns)
            {
                if (!string.IsNullOrEmpty(groupBy))
                    groupBy += ",";

                string alias = GetTableByNameOrAlias(usedTables, column.Table.TableName).Alias;
                groupBy += QuoteColumnWithTable(Quote(alias), column.ColumnName);
            }

            if (!string.IsNullOrEmpty(groupBy))
                groupBy = " GROUP BY " + groupBy;

            return groupBy;
        }

        private void GetHavingCloumns(Expression e, IList<Column> havingColumns)
        {
            object left = e.Left;
            object right = e.Right;
            if (left is Expression)
                GetHavingCloumns((Expression)left, havingColumns);
            else if (left is Column)
                havingColumns.Add((Column)left);

            if (right is Expression)
                GetHavingCloumns((Expression)right, havingColumns);
            else if (right is Column)
                havingColumns.Add((Column)right);
        }

        public virtual string HandleHaving(IList<Table> usedTables, IList<DbParameter> parameters, object clauses)
        {
            string having = string.Empty;
            IList<GroupByClause> groupByClauses = ((IList<ClauseBase>)clauses).OfType<GroupByClause>().ToList<GroupByClause>();
            IList<HavingClause> HavingClauses = ((IList<ClauseBase>)clauses).OfType<HavingClause>().ToList<HavingClause>();
            if (HavingClauses.Count == 0)
                return having;

            HavingClause havingClause = HavingClauses.First();

            Expression expression = havingClause.Criteria;
            HandleExpressionImpl(usedTables, parameters, "having", expression, ref having);

            IList<Column> havingColumns = new List<Column>();
            GetHavingCloumns(expression, havingColumns);
            foreach (var column in havingColumns)
            {
                MicroOrm.Table table = GetTableByNameOrAlias(usedTables, column.Table.TableName);    
            }

            if (!string.IsNullOrEmpty(having))
                having = " HAVING " + having;

            return having;
        }

        //expression impl
        private void HandleExpressionImpl(IList<Table> usedTables, IList<DbParameter> parameters, string type, Expression e, ref string expressionString)
        {
            if (e.Operator == ExpressionOperator.Empty)
                return;

            object left = e.Left;
            object right = e.Right;

            if (((left is Expression && ((Expression)left).Operator == ExpressionOperator.Empty) || (right is Expression && ((Expression)right).Operator == ExpressionOperator.Empty)) && e.Operator != ExpressionOperator.And)
            {
                throw new Exception("Empty expression only support 'and' operator.");
            }

            if (left is Expression)
            {
                expressionString += "(";
                HandleExpressionImpl(usedTables, parameters, type, (Expression)left, ref expressionString);
            }
            else if (left is Column)
            {
                Column leftColumn = (Column)left;
                string leftColumnTableAlias = GetTableByNameOrAlias(usedTables, leftColumn.Table.TableName).Alias;
                string s = !string.IsNullOrEmpty(leftColumnTableAlias) ? QuoteColumnWithTable(Quote(leftColumnTableAlias), leftColumn.ColumnName) : QuoteColumnWithTableSchema(leftColumn);
                if (leftColumn.Function != null)
                {
                    if (leftColumn.Function is AggregateFunction)
                        s = string.Format("{0}({1})", leftColumn.Function.FunctionName, s);
                }
                expressionString += s;
            }
            else
            {
                if (e.Operator != ExpressionOperator.IsNull && e.Operator != ExpressionOperator.IsNotNull)
                {
                    string parameterName = string.Format(_parameterFormatString, GetParameterPrefix(), _pi++);
                    expressionString += parameterName;

                    object parameterValue = left;
                    if (parameterValue == null)
                        parameterValue = DBNull.Value;

                    Column rightColumn = (Column)right;
                    DbParameter p = CreateDbDataParameter(parameterName, Database.SchemaProvider.GetColumnSchema(GetTableByNameOrAlias(usedTables, rightColumn.Table.TableName).TableName, rightColumn.ColumnName).DbType, parameterValue);
                    parameters.Add(p);
                }
            }

            if ((left is Expression && ((Expression)left).Operator == ExpressionOperator.Empty) ||
                (right is Expression && ((Expression)right).Operator == ExpressionOperator.Empty))
            { }
            else
                expressionString += " " + Expression.GetOperatorString(e.Operator) + " ";

            string rightString = string.Empty;
            if (right is Expression)
            {
                HandleExpressionImpl(usedTables, parameters, type, (Expression)right, ref expressionString);
                expressionString += ")";
            }
            else if (right is Column)
            {
                Column rightColumn = (Column)right;
                string rightColumnTableAlias = GetTableByNameOrAlias(usedTables, rightColumn.Table.TableName).Alias;
                string s = !string.IsNullOrEmpty(rightColumnTableAlias) ? QuoteColumnWithTable(Quote(rightColumnTableAlias), rightColumn.ColumnName) : QuoteColumnWithTableSchema(rightColumn);
                if (rightColumn.Function != null)
                {
                    if (rightColumn.Function is AggregateFunction)
                        s = string.Format("{0}({1})", rightColumn.Function.FunctionName, s);
                }

                expressionString += s;
            }
            else
            {
                if (e.Operator != ExpressionOperator.IsNull && e.Operator != ExpressionOperator.IsNotNull)
                {
                    string parameterName = string.Format(_parameterFormatString, GetParameterPrefix(), _pi++);
                    expressionString += parameterName;

                    object parameterValue = right;
                    if (parameterValue == null)
                        parameterValue = DBNull.Value;

                    Column leftColumn = (Column)left;
                    DbParameter p = CreateDbDataParameter(parameterName, Database.SchemaProvider.GetColumnSchema(GetTableByNameOrAlias(usedTables, leftColumn.Table.TableName).TableName, leftColumn.ColumnName).DbType, parameterValue);
                    parameters.Add(p);
                }
            }
        }

        public string JoinSeparator(string s1, string s2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(s1);
            sb.Append(_commandBuilder.SchemaSeparator);
            sb.Append(s2);

            return sb.ToString();
        }

        public string Quote(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_commandBuilder.QuotePrefix);
            sb.Append(s);
            sb.Append(_commandBuilder.QuoteSuffix);
            return sb.ToString();
        }

        public string QuoteTableWithSchema(Table table)
        {
            TableSchema ts = _schemaProvider.GetTableSchema(table.TableName);

            StringBuilder sb = new StringBuilder();
            sb.Append(_commandBuilder.QuotePrefix);
            sb.Append(ts.Table_Schema);
            sb.Append(_commandBuilder.QuoteSuffix);
            sb.Append(_commandBuilder.SchemaSeparator);
            sb.Append(_commandBuilder.QuotePrefix);
            sb.Append(ts.TableName);
            sb.Append(_commandBuilder.QuoteSuffix);

            return sb.ToString();
        }

        public string QuoteColumnWithTableSchema(Table table, string columnName)
        {
            ColumnSchema cs = _schemaProvider.GetColumnSchema(table.TableName, columnName);

            StringBuilder sb = new StringBuilder();
            sb.Append(QuoteTableWithSchema(table));
            sb.Append(_commandBuilder.SchemaSeparator);
            sb.Append(_commandBuilder.QuotePrefix);
            sb.Append(cs.ColumnName);
            sb.Append(_commandBuilder.QuoteSuffix);
            return sb.ToString();
        }

        public string QuoteColumnWithTable(string tableName, string columnName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(tableName);
            sb.Append(_commandBuilder.SchemaSeparator);
            sb.Append(_commandBuilder.QuotePrefix);
            sb.Append(columnName);
            sb.Append(_commandBuilder.QuoteSuffix);
            return sb.ToString();
        }

        public string QuoteColumnWithTableSchema(Column column)
        {
            return QuoteColumnWithTableSchema(column.Table, column.ColumnName);
        }

        private DbParameter CreateDbDataParameter(string name, DbType dbType, object value)
        {
            return CreateDbDataParameter(name, dbType, -1, value);
        }

        private DbParameter CreateDbDataParameter(string name, DbType dbType, int size, object value)
        {
            DbParameter parameter = Database.DbProviderFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.DbType = dbType;
            if (size != -1)
                parameter.Size = size;
            parameter.Value = value;

            return parameter;
        }

        public Table GetTableByNameOrAlias(IList<Table> usedTables, string tableNameOrAlias)
        {
            int count = usedTables.Count(t => t.TableName.Equals(tableNameOrAlias, StringComparison.OrdinalIgnoreCase)) +
                usedTables.Count(t => t.Alias.Equals(tableNameOrAlias, StringComparison.OrdinalIgnoreCase));
            if (count != 1)
                throw new Exception(string.Format("A table with name or alias '{0}' already existed.", tableNameOrAlias));

            return usedTables.First(t => t.TableName.Equals(tableNameOrAlias, StringComparison.OrdinalIgnoreCase) ||
                t.Alias.Equals(tableNameOrAlias, StringComparison.OrdinalIgnoreCase));
        }

        private void Clear()
        {
            _table.As(string.Empty);
            _ti = 0;
            _pi = 0;
        }

        public virtual IDbCommand GetSelectCommand(IList<Table> usedTables, object clauses)
        {
            IList<DbParameter> parameters = new List<DbParameter>();
            IDbCommand command = Database.GetConnection().CreateCommand();
            command.CommandText = GetSelectCommandText(usedTables, parameters, clauses);
            foreach (var p in parameters)
                command.Parameters.Add(p);

            Clear();
            return command;
        }

        public virtual IDbCommand GetInsertCommand(IDictionary dict)
        {
            string columns = string.Empty;
            string values = string.Empty;
            IList<DbParameter> parameters = new List<DbParameter>();
            IList<string> columnNames = new List<string>();

            foreach (string key in dict.Keys)
            {
                if (columnNames.Any(k => k.Equals(key, StringComparison.OrdinalIgnoreCase)))
                    continue;

                if (dict[key] == null)
                    continue;

                ColumnSchema columnSchema = _schemaProvider.GetColumnSchema(Table.TableName, key);
                if (columnSchema == null)
                    continue;

                object parameterValue = dict[key];
                if (parameterValue != null)
                {
                    try
                    {
                        parameterValue = Convert.ChangeType(parameterValue, columnSchema.ClrType);
                    }
                    catch
                    {
                        throw new Exception(string.Format("Cannot covert '{0}' to '{1}' on column '{2}'.", parameterValue.GetType().FullName, columnSchema.ClrType, key));
                    }
                }
                else
                    parameterValue = DBNull.Value;

                string parameterName = string.Format(_parameterFormatString, GetParameterPrefix(), _pi++);
                DbParameter parameter = CreateDbDataParameter(parameterName, columnSchema.DbType, columnSchema.MaxLength, parameterValue);
                parameters.Add(parameter);

                if (!string.IsNullOrEmpty(columns))
                    columns += ",";
                if (!string.IsNullOrEmpty(values))
                    values += ",";

                columns += QuoteColumnWithTableSchema(Table, columnSchema.ColumnName);
                values += parameterName;
            }

            if(string.IsNullOrEmpty(columns) || string.IsNullOrEmpty(values))
                throw new Exception("No column to be inserted.");

            IDbCommand insertCommand = _database.GetConnection().CreateCommand();
            foreach (var p in parameters)
                insertCommand.Parameters.Add(p);

            string s = _insertSql.Replace("$TABLE", QuoteTableWithSchema(Table));
            s = s.Replace("$COLUMNS", columns);
            s = s.Replace("$VALUES", values);
            insertCommand.CommandText = s.RemoveExtraEmpty();

            Clear();
            return insertCommand;
        }

        public IDbCommand GetUpdateCommand(Expression criteria, IDictionary dict)
        {
            IList<Table> usedTables = new List<Table>() { Table };
            IList<string> keyColumnNames = new List<string>();

            IList<DbParameter> parameters = new List<DbParameter>();
            Dictionary<string, string> parameterColumnNames = new Dictionary<string, string>();
            string columnValues = string.Empty;
            string where = string.Empty;

            //where
            if (criteria == null)
            {
                if (dict.Count <= 1)
                    throw new Exception("No column to be updated.");

                IList<ColumnSchema> primaryKeyColumnSchemas = _schemaProvider.GetPrimaryKeys(Table.TableName).ToList();
                if (primaryKeyColumnSchemas.Count == 0)
                    throw new Exception(string.Format("Unable to find primary key in '{0}'.", Table.TableName));

                foreach (var keyColumnSchema in primaryKeyColumnSchemas)
                {
                    if (!dict.Keys.OfType<string>().Any(k => k.Equals(keyColumnSchema.ColumnName, StringComparison.OrdinalIgnoreCase)))
                        throw new Exception("Unable to find primary colunm.");

                    if (!string.IsNullOrEmpty(where))
                        where += " AND ";

                    keyColumnNames.Add(keyColumnSchema.ColumnName);

                    string parameterName = string.Empty;
                    object parameterValue = null;
                    if (parameterColumnNames.Keys.Any(n => n.Equals(keyColumnSchema.ColumnName, StringComparison.OrdinalIgnoreCase)))
                        parameterName = parameterColumnNames[parameterColumnNames.Keys.First(n => n.Equals(keyColumnSchema.ColumnName, StringComparison.OrdinalIgnoreCase))];
                    else
                    {
                        parameterValue = dict[dict.Keys.OfType<string>().First(k => k.Equals(keyColumnSchema.ColumnName, StringComparison.OrdinalIgnoreCase))];
                        if (parameterValue == null)
                        {
                            throw new Exception(string.Format("Column '{0}' is primary key, it's value can not be null.", keyColumnSchema.ColumnName));
                        }

                        if (parameterValue != null)
                        {
                            try
                            {
                                parameterValue = Convert.ChangeType(parameterValue, keyColumnSchema.ClrType);
                            }
                            catch
                            {
                                throw new Exception(string.Format("Cannot covert '{0}' to '{1}' on column '{2}'.", parameterValue.GetType().FullName, keyColumnSchema.ClrType, keyColumnSchema.ColumnName));
                            }

                            parameterName = string.Format(_parameterFormatString, GetParameterPrefix(), _pi++);
                            DbParameter parameter = CreateDbDataParameter(parameterName, keyColumnSchema.DbType, keyColumnSchema.MaxLength, parameterValue);
                            parameters.Add(parameter);
                        }
                    }

                    if (parameterValue != null)
                        where += QuoteColumnWithTableSchema(Table, keyColumnSchema.ColumnName) + "=" + parameterName;
                    else
                        where += QuoteColumnWithTableSchema(Table, keyColumnSchema.ColumnName) + " IS NULL ";
                }

                where = " WHERE " + where;
            }
            else
            {
                if (dict == null || dict.Count < 1)
                    throw new Exception("No column to be updated.");

                IList<ClauseBase> clauses = new List<ClauseBase>();
                clauses.Add(new WhereClause(criteria));
                where = HandleWhere(usedTables, parameters, clauses);
            }

            //column-values
            foreach (string key in dict.Keys)
            {
                if (keyColumnNames.Any(k => k.Equals(key, StringComparison.OrdinalIgnoreCase)))
                    continue;

                ColumnSchema columnSchema = _schemaProvider.GetColumnSchema(Table.TableName, key);
                if (columnSchema == null)
                    continue;

                string parameterName = string.Empty;
                object parameterValue = null;
                if (parameterColumnNames.Keys.Any(n => n.Equals(columnSchema.ColumnName, StringComparison.OrdinalIgnoreCase)))
                    parameterName = parameterColumnNames[parameterColumnNames.Keys.First(n => n.Equals(columnSchema.ColumnName, StringComparison.OrdinalIgnoreCase))];
                else
                {
                    parameterValue = dict[key];
                    if (parameterValue != null)
                    {
                        try
                        {
                            parameterValue = Convert.ChangeType(parameterValue, columnSchema.ClrType);
                        }
                        catch
                        {
                            throw new Exception(string.Format("Cannot covert '{0}' to '{1}' on column '{2}'.", parameterValue.GetType().FullName, columnSchema.ClrType, key));
                        }
                    }
                    else
                        parameterValue = DBNull.Value;

                    parameterName = string.Format(_parameterFormatString, GetParameterPrefix(), _pi++);
                    DbParameter parameter = CreateDbDataParameter(parameterName, columnSchema.DbType, columnSchema.MaxLength, parameterValue);
                    parameters.Add(parameter);
                }

                if (!string.IsNullOrEmpty(columnValues)) columnValues += ",";
                columnValues += QuoteColumnWithTableSchema(Table, columnSchema.ColumnName) + "=" + parameterName;
            }

            if (string.IsNullOrEmpty(columnValues) || string.IsNullOrEmpty(where))
                throw new Exception("No column to be updated.");

            IDbCommand updateCommand = _database.GetConnection().CreateCommand();
            foreach (var p in parameters)
                updateCommand.Parameters.Add(p);

            string s = _updateSql.Replace("$TABLE", QuoteTableWithSchema(Table));
            s = s.Replace("$COLUMNVALUES", columnValues);
            s = s.Replace("$WHERE", where);
            updateCommand.CommandText = s.RemoveExtraEmpty();

            Clear();
            return updateCommand;
        }

        public IDbCommand GetDeleteCommand(Expression criteria, IDictionary dict)
        {
            IList<Table> usedTables = new List<Table>() { Table };
            IList<string> keyColumnNames = new List<string>();

            IList<DbParameter> parameters = new List<DbParameter>();
            Dictionary<string, string> parameterColumnNames = new Dictionary<string, string>();
            string where = string.Empty;

            if (criteria == null)
            {
                if (dict.Count <= 1)
                    throw new Exception("No row to be deleted.");

                IList<ColumnSchema> columnSchemas = _schemaProvider.GetColumnSchemas(Table.TableName).ToList();
                if (columnSchemas.Count == 0)
                    throw new Exception(string.Format("Unable to find any column in '{0}'.", Table.TableName));

                foreach (string key in dict.Keys)
                {
                    if (!columnSchemas.Any(k => k.ColumnName.Equals(key, StringComparison.OrdinalIgnoreCase)))
                        continue;

                    ColumnSchema columnSchema = columnSchemas.First(k => k.ColumnName.Equals(key, StringComparison.OrdinalIgnoreCase));

                    if (!string.IsNullOrEmpty(where))
                        where += " AND ";

                    keyColumnNames.Add(key);

                    string parameterName = string.Empty;
                    object parameterValue = null;
                    if (parameterColumnNames.Keys.Any(n => n.Equals(columnSchema.ColumnName, StringComparison.OrdinalIgnoreCase)))
                        parameterName = parameterColumnNames[parameterColumnNames.Keys.First(n => n.Equals(columnSchema.ColumnName, StringComparison.OrdinalIgnoreCase))];
                    else
                    {
                        parameterValue = dict[key];
                        if (parameterValue != null)
                        {
                            try
                            {
                                parameterValue = Convert.ChangeType(parameterValue, columnSchema.ClrType);
                            }
                            catch
                            {
                                throw new Exception(string.Format("Cannot covert '{0}' to '{1}' on column '{2}'.", parameterValue.GetType().FullName, columnSchema.ClrType, key));
                            }

                            parameterName = string.Format(_parameterFormatString, GetParameterPrefix(), _pi++);
                            DbParameter parameter = CreateDbDataParameter(parameterName, columnSchema.DbType, columnSchema.MaxLength, parameterValue);
                            parameters.Add(parameter);
                        }
                    }

                    if (parameterValue != null)
                        where += QuoteColumnWithTableSchema(Table, columnSchema.ColumnName) + "=" + parameterName;
                    else
                        where += QuoteColumnWithTableSchema(Table, columnSchema.ColumnName) + " IS NULL ";
                }

                where = " WHERE " + where;
            }
            else
            {
                if (dict != null && dict.Count != 0)
                    throw new Exception("No row to be deleted.");

                IList<ClauseBase> clauses = new List<ClauseBase>();
                clauses.Add(new WhereClause(criteria));
                where = HandleWhere(usedTables, parameters, clauses);
            }

            if (string.IsNullOrEmpty(where))
                throw new Exception("No row to be deleted.");

            IDbCommand deleteCommand = _database.GetConnection().CreateCommand();
            foreach (var p in parameters)
            {
                deleteCommand.Parameters.Add(p);
            }

            string s = _deleteSql.Replace("$TABLE", QuoteTableWithSchema(Table));
            s = s.Replace("$WHERE", where);
            deleteCommand.CommandText = s.RemoveExtraEmpty();

            Clear();
            return deleteCommand;
        }

        public abstract bool IsCommandFor(Database database);
        public abstract string GetParameterPrefix();
        public abstract string GetSelectCommandText(IList<Table> usedTables, IList<DbParameter> parameters, object clauses);
    }
}