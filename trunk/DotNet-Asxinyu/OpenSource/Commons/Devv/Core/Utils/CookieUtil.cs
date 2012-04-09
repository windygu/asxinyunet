namespace Devv.Core.Utils
{
    using System;
    using System.Web;

    public class CookieUtil
    {
        private CookieUtil()
        {
        }

        public static string GetCookie(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie == null)
            {
                return string.Empty;
            }
            return cookie.Value;
        }

        public static DateTime GetCookie(string name, DateTime defaultValue)
        {
            string cookie = GetCookie(name);
            if (string.IsNullOrEmpty(cookie))
            {
                return defaultValue;
            }
            return Convert.ToDateTime(cookie);
        }

        public static int GetCookie(string name, int defaultValue)
        {
            string cookie = GetCookie(name);
            if (string.IsNullOrEmpty(cookie))
            {
                return defaultValue;
            }
            return Convert.ToInt32(cookie);
        }

        public static string GetCookie(string name, string defaultValue)
        {
            string cookie = GetCookie(name);
            if (string.IsNullOrEmpty(cookie))
            {
                return defaultValue;
            }
            return cookie;
        }

        public static void SetCookie(string name, string value)
        {
            SetCookie(name, value, DateTime.Now.AddDays(1.0));
        }

        public static void SetCookie(string name, DateTime value, DateTime expires)
        {
            SetCookie(name, value.ToString("yyyy-MM-dd HH:mm:ss"), expires);
        }

        public static void SetCookie(string name, string value, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(name, value) {
                Expires = expires
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
