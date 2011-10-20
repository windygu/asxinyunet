namespace Utils
{
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary><para>　</para>
    /// 类名：常用工具类——根据IP地址查询所在地区[纯真数据库]
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>---------------------------------------------------------------------------------</para><para>　使用方法：</para><para>　１、将纯真数据库QQwry.dat放入站点目录中，一般为Bin目录</para><para>　２、Utils.QQWryIpHelper.QQWryLocator Wry = new QQWryIpHelper.QQWryLocator("bin\\qqwry.dat");</para><para>　３、Utils.QQWryIpHelper.IPLocation ip = Wry.Query("202.96.134.133");</para><para>　４、获取地区：ip.Country</para></summary>
    public class QQWryIpHelper
    {
        private static Regex x075006648c378b9f = new Regex(@"(((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{2})|(2[0-4]\d)|(25[0-5]))");
        private static long x3be253ea2a6b5408;
        private static byte[] x4a3f0a05c02f235f;
        private static long xa38e3cb64df45358;
        private static long xea1510873fc4e6a9;

        /// <summary>根据IP获取城市名称，不含“市”</summary>
        /// <param name="QQWryFilePath"></param>
        /// <param name="SearchIP"></param>
        /// <returns></returns>
        public static string GetCityNameByIP(string QQWryFilePath, string SearchIP)
        {
            string str = "";
            string strContent = "北京,天津,上海,重庆";
            string str3 = "内蒙古,宁夏,新疆,西藏,广西";
            string oldValue = "";
            try
            {
                string str5;
                string[] strArray;
                int num;
                int num2;
                int index;
                IPLocation countryAddress = GetCountryAddress(QQWryFilePath, SearchIP);
                goto Label_01C5;
            Label_0026:
                str = str5.Substring(num2 + 1, str5.IndexOf("州") - num2 - 1);
                goto Label_0059;
            Label_0045:
                if (str5.IndexOf("州") > 0) goto Label_0026;
                return str;
            Label_0059:
                if (((uint) index) + ((uint) num2) < 0) goto Label_0045;
                if (((uint) index) < 0) goto Label_012C;
                if ((((uint) num) | 15) != 0) return str;
                goto Label_0115;
            Label_00AB:
                if (index > 0) return str5.Substring(num2 + 1, index - num2 - 1);
                goto Label_0045;
            Label_00B2:
                num2 = str5.IndexOf("省");
                index = str5.IndexOf("市");
                goto Label_00AB;
            Label_00E5:
                num++;
                if (((uint) index) + ((uint) num) > uint.MaxValue) return oldValue;
            Label_0106:
                if (num < strArray.Length) goto Label_015C;
                goto Label_00B2;
            Label_0115:
                str5 = str5.Replace(oldValue, oldValue + "省");
                goto Label_00E5;
            Label_012C:
                if (str5.Substring(0, 2) == oldValue) goto Label_0115;
                if (((uint) index) + ((uint) num) < 0) goto Label_0106;
                goto Label_00E5;
            Label_015C:
                oldValue = strArray[num];
                goto Label_012C;
            Label_0164:
                if (((uint) num) + ((uint) index) > uint.MaxValue) goto Label_015C;
                goto Label_0106;
            Label_0185:
                if (StringHelper.IsInArray(oldValue, StringHelper.Split(strContent, ","), false)) return oldValue;
                strArray = StringHelper.Split(str3, ",");
                num = 0;
                if (((uint) num2) + ((uint) index) >= 0) goto Label_0164;
                goto Label_015C;
            Label_01C5:
                str5 = countryAddress.Country;
                oldValue = str5.Substring(0, 2);
            }
            catch (Exception)
            {
            }
            goto Label_0185;
        }

        /// <summary>直接用库文件和IP地址查询</summary>
        /// <param name="QQWryFilePath">QQWry.dat文件相对于站点根目录的路径，如："\\QQWry.dat"</param>
        /// <param name="SearchIP">要查询的IP地址</param>
        /// <returns></returns>
        public static IPLocation GetCountryAddress(string QQWryFilePath, string SearchIP)
        {
            x93f3fdbfba63bfb8 xffdbfbabfb = new x93f3fdbfba63bfb8(QQWryFilePath);
            return xffdbfbabfb.x02b56011810c316c(SearchIP);
        }

        /// <summary>IP地址信息实体，记录IP地址、所在城市、位置信息</summary>
        public class IPLocation
        {
            [CompilerGenerated]
            private string x0341b00e3ee5fca1;
            [CompilerGenerated]
            private string x56b117ba44bf02a4;
            [CompilerGenerated]
            private string x739f7959088a1458;

            /// <summary>所在城市</summary>
            public string Country { [CompilerGenerated]
            get { return this.x739f7959088a1458; } [CompilerGenerated]
            set { this.x739f7959088a1458 = value; } }

            /// <summary>IP地址</summary>
            public string IP { [CompilerGenerated]
            get { return this.x0341b00e3ee5fca1; } [CompilerGenerated]
            set { this.x0341b00e3ee5fca1 = value; } }

            /// <summary>位置</summary>
            public string Local { [CompilerGenerated]
            get { return this.x56b117ba44bf02a4; } [CompilerGenerated]
            set { this.x56b117ba44bf02a4 = value; } }
        }

        internal class x93f3fdbfba63bfb8
        {
            internal x93f3fdbfba63bfb8(string dataPath)
            {
                if (3 != 0)
                {
                    if (8 != 0)
                    {
                    }
                    string filename = NetWorkHelper.GetServerPhysicalPath() + @"\" + dataPath;
                    if (!FilesHelper.FileExists(filename))
                        HttpContext.Current.Response.Write("<div style='color:red;font-size:14px;text-align:center'>读取纯真IP数据库文件失败！</div>");
                    else
                    {
                        using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            QQWryIpHelper.x4a3f0a05c02f235f = new byte[stream.Length];
                            stream.Read(QQWryIpHelper.x4a3f0a05c02f235f, 0, QQWryIpHelper.x4a3f0a05c02f235f.Length);
                        }
                        byte[] destinationArray = new byte[8];
                        Array.Copy(QQWryIpHelper.x4a3f0a05c02f235f, 0, destinationArray, 0, 8);
                        if (2 != 0)
                        {
                            QQWryIpHelper.xa38e3cb64df45358 = destinationArray[0] + destinationArray[1] * 0x100 + destinationArray[2] * 0x100 * 0x100 + destinationArray[3] * 0x100 * 0x100 * 0x100;
                            QQWryIpHelper.xea1510873fc4e6a9 = destinationArray[4] + destinationArray[5] * 0x100 + destinationArray[6] * 0x100 * 0x100 + destinationArray[7] * 0x100 * 0x100 * 0x100;
                            QQWryIpHelper.x3be253ea2a6b5408 = Convert.ToInt64((double) (((double) (QQWryIpHelper.xea1510873fc4e6a9 - QQWryIpHelper.xa38e3cb64df45358)) / 7.0));
                            if (15 == 0 || QQWryIpHelper.x3be253ea2a6b5408 <= 1) throw new ArgumentException("读取纯真IP数据库文件失败！");
                        }
                    }
                }
            }

            private static long x01dc5fc82d6a9f0f(string xfe29e86a213b6ed3)
            {
                char[] chArray;
                string[] strArray;
                long num;
                long num3;
                char[] chArray2 = new char[1];
                if (((uint) num3) + ((uint) num3) <= uint.MaxValue) goto Label_00C1;
            Label_0023:
                num = long.Parse(strArray[0]) * 0x100 * 0x100 * 0x100;
                long num2 = long.Parse(strArray[1]) * 0x100 * 0x100;
                num3 = long.Parse(strArray[2]) * 0x100;
                long num4 = long.Parse(strArray[3]);
                if (((uint) num4) + ((uint) num3) <= uint.MaxValue) return num + num2 + num3 + num4;
                goto Label_00C1;
            Label_0090:
                strArray = xfe29e86a213b6ed3.Split(chArray);
                goto Label_0023;
            Label_00C1:
                chArray2[0] = '.';
                chArray = chArray2;
                if (xfe29e86a213b6ed3.Split(chArray).Length == 3)
                {
                    xfe29e86a213b6ed3 = xfe29e86a213b6ed3 + ".0";
                    if (((uint) num2) < 0) goto Label_00C1;
                }
                else
                    goto Label_0090;
                if ((((uint) num2) & 0) != 0) goto Label_0023;
                goto Label_0090;
            }

            internal QQWryIpHelper.IPLocation x02b56011810c316c(string xfe29e86a213b6ed3)
            {
                QQWryIpHelper.IPLocation location = null;
                try
                {
                    long num;
                    long num2;
                    long num3;
                    long num4;
                    long num5;
                    long num6;
                    long num7;
                    int num8;
                    string str;
                    QQWryIpHelper.IPLocation location2;
                    if (QQWryIpHelper.x075006648c378b9f.Match(xfe29e86a213b6ed3).Success) goto Label_0366;
                    if (((uint) num7) >= 0) goto Label_0346;
                    if (((uint) num3) + ((uint) num5) > uint.MaxValue)
                    {
                    }
                    goto Label_0089;
                Label_004E:
                    if (num7 >= num) goto Label_006B;
                Label_0053:
                    location.Country = "未知";
                    location.Local = "";
                    goto Label_015C;
                Label_006B:
                    location.Country = this.x0c752800080444ee(num6, num8, out str);
                    location.Local = str;
                    return location;
                Label_0089:
                    if (num3 < num2 - 1) goto Label_010A;
                Label_0093:
                    num5 = this.x12530b37729c2dec(num3, out num6);
                    num7 = this.x6c23ebba535c4bd8(num6, out num8);
                    if (num5 > num) goto Label_0053;
                    if (((uint) num8) - ((uint) num3) <= uint.MaxValue) goto Label_004E;
                    if ((((uint) num6) | 8) == 0) return location;
                    goto Label_006B;
                Label_00EF:
                    if (num > num5)
                    {
                        num3 = num4;
                        goto Label_0089;
                    }
                    num2 = num4;
                    goto Label_0141;
                Label_00FE:
                    num3 = num4;
                    goto Label_0093;
                Label_010A:
                    num4 = (num2 + num3) / 2;
                    num5 = this.x12530b37729c2dec(num4, out num6);
                    if (num != num5) goto Label_00EF;
                    if (((uint) num8) - ((uint) num4) > uint.MaxValue) goto Label_0305;
                    if (0 == 0) goto Label_00FE;
                Label_0141:
                    if (((uint) num) + ((uint) num3) >= 0) goto Label_0089;
                Label_015C:
                    if ((((uint) num7) | uint.MaxValue) != 0) return location;
                    if ((((uint) num4) | 1) != 0) goto Label_0346;
                Label_0192:
                    num7 = 0;
                    num8 = 0;
                    goto Label_0089;
                Label_019E:
                    num6 = 0;
                    if (((uint) num) > uint.MaxValue) goto Label_02C6;
                    if (((uint) num4) >= 0) goto Label_0192;
                    goto Label_0237;
                Label_01CE:
                    if (((uint) num7) + ((uint) num3) < 0) goto Label_02B4;
                Label_01E9:
                    num2 = QQWryIpHelper.x3be253ea2a6b5408;
                    num3 = 0;
                    num4 = 0;
                    num5 = 0;
                    if (((uint) num4) + ((uint) num7) >= 0) goto Label_019E;
                    goto Label_01E9;
                Label_0214:
                    if (num <= x01dc5fc82d6a9f0f("60.255.255.255")) goto Label_0237;
                    goto Label_01CE;
                Label_0227:
                    if (num > x01dc5fc82d6a9f0f("126.255.255.255")) goto Label_0291;
                Label_0237:
                    location.Country = "网络保留地址";
                    location.Local = "";
                    goto Label_01E9;
                Label_0259:
                    if ((((uint) num6) | 0xfffffffe) != 0) goto Label_0214;
                Label_0271:
                    if (((uint) num3) - ((uint) num4) < 0) goto Label_032A;
                    goto Label_0237;
                Label_0291:
                    if (num < x01dc5fc82d6a9f0f("58.0.0.0")) goto Label_01E9;
                    goto Label_02FC;
                Label_02A3:
                    if (num >= x01dc5fc82d6a9f0f("0.0.0.0")) goto Label_02D5;
                Label_02B4:
                    if (num >= x01dc5fc82d6a9f0f("64.0.0.0")) goto Label_0227;
                    goto Label_02E7;
                Label_02C6:
                    if (num <= x01dc5fc82d6a9f0f("127.255.255.255")) goto Label_0305;
                    goto Label_02A3;
                Label_02D5:
                    if (num <= x01dc5fc82d6a9f0f("2.255.255.255")) goto Label_0237;
                    goto Label_02B4;
                Label_02E7:
                    if (((uint) num6) <= uint.MaxValue) goto Label_0291;
                Label_02FC:;
                    goto Label_0259;
                Label_0305:
                    location.Country = "本机内部环回地址";
                    location.Local = "";
                    goto Label_01E9;
                Label_032A:
                    num = x01dc5fc82d6a9f0f(xfe29e86a213b6ed3);
                    if (num < x01dc5fc82d6a9f0f("127.0.0.1")) goto Label_02A3;
                    goto Label_02C6;
                Label_0346:
                    throw new ArgumentException("IP格式错误");
                    if (((uint) num3) > uint.MaxValue) goto Label_02A3;
                Label_0366:
                    location2 = new QQWryIpHelper.IPLocation();
                    location2.IP = xfe29e86a213b6ed3;
                    location = location2;
                    if (((uint) num5) - ((uint) num6) < 0) goto Label_0271;
                    if ((((uint) num7) | 1) != 0) goto Label_032A;
                }
                catch (Exception)
                {
                }
                goto Label_0305;
            }

            private static string x0a96e0823923e6f2(long x1532616ca9c582e2)
            {
                long num2;
                long num3;
                long num4;
                string[] strArray;
                long num = (long) ((x1532616ca9c582e2 & 0xff000000L) >> 0x18);
                goto Label_01CF;
            Label_002A:
                strArray[2] = num2.ToString();
                strArray[3] = ".";
                strArray[4] = num3.ToString();
                if (((uint) num3) - ((uint) num4) < 0) goto Label_0081;
                if (((uint) x1532616ca9c582e2) - ((uint) num3) >= 0)
                {
                    if (((uint) num3) >= 0)
                    {
                        strArray[5] = ".";
                        strArray[6] = num4.ToString();
                    }
                    if ((((uint) num) | 0xff) != 0) return string.Concat(strArray);
                    goto Label_01CF;
                }
            Label_0079:
                strArray = new string[7];
            Label_0081:
                strArray[0] = num.ToString();
                strArray[1] = ".";
                goto Label_002A;
            Label_00CC:
                num4 += 0x100;
                if (((uint) num4) <= uint.MaxValue) goto Label_0079;
            Label_00E7:
                if (num4 < 0) goto Label_00CC;
                goto Label_0079;
            Label_01CF:
                if (num < 0) num += 0x100;
                num2 = (x1532616ca9c582e2 & 0xff0000) >> 0x10;
            Label_0184:
                while (num2 < 0)
                {
                    num2 += 0x100;
                    if (((uint) num) + ((uint) num4) >= 0)
                    {
                        do
                        {
                            if ((((uint) num) & 0) != 0) goto Label_0184;
                            if (((uint) num3) + ((uint) num3) < 0) goto Label_00CC;
                        }
                        while ((((uint) num2) & 0) != 0);
                        break;
                    }
                }
                num3 = (x1532616ca9c582e2 & 0xff00) >> 8;
                if (((uint) x1532616ca9c582e2) - ((uint) num2) > uint.MaxValue) goto Label_002A;
                if (num3 < 0) num3 += 0x100;
                num4 = x1532616ca9c582e2 & 0xff;
                if (((uint) num4) - ((uint) num4) <= uint.MaxValue) goto Label_00E7;
                if (((uint) num) <= uint.MaxValue) goto Label_00CC;
                goto Label_0079;
            }

            private string x0c752800080444ee(long xca0ba530311e7257, int x8b5968630d21f195, out string x7342d8d7af6bfa3c)
            {
                long num;
                int num2;
                string str = "";
                if (((uint) num2) + ((uint) num) >= 0) goto Label_00C9;
            Label_0091:
                switch (x8b5968630d21f195)
                {
                    case 1:
                    case 2:
                        str = this.x3628b841ba8dea6b(ref num, ref x8b5968630d21f195, ref xca0ba530311e7257);
                        num = xca0ba530311e7257 + 8;
                        x7342d8d7af6bfa3c = (1 == x8b5968630d21f195) ? "" : this.x3628b841ba8dea6b(ref num, ref x8b5968630d21f195, ref xca0ba530311e7257);
                        return str;

                    default:
                        str = this.x3628b841ba8dea6b(ref num, ref x8b5968630d21f195, ref xca0ba530311e7257);
                        x7342d8d7af6bfa3c = this.x3628b841ba8dea6b(ref num, ref x8b5968630d21f195, ref xca0ba530311e7257);
                        if (((uint) x8b5968630d21f195) + ((uint) x8b5968630d21f195) < 0) return str;
                        if (((uint) x8b5968630d21f195) - ((uint) x8b5968630d21f195) <= uint.MaxValue)
                        {
                            if (((uint) xca0ba530311e7257) <= uint.MaxValue) return str;
                            goto Label_00C9;
                        }
                        goto Label_0091;
                }
            Label_00C9:
                num = xca0ba530311e7257 + 4;
                goto Label_0091;
            }

            private long x12530b37729c2dec(long xa447fc54e41dfe06, out long xca0ba530311e7257)
            {
                long sourceIndex = QQWryIpHelper.xa38e3cb64df45358 + xa447fc54e41dfe06 * 7;
                byte[] destinationArray = new byte[7];
                Array.Copy(QQWryIpHelper.x4a3f0a05c02f235f, sourceIndex, destinationArray, 0, 7);
                xca0ba530311e7257 = Convert.ToInt64(destinationArray[4].ToString()) + Convert.ToInt64(destinationArray[5].ToString()) * 0x100 + Convert.ToInt64(destinationArray[6].ToString()) * 0x100 * 0x100;
                return Convert.ToInt64(destinationArray[0].ToString()) + Convert.ToInt64(destinationArray[1].ToString()) * 0x100 + Convert.ToInt64(destinationArray[2].ToString()) * 0x100 * 0x100 + Convert.ToInt64(destinationArray[3].ToString()) * 0x100 * 0x100 * 0x100;
            }

            private string x3628b841ba8dea6b(ref long x374ea4fe62468d0f, ref int x8b5968630d21f195, ref long xca0ba530311e7257)
            {
                long num2;
                int num = 0;
                byte[] destinationArray = new byte[3];
                goto Label_00C6;
            Label_008F:
                num2 += 3;
                if (num == 2)
                {
                    x8b5968630d21f195 = 2;
                    xca0ba530311e7257 = x374ea4fe62468d0f - 4;
                    if (0 != 0) goto Label_00AD;
                }
                x374ea4fe62468d0f = Convert.ToInt64(destinationArray[0].ToString()) + Convert.ToInt64(destinationArray[1].ToString()) * 0x100 + Convert.ToInt64(destinationArray[2].ToString()) * 0x100 * 0x100;
                goto Label_00C6;
            Label_00AD:
                Array.Copy(QQWryIpHelper.x4a3f0a05c02f235f, num2, destinationArray, 0, 3);
                goto Label_008F;
            Label_00C6:
                num2 = x374ea4fe62468d0f;
                num2++;
                num = QQWryIpHelper.x4a3f0a05c02f235f[(int) ((IntPtr) num2)];
                if ((((uint) num) | 0xfffffffe) != 0 && ((uint) num) + ((uint) num) <= uint.MaxValue)
                {
                    if (num == 1 || num == 2) goto Label_00AD;
                    if (((uint) num) - ((uint) num2) <= uint.MaxValue && x374ea4fe62468d0f >= 12) return this.x9026a66a4156aae1(ref x374ea4fe62468d0f);
                    return "";
                }
                goto Label_008F;
            }

            private long x6c23ebba535c4bd8(long xca0ba530311e7257, out int x8b5968630d21f195)
            {
                byte[] destinationArray = new byte[5];
                Array.Copy(QQWryIpHelper.x4a3f0a05c02f235f, xca0ba530311e7257, destinationArray, 0, 5);
                x8b5968630d21f195 = destinationArray[4];
                return Convert.ToInt64(destinationArray[0].ToString()) + Convert.ToInt64(destinationArray[1].ToString()) * 0x100 + Convert.ToInt64(destinationArray[2].ToString()) * 0x100 * 0x100 + Convert.ToInt64(destinationArray[3].ToString()) * 0x100 * 0x100 * 0x100;
            }

            private string x9026a66a4156aae1(ref long x374ea4fe62468d0f)
            {
                byte num2;
                StringBuilder builder;
                byte[] buffer;
                Encoding encoding;
                long num3;
                long num4;
                byte num = 0;
                goto Label_00DD;
            Label_0053:
                if (num2 - ((uint) num4) <= uint.MaxValue)
                {
                    x374ea4fe62468d0f = (num4 = x374ea4fe62468d0f) + 1;
                    num2 = QQWryIpHelper.x4a3f0a05c02f235f[(int) ((IntPtr) num4)];
                    buffer[0] = num;
                    buffer[1] = num2;
                    if (num2 != 0)
                    {
                        builder.Append(encoding.GetString(buffer));
                        goto Label_0094;
                    }
                    if (((uint) num4) + num >= 0) return builder.ToString();
                }
                goto Label_00DD;
            Label_0094:
                x374ea4fe62468d0f = (num3 = x374ea4fe62468d0f) + 1;
                num = QQWryIpHelper.x4a3f0a05c02f235f[(int) ((IntPtr) num3)];
                if (num == 0) return builder.ToString();
                if (num <= 0x7f)
                {
                    builder.Append((char) num);
                    goto Label_0094;
                }
                goto Label_0053;
            Label_00DD:
                num2 = 0;
                builder = new StringBuilder();
                buffer = new byte[2];
                if (((uint) num4) - num2 < 0) goto Label_0053;
                encoding = Encoding.GetEncoding("GB2312");
                goto Label_0094;
            }
        }
    }
}
