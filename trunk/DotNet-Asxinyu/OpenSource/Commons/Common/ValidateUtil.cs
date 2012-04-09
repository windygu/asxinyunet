namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ValidateUtil
    {
        private static Regex 37jAJ3Bnt = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1758));
        private static Regex 408MSTia8 = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x16b0));
        private static Regex GPY6Re0PF = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x16d8));
        private static Regex JiYUNJcCW = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x170a));
        private static Regex mUvqAX6rk = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x167e));
        private static Regex XPOfx7u7N = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1692));

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CheckMathLength(string inputData, int maxLength)
        {
            if ((inputData != null) && (inputData != string.Empty))
            {
                inputData = inputData.Trim();
                if (inputData.Length > maxLength)
                {
                    inputData = inputData.Substring(0, maxLength);
                }
            }
            return inputData;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Decode(string str)
        {
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x161c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1628));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x162e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x163a));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1640), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x164c));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1652), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1662));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1668), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1678));
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Encode(string str)
        {
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1598), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x159e));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15ac), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15b2));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15ba), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15c0));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15d0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15d6));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15e6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15ec));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15f8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x15fe));
            str = str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x160a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1610));
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetCHZNLength(string inputData)
        {
            byte[] bytes = new ASCIIEncoding().GetBytes(inputData);
            int num = 0;
            for (int i = 0; i <= (bytes.Length - 1); i++)
            {
                if (bytes[i] == 0x3f)
                {
                    num++;
                }
                num++;
            }
            return num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetStringLength(string stringValue)
        {
            return Encoding.Default.GetBytes(stringValue).Length;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsBase64String(string str)
        {
            return Regex.IsMatch(str, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1016));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsDate(string strValue)
        {
            return Regex.IsMatch(strValue, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x10ac));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsDateHourMinute(string strValue)
        {
            return Regex.IsMatch(strValue, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1416));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsDecimal(string inputData)
        {
            return 408MSTia8.Match(inputData).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsDecimalSign(string inputData)
        {
            return GPY6Re0PF.Match(inputData).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsEmail(string inputData)
        {
            return JiYUNJcCW.Match(inputData).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsGuid(string guid)
        {
            if (string.IsNullOrEmpty(guid))
            {
                return false;
            }
            return Regex.IsMatch(guid, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x103c), RegexOptions.IgnoreCase);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsHasCHZN(string inputData)
        {
            return 37jAJ3Bnt.Match(inputData).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsIdCard(string idCard)
        {
            if (string.IsNullOrEmpty(idCard))
            {
                return false;
            }
            if (idCard.Length == 15)
            {
                return Regex.IsMatch(idCard, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc94));
            }
            return ((idCard.Length == 0x12) && Regex.IsMatch(idCard, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd02), RegexOptions.IgnoreCase));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsNumber(string inputData)
        {
            return mUvqAX6rk.Match(inputData).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsNumberSign(string inputData)
        {
            return XPOfx7u7N.Match(inputData).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidDomain(string host)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xffc));
            if (host.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x100a)) == -1)
            {
                return false;
            }
            return !regex.IsMatch(host.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1010), string.Empty));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidInt(string val)
        {
            return Regex.IsMatch(val, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc6e));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidIP(string ip)
        {
            return Regex.IsMatch(ip, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf72));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidMobile(string mobile)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xdf8), RegexOptions.None);
            return regex.Match(mobile).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xc42));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidPhone(string phone)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xdb4), RegexOptions.None);
            return regex.Match(phone).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidPhoneAndMobile(string number)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe18), RegexOptions.None);
            return regex.Match(number).Success;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidURL(string url)
        {
            return Regex.IsMatch(url, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xe7a));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidUserName(string userName)
        {
            int stringLength = GetStringLength(userName);
            return (((stringLength >= 4) && (stringLength <= 20)) && Regex.IsMatch(userName, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xbfc)));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool IsValidZip(string zip)
        {
            Regex regex = new Regex(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xda2), RegexOptions.None);
            return regex.Match(zip).Success;
        }
    }
}

