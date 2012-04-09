namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class UnicodeHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ConvertSingle(string unicodeSingle)
        {
            if (unicodeSingle.Length != 4)
            {
                return null;
            }
            Encoding unicode = Encoding.Unicode;
            byte[] bytes = new byte[2];
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        bytes[1] = (byte) (bytes[1] + ((byte) (mUvqAX6rk(unicodeSingle[i]) * 0x10)));
                        break;

                    case 1:
                        bytes[1] = (byte) (bytes[1] + ((byte) mUvqAX6rk(unicodeSingle[i])));
                        break;

                    case 2:
                        bytes[0] = (byte) (bytes[0] + ((byte) (mUvqAX6rk(unicodeSingle[i]) * 0x10)));
                        break;

                    case 3:
                        bytes[0] = (byte) (bytes[0] + ((byte) mUvqAX6rk(unicodeSingle[i])));
                        break;
                }
            }
            char[] chars = new char[unicode.GetCharCount(bytes, 0, bytes.Length)];
            unicode.GetChars(bytes, 0, bytes.Length, chars, 0);
            return new string(chars);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GB2Unicode(string str)
        {
            string str2 = "";
            Encoding encoding = Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a8c));
            Encoding unicode = Encoding.Unicode;
            byte[] bytes = encoding.GetBytes(str);
            for (int i = 0; i < bytes.Length; i++)
            {
                string str3 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a9c) + bytes[i].ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2aa2));
                str2 = str2 + str3;
            }
            return str2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static ushort mUvqAX6rk(char ch1)
        {
            switch (ch1)
            {
                case 'A':
                case 'a':
                    return 10;

                case 'B':
                case 'b':
                    return 11;

                case 'C':
                case 'c':
                    return 12;

                case 'D':
                case 'd':
                    return 13;

                case 'E':
                case 'e':
                    return 14;

                case 'F':
                case 'f':
                    return 15;
            }
            return ushort.Parse(ch1.ToString());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string StringToUnicode(string str)
        {
            string str2 = "";
            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    str2 = str2 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a56) + ((int) str[i]).ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a5e));
                }
            }
            return str2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string UnicodeToString(string str)
        {
            string str2 = "";
            str = CRegex.Replace(str, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a64), "", 0);
            if (!string.IsNullOrEmpty(str))
            {
                string[] strArray = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a70), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a78)).Split(new char[] { '㊣' });
                try
                {
                    str2 = str2 + strArray[0];
                    for (int i = 1; i < strArray.Length; i++)
                    {
                        string str3 = strArray[i];
                        if (!(string.IsNullOrEmpty(str3) || (str3.Length < 4)))
                        {
                            str3 = strArray[i].Substring(0, 4);
                            str2 = str2 + ((char) int.Parse(str3, NumberStyles.HexNumber));
                            str2 = str2 + strArray[i].Substring(4);
                        }
                    }
                }
                catch (FormatException)
                {
                    str2 = str2 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2a7e);
                }
            }
            return str2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string UtoGB(string str)
        {
            int num;
            string[] strArray = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2aa8), "").Split(new char[] { 'u' });
            byte[] bytes = new byte[strArray.Length - 1];
            for (num = 1; num < strArray.Length; num++)
            {
                bytes[num - 1] = Convert.ToByte(XPOfx7u7N(strArray[num]));
            }
            char[] chars = Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2aae)).GetChars(bytes);
            string str2 = "";
            for (num = 0; num < chars.Length; num++)
            {
                str2 = str2 + chars[num].ToString();
            }
            return str2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string XPOfx7u7N(string text1)
        {
            if (text1.Length == 2)
            {
                text1 = text1.ToUpper();
                string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2abe);
                int num = (str.IndexOf(text1.Substring(0, 1)) * 0x10) + str.IndexOf(text1.Substring(1, 1));
                return num.ToString();
            }
            return "";
        }
    }
}

