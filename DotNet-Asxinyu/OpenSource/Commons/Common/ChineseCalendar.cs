namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;

    public class ChineseCalendar
    {
        private static string[] 37jAJ3Bnt = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xba8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbae), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbb4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbba) };
        private static string[] 408MSTia8 = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xac6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xade), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaea), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaf0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaf6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xafc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb02), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb08) };
        private static string[] GPY6Re0PF = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb0e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb14), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb1a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb20), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb26), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb2c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb32), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb38), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb3e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb44), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb4a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb50) };
        private static string[] JiYUNJcCW = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb56), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb5c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb62), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb68), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb6e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb74), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb7a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb80), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb86), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb8c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb92), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb9a) };
        private static ChineseLunisolarCalendar mUvqAX6rk = new ChineseLunisolarCalendar();
        private static string[] PQMwwy6pB = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbc6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbcc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbd8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbde), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbe4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbea), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbf6) };
        private static string[] XPOfx7u7N = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa8a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa90), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa96), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa9c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaa2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaa8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaae), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xab4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xac0) };

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetChineseDateTime(DateTime datetime)
        {
            int year = mUvqAX6rk.GetYear(datetime);
            int month = mUvqAX6rk.GetMonth(datetime);
            int dayOfMonth = mUvqAX6rk.GetDayOfMonth(datetime);
            int leapMonth = mUvqAX6rk.GetLeapMonth(year);
            bool flag = false;
            if (leapMonth > 0)
            {
                if (leapMonth == month)
                {
                    flag = true;
                    month--;
                }
                else if (month > leapMonth)
                {
                    month--;
                }
            }
            return (GetLunisolarYear(year) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa3e) + (flag ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa44) : string.Empty) + GetLunisolarMonth(month) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa4a) + GetLunisolarDay(dayOfMonth));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetChineseDateTimeNow()
        {
            return GetChineseDateTime(DateTime.Now);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLunisolarDay(int day)
        {
            if ((day <= 0) || (day >= 0x20))
            {
                throw new ArgumentOutOfRangeException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa7c));
            }
            if ((day != 20) && (day != 30))
            {
                return (37jAJ3Bnt[(day - 1) / 10] + PQMwwy6pB[(day - 1) % 10]);
            }
            return (PQMwwy6pB[(day - 1) / 10] + 37jAJ3Bnt[1]);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLunisolarMonth(int month)
        {
            if ((month >= 13) || (month <= 0))
            {
                throw new ArgumentOutOfRangeException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa6c));
            }
            return JiYUNJcCW[month - 1];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetLunisolarYear(int year)
        {
            if (year <= 3)
            {
                throw new ArgumentOutOfRangeException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa5c));
            }
            int index = (year - 4) % 10;
            int num2 = (year - 4) % 12;
            return (XPOfx7u7N[index] + 408MSTia8[num2] + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa50) + GPY6Re0PF[num2] + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa56));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetShengXiao(DateTime datetime)
        {
            return GPY6Re0PF[mUvqAX6rk.GetTerrestrialBranch(mUvqAX6rk.GetSexagenaryYear(datetime)) - 1];
        }

        public static DateTime MaxSupportedDateTime
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return mUvqAX6rk.MaxSupportedDateTime;
            }
        }

        public static DateTime MinSupportedDateTime
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return mUvqAX6rk.MinSupportedDateTime;
            }
        }

        public static string Now
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return GetChineseDateTimeNow();
            }
        }
    }
}

