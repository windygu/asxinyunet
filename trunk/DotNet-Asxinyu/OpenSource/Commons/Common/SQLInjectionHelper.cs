namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using System.Web;

    public class SQLInjectionHelper
    {
        private const string 408MSTia8 = "[-|;|,|/|(|)|[|]|}|{|%|@|*|!|']";
        private const string XPOfx7u7N = ".*(select|insert|delete|from|count(|drop table|update|truncate|asc(|mid(|char(|xp_cmdshell|exec master|netlocalgroup administrators|:|net user|\"|or|and).*";

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string mUvqAX6rk()
        {
            string[] strArray = new string[] { 
                kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x17f8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1802), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x180e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x181e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x182e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x183e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x184e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x185c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1868), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1874), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x187e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x188a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1892), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1898), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x189e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x18a4), 
                kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x18aa), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x18b0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x18b6), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x18c0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x18ca), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x18da), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x18ee), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x18fa), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x190c), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1920), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1934), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x194e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x195a), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1994)
             };
            string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x19d2);
            for (int i = 0; i < (strArray.Length - 1); i++)
            {
                str = str + strArray[i] + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x19dc);
            }
            return (str + strArray[strArray.Length - 1] + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x19e2));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ValidData(string inputData)
        {
            return Regex.IsMatch(inputData.ToLower(), mUvqAX6rk());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ValidUrlGetData()
        {
            bool flag = false;
            for (int i = 0; i < HttpContext.Current.Request.QueryString.Count; i++)
            {
                flag = ValidData(HttpContext.Current.Request.QueryString[i].ToString());
                if (flag)
                {
                    LogHelper.Info(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x17b0) + HttpContext.Current.Request.QueryString[i].ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x17ce) + HttpContext.Current.Request.RawUrl + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x17e2) + HttpContext.Current.Request.UserHostAddress + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x17f2));
                    return flag;
                }
            }
            return flag;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ValidUrlPostData()
        {
            bool flag = false;
            for (int i = 0; i < HttpContext.Current.Request.Form.Count; i++)
            {
                flag = ValidData(HttpContext.Current.Request.Form[i].ToString());
                if (flag)
                {
                    LogHelper.Info(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1766) + HttpContext.Current.Request.Form[i].ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1786) + HttpContext.Current.Request.RawUrl + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x179a) + HttpContext.Current.Request.UserHostAddress + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x17aa));
                    return flag;
                }
            }
            return flag;
        }
    }
}

