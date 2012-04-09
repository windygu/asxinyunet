namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;

    public sealed class ConvertHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int BytesToInt32(byte[] data)
        {
            if (data.Length < 4)
            {
                return 0;
            }
            int num = 0;
            if (data.Length >= 4)
            {
                byte[] dst = new byte[4];
                Buffer.BlockCopy(data, 0, dst, 0, 4);
                num = BitConverter.ToInt32(dst, 0);
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string BytesToString(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ConvertBase(string value, int from, int to)
        {
            if (!qCpqRb2bV(from))
            {
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd46c));
            }
            if (!qCpqRb2bV(to))
            {
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd49c));
            }
            string str = Convert.ToString(Convert.ToInt32(value, from), to);
            if (to == 2)
            {
                switch (str.Length)
                {
                    case 3:
                        return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd4ec) + str);

                    case 4:
                        return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd4e0) + str);

                    case 5:
                        return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd4d6) + str);

                    case 6:
                        return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd4ce) + str);

                    case 7:
                        return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd4c8) + str);
                }
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T ConvertTo<T>(object data)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return default(T);
            }
            object obj2 = ConvertTo(data, typeof(T));
            if (obj2 == null)
            {
                return default(T);
            }
            return (T) obj2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object ConvertTo(object data, Type targetType)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return null;
            }
            Type type = data.GetType();
            if (targetType == type)
            {
                return data;
            }
            if (((targetType == typeof(Guid)) || (targetType == typeof(Guid?))) && (type == typeof(string)))
            {
                if (string.IsNullOrEmpty(data.ToString()))
                {
                    return null;
                }
                return new Guid(data.ToString());
            }
            if (targetType.IsEnum)
            {
                try
                {
                    return Enum.Parse(targetType, data.ToString(), true);
                }
                catch
                {
                    return Enum.ToObject(targetType, data);
                }
            }
            if (targetType.IsGenericType)
            {
                targetType = targetType.GetGenericArguments()[0];
            }
            return Convert.ChangeType(data, targetType);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ConvertToDBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '　')
                {
                    chArray[i] = ' ';
                }
                else if ((chArray[i] > 0xff00) && (chArray[i] < 0xff5f))
                {
                    chArray[i] = (char) (chArray[i] - 0xfee0);
                }
            }
            return new string(chArray);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ConvertToSBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == ' ')
                {
                    chArray[i] = '　';
                }
                else if (chArray[i] < '\x007f')
                {
                    chArray[i] = (char) (chArray[i] + 0xfee0);
                }
            }
            return new string(chArray);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool qCpqRb2bV(int num1)
        {
            return ((((num1 == 2) || (num1 == 8)) || (num1 == 10)) || (num1 == 0x10));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] StringToBytes(string text)
        {
            return Encoding.Default.GetBytes(text);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ToBoolean(object data, bool defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToBoolean(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ToBoolean(string data, bool defValue)
        {
            if (!string.IsNullOrEmpty(data))
            {
                bool result = false;
                if (bool.TryParse(data, out result))
                {
                    return result;
                }
            }
            return defValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ToBoolean<T>(T data, bool defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToBoolean(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime ToDateTime(string data, DateTime defValue)
        {
            if (!string.IsNullOrEmpty(data))
            {
                DateTime now = DateTime.Now;
                if (DateTime.TryParse(data, out now))
                {
                    return now;
                }
            }
            return defValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime ToDateTime<T>(T data, DateTime defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToDateTime(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DateTime ToDateTime(object data, DateTime defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToDateTime(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static decimal ToDecimal<T>(T data, decimal defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToDecimal(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static decimal ToDecimal(object data, decimal defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToDecimal(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static decimal ToDecimal(string data, decimal defValue)
        {
            if (!string.IsNullOrEmpty(data))
            {
                decimal result = 0M;
                if (decimal.TryParse(data, out result))
                {
                    return result;
                }
            }
            return defValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double ToDouble<T>(T data, double defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToDouble(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double ToDouble(object data, double defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToDouble(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double ToDouble(string data, double defValue)
        {
            if (!string.IsNullOrEmpty(data))
            {
                double result = 0.0;
                if (double.TryParse(data, out result))
                {
                    return result;
                }
            }
            return defValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double ToDouble(object data, int decimals, double defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Math.Round(Convert.ToDouble(data), decimals);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double ToDouble(string data, int decimals, double defValue)
        {
            if (!string.IsNullOrEmpty(data))
            {
                double result = 0.0;
                if (double.TryParse(data, out result))
                {
                    return Math.Round(result, decimals);
                }
            }
            return defValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static double ToDouble<T>(T data, int decimals, double defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Math.Round(Convert.ToDouble(data), decimals);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float ToFloat<T>(T data, float defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToSingle(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float ToFloat(object data, float defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToSingle(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static float ToFloat(string data, float defValue)
        {
            if (!string.IsNullOrEmpty(data))
            {
                float result = 0f;
                if (float.TryParse(data, out result))
                {
                    return result;
                }
            }
            return defValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ToInt32(object data, int defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToInt32(data);
            }
            catch
            {
                return defValue;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ToInt32(string data, int defValue)
        {
            if (!string.IsNullOrEmpty(data))
            {
                int result = 0;
                if (int.TryParse(data, out result))
                {
                    return result;
                }
            }
            return defValue;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int ToInt32<T>(T data, int defValue)
        {
            if ((data == null) || Convert.IsDBNull(data))
            {
                return defValue;
            }
            try
            {
                return Convert.ToInt32(data);
            }
            catch
            {
                return defValue;
            }
        }
    }
}

