namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;

    public class CommandLine
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool mUvqAX6rk(string text1)
        {
            return (text1.StartsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa32)) || text1.StartsWith(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa38)));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CommandArgs Parse(string[] args)
        {
            char[] trimChars = new char[] { '=' };
            char[] chArray2 = new char[] { '-', '\\' };
            CommandArgs args2 = new CommandArgs();
            int num = -1;
            for (string str = XPOfx7u7N(args, ref num); str != null; str = XPOfx7u7N(args, ref num))
            {
                if (mUvqAX6rk(str))
                {
                    string key = str.TrimStart(chArray2).TrimEnd(trimChars);
                    string str3 = null;
                    if (key.Contains(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa1a)))
                    {
                        string[] strArray = key.Split(trimChars, 2);
                        if ((strArray.Length == 2) && (strArray[1] != string.Empty))
                        {
                            key = strArray[0];
                            str3 = strArray[1];
                        }
                    }
                    while (str3 == null)
                    {
                        string str4 = XPOfx7u7N(args, ref num);
                        if (str4 != null)
                        {
                            if (mUvqAX6rk(str4))
                            {
                                num--;
                                str3 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa20);
                            }
                            else if (str4 != kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa2c))
                            {
                                str3 = str4.TrimStart(trimChars);
                            }
                        }
                    }
                    args2.ArgPairs.Add(key, str3);
                }
                else if (str != string.Empty)
                {
                    args2.Params.Add(str);
                }
            }
            return args2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string XPOfx7u7N(string[] textArray1, ref int numRef1)
        {
            numRef1++;
            while (numRef1 < textArray1.Length)
            {
                string str = textArray1[numRef1].Trim();
                if (str != string.Empty)
                {
                    return str;
                }
                numRef1++;
            }
            return null;
        }
    }
}

