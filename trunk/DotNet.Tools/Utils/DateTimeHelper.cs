namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    /// <summary><para>　</para>
    /// 类名：常用工具类——日期时间类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2010-01-05</para><para>--------------------------------------------------------------</para><para>　ConvertDate：返回当前日期的标准日期格式：2009-09-26</para><para>　IsTime：是否为时间格式</para><para>　IsDate：是否为日期格式：2009-09-03</para><para>　IsDateTime：是否为日期加时间格式：2009-09-03 12:12:12</para><para>　FormatDate：2008-9-6形式的字符串转成2008-09-06形式的方法</para><para>　FileNameStr：生成年月日时分秒字符串</para><para>　SecondToMinute：把秒转换成分钟</para><para>　GetMonthLastDate：返回某年某月最后一天</para><para>　DateDiff：计算两个日期的时间差</para><para>　GetYearDateList：生成两个日期中的月份数组</para><para>　GetFullWeek：获取指定日期的星期数(+2重载)</para><para>　GetChineseDate：获取指定日期或当前日期的农历信息【包括年月日闰月生肖天干地支】</para></summary>
    public class DateTimeHelper
    {
        private static string[] x23fce7bbff38614f;
        private static string[] x2b30016c79d0f9a6;
        private static string[] x34da11a5d16bfce7;
        private static string[] x41988aff98bb5bbf;
        private static string[] x6b3efa7ee99fd057;
        private static string[] x746f686c2f89304f;
        private static string[] x9e67a356b03923d2;
        private static string[] xa84bf1c85e238c46;
        private static string[] xbeddec8340ed099c;

        static DateTimeHelper()
        {
            string[] strArray3;
            string[] strArray4;
            string[] strArray5;
            string[] strArray6;
            string[] strArray7;
            string[] strArray8;
            string[] strArray9;
            string[] strArray = new string[10];
            goto Label_075C;
        Label_0021:
            x746f686c2f89304f = strArray9;
        Label_0028:
            if (15 == 0) goto Label_017D;
            return;
        Label_008E:
            x34da11a5d16bfce7 = strArray8;
            strArray9 = new string[12];
            strArray9[0] = "钻石";
            strArray9[1] = "蓝宝石";
            if (0 == 0)
            {
                strArray9[2] = "玛瑙";
                strArray9[3] = "珍珠";
            }
            strArray9[4] = "红宝石";
            strArray9[5] = "红条纹玛瑙";
            strArray9[6] = "蓝宝石";
            strArray9[7] = "猫眼石";
            strArray9[8] = "黄宝石";
            strArray9[9] = "土耳其玉";
            if (0 == 0)
            {
                strArray9[10] = "紫水晶";
                strArray9[11] = "月长石，血石";
                goto Label_0021;
            }
            return;
        Label_00FA:
            strArray8[8] = "射手座";
            strArray8[9] = "摩羯座";
            if (0 == 0)
            {
                strArray8[10] = "水瓶座";
                if (3 != 0)
                {
                    strArray8[11] = "双鱼座";
                    goto Label_008E;
                }
                goto Label_0301;
            }
        Label_0110:
            if (0x7fffffff == 0) goto Label_0487;
            strArray8[2] = "双子座";
            strArray8[3] = "巨蟹座";
            strArray8[4] = "狮子座";
            strArray8[5] = "处女座";
            strArray8[6] = "天秤座";
            strArray8[7] = "天蝎座";
            goto Label_00FA;
        Label_0139:
            strArray8[1] = "金牛座";
            goto Label_0110;
        Label_017D:
            strArray7[0x11] = "秋分";
            strArray7[0x12] = "寒露";
            strArray7[0x13] = "霜降";
            strArray7[20] = "立冬";
        Label_01A5:
            strArray7[0x15] = "小雪";
            if (0x7fffffff != 0)
            {
                strArray7[0x16] = "大雪";
                strArray7[0x17] = "冬至";
                x41988aff98bb5bbf = strArray7;
                strArray8 = new string[12];
                strArray8[0] = "白羊座";
            }
            if (0 != 0) goto Label_02E9;
            goto Label_0139;
        Label_01E5:
            strArray7[14] = "立秋";
            strArray7[15] = "处暑";
            strArray7[0x10] = "白露";
            if (4 == 0) goto Label_0408;
            goto Label_017D;
        Label_01FB:
            strArray7[13] = "大暑";
            if (-2 == 0) goto Label_01A5;
            goto Label_01E5;
        Label_02E9:
            strArray6[8] = "申";
            strArray6[9] = "酉";
            if (0 == 0)
            {
                strArray6[10] = "戌";
                strArray6[11] = "亥";
                if (-2147483648 == 0) goto Label_01E5;
                xbeddec8340ed099c = strArray6;
                strArray7 = new string[0x18];
                if (0 == 0)
                {
                    strArray7[0] = "小寒";
                    strArray7[1] = "大寒";
                    strArray7[2] = "立春";
                    strArray7[3] = "雨水";
                    strArray7[4] = "惊蛰";
                }
            }
            strArray7[5] = "春分";
            strArray7[6] = "清明";
            strArray7[7] = "谷雨";
            strArray7[8] = "立夏";
            if (0 != 0) goto Label_06EB;
            strArray7[9] = "小满";
            strArray7[10] = "芒种";
            if (0 != 0) goto Label_059E;
            if (15 == 0) goto Label_05FE;
            strArray7[11] = "夏至";
            strArray7[12] = "小暑";
            goto Label_01FB;
        Label_0301:
            strArray6[2] = "寅";
        Label_030A:
            strArray6[3] = "卯";
        Label_0313:
            strArray6[4] = "辰";
            strArray6[5] = "巳";
            strArray6[6] = "午";
            strArray6[7] = "未";
            goto Label_02E9;
        Label_033C:
            strArray6 = new string[12];
            if (-2 == 0) goto Label_073E;
            strArray6[0] = "子";
            strArray6[1] = "丑";
            goto Label_0301;
        Label_036D:
            strArray5[9] = "癸";
            x9e67a356b03923d2 = strArray5;
            if (2 != 0) goto Label_05DB;
            goto Label_0468;
        Label_0408:
            strArray4[9] = "鸡";
            strArray4[10] = "狗";
            strArray4[11] = "猪";
            x6b3efa7ee99fd057 = strArray4;
            strArray5 = new string[10];
            if (0 == 0)
            {
                do
                {
                    strArray5[0] = "甲";
                    strArray5[1] = "乙";
                    strArray5[2] = "丙";
                    strArray5[3] = "丁";
                    strArray5[4] = "戊";
                    strArray5[5] = "己";
                    strArray5[6] = "庚";
                }
                while (-1 == 0);
            }
            strArray5[7] = "辛";
            if (0 != 0) goto Label_0540;
            strArray5[8] = "壬";
            goto Label_036D;
        Label_0468:
            strArray4 = new string[12];
            strArray4[0] = "鼠";
            strArray4[1] = "牛";
            strArray4[2] = "虎";
            strArray4[3] = "兔";
            strArray4[4] = "龙";
            strArray4[5] = "蛇";
            strArray4[6] = "马";
            strArray4[7] = "羊";
            strArray4[8] = "猴";
            goto Label_0408;
        Label_0487:
            strArray3[0x1c] = "廿八";
            strArray3[0x1d] = "廿九";
            strArray3[30] = "三十";
            if (0 != 0) goto Label_01E5;
            xa84bf1c85e238c46 = strArray3;
            if (0 == 0) goto Label_05D1;
            goto Label_0556;
        Label_04B9:
            strArray3[0x17] = "廿三";
            strArray3[0x18] = "廿四";
            strArray3[0x19] = "廿五";
            strArray3[0x1a] = "廿六";
            strArray3[0x1b] = "廿七";
            goto Label_0487;
        Label_0531:
            strArray3[15] = "十五";
            if (0 != 0) goto Label_008E;
        Label_0540:
            strArray3[0x10] = "十六";
            strArray3[0x11] = "十七";
        Label_04FC:
            strArray3[0x12] = "十八";
            if (-1 == 0) goto Label_06DB;
            strArray3[0x13] = "十九";
            strArray3[20] = "二十";
            strArray3[0x15] = "廿一";
            if (-1 != 0)
            {
                if (15 != 0)
                {
                    if (0 == 0)
                    {
                        strArray3[0x16] = "廿二";
                        if (0 == 0) goto Label_04B9;
                    }
                    else
                        goto Label_04FC;
                }
                goto Label_0487;
            }
            goto Label_0531;
        Label_0556:
            strArray3[13] = "十三";
            strArray3[14] = "十四";
            goto Label_0531;
        Label_059E:
            strArray3[7] = "初七";
            strArray3[8] = "初八";
            strArray3[9] = "初九";
            strArray3[10] = "初十";
            strArray3[11] = "十一";
            if (0x7fffffff == 0) goto Label_0028;
            strArray3[12] = "十二";
            if (0 != 0) goto Label_0021;
            if (0 == 0) goto Label_0556;
        Label_05D1:
            if (3 != 0) goto Label_0468;
        Label_05DB:
            if (1 != 0) goto Label_033C;
            goto Label_075C;
        Label_05FE:
            strArray3 = new string[0x1f];
            strArray3[0] = "*";
            strArray3[1] = "初一";
            strArray3[2] = "初二";
            strArray3[3] = "初三";
            strArray3[4] = "初四";
            strArray3[5] = "初五";
            if (0 == 0)
            {
                strArray3[6] = "初六";
                goto Label_059E;
            }
            goto Label_033C;
        Label_06DB:
            strArray[7] = "七";
            strArray[8] = "八";
        Label_06EB:
            strArray[9] = "九";
            x23fce7bbff38614f = strArray;
            string[] strArray2 = new string[13];
            strArray2[0] = "*";
            strArray2[1] = "正月";
            if (-2147483648 == 0) goto Label_01FB;
            strArray2[2] = "二月";
            while (true)
            {
                if (0 != 0) goto Label_00FA;
                if (-2 == 0) goto Label_04B9;
                strArray2[3] = "三月";
                strArray2[4] = "四月";
                strArray2[5] = "五月";
                strArray2[6] = "六月";
                strArray2[7] = "七月";
                strArray2[8] = "八月";
                strArray2[9] = "九月";
                strArray2[10] = "十月";
                strArray2[11] = "十一月";
                if (0 == 0)
                {
                    if (15 == 0) goto Label_033C;
                    strArray2[12] = "腊月";
                    x2b30016c79d0f9a6 = strArray2;
                    goto Label_05FE;
                }
            }
        Label_073E:
            strArray[5] = "五";
            strArray[6] = "六";
            if (1 != 0) goto Label_06DB;
        Label_0748:
            strArray[2] = "二";
            if (0 != 0) goto Label_030A;
            strArray[3] = "三";
            if (0 != 0) goto Label_0139;
            strArray[4] = "四";
            if (0 != 0) goto Label_036D;
            goto Label_073E;
        Label_075C:
            strArray[0] = "O";
            strArray[1] = "一";
            if (0 != 0) goto Label_0313;
            if (0xff != 0) goto Label_0748;
            goto Label_06DB;
        }

        /// <summary>返回当前日期的标准日期格式：2009-09-26</summary>
        public static string ConvertDate() { return DateTime.Now.ToString("yyyy-MM-dd"); }

        /// <summary>返回指定日期DateTime的标准日期格式string</summary>
        /// <param name="Dates">日期</param>
        /// <returns></returns>
        public static string ConvertDate(DateTime Dates) { return Dates.ToString("yyyy-MM-dd"); }

        /// <summary>返回指定日期string的标准日期格式：2009-09-26</summary>
        /// <param name="Dates">String格式日期</param>
        /// <returns></returns>
        public static string ConvertDate(string Dates)
        {
            string str = null;
            try
            {
                if (!string.IsNullOrEmpty(Dates)) str = Convert.ToDateTime(Dates).ToString("yyyy-MM-dd");
            }
            catch (Exception)
            {
            }
            return str;
        }

        /// <summary>计算两个日期的时间差</summary>
        /// <param name="DateTime1">原日期</param>
        /// <param name="DateTime2">新日期</param>
        /// <param name="BackTypes">返回类型：天，小时，分钟，秒，毫秒，（X天或X小时或X分钟）</param>
        /// <returns>null或一个具体类型</returns>
        public static object DateDiff(DateTime DateTime1, DateTime DateTime2, BackType BackTypes)
        {
            object milliseconds = null;
            string str;
            TimeSpan span = (TimeSpan) (DateTime2 - DateTime1);
            switch (BackTypes)
            {
                case BackType.GetDays:
                    goto Label_00CA;

                case BackType.GetHours:
                    return span.Minutes;

                case BackType.GetMinutes:
                    goto Label_0107;

                case BackType.GetSeconds:
                    return span.Seconds;

                case BackType.GetMilliseconds:
                    milliseconds = span.Milliseconds;
                    if (2 != 0)
                    {
                        if (0 == 0) return milliseconds;
                        goto Label_00CA;
                    }
                    if (0 == 0) goto Label_0048;
                    if (15 != 0) goto Label_0007;
                    return milliseconds;

                case BackType.GetString:
                    goto Label_0048;

                default:
                    if (0 != 0) goto Label_0054;
                    goto Label_0107;
            }
        Label_0007:
            if (span.Hours >= 1) return (span.Hours + "小时");
            return (span.Minutes + "分钟");
        Label_0048:
            str = null;
            if (span.Days < 1) goto Label_0007;
        Label_0054:
            if (4 == 0) goto Label_0007;
            return (span.Days + "天");
        Label_00CA:
            return span.Days;
        Label_0107:
            return span.Days;
        }

        /// <summary>工具方法:生成年月日时分秒字符串</summary>
        /// <param name="link">年月日时分秒之间的连接字符</param>
        /// <param name="RanLength">最后生成随机数的位数</param>
        /// <returns>返回年月日时分秒毫秒四位随机数字的字符串</returns>
        public static string FileNameStr(string link, int RanLength)
        {
            int num;
            int month;
            int num3;
            int num4;
            int minute;
            int second;
            int num7;
            string str;
            string str2;
            int num8;
            DateTime time;
            DateTime now;
            DateTime time7;
            object[] objArray;
            if (string.IsNullOrEmpty(link))
            {
                link = "";
                if (((uint) minute) - ((uint) num4) < 0) goto Label_01E5;
            }
            goto Label_020E;
        Label_0062:
            objArray[10] = second;
            objArray[11] = link;
            objArray[12] = num7;
            if ((((uint) minute) & 0) != 0) goto Label_0215;
            if (((uint) num8) - ((uint) RanLength) <= uint.MaxValue)
            {
                objArray[13] = link;
                objArray[14] = str2;
                string str3 = string.Concat(objArray).ToString();
                if (((uint) month) + ((uint) second) <= uint.MaxValue) return str3;
                goto Label_0062;
            }
        Label_00F7:
            objArray[7] = link;
            objArray[8] = minute;
            if ((((uint) num4) & 0) != 0) goto Label_0186;
            objArray[9] = link;
            if ((((uint) RanLength) | 0xff) != 0) goto Label_0062;
        Label_017D:
            num7 = time7.Millisecond;
        Label_0186:
            str = "0123456789";
            Random random = new Random();
            str2 = "";
            num8 = 1;
            while (num8 <= RanLength)
            {
                str2 = str2 + str[random.Next(str.Length)];
                num8++;
            }
            objArray = new object[15];
            objArray[0] = num;
            objArray[1] = link;
            objArray[2] = month;
            objArray[3] = link;
            objArray[4] = num3;
            objArray[5] = link;
            objArray[6] = num4;
            if ((((uint) num7) | 4) == 0) goto Label_01ED;
            goto Label_00F7;
        Label_01E5:
            num3 = now.Day;
        Label_01ED:
            num4 = DateTime.Now.Hour;
            if (((uint) num8) <= uint.MaxValue)
            {
                minute = DateTime.Now.Minute;
                DateTime time6 = DateTime.Now;
                if (((uint) second) > uint.MaxValue) goto Label_017D;
                second = time6.Second;
                time7 = DateTime.Now;
                if (((uint) minute) <= uint.MaxValue) goto Label_017D;
                goto Label_0062;
            }
        Label_020E:
            time = DateTime.Now;
        Label_0215:
            num = time.Year;
            month = DateTime.Now.Month;
            now = DateTime.Now;
            goto Label_01E5;
        }

        /// <summary>2008-9-6形式的字符串转成2008-09-06形式的方法</summary>
        /// <param name="str">要转换的日期</param>
        /// <returns></returns>
        public static string FormatDate(string str)
        {
            DateTime time = DateTime.Parse(str);
            return string.Format("{0:yyyy-MM-dd}", time);
        }

        /// <summary>
        /// 获取指定日期的农历信息【包括年月日闰月生肖天干地支】
        /// <para>　使用方法：Utils.DateTimeHelper.ChineseDateInfo Info = Utils.DateTimeHelper.GetChineseDate(CDateTime);</para></summary>
        /// <param name="CDateTime">要转换的时间日期</param>
        /// <returns></returns>
        public static ChineseDateInfo GetChineseDate(DateTime CDateTime)
        {
            ChineseDateInfo info = new ChineseDateInfo();
            try
            {
                int num;
                int leapMonth;
                int month;
                int dayOfMonth;
                int num5;
                int num6;
                int terrestrialBranch;
                string str;
                int num8;
                ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
                goto Label_01C1;
            Label_0011:
                info.TianGan = x9e67a356b03923d2[num6];
                info.DiZhi = xbeddec8340ed099c[terrestrialBranch - 1];
                if (((uint) leapMonth) + ((uint) num6) < 0) goto Label_0129;
                info.Constellations = (x879f9e94ce340421(CDateTime) >= 0) ? x34da11a5d16bfce7[x879f9e94ce340421(CDateTime)] : "未知星座";
                info.BirthStones = (x879f9e94ce340421(CDateTime) >= 0) ? x746f686c2f89304f[x879f9e94ce340421(CDateTime)] : "未知诞生石";
                return info;
            Label_0090:
                info.Year = str + "年";
                info.Month = x2b30016c79d0f9a6[month];
            Label_00B0:
                info.Day = xa84bf1c85e238c46[dayOfMonth];
                info.LeapMonth = x2b30016c79d0f9a6[leapMonth - 1];
                if (-2 == 0) goto Label_0180;
                info.ShengXiao = x6b3efa7ee99fd057[num5 - 1];
                goto Label_0011;
            Label_00E9:
                if (num8 >= num.ToString().Length) goto Label_0090;
                int index = Convert.ToInt32(num.ToString().Substring(num8, 1));
                str = str + x23fce7bbff38614f[index];
            Label_0129:
                num8++;
                goto Label_00E9;
            Label_0138:
                if (((uint) dayOfMonth) + ((uint) num) < 0) goto Label_0180;
            Label_0150:
                if (month >= leapMonth) goto Label_0164;
            Label_0155:
                str = "";
                num8 = 0;
                goto Label_00E9;
            Label_0164:
                month--;
                goto Label_0155;
            Label_016E:
                if (((uint) num6) <= uint.MaxValue) goto Label_0138;
            Label_0180:
                if (leapMonth <= 0) goto Label_0155;
                goto Label_0150;
            Label_0186:
                num6 = (num - 0x748) % 10;
                terrestrialBranch = calendar.GetTerrestrialBranch(calendar.GetSexagenaryYear(CDateTime));
                if (((uint) num8) > uint.MaxValue) goto Label_0129;
                if (0 != 0) goto Label_016E;
                if (0 == 0) goto Label_0180;
                goto Label_0150;
            Label_01C1:
                num = calendar.GetYear(CDateTime);
                leapMonth = calendar.GetLeapMonth(num);
                if (0 != 0) goto Label_00B0;
                month = calendar.GetMonth(CDateTime);
                dayOfMonth = calendar.GetDayOfMonth(CDateTime);
                num5 = calendar.GetTerrestrialBranch(calendar.GetSexagenaryYear(CDateTime));
            }
            catch (Exception)
            {
            }
            goto Label_0186;
        }

        /// <summary>获取当前日期的星期数，如星期一</summary>
        /// <returns>星期一、星期二……</returns>
        public static string GetFullWeek() { return GetFullWeek(DateTime.Now); }

        /// <summary>获取指定日期的星期数，如星期一</summary>
        /// <param name="T">当前日期时间</param>
        /// <returns>星期一、星期二……</returns>
        public static string GetFullWeek(DateTime T)
        {
            string str = "";
            if (15 != 0)
            {
                switch (T.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        str = "日";
                        goto Label_0036;

                    case DayOfWeek.Monday:
                        str = "一";
                        goto Label_0036;

                    case DayOfWeek.Tuesday:
                        str = "二";
                        goto Label_0036;

                    case DayOfWeek.Wednesday:
                        str = "三";
                        if (0xff != 0)
                        {
                        }
                        goto Label_0036;

                    case DayOfWeek.Thursday:
                        str = "四";
                        goto Label_0036;

                    case DayOfWeek.Friday:
                        str = "五";
                        goto Label_0036;

                    case DayOfWeek.Saturday:
                        str = "六";
                        goto Label_0036;
                }
                goto Label_0036;
            }
        Label_0010:
            if (0 == 0 || -1 != 0) return "";
        Label_0036:
            while (!string.IsNullOrEmpty(str))
            {
                return ("星期" + str);
            }
            goto Label_0010;
        }

        /// <summary>返回某年某月最后一天</summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime time = new DateTime(year, month, new GregorianCalendar().GetDaysInMonth(year, month));
            return time.Day;
        }

        /// <summary>生成两个日期中的月份数组</summary>
        /// <param name="StartDate">开始日期</param>
        /// <param name="EndDate">结束日期</param>
        /// <returns></returns>
        public static IList<int[]> GetYearDateList(DateTime StartDate, DateTime EndDate)
        {
            int num5;
            int[] numArray;
            int num6;
            int num7;
            int[] numArray2;
            int num8;
            int num9;
            List<int[]> list = new List<int[]>();
            int year = StartDate.Year;
            int month = StartDate.Month;
            int num3 = EndDate.Year;
            int num4 = EndDate.Month;
            if (((uint) num5) - ((uint) month) > uint.MaxValue) goto Label_0248;
        Label_0215:
            if (year == num3)
                num5 = month;
            else
            {
                if ((((uint) num3) & 0) == 0 || ((uint) num6) + ((uint) month) <= uint.MaxValue)
                {
                    if (year >= num3) return list;
                    num6 = year;
                    goto Label_0042;
                }
                goto Label_0215;
            }
            goto Label_021D;
        Label_000B:
            if (num6 == num3)
            {
                num9 = 1;
                while (num9 <= num4)
                {
                    int[] item = new int[] { num6, num9 };
                    list.Add(item);
                    if (15 == 0) goto Label_0163;
                    num9++;
                }
                if ((((uint) month) & 0) == 0)
                {
                    if (((uint) num6) < 0) goto Label_000B;
                    goto Label_003C;
                }
                goto Label_00C7;
            }
            if (((uint) year) < 0) goto Label_0248;
        Label_003C:
            num6++;
        Label_0042:
            if (num6 <= num3)
            {
                if (num6 == year)
                {
                    num7 = month;
                    goto Label_0163;
                }
                if (((uint) num7) - ((uint) num4) <= uint.MaxValue)
                {
                    if (num6 <= year) goto Label_000B;
                    if (((uint) num3) < 0) goto Label_01C5;
                    if (num6 >= num3) goto Label_000B;
                }
                if (((uint) num7) >= 0)
                {
                    if (((uint) num9) + ((uint) num9) > uint.MaxValue) return list;
                    goto Label_00FB;
                }
                goto Label_022E;
            }
        Label_00C7:
            if (0x7fffffff != 0) return list;
        Label_00FB:
            num8 = 1;
            while (num8 <= 12)
            {
                int[] numArray3 = new int[] { num6, num8 };
                if ((((uint) num6) | 0xfffffffe) != 0)
                {
                    list.Add(numArray3);
                    if (((uint) num9) - ((uint) num9) > uint.MaxValue) break;
                    num8++;
                }
                if ((((uint) num4) | 0x80000000) == 0) break;
            }
            goto Label_003C;
        Label_0163:
            if (num7 > 12) goto Label_003C;
        Label_01C5:
            numArray2 = new int[] { num6, num7 };
            list.Add(numArray2);
            num7++;
            goto Label_0163;
        Label_021D:
            if (num5 <= num4)
            {
                numArray = new int[2];
                numArray[0] = year;
                if ((((uint) num3) & 0) == 0) goto Label_0248;
            }
            else
                return list;
        Label_022E:
            list.Add(numArray);
            num5++;
            goto Label_021D;
        Label_0248:
            numArray[1] = num5;
            goto Label_022E;
        }

        /// <summary>是否为日期格式：2009-09-03</summary>
        /// <param name="DateStr">日期字符串</param>
        /// <returns></returns>
        public static bool IsDate(string DateStr)
        {
            try
            {
                DateTime time = Convert.ToDateTime(DateStr);
                while (time.ToString("yyyy-MM-dd") == DateStr)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>是否为日期加时间格式：2009-09-03 12:12:12</summary>
        /// <param name="DateTimeStr">日期加时间字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(string DateTimeStr)
        {
            try
            {
                DateTime time = Convert.ToDateTime(DateTimeStr);
                while (time.ToString("yyyy-MM-dd HH:mm:ss") == DateTimeStr)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>是否为时间格式</summary>
        /// <returns>是则返加true 不是则返回 false</returns>
        public static bool IsTime(string timeval) { return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$"); }

        /// <summary>把秒转换成分钟</summary>
        /// <param name="Second">秒</param>
        /// <returns>分钟</returns>
        public static int SecondToMinute(int Second)
        {
            decimal d = Second / 60M;
            return Convert.ToInt32(Math.Ceiling(d));
        }

        private static ChineseDateInfo x0c45f5ee01797a11() { return GetChineseDate(DateTime.Now); }

        private static int x879f9e94ce340421(DateTime x964e6c32690a7a3e)
        {
            int num2;
            int num = Convert.ToInt32(x964e6c32690a7a3e.ToString("MMdd"));
            goto Label_02F4;
        Label_001E:
            if (0 != 0)
            {
                if (((uint) num) > uint.MaxValue) goto Label_0068;
                if (0 != 0) goto Label_02B8;
                if (2 == 0) goto Label_0249;
                if (0xff != 0) goto Label_02B8;
                goto Label_0276;
            }
            return num2;
        Label_0051:
            if (num >= 120 || ((uint) num) < 0) goto Label_00AF;
        Label_0068:
            if (num >= 0xdb)
            {
                if (num <= 320)
                {
                    num2 = 11;
                    if (0 != 0) goto Label_0068;
                    if (((uint) num) - ((uint) num2) <= uint.MaxValue) goto Label_001E;
                    if ((((uint) num) | 0xff) == 0) goto Label_021A;
                    goto Label_00AF;
                }
                if (((uint) num2) - ((uint) num2) < 0) goto Label_0319;
            }
            num2 = -1;
            if (0xff != 0)
            {
                if (((uint) num2) <= uint.MaxValue)
                {
                    if (-2 != 0) return num2;
                    goto Label_02F4;
                }
                if ((((uint) num2) & 0) != 0) goto Label_01D2;
                goto Label_0169;
            }
            goto Label_00E0;
        Label_00AF:
            if (num > 0xda)
            {
                if ((((uint) num2) | uint.MaxValue) != 0) goto Label_0068;
                goto Label_001E;
            }
        Label_00E0:
            return 10;
        Label_0102:
            if (num < 0x4c6)
            {
                if (num > 0x77) goto Label_0051;
                if (((uint) num2) > uint.MaxValue) return num2;
            }
            return 9;
        Label_0117:
            if (num <= 0x4c5) goto Label_0162;
            goto Label_0102;
        Label_0140:
            if (num >= 0x462) goto Label_0117;
            goto Label_0102;
        Label_0162:
            return 8;
        Label_0169:
            if (num < 0x400) goto Label_0140;
            if (num <= 0x461)
            {
                num2 = 7;
                if (((uint) num2) - ((uint) num2) >= 0) return num2;
                goto Label_001E;
            }
            if (15 != 0) goto Label_0140;
            if (((uint) num2) + ((uint) num) <= uint.MaxValue) goto Label_0117;
            goto Label_0162;
        Label_01D2:
            if (num < 0x39b)
            {
                if (((uint) num2) + ((uint) num2) > uint.MaxValue) goto Label_0051;
                goto Label_0169;
            }
        Label_021A:
            if (num > 0x3ff) goto Label_0169;
            return 6;
        Label_0249:
            if (num <= 0x2d2) return 3;
        Label_0258:
            if (num < 0x2d3 || ((uint) num2) >= 0 && num > 0x336)
            {
                if (num < 0x337) goto Label_01D2;
                if (num <= 0x39a) return 5;
                if (((uint) num2) - ((uint) num) <= uint.MaxValue) goto Label_01D2;
                goto Label_021A;
            }
            return 4;
        Label_0276:
            if (num < 0x209 || num > 0x26d)
            {
                if (num < 0x26e) goto Label_0258;
                goto Label_0249;
            }
            return 2;
        Label_02B8:
            if (num >= 420 && num <= 520) return 1;
            goto Label_0276;
        Label_02F4:
            if (((uint) num) + ((uint) num2) > uint.MaxValue) goto Label_00AF;
            if (num >= 0x141)
            {
                if (num > 0x1a3) goto Label_02B8;
            }
            else
                goto Label_02B8;
        Label_0319:
            return 0;
        }

        /// <summary>返回类型</summary>
        public enum BackType
        {
            GetDays,
            GetHours,
            GetMinutes,
            GetSeconds,
            GetMilliseconds,
            GetString
        }

        /// <summary>农历日期信息对象实体</summary>
        public class ChineseDateInfo
        {
            [CompilerGenerated]
            private string x01a8373b5fa516ef;
            [CompilerGenerated]
            private string x1a80136564431bc2;
            [CompilerGenerated]
            private string x4d78f2a01c62e353;
            [CompilerGenerated]
            private string x6cbc755c83a6d126;
            [CompilerGenerated]
            private string x96764e67c8b213d6;
            [CompilerGenerated]
            private string x989939e4dce4fbb3;
            [CompilerGenerated]
            private string x9adf06ec5802164b;
            [CompilerGenerated]
            private string xb5f5497b07b55d49;
            [CompilerGenerated]
            private string xcf400d8b794a2e42;
            [CompilerGenerated]
            private string xfbd41362e68ab91a;

            /// <summary>诞生石</summary>
            public string BirthStones { [CompilerGenerated]
            get { return this.x96764e67c8b213d6; } [CompilerGenerated]
            set { this.x96764e67c8b213d6 = value; } }

            /// <summary>星座</summary>
            public string Constellations { [CompilerGenerated]
            get { return this.x4d78f2a01c62e353; } [CompilerGenerated]
            set { this.x4d78f2a01c62e353 = value; } }

            /// <summary>农历日</summary>
            public string Day { [CompilerGenerated]
            get { return this.xcf400d8b794a2e42; } [CompilerGenerated]
            set { this.xcf400d8b794a2e42 = value; } }

            /// <summary>地支</summary>
            public string DiZhi { [CompilerGenerated]
            get { return this.x989939e4dce4fbb3; } [CompilerGenerated]
            set { this.x989939e4dce4fbb3 = value; } }

            /// <summary>闰月的月份</summary>
            public string LeapMonth { [CompilerGenerated]
            get { return this.x01a8373b5fa516ef; } [CompilerGenerated]
            set { this.x01a8373b5fa516ef = value; } }

            /// <summary>农历月</summary>
            public string Month { [CompilerGenerated]
            get { return this.x9adf06ec5802164b; } [CompilerGenerated]
            set { this.x9adf06ec5802164b = value; } }

            /// <summary>十二生肖</summary>
            public string ShengXiao { [CompilerGenerated]
            get { return this.x1a80136564431bc2; } [CompilerGenerated]
            set { this.x1a80136564431bc2 = value; } }

            /// <summary>24节气</summary>
            public string SolarTerms { [CompilerGenerated]
            get { return this.xb5f5497b07b55d49; } [CompilerGenerated]
            set { this.xb5f5497b07b55d49 = value; } }

            /// <summary>天干</summary>
            public string TianGan { [CompilerGenerated]
            get { return this.x6cbc755c83a6d126; } [CompilerGenerated]
            set { this.x6cbc755c83a6d126 = value; } }

            /// <summary>农历年</summary>
            public string Year { [CompilerGenerated]
            get { return this.xfbd41362e68ab91a; } [CompilerGenerated]
            set { this.xfbd41362e68ab91a = value; } }
        }
    }
}
