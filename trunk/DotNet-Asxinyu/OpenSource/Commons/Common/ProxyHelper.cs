namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public class ProxyHelper
    {
        private const int GPY6Re0PF = 0x25;
        private const int JiYUNJcCW = 0x27;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string 408MSTia8(WebResponse response1, Encoding encoding1)
        {
            string str2;
            try
            {
                StreamReader reader = new StreamReader(response1.GetResponseStream(), encoding1);
                string str = reader.ReadToEnd();
                reader.Close();
                str2 = str;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str2;
        }

        [DllImport("wininet.dll", EntryPoint="InternetSetOption", SetLastError=true)]
        private static extern bool mUvqAX6rk(IntPtr, int, IntPtr, int);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SetIEProxy(string ProxyServer, int EnableProxy)
        {
            string str = "";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x752), true);
            key.SetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7cc), EnableProxy);
            if (!(ProxyServer.Equals("") || (EnableProxy != 1)))
            {
                key.SetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7e6), ProxyServer);
                key.SetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x800), 1);
                str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x81a);
            }
            if (EnableProxy == 0)
            {
                key.SetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x82c), 0);
                str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x846);
            }
            key.Close();
            XPOfx7u7N();
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetIESupportWap()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5fc), true);
            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x678));
            }
            key.SetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6f4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x702));
            key.Close();
            XPOfx7u7N();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetProxySetting(WebRequest request, ProxySettingEntity Proxy)
        {
            if (Proxy != null)
            {
                WebProxy defaultProxy = WebProxy.GetDefaultProxy();
                if (((Proxy.Ip != null) && (Proxy.Ip != "")) && (Proxy.Port != 0))
                {
                    defaultProxy.Address = new Uri(string.Concat(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x91c), Proxy.Ip, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x92e), Proxy.Port, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x934) }));
                    if (!(string.IsNullOrEmpty(Proxy.UserName) || string.IsNullOrEmpty(Proxy.Password)))
                    {
                        defaultProxy.Credentials = new NetworkCredential(Proxy.UserName, Proxy.Password);
                    }
                }
                request.Proxy = defaultProxy;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool TestProxy(ProxySettingEntity setting, TestEntity te)
        {
            if (setting == null)
            {
                return false;
            }
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(te.TestUrl);
            WebProxy defaultProxy = WebProxy.GetDefaultProxy();
            if (((setting.Ip != null) && (setting.Ip != "")) && (setting.Port != 0))
            {
                defaultProxy.Address = new Uri(string.Concat(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x858), setting.Ip, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x86a), setting.Port, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x870) }));
                if (!(string.IsNullOrEmpty(setting.UserName) || string.IsNullOrEmpty(setting.Password)))
                {
                    defaultProxy.Credentials = new NetworkCredential(setting.UserName, setting.Password);
                }
            }
            request.Proxy = defaultProxy;
            request.Method = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x876);
            request.UserAgent = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x880);
            WebResponse response = request.GetResponse();
            string str = 408MSTia8(response, Encoding.GetEncoding(te.TestWebEncoding));
            response.Close();
            return str.Contains(te.TestWebTitle);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void XPOfx7u7N()
        {
            mUvqAX6rk(IntPtr.Zero, 0x27, IntPtr.Zero, 0);
            mUvqAX6rk(IntPtr.Zero, 0x25, IntPtr.Zero, 0);
        }
    }
}

