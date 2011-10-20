namespace Utils
{
    using System;
    using System.Collections.Specialized;
    using System.Web;

    /// <summary><para>　</para>
    /// 类名：常用工具类——COOKIES操作类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------------</para><para>　WriteCookie：创建COOKIE对象并赋Value值或值集合 [+4重载]</para><para>　GetCookie：读取Cookie某个对象的Value值，返回Value值，如果对象本就不存在，则返回null</para><para>　DelCookie：删除COOKIE对象</para></summary>
    public class CookiesHelper
    {
        /// <summary>删除COOKIE对象</summary>
        /// <param name="CookiesName">Cookie对象名称</param>
        public static void DelCookie(string CookiesName)
        {
            HttpCookie cookie = new HttpCookie(CookiesName.Trim());
            cookie.Expires = DateTime.Now.AddYears(-5);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>读取Cookie某个对象的Value值，返回Value值，如果对象本就不存在，则返回null</summary>
        /// <param name="CookiesName">Cookie对象名称</param>
        /// <returns>返回对象的Value值，返回Value值，如果对象本就不存在，则返回null</returns>
        public static string GetCookies(string CookiesName)
        {
            if (HttpContext.Current.Request.Cookies[CookiesName] == null) return null;
            return EncyptHelper.DESDecrypt(HttpContext.Current.Request.Cookies[CookiesName].Value);
        }

        /// <summary>读取Cookie某个对象的Value值，返回Value值，如果对象本就不存在，则返回null</summary>
        /// <param name="CookiesName">Cookie对象名称</param>
        /// <param name="KeyName">键值</param>
        /// <returns>返回对象的Value值，返回Value值，如果对象本就不存在，则返回null</returns>
        public static string GetCookies(string CookiesName, string KeyName)
        {
            if (HttpContext.Current.Request.Cookies[CookiesName] == null) return null;
            string str = EncyptHelper.DESDecrypt(HttpContext.Current.Request.Cookies[CookiesName].Value);
            string str2 = KeyName + "=";
            if (0 == 0 && str.IndexOf(str2) == -1) return null;
            return EncyptHelper.DESDecrypt(HttpContext.Current.Request.Cookies[CookiesName][KeyName]);
        }

        /// <summary>   
        /// 创建COOKIE对象并赋多个KEY键值   
        /// 设键/值如下：   
        /// NameValueCollection myCol = new NameValueCollection();   
        /// myCol.Add("red", "rojo");   
        /// myCol.Add("green", "verde");   
        /// myCol.Add("blue", "azul");   
        /// myCol.Add("red", "rouge");   结果“red:rojo,rouge；green:verde；blue:azul”   
        /// </summary>
        /// <param name="CookiesName">COOKIE对象名</param>
        /// <param name="IExpires">COOKIE对象有效时间（秒数），1表示永久有效，0和负数都表示不设有效时间，大于等于2表示具体有效秒数，31536000秒=1年=(60*60*24*365)，</param>
        /// <param name="CookiesKeyValueCollection">键/值对集合</param>
        public static void WriteCookies(string CookiesName, int IExpires, NameValueCollection CookiesKeyValueCollection)
        {
            string[] strArray;
            int num;
            HttpCookie cookie = new HttpCookie(CookiesName.Trim());
            goto Label_00BF;
        Label_0032:
            HttpContext.Current.Response.Cookies.Add(cookie);
            return;
        Label_0049:
            if (IExpires != 1)
            {
                cookie.Expires = DateTime.Now.AddSeconds((double) IExpires);
                if (((uint) num) + ((uint) IExpires) < 0) goto Label_00CA;
            }
            else
                cookie.Expires = DateTime.MaxValue;
            goto Label_0032;
        Label_0097:
            if (num < strArray.Length) goto Label_00CA;
            if (8 != 0)
            {
                if (IExpires > 0) goto Label_0049;
                goto Label_0032;
            }
            if (((uint) IExpires) - ((uint) IExpires) <= uint.MaxValue) goto Label_0049;
        Label_00BF:
            strArray = CookiesKeyValueCollection.AllKeys;
            num = 0;
            goto Label_0097;
        Label_00CA:
            do
            {
                string str = strArray[num];
                cookie[str] = EncyptHelper.DESEncrypt(CookiesKeyValueCollection[str].Trim());
                num++;
            }
            while ((((uint) num) | 0xff) == 0);
            goto Label_0097;
        }

        /// <summary>创建COOKIE对象并赋Value值</summary>
        /// <param name="CookiesName">COOKIE对象名</param>
        /// <param name="IExpires">COOKIE对象有效时间（秒数），1表示永久有效，0和负数都表示不设有效时间，大于等于2表示具体有效秒数，31536000秒=1年=(60*60*24*365)，</param>
        /// <param name="CookiesValue">COOKIE对象Value值</param>
        public static void WriteCookies(string CookiesName, int IExpires, string CookiesValue)
        {
            HttpCookie cookie = new HttpCookie(CookiesName.Trim());
            if (1 != 0 && 0 == 0)
            {
                cookie.Value = EncyptHelper.DESEncrypt(CookiesValue.Trim());
                if (IExpires <= 0)
                {
                    if (0 != 0) return;
                }
                else if (IExpires != 1)
                    cookie.Expires = DateTime.Now.AddMinutes((double) IExpires);
                else
                    cookie.Expires = DateTime.MaxValue;
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>   
        /// 创建COOKIE对象并赋多个KEY键值   
        /// 设键/值如下：   
        /// NameValueCollection myCol = new NameValueCollection();   
        /// myCol.Add("red", "rojo");   
        /// myCol.Add("green", "verde");   
        /// myCol.Add("blue", "azul");   
        /// myCol.Add("red", "rouge");   结果“red:rojo,rouge；green:verde；blue:azul”   
        /// </summary>
        /// <param name="CookiesName">COOKIE对象名</param>
        /// <param name="IExpires">COOKIE对象有效时间（秒数），1表示永久有效，0和负数都表示不设有效时间，大于等于2表示具体有效秒数，31536000秒=1年=(60*60*24*365)，</param>
        /// <param name="CookiesKeyValueCollection">键/值对集合</param>
        /// <param name="CookiesDomain">作用域</param>
        public static void WriteCookies(string CookiesName, int IExpires, NameValueCollection CookiesKeyValueCollection, string CookiesDomain)
        {
            int num;
            HttpCookie cookie = new HttpCookie(CookiesName.Trim());
            if (((uint) num) - ((uint) IExpires) >= 0)
            {
                string[] allKeys = CookiesKeyValueCollection.AllKeys;
                num = 0;
            Label_00FB:
                if (num < allKeys.Length)
                {
                    string str = allKeys[num];
                Label_0112:
                    cookie[str] = EncyptHelper.DESEncrypt(CookiesKeyValueCollection[str].Trim());
                    if (((uint) IExpires) + ((uint) num) <= uint.MaxValue)
                    {
                        if (((uint) IExpires) > uint.MaxValue) goto Label_0112;
                        num++;
                        goto Label_00FB;
                    }
                }
            }
            cookie.Domain = CookiesDomain.Trim();
        Label_0044:
            if (IExpires > 0) goto Label_0092;
        Label_0048:
            HttpContext.Current.Response.Cookies.Add(cookie);
            if (((uint) IExpires) + ((uint) num) > uint.MaxValue) goto Label_0098;
            return;
        Label_007A:
            cookie.Expires = DateTime.Now.AddSeconds((double) IExpires);
            if (((uint) IExpires) + ((uint) IExpires) >= 0) goto Label_0048;
            goto Label_0044;
        Label_0092:
            if (IExpires == 1)
            {
                cookie.Expires = DateTime.MaxValue;
                goto Label_0048;
            }
            if (0 == 0) goto Label_007A;
        Label_0098:
            if (((uint) IExpires) - ((uint) num) < 0) goto Label_0092;
            goto Label_007A;
        }

        /// <summary>创建COOKIE对象并赋Value值</summary>
        /// <param name="CookiesName">COOKIE对象名</param>
        /// <param name="IExpires">COOKIE对象有效时间（秒数），1表示永久有效，0和负数都表示不设有效时间，大于等于2表示具体有效秒数，31536000秒=1年=(60*60*24*365)，</param>
        /// <param name="CookiesValue">COOKIE对象Value值</param>
        /// <param name="CookiesDomain">作用域</param>
        public static void WriteCookies(string CookiesName, int IExpires, string CookiesValue, string CookiesDomain)
        {
            HttpCookie cookie = new HttpCookie(CookiesName.Trim());
            goto Label_0073;
        Label_004C:
            HttpContext.Current.Response.Cookies.Add(cookie);
            if (((uint) IExpires) <= uint.MaxValue) return;
        Label_0073:
            cookie.Value = EncyptHelper.DESEncrypt(CookiesValue.Trim());
            cookie.Domain = CookiesDomain.Trim();
            if (IExpires > 0)
            {
                if (IExpires == 1)
                {
                    cookie.Expires = DateTime.MaxValue;
                    if (((uint) IExpires) + ((uint) IExpires) >= 0) goto Label_004C;
                }
                cookie.Expires = DateTime.Now.AddMinutes((double) IExpires);
            }
            goto Label_004C;
        }
    }
}
