namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web;

    /// <summary><para>　</para>
    /// 类名：常用工具类——直接在浏览器输出数据[注：只适用于WebForm]
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------------</para><para>　DumpDataTable：接在浏览器输出数据DataTable</para><para>　DumpListItemILIST：直接在浏览器输出数据ILIST＜ListItem＞</para><para>　DumpDataTableILIST：直接在浏览器输出数据DataTableILIST</para><para>　DumpIntArrILIST：直接在浏览器输出数据整型数组ILIST＜int[]＞</para><para>　DumpStrArrILIST：直接在浏览器输出数据字符串数组的ILIST＜string[]＞</para><para>　DumpDataSet：直接在浏览器输出数据DataSet对象</para><para>　DumpObjectArr2：直接在浏览器中输出二维数组</para></summary>
    public class DumpHelper
    {
        /// <summary>列数颜色</summary>
        protected static string ColorColumnsCount;
        /// <summary>数据类型颜色</summary>
        protected static string ColorDataType = "red";
        /// <summary>字段名颜色</summary>
        protected static string ColorFieldName;
        /// <summary>字段类型颜色</summary>
        protected static string ColorFieldType;
        /// <summary>字段值颜色</summary>
        protected static string ColorFieldValue;
        /// <summary>无数据时颜色</summary>
        protected static string ColorNoData;
        /// <summary>行数颜色</summary>
        protected static string ColorRowCount;
        /// <summary>序号颜色</summary>
        protected static string ColorSerial;
        /// <summary>输出字符串ＤＩＶ开始</summary>
        protected static string DivRef;
        /// <summary>最终输出字符串</summary>
        protected static string DumpStr;

        static DumpHelper()
        {
            if (0 == 0) goto Label_0040;
        Label_000D:
            DivRef = "<div style='font-size:14px;line-height:20px;margin:5px 0 0 5px;'>";
            return;
        Label_0040:
            ColorRowCount = "red";
            ColorColumnsCount = "red";
            do
            {
                ColorNoData = "red";
                ColorSerial = "black";
                ColorFieldName = "blue";
            }
            while (1 == 0);
            ColorFieldType = "#cc9999";
            if (8 != 0)
            {
                if (8 != 0)
                {
                    ColorFieldValue = "#9933ff";
                    DumpStr = string.Empty;
                }
                goto Label_000D;
            }
            goto Label_0040;
        }

        /// <summary>直接在浏览器输出数据DataSet对象</summary>
        /// <param name="DS">DataSet对象</param>
        public static void DumpDataSet(DataSet DS)
        {
            int num;
            int num2;
            DataTable table;
            int num3;
            int count;
            int num5;
            int num6;
            string str;
            string str2;
            object dumpStr;
            object[] objArray2;
            object obj3;
            object[] objArray3;
            object obj4;
            object[] objArray4;
            if (DS == null) goto Label_0035;
            goto Label_062C;
        Label_0022:
            if (num5 < num3)
            {
                obj3 = DumpStr;
                objArray3 = new object[6];
                goto Label_02F7;
            }
        Label_002A:
            num2++;
        Label_002E:
            if (num2 < num)
            {
                if (num2 <= 0)
                {
                    if (15 != 0) goto Label_046E;
                    if (((uint) num3) + ((uint) num5) <= uint.MaxValue) goto Label_0520;
                }
                else
                {
                    DumpStr = DumpStr + "<hr>";
                    goto Label_046E;
                }
                goto Label_04EC;
            }
        Label_0035:
            HttpContext.Current.Response.Write(DumpStr + "</div>");
            if (((uint) num2) + ((uint) num3) <= uint.MaxValue) return;
            if (((uint) num) + ((uint) count) < 0) goto Label_015E;
        Label_0094:
            if (num6 < count)
            {
                str = table.Columns[num6].ColumnName.ToString();
                str2 = table.Columns[num6].DataType.ToString();
                goto Label_027A;
            }
            if (((uint) num3) - ((uint) num3) >= 0)
            {
                DumpStr = DumpStr + "<p>";
                num5++;
                goto Label_0022;
            }
            return;
        Label_009F:
            if (((uint) count) - ((uint) count) > uint.MaxValue) goto Label_03DB;
        Label_00BA:
            objArray4[13] = ">";
            objArray4[14] = table.Rows[num5][str].ToString();
            objArray4[15] = "</font>\"<br>";
            DumpStr = string.Concat(objArray4);
            num6++;
            goto Label_0094;
        Label_0115:
            if (((uint) num) > uint.MaxValue) goto Label_01FA;
            objArray4[9] = ">";
            if (((uint) num5) < 0) goto Label_00BA;
            objArray4[10] = str2;
            objArray4[11] = "</font> ) => \"<font color=";
            if (15 == 0) goto Label_01AE;
            objArray4[12] = ColorFieldValue;
            goto Label_009F;
        Label_015E:
            objArray4[6] = str;
            if (((uint) num6) - ((uint) num2) > uint.MaxValue) goto Label_027A;
            objArray4[7] = "</font> ( <font color=";
            objArray4[8] = ColorFieldType;
            if (-1 != 0) goto Label_0115;
            goto Label_009F;
        Label_01AE:
            objArray4[2] = num6;
            objArray4[3] = "] <font color=";
            objArray4[4] = ColorFieldName;
            objArray4[5] = ">";
            goto Label_015E;
        Label_01FA:
            objArray4[0] = obj4;
            objArray4[1] = "　　　　[";
            goto Label_01AE;
        Label_027A:
            obj4 = DumpStr;
            if (((uint) num6) + ((uint) count) >= 0)
            {
                if (1 == 0) goto Label_0115;
                if (((uint) num5) + ((uint) num2) < 0) goto Label_047B;
                if (((uint) num5) - ((uint) num2) <= uint.MaxValue)
                {
                    objArray4 = new object[0x10];
                    if (((uint) num2) - ((uint) num) < 0) goto Label_02F7;
                    goto Label_01FA;
                }
            }
            goto Label_015E;
        Label_02CA:
            objArray3[4] = num5;
            objArray3[5] = "</font> ) => <br>";
            DumpStr = string.Concat(objArray3);
            num6 = 0;
            goto Label_0094;
        Label_02F7:
            objArray3[0] = obj3;
            objArray3[1] = "　　( Row：<font color=";
            objArray3[2] = ColorSerial;
            objArray3[3] = ">";
            goto Label_02CA;
        Label_0364:
            objArray2[12] = count;
            objArray2[13] = "</font> ]<br>";
            DumpStr = string.Concat(objArray2);
            if (num3 >= 1)
            {
                if (((uint) count) + ((uint) num) <= uint.MaxValue) goto Label_0454;
                goto Label_03C0;
            }
        Label_0388:
            DumpStr = DumpStr + "　<font color=" + ColorNoData + ">表格中无数据！</font><p>";
            goto Label_002A;
        Label_03C0:
            objArray2[10] = ColorColumnsCount;
            objArray2[11] = ">";
            goto Label_0364;
        Label_03DB:
            objArray2[4] = table.TableName;
            objArray2[5] = " ) => [ 行数：<font color=";
            objArray2[6] = ColorRowCount;
            objArray2[7] = ">";
            objArray2[8] = num3;
            objArray2[9] = "</font>，列数：<font color=";
            if (0 == 0)
            {
                if (((uint) num3) >= 0) goto Label_03C0;
                goto Label_0454;
            }
        Label_0417:
            objArray2[1] = "( 表序号：";
            objArray2[2] = num2;
            objArray2[3] = "　表名：";
            goto Label_03DB;
        Label_0437:
            objArray2[0] = dumpStr;
            goto Label_0417;
        Label_0454:
            if (((uint) num6) >= 0)
            {
                if (((uint) num) >= 0)
                {
                    num5 = 0;
                    if (((uint) num5) + ((uint) num) < 0) goto Label_0520;
                    if (((uint) num3) > uint.MaxValue) goto Label_0035;
                    goto Label_0022;
                }
                goto Label_0094;
            }
            goto Label_062C;
        Label_046E:
            table = DS.Tables[num2];
        Label_047B:
            num3 = table.Rows.Count;
            count = table.Columns.Count;
            dumpStr = DumpStr;
            objArray2 = new object[14];
            goto Label_0437;
        Label_04EC:
            if ((((uint) num2) & 0) != 0) goto Label_0364;
            if (((uint) count) + ((uint) count) < 0) goto Label_02CA;
            goto Label_002E;
        Label_0520:
            num2 = 0;
            goto Label_04EC;
        Label_052E:
            DumpStr = DumpStr + "　<font color=" + ColorNoData + ">DataSet对象中无表格！</font>";
            goto Label_0035;
        Label_062C:
            num = DS.Tables.Count;
            object[] objArray = new object[8];
            if ((((uint) num2) & 0) == 0)
            {
                objArray[0] = DivRef;
                objArray[1] = "数据类型：<font color=";
                objArray[2] = ColorDataType;
                objArray[3] = ">DataSet对象</font>　[ DataSet中表格个数：<font color=";
                if ((((uint) num5) & 0) != 0) goto Label_0388;
                objArray[4] = ColorRowCount;
                objArray[5] = ">";
                if (((uint) num) - ((uint) num5) > uint.MaxValue) goto Label_062C;
            }
            if (8 != 0) objArray[6] = num;
            objArray[7] = "</font> ] <hr>";
            DumpStr = string.Concat(objArray);
            if ((((uint) num2) & 0) == 0)
            {
                if (num < 1) goto Label_052E;
            }
            else if (((uint) num3) - ((uint) num2) <= uint.MaxValue) goto Label_052E;
            if (((uint) num5) >= 0)
            {
                if (((uint) num2) <= uint.MaxValue) goto Label_0520;
                goto Label_0437;
            }
            goto Label_062C;
        }

        /// <summary>直接在浏览器输出数据DataTable</summary>
        /// <param name="Dt">DataTable表格</param>
        public static void DumpDataTable(DataTable Dt)
        {
            int num;
            int count;
            int num3;
            int num4;
            string str;
            string str2;
            object[] objArray;
            object[] objArray3;
            if (Dt != null) goto Label_044A;
        Label_0008:
            HttpContext.Current.Response.Write(DumpStr + "</div>");
            goto Label_0432;
        Label_002F:
            if (num4 < count)
            {
                str = Dt.Columns[num4].ColumnName.ToString();
                str2 = Dt.Columns[num4].DataType.ToString();
                object dumpStr = DumpStr;
                objArray3 = new object[0x10];
                objArray3[0] = dumpStr;
                if ((((uint) count) & 0) != 0) goto Label_02FD;
                goto Label_018C;
            }
            DumpStr = DumpStr + "<p>";
            num3++;
        Label_004E:
            if (num3 < num)
            {
                object obj2 = DumpStr;
                if (((uint) num3) + ((uint) num) > uint.MaxValue) goto Label_03AD;
                object[] objArray2 = new object[6];
                while (true)
                {
                    objArray2[0] = obj2;
                    if (((uint) num) + ((uint) count) > uint.MaxValue) goto Label_004E;
                    objArray2[1] = "( Row：<font color=";
                    objArray2[2] = ColorSerial;
                    objArray2[3] = ">";
                    if ((((uint) num) | 1) == 0) goto Label_034E;
                    objArray2[4] = num3;
                    if ((((uint) num3) & 0) == 0)
                    {
                        if (((uint) num4) + ((uint) num3) >= 0)
                        {
                            objArray2[5] = "</font> ) => <br>";
                            DumpStr = string.Concat(objArray2);
                            num4 = 0;
                            goto Label_002F;
                        }
                        goto Label_03C2;
                    }
                }
            }
            if (((uint) num3) + ((uint) num3) >= 0) goto Label_014F;
        Label_0114:
            objArray3[5] = ">";
            objArray3[6] = str;
            objArray3[7] = "</font> ( <font color=";
            objArray3[8] = ColorFieldType;
            if (0x7fffffff == 0 || ((uint) num3) - ((uint) num) <= uint.MaxValue)
            {
                objArray3[9] = ">";
                objArray3[10] = str2;
                objArray3[11] = "</font> ) => \"<font color=";
                objArray3[12] = ColorFieldValue;
            }
            objArray3[13] = ">";
            objArray3[14] = Dt.Rows[num3][str].ToString();
            objArray3[15] = "</font>\"<br>";
            DumpStr = string.Concat(objArray3);
            num4++;
            goto Label_002F;
        Label_014F:
            if (((uint) num3) - ((uint) num3) >= 0) goto Label_0008;
            goto Label_0432;
        Label_018C:
            objArray3[1] = "　　[";
            objArray3[2] = num4;
            objArray3[3] = "] <font color=";
            objArray3[4] = ColorFieldName;
            if (((uint) num) >= 0) goto Label_0114;
            goto Label_014F;
        Label_02D4:
            num3 = 0;
            if ((((uint) num) | uint.MaxValue) != 0) goto Label_004E;
            if (3 != 0) goto Label_03C2;
            goto Label_0344;
        Label_02FD:
            DumpStr = string.Concat(objArray);
        Label_0309:
            if (((uint) num) - ((uint) num) <= uint.MaxValue && num >= 1) goto Label_02D4;
            DumpStr = DumpStr + "　<font color=" + ColorNoData + ">无表格行数据！</font>";
            goto Label_0008;
        Label_0344:
            objArray[9] = "</font>，列数：<font color=";
        Label_034E:
            objArray[10] = ColorColumnsCount;
            objArray[11] = ">";
            objArray[12] = count;
            objArray[13] = "</font> ] <hr>";
            goto Label_02FD;
        Label_039B:
            objArray[5] = " 行数：<font color=";
            objArray[6] = ColorRowCount;
        Label_03AD:
            objArray[7] = ">";
            objArray[8] = num;
            if ((((uint) count) & 0) == 0) goto Label_0344;
            goto Label_02D4;
        Label_03C2:
            if ((((uint) count) & 0) != 0) goto Label_018C;
        Label_03D9:
            objArray[0] = DivRef;
            objArray[1] = "数据类型：<font color=";
            objArray[2] = ColorDataType;
            objArray[3] = ">TableDate</font>　[ 表名：";
            if (((uint) num) > uint.MaxValue) goto Label_0309;
            objArray[4] = Dt.TableName;
            goto Label_039B;
        Label_0432:
            if (((uint) count) - ((uint) num4) >= 0) return;
        Label_044A:
            num = Dt.Rows.Count;
            count = Dt.Columns.Count;
            objArray = new object[14];
            if (-1 == 0) goto Label_039B;
            if (((uint) num4) < 0) goto Label_03D9;
            goto Label_03C2;
        }

        /// <summary>直接在浏览器输出数据DataTableILIST</summary>
        /// <param name="ListDataTable">ILIST＜ListDataTable＞泛型数据</param>
        public static void DumpDataTableILIST(IList<DataTable> ListDataTable)
        {
            int num;
            int num2;
            DataTable table;
            int count;
            int num4;
            int num5;
            int num6;
            string str;
            string str2;
            object[] objArray;
            object dumpStr;
            object[] objArray2;
            object[] objArray3;
            object obj4;
            object[] objArray4;
            if (ListDataTable == null) goto Label_0035;
            goto Label_05DB;
        Label_0022:
            if (num5 < count)
            {
                object obj3 = DumpStr;
                objArray3 = new object[6];
                objArray3[0] = obj3;
                goto Label_02A8;
            }
        Label_002A:
            num2++;
        Label_002E:
            if (num2 < num) goto Label_041F;
        Label_0035:
            HttpContext.Current.Response.Write(DumpStr + "</div>");
            if (((uint) num5) - ((uint) num5) >= 0) return;
            goto Label_0174;
        Label_0091:
            if (num6 < count)
            {
                str = table.Columns[num6].ColumnName.ToString();
                str2 = table.Columns[num6].DataType.ToString();
                if (((uint) num) - ((uint) num5) > uint.MaxValue) goto Label_0520;
                obj4 = DumpStr;
                objArray4 = new object[0x10];
                goto Label_0207;
            }
            DumpStr = DumpStr + "<p>";
            num5++;
            goto Label_0022;
        Label_00BC:
            objArray4[15] = "</font>\"<br>";
            DumpStr = string.Concat(objArray4);
            if (((uint) num6) <= uint.MaxValue)
            {
                if ((((uint) count) | 4) == 0) goto Label_00BC;
                num6++;
                goto Label_0091;
            }
            if (((uint) num5) - ((uint) num6) >= 0) goto Label_0141;
        Label_00FF:
            objArray4[10] = str2;
            if (((uint) num2) + ((uint) count) < 0) goto Label_03EE;
            objArray4[11] = "</font> ) => \"<font color=";
            objArray4[12] = ColorFieldValue;
            objArray4[13] = ">";
            objArray4[14] = table.Rows[num5][str].ToString();
            goto Label_00BC;
        Label_0141:
            objArray4[9] = ">";
            if (((uint) num5) - ((uint) num2) > uint.MaxValue) goto Label_0207;
            goto Label_00FF;
        Label_0174:
            objArray4[6] = str;
            objArray4[7] = "</font> ( <font color=";
            objArray4[8] = ColorFieldType;
            goto Label_0141;
        Label_0207:
            objArray4[0] = obj4;
            objArray4[1] = "　　　　[";
            objArray4[2] = num6;
            objArray4[3] = "] <font color=";
            objArray4[4] = ColorFieldName;
            objArray4[5] = ">";
            if (2 != 0)
            {
                if (((uint) num5) - ((uint) num) >= 0) goto Label_0174;
                if (((uint) num6) - ((uint) num) >= 0) goto Label_034A;
                goto Label_002A;
            }
            goto Label_0022;
        Label_0222:
            objArray3[5] = "</font> ) => <br>";
            DumpStr = string.Concat(objArray3);
            num6 = 0;
            goto Label_0091;
        Label_02A8:
            objArray3[1] = "　　( Row：<font color=";
            objArray3[2] = ColorSerial;
            objArray3[3] = ">";
            objArray3[4] = num5;
            if (-2 == 0) goto Label_041F;
            goto Label_0222;
        Label_034A:
            objArray2[9] = "</font>，列数：<font color=";
            objArray2[10] = ColorColumnsCount;
        Label_035E:
            objArray2[11] = ">";
            objArray2[12] = num4;
            if (((uint) count) + ((uint) num) > uint.MaxValue) goto Label_040E;
            if (((uint) num) + ((uint) num2) > uint.MaxValue) goto Label_0222;
            objArray2[13] = "</font> ]<br>";
            DumpStr = string.Concat(objArray2);
            if (count < 1)
            {
                DumpStr = DumpStr + "　<font color=" + ColorNoData + ">表格中无数据！</font><p>";
                goto Label_002A;
            }
            num5 = 0;
            goto Label_0022;
        Label_03BF:
            objArray2[7] = ">";
            objArray2[8] = count;
            if (((uint) num4) <= uint.MaxValue) goto Label_034A;
        Label_03E4:
            objArray2[2] = num2;
        Label_03EE:
            objArray2[3] = "　表名：";
            objArray2[4] = table.TableName;
            objArray2[5] = " ) => [ 行数：<font color=";
            if (0 != 0) goto Label_035E;
            objArray2[6] = ColorRowCount;
            goto Label_03BF;
        Label_040E:
            objArray2 = new object[14];
            objArray2[0] = dumpStr;
            if (((uint) num2) - ((uint) count) <= uint.MaxValue) objArray2[1] = "( 表序号：";
            if (0 == 0) goto Label_05F1;
            goto Label_05DB;
        Label_041F:
            if (num2 > 0) DumpStr = DumpStr + "<hr>";
            table = ListDataTable[num2];
            count = table.Rows.Count;
            num4 = table.Columns.Count;
            dumpStr = DumpStr;
            goto Label_040E;
        Label_0520:
            objArray[3] = ">IList＜DataTable＞</font>　[ DataTable数：<font color=";
            objArray[4] = ColorRowCount;
            objArray[5] = ">";
            if (((uint) num5) + ((uint) num) < 0) goto Label_03BF;
            objArray[6] = num;
            do
            {
                objArray[7] = "</font> ] <hr>";
                DumpStr = string.Concat(objArray);
            }
            while (((uint) num6) - ((uint) num) > uint.MaxValue);
            if (num >= 1)
            {
                num2 = 0;
                goto Label_002E;
            }
            DumpStr = DumpStr + "　<font color=" + ColorNoData + ">泛型中无数据！</font>";
            goto Label_0035;
        Label_05DB:
            num = ListDataTable.Count;
            objArray = new object[8];
            if (((uint) num6) > uint.MaxValue) goto Label_002E;
            if (((uint) num4) + ((uint) count) < 0) goto Label_0222;
            if (((uint) num4) + ((uint) num6) < 0) goto Label_02A8;
            objArray[0] = DivRef;
            if ((((uint) num4) | 0x7fffffff) == 0) goto Label_00BC;
            if ((((uint) num6) & 0) == 0)
            {
                if (8 != 0)
                {
                    objArray[1] = "数据类型：<font color=";
                    objArray[2] = ColorDataType;
                    goto Label_0520;
                }
            }
            else
                goto Label_05DB;
        Label_05F1:
            if ((((uint) num2) & 0) == 0) goto Label_03E4;
            goto Label_0174;
        }

        /// <summary>直接在浏览器输出数据整型数组ILIST＜int[]＞</summary>
        /// <param name="IntList">ILIST＜Int[]＞泛型数据</param>
        public static void DumpIntArrILIST(IList<int[]> IntList)
        {
            int num;
            int num2;
            int[] numArray;
            int length;
            int num4;
            object[] objArray;
            object obj2;
            object[] objArray2;
            object[] objArray3;
            if (IntList == null) goto Label_002D;
            goto Label_03A5;
        Label_001A:
            if (num4 < length)
            {
                object dumpStr = DumpStr;
                objArray3 = new object[10];
                if (-2 != 0)
                {
                    if (((uint) num4) + ((uint) num) < 0) goto Label_0384;
                    if (((uint) length) + ((uint) num2) <= uint.MaxValue)
                    {
                        objArray3[0] = dumpStr;
                        if ((((uint) num) | uint.MaxValue) == 0) goto Label_0022;
                        objArray3[1] = "　　[";
                        objArray3[2] = num4;
                        if (((uint) num2) > uint.MaxValue) goto Label_02D9;
                        objArray3[3] = "]  ( <font color=";
                        objArray3[4] = ColorFieldType;
                        objArray3[5] = ">Int</font> ) => \"<font color=";
                        objArray3[6] = ColorFieldValue;
                    }
                    objArray3[7] = ">";
                    goto Label_0050;
                }
                goto Label_0184;
            }
        Label_0022:
            num2++;
        Label_0026:
            if (num2 < num) goto Label_02D9;
        Label_002D:
            HttpContext.Current.Response.Write(DumpStr + "</div>");
            goto Label_0184;
        Label_0050:
            objArray3[8] = numArray[num4].ToString();
            if ((((uint) num2) | 0x7fffffff) == 0) goto Label_0358;
            objArray3[9] = "</font>\"<br>";
            if ((((uint) num4) & 0) != 0) goto Label_0253;
            DumpStr = string.Concat(objArray3);
            num4++;
            goto Label_001A;
        Label_0184:
            if (((uint) num) + ((uint) num4) <= uint.MaxValue) return;
            if ((((uint) num) | 0x80000000) != 0) goto Label_03A5;
        Label_0212:
            objArray2[7] = ">";
            objArray2[8] = length;
            if (((uint) num) <= uint.MaxValue)
            {
                objArray2[9] = "</font><br>";
                DumpStr = string.Concat(objArray2);
                if (length < 1)
                {
                    DumpStr = DumpStr + "　　<font color=" + ColorNoData + ">数组中无数据</font><p>";
                    if ((((uint) num) | 1) == 0) goto Label_0050;
                    goto Label_0022;
                }
            }
            num4 = 0;
            goto Label_001A;
        Label_0253:
            objArray2[0] = obj2;
            objArray2[1] = "( Int[]：<font color=";
            objArray2[2] = ColorSerial;
            objArray2[3] = ">";
            objArray2[4] = num2;
            if ((((uint) num2) & 0) == 0)
            {
                objArray2[5] = "</font> ) => 数组元素个数：<font color=";
                objArray2[6] = ColorSerial;
            }
            goto Label_0212;
        Label_02D9:
            numArray = IntList[num2];
            goto Label_03B8;
        Label_0358:
            objArray = new object[8];
            objArray[0] = DivRef;
            objArray[1] = "数据类型：<font color=";
            objArray[2] = ColorDataType;
            objArray[3] = ">IList＜Int[]＞</font>　[ Int[]个数：<font color=";
        Label_0384:
            objArray[4] = ColorRowCount;
            if ((((uint) length) | 3) != 0)
            {
                if (((uint) length) <= uint.MaxValue)
                {
                }
                objArray[5] = ">";
                objArray[6] = num;
                objArray[7] = "</font> ] <hr>";
                if (((uint) num4) + ((uint) num4) >= 0)
                {
                    DumpStr = string.Concat(objArray);
                    if (num >= 1)
                    {
                        num2 = 0;
                        goto Label_0026;
                    }
                    if (((uint) num4) - ((uint) num4) >= 0)
                    {
                        DumpStr = DumpStr + "　<font color=" + ColorNoData + ">泛型中无数据！</font>";
                        goto Label_002D;
                    }
                    goto Label_03B8;
                }
            }
        Label_03A5:
            num = IntList.Count;
            goto Label_0358;
        Label_03B8:
            if (3 != 0)
            {
                length = numArray.Length;
                obj2 = DumpStr;
                objArray2 = new object[10];
                goto Label_0253;
            }
            goto Label_0212;
        }

        /// <summary>直接在浏览器输出数据ILIST＜ListItem＞</summary>
        /// <param name="ListItems">ILIST＜ListItem＞泛型数据</param>
        public static void DumpListItemILIST(IList<ListItem> ListItems)
        {
            int count;
            int num2;
            string str;
            string str2;
            object[] objArray;
            object[] objArray2;
            string[] strArray;
            string str4;
            string[] strArray2;
            if (ListItems == null) goto Label_002D;
            if (3 == 0) goto Label_00D0;
            if (-1 != 0) goto Label_0301;
            return;
        Label_000D:
            strArray2[7] = "</font>\"<br>";
            DumpStr = string.Concat(strArray2);
            num2++;
        Label_0026:
            while (num2 < count)
            {
                object obj2 = DumpStr;
                objArray2 = new object[] { obj2, "( ", num2, " ) => <br>" };
                if (0 == 0) goto Label_013F;
            }
        Label_002D:
            HttpContext.Current.Response.Write(DumpStr + "</div>");
            if (((uint) count) >= 0) goto Label_012D;
        Label_00C7:
            strArray[1] = "　　<font color=";
        Label_00D0:
            strArray[2] = ColorFieldName;
            strArray[3] = ">[ Text ]</font> => \"<font color=";
            strArray[4] = ColorFieldValue;
            strArray[5] = ">";
            if ((((uint) num2) & 0) == 0)
            {
                strArray[6] = str;
                strArray[7] = "</font>\"<br>";
                DumpStr = string.Concat(strArray);
                str4 = DumpStr;
            }
            strArray2 = new string[8];
            strArray2[0] = str4;
            strArray2[1] = "　　<font color=";
            strArray2[2] = ColorFieldName;
            strArray2[3] = ">[ Value ]</font> => \"<font color=";
            strArray2[4] = ColorFieldValue;
            strArray2[5] = ">";
            if (((uint) count) + ((uint) num2) >= 0)
            {
                strArray2[6] = str2;
                goto Label_000D;
            }
        Label_012D:
            if (((uint) num2) <= uint.MaxValue) return;
        Label_013F:
            DumpStr = string.Concat(objArray2);
        Label_014B:
            str = ListItems[num2].Text.ToString();
            str2 = ListItems[num2].Value.ToString();
            string dumpStr = DumpStr;
            strArray = new string[8];
            strArray[0] = dumpStr;
            goto Label_00C7;
        Label_01CB:
            DumpStr = DumpStr + "　<font color=" + ColorNoData + ">泛型中无数据！</font>";
            goto Label_002D;
        Label_0251:
            objArray[4] = ColorRowCount;
            if (((uint) num2) + ((uint) count) > uint.MaxValue) goto Label_000D;
        Label_0275:
            if ((((uint) count) & 0) != 0) goto Label_000D;
            objArray[5] = ">";
            objArray[6] = count;
            objArray[7] = "</font> ] <hr>";
            DumpStr = string.Concat(objArray);
            if ((((uint) count) | 0xff) != 0)
            {
                if (count >= 1)
                {
                    num2 = 0;
                    if (((uint) num2) - ((uint) count) < 0) return;
                    goto Label_0026;
                }
                goto Label_01CB;
            }
            if (((uint) num2) - ((uint) num2) >= 0)
            {
                if (-1 != 0)
                {
                    if (((uint) count) + ((uint) count) < 0) return;
                    goto Label_01CB;
                }
            }
            else
                goto Label_0251;
        Label_0301:
            if (((uint) count) + ((uint) count) < 0) goto Label_013F;
            count = ListItems.Count;
            if (8 == 0) goto Label_0026;
            objArray = new object[8];
            objArray[0] = DivRef;
            if (((uint) count) + ((uint) count) < 0) goto Label_014B;
            objArray[1] = "数据类型：<font color=";
            objArray[2] = ColorDataType;
            if (3 == 0) goto Label_0275;
            if (((uint) num2) + ((uint) count) >= 0 && ((uint) num2) + ((uint) count) <= uint.MaxValue) objArray[3] = ">IList＜ListItem＞</font>　[ 项目数：<font color=";
            goto Label_0251;
        }

        /// <summary>直接在浏览器中输出二维数组</summary>
        /// <param name="ObjArr">二维数组</param>
        public static void DumpObjectArr2(object[] ObjArr)
        {
            int num;
            int num2;
            object[] objArray;
            object obj3;
            if (ObjArr == null) goto Label_0013;
        Label_02B1:
            num = ObjArr.Length;
            if (((uint) num) - ((uint) num) < 0) goto Label_0013;
            if (((uint) num2) - ((uint) num) >= 0)
            {
                objArray = new object[8];
                objArray[0] = DivRef;
                objArray[1] = "数据类型：<font color=";
                objArray[2] = ColorDataType;
                if (((uint) num) + ((uint) num2) <= uint.MaxValue)
                {
                    objArray[3] = ">Object数组</font>　[ 数组中元素个数：<font color=";
                    if (((uint) num) - ((uint) num) >= 0)
                    {
                        objArray[4] = ColorRowCount;
                        objArray[5] = ">";
                        objArray[6] = num;
                    }
                    goto Label_0255;
                }
                if (((uint) num) + ((uint) num) > uint.MaxValue) goto Label_02B1;
            }
            goto Label_01FE;
        Label_000C:
            if (num2 < num) goto Label_01FE;
        Label_0013:
            HttpContext.Current.Response.Write(DumpStr + "</div>");
            return;
        Label_01FE:
            obj3 = DumpStr;
            object[] objArray2 = new object[6];
            while (true)
            {
                object obj2;
                string dumpStr;
                objArray2[0] = obj3;
                objArray2[1] = "　　( <font color=";
                objArray2[2] = ColorSerial;
                if ((((uint) num) | 3) != 0)
                {
                    objArray2[3] = ">";
                    objArray2[4] = num2;
                    objArray2[5] = "</font> ) ";
                    DumpStr = string.Concat(objArray2);
                    obj2 = ObjArr[num2];
                    DumpStr = DumpStr + " ( ";
                    dumpStr = DumpStr;
                }
                string[] strArray = new string[6];
                strArray[0] = dumpStr;
                if ((((uint) num) & 0) == 0)
                {
                    strArray[1] = "<font color=";
                    strArray[2] = ColorFieldType;
                    if (-2 == 0) goto Label_0255;
                    strArray[3] = ">";
                    strArray[4] = obj2.GetType().ToString();
                    strArray[5] = "</font>";
                    DumpStr = string.Concat(strArray);
                    DumpStr = DumpStr + " ) ";
                    object obj4 = DumpStr;
                    object[] objArray3 = new object[6];
                    objArray3[0] = obj4;
                    if (((uint) num) < 0) break;
                    objArray3[1] = " => <font color=";
                    if (4 != 0)
                    {
                        if (((uint) num) - ((uint) num) < 0) goto Label_0215;
                        objArray3[2] = ColorFieldValue;
                        objArray3[3] = ">\"";
                    }
                    objArray3[4] = obj2;
                    objArray3[5] = "\"</font><br>";
                    DumpStr = string.Concat(objArray3);
                    if (((uint) num2) + ((uint) num2) >= 0)
                    {
                        num2++;
                        goto Label_000C;
                    }
                    return;
                }
            }
        Label_020A:
            DumpStr = string.Concat(objArray);
        Label_0215:
            num2 = 0;
            goto Label_000C;
        Label_0255:
            objArray[7] = "</font> ] <hr>";
            goto Label_020A;
        }

        /// <summary>直接在浏览器输出数据字符串数组的ILIST＜string[]＞</summary>
        /// <param name="StrList">ILIST＜String[]＞泛型数据</param>
        public static void DumpStrArrILIST(IList<string[]> StrList)
        {
            int num;
            int num2;
            string[] strArray;
            int length;
            int num4;
            object[] objArray;
            object obj3;
            object[] objArray3;
            if (StrList == null) goto Label_002E;
            if ((((uint) length) | 8) != 0) goto Label_0353;
            goto Label_0231;
        Label_0023:
            num2++;
        Label_0027:
            if (num2 < num)
            {
                strArray = StrList[num2];
                length = strArray.Length;
                object dumpStr = DumpStr;
                object[] objArray2 = new object[10];
                if (((uint) num) + ((uint) length) < 0) goto Label_00F4;
                if (0 == 0)
                {
                    objArray2[0] = dumpStr;
                    objArray2[1] = "( String[]：<font color=";
                    objArray2[2] = ColorSerial;
                    objArray2[3] = ">";
                    objArray2[4] = num2;
                }
                objArray2[5] = "</font> ) => 数组元素个数：<font color=";
                objArray2[6] = ColorSerial;
                objArray2[7] = ">";
                objArray2[8] = length;
                objArray2[9] = "</font><br>";
                if (((uint) num4) + ((uint) num2) > uint.MaxValue) goto Label_00F4;
                DumpStr = string.Concat(objArray2);
                if (length < 1)
                {
                    DumpStr = DumpStr + "　　<font color=" + ColorNoData + ">数组中无数据</font><p>";
                    goto Label_0023;
                }
                num4 = 0;
                if (((uint) num) + ((uint) num) >= 0) goto Label_0078;
                goto Label_0231;
            }
        Label_002E:
            HttpContext.Current.Response.Write(DumpStr + "</div>");
            return;
        Label_0072:
            num4++;
        Label_0078:
            if (num4 < length)
            {
                obj3 = DumpStr;
                if (((uint) length) < 0) goto Label_036B;
                goto Label_00F4;
            }
            goto Label_0023;
        Label_00B7:
            objArray3[4] = ColorFieldType;
            objArray3[5] = ">Int</font> ) => \"<font color=";
            objArray3[6] = ColorFieldValue;
            objArray3[7] = ">";
            objArray3[8] = strArray[num4].ToString();
            objArray3[9] = "</font>\"<br>";
            DumpStr = string.Concat(objArray3);
            if (((uint) length) < 0) goto Label_00FD;
            goto Label_0072;
        Label_00F4:
            objArray3 = new object[10];
        Label_00FD:
            objArray3[0] = obj3;
            objArray3[1] = "　　[";
            objArray3[2] = num4;
            objArray3[3] = "]  ( <font color=";
            goto Label_00B7;
        Label_0231:
            num2 = 0;
            if (((uint) length) - ((uint) num2) < 0) goto Label_0072;
            if (((uint) length) > uint.MaxValue) goto Label_00B7;
            goto Label_0027;
        Label_0283:
            DumpStr = DumpStr + "　<font color=" + ColorNoData + ">泛型中无数据！</font>";
            goto Label_002E;
        Label_02EA:
            objArray[6] = num;
            objArray[7] = "</font> ] <hr>";
            if (((uint) num4) + ((uint) num2) <= uint.MaxValue)
            {
                DumpStr = string.Concat(objArray);
                if (((uint) num2) + ((uint) length) >= 0)
                {
                    if (num < 1) goto Label_0283;
                    goto Label_0231;
                }
                if (((uint) num2) - ((uint) num4) >= 0)
                {
                    if (((uint) num) <= uint.MaxValue) goto Label_0283;
                    goto Label_0231;
                }
                goto Label_0353;
            }
            if (((uint) length) + ((uint) length) <= uint.MaxValue) goto Label_0353;
        Label_032D:
            objArray[2] = ColorDataType;
            objArray[3] = ">IList＜String[]＞</font>　[ String[]个数：<font color=";
            objArray[4] = ColorRowCount;
            objArray[5] = ">";
            goto Label_02EA;
        Label_0353:
            num = StrList.Count;
            objArray = new object[8];
            objArray[0] = DivRef;
        Label_036B:
            objArray[1] = "数据类型：<font color=";
            if (0x7fffffff != 0) goto Label_032D;
            goto Label_02EA;
        }
    }
}
