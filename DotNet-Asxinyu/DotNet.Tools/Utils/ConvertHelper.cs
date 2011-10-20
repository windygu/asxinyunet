namespace Utils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Xml;

    /// <summary><para>　</para>
    /// 类名：常用工具类——转换操作类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------------</para><para>　UniteTable：合并两个相同结构的 DataTable到一个新表中</para><para>　UnitesTable：合并两个相同结构的表到第一个表中</para><para>　GetStrArray：将字符串数组转为泛型LIST</para><para>　GetArrayStr：将泛型ILIST转换为分隔字符串</para><para>　GetStrArray：将分隔字符串","转换为字符串数组</para><para>　HashTableToObjArgs：将希哈表的Value转换为数组</para><para>　===============XML和DataSet、DataTable之间的互相转换===============</para><para>　DataTableoXml：将Table转换成XML字符串</para><para>　DataTableToXmlFile：将DataTable对象或DataSet对象中指定的表保存为XML文件[+2 重载]</para><para>　DataSetToXml：将DataSet中第一个表格或指定索引的表格转为XML字符串[共三种方法]</para><para>　XmlToDataSet：将Xml字符串转换成DataSet对象</para><para>　XmlFileToDataSet：读取Xml文件信息,并转换成DataSet对象</para><para>　XmlDocumentToDataSet：将XmlDocument转为DataSet</para><para>　================二进制相关转换类==============</para><para>　FileToBinary：将文件转换为二进制数组</para><para>　BinaryToFile：二进制数组转为文件</para></summary>
    public class ConvertHelper
    {
        /// <summary>二进制数组转为文件</summary>
        /// <param name="FilePath">转到的文件完整路径</param>
        /// <param name="Buffer">二进制数组</param>
        /// <returns>转换是否成功</returns>
        public static bool BinaryToFile(string FilePath, byte[] Buffer)
        {
            bool flag = false;
            FileStream stream = File.Create(FilePath, Buffer.Length);
            try
            {
                stream.Write(Buffer, 0, Buffer.Length);
                flag = true;
            }
            catch (Exception)
            {
            }
            finally
            {
                stream.Close();
            }
            return flag;
        }

        /// <summary>将DataSet中第一个表格转为XML字符串</summary>
        /// <param name="Ds">DataSet对象</param>
        /// <returns></returns>
        public static string DataSetToXml(DataSet Ds) { return DataSetToXml(Ds, 0); }

        /// <summary>将DataSet中指定索引的表格转为XML字符串</summary>
        /// <param name="Ds"></param>
        /// <param name="TableIndex"></param>
        /// <returns></returns>
        public static string DataSetToXml(DataSet Ds, int TableIndex)
        {
            if (Ds != null && (TableIndex >= 0 || 0 != 0) && Ds.Tables[TableIndex] != null) return DataTableToXml(Ds.Tables[TableIndex]);
            return "";
        }

        /// <summary>将DataTable对象转换成XML字符串</summary>
        /// <param name="Dt">DataTable对象</param>
        /// <returns>XML字符串</returns>
        public static string DataTableToXml(DataTable Dt)
        {
            if (Dt != null)
            {
                Dt.TableName = "Table1";
                MemoryStream w = null;
                XmlTextWriter writer = null;
                try
                {
                    int length;
                    byte[] buffer;
                    UnicodeEncoding encoding;
                    string str2;
                    w = new MemoryStream();
                    goto Label_005F;
                Label_001D:
                    str2 = encoding.GetString(buffer).Trim();
                    if (((uint) length) + ((uint) length) <= uint.MaxValue) return str2;
                    goto Label_005F;
                Label_004A:
                    encoding = new UnicodeEncoding();
                    goto Label_001D;
                Label_0053:
                    w.Read(buffer, 0, length);
                    goto Label_00A6;
                Label_005F:
                    writer = new XmlTextWriter(w, Encoding.Unicode);
                    Dt.WriteXml(writer);
                    if (((uint) length) + ((uint) length) > uint.MaxValue) goto Label_0053;
                    length = (int) w.Length;
                    buffer = new byte[length];
                    w.Seek(0, SeekOrigin.Begin);
                    if (0 == 0) goto Label_0053;
                Label_00A6:
                    if (-2147483648 != 0) goto Label_004A;
                    goto Label_001D;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                        w.Close();
                        w.Dispose();
                    }
                }
            }
            return "";
        }

        /// <summary>将DataTable对象转换成XML字符串的另一种方法</summary>
        /// <param name="Dt">DataTable对象</param>
        /// <returns></returns>
        public static string DataTableToXml2(DataTable Dt)
        {
            XmlElement element;
            XmlElement element2;
            int num2;
            string xml = "<DataTable />";
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            System.Xml.XmlNode node = document.SelectSingleNode("//DataTable");
            int num = 0;
            goto Label_0018;
        Label_000B:
            node.AppendChild(element);
            num++;
        Label_0018:
            if (num < Dt.Rows.Count)
            {
                element = document.CreateElement("Rows");
                element2 = null;
                goto Label_013E;
            }
            return document.InnerXml.ToString();
            if (((uint) num) + ((uint) num2) < 0) goto Label_013E;
        Label_0049:
            element.AppendChild(element2);
        Label_0053:
            num2++;
        Label_0059:
            if (num2 >= Dt.Columns.Count) goto Label_000B;
            if (Dt.Columns[num2].ColumnName.StartsWith("@"))
            {
                string name = Dt.Columns[num2].ColumnName.Replace("@", "");
                element.SetAttribute(name, Dt.Rows[num][num2].ToString());
                goto Label_0053;
            }
            element2 = document.CreateElement(Dt.Columns[num2].ColumnName);
            try
            {
                element2.InnerXml = Dt.Rows[num][num2].ToString();
            }
            catch
            {
                element2.InnerText = Dt.Rows[num][num2].ToString();
            }
            goto Label_0049;
        Label_013E:
            if (object.Equals(Dt, null) || ((uint) num2) + ((uint) num) > uint.MaxValue) goto Label_000B;
            num2 = 0;
            goto Label_0059;
        }

        /// <summary>将DataTable对象转换成XML字符串的另三种方法[若表格中有HTML特殊标记用此方法]</summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToXml3(DataTable dt)
        {
            int num;
            int num2;
            StringBuilder builder = new StringBuilder();
            goto Label_00DA;
        Label_000B:
            if (num2 < dt.Columns.Count) goto Label_0052;
            builder.AppendLine("</Rows>");
            num++;
        Label_0029:
            if (num < dt.Rows.Count)
            {
                builder.AppendLine("<Rows>");
                num2 = 0;
                goto Label_000B;
            }
            if (0x7fffffff == 0) goto Label_0052;
        Label_0041:
            builder.AppendLine("</Root>");
            if (0 == 0) return builder.ToString();
            goto Label_00DA;
        Label_0052:;
            builder.AppendLine("<" + dt.Columns[num2].ColumnName + "><![CDATA[" + dt.Rows[num][num2].ToString() + "]]></" + dt.Columns[num2].ColumnName + ">");
            num2++;
            if (0 != 0) goto Label_0041;
            goto Label_000B;
        Label_00DA:
            builder.AppendLine("<Root>");
            num = 0;
            goto Label_0029;
        }

        /// <summary>将DataTable对象数据保存为XML文件</summary>
        /// <param name="Dt">DataSet</param>
        /// <param name="XmlFilePath">XML文件路径</param>
        /// <returns>bool值</returns>
        public static bool DataTableToXmlFile(DataTable Dt, string XmlFilePath)
        {
            string str;
            int length;
            bool flag;
            if (Dt == null) goto Label_000D;
            if ((((uint) flag) & 0) != 0) goto Label_0023;
        Label_0005:
            if (!string.IsNullOrEmpty(XmlFilePath)) goto Label_0023;
        Label_000D:
            return false;
        Label_0023:
            str = HttpContext.Current.Server.MapPath(XmlFilePath);
            MemoryStream w = null;
            XmlTextWriter writer = null;
            try
            {
                byte[] buffer;
                UnicodeEncoding encoding;
                StreamWriter writer2;
                w = new MemoryStream();
                goto Label_00E4;
            Label_0043:
                writer2 = new StreamWriter(str);
                writer2.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            Label_0057:
                writer2.WriteLine(encoding.GetString(buffer).Trim());
                do
                {
                    writer2.Close();
                    flag = true;
                }
                while (((uint) length) - ((uint) length) > uint.MaxValue);
                if (((uint) flag) - ((uint) length) <= uint.MaxValue) goto Label_00D0;
            Label_00A6:
                buffer = new byte[length];
                w.Seek(0, SeekOrigin.Begin);
                w.Read(buffer, 0, length);
                encoding = new UnicodeEncoding();
                if (0 == 0) goto Label_0043;
            Label_00D0:
                if ((((uint) length) & 0) == 0) return flag;
            Label_00E4:
                writer = new XmlTextWriter(w, Encoding.Unicode);
                Dt.WriteXml(writer);
                length = (int) w.Length;
                if (((uint) length) - ((uint) flag) < 0) goto Label_0057;
                if (((uint) flag) + ((uint) flag) <= uint.MaxValue) goto Label_00A6;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    w.Close();
                    w.Dispose();
                }
            }
            if (((uint) length) > uint.MaxValue) goto Label_0005;
            goto Label_000D;
        }

        /// <summary>将DataSet对象中指定的Table转换成XML文件</summary>
        /// <param name="Ds">DataSet对象</param>
        /// <param name="TableIndex">DataSet对象中的Table索引</param>
        /// <param name="XmlFilePath">xml文件路径</param>
        /// <returns>bool值</returns>
        public static bool DataTableToXmlFile(DataSet Ds, int TableIndex, string XmlFilePath)
        {
            if (TableIndex != -1) return DataTableToXmlFile(Ds.Tables[TableIndex], XmlFilePath);
            return DataTableToXmlFile(Ds.Tables[0], XmlFilePath);
        }

        /// <summary>将文件转换为二进制数组</summary>
        /// <param name="FilePath">文件完整路径</param>
        /// <returns>二进制数组</returns>
        public static byte[] FileToBinary(string FilePath)
        {
            byte[] buffer = null;
            FileStream stream;
            if (-1 != 0)
            {
                if (!FilesHelper.FileExists(FilePath)) return buffer;
                if (!Path.HasExtension(FilePath)) return buffer;
                stream = new FileInfo(FilePath).OpenRead();
            }
            do
            {
                buffer = new byte[stream.Length];
            }
            while (0 != 0);
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            return buffer;
        }

        /// <summary>将泛型ILIST转换为分隔字符串</summary>
        /// <param name="list">泛型ILIST</param>
        /// <param name="speater">分隔字符</param>
        /// <returns>字符串</returns>
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder builder = new StringBuilder();
            int num = 0;
            goto Label_000F;
        Label_000B:
            num++;
        Label_000F:
            if (num < list.Count)
            {
                if (num == list.Count - 1)
                {
                    builder.Append(list[num]);
                    if (((uint) num) + ((uint) num) > uint.MaxValue) goto Label_000F;
                    goto Label_000B;
                }
            }
            else
                goto Label_008B;
        Label_0044:
            builder.Append(list[num]);
            builder.Append(speater);
            if (((uint) num) + ((uint) num) >= 0)
            {
                if (0 != 0) goto Label_0044;
                goto Label_000B;
            }
        Label_008B:
            return builder.ToString();
        }

        /// <summary>将分隔字符串","转换为字符串数组</summary>
        /// <param name="str">字符串</param>
        /// <returns>字符串数组</returns>
        public static string[] GetStrArray(string str) { return str.Split(new char[0x2c]); }

        /// <summary>将字符串分隔转为泛型LIST</summary>
        /// <param name="str">字符串</param>
        /// <param name="speater">分隔符</param>
        /// <param name="toLower">是否转换为小写</param>
        /// <returns>ILIST</returns>
        public static List<string> GetStrArray(string str, char speater, bool toLower)
        {
            string str2;
            string str3;
            string[] strArray2;
            int num;
            List<string> list = new List<string>();
            goto Label_00B6;
        Label_000B:
            if (num < strArray2.Length)
            {
                str2 = strArray2[num];
                if ((((uint) num) & 0) == 0)
                {
                    if (!string.IsNullOrEmpty(str2)) goto Label_004D;
                    if (-2147483648 == 0) goto Label_00CC;
                    if (((uint) num) > uint.MaxValue) goto Label_004D;
                    goto Label_003C;
                }
                if (0 != 0) goto Label_0080;
                if (((uint) num) + ((uint) num) >= 0) goto Label_004D;
                goto Label_0089;
            }
            if (0 == 0)
            {
                if (((uint) num) - ((uint) num) >= 0) return list;
                goto Label_00B6;
            }
            goto Label_004D;
        Label_003C:
            num++;
            goto Label_000B;
        Label_004D:
            if (str2 != speater.ToString()) goto Label_0089;
            goto Label_003C;
        Label_0080:
            list.Add(str3);
            goto Label_003C;
        Label_0089:
            str3 = str2;
            if (toLower) str3 = str2.ToLower();
            goto Label_0080;
        Label_00B6:;
            string[] strArray = str.Split(new char[] { speater });
        Label_00CC:
            strArray2 = strArray;
            num = 0;
            goto Label_000B;
        }

        /// <summary>将希哈表的Value转换为数组</summary>
        /// <param name="HT">希哈表</param>
        /// <returns>Object数组</returns>
        public static object[] HashTableToObjArgs(Hashtable HT)
        {
            object[] objArray = null;
            do
            {
                if (0 == 0)
                {
                    if (HT != null) break;
                    return objArray;
                }
            }
            while (8 == 0);
            if (HT.Count > 0 && 0 == 0)
            {
                ArrayList list = new ArrayList();
                IDictionaryEnumerator enumerator = HT.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        DictionaryEntry current = (DictionaryEntry) enumerator.Current;
                        list.Add(current.Value.ToString());
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (0xff == 0) goto Label_0056;
                Label_0050:
                    if (disposable != null) goto Label_0060;
                    goto Label_006E;
                Label_0056:
                    if (0 == 0 && 0 == 0) goto Label_006E;
                    goto Label_0050;
                Label_0060:
                    disposable.Dispose();
                    if (1 != 0) goto Label_0056;
                Label_006E:;
                }
                return list.ToArray();
            }
            return objArray;
        }

        /// <summary>合并两个相同结构的表到第一个表中</summary>
        /// <param name="DataTable1">第一个表</param>
        /// <param name="DataTable2">第二个表</param>
        /// <returns>第一个表</returns>
        public static DataTable UnitesTable(DataTable DataTable1, DataTable DataTable2)
        {
            object[] objArray;
            int num;
            if (DataTable1 != null) goto Label_0050;
            if (0xff != 0)
            {
                DataTable1 = DataTable2.Clone();
                if (0 != 0) return DataTable1;
                goto Label_0050;
            }
        Label_0035:
            while (num < DataTable2.Rows.Count)
            {
                DataTable2.Rows[num].ItemArray.CopyTo(objArray, 0);
                DataTable1.Rows.Add(objArray);
                num++;
            }
            return DataTable1;
        Label_0050:
            objArray = new object[DataTable1.Columns.Count];
            num = 0;
            goto Label_0035;
        }

        /// <summary>合并两个相同结构的 DataTable到一个新表中</summary>
        /// <param name="DataTable1">DataTable1</param>
        /// <param name="DataTable2">DataTable2</param>
        /// <returns></returns>
        public static DataTable UniteTable(DataTable DataTable1, DataTable DataTable2)
        {
            object[] objArray;
            int num;
            int num2;
            DataTable table = DataTable1.Clone();
            if (((uint) num2) + ((uint) num2) <= uint.MaxValue)
            {
                objArray = new object[table.Columns.Count];
                num = 0;
                goto Label_005C;
            }
        Label_001F:
            DataTable2.Rows[num2].ItemArray.CopyTo(objArray, 0);
            table.Rows.Add(objArray);
            num2++;
        Label_0048:
            if (num2 < DataTable2.Rows.Count) goto Label_001F;
            return table;
        Label_0058:
            num++;
        Label_005C:
            if (num < DataTable1.Rows.Count)
            {
                DataTable1.Rows[num].ItemArray.CopyTo(objArray, 0);
                table.Rows.Add(objArray);
                goto Label_0058;
            }
            num2 = 0;
            if (((uint) num2) < 0) goto Label_0058;
            goto Label_0048;
        }

        /// <summary>将XmlDocument转为DataSet</summary>
        /// <param name="doc">XmlDocument对象</param>
        /// <returns>DataSet对象</returns>
        public static DataSet XmlDocumentToDataSet(XmlDocument doc)
        {
            DataSet set = null;
            try
            {
                XmlNodeReader reader = new XmlNodeReader(doc);
                set = new DataSet();
                set.ReadXml(reader);
                reader.Close();
            }
            catch (Exception)
            {
            }
            return set;
        }

        /// <summary>读取Xml文件信息,并转换成DataSet对象</summary>
        /// <remarks>DataSet ds = new DataSet();ds = CXmlFileToDataSet("/XML/upload.xml");</remarks>
        /// <param name="XmlFilePath">Xml文件地址</param>
        /// <returns>DataSet对象</returns>
        public static DataSet XmlFileToDataSet(string XmlFilePath)
        {
            if (!string.IsNullOrEmpty(XmlFilePath))
            {
                string filename = HttpContext.Current.Server.MapPath(XmlFilePath);
                StringReader input = null;
                XmlTextReader reader = null;
                try
                {
                    DataSet set;
                    XmlDocument document = new XmlDocument();
                    document.Load(filename);
                    do
                    {
                        set = new DataSet();
                        input = new StringReader(document.InnerXml);
                        reader = new XmlTextReader(input);
                    }
                    while (0 != 0);
                    set.ReadXml(reader);
                    return set;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                        input.Close();
                        input.Dispose();
                    }
                }
            }
            return null;
        }

        /// <summary>将Xml字符串转换成DataSet对象</summary>
        /// <param name="XmlStr">Xml内容字符串</param>
        /// <returns>DataSet对象</returns>
        public static DataSet XmlToDataSet(string XmlStr)
        {
            if (!string.IsNullOrEmpty(XmlStr))
            {
                StringReader input = null;
                XmlTextReader reader = null;
                try
                {
                    DataSet set = new DataSet();
                    input = new StringReader(XmlStr);
                    reader = new XmlTextReader(input);
                    set.ReadXml(reader);
                    return set;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                        input.Close();
                        input.Dispose();
                    }
                }
            }
            return null;
        }

        /// <summary>将Xml字符串转为DataTable对象</summary>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        public static DataTable XmlToDataTable(string xmlStr) { return XmlToDataSet(xmlStr).Tables[0]; }

        /// <summary>将Xml字符串转为DataTable对象对应DataTableToXml2</summary>
        /// <param name="xmlStr"></param>
        /// <returns></returns>
        public static DataTable XmlToDataTable2(string xmlStr)
        {
            XmlNodeList list;
            DataTable table;
            DataRow row;
            int num;
            XmlElement element;
            int num2;
            int num3;
            XmlDocument document = new XmlDocument();
            if (0 == 0)
            {
                document.LoadXml(xmlStr);
                list = document.SelectNodes("//DataTable/Rows");
                table = new DataTable();
                num = 0;
                goto Label_0030;
            }
            goto Label_0042;
        Label_000E:
            if (num3 < element.ChildNodes.Count)
            {
                if (!table.Columns.Contains(element.ChildNodes.Item(num3).Name)) goto Label_0042;
                if (((uint) num) - ((uint) num3) > uint.MaxValue) goto Label_00D7;
                goto Label_009B;
            }
            table.Rows.Add(row);
            num++;
        Label_0030:
            if (num < list.Count)
            {
                row = table.NewRow();
                element = (XmlElement) list.Item(num);
                num2 = 0;
                if (((uint) num) > uint.MaxValue) goto Label_0030;
                if (0x7fffffff != 0) goto Label_0130;
            }
            else
                return table;
        Label_0042:
            table.Columns.Add(element.ChildNodes.Item(num3).Name);
        Label_009B:
            row[element.ChildNodes.Item(num3).Name] = element.ChildNodes.Item(num3).InnerText;
            num3++;
            goto Label_000E;
        Label_00D7:
            num3 = 0;
            if (((uint) num2) < 0) goto Label_009B;
            goto Label_000E;
        Label_00F4:
            row["@" + element.Attributes[num2].Name] = element.Attributes[num2].Value;
            num2++;
        Label_0130:
            if (num2 < element.Attributes.Count)
            {
                if (table.Columns.Contains("@" + element.Attributes[num2].Name)) goto Label_00F4;
                if (((uint) num2) < 0) goto Label_000E;
                table.Columns.Add("@" + element.Attributes[num2].Name);
                if (0 == 0) goto Label_00F4;
            }
            goto Label_00D7;
        }
    }
}
