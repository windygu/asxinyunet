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
using System.Diagnostics;

namespace MicroOrm
{
    static class Extensions
    {
        public static T GetOrDefault<T>(this IList<T> list, int index)
        {
            return index < list.Count ? list[index] : default(T);
        }

        public static string RemoveExtraEmpty(this string s)
        {
            StringBuilder sb = new StringBuilder();
            string[] ss = s.Split(" ".ToArray());
            foreach (string t in ss)
            {
                if (string.IsNullOrEmpty(t))
                    continue;

                sb.Append(t + " ");
            }
            return sb.ToString();
        }

        public static void OpenIfClosed(this IDbConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public static void CloseIfOpened(this IDbConnection connection)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public static IEnumerable<Dictionary<string, object>> Expand(this IDataReader reader)
        {
            while (reader.Read())
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dict[reader.GetName(i).ToString()] = reader[i];
                }
                yield return dict;
            }
        }

        public static void WriteToOutput(string s)
        {
            try
            {
                Debug.WriteLine(s);
            }
            catch
            {
            }
        }
    }
}
