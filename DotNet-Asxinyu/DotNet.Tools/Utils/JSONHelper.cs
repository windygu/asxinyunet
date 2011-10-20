namespace Utils
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Data.Common;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization.Json;
    using System.Text;

    /// <summary><para>　</para>
    /// 类名：常用工具类——JSON工具类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：20010-01-04</para><para>------------------------------------------------</para><para>　ToJSON：对象转换为Json字符串</para><para>　ToJSON[IEnumerable]：对象集合转换Json</para><para>　ToJSON[DataTable]：Datatable转换为Json</para><para>　ToJSON[DbDataReader]：DataReader转换为Json</para><para>　ToJSON[DataSet]：DataSet转换为Json</para><para>　Obj2Json：对象与JSON字符串之间的转换，适用于Net3.5以上</para></summary>
    public class JSONHelper
    {
        /// <summary>将对象序列化为JSON字符串，适用于Net3.5以上</summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static string Obj2Json(object Obj)
        {
            string message = "";
            try
            {
                DataTable table;
                Type type = Obj.GetType();
                while (1 != 0)
                {
                    DataContractJsonSerializer serializer;
                    if (type == typeof(DataTable)) break;
                Label_0021:
                    serializer = new DataContractJsonSerializer(type);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        serializer.WriteObject(stream, Obj);
                        return Encoding.UTF8.GetString(stream.ToArray());
                    }
                    do
                    {
                        if (0 != 0) goto Label_0021;
                    }
                    while (3 == 0);
                    return message;
                Label_0066:
                    if (string.IsNullOrEmpty(table.TableName)) goto Label_008B;
                Label_0073:
                    Obj = table;
                    goto Label_0021;
                }
                table = (DataTable) Obj;
                goto Label_0066;
            Label_008B:
                table.TableName = "TableName1";
                if (0 == 0) goto Label_0073;
                goto Label_0021;
            }
            catch (Exception exception)
            {
                message = exception.Message;
            }
            return message;
        }

        /// <summary>将JSON字符串反序列化为对象，适用于Net3.5以上</summary>
        /// <param name="JSONStr"></param>
        /// <param name="ObjType"></param>
        /// <returns></returns>
        public static object Obj2Json(string JSONStr, Type ObjType)
        {
            object obj2 = "";
            try
            {
                if (string.IsNullOrEmpty(JSONStr)) return obj2;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(ObjType);
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(JSONStr)))
                {
                    obj2 = serializer.ReadObject(stream);
                }
            }
            catch (Exception)
            {
                obj2 = null;
            }
            return obj2;
        }

        /// <summary>DataReader转换为Json</summary>
        /// <param name="dataReader">DataReader对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJSON(DbDataReader dataReader)
        {
            int num;
            object obj2;
            object[] objArray;
            string str = "[";
        Label_0016:
            if (dataReader.Read())
            {
                str = str + "{";
                num = 0;
            }
            else
            {
                if (((uint) num) - ((uint) num) <= uint.MaxValue)
                {
                    if ((((uint) num) & 0) == 0)
                    {
                        if (((uint) num) - ((uint) num) <= uint.MaxValue) dataReader.Close();
                        return (x60c9114747e01751(str) + "]");
                    }
                    goto Label_00F0;
                }
                goto Label_00A7;
            }
        Label_0041:
            if (num < dataReader.FieldCount)
            {
                str = str + "\"" + dataReader.GetName(num) + "\":";
                if (dataReader.GetFieldType(num) == typeof(DateTime)) goto Label_012C;
                if (0 != 0) goto Label_007C;
                goto Label_00F0;
            }
            str = x60c9114747e01751(str) + "}";
            goto Label_0016;
        Label_0069:
            str = str + dataReader[num] + ",";
        Label_007C:
            do
            {
                num++;
            }
            while (3 == 0);
            goto Label_0041;
        Label_0084:
            if (dataReader.GetFieldType(num) == typeof(string)) goto Label_012C;
            goto Label_0069;
        Label_00A7:
            objArray[3] = "\",";
            str = string.Concat(objArray);
            goto Label_00A3;
        Label_00F0:
            if (((uint) num) + ((uint) num) >= 0) goto Label_0084;
            if (((uint) num) - ((uint) num) > uint.MaxValue) goto Label_00A7;
            if (0 != 0)
            {
                if (-1 == 0) goto Label_0084;
                goto Label_0069;
            }
        Label_012C:
            obj2 = str;
            objArray = new object[4];
            objArray[0] = obj2;
            objArray[1] = "\"";
            objArray[2] = dataReader[num];
            goto Label_00A7;
        }

        /// <summary>DataSet转换为Json</summary>
        /// <param name="dataSet">DataSet对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJSON(DataSet dataSet)
        {
            string str = "{";
            IEnumerator enumerator = dataSet.Tables.GetEnumerator();
            try
            {
                DataTable table;
                string str2;
                string[] strArray;
                goto Label_0042;
            Label_0014:
                if (0 != 0) goto Label_003A;
                if (2 != 0) goto Label_00AA;
                goto Label_004C;
            Label_0020:
                if (3 != 0)
                {
                }
                strArray[4] = ToJSON(table);
                strArray[5] = ",";
            Label_003A:
                str = string.Concat(strArray);
            Label_0042:
                if (enumerator.MoveNext()) goto Label_0080;
                goto Label_0014;
            Label_004C:
                strArray[2] = table.TableName;
                strArray[3] = "\":";
                if (0 == 0) goto Label_0020;
                goto Label_0014;
            Label_0066:
                strArray = new string[6];
                strArray[0] = str2;
                strArray[1] = "\"";
                goto Label_004C;
            Label_0080:
                table = (DataTable) enumerator.Current;
                str2 = str;
                goto Label_0066;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                while (disposable != null)
                {
                    disposable.Dispose();
                    break;
                }
            }
        Label_00AA:
            return (str = x60c9114747e01751(str) + "}");
        }

        /// <summary>Datatable转换为Json</summary>
        /// <param name="table">Datatable对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJSON(DataTable table)
        {
            DataRowCollection rows;
            string str = "[";
            do
            {
                rows = table.Rows;
            }
            while (0 != 0);
            int num = 0;
            goto Label_001D;
        Label_0008:
            str = x60c9114747e01751(str) + "},";
            num++;
        Label_001D:
            if (num < rows.Count)
            {
                str = str + "{";
                IEnumerator enumerator = table.Columns.GetEnumerator();
                try
                {
                    DataColumn column;
                    object obj2;
                    object[] objArray;
                    goto Label_0087;
                Label_0054:
                    if (column.DataType == typeof(string)) goto Label_00F2;
                    str = str + rows[num][column.ColumnName] + ",";
                Label_0087:
                    if (enumerator.MoveNext()) goto Label_012B;
                    goto Label_0008;
                Label_0098:
                    if (column.DataType == typeof(DateTime)) goto Label_00F2;
                    goto Label_0054;
                Label_00AC:
                    objArray[0] = obj2;
                    objArray[1] = "\"";
                    objArray[2] = rows[num][column.ColumnName];
                    objArray[3] = "\",";
                    str = string.Concat(objArray);
                    goto Label_0087;
                Label_00E6:
                    objArray = new object[4];
                    goto Label_00AC;
                Label_00F2:
                    obj2 = str;
                    if (8 != 0) goto Label_0118;
                Label_00FC:
                    str = str + "\"" + column.ColumnName + "\":";
                    goto Label_0098;
                Label_0118:
                    if (0xff != 0) goto Label_00E6;
                    goto Label_00AC;
                Label_012B:
                    column = (DataColumn) enumerator.Current;
                    if ((((uint) num) & 0) == 0) goto Label_00FC;
                    goto Label_0008;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    while (disposable != null)
                    {
                        disposable.Dispose();
                        break;
                    }
                }
                if (((uint) num) - ((uint) num) >= 0) goto Label_0008;
            }
            return (x60c9114747e01751(str) + "]");
        }

        /// <summary>对象转换为Json字符串</summary>
        /// <param name="jsonObject">对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJSON(object jsonObject)
        {
            object obj2;
            string str2;
            string str3;
            string[] strArray;
            string str = "{";
            PropertyInfo[] properties = jsonObject.GetType().GetProperties();
            int index = 0;
        Label_000F:
            if (index < properties.Length)
            {
                obj2 = properties[index].GetGetMethod().Invoke(jsonObject, null);
                str2 = string.Empty;
                if (-1 != 0) goto Label_013C;
                goto Label_00E4;
            }
            if (2 != 0) return (x60c9114747e01751(str) + "}");
            goto Label_00F1;
        Label_0073:
            if (obj2 is IEnumerable) goto Label_00AE;
            str2 = obj2.ToString();
        Label_0083:
            str3 = str;
            if (8 != 0)
            {
                if (0xff != 0) goto Label_014E;
                goto Label_00E4;
            }
        Label_0099:
            if (((uint) index) < 0)
            {
                if (((uint) index) - ((uint) index) > uint.MaxValue)
                {
                }
                goto Label_00F8;
            }
        Label_00AE:
            str2 = ToJSON((IEnumerable) obj2);
            goto Label_0083;
        Label_00E4:
            if (!(obj2 is string) && !(obj2 is Guid))
            {
                if (obj2 is TimeSpan) goto Label_00F1;
                if (((uint) index) + ((uint) index) >= 0) goto Label_0073;
                if (-1 != 0) goto Label_0099;
                if (2 != 0) goto Label_0073;
                goto Label_014E;
            }
            goto Label_00F8;
        Label_00F1:
            if (8 == 0) goto Label_013C;
        Label_00F8:
            str2 = "'" + obj2 + "'";
            goto Label_0083;
        Label_013C:
            if (obj2 is DateTime) goto Label_00F8;
            if (0 == 0) goto Label_00E4;
        Label_014E:
            if (2 != 0)
            {
                strArray = new string[6];
                strArray[0] = str3;
                strArray[1] = "\"";
            }
            strArray[2] = properties[index].Name;
            strArray[3] = "\":";
            strArray[4] = str2;
            strArray[5] = ",";
            str = string.Concat(strArray);
            index++;
            goto Label_000F;
        }

        /// <summary>对象集合或普通集合转换Json</summary>
        /// <param name="array">集合对象</param>
        /// <param name="IsObject">是否为对象集合，</param>
        /// <returns>Json字符串</returns>
        public static string ToJSON(IEnumerable array, bool IsObject)
        {
            string str = "[";
            IEnumerator enumerator = array.GetEnumerator();
            try
            {
                object obj2;
            Label_000F:
                if (enumerator.MoveNext()) goto Label_0045;
                if (((uint) IsObject) + ((uint) IsObject) <= uint.MaxValue) goto Label_00E2;
                goto Label_007A;
            Label_0034:
                if (IsObject) goto Label_0064;
                str = obj2 + ",";
                goto Label_000F;
            Label_0045:
                obj2 = enumerator.Current;
            Label_004C:
                if (((uint) IsObject) - ((uint) IsObject) >= 0) goto Label_0034;
            Label_0064:
                str = str + ToJSON(obj2) + ",";
                goto Label_000F;
            Label_007A:
                if ((((uint) IsObject) | 3) == 0) goto Label_004C;
                if (15 != 0) goto Label_0045;
                goto Label_000F;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                goto Label_00DF;
            Label_00A9:
                disposable.Dispose();
                if (0 == 0)
                {
                }
                while ((((uint) IsObject) & 0) != 0 || ((uint) IsObject) > uint.MaxValue)
                {
                    if (disposable != null) goto Label_00A9;
                    break;
                }
            }
        Label_00E2:
            return (x60c9114747e01751(str) + "]");
        }

        private static string x60c9114747e01751(string xf6987a1745781d6f)
        {
            if (xf6987a1745781d6f.Length > 1) return xf6987a1745781d6f.Substring(0, xf6987a1745781d6f.Length - 1);
            return xf6987a1745781d6f;
        }
    }
}
