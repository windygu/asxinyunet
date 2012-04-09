namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;

    public class DateTimeHelper
    {
        private DateTime AWbNwkBdU;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DateTimeHelper()
        {
            this.AWbNwkBdU = DateTime.Now;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DateTimeHelper(DateTime dateTime)
        {
            this.AWbNwkBdU = DateTime.Now;
            this.AWbNwkBdU = dateTime;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DateTimeHelper(string dateTime)
        {
            this.AWbNwkBdU = DateTime.Now;
            this.AWbNwkBdU = DateTime.Parse(dateTime);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime ConvertPHPToTime(long time)
        {
            DateTime time2 = new DateTime(0x7b2, 1, 1);
            return new DateTime(((time + 0x7080L) * 0x989680L) + time2.Ticks);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long ConvertTimeToJS(DateTime TheDate)
        {
            DateTime time = new DateTime(0x7b2, 1, 1);
            DateTime time2 = TheDate.ToUniversalTime();
            TimeSpan span = new TimeSpan(time2.Ticks - time.Ticks);
            return (long) span.TotalMilliseconds;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static long ConvertTimeToPHP(DateTime time)
        {
            DateTime time2 = new DateTime(0x7b2, 1, 1);
            return ((DateTime.UtcNow.Ticks - time2.Ticks) / 0x989680L);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime GetChineseDateTime()
        {
            DateTime minValue = DateTime.MinValue;
            try
            {
                string url = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf8b8);
                string html = new HttpHelper { Encoding = Encoding.Default }.GetHtml(url);
                string pattern = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf8fa);
                string str4 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf92a);
                string str5 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf950);
                string str6 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf976);
                Regex regex = new Regex(pattern);
                Regex regex2 = new Regex(str4);
                Regex regex3 = new Regex(str5);
                Regex regex4 = new Regex(str6);
                minValue = DateTime.Parse(regex.Match(html).Value);
                int num = JkKfoMY5A(regex2.Match(html).Value, false);
                int num2 = JkKfoMY5A(regex3.Match(html).Value, false);
                int num3 = JkKfoMY5A(regex4.Match(html).Value, false);
                minValue = minValue.AddHours((double) num).AddMinutes((double) num2).AddSeconds((double) num3);
            }
            catch
            {
            }
            return minValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetDayOfWeekCN()
        {
            string[] strArray = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa3a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa44), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa4e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa58), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa62), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa6c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa76) };
            return strArray[Convert.ToInt16(this.AWbNwkBdU.DayOfWeek)];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int GetDayOfWeekNum()
        {
            return ((Convert.ToInt16(this.AWbNwkBdU.DayOfWeek) == 0) ? 7 : Convert.ToInt16(this.AWbNwkBdU.DayOfWeek));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDiffTime(DateTime beginTime, DateTime endTime)
        {
            int mindTime = 0;
            return GetDiffTime(beginTime, endTime, ref mindTime);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDiffTime(DateTime beginTime, DateTime endTime, ref int mindTime)
        {
            string str = string.Empty;
            int num = Convert.ToInt32(endTime.Subtract(beginTime).TotalSeconds);
            int num2 = 60;
            int num3 = num2 * 60;
            int num4 = num3 * 0x18;
            int num5 = num4 * 30;
            int num6 = num5 * 12;
            if ((mindTime > num) && (num > 0))
            {
                mindTime = 1;
            }
            else
            {
                mindTime = 0;
            }
            if (num > num6)
            {
                str = str + (num / num6) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa80);
                num = num % num6;
            }
            if (num > num5)
            {
                str = str + (num / num5) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa86);
                num = num % num5;
            }
            if (num > num4)
            {
                str = str + (num / num4) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa8c);
                num = num % num4;
            }
            if (num > num3)
            {
                str = str + (num / num3) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa92);
                num = num % num3;
            }
            if (num > num2)
            {
                str = str + (num / num2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa9a);
                num = num % num2;
            }
            return (str + num + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfaa0));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetFirstDayOfMonth(int? months)
        {
            int? nullable = months;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(DateTime.Now.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf9aa))).AddMonths(num).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetFirstDayOfQuarter(int? quarters)
        {
            int? nullable = quarters;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return this.AWbNwkBdU.AddMonths((num * 3) - ((this.AWbNwkBdU.Month - 1) % 3)).ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa0a));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetFirstDayOfYear(int? years)
        {
            int? nullable = years;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(this.AWbNwkBdU.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf9da))).AddYears(num).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetLastDayOfMonth(int? months)
        {
            int? nullable = months;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(this.AWbNwkBdU.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf9c2))).AddMonths(num).AddDays(-1.0).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetLastDayOfQuarter(int? quarters)
        {
            int? nullable = quarters;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(this.AWbNwkBdU.AddMonths((num * 3) - ((this.AWbNwkBdU.Month - 1) % 3)).ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xfa22))).AddDays(-1.0).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetLastDayOfYear(int? years)
        {
            int? nullable = years;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(this.AWbNwkBdU.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf9f2))).AddYears(num).AddDays(-1.0).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetSaturday(int? weeks)
        {
            int? nullable = weeks;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return this.AWbNwkBdU.AddDays(Convert.ToDouble((int) (6 - Convert.ToInt16(this.AWbNwkBdU.DayOfWeek))) + (7 * num)).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetSunday(int? weeks)
        {
            int? nullable = weeks;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return this.AWbNwkBdU.AddDays(Convert.ToDouble((int) -Convert.ToInt16(this.AWbNwkBdU.DayOfWeek)) + (7 * num)).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetTheDay(int? days)
        {
            int? nullable = days;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return this.AWbNwkBdU.AddDays((double) num).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetWeekAmount(int year)
        {
            DateTime time = new DateTime(year, 12, 0x1f);
            GregorianCalendar calendar = new GregorianCalendar();
            return calendar.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void GetWeekTime(int nYear, int nNumWeek, out DateTime dtWeekStart, out DateTime dtWeekeEnd)
        {
            DateTime time = new DateTime(nYear, 1, 1);
            time += new TimeSpan((nNumWeek - 1) * 7, 0, 0, 0);
            dtWeekStart = time.AddDays((double) (-time.DayOfWeek + 1));
            dtWeekeEnd = time.AddDays((double) ((6 - time.DayOfWeek) + 1));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void GetWeekWorkTime(int nYear, int nNumWeek, out DateTime dtWeekStart, out DateTime dtWeekeEnd)
        {
            DateTime time = new DateTime(nYear, 1, 1);
            time += new TimeSpan((nNumWeek - 1) * 7, 0, 0, 0);
            dtWeekStart = time.AddDays((double) (-time.DayOfWeek + 1));
            dtWeekeEnd = time.AddDays((double) ((6 - time.DayOfWeek) + 1)).AddDays(-2.0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int JkKfoMY5A(string text1, bool flag1)
        {
            if (string.IsNullOrEmpty(text1))
            {
                return 0;
            }
            text1 = text1.Trim();
            if (!flag1)
            {
                Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf99c));
                text1 = regex.Match(text1.Trim()).Value;
            }
            int result = 0;
            int.TryParse(text1, out result);
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetLocalTime(DateTime dt)
        {
            G31rjSq7lSZmEAvw11Y avwy;
            avwy.VZJq3SjrW = (short) dt.Year;
            avwy.JkKfoMY5A = (short) dt.Month;
            avwy.AWbNwkBdU = (short) dt.DayOfWeek;
            avwy.wKyWxGToc = (short) dt.Day;
            avwy.NMPUAbUfQ = (short) dt.Hour;
            avwy.9kgn4QLpm = (short) dt.Minute;
            avwy.6VVwcY8if = (short) dt.Second;
            avwy.HMRRScNpR = (short) dt.Millisecond;
            VZJq3SjrW(ref avwy);
        }

        [DllImport("kernel32.dll", EntryPoint="SetLocalTime")]
        private static extern bool VZJq3SjrW(ref G31rjSq7lSZmEAvw11Y);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int WeekOfYear(DateTime date)
        {
            GregorianCalendar calendar = new GregorianCalendar();
            return calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int WeekOfYear(DateTime date, DayOfWeek week)
        {
            GregorianCalendar calendar = new GregorianCalendar();
            return calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, week);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct G31rjSq7lSZmEAvw11Y
        {
            public short VZJq3SjrW;
            public short JkKfoMY5A;
            public short AWbNwkBdU;
            public short wKyWxGToc;
            public short NMPUAbUfQ;
            public short 9kgn4QLpm;
            public short 6VVwcY8if;
            public short HMRRScNpR;
        }
    }
}

