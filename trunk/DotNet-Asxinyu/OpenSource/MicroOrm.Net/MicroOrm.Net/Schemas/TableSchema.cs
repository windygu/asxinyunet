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
    public class TableSchema
    {
        private readonly string _tableCatalog;
        private readonly string _tableName;
        private IList<ColumnSchema> _columns;
        private readonly string _tableSchema;

        internal TableSchema(string tableName, string tableCatalog, string tableSchema)
        {
            _tableName = tableName;
            _tableCatalog = tableCatalog;
            _tableSchema = tableSchema;
            _columns = new List<ColumnSchema>();
        }

        internal void AddColumn(ColumnSchema column){
            _columns.Add(column);
        }

        public string TableName
        {
            get { return _tableName; }
        }

        public string TableCatalog
        {
            get { return _tableCatalog; }
        }

        public string Table_Schema
        {
            get { return _tableSchema; }
        }

        public IEnumerable<ColumnSchema> Columns
        {
            get { return _columns; }
        }

        public IEnumerable<ColumnSchema> PrimaryKeys
        {
            get { return _columns.Where(c => c.IsPrimaryKey); }
        }
    }
}
