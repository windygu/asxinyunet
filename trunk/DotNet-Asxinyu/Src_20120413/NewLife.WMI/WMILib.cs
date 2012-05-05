using System;
using System.Collections.Generic;
using System.Text;

namespace NewLife.WMI
{
    /// <summary>WMI���ʹ�����</summary>>
    internal static class WMILib
    {
        /// <summary>����Mac��ַ�ָ���</summary>>
        /// <param name="mACAddress"></param>
        /// <returns></returns>
        public static string GetMACAddress(string mACAddress)
        {
            return mACAddress.Replace(":", "-");
        }

        /// <summary>��ʱ���ַ�������ΪDateTime����</summary>>
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
