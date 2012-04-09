namespace Utils
{
    using Microsoft.VisualBasic;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;

    /// <summary><para>　</para>
    /// 类名：常用工具类——字符串操作类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>-------------------------------------------------------------------------------------------</para><para>　IsNum：判断输入的字符是不是全为数字</para><para>　t：替换内容中特殊字符为全角</para><para>　FormatBytesStr：格式化字节数字符串</para><para>　ToSChinese：转换为简体中文</para><para>　ToTChinese：转换为繁体中文</para><para>　ToColor：将字符串转换为Color</para><para>　IsStringDate：检查一个字符串是否可以转化为日期，一般用于验证用户输入日期的合法性。</para><para>　CutString：工具方法：NET截取指定长度汉字超出部分以"..."代替</para><para>　Verify：生成指定位数的随机数字或字符串</para><para>　RTrim：删除字符串尾部的回车/换行/空格</para><para>　ResponseFile：以指定的ContentType输出指定文件文件</para><para>　StrFormat：替换回车换行符为html换行符</para><para>　RemoveUnsafeHtml：过滤HTML中的不安全标签</para><para>　FilterStr：替字符串中不安全字符为大写</para><para>　NoHTML：删除字符串中所有HTML标记</para><para>　Split：分割字符串</para><para>　DelLastComma：删除最后结尾的一个逗号</para><para>　DelLastChar：删除最后结尾的指定字符后的字符</para><para>　ToSBC：半角转换为全角</para><para>　ToDBC：全角转换为半角</para><para>　GetArrayID：获取指定字符串在指定字符串数组中的位置</para><para>　IsInArray：判断指定字符串是否属于指定字符串数组中的一个元素</para><para>　IsInArray：判断指定字符串是否属于内部以分隔符分割单词的字符串的一个元素</para><para>  DeleteStrArrTheOne：删除字符串数组中的一个元素</para><para>　ClipboardData：将指定字符串复制到剪贴板</para><para>　DoubleToRound：将Double类型的数据四舍五入</para><para>　GetStrAToZ：将指定字符串中的汉字转换为拼音首字母的缩写，其中非汉字保留为原字符[生成指定字符串的助记码]</para><para>　GetStringLength：返回字符串真实长度, 1个汉字长度为2</para><para>　UTF8ToGB2312：将UTF-８字符串转为GB2312</para><para>　GB2312ToUTF8：将GB2312编码字符串转为UTF8</para></summary>
    public class StringHelper
    {
        /// <summary>将指定字符串复制到剪贴板'</summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="ClipblardStr">要复制到剪贴板的字符串内容</param>
        public static void ClipboardData(Page page, string ClipblardStr)
        {
            if (!string.IsNullOrEmpty(ClipblardStr))
            {
                string script = "<script language='javascript'>";
                script = (script + "window.clipboardData.setData('text', '" + ClipblardStr + "')") + "</script>";
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", script);
            }
        }

        /// <summary>将指定字符串复制到剪贴板并指定返回的信息</summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="ClipblardStr">要复制到剪贴板的字符串内容</param>
        /// <param name="BackMessage">要返回弹出消息，null为不弹出</param>
        public static void ClipboardData(Page page, string ClipblardStr, string BackMessage)
        {
            string str;
            if (string.IsNullOrEmpty(ClipblardStr)) return;
            if (0xff != 0) goto Label_004D;
        Label_0012:
            if (1 != 0) goto Label_0021;
        Label_0019:
            if (!string.IsNullOrEmpty(BackMessage))
            {
                str = str + "alert('" + BackMessage + "');";
                goto Label_0012;
            }
        Label_0021:
            str = str + "</script>";
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", str);
            if (2 != 0) return;
        Label_004D:
            str = "<script language='javascript'>";
            str = str + "window.clipboardData.setData('text', '" + ClipblardStr + "');";
            goto Label_0019;
        }

        /// <summary>工具方法：NET截取指定长度汉字超出部分以"..."代替使用示例：string str = StringSubstr("abcde",3,"...");</summary>
        /// <param name="oldStr">要截取的字符串[string]</param>
        /// <param name="maxLength">截取后字符串的最大长度[int]</param>
        /// <param name="endWith">超过长度的后缀，如：...或###等[string]</param>
        /// <returns>如果超过长度，返回截断后的新字符串加上后缀，否则，返回原字符串[string]</returns>
        public static string CutString(string oldStr, int maxLength, string endWith)
        {
            string str;
            if (!string.IsNullOrEmpty(oldStr))
            {
            Label_008A:
                if (maxLength >= 1)
                {
                    if ((((uint) maxLength) & 0) != 0)
                    {
                        if (0x7fffffff == 0) return oldStr;
                        goto Label_0015;
                    }
                    if (oldStr.Length <= maxLength)
                    {
                        if (((uint) maxLength) - ((uint) maxLength) >= 0) return oldStr;
                        if (((uint) maxLength) + ((uint) maxLength) >= 0) goto Label_00A4;
                        if (0 == 0) goto Label_008A;
                    }
                    else
                    {
                        str = oldStr.Substring(0, maxLength);
                        do
                        {
                            if (string.IsNullOrEmpty(endWith)) return str;
                        }
                        while (0 != 0);
                        goto Label_0015;
                    }
                }
                throw new Exception("返回的字符串长度必须大于[0] ");
            }
            if (1 != 0) goto Label_00A4;
        Label_0015:
            return (str + endWith);
        Label_00A4:
            return (oldStr + endWith);
        }

        /// <summary>删除字符串数组中的一个元素</summary>
        /// <param name="StrArr"></param>
        /// <param name="DeleteStr"></param>
        /// <returns></returns>
        public static string[] DeleteStrArrTheOne(string[] StrArr, string DeleteStr)
        {
            string str;
            int num2;
            List<string> list = new List<string>();
            int index = 0;
            goto Label_0046;
        Label_000B:
            str = str + ",";
        Label_0017:
            str = str + list[num2].ToString();
            num2++;
            if (0 != 0) goto Label_0083;
        Label_0031:
            if (num2 >= list.Count) return Split(str, ",");
            if (num2 <= 0) goto Label_0017;
            goto Label_000B;
        Label_0046:
            if (index >= StrArr.Length)
            {
                str = string.Empty;
                if (0 != 0) goto Label_000B;
                num2 = 0;
                if ((((uint) num2) | 0xfffffffe) != 0) goto Label_0031;
            }
            if (StrArr[index] != DeleteStr) list.Add(StrArr[index]);
        Label_0083:
            index++;
            goto Label_0046;
        }

        /// <summary>删除最后结尾的指定字符后的字符</summary>
        /// <param name="str">未删除的字符串</param>
        /// <param name="strchar">要删除之后的字符串</param>
        /// <returns>删除后的字符串</returns>
        public static string DelLastChar(string str, string strchar) { return str.Substring(0, str.LastIndexOf(strchar)); }

        /// <summary>删除最后结尾的一个逗号</summary>
        /// <param name="str">要删除逗号的字符串</param>
        /// <returns>删除逗号后的字符串</returns>
        public static string DelLastComma(string str) { return str.Substring(0, str.LastIndexOf(",")); }

        /// <summary>将Double类型的数据四舍五入</summary>
        /// <param name="Doubles">要四舍五入的Double类型数据</param>
        /// <param name="Point">保留小数点位数</param>
        /// <returns></returns>
        public static string DoubleToRound(double Doubles, int Point) { return Doubles.ToString("F" + Point); }

        /// <summary>替字符串中不安全字符为大写</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterStr(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            goto Label_03D6;
        Label_008C:
            str = str.Replace("SCRIPT", "ＳＣＲＩＰＴ");
            str = str.Replace("form", "ＦＯＲＭ");
            str = str.Replace("FORM", "ＦＯＲＭ");
            if (0 == 0)
            {
                str = str.Replace("meta", "ＭＥＴＡ");
                if (4 != 0)
                {
                    str = str.Replace("META", "ＭＥＴＡ");
                    str = str.Replace("style", "ＳＴＹＬＥ");
                    str = str.Replace("STYLE", "ＳＴＹＬＥ");
                    str = str.Replace("behavior", "ＢＥＨＡＶＩＯＲ");
                    str = str.Replace("BEHAVIOR", "ＢＥＨＡＶＩＯＲ");
                }
                if (8 != 0) return str;
                goto Label_03D6;
            }
        Label_0114:
            str = str.Replace("ALERT", "ＡＬＥＲＴ");
            str = str.Replace("cast", "ＣＡＳＴ");
            str = str.Replace("CAST", "ＣＡＳＴ");
            str = str.Replace("frame", "ＦＲＡＭＥ");
            str = str.Replace("FRAME", "ＦＲＡＭＥ");
            str = str.Replace("script", "ＳＣＲＩＰＴ");
            if (0 != 0) goto Label_037A;
            goto Label_008C;
        Label_0158:
            str = str.Replace("modify", "ＭＯＤＩＦＹ");
            str = str.Replace("MODIFY", "ＭＯＤＩＦＹ");
            str = str.Replace("rename", "ＲＥＮＡＭＥ");
            str = str.Replace("RENAME", "ＲＥＮＡＭＥ");
            str = str.Replace("alert", "ＡＬＥＲＴ");
            goto Label_0114;
        Label_0228:
            if (0xff == 0) goto Label_0317;
            str = str.Replace("update", "ＵＰＤＡＴＥ");
            str = str.Replace("UPDATE", "ＵＰＤＡＴＥ");
            str = str.Replace("like", "ＬＩＫＥ");
            str = str.Replace("LIKE", "ＬＩＫＥ");
        Label_01FD:
            str = str.Replace("drop", "ＤＲＯＰ");
            str = str.Replace("DROP", "ＤＲＯＰ");
            if (2 != 0)
            {
                if (2 != 0)
                {
                    if (15 != 0)
                    {
                        str = str.Replace("create", "ＣＲＥＡＴＥ");
                        if (0 != 0) goto Label_0329;
                        str = str.Replace("CREATE", "ＣＲＥＡＴＥ");
                        if (0 != 0) goto Label_008C;
                        if (15 != 0) goto Label_0158;
                        goto Label_0393;
                    }
                    goto Label_01FD;
                }
                goto Label_0158;
            }
            goto Label_0228;
        Label_02F2:
            if (0 != 0) goto Label_0114;
            if (0 == 0)
            {
                str = str.Replace("where", "ＷＨＥＲＥ");
                str = str.Replace("WHERE", "ＷＨＥＲＥ");
                str = str.Replace("insert", "ＩＮＳＥＲＴ");
                str = str.Replace("INSERT", "ＩＮＳＥＲＴ");
                str = str.Replace("delete", "ＤＥＬＥＴＥ");
                str = str.Replace("DELETE", "ＤＥＬＥＴＥ");
            }
            goto Label_0228;
        Label_0317:
            str = str.Replace("union", "ＵＮＩＯＮ");
        Label_0329:
            str = str.Replace("UNION", "ＵＮＩＯＮ");
            goto Label_02F2;
        Label_033D:
            str = str.Replace("》", "＞＞");
            str = str.Replace("select", "ＳＥＬＥＣＴ");
            str = str.Replace("SELECT", "ＳＥＬＥＣＴ");
            if (4 == 0) goto Label_0329;
        Label_037A:
            str = str.Replace("join", "ＪＯＩＮ");
            str = str.Replace("JOIN", "ＪＯＩＮ");
            goto Label_0317;
        Label_0393:
            str = str.Replace("'", "＇");
            if (0 != 0) goto Label_033D;
            str = str.Replace("《", "＜＜");
            if (0 == 0) goto Label_033D;
            goto Label_02F2;
        Label_03D6:
            str = str.Trim();
            str = str.Replace("&", "＠");
            str = str.Replace("<", "＜");
            str = str.Replace(">", "＞");
            goto Label_0393;
        }

        /// <summary>替字符串中不安全字符为大写</summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterStrA(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            goto Label_03BA;
        Label_00A6:
            str = str.Replace("ＦＯＲＭ", "FORM");
            goto Label_0161;
        Label_00BD:
            str = str.Replace("ＳＣＲＩＰＴ", "SCRIPT");
            str = str.Replace("ＦＯＲＭ", "form");
            if (0 == 0) goto Label_00A6;
            goto Label_0161;
        Label_00F5:
            str = str.Replace("ＦＲＡＭＥ", "FRAME");
            str = str.Replace("ＳＣＲＩＰＴ", "script");
            goto Label_00BD;
        Label_0161:
            if (0 == 0)
            {
                str = str.Replace("ＭＥＴＡ", "meta");
                if (-2147483648 != 0)
                {
                    if (3 == 0) goto Label_03C2;
                    str = str.Replace("ＭＥＴＡ", "META");
                    if (15 == 0) goto Label_02F6;
                    str = str.Replace("ＳＴＹＬＥ", "style");
                    str = str.Replace("ＳＴＹＬＥ", "STYLE");
                    str = str.Replace("ＢＥＨＡＶＩＯＲ", "behavior");
                    if (0 == 0) str = str.Replace("ＢＥＨＡＶＩＯＲ", "BEHAVIOR");
                }
                goto Label_0268;
            }
        Label_0164:
            str = str.Replace("ＲＥＮＡＭＥ", "rename");
            str = str.Replace("ＲＥＮＡＭＥ", "RENAME");
            str = str.Replace("ＡＬＥＲＴ", "alert");
            str = str.Replace("ＡＬＥＲＴ", "ALERT");
            str = str.Replace("ＣＡＳＴ", "cast");
            if (0 != 0) goto Label_00A6;
            str = str.Replace("ＣＡＳＴ", "CAST");
            if (2 == 0) goto Label_03E6;
            if (1 != 0)
            {
                str = str.Replace("ＦＲＡＭＥ", "frame");
                goto Label_00F5;
            }
            goto Label_00BD;
        Label_021E:
            str = str.Replace("ＬＩＫＥ", "like");
            str = str.Replace("ＬＩＫＥ", "LIKE");
            str = str.Replace("ＤＲＯＰ", "drop");
            str = str.Replace("ＤＲＯＰ", "DROP");
            str = str.Replace("ＣＲＥＡＴＥ", "create");
            if (0 != 0) goto Label_00A6;
            str = str.Replace("ＣＲＥＡＴＥ", "CREATE");
            if (0 != 0) goto Label_00F5;
            if (0 != 0) return str;
            str = str.Replace("ＭＯＤＩＦＹ", "modify");
            str = str.Replace("ＭＯＤＩＦＹ", "MODIFY");
            if (0 == 0) goto Label_0164;
        Label_0268:
            if (2 != 0)
            {
                if (15 != 0) return str;
                goto Label_03BA;
            }
            if (4 != 0) goto Label_0323;
        Label_02F6:
            str = str.Replace("ＷＨＥＲＥ", "where");
            str = str.Replace("ＷＨＥＲＥ", "WHERE");
            str = str.Replace("ＩＮＳＥＲＴ", "insert");
            str = str.Replace("ＩＮＳＥＲＴ", "INSERT");
            do
            {
                str = str.Replace("ＤＥＬＥＴＥ", "delete");
                str = str.Replace("ＤＥＬＥＴＥ", "DELETE");
                str = str.Replace("ＵＰＤＡＴＥ", "update");
                str = str.Replace("ＵＰＤＡＴＥ", "UPDATE");
            }
            while (0 != 0);
            if (4 != 0) goto Label_021E;
        Label_0323:
            str = str.Replace("ＳＥＬＥＣＴ", "select");
            str = str.Replace("ＳＥＬＥＣＴ", "SELECT");
            str = str.Replace("ＪＯＩＮ", "join");
            str = str.Replace("ＪＯＩＮ", "JOIN");
            str = str.Replace("ＵＮＩＯＮ", "union");
            str = str.Replace("ＵＮＩＯＮ", "UNION");
            if (0 == 0) goto Label_02F6;
            goto Label_021E;
        Label_03BA:
            str = str.Trim();
        Label_03C2:
            str = str.Replace("＠", "&");
            str = str.Replace("＜", "<");
        Label_03E6:
            str = str.Replace("＞", ">");
            str = str.Replace("＇", "'");
            str = str.Replace("＜＜", "《");
            str = str.Replace("＞＞", "》");
            goto Label_0323;
        }

        /// <summary>格式化字节数字符串</summary>
        /// <param name="bytes">字节数</param>
        /// <returns>格式化的结果</returns>
        public static string FormatBytesStr(int bytes)
        {
            double num;
            double num2;
            if (bytes <= 0x40000000)
            {
                if (bytes > 0x100000)
                {
                    num2 = bytes / 0x100000;
                    return (num2.ToString("0") + "M");
                }
            }
            else
            {
                num = bytes / 0x40000000;
                return (num.ToString("0") + "G");
            }
            do
            {
                if (bytes > 0x400)
                {
                    double num3 = bytes / 0x400;
                    return (num3.ToString("0") + "K");
                }
            }
            while ((((uint) num) & 0) != 0 && ((uint) num2) + ((uint) num) > uint.MaxValue);
            return (bytes.ToString() + "Bytes");
        }

        /// <summary>将GB2312编码字符串转为UTF8</summary>
        /// <param name="Gb2312Str">GB2312编码字符串</param>
        /// <returns></returns>
        public static string GB2312ToUTF8(string Gb2312Str)
        {
            string str2;
            try
            {
                Encoding dstEncoding = Encoding.UTF8;
                Encoding encoding = Encoding.GetEncoding("gb2312");
                byte[] bytes = encoding.GetBytes(Gb2312Str);
                byte[] buffer2 = Encoding.Convert(encoding, dstEncoding, bytes);
                string str = dstEncoding.GetString(buffer2);
                do
                {
                    str2 = str;
                }
                while (0 != 0);
            }
            catch (Exception)
            {
                str2 = null;
            }
            return str2;
        }

        /// <summary>获取指定字符串在指定字符串数组中的位置</summary>
        /// <param name="Str">字符串</param>
        /// <param name="StrArray">字符串数组</param>
        /// <param name="CaseAa">是否区分大小写：True为区分；False为不区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetArrayID(string Str, string[] StrArray, bool CaseAa)
        {
            int num = -1;
            int index = 0;
        Label_0007:
            if (index >= StrArray.Length) return num;
        Label_0012:
            while (CaseAa)
            {
                if (!(Str == StrArray[index])) goto Label_002A;
                num = index;
                if ((((uint) num) & 0) == 0) goto Label_002A;
                if (((uint) CaseAa) >= 0) break;
            }
        Label_0015:
            if (Str.ToLower() == StrArray[index].ToLower()) num = index;
        Label_002A:
            index++;
            if (((uint) num) + ((uint) CaseAa) >= 0)
            {
                if (0 == 0) goto Label_0007;
                if (0 != 0) goto Label_002A;
                if (((uint) CaseAa) + ((uint) CaseAa) <= uint.MaxValue) goto Label_0012;
            }
            goto Label_0015;
        }

        /// <summary>将指定字符串中的汉字转换为拼音首字母的缩写，其中非汉字保留为原字符[生成指定字符串的助记码]</summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetStrAToZ(string text)
        {
            char ch;
            byte[] bytes;
            char ch2;
            int num;
            string str;
            int num2;
            StringBuilder builder = new StringBuilder(text.Length);
            goto Label_046C;
        Label_0011:
            if (-2 != 0) goto Label_0021;
        Label_0018:
            if (num < 0xd7fa) goto Label_004C;
        Label_0021:
            builder.Append(ch);
            num2++;
        Label_002F:
            if (num2 < str.Length)
            {
                ch2 = str[num2];
                ch = ch2;
                bytes = Encoding.Default.GetBytes(new char[] { ch2 });
            }
            else
            {
                if (0 == 0)
                {
                    if (((uint) num2) - ((uint) num2) >= 0) return builder.ToString();
                    goto Label_046C;
                }
                goto Label_011D;
            }
        Label_0041:
            if (bytes.Length == 2) goto Label_044F;
            goto Label_0011;
        Label_004C:
            ch = 'z';
            if (((uint) num2) - ((uint) num) > uint.MaxValue) goto Label_00DB;
            if (((uint) num2) >= 0) goto Label_0021;
            goto Label_0011;
        Label_00AE:
            if (num >= 0xcef4)
            {
                while (num < 0xd1b9)
                {
                    ch = 'x';
                    goto Label_0021;
                }
                if ((((uint) num) & 0) == 0 && num >= 0xd4d1) goto Label_0018;
                ch = 'y';
            }
            else
                ch = 'w';
            goto Label_0021;
        Label_00DB:
            if (num < 0xcdda)
            {
                ch = 't';
                goto Label_0021;
            }
            goto Label_00AE;
        Label_011D:
            ch = 's';
            if (1 == 0)
            {
            }
            goto Label_0021;
        Label_012B:
            if (num < 0xc8f6)
            {
                ch = 'r';
                goto Label_0021;
            }
            if (((uint) num2) < 0) goto Label_0335;
            if (num < 0xcbfa) goto Label_011D;
            if ((((uint) num2) | 8) == 0) goto Label_03DB;
            goto Label_00DB;
        Label_0194:
            if (num >= 0xc6da)
            {
                if (num < 0xc8bb)
                {
                    ch = 'q';
                    goto Label_01F6;
                }
                if (0x7fffffff == 0) goto Label_00AE;
                goto Label_012B;
            }
        Label_01A6:
            ch = 'p';
            if (0 == 0) goto Label_0021;
        Label_01F6:
            if (((uint) num2) <= uint.MaxValue)
            {
                if (((uint) num2) >= 0) goto Label_0021;
                goto Label_0255;
            }
        Label_0208:
            ch = 'm';
            goto Label_0021;
        Label_0255:
            if (num < 0xc0ac)
                ch = 'k';
            else if (((uint) num) + ((uint) num2) >= 0 && num >= 0xc2e8)
            {
                if (num < 0xc4c3) goto Label_0208;
                if (0xff != 0)
                {
                Label_01DE:
                    if (num >= 0xc5b6)
                    {
                        while (num >= 0xc5be)
                        {
                            if (0 == 0) goto Label_0194;
                            if (((uint) num) > uint.MaxValue) goto Label_01DE;
                        }
                        ch = 'o';
                        goto Label_0021;
                    }
                }
                ch = 'n';
            }
            else
                ch = 'l';
            goto Label_0021;
        Label_0335:
            if (num < 0xb7a2)
            {
                ch = 'e';
                goto Label_0021;
            }
            if (num >= 0xb8c1)
            {
                if (num < 0xb9fe)
                {
                    ch = 'g';
                    goto Label_0021;
                }
                while (true)
                {
                    if (num < 0xbbf7)
                    {
                        ch = 'h';
                        goto Label_0021;
                    }
                    if (num < 0xbfa6)
                    {
                        ch = 'g';
                        goto Label_0021;
                    }
                    if (((uint) num) > uint.MaxValue) goto Label_0041;
                    if (0xff == 0) goto Label_004C;
                    if ((((uint) num2) & 0) == 0) goto Label_0255;
                    if (((uint) num) <= uint.MaxValue) goto Label_012B;
                    if (((uint) num2) - ((uint) num) <= uint.MaxValue) goto Label_0377;
                }
            }
            if (15 == 0) goto Label_011D;
            if (((uint) num2) >= 0)
            {
                ch = 'f';
                goto Label_0021;
            }
            goto Label_0335;
        Label_0377:
            if (((uint) num2) - ((uint) num2) >= 0) goto Label_0021;
        Label_03D6:
            ch = 'b';
            if ((((uint) num) & 0) == 0)
            {
                if ((((uint) num) | 0x7fffffff) != 0) goto Label_0021;
                goto Label_012B;
            }
            if (((uint) num) < 0) goto Label_0041;
            goto Label_043D;
        Label_03DB:
            if (num < 0xb0c5)
            {
                ch = 'a';
                goto Label_0021;
            }
            if (num >= 0xb2c1)
            {
                if (num >= 0xb4ee)
                {
                    if (num < 0xb6ea)
                    {
                        ch = 'd';
                        goto Label_0021;
                    }
                    goto Label_0335;
                }
                ch = 'c';
                if (0 != 0) goto Label_044F;
                if (((uint) num2) > uint.MaxValue) goto Label_0194;
                goto Label_0377;
            }
            goto Label_03D6;
        Label_043D:
            if (num < 0xb0a1)
            {
                ch = ch2;
                goto Label_0021;
            }
            if ((((uint) num) & 0) != 0) goto Label_01A6;
            goto Label_03DB;
        Label_044F:
            num = bytes[0] * 0x100 + bytes[1];
            goto Label_043D;
        Label_046C:
            str = text;
            num2 = 0;
            goto Label_002F;
        }

        /// <summary>返回字符串真实长度, 1个汉字长度为2</summary>
        /// <param name="Str">字符串</param>
        /// <returns>字符长度</returns>
        public static int GetStringLength(string Str) { return Encoding.Default.GetBytes(Str).Length; }

        /// <summary>判断指定字符串是否属于指定字符串数组中的一个元素</summary>
        /// <param name="Str">字符串</param>
        /// <param name="StrArray">字符串数组</param>
        /// <param name="CaseAa">是否区分大小写：True为区分，False为不区分</param>
        /// <returns>True或False</returns>
        public static bool IsInArray(string Str, string[] StrArray, bool CaseAa) { return GetArrayID(Str, StrArray, CaseAa) >= 0; }

        /// <summary>判断指定字符串是否属于内部以逗号分割单词的字符串的一个元素</summary>
        /// <param name="Str">字符串</param>
        /// <param name="ArrayStr">内部以分隔符分割单词的字符串</param>
        /// <param name="StrSplit">字符串分隔符</param>
        /// <param name="CaseAa">是否区分大小写：True为区分，False为不区分</param>
        /// <returns>True或False</returns>
        public static bool IsInArray(string Str, string ArrayStr, string StrSplit, bool CaseAa) { return GetArrayID(Str, Split(ArrayStr, StrSplit), CaseAa) >= 0; }

        /// <summary>判断输入的字符是不是全为数字</summary>
        /// <param name="Str">要判断的字符串</param>
        /// <returns>是否为字符：True或False</returns>
        public static bool IsNum(string Str)
        {
            string str;
            int num;
            bool flag = true;
        Label_00B7:
            while (Str == "")
            {
                return false;
            }
            if (((uint) flag) + ((uint) num) <= uint.MaxValue)
            {
                if (((uint) flag) - ((uint) num) < 0) goto Label_000F;
                str = Str;
                num = 0;
                if (4 != 0) goto Label_0045;
                goto Label_00B7;
            }
            goto Label_0057;
        Label_000F:
            if (int.Parse(Str) == 0) return false;
            if ((((uint) num) | 2) != 0) return flag;
            if (((uint) flag) <= uint.MaxValue) goto Label_0057;
        Label_0041:
            num++;
        Label_0045:
            if (num < str.Length)
            {
                char c = str[num];
                if (char.IsNumber(c)) goto Label_0041;
                flag = false;
            }
            if (!flag) return flag;
            goto Label_000F;
        Label_0057:
            if (((uint) num) < 0) return flag;
            goto Label_0041;
        }

        /// <summary>检查一个字符串是否可以转化为日期，一般用于验证用户输入日期的合法性。</summary>
        /// <param name="_value">需验证的字符串。</param>
        /// <returns>是否可以转化为日期的bool值。</returns>
        public static bool IsStringDate(string _value)
        {
            try
            {
                DateTime.Parse(_value);
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }

        /// <summary>删除字符串中所有HTML标记</summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoHTML(string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            goto Label_0174;
        Label_0071:
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            if (3 == 0) goto Label_01AD;
            Htmlstring.Replace("&", "＆");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            if (0x7fffffff != 0) return Htmlstring;
        Label_0174:
            Htmlstring = Regex.Replace(Htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "-->", "", RegexOptions.IgnoreCase);
        Label_01AD:
            Htmlstring = Regex.Replace(Htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            if (0 != 0) goto Label_0071;
            Htmlstring = Regex.Replace(Htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
        Label_0100:
            Htmlstring = Regex.Replace(Htmlstring, "&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            if (0 == 0)
            {
                Htmlstring = Regex.Replace(Htmlstring, "&(iexcl|#161);", "\x00a1", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(cent|#162);", "\x00a2", RegexOptions.IgnoreCase);
                if (15 == 0) goto Label_0100;
                Htmlstring = Regex.Replace(Htmlstring, "&(pound|#163);", "\x00a3", RegexOptions.IgnoreCase);
                Htmlstring = Regex.Replace(Htmlstring, "&(copy|#169);", "\x00a9", RegexOptions.IgnoreCase);
                goto Label_0071;
            }
            goto Label_0174;
        }

        /// <summary>过滤所有HTML标记</summary>
        /// <param name="content">要过滤的内容</param>
        /// <param name="TagType">过滤类型：空或null则过滤全部HTML标记,DIV则过滤DIV和SPAN标记</param>
        /// <returns></returns>
        public static string RemoveHtmlTag(string content, string TagType)
        {
            if (string.IsNullOrEmpty(TagType.ToUpper()))
            {
                content = Regex.Replace(content, "</?[^>]*>", "");
                return content;
            }
            if (TagType.ToUpper() != "DIV")
            {
                content = Regex.Replace(content, "</?[^>]*>", "");
                if (0x7fffffff != 0)
                {
                }
                return content;
            }
            content = Regex.Replace(content, "</?(div|span)[^>]*>", "");
            if (15 == 0)
            {
            }
            return content;
        }

        /// <summary>过滤HTML中的不安全标签</summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RemoveUnsafeHtml(string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }

        /// <summary>以指定的ContentType输出指定文件文件</summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="filename">输出的文件名</param>
        /// <param name="filetype">将文件输出时设置的ContentType</param>
        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream stream = null;
            byte[] buffer = new byte[0x2710];
            try
            {
                int num;
                long num2;
                stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if (0 == 0) goto Label_00F0;
            Label_0098:
                while (0 != 0)
                {
                    if (((uint) num) - ((uint) num2) <= uint.MaxValue) goto Label_004E;
                Label_003A:
                    if (HttpContext.Current.Response.IsClientConnected) goto Label_00E0;
                Label_004E:
                    num2 = -1;
                Label_0051:
                    if (num2 > 0) goto Label_003A;
                    if (((uint) num2) + ((uint) num2) <= uint.MaxValue) goto Label_0080;
                Label_006E:
                    buffer = new byte[0x2710];
                    num2 -= num;
                    goto Label_0051;
                Label_0080:
                    if (((uint) num2) - ((uint) num2) >= 0) goto Label_00C6;
                }
                HttpContext.Current.Response.OutputStream.Write(buffer, 0, num);
                HttpContext.Current.Response.Flush();
                goto Label_006E;
            Label_00C6:
                if (((uint) num) - ((uint) num) <= uint.MaxValue) goto Label_017B;
                goto Label_00F0;
            Label_00E0:
                num = stream.Read(buffer, 0, 0x2710);
                goto Label_0098;
            Label_00F0:
                num2 = stream.Length;
                HttpContext.Current.Response.ContentType = filetype;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + EncyptHelper.UrlEncode(filename.Trim()).Replace("+", " "));
                goto Label_0051;
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("Error : " + exception.Message);
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        Label_017B:
            HttpContext.Current.Response.End();
        }

        /// <summary>删除字符串尾部的回车/换行/空格</summary>
        /// <param name="str">要删除的字符串</param>
        /// <returns></returns>
        public static string RTrim(string str)
        {
            char ch2;
            char ch3;
            int length = str.Length;
            if ((((uint) length) | 15) == 0) goto Label_0081;
        Label_0027:
            if (length >= 0)
            {
                char ch = str[length];
                if (!ch.Equals(" "))
                {
                    ch2 = str[length];
                    goto Label_0059;
                }
                if (((uint) length) - ((uint) length) > uint.MaxValue) goto Label_0059;
            }
            else if (0 == 0) return str;
            goto Label_0081;
        Label_003D:
            if (ch3.Equals("\n")) goto Label_0081;
            if (0 != 0) return str;
        Label_0051:
            length--;
            goto Label_0027;
        Label_0059:
            if (!ch2.Equals("\r"))
            {
                ch3 = str[length];
                goto Label_003D;
            }
        Label_0081:
            str.Remove(length, 1);
            if (15 != 0) goto Label_0051;
            goto Label_003D;
        }

        /// <summary>分割字符串<param name="strContent">要分割的字符串</param><param name="strSplit">分隔符</param></summary>
        public static string[] Split(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0) return new string[] { strContent };
            return Regex.Split(strContent, strSplit.Replace(".", @"\."), RegexOptions.IgnoreCase);
        }

        /// <summary>替换回车换行符为html换行符</summary>
        public static string StrFormat(string str)
        {
            if (str == null) return "";
            str = str.Replace("\r\n", "<br />");
            str = str.Replace("\n", "<br />");
            string str2 = str;
            if (0 == 0)
            {
            }
            return str2;
        }

        /// <summary>替换内容中特殊字符为全角</summary>
        /// <param name="str">要替换的字符</param>
        /// <returns>替换后的结果字符串</returns>
        public static string t(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace("'", "‘");
                str = str.Replace(";", "；");
                str = str.Replace(",", "，");
                if (0 == 0) str = str.Replace("?", "？");
            }
            else
                return str;
            str = str.Replace("<", "＜");
            str = str.Replace(">", "＞");
            str = str.Replace("(", "(");
            str = str.Replace(")", ")");
            str = str.Replace("@", "＠");
            str = str.Replace("=", "＝");
            do
            {
                str = str.Replace("+", "＋");
                str = str.Replace("*", "＊");
            }
            while (0 != 0);
            str = str.Replace("&", "＆");
            str = str.Replace("#", "＃");
            if (1 != 0)
            {
                str = str.Replace("%", "％");
                str = str.Replace("$", "￥");
                return str;
            }
            return str;
        }

        /// <summary>将字符串转换为Color</summary>
        /// <param name="color">字符串颜色：#000000</param>
        /// <returns></returns>
        public static Color ToColor(string color)
        {
            int num;
            int num2;
            char[] chArray;
            int blue = 0;
            if (((uint) num2) <= uint.MaxValue) goto Label_018F;
            goto Label_00DA;
        Label_006F:
            num2 = Convert.ToInt32(chArray[2].ToString() + chArray[3].ToString(), 0x10);
            blue = Convert.ToInt32(chArray[4].ToString() + chArray[5].ToString(), 0x10);
            return Color.FromArgb(num, num2, blue);
        Label_00DA:
            num2 = Convert.ToInt32(chArray[1].ToString() + chArray[1].ToString(), 0x10);
            blue = Convert.ToInt32(chArray[2].ToString() + chArray[2].ToString(), 0x10);
            return Color.FromArgb(num, num2, blue);
        Label_018F:;
            color = color.TrimStart(new char[] { '#' });
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            int length = color.Length;
            if (((uint) num2) - ((uint) blue) < 0 || length != 3)
            {
                if (length != 6) return Color.FromName(color);
                chArray = color.ToCharArray();
                num = Convert.ToInt32(chArray[0].ToString() + chArray[1].ToString(), 0x10);
                goto Label_006F;
            }
            chArray = color.ToCharArray();
            if ((((uint) num2) | 0xfffffffe) != 0 && (((uint) blue) & 0) != 0) goto Label_006F;
            num = Convert.ToInt32(chArray[0].ToString() + chArray[0].ToString(), 0x10);
            if ((((uint) length) | 4) != 0) goto Label_00DA;
            goto Label_018F;
        }

        /// <summary>转半角的函数(SBC case)</summary>
        /// <param name="input">要转换的全角</param>
        /// <returns>转换后的半角</returns>
        public static string ToDBC(string input)
        {
            int num;
            char[] chArray = input.ToCharArray();
            goto Label_00A8;
        Label_0022:
            num++;
        Label_0026:
            do
            {
                if (num < chArray.Length) goto Label_0047;
                if (15 != 0)
                {
                    if (((uint) num) + ((uint) num) <= uint.MaxValue) return new string(chArray);
                    goto Label_00A8;
                }
            }
            while (0 != 0);
        Label_0036:
            chArray[num] = (char) (chArray[num] - 0xfee0);
            goto Label_0022;
        Label_0047:
            if (chArray[num] != '　')
            {
                if ((((uint) num) - ((uint) num) < 0 || chArray[num] > 0xff00) && chArray[num] < 0xff5f) goto Label_0036;
                goto Label_0022;
            }
        Label_009E:
            chArray[num] = ' ';
            goto Label_0022;
        Label_00A8:
            if (1 == 0)
            {
                if (((uint) num) >= 0) goto Label_0047;
                goto Label_009E;
            }
            num = 0;
            goto Label_0026;
        }

        /// <summary>半角转换为全角</summary>
        /// <param name="input">要转换的半角字符串</param>
        /// <returns>转换后的全角字符串</returns>
        public static string ToSBC(string input)
        {
            int num;
            char[] chArray = input.ToCharArray();
        Label_0048:
            num = 0;
        Label_0019:
            if (num >= chArray.Length)
            {
                if (3 != 0) return new string(chArray);
            }
            else
            {
                if (chArray[num] != ' ')
                {
                    do
                    {
                        if (chArray[num] < '\x007f')
                        {
                            chArray[num] = (char) (chArray[num] + 0xfee0);
                            break;
                        }
                    }
                    while (0 != 0);
                }
                else
                    chArray[num] = '　';
                num++;
                goto Label_0019;
            }
            goto Label_0048;
        }

        /// <summary>转换为简体中文</summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns></returns>
        public static string ToSChinese(string str) { return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0); }

        /// <summary>转换为繁体中文</summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns></returns>
        public static string ToTChinese(string str) { return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0); }

        /// <summary>将UTF-８字符串转为GB2312</summary>
        /// <param name="Utf8Str">Utf8编码字符串</param>
        /// <returns></returns>
        public static string UTF8ToGB2312(string Utf8Str)
        {
            Encoding encoding;
            Encoding encoding2;
            byte[] buffer2;
            char[] chArray;
            string str = string.Empty;
            if (0 == 0) goto Label_0029;
        Label_0009:
            encoding2.GetChars(buffer2, 0, buffer2.Length, chArray, 0);
        Label_001A:
            str = new string(chArray);
            if (-2147483648 != 0) return str;
        Label_0029:
            encoding = Encoding.UTF8;
            encoding2 = Encoding.GetEncoding("gb2312");
            byte[] bytes = encoding.GetBytes(Utf8Str);
            buffer2 = Encoding.Convert(encoding, encoding2, bytes);
            chArray = new char[encoding2.GetCharCount(buffer2, 0, buffer2.Length)];
            if (-1 == 0) goto Label_001A;
            goto Label_0009;
        }

        /// <summary>生成指定位数的随机数字或字符串</summary>
        /// <param name="DataString">自定义随机字符串范围</param>
        /// <param name="RanLength">长度</param>
        /// <param name="Session">是否要将返回结果写入到SESSION</param>
        /// <returns></returns>
        public static string Verify(string DataString, int RanLength, bool Session)
        {
            string str;
            string str2;
            if (!string.IsNullOrEmpty(DataString))
                str = DataString.ToUpper();
            else
                str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            do
            {
                Random random;
                int num;
                do
                {
                    str2 = "";
                    random = new Random();
                    num = 1;
                }
                while (((uint) num) - ((uint) num) > uint.MaxValue);
                while (num <= RanLength)
                {
                    str2 = str2 + str[random.Next(str.Length)];
                    if ((((uint) RanLength) | 3) == 0) return str2;
                    num++;
                }
                while (Session)
                {
                    HttpContext.Current.Session["verify"] = str2;
                    return str2;
                }
            }
            while (0 != 0);
            return str2;
        }
    }
}
