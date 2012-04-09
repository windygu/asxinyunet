namespace Utils
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary><para>　</para>
    /// 类名：常用工具类——GUID相关类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------</para><para>　CreateGUID：生成新的GUID值[+3方法重载]</para><para>　IsGuid：验证给定字符串是否是合法的Guid</para></summary>
    public class GUIDHelper
    {
        /// <summary>生成GUID值小写</summary>
        /// <returns>新生成的GUID的字符串</returns>
        public static string CreateGUID() { return Guid.NewGuid().ToString().ToLower(); }

        /// <summary>生成GUID值小写，并指定是否显示中间的横线分隔符</summary>
        /// <param name="ShowLine">是否显示中间的横线分隔符</param>
        /// <returns></returns>
        public static string CreateGUID(bool ShowLine)
        {
            string str = CreateGUID();
            while (!ShowLine)
            {
                return str.Replace("-", "");
            }
            return str;
        }

        /// <summary>生成GUID值，是否显示大写，并指定是否显示中间的横线分隔符</summary>
        /// <param name="ShowLine">是否显示中间的横线分隔符</param>
        /// <param name="Upper">是否转换为大写</param>
        /// <returns></returns>
        public static string CreateGUID(bool ShowLine, bool Upper)
        {
            string str = CreateGUID(ShowLine);
            if (Upper) return str.ToUpper();
            return str.ToLower();
        }

        /// <summary>验证给定字符串是否是合法的Guid</summary>
        /// <param name="strToValidate">要验证的字符串</param>
        /// <returns>true/false</returns>
        public static bool IsGuid(string strToValidate)
        {
            bool flag = false;
            string pattern = @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$";
            try
            {
                if (strToValidate != null && !strToValidate.Equals("")) flag = Regex.IsMatch(strToValidate, pattern);
            }
            catch (Exception)
            {
            }
            return flag;
        }
    }
}
