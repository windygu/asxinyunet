namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;

    public class MyDateTime
    {
        private DateTime mUvqAX6rk;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public MyDateTime()
        {
            this.mUvqAX6rk = DateTime.Now;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public MyDateTime(DateTime dateTime)
        {
            this.mUvqAX6rk = DateTime.Now;
            this.mUvqAX6rk = dateTime;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public MyDateTime(string dateTime)
        {
            this.mUvqAX6rk = DateTime.Now;
            this.mUvqAX6rk = DateTime.Parse(dateTime);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetDayOfWeekCN()
        {
            string[] strArray = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e6c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e76), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e80), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e8a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e94), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e9e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1ea8) };
            return strArray[Convert.ToInt16(this.mUvqAX6rk.DayOfWeek)];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public int GetDayOfWeekNum()
        {
            return ((Convert.ToInt16(this.mUvqAX6rk.DayOfWeek) == 0) ? 7 : Convert.ToInt16(this.mUvqAX6rk.DayOfWeek));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetFirstDayOfMonth(int? months)
        {
            int? nullable = months;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(DateTime.Now.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1ddc))).AddMonths(num).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetFirstDayOfQuarter(int? quarters)
        {
            int? nullable = quarters;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return this.mUvqAX6rk.AddMonths((num * 3) - ((this.mUvqAX6rk.Month - 1) % 3)).ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e3c));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetFirstDayOfYear(int? years)
        {
            int? nullable = years;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(this.mUvqAX6rk.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e0c))).AddYears(num).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetLastDayOfMonth(int? months)
        {
            int? nullable = months;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(this.mUvqAX6rk.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1df4))).AddMonths(num).AddDays(-1.0).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetLastDayOfQuarter(int? quarters)
        {
            int? nullable = quarters;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(this.mUvqAX6rk.AddMonths((num * 3) - ((this.mUvqAX6rk.Month - 1) % 3)).ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e54))).AddDays(-1.0).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetLastDayOfYear(int? years)
        {
            int? nullable = years;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return DateTime.Parse(this.mUvqAX6rk.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1e24))).AddYears(num).AddDays(-1.0).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetSaturday(int? weeks)
        {
            int? nullable = weeks;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return this.mUvqAX6rk.AddDays(Convert.ToDouble((int) (6 - Convert.ToInt16(this.mUvqAX6rk.DayOfWeek))) + (7 * num)).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetSunday(int? weeks)
        {
            int? nullable = weeks;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return this.mUvqAX6rk.AddDays(Convert.ToDouble((int) -Convert.ToInt16(this.mUvqAX6rk.DayOfWeek)) + (7 * num)).ToShortDateString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetTheDay(int? days)
        {
            int? nullable = days;
            int num = nullable.HasValue ? nullable.GetValueOrDefault() : 0;
            return this.mUvqAX6rk.AddDays((double) num).ToShortDateString();
        }
    }
}

