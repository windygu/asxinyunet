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
using System.Data.Common;

namespace MicroOrm
{
    //db.Order.Update(db.Order.OrderId == "001" && db.Order.CustomerId == "001", UserId: "001", UserName: "mapserver");
    //db.Order.Update(db.Order.OrderId == "001" && db.Order.CustomerId == "001", key-value);
    //db.Order.Update(db.Order.OrderId == "001" && db.Order.CustomerId == "001", new { UserId = "001", UserName = "mapserver" });
    //db.Order.Update(db.Order.OrderId == "001" && db.Order.CustomerId == "001", entity);
    //db.Order.Update(UserId: "001", UserName: "mapserver");
    //db.Order.Update(key-value);
    //db.Order.Update(new { UserId = "001", UserName = "mapserver" });
    //db.Order.Update(entity);

    class UpdateMethod : IMethod
    {
        public bool IsMethodFor(string methodName)
        {
            if (methodName.Equals("Update", StringComparison.OrdinalIgnoreCase))
                return true;
            else
                return false;
        }

        public object Execute(Database database, Table table, System.Dynamic.InvokeMemberBinder binder, object[] arguments)
        {
            int i = 0;
            if (arguments.Length == 0)
                throw new Exception("Wrong number of arguments in 'Update'.");

            int j = 0;
            foreach (var o in arguments)
            {
                if (o is Expression && j++ != 0)
                    throw new Exception("");
            }

            if (arguments[0] is Expression)
            {
                if (binder.CallInfo.ArgumentNames.Count != 0)
                {
                    if (binder.CallInfo.ArgumentNames.Count != binder.CallInfo.ArgumentCount - 1)
                        throw new Exception("Wrong number of arguments in 'Update'.");

                    Dictionary<string, object> hash = new Dictionary<string, object>();
                    int n = 1;
                    foreach (var name in binder.CallInfo.ArgumentNames)
                        hash[name] = arguments[n++];

                    i = ExecuteImpl(database, table, (Expression)arguments[0], hash);
                }
                else
                {
                    if (binder.CallInfo.ArgumentCount != 2 || (!(arguments[1] is IDictionary) && arguments[1] is ICollection))
                        throw new Exception("Argument does not support the collection type in 'Update'.");

                    if (arguments[1] is IDictionary)
                        i = ExecuteImpl(database, table, (Expression)arguments[0], (IDictionary)arguments[1]);
                    else
                        i = ExecuteImpl(database, table, (Expression)arguments[0], arguments[1]);
                }
            }

            if (!(arguments[0] is Expression))
            {
                if (binder.CallInfo.ArgumentNames.Count != 0)
                {
                    if (binder.CallInfo.ArgumentCount != binder.CallInfo.ArgumentNames.Count)
                        throw new Exception("Wrong number of arguments in 'Update'.");

                    Dictionary<string, object> hash = new Dictionary<string, object>();
                    int n = 0;
                    foreach (var name in binder.CallInfo.ArgumentNames)
                        hash[name] = arguments[n++];

                    i = ExecuteImpl(database, table, hash);
                }
                else
                {
                    if (binder.CallInfo.ArgumentCount != 1 || (!(arguments[0] is IDictionary) && arguments[0] is ICollection))
                        throw new Exception("Argument does not support the collection type in 'Update'.");

                    if (arguments[0] is IDictionary)
                        i = ExecuteImpl(database, table, (IDictionary)arguments[0]);
                    else
                        i = ExecuteImpl(database, table, arguments[0]);
                }
            }

            return i;
        }

        private int ExecuteImpl(Database database, Table table, object o)
        {
            return ExecuteImpl(database, table, null, o);
        }

        private int ExecuteImpl(Database database, Table table, IDictionary dict)
        {
            return ExecuteImpl(database, table, null, dict);
        }

        private int ExecuteImpl(Database database, Table table, Expression criteria, object o)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            PropertyInfo[] ps = o.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var p in ps)
                dict[p.Name] = p.GetValue(o, null);

            return ExecuteImpl(database, table, criteria, dict);
        }

        private int ExecuteImpl(Database database, Table table, Expression criteria, IDictionary dict)
        {
            int i = 0;
            ICommandProvider commandBuilder = CommandProviderFactory.GetCommandBuilder(database, table);

            IDbCommand command = commandBuilder.GetUpdateCommand(criteria, dict);
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
