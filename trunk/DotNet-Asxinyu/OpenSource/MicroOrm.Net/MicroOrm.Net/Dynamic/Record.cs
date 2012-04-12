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
using System.Reflection;

namespace MicroOrm
{
    public class Record : DynamicObject
    {
        private Database _database;
        private Dictionary<string, object> _dict;

        internal Record(Database database, Dictionary<string, object> dict) 
        {
            _database = database;
            _dict = dict;
        }

        public object ToScalar()
        {
            return _dict[_dict.Keys.First()];
        }

        public T ToScalar<T>()
        {
            return (T)_dict[_dict.Keys.First()];
        }

        public Dictionary<string, object> ToDictionary()
        {
            return _dict;
        }

        public T To<T>()
        {
            T entity = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in propertyInfos)
            {
                p.SetValue(entity, GetColumnValue(p.Name), null);
            }
            return entity;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (base.TryGetMember(binder, out result))
                return true;

            result = GetColumnValue(binder.Name);
            return true;
        }

        private object GetColumnValue(string columnName)
        {
            if (_dict != null && _dict.Keys.Any(k => k.Equals(columnName, StringComparison.OrdinalIgnoreCase)))
                return _dict[_dict.Keys.First(k => k.Equals(columnName, StringComparison.OrdinalIgnoreCase))];
            else
                return null;
        }
    }
}