﻿// Copyright 2012, mark.yang.d All Rights Reserved.
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

namespace MicroOrm
{
    public class ColumnSchema
    {
        private readonly string _columnName;
        private readonly TableSchema _table;
        private readonly bool _IsPrimaryKey;

        private readonly DbType _dbType;
        private readonly Type _clrType;
        private readonly int _maxLength;

        internal ColumnSchema(string columnName, TableSchema table, DbType dbType, Type clrType)
            : this(columnName, table, dbType, clrType, -1)
        { }

        internal ColumnSchema(string columnName, TableSchema table, DbType dbType, Type clrType, int maxLength)
            : this(columnName, table, dbType, clrType, maxLength, false)
        {
        }

        internal ColumnSchema(string columnName, TableSchema table, DbType dbType, Type clrType, int maxLength, bool isPrimaryKey)
        {
            _columnName = columnName;
            _table = table;
            _dbType = dbType;
            _clrType = clrType;
            _maxLength = maxLength;
            _IsPrimaryKey = isPrimaryKey;
        }

        public string ColumnName
        {
            get { return _columnName; }
        }

        public TableSchema Table
        {
            get { return _table; }
        }

        public DbType DbType
        {
            get { return _dbType; }
        }

        public Type ClrType
        {
            get { return _clrType; }
        }

        public int MaxLength
        {
            get { return _maxLength; }
        }

        public bool IsPrimaryKey
        {
            get { return _IsPrimaryKey; }
        }
    }
}
