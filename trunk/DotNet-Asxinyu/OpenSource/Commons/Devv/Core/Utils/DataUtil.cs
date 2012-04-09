namespace Devv.Core.Utils
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class DataUtil
    {
        private DataUtil()
        {
        }

        public static string Capitalize(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return (value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1));
            }
            return string.Empty;
        }

        public static int DateDiff(DateTime date1, DateTime date2)
        {
            return DateDiff(date1, date2, "days");
        }

        public static int DateDiff(DateTime date1, DateTime date2, string datePart)
        {
            TimeSpan span = (TimeSpan) (date1 - date2);
            string str = datePart;
            switch (str)
            {
                case "year":
                case "yyyy":
                case "yy":
                case "y":
                    return (span.Days / 0x16d);

                case "month":
                case "mon":
                case "mo":
                    return (span.Days / 30);

                case "day":
                case "dd":
                case "d":
                    return span.Days;

                case "hour":
                case "hh":
                case "h":
                    return span.Hours;

                case "minute":
                case "min":
                case "m":
                    return span.Minutes;
            }
            if (((str != "second") && (str != "sec")) && (str != "s"))
            {
                return span.Days;
            }
            return span.Seconds;
        }

        public static bool GetBoolean(object value)
        {
            if (value == null)
            {
                return false;
            }
            string str = value.ToString();
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            str = str.ToLower();
            if (((str != "1") && (str != "true")) && (str != "yes"))
            {
                return false;
            }
            return true;
        }

        public static string GetDateRfc822(DateTime value)
        {
            int hours = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
            string str2 = "+" + hours.ToString().PadLeft(2, '0');
            if (hours < 0)
            {
                int num2 = hours * -1;
                str2 = "-" + num2.ToString().PadLeft(2, '0');
            }
            return value.ToString("ddd, dd MMM yyyy HH:mm:ss " + str2.PadRight(5, '0'));
        }

        public static DateTime GetDateTime(object value)
        {
            if (value == null)
            {
                return DateTime.MinValue;
            }
            return Convert.ToDateTime(RuntimeHelpers.GetObjectValue(value));
        }

        public static double GetDouble(object value)
        {
            if (value == null)
            {
                return -7.9228162514264338E+28;
            }
            return Convert.ToDouble(RuntimeHelpers.GetObjectValue(value));
        }

        public static int GetInt32(object value)
        {
            if (value == null)
            {
                return -2147483648;
            }
            return Convert.ToInt32(RuntimeHelpers.GetObjectValue(value));
        }

        public static float GetSingle(object value)
        {
            if (value == null)
            {
                return float.MinValue;
            }
            return Convert.ToSingle(RuntimeHelpers.GetObjectValue(value));
        }

        public static string GetString(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.ToString();
        }

        public static bool HasValue(object value)
        {
            return (((value != null) && !(value is DBNull)) && !string.IsNullOrWhiteSpace(value.ToString()));
        }

        public static bool IsNumeric(string value)
        {
            int intReturn = 0;
            return IsNumeric(value, ref intReturn);
        }

        public static bool IsNumeric(string value, ref int intReturn)
        {
            bool flag;
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            try
            {
                intReturn = Convert.ToInt32(value);
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                flag = false;
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        public static DateTime ParseDateRfc822(string value)
        {
            DateTime time;
            if (string.IsNullOrEmpty(value))
            {
                return DateTime.MinValue;
            }
            int length = value.LastIndexOf(" ");
            try
            {
                time = Convert.ToDateTime(value);
                if (value.Substring(length + 1) == "Z")
                {
                    return time.ToUniversalTime();
                }
                if (value.Substring(length + 1) == "GMT")
                {
                    time = time.ToUniversalTime();
                }
                return time;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
            time = Convert.ToDateTime(value.Substring(0, length));
            if (value[length + 1] == '+')
            {
                int num2 = Convert.ToInt32(value.Substring(length + 2, 2));
                time = time.AddHours((double) -num2);
                int num3 = Convert.ToInt32(value.Substring(length + 4, 2));
                return time.AddMinutes((double) -num3);
            }
            if (value[length + 1] == '-')
            {
                int num4 = Convert.ToInt32(value.Substring(length + 2, 2));
                time = time.AddHours((double) num4);
                int num5 = Convert.ToInt32(value.Substring(length + 4, 2));
                return time.AddMinutes((double) num5);
            }
            if (value.Substring(length + 1) == "A")
            {
                return time.AddHours(1.0);
            }
            if (value.Substring(length + 1) == "B")
            {
                return time.AddHours(2.0);
            }
            if (value.Substring(length + 1) == "C")
            {
                return time.AddHours(3.0);
            }
            if (value.Substring(length + 1) == "D")
            {
                return time.AddHours(4.0);
            }
            if (value.Substring(length + 1) == "E")
            {
                return time.AddHours(5.0);
            }
            if (value.Substring(length + 1) == "F")
            {
                return time.AddHours(6.0);
            }
            if (value.Substring(length + 1) == "G")
            {
                return time.AddHours(7.0);
            }
            if (value.Substring(length + 1) == "H")
            {
                return time.AddHours(8.0);
            }
            if (value.Substring(length + 1) == "I")
            {
                return time.AddHours(9.0);
            }
            if (value.Substring(length + 1) == "K")
            {
                return time.AddHours(10.0);
            }
            if (value.Substring(length + 1) == "L")
            {
                return time.AddHours(11.0);
            }
            if (value.Substring(length + 1) == "M")
            {
                return time.AddHours(12.0);
            }
            if (value.Substring(length + 1) == "N")
            {
                return time.AddHours(-1.0);
            }
            if (value.Substring(length + 1) == "O")
            {
                return time.AddHours(-2.0);
            }
            if (value.Substring(length + 1) == "P")
            {
                return time.AddHours(-3.0);
            }
            if (value.Substring(length + 1) == "Q")
            {
                return time.AddHours(-4.0);
            }
            if (value.Substring(length + 1) == "R")
            {
                return time.AddHours(-5.0);
            }
            if (value.Substring(length + 1) == "S")
            {
                return time.AddHours(-6.0);
            }
            if (value.Substring(length + 1) == "T")
            {
                return time.AddHours(-7.0);
            }
            if (value.Substring(length + 1) == "U")
            {
                return time.AddHours(-8.0);
            }
            if (value.Substring(length + 1) == "V")
            {
                return time.AddHours(-9.0);
            }
            if (value.Substring(length + 1) == "W")
            {
                return time.AddHours(-10.0);
            }
            if (value.Substring(length + 1) == "X")
            {
                return time.AddHours(-11.0);
            }
            if (value.Substring(length + 1) == "Y")
            {
                return time.AddHours(-12.0);
            }
            if (value.Substring(length + 1) == "EST")
            {
                return time.AddHours(5.0);
            }
            if (value.Substring(length + 1) == "EDT")
            {
                return time.AddHours(4.0);
            }
            if (value.Substring(length + 1) == "CST")
            {
                return time.AddHours(6.0);
            }
            if (value.Substring(length + 1) == "CDT")
            {
                return time.AddHours(5.0);
            }
            if (value.Substring(length + 1) == "MST")
            {
                return time.AddHours(7.0);
            }
            if (value.Substring(length + 1) == "MDT")
            {
                return time.AddHours(6.0);
            }
            if (value.Substring(length + 1) == "PST")
            {
                return time.AddHours(8.0);
            }
            if (value.Substring(length + 1) == "PDT")
            {
                time = time.AddHours(7.0);
            }
            return time;
        }

        public static int ParseDurationToSeconds(string value)
        {
            int num = 0;
            try
            {
                if (value.Contains("s"))
                {
                    num += ParseDurationValueFinder(value, "s");
                }
                if (value.Contains("m"))
                {
                    num += ParseDurationValueFinder(value, "m") * 60;
                }
                if (value.Contains("h"))
                {
                    num += (ParseDurationValueFinder(value, "h") * 60) * 60;
                }
                if (value.Contains("d"))
                {
                    num += ((ParseDurationValueFinder(value, "d") * 60) * 60) * 0x18;
                }
                if (num == 0)
                {
                    num = Convert.ToInt32(value);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                ProjectData.ClearProjectError();
            }
            return num;
        }

        private static int ParseDurationValueFinder(string value, string identifier)
        {
            int num3;
            try
            {
                value = value.ToLower();
                int index = value.IndexOf(identifier);
                int startIndex = index - 1;
                while ((startIndex > -1) && IsNumeric(value.Substring(startIndex, 1)))
                {
                    startIndex--;
                }
                num3 = Convert.ToInt32(value.Substring(startIndex, index));
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                num3 = 0;
                ProjectData.ClearProjectError();
            }
            return num3;
        }

        public static int StringSimilarity(string a, string b)
        {
            if (string.IsNullOrEmpty(b) | string.IsNullOrEmpty(b))
            {
                return 0;
            }
            if (a == b)
            {
                return 100;
            }
            int[,] numArray = new int[a.Length + 1, b.Length + 1];
            int upperBound = numArray.GetUpperBound(0);
            for (int i = 0; i <= upperBound; i++)
            {
                numArray[i, 0] = i;
            }
            int num13 = numArray.GetUpperBound(1);
            for (int j = 0; j <= num13; j++)
            {
                numArray[0, j] = j;
            }
            int num14 = numArray.GetUpperBound(0);
            for (int k = 1; k <= num14; k++)
            {
                int num15 = numArray.GetUpperBound(1);
                for (int m = 1; m <= num15; m++)
                {
                    int num = Convert.ToInt32(a[k - 1] != b[m - 1]);
                    int num3 = numArray[k - 1, m] + 1;
                    int num4 = numArray[k, m - 1] + 1;
                    int num5 = numArray[k - 1, m - 1] + num;
                    numArray[k, m] = Math.Min(Math.Min(num3, num4), num5);
                }
            }
            int num6 = numArray[numArray.GetUpperBound(0), numArray.GetUpperBound(1)];
            int length = a.Length;
            if (b.Length > length)
            {
                length = b.Length;
            }
            return Convert.ToInt32(Math.Abs((double) ((1.0 - (((double) num6) / ((double) length))) * 100.0)));
        }

        public static byte[] StringToUTF8ByteArray(string value)
        {
            return new UTF8Encoding().GetBytes(value);
        }

        public static string TimespanToTime(TimeSpan value, string separator)
        {
            return (value.Hours.ToString("00") + separator + value.Minutes.ToString("00"));
        }

        public static bool TrueOrFalse(object value)
        {
            if (HasValue(RuntimeHelpers.GetObjectValue(value)))
            {
                string str = value.ToString().Trim().ToUpper();
                switch (str)
                {
                    case "1":
                    case "TRUE":
                    case "YES":
                    case "ON":
                    case "ENABLE":
                        return true;
                }
                if (((str != "0") && (str != "FALSE")) && (((str != "NO") && (str != "OFF")) && (str != "DISABLE")))
                {
                    throw new InvalidOperationException(value.ToString());
                }
            }
            return false;
        }

        public static string UTF8ByteArrayToString(byte[] value)
        {
            return new UTF8Encoding().GetString(value);
        }
    }
}
