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

namespace MicroOrm
{
    class SchemaProviderFactory
    {
        private static readonly Dictionary<string, Type> _schemaProviderTypes = new Dictionary<string, Type>(){
                                                                {"System.Data.SqlClient.SqlConnection", typeof(SqlSchemaProvider)}};

        private static Dictionary<string, ISchemaProvider> _schemaProviders = new Dictionary<string, ISchemaProvider>();

        public static ISchemaProvider GetSchemaProvider(Database database)
        {
            string connectionTypeName = database.GetConnection().GetType().FullName;
            string key = string.Format("{0} & {1}", connectionTypeName, database.GetConnection().ConnectionString).ToLower();

            if (!_schemaProviders.ContainsKey(key))
            {
                if (!_schemaProviderTypes.Keys.Contains(connectionTypeName))
                    throw new Exception(string.Format("Unable to find schema provider for '{0}'.", connectionTypeName));

                Type type = _schemaProviderTypes.First(s => s.Key == connectionTypeName).Value;
                _schemaProviders.Add(key, (ISchemaProvider)Activator.CreateInstance(type, database));
            }

            return _schemaProviders[key];
        }
    }
}
