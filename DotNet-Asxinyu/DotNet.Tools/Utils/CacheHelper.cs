namespace Utils
{
    using System;
    using System.Web;

    /// <summary><para>　</para>
    /// 类名：常用工具类——缓存类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------------</para><para>　SetCache：设置当前应用程序指定CacheKey的Cache值[ +2方法重载 ]</para><para>　GetCache：获取当前应用程序指定CacheKey的Cache值</para><para>　RemoveCache：删除缓存</para></summary>
    public class CacheHelper
    {
        /// <summary>获取当前应用程序指定CacheKey的Cache值</summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey) { return HttpRuntime.Cache[CacheKey]; }

        /// <summary>删除缓存</summary>
        /// <param name="CacheKey"></param>
        public static void RemoveCache(string CacheKey) { HttpRuntime.Cache.Remove(CacheKey); }

        /// <summary>设置当前应用程序指定CacheKey的Cache值</summary>
        /// <param name="CacheKey">键</param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject) { HttpRuntime.Cache.Insert(CacheKey, objObject); }

        /// <summary>设置当前应用程序指定CacheKey的Cache值</summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        /// <param name="absoluteExpiration"></param>
        /// <param name="slidingExpiration"></param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration) { HttpRuntime.Cache.Insert(CacheKey, objObject, null, absoluteExpiration, slidingExpiration); }
    }
}
