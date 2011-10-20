namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class CookieManger
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public CookieManger()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ClearCookies(WebBrowser browser)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ClearCookies(string ck, string url)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ClearCookiesFiles()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCK(CookieCollection cc)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCK(WebBrowser browser)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCK(string[] cks)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CookieCollection GetCK(string ck, string url)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetCKS(string ck)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetDomains(string url)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetDomains(WebBrowser browser)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CookieContainer GetUriCookieContainer(Uri uri)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected static bool IncludeCK(List<string> cks, string ck)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("wininet.dll", SetLastError=true)]
        public static extern bool InternetGetCookie(string url, string cookieName, StringBuilder cookieData, ref int size);
        [DllImport("wininet.dll", CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string PrintCookies(CookieContainer cookies, Uri uri)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCKAppendToCC(CookieCollection cc, string ck, string url)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCKToBrowser(WebBrowser browser, string ck)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCKToSystem(CookieCollection cc, string url)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCKToSystem(string ck, string url)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        public class Test
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            public Test()
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void t00qRSolC(string[])
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }
    }
}
