namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class DataTableHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable AddIdentityColumn(DataTable dt)
        {
            if (!dt.Columns.Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x84a4)))
            {
                dt.Columns.Add(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x84bc));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x84d4)] = (i + 1).ToString();
                }
            }
            return dt;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable CreateTable(List<string> nameList)
        {
            if (nameList.Count <= 0)
            {
                return null;
            }
            DataTable table = new DataTable();
            foreach (string str in nameList)
            {
                table.Columns.Add(str, typeof(string));
            }
            return table;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable CreateTable(string nameString)
        {
            string[] strArray = nameString.Split(new char[] { ',', ';' });
            List<string> list = new List<string>();
            DataTable table = new DataTable();
            foreach (string str in strArray)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    string[] strArray2 = str.Split(new char[] { '|' });
                    if (strArray2.Length == 2)
                    {
                        table.Columns.Add(strArray2[0], mi5qIK3te(strArray2[1]));
                    }
                    else
                    {
                        table.Columns.Add(strArray2[0]);
                    }
                }
            }
            return table;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IList<T> DataTableToList<T>(DataTable table) where T: class
        {
            if (!IsHaveRows(table))
            {
                return new List<T>();
            }
            IList<T> list = new List<T>();
            T local = default(T);
            foreach (DataRow row in table.Rows)
            {
                local = Activator.CreateInstance<T>();
                foreach (DataColumn column in row.Table.Columns)
                {
                    object obj2 = row[column.ColumnName];
                    PropertyInfo property = local.GetType().GetProperty(column.ColumnName);
                    if (((property != null) && property.CanWrite) && ((obj2 != null) && !Convert.IsDBNull(obj2)))
                    {
                        property.SetValue(local, obj2, null);
                    }
                }
                list.Add(local);
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable FilterDataTable(DataTable dt, string condition)
        {
            if (condition.Trim() == "")
            {
                return dt;
            }
            DataTable table = new DataTable();
            table = dt.Clone();
            DataRow[] rowArray = dt.Select(condition);
            for (int i = 0; i < rowArray.Length; i++)
            {
                table.ImportRow(rowArray[i]);
            }
            return table;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataRow[] GetDataRowArray(DataRowCollection drc)
        {
            int count = drc.Count;
            DataRow[] rowArray = new DataRow[count];
            for (int i = 0; i < count; i++)
            {
                rowArray[i] = drc[i];
            }
            return rowArray;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable GetTableFromRows(DataRow[] rows)
        {
            if (rows.Length <= 0)
            {
                return new DataTable();
            }
            DataTable table = rows[0].Table.Clone();
            table.DefaultView.Sort = rows[0].Table.DefaultView.Sort;
            for (int i = 0; i < rows.Length; i++)
            {
                table.LoadDataRow(rows[i].ItemArray, true);
            }
            return table;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsHaveRows(DataTable dt)
        {
            return ((dt != null) && (dt.Rows.Count > 0));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable ListToDataTable<T>(IList<T> list) where T: class
        {
            if ((list == null) || (list.Count <= 0))
            {
                return null;
            }
            DataTable table = new DataTable(typeof(T).Name);
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int length = properties.Length;
            bool flag = true;
            foreach (T local in list)
            {
                if (local != null)
                {
                    DataRow row = table.NewRow();
                    for (int i = 0; i < length; i++)
                    {
                        PropertyInfo info = properties[i];
                        string name = info.Name;
                        if (flag)
                        {
                            DataColumn column = new DataColumn(name, info.PropertyType);
                            table.Columns.Add(column);
                        }
                        row[name] = info.GetValue(local, null);
                    }
                    if (flag)
                    {
                        flag = false;
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Type mi5qIK3te(string text1)
        {
            text1 = text1.ToLower().Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x84ec), "");
            Type type = typeof(string);
            switch (text1)
            {
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x84fe):
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8510):
                    return typeof(bool);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x851c):
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x852a):
                    return typeof(short);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8538):
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8546):
                    return typeof(int);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8550):
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x855c):
                    return typeof(long);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x856a):
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x857a):
                    return typeof(ushort);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x858a):
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x859a):
                    return typeof(uint);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x85a6):
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x85b6):
                    return typeof(ulong);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x85c4):
                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x85d4):
                    return typeof(float);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x85e2):
                    return typeof(string);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x85f2):
                    return typeof(Guid);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x85fe):
                    return typeof(decimal);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8610):
                    return typeof(double);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8620):
                    return typeof(DateTime);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8634):
                    return typeof(byte);

                case kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8640):
                    return typeof(char);
            }
            return type;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable SortedTable(DataTable dt, params string[] sorts)
        {
            if (dt.Rows.Count > 0)
            {
                string str = "";
                for (int i = 0; i < sorts.Length; i++)
                {
                    str = str + sorts[i] + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x864c);
                }
                dt.DefaultView.Sort = str.TrimEnd(new char[] { ',' });
            }
            return dt;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable ToDataTable<T>(IList<T> list)
        {
            return ToDataTable<T>(list, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DataTable ToDataTable<T>(IList<T> list, params string[] propertyName)
        {
            List<string> list2 = new List<string>();
            if (propertyName != null)
            {
                list2.AddRange(propertyName);
            }
            DataTable table = new DataTable();
            if (list.Count > 0)
            {
                T local = list[0];
                PropertyInfo[] properties = local.GetType().GetProperties();
                foreach (PropertyInfo info in properties)
                {
                    if (list2.Count == 0)
                    {
                        table.Columns.Add(info.Name, info.PropertyType);
                    }
                    else if (list2.Contains(info.Name))
                    {
                        table.Columns.Add(info.Name, info.PropertyType);
                    }
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList list3 = new ArrayList();
                    foreach (PropertyInfo info in properties)
                    {
                        object obj2;
                        if (list2.Count == 0)
                        {
                            obj2 = info.GetValue(list[i], null);
                            list3.Add(obj2);
                        }
                        else if (list2.Contains(info.Name))
                        {
                            obj2 = info.GetValue(list[i], null);
                            list3.Add(obj2);
                        }
                    }
                    object[] values = list3.ToArray();
                    table.LoadDataRow(values, true);
                }
            }
            return table;
        }
    }
}

