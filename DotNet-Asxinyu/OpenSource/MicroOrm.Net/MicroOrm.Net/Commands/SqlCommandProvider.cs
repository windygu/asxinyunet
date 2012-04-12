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

namespace MicroOrm
{
    public class SqlCommandProvider : CommandBuilder, ICommandProvider
    {
        private string _selectSql = "SELECT $DISTINCT $TAKE $SELECT FROM $TABLE $JOIN $WHERE $GROUPBY $HAVING $ORDERBY";
        private string _selectPagerSql = "SELECT * FROM ($SUBSQL) _Data WHERE [_ROW_NUMBER_] BETWEEN $SKIP AND $TAKE";
        private string _rowNumSql = " ,ROW_NUMBER() OVER({0}) [_ROW_NUMBER_] ";
        private string _parameterPrefix = "@";

        public SqlCommandProvider(Database database, Table table)
            : base(database, table)
        {
        }

        public override bool IsCommandFor(Database database)
        {
            if (database.GetConnection().GetType().FullName.ToLower().Contains("sqlconnection"))
                return true;
            else
                return false;
        }

        public override string GetParameterPrefix()
        {
            return _parameterPrefix;
        }

        public override string GetSelectCommandText(IList<Table> usedTables, IList<DbParameter> parameters, object clauses)
        {
            string from = HandleFrom(usedTables);
            string join = HandleJoin(usedTables, parameters, clauses);
            string select = HandleSelect(usedTables, clauses);
            string distinct = HandleDistinct(clauses);
            string take = HandleTake(clauses);
            string where = HandleWhere(usedTables, parameters, clauses);
            string orderBy = HandleOrderBy(usedTables, clauses);
            string groupBy = HandleGroupBy(usedTables, clauses);
            string having = HandleHaving(usedTables, parameters, clauses);

            AddRowNumColumnToSql(clauses, usedTables, ref orderBy, ref take, ref select);

            string s = _selectSql;
            s = s.Replace("$DISTINCT", distinct);
            s = s.Replace("$TAKE", take);
            s = s.Replace("$TABLE", from);
            s = s.Replace("$JOIN", join);
            s = s.Replace("$WHERE", where);
            s = s.Replace("$ORDERBY", orderBy);
            s = s.Replace("$GROUPBY", groupBy);
            s = s.Replace("$HAVING", having);
            s = s.Replace("$SELECT", select);

            HandleSkip(clauses, ref s);

            return s.RemoveExtraEmpty();
        }

        private string HandleTake(object clauses)
        {
            string take = string.Empty;
            IList<TakeClause> takeClauses = ((IList<ClauseBase>)clauses).OfType<TakeClause>().ToList<TakeClause>();
            if (takeClauses.Count != 0 && takeClauses[0].Take != -1)
                take += " TOP " + takeClauses[0].Take;

            return take;
        }

        private void AddRowNumColumnToSql(object clauses, IList<Table> usedTable, ref string orderBy, ref string take, ref string select)
        {
            IList<TakeClause> takeClauses = ((IList<ClauseBase>)clauses).OfType<TakeClause>().ToList<TakeClause>();
            IList<SkipClause> skipClauses = ((IList<ClauseBase>)clauses).OfType<SkipClause>().ToList();
            if ((takeClauses.Count == 0 || takeClauses[0].Take != -1) && skipClauses.Count == 0)
                return;

            if (!string.IsNullOrEmpty(orderBy))
                select += string.Format(_rowNumSql, orderBy);
            else
            {
                IList<SelectClause> selectClauses = ((IList<ClauseBase>)clauses).OfType<SelectClause>().ToList<SelectClause>();
                string firstColumnName = string.Empty;
                if (selectClauses.Count != 0 && selectClauses[0].Columns.Count != 0)
                    firstColumnName = selectClauses[0].Columns[0].ColumnName;
                else
                    firstColumnName = Database.SchemaProvider.GetTableSchema(GetTableByNameOrAlias(usedTable, Table.TableName).TableName).Columns.First().ColumnName;

                if (usedTable.Any(t => t.TableName.Equals(Table.TableName, StringComparison.OrdinalIgnoreCase)))
                {
                    string s = QuoteColumnWithTable(Quote(usedTable.First(
                        t => t.TableName.Equals(Table.TableName, StringComparison.OrdinalIgnoreCase)).Alias), firstColumnName);

                    select += string.Format(_rowNumSql, " ORDER BY " + s);
                }
                else
                    throw new Exception("The select column must belongs to from table or join table.");
            }

            orderBy = string.Empty;
            take = string.Empty;
        }

        private void HandleSkip(object clauses, ref string sql)
        {
            string skip = string.Empty;
            string take = string.Empty;

            IList<TakeClause> takeClauses = ((IList<ClauseBase>)clauses).OfType<TakeClause>().ToList();
            IList<SkipClause> skipClauses = ((IList<ClauseBase>)clauses).OfType<SkipClause>().ToList();

            if (takeClauses.Count != 0 && takeClauses[0].Take == -1)
            {
                skip = "([_ROW_NUMBER_]-1)";
                take = "[_ROW_NUMBER_]";
            }
            else
            {
                if (skipClauses.Count == 0)
                    return;

                skip = skipClauses[0].Skip.ToString();
                if (takeClauses.Count != 0)
                    take = (skipClauses[0].Skip + takeClauses[0].Take).ToString();
                else
                    take = int.MaxValue.ToString();
            }

            sql = _selectPagerSql.Replace("$SUBSQL", sql);
            sql = sql.Replace("$SKIP", skip);
            sql = sql.Replace("$TAKE", take);
        }
    }
}