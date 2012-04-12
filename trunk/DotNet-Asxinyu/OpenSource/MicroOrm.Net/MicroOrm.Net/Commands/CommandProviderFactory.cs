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
using System.Collections.Concurrent;
using System.Data.Common;

namespace MicroOrm
{
    class CommandProviderFactory
    {
        private static readonly Dictionary<string, Type> _commandProviderTypes = new Dictionary<string, Type>(){
                                                                {"System.Data.SqlClient.SqlConnection", typeof(SqlCommandProvider)}};

        public static ICommandProvider GetCommandBuilder(Database database, Table table)
        {
            string connectionTypeName = database.GetConnection().GetType().FullName;
            if (!_commandProviderTypes.Keys.Contains(connectionTypeName))
                throw new Exception(string.Format("Unable to find command provider for '{0}'.", connectionTypeName));

            Type type = _commandProviderTypes.First(s => s.Key == connectionTypeName).Value;
            return (ICommandProvider)Activator.CreateInstance(type, database, table);
        }
    }
}