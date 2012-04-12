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
    public class Result : DynamicObject, IEnumerable
    {
        private readonly Database _database;
        private readonly IEnumerable<Dictionary<string, object>> _sources;

        internal Result(Database database, IEnumerable<Dictionary<string, object>> sources)
        {
            _database = database;
            _sources = sources;
        }

        public IEnumerator GetEnumerator()
        {
            return _sources.GetEnumerator();
        }

        public dynamic First()
        {
            IEnumerator<Dictionary<string, object>> e = _sources.GetEnumerator();
            e.MoveNext();
            return new Record(_database, e.Current == null ? new Dictionary<string, object>() : e.Current);
        }

        public T First<T>()
        {
            IEnumerator<Dictionary<string, object>> e = _sources.GetEnumerator();
            e.MoveNext();
            return new Record(_database, e.Current == null ? new Dictionary<string, object>() : e.Current).To<T>();
        }

        public dynamic Last()
        {
            IEnumerator<Dictionary<string, object>> e = _sources.GetEnumerator();
            Dictionary<string, object> dict = default(dynamic);
            while (e.MoveNext())
                dict = e.Current;
            return new Record(_database, dict == null ? new Dictionary<string, object>() : dict);
        }

        public T Last<T>()
        {
            IEnumerator<Dictionary<string, object>> e = _sources.GetEnumerator();
            Dictionary<string, object> dict = default(dynamic);
            while (e.MoveNext())
                dict = e.Current;
            return (new Record(_database, dict == null ? new Dictionary<string, object>() : dict)).To<T>();
        }

        public IEnumerable<object> ToScalarList()
        {
            IEnumerator<Dictionary<string, object>> e = _sources.GetEnumerator();
            while (e.MoveNext())
                yield return (new Record(_database, e.Current == null ? new Dictionary<string, object>() : e.Current)).ToScalar();
        }

        public IEnumerable<T> ToScalarList<T>()
        {
            IEnumerator<Dictionary<string, object>> e = _sources.GetEnumerator();
            while (e.MoveNext())
                yield return (new Record(_database, e.Current == null ? new Dictionary<string, object>() : e.Current)).ToScalar<T>();
        }

        public IEnumerable<dynamic> ToList()
        {
            IEnumerator<Dictionary<string, object>> e = _sources.GetEnumerator();
            while (e.MoveNext())
                yield return new Record(_database, e.Current == null ? new Dictionary<string, object>() : e.Current);
        }

        public IEnumerable<T> ToList<T>()
        {
            IEnumerator<Dictionary<string, object>> e = _sources.GetEnumerator();
            while (e.MoveNext())
                yield return (new Record(_database, e.Current == null ? new Dictionary<string, object>() : e.Current)).To<T>();
        }
    }
}