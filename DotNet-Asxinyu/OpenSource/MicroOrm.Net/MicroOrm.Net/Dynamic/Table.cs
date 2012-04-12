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
using System.Collections;

namespace MicroOrm
{
    public class Table : DynamicObject
    {
        private readonly Dictionary<string, Func<object[], object>> _delegates;
        private readonly ICollection _delegatesAsCollection;

        private string _alias;
        private string _tableName;
        private Database _database;

        public Table(string tableName, Database database)
        {
            _delegates = new Dictionary<string, Func<object[], object>>();
            _delegatesAsCollection = _delegates;

            _tableName = tableName;
            _database = database;
        }

        public Table As(string alias)
        {
            _alias = alias;
            return this;
        }

        public string Alias
        {
            get { return _alias; }
        }

        public string TableName
        {
            get { return _tableName; }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var signature = MethodSignature.FromBinder(binder, args);
            Func<object[], object> func;
            if (_delegatesAsCollection.IsSynchronized && _delegates.ContainsKey(signature))
            {
                func = _delegates[signature];
            }
            else
            {
                lock (_delegatesAsCollection.SyncRoot)
                {
                    if (!_delegates.ContainsKey(signature))
                    {
                        func = CreateMemberDelegate(signature, binder, args);
                        _delegates.Add(signature, func);
                    }
                    else
                    {
                        func = _delegates[signature];
                    }
                }
            }
            if (func != null)
            {
                result = func(args);
                return true;
            }

            var command = MethodFactory.GetCommand(binder.Name);
            if (command != null)
            {
                result = command.Execute(_database, this, binder, args);
                return true;
            }

            var query = new Query(_database, this);
            if (query.TryInvokeMember(binder, args, out result))
            {
                return true;
            }

            return base.TryInvokeMember(binder, args, out result);
        }

        private Func<object[], object> CreateMemberDelegate(string signature, InvokeMemberBinder binder, object[] args)
        {
            try
            {
                var command = MethodFactory.GetCommand(binder.Name);
                if (command == null) return null;
                return command.CreateDelegate(_database, this, binder, args);
            }
            catch (NotImplementedException)
            {
                return null;
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = new Column(this, binder.Name);
            return true;
        }
    }
}