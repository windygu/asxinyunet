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
using System.Collections.Concurrent;

namespace MicroOrm
{
	internal class SqlSchemaProvider : ISchemaProvider
	{
		//http://msdn.microsoft.com/en-us/library/cc716729.aspx
		private static readonly Dictionary<string, DbType> DbTypes = new Dictionary<string, DbType>{
																							{"bigint",DbType.Int64},
																							{"binary",DbType.Binary},
																							{"bit",DbType.Boolean},
																							{"char",DbType.String},
																							{"date",DbType.Date},
																							{"datetime",DbType.DateTime},
																							{"datetime2",DbType.DateTime2},
																							{"datetimeoffset",DbType.DateTimeOffset},
																							{"decimal",DbType.Decimal},
																							{"varbinary",DbType.Binary},
																							{"float",DbType.Double},
																							{"image",DbType.Binary},
																							{"int",DbType.Int32},
																							{"money",DbType.Decimal},
																							{"nchar",DbType.StringFixedLength},
																							{"ntext",DbType.String},
																							{"numeric",DbType.Decimal},
																							{"nvarchar",DbType.String},
																							{"real",DbType.Single},
																							{"rowversion",DbType.Binary},
																							{"smalldatetime",DbType.DateTime},
																							{"smallint",DbType.Int16},
																							{"smallmoney",DbType.Decimal},
																							{"sql_variant",DbType.Object},
																							{"text",DbType.String},
																							{"time",DbType.Time},
																							{"timestamp",DbType.Binary},
																							{"tinyint",DbType.Byte},
																							{"uniqueidentifier",DbType.Guid},
																							//{"varbinary",DbType.Binary},
																							{"varchar",DbType.String},
																							{"xml",DbType.Xml}};

        private static readonly Dictionary<string, Type> ClrTypes = new Dictionary<string, Type>{
																							{"bigint",typeof(Int64)},
																							{"binary",typeof(Byte[])},
																							{"bit",typeof(Boolean)},
																							{"char",typeof(String)},
																							{"date",typeof(DateTime)},
																							{"datetime",typeof(DateTime)},
																							{"datetime2",typeof(DateTime)},
																							{"datetimeoffset",typeof(DateTimeOffset)},
																							{"decimal",typeof(Decimal)},
																							{"varbinary",typeof(Byte[])},
																							{"float",typeof(Double)},
																							{"image",typeof(Byte[])},
																							{"int",typeof(Int32)},
																							{"money",typeof(Decimal)},
																							{"nchar",typeof(string)},
																							{"ntext",typeof(string)},
																							{"numeric",typeof(Decimal)},
																							{"nvarchar",typeof(String)},
																							{"real",typeof(Single)},
																							{"rowversion",typeof(Byte[])},
																							{"smalldatetime",typeof(DateTime)},
																							{"smallint",typeof(Int16)},
																							{"smallmoney",typeof(Decimal)},
																							{"sql_variant",typeof(Object)},
																							{"text",typeof(String)},
																							{"time",typeof(TimeSpan)},
																							{"timestamp",typeof(Byte[])},
																							{"tinyint",typeof(Byte)},
																							{"uniqueidentifier",typeof(Guid)},
																							//{"varbinary",typeof(Byte[])},
																							{"varchar",typeof(String)},
																							{"xml",typeof(System.Xml.XmlDocument)}};

		private static readonly string SQL = @"SELECT _#4.* FROM (SELECT _#1.TABLE_CATALOG,_#1.TABLE_NAME,_#1.TABLE_SCHEMA,_#1.COLUMN_NAME,_#1.ORDINAL_POSITION,_#1.DATA_TYPE,_#1.CHARACTER_MAXIMUM_LENGTH,_#3.CONSTRAINT_NAME,_#3.CONSTRAINT_TYPE	FROM INFORMATION_SCHEMA.COLUMNS AS _#1 LEFT JOIN (SELECT _#2.TABLE_SCHEMA, _#2.TABLE_NAME, _#2.CONSTRAINT_NAME, _1.CONSTRAINT_TYPE, _#2.COLUMN_NAME, _#2.ORDINAL_POSITION FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS _1 JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS _#2 ON _#2.CONSTRAINT_SCHEMA=_1.CONSTRAINT_SCHEMA AND _#2.CONSTRAINT_NAME=_1.CONSTRAINT_NAME AND _#2.TABLE_SCHEMA=_1.TABLE_SCHEMA AND _#2.TABLE_NAME=_1.TABLE_NAME) AS _#3 ON _#3.TABLE_NAME=_#1.TABLE_NAME AND _#3.COLUMN_NAME=_#1.COLUMN_NAME) _#4 $WHERE";
        private readonly Database _database;
        private static ConcurrentDictionary<string, TableSchema> _tableSchemas;

		static SqlSchemaProvider()
		{
            _tableSchemas = new ConcurrentDictionary<string, TableSchema>();
		}

		public SqlSchemaProvider(Database database)
		{
            _database = database;
		}

        //internal void CacheTableSchemas()
        //{
        //    IDbCommand cmd = _database.GetConnection().CreateCommand();
        //    if (_database.Transaction != null)
        //        cmd.Transaction = _database.Transaction;

        //    cmd.CommandText = SQL.Replace("$WHERE", string.Empty).RemoveExtraEmpty();
        //    _database.GetConnection().OpenIfClosed();

        //    IDataReader reader = cmd.ExecuteReader();
        //    IEnumerator<Dictionary<string, object>> e = reader.Expand().GetEnumerator();

        //    TableSchema t = null;
        //    while (e.MoveNext())
        //    {
        //        string table_Catalog = e.Current["TABLE_CATALOG"] == DBNull.Value ? string.Empty : e.Current["TABLE_CATALOG"].ToString();
        //        string table_Schema = e.Current["TABLE_SCHEMA"] == DBNull.Value ? string.Empty : e.Current["TABLE_SCHEMA"].ToString();
        //        string table_Name = e.Current["TABLE_NAME"] == DBNull.Value ? string.Empty : e.Current["TABLE_NAME"].ToString();

        //        if (t == null || !t.TableCatalog.Equals(table_Catalog, StringComparison.OrdinalIgnoreCase)
        //            || !t.Table_Schema.Equals(table_Schema, StringComparison.OrdinalIgnoreCase)
        //            || !t.TableName.Equals(table_Name, StringComparison.OrdinalIgnoreCase))
        //        {
        //            t = new TableSchema(table_Name, table_Catalog, table_Schema);
        //            _tables.Add(t);
        //        }

        //        string column_Name = e.Current["COLUMN_NAME"] == DBNull.Value ? string.Empty : e.Current["COLUMN_NAME"].ToString();
        //        string ordinal_Position = e.Current["ORDINAL_POSITION"] == DBNull.Value ? string.Empty : e.Current["ORDINAL_POSITION"].ToString();
        //        string data_Type = e.Current["DATA_TYPE"] == DBNull.Value ? string.Empty : e.Current["DATA_TYPE"].ToString();
        //        int max_lenght = e.Current["CHARACTER_MAXIMUM_LENGTH"] == DBNull.Value ? -1 : Convert.ToInt32(e.Current["CHARACTER_MAXIMUM_LENGTH"].ToString());
        //        string constraint_Name = e.Current["CONSTRAINT_NAME"] == DBNull.Value ? string.Empty : e.Current["CONSTRAINT_NAME"].ToString();
        //        string constraint_Type = e.Current["CONSTRAINT_TYPE"] == DBNull.Value ? string.Empty : e.Current["CONSTRAINT_TYPE"].ToString();

        //        ColumnSchema c = new ColumnSchema(column_Name, t, DbTypes[data_Type], max_lenght, constraint_Type.Equals("PRIMARY KEY", StringComparison.OrdinalIgnoreCase));
        //        t.AddColumn(c);
        //    }

        //    if (_database.Scope == null)
        //        _database.GetConnection().CloseIfOpened();
        //}

        internal TableSchema GetTableSchemaImpl(string table)
        {
            IDbCommand cmd = _database.GetConnection().CreateCommand();
            if (_database.Transaction != null)
                cmd.Transaction = _database.Transaction;

            string where = string.Format(" WHERE _#4.TABLE_NAME='{0}' ", table);
            cmd.CommandText = SQL.Replace("$WHERE", where).RemoveExtraEmpty();
            _database.GetConnection().OpenIfClosed();

            IDataReader reader = cmd.ExecuteReader();
            IEnumerator<Dictionary<string, object>> e = reader.Expand().GetEnumerator();

            TableSchema t = null;
            while (e.MoveNext())
            {
                string table_Catalog = e.Current["TABLE_CATALOG"] == DBNull.Value ? string.Empty : e.Current["TABLE_CATALOG"].ToString();
                string table_Schema = e.Current["TABLE_SCHEMA"] == DBNull.Value ? string.Empty : e.Current["TABLE_SCHEMA"].ToString();
                string table_Name = e.Current["TABLE_NAME"] == DBNull.Value ? string.Empty : e.Current["TABLE_NAME"].ToString();

                if (t == null)
                    t = new TableSchema(table_Name, table_Catalog, table_Schema);

                string column_Name = e.Current["COLUMN_NAME"] == DBNull.Value ? string.Empty : e.Current["COLUMN_NAME"].ToString();
                string ordinal_Position = e.Current["ORDINAL_POSITION"] == DBNull.Value ? string.Empty : e.Current["ORDINAL_POSITION"].ToString();
                string data_Type = e.Current["DATA_TYPE"] == DBNull.Value ? string.Empty : e.Current["DATA_TYPE"].ToString();
                int max_lenght = e.Current["CHARACTER_MAXIMUM_LENGTH"] == DBNull.Value ? -1 : Convert.ToInt32(e.Current["CHARACTER_MAXIMUM_LENGTH"].ToString());
                string constraint_Name = e.Current["CONSTRAINT_NAME"] == DBNull.Value ? string.Empty : e.Current["CONSTRAINT_NAME"].ToString();
                string constraint_Type = e.Current["CONSTRAINT_TYPE"] == DBNull.Value ? string.Empty : e.Current["CONSTRAINT_TYPE"].ToString();

                ColumnSchema c = new ColumnSchema(column_Name, t, DbTypes.First(m => m.Key.Equals(data_Type, StringComparison.OrdinalIgnoreCase)).Value,
                    ClrTypes.First(m => m.Key.Equals(data_Type, StringComparison.OrdinalIgnoreCase)).Value,
                    max_lenght, constraint_Type.Equals("PRIMARY KEY", StringComparison.OrdinalIgnoreCase));
                t.AddColumn(c);
            }

            if (!reader.IsClosed)
                reader.Close();

            if (_database.Scope == null)
                _database.GetConnection().CloseIfOpened();

            return t;
        }

		public TableSchema GetTableSchema(string tableName)
		{
            //if (_tables.Any(t => t.TableName.Equals(tableName, StringComparison.OrdinalIgnoreCase)))
            //    return _tables.First(t => t.TableName.Equals(tableName, StringComparison.OrdinalIgnoreCase));
            //else
            //    return null;

            if (!_tableSchemas.Keys.Any(ts => ts.Equals(tableName, StringComparison.OrdinalIgnoreCase)))
            {
                TableSchema tableSchema = GetTableSchemaImpl(tableName);
                _tableSchemas.TryAdd(tableName, tableSchema);
            }

            return _tableSchemas.First(ts => ts.Key.Equals(tableName, StringComparison.OrdinalIgnoreCase)).Value;
		}

        public IEnumerable<ColumnSchema> GetColumnSchemas(string tableName)
        {
            TableSchema tableSchema = GetTableSchema(tableName);
            if (tableSchema != null)
                return tableSchema.Columns;
            else
                return new List<ColumnSchema>();
        }

        public IEnumerable<ColumnSchema> GetPrimaryKeys(string tableName)
        {
            return GetColumnSchemas(tableName).Where(e => e.IsPrimaryKey);
        }

        public ColumnSchema GetColumnSchema(string tableName, string columnName)
        {
            IEnumerable<ColumnSchema> columnSchemas = GetColumnSchemas(tableName);
            if (columnName.Count() != 0 && columnSchemas.Any(c => c.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase)))
                return columnSchemas.First(c => c.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase));
            else
                return null;
        }
	 }
}