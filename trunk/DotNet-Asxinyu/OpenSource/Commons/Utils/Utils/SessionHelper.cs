namespace Utils
{
    using System;
    using System.Web;

    /// <summary><para>　</para>
    /// 常用工具类——Session操作类
    /// <para>　----------------------------------------------------------</para><para>　AddSession：添加Session,有效期为默认</para><para>　AddSession：添加Session，并调整有效期为分钟或几年</para><para>　GetSession：读取某个Session对象值</para><para>　DelSession：删除某个Session对象</para></summary>
    public class SessionHelper
    {
        /// <summary>添加Session,有效期为默认</summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValue">Session值</param>
        public static void AddSession(string strSessionName, string strValue) { HttpContext.Current.Session[strSessionName] = strValue; }

        /// <summary>添加Session，并调整有效期为分钟或几年</summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <param name="strValue">Session值</param>
        /// <param name="iExpires">分钟数：大于０则以分钟数为有效期，等于０则以后面的年为有效期</param>
        /// <param name="iYear">年数：当分钟数为０时按年数为有效期，当分钟数大于０时此参数随意设置</param>
        public static void AddSession(string strSessionName, string strValue, int iExpires, int iYear)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            if (iExpires > 0)
                HttpContext.Current.Session.Timeout = iExpires;
            else if (iYear > 0) HttpContext.Current.Session.Timeout = 0x80520 * iYear;
        }

        /// <summary>删除某个Session对象</summary>
        /// <param name="strSessionName">Session对象名称</param>
        public static void DelSession(string strSessionName) { HttpContext.Current.Session[strSessionName] = null; }

        /// <summary>读取某个Session对象值</summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值</returns>
        public static string GetSession(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null) return null;
            return HttpContext.Current.Session[strSessionName].ToString();
        }
    }
}
