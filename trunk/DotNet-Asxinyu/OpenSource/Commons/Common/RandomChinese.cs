namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;

    public class RandomChinese
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetRandomChars(int Length, params int[] Seed)
        {
            Random random;
            char[] separator = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd726).ToCharArray();
            string str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd72c);
            string[] strArray = str2.Split(separator, str2.Length);
            string str3 = string.Empty;
            if ((Seed != null) && (Seed.Length > 0))
            {
                random = new Random(Seed[0]);
            }
            else
            {
                random = new Random();
            }
            for (int i = 0; i < Length; i++)
            {
                str3 = str3 + strArray[random.Next(strArray.Length)];
            }
            return str3;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetRandomChinese(int strlength)
        {
            Encoding encoding = Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6b6));
            object[] objArray = qCpqRb2bV(strlength);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < strlength; i++)
            {
                string str = encoding.GetString((byte[]) Convert.ChangeType(objArray[i], typeof(byte[])));
                builder.Append(str);
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetRandomChinese2(int strlength)
        {
            int num3;
            string[] strArray = new string[strlength];
            Random random = new Random();
            for (num3 = 0; num3 < strlength; num3++)
            {
                int num2;
                int num = random.Next(0x10, 0x58);
                if (num == 0x37)
                {
                    num2 = random.Next(1, 90);
                }
                else
                {
                    num2 = random.Next(1, 0x5e);
                }
                strArray[num3] = Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd822)).GetString(new byte[] { Convert.ToByte((int) (num + 160)), Convert.ToByte((int) (num2 + 160)) });
            }
            StringBuilder builder = new StringBuilder();
            for (num3 = 0; num3 < strArray.Length; num3++)
            {
                builder.Append(strArray[num3]);
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetRandomNumber(int Length)
        {
            return GetRandomNumber(Length, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetRandomNumber(int Length, bool Sleep)
        {
            if (Sleep)
            {
                Thread.Sleep(3);
            }
            string str = "";
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                str = str + random.Next(10).ToString();
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetRandomPureChar(int Length)
        {
            return GetRandomPureChar(Length, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetRandomPureChar(int Length, bool Sleep)
        {
            if (Sleep)
            {
                Thread.Sleep(3);
            }
            char[] chArray = new char[] { 
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 
                'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
             };
            string str = "";
            int length = chArray.Length;
            Random random = new Random(~((int) DateTime.Now.Ticks));
            for (int i = 0; i < Length; i++)
            {
                int index = random.Next(0, length);
                str = str + chArray[index];
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static object[] qCpqRb2bV(int num1)
        {
            string[] strArray = new string[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6c6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6cc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6d2), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6d8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6de), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6e4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6ea), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6f0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6f6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd6fc), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd702), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd708), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd70e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd714), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd71a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd720) };
            Random random = new Random();
            object[] objArray = new object[num1];
            for (int i = 0; i < num1; i++)
            {
                int num3;
                int num5;
                int index = random.Next(11, 14);
                string str = strArray[index].Trim();
                random = new Random((index * ((int) DateTime.Now.Ticks)) + i);
                if (index == 13)
                {
                    num3 = random.Next(0, 7);
                }
                else
                {
                    num3 = random.Next(0, 0x10);
                }
                string str2 = strArray[num3].Trim();
                random = new Random((num3 * ((int) DateTime.Now.Ticks)) + i);
                int num4 = random.Next(10, 0x10);
                string str3 = strArray[num4].Trim();
                random = new Random((num4 * ((int) DateTime.Now.Ticks)) + i);
                if (num4 == 10)
                {
                    num5 = random.Next(1, 0x10);
                }
                else if (num4 == 15)
                {
                    num5 = random.Next(0, 15);
                }
                else
                {
                    num5 = random.Next(0, 0x10);
                }
                string str4 = strArray[num5].Trim();
                byte num6 = Convert.ToByte(str + str2, 0x10);
                byte num7 = Convert.ToByte(str3 + str4, 0x10);
                byte[] buffer = new byte[] { num6, num7 };
                objArray.SetValue(buffer, i);
            }
            return objArray;
        }
    }
}

