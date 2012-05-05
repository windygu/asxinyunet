using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace NewLife.WMI
{
    /// <summary>WMI基础类</summary>>
    public class WMIBase
    {
        protected object GetProp(ManagementObject mo, string propName)
        {
            object obj = null;
            try
            {
                obj = mo.Properties[propName].Value;
            }
            catch { }
             
            return obj;
        }

        protected string GetPropStr(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            return (obj == null) ? "" : Convert.ToString(obj).Trim();
        }

        protected int GetPropInt(ManagementObject mo, string propName, int defaultValue)
        {
            object obj = GetProp(mo, propName);
            if (obj == null)
            {
                return defaultValue;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        protected int GetPropInt(ManagementObject mo, string propName)
        {
            return GetPropInt(mo, propName, 0);
        }

        protected uint GetPropUInt(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            return (obj == null) ? 0 : Convert.ToUInt32(obj);
        }

        protected UInt64 GetPropUInt64(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            return (obj == null) ? 0 : Convert.ToUInt64(obj);
        }

        protected Int64 GetPropInt64(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            return (obj == null) ? 0 : Convert.ToInt64(obj);
        }

        protected ushort GetPropUShort(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToUInt16(obj);
            }
        }

        protected short GetPropShort(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt16(obj);
            }
        }

        protected ushort[] GetPropUShorts(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            return (obj == null) ? null : (ushort[])obj;
        }

        protected DateTime GetPropDateTime(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            return (obj == null) ? DateTime.MinValue : DateTime.Parse(obj.ToString());
        }

        protected string[] GetPropStrs(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            return (obj == null) ? null : (string[])obj;
        }

        protected bool GetPropBool(ManagementObject mo, string propName)
        {
            object obj = GetProp(mo, propName);
            return (obj == null) ? false : Convert.ToBoolean(obj);
        }

        /// <summary>将时间字符串处理为DateTime对象</summary>>
        /// <param name="dateTimeString"></param>
        /// <returns></returns>
        protected DateTime GetDateTime(string dateTimeString)
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
