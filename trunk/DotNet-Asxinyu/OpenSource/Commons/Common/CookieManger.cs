namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class CookieManger
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ClearCookies(WebBrowser browser)
        {
            if ((browser != null) && (browser.Document != null))
            {
                ClearCookies(browser.Document.Cookie, browser.Url.ToString());
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ClearCookies(string ck, string url)
        {
            string[] cKS = GetCKS(ck);
            List<string> domains = GetDomains(url);
            for (int i = 0; i < cKS.Length; i++)
            {
                string[] strArray2 = cKS[i].Split(new char[] { '=' });
                for (int j = 0; j < domains.Count; j++)
                {
                    InternetSetCookie(domains[j], strArray2[0], kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x56a0));
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ClearCookiesFiles()
        {
            DirectoryInfo info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
            foreach (FileInfo info2 in info.GetFiles())
            {
                try
                {
                    info2.Delete();
                }
                catch
                {
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCK(CookieCollection cc)
        {
            string str = "";
            for (int i = 0; i < cc.Count; i++)
            {
                string str3 = str;
                str = str3 + cc[i].Name + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5672) + cc[i].Value + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5678);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCK(WebBrowser browser)
        {
            string cK = "";
            if ((browser.Document != null) && (browser.Document.Cookie != null))
            {
                cK = GetCK(GetCKS(browser.Document.Cookie));
            }
            return cK;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCK(string[] cks)
        {
            int num;
            string str = "";
            List<string> list = new List<string>();
            for (num = 0; num < cks.Length; num++)
            {
                if ((cks[num].Trim() != "") && !IncludeCK(list, cks[num]))
                {
                    list.Add(cks[num].Trim());
                }
            }
            for (num = 0; num < list.Count; num++)
            {
                str = str + list[num] + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x566c);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CookieCollection GetCK(string ck, string url)
        {
            CookieCollection cookies = new CookieCollection();
            string host = "";
            try
            {
                Uri uri = new Uri(url);
                host = uri.Host;
            }
            catch
            {
            }
            string[] cKS = GetCKS(ck);
            for (int i = 0; i < cKS.Length; i++)
            {
                if (cKS[i].IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x567e)) > -1)
                {
                    try
                    {
                        string str2 = cKS[i].Substring(0, cKS[i].IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5684)));
                        string str3 = cKS[i].Substring(cKS[i].IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x568a)) + 1);
                        Cookie cookie = new Cookie {
                            Name = str2.Trim(),
                            Value = str3.Trim(),
                            Domain = host
                        };
                        cookies.Add(cookie);
                    }
                    catch
                    {
                    }
                }
            }
            return cookies;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetCKS(string ck)
        {
            if (ck != null)
            {
                return ck.Split(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5666).ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            return new string[0];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetDomains(string url)
        {
            List<string> list = new List<string>();
            try
            {
                url = url.Remove(url.IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5690)));
            }
            catch
            {
            }
            try
            {
                Uri uri = new Uri(url);
                string item = uri.Scheme + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5696) + uri.Host;
                for (int i = 0; i < uri.Segments.Length; i++)
                {
                    item = item + uri.Segments[i];
                    list.Add(item);
                }
            }
            catch
            {
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static List<string> GetDomains(WebBrowser browser)
        {
            if ((browser != null) && (browser.Url != null))
            {
                return GetDomains(browser.Url.ToString());
            }
            return new List<string>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CookieContainer GetUriCookieContainer(Uri uri)
        {
            CookieContainer container = null;
            int capacity = 0x100;
            StringBuilder cookieData = new StringBuilder(capacity);
            if (!InternetGetCookie(uri.ToString(), null, cookieData, ref capacity))
            {
                if (capacity < 0)
                {
                    return null;
                }
                cookieData = new StringBuilder(capacity);
                if (!InternetGetCookie(uri.ToString(), null, cookieData, ref capacity))
                {
                    return null;
                }
            }
            if (cookieData.Length > 0)
            {
                container = new CookieContainer();
                container.SetCookies(uri, cookieData.ToString().Replace(';', ','));
            }
            return container;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected static bool IncludeCK(List<string> cks, string ck)
        {
            try
            {
                string str = ck.Remove(ck.IndexOf('=') + 1).Trim().ToLower();
                for (int i = 0; i < cks.Count; i++)
                {
                    if (cks[i].ToLower().Trim().IndexOf(str) != -1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        [DllImport("wininet.dll", SetLastError=true)]
        public static extern bool InternetGetCookie(string url, string cookieName, StringBuilder cookieData, ref int size);
        [DllImport("wininet.dll", CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string PrintCookies(CookieContainer cookies, Uri uri)
        {
            CookieCollection cookies2 = cookies.GetCookies(uri);
            StringBuilder builder = new StringBuilder();
            foreach (Cookie cookie in cookies2)
            {
                builder.AppendLine(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5654), cookie.Name, cookie.Value));
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCKAppendToCC(CookieCollection cc, string ck, string url)
        {
            CookieCollection cK = GetCK(ck, url);
            for (int i = 0; i < cK.Count; i++)
            {
                cc.Add(cK[i]);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCKToBrowser(WebBrowser browser, string ck)
        {
            if (browser.Document != null)
            {
                string[] cKS = GetCKS(ck);
                for (int i = 0; i < cKS.Length; i++)
                {
                    if (cKS[i] != "")
                    {
                        browser.Document.Cookie = cKS[i];
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCKToSystem(CookieCollection cc, string url)
        {
            List<string> domains = GetDomains(url);
            for (int i = 0; i < cc.Count; i++)
            {
                for (int j = 0; j < domains.Count; j++)
                {
                    InternetSetCookie(domains[j], cc[i].Name, cc[i].Value);
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCKToSystem(string ck, string url)
        {
            string[] cKS = GetCKS(ck);
            for (int i = 0; i < cKS.Length; i++)
            {
                string[] strArray2 = cKS[i].Split(new char[] { '=' });
                InternetSetCookie(url, strArray2[0], (strArray2.Length > 1) ? strArray2[1] : "");
            }
        }

        public class Test
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            private static void t00qRSolC(string[])
            {
                Uri uri = new Uri(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x56fa));
                CookieManger.PrintCookies(CookieManger.GetUriCookieContainer(uri), uri);
                Console.ReadKey();
            }
        }
    }
}

