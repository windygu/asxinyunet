namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;

    public class RMBUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CmycurD(decimal num)
        {
            string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae10);
            string str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae28);
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            int num4 = 0;
            num = Math.Round(Math.Abs(num), 2);
            str4 = ((long) (num * 100M)).ToString();
            int length = str4.Length;
            if (length > 15)
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae4a);
            }
            str2 = str2.Substring(15 - length);
            for (int i = 0; i < length; i++)
            {
                str3 = str4.Substring(i, 1);
                int startIndex = Convert.ToInt32(str3);
                if ((((i != (length - 3)) && (i != (length - 7))) && (i != (length - 11))) && (i != (length - 15)))
                {
                    if (str3 == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae52))
                    {
                        str6 = "";
                        str7 = "";
                        num4++;
                    }
                    else if ((str3 != kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae58)) && (num4 != 0))
                    {
                        str6 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae5e) + str.Substring(startIndex, 1);
                        str7 = str2.Substring(i, 1);
                        num4 = 0;
                    }
                    else
                    {
                        str6 = str.Substring(startIndex, 1);
                        str7 = str2.Substring(i, 1);
                        num4 = 0;
                    }
                }
                else if ((str3 != kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae64)) && (num4 != 0))
                {
                    str6 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae6a) + str.Substring(startIndex, 1);
                    str7 = str2.Substring(i, 1);
                    num4 = 0;
                }
                else if ((str3 != kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae70)) && (num4 == 0))
                {
                    str6 = str.Substring(startIndex, 1);
                    str7 = str2.Substring(i, 1);
                    num4 = 0;
                }
                else if ((str3 == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae76)) && (num4 >= 3))
                {
                    str6 = "";
                    str7 = "";
                    num4++;
                }
                else if (length >= 11)
                {
                    str6 = "";
                    num4++;
                }
                else
                {
                    str6 = "";
                    str7 = str2.Substring(i, 1);
                    num4++;
                }
                if ((i == (length - 11)) || (i == (length - 3)))
                {
                    str7 = str2.Substring(i, 1);
                }
                str5 = str5 + str6 + str7;
                if ((i == (length - 1)) && (str3 == kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae7c)))
                {
                    str5 = str5 + '整';
                }
            }
            if (num == 0M)
            {
                str5 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae82);
            }
            return str5;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CmycurD(string numstr)
        {
            try
            {
                return CmycurD(Convert.ToDecimal(numstr));
            }
            catch
            {
                return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae8c);
            }
        }
    }
}

