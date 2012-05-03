namespace DotNet.WMI
{
    using Microsoft.VisualBasic.Devices;
    using System;
    using System.Collections;
    using System.Management;

    public class SystemInfo
    {
        public static string GetAllConfigInfoFormComputer(WMI_ClassNames Win32_Class)
        {
            string str2;
            string str = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + Win32_Class.ToString().Trim());
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    str = str + obj2.GetText(TextFormat.Mof) + "\n";
                }
                str2 = str;
            }
            catch (Exception exception)
            {
                throw new Exception("获取系统信息失败，请确认输入的对象和属性名正确：" + exception.Message);
            }
            return str2;
        }

        public static Hashtable GetAllWin32_ClassPropValuesIntoTable(WMI_ClassNames Win32_Class)
        {
            Hashtable hashtable = new Hashtable();
            ManagementObjectCollection instances = new ManagementClass(Win32_Class.ToString().Trim()).GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                PropertyDataCollection properties = obj2.Properties;
                foreach (PropertyData data in properties)
                {
                    string key = data.Name.ToLower();
                    if (!hashtable.ContainsKey(key)) hashtable.Add(key, data.Value);
                }
            }
            return hashtable;
        }

        public static string GetCurenDirectory()
        {
            return Environment.CurrentDirectory.ToString();
        }

        public static string GetMachineName()
        {
            return Environment.MachineName.ToString();
        }

        public static string GetOsFullName()
        {
            ComputerInfo info = new ComputerInfo();
            return info.OSFullName;
        }

        public static string GetOsVersion()
        {
            return Environment.OSVersion.VersionString;
        }

        public static string GetSystemDirectory()
        {
            return Environment.SystemDirectory.ToString();
        }

        public static string GetSystemTimeOfNow()
        {
            return DateTime.Now.ToString();
        }

        public static string GetWin32_ClassAllProperValues(WMI_ClassNames Win32_Class)
        {
            ManagementClass class2 = new ManagementClass(Win32_Class.ToString().Trim());
            string str = null;
            ManagementObjectCollection instances = class2.GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                str = obj2.GetText(TextFormat.Mof) + "\n";
            }
            return str;
        }

        public static string GetWin32_ClassPropertyValueByName(WMI_ClassNames Win32_Class, string propertyName)
        {
            string key = propertyName.ToLower().Trim();
            Hashtable hashtable = GetAllWin32_ClassPropValuesIntoTable(Win32_Class);
            string str2 = null;
            if (hashtable.ContainsKey(key))
            {
                object obj2 = hashtable[key];
                if (obj2 != null) str2 = obj2.ToString();
            }
            return str2;
        }
    }
}
