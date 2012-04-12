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
using System.Collections;
using System.Reflection;

namespace MicroOrm
{
    class DeleteMethod : IMethod
    {
        public bool IsMethodFor(string methodName)
        {
            if (methodName.Equals("Delete", StringComparison.OrdinalIgnoreCase))
                return true;
            else
                return false;
        }

        public object Execute(Database database, Table table, System.Dynamic.InvokeMemberBinder binder, object[] arguments)
        {
            int i = 0;
            if (arguments.Length == 0)
                throw new Exception("Wrong number of arguments in 'Delete'.");

            int j = 0;
            foreach (var o in arguments)
            {
                if (o is Expression && j++ != 0)
                    throw new Exception("A expression can only appear in 'Delete' arguments.");
            }

            if (arguments[0] is Expression)
            {
                if (binder.CallInfo.ArgumentCount != 1)
                    throw new Exception("Wrong number of arguments in 'Delete'.");

                i = ExecuteImpl(database, table, (Expression)arguments[0]);
            }

            if (!(arguments[0] is Expression))
            {
                if (binder.CallInfo.ArgumentNames.Count != 0)
                {
                    if (binder.CallInfo.ArgumentCount != binder.CallInfo.ArgumentNames.Count)
                        throw new Exception("A named-arguments in 'Delete' arguments, all other arguments must be named-arguments.");

                    Dictionary<string, object> hash = new Dictionary<string, object>();
                    int n = 0;
                    foreach (var name in binder.CallInfo.ArgumentNames)
                        hash[name] = arguments[n++];

                    i = ExecuteImpl(database, table, hash);
                }
                else
                {
                    if (binder.CallInfo.ArgumentCount != 1 || (!(arguments[0] is IDictionary) && arguments[0] is ICollection))
                        throw new Exception("Argument does not support the collection type in 'Delete'.");

                    if (arguments[0] is IDictionary)
                        i = ExecuteImpl(database, table, (IDictionary)arguments[0]);
                    else
                        i = ExecuteImpl(database, table, arguments[0]);
                }
            }

            return i;
        }

        private int ExecuteImpl(Database database, Table table, IDictionary dict)
        {
            return ExecuteImpl(database, table, null, dict);
        }

        private int ExecuteImpl(Database database, Table table, object o)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            PropertyInfo[] ps = o.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var p in ps)
                dict[p.Name] = p.GetValue(o, null);

            return ExecuteImpl(database, table, null, dict);
        }

        private int ExecuteImpl(Database database, Table table, Expression criteria)
        {
            return ExecuteImpl(database, table, criteria, null);
        }

        private int ExecuteImpl(Database database, Table table, Expression criteria, IDictionary dict)
        {
            int i = 0;
            ICommandProvider commandBuilder = CommandProviderFactory.GetCommandBuilder(database, table);

            IDbCommand command = commandBuilder.GetDeleteCommand(criteria, dict);
            if (database.Transaction != null)
                command.Transaction = database.Transaction;

            database.GetConnection().OpenIfClosed();

            i = command.ExecuteNonQuery();

            if (database.Scope == null)
                database.GetConnection().CloseIfOpened();

            return i;
        }

        public Func<object[], object> CreateDelegate(Database database, Table table, System.Dynamic.InvokeMemberBinder binder, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}