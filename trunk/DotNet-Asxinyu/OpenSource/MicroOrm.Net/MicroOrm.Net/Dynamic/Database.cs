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
using System.Collections.Concurrent;
using System.Data.Common;
using System.Configuration;

namespace MicroOrm
{
    public abstract class Scope : IDisposable
    {
        private Database _database;

        public Scope(Database database)
        {
            _database = database;
            _database.GetConnection().OpenIfClosed();
        }

        public Database Database
        {
            get { return _database; }
        }
        
        public void Dispose()
        {
            _database.GetConnection().CloseIfOpened();
        }
    }

    public class CodeScope : Scope, IDisposable
    {
        public CodeScope(Database database)
            :base(database)
        {
        }

        public void Dispose()
        {
            base.Dispose();
        }
    }

    public class TransactionScope : Scope, IDisposable
    {
        private IDbTransaction _transaction;

        public TransactionScope(Database database)
            : this(database, IsolationLevel.ReadCommitted)
        {
        }

        public IDbTransaction Transaction
        {
            get { return _transaction; }
        }

        public TransactionScope(Database database, IsolationLevel isolationLevel)
            : base(database)
        {
            _transaction = database.GetConnection().BeginTransaction(isolationLevel);
            database.Transaction = _transaction;
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            try
            {
                _transaction.Commit();
                Database.Transaction = null;
                base.Dispose();
            }
            catch (Exception e)
            {
                _transaction.Rollback();
                Database.Transaction = null;
                base.Dispose();
                throw e;
            }
        }
    }

    public class Database : DynamicObject
    {
        private readonly ConcurrentDictionary<string, dynamic> _members = new ConcurrentDictionary<string, dynamic>();
        private readonly DbConnection _connection;
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly ISchemaProvider _schemaProvider;
        private readonly DbCommandBuilder _dbCommandBuilder;

        private IDbTransaction _transaction;
        private Scope _scope;

        internal Database(string provider, string connectionString)
        {
            _dbProviderFactory = DbProviderFactories.GetFactory(provider);
            _connection = _dbProviderFactory.CreateConnection();
            _connection.ConnectionString = connectionString;
            _schemaProvider = SchemaProviderFactory.GetSchemaProvider(this);
            _dbCommandBuilder = _dbProviderFactory.CreateCommandBuilder();
        }

        public Scope BeginTransactionScope()
        {
            return BeginTransactionScope(IsolationLevel.ReadCommitted);
        }

        public Scope BeginTransactionScope(IsolationLevel isolationLevel)
        {
            _scope = new TransactionScope(this, isolationLevel);
            return _scope;
        }

        public Scope BeginCodeScope()
        {
            _scope = new CodeScope(this);
            return _scope;
        }

        public Scope Scope
        {
            get { return _scope; }
        }

        internal IDbTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        public DbProviderFactory DbProviderFactory
        {
            get { return _dbProviderFactory; }
        }

        public ISchemaProvider SchemaProvider
        {
            get { return _schemaProvider; }
        }

        public DbCommandBuilder CommandBuilder
        {
            get { return _dbCommandBuilder; }
        }

        public static dynamic Open(string providerName, string connectionString)
        {
            return new Database(providerName, connectionString);
        }

        public static dynamic Open(string connectionStringName)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionStringName];
            return Open(settings.ProviderName, settings.ConnectionString);
        }

        public IDbConnection GetConnection()
        {
            return _connection;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return base.GetDynamicMemberNames();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            result = _members.GetOrAdd(name, CreateDynamicTable);
            return true;
        }

        public Table CreateDynamicTable(string name)
        {
            return new Table(name, this);
        }
    }
}