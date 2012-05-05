using System;
using System.Collections.Generic;
using System.Text;

namespace NewLife.WMI
{
    /// <summary>WMI访问公用类</summary>>
    internal static class WMILib
    {
        /// <summary>处理Mac地址分隔符</summary>>
        /// <param name="mACAddress"></param>
        /// <returns></returns>
        public static string GetMACAddress(string mACAddress)
        {
            return mACAddress.Replace(":", "-");
        }

        /// <summary>将时间字符串处理为DateTime对象</summary>>
        /// <param name="dateTimeString"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(string dateTimeString)
        {
            if (dateTimeString.Trim() == String.Empty)
            {
                return DateTime.MinValue;
            }

            //20060128200204.000000+480
            string temp = dateTimeString.Substring(0, dateTimeString.IndexOf("."));
            string year, month, day, hour, minute, second;

            year = temp.Substring(0, 4);
            month = temp.Substring(4, 2);
            day = temp.Substring(6, 2);
            hour = temp.Substring(8, 2);
            minute = temp.Substring(10, 2);
            second = temp.Substring(12, 2);

            return DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second);
        }
    }
}
