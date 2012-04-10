namespace WHC.Pager.WinControl
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    public sealed class ReflectionUtil
    {
        public static BindingFlags bf = (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        private ReflectionUtil()
        {
        }

        public static DataTable CreateTable(object objSource)
        {
            DataTable table = null;
            IEnumerable enumerable = objSource as IEnumerable;
            foreach (object obj2 in enumerable)
            {
                if (table == null)
                {
                    List<string> propertyNames = GetPropertyNames(obj2);
                    table = new DataTable("");
                    foreach (string str in propertyNames)
                    {
                        DataColumn column = new DataColumn {
                            DataType = Type.GetType("System.String"),
                            ColumnName = str,
                            Caption = str
                        };
                        table.Columns.Add(column);
                    }
                }
                DataRow row = table.NewRow();
                foreach (PropertyInfo info in obj2.GetType().GetProperties(bf))
                {
                    row[info.Name] = info.GetValue(obj2, null);
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public static object GetField(object obj, string name)
        {
            return obj.GetType().GetField(name, bf).GetValue(obj);
        }

        public static object GetProperty(object obj, string name)
        {
            return obj.GetType().GetProperty(name, bf).GetValue(obj, null);
        }

        public static List<string> GetPropertyNames(object obj)
        {
            List<string> list = new List<string>();
            foreach (PropertyInfo info in obj.GetType().GetProperties(bf))
            {
                list.Add(info.Name);
            }
            return list;
        }

        public static Dictionary<string, string> GetPropertyNameTypes(object obj)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (PropertyInfo info in obj.GetType().GetProperties(bf))
            {
                dictionary.Add(info.Name, info.PropertyType.FullName);
            }
            return dictionary;
        }

        public static object InvokeMethod(object obj, string methodName, object[] args)
        {
            return obj.GetType().InvokeMember(methodName, bf | BindingFlags.InvokeMethod, null, obj, args);
        }

        public static void SetField(object obj, string name, object value)
        {
            obj.GetType().GetField(name, bf).SetValue(obj, value);
        }

        public static void SetProperty(object obj, string name, object value)
        {
            PropertyInfo property = obj.GetType().GetProperty(name, bf);
            object obj2 = Convert.ChangeType(value, property.PropertyType);
            property.SetValue(obj, obj2, null);
        }
    }
}

