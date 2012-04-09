namespace Utils
{
    using System;
    using System.Configuration;

    /// <summary><para>　</para>
    /// 类名：常用工具类——Web.Config操作类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>--------------------------------------------------------------</para><para>　GetConfigString：得到AppSettings中的配置字符串信息</para><para>　GetConnectionString：得到Connection中配置字符串信息</para><para>　GetConfigBool：得到AppSettings中的配置Bool信息</para><para>　GetConfigDecimal：得到AppSettings中的配置Decimal信息</para><para>　GetConfigDecimal：得到AppSettings中的配置int信息</para><para>　SetAppSettingString：更改AppSettings中的配置值</para></summary>
    public class ConfigHelper
    {
        /// <summary>得到AppSettings中的配置Bool信息</summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetConfigBool(string key)
        {
            bool flag = false;
            string configString = GetConfigString(key);
            while (configString != null)
            {
                if (string.Empty != configString)
                {
                    try
                    {
                        flag = bool.Parse(configString);
                    }
                    catch (FormatException)
                    {
                    }
                }
                return flag;
            }
            return flag;
        }

        /// <summary>得到AppSettings中的配置Decimal信息</summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetConfigDecimal(string key)
        {
            decimal num = 0M;
            string configString = GetConfigString(key);
            if ((1 == 0 || configString != null) && string.Empty != configString)
            {
                try
                {
                    num = decimal.Parse(configString);
                }
                catch (FormatException)
                {
                }
                return num;
            }
            return num;
        }

        /// <summary>得到AppSettings中的配置int信息</summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetConfigInt(string key)
        {
            int num = 0;
            string configString = GetConfigString(key);
            do
            {
                if (configString != null && string.Empty != configString)
                {
                    try
                    {
                        num = int.Parse(configString);
                    }
                    catch (FormatException)
                    {
                    }
                    return num;
                }
                return num;
            }
            while (((uint) num) + ((uint) num) < 0);
            return num;
        }

        /// <summary>得到AppSettings中的配置字符串信息</summary>
        /// <param name="key">AppSetting中关键字KEY</param>
        /// <returns>AppSettings中的配置字符串信息</returns>
        public static string GetConfigString(string key) { return ConfigurationManager.AppSettings[key].ToString(); }

        /// <summary>得到Connection中配置字符串信息</summary>
        /// <param name="key">Connection中name的值</param>
        /// <returns>Connection中name的值</returns>
        public static string GetConnectionString(string key) { return ConfigurationManager.ConnectionStrings[key].ToString(); }
    }
}
