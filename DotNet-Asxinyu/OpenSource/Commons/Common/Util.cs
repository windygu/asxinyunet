namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public sealed class Util
    {
        private static Random dT3f0t4t3 = new Random((int) DateTime.Now.Ticks);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private Util()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string 01FqmBarm(string text1)
        {
            byte[] bytes = Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8746)).GetBytes(text1);
            if (bytes.Length > 1)
            {
                int num = bytes[0];
                int num2 = bytes[1];
                int num3 = (num << 8) + num2;
                int[] numArray = new int[] { 
                    0xb0a1, 0xb0c5, 0xb2c1, 0xb4ee, 0xb6ea, 0xb7a2, 0xb8c1, 0xb9fe, 0xbbf7, 0xbbf7, 0xbfa6, 0xc0ac, 0xc2e8, 0xc4c3, 0xc5b6, 0xc5be, 
                    0xc6da, 0xc8bb, 0xc8f6, 0xcbfa, 0xcdda, 0xcdda, 0xcdda, 0xcef4, 0xd1b9, 0xd4d1
                 };
                for (int i = 0; i < 0x1a; i++)
                {
                    int num5 = 0xd7fa;
                    if (i != 0x19)
                    {
                        num5 = numArray[i + 1];
                    }
                    if ((numArray[i] <= num3) && (num3 < num5))
                    {
                        return Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8756)).GetString(new byte[] { (byte) (0x41 + i) });
                    }
                }
                return string.Empty;
            }
            return text1;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool AreObjectsEqual(object o1, object o2)
        {
            int num;
            Type type = o1.GetType();
            Type type2 = o2.GetType();
            PropertyInfo[] properties = type.GetProperties();
            PropertyInfo[] infoArray2 = type2.GetProperties();
            for (num = 0; num < properties.Length; num++)
            {
                try
                {
                    PropertyInfo info = properties[num];
                    PropertyInfo info2 = infoArray2[num];
                    if ((!info.GetValue(o1, null).Equals(null) && !info2.GetValue(o2, null).Equals(null)) && !info.GetValue(o1, null).Equals(info2.GetValue(o2, null)))
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            FieldInfo[] fields = type.GetFields();
            FieldInfo[] infoArray4 = type2.GetFields();
            for (num = 0; num < fields.Length; num++)
            {
                try
                {
                    FieldInfo info3 = fields[num];
                    FieldInfo info4 = infoArray4[num];
                    if ((!info3.GetValue(o1).Equals(null) && !info4.GetValue(o2).Equals(null)) && !info3.GetValue(o1).Equals(info4.GetValue(o2)))
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetAcronym(string chinese)
        {
            int length = chinese.Length;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                char ch = chinese[i];
                builder.Append(01FqmBarm(ch.ToString()));
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsDateTime(object o)
        {
            return (o is DateTime);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsNumeric(object o)
        {
            return ((((((o is short) || (o is int)) || ((o is long) || (o is decimal))) || (((o is double) || (o is byte)) || ((o is sbyte) || (o is float)))) || ((o is ushort) || (o is uint))) || (o is ulong));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Join<T>(IList<T> list)
        {
            return Join<T>(list, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8766));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Join(IList<string> list)
        {
            return Join<string>(list, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x876c));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Join(IList<string> list, string c)
        {
            return Join<string>(list, c);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Join<T>(IList<T> list, string c)
        {
            if ((list != null) && (list.Count > 0))
            {
                StringBuilder builder = new StringBuilder();
                foreach (T local in list)
                {
                    builder.Append(c);
                    builder.Append(local.ToString());
                }
                if (!string.IsNullOrEmpty(c))
                {
                    return builder.ToString().Substring(c.Length);
                }
                return builder.ToString();
            }
            return string.Empty;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool RandomAction(int rate)
        {
            return (dT3f0t4t3.Next(100) < rate);
        }

        public static string WinFormName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                string executablePath = Application.ExecutablePath;
                int num = executablePath.LastIndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8772));
                int num2 = executablePath.ToLower().LastIndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8778));
                return executablePath.Substring(num + 1, (num2 - num) - 1);
            }
        }
    }
}

