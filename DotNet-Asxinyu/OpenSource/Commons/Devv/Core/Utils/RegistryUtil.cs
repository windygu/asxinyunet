namespace Devv.Core.Utils
{
    using Microsoft.Win32;
    using System;

    public class RegistryUtil
    {
        private RegistryUtil()
        {
        }

        public static string GetAutoRun(string strName)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (key != null)
            {
                return key.GetValue(strName, string.Empty).ToString();
            }
            return string.Empty;
        }

        public static string Read(string path, string key)
        {
            RegistryKey key2 = Registry.CurrentUser.OpenSubKey(path, false);
            if (key2 != null)
            {
                return key2.GetValue(key, string.Empty).ToString();
            }
            return string.Empty;
        }

        public static bool SetAutoRun(string strName, string strPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (key == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(strPath))
            {
                key.DeleteValue(strName, false);
            }
            else
            {
                key.SetValue(strName, strPath);
            }
            return true;
        }

        public static bool Write(string path, string key, string value)
        {
            RegistryKey key2 = Registry.CurrentUser.OpenSubKey(path, true);
            if (key2 != null)
            {
                key2.SetValue(key, value);
                return true;
            }
            return false;
        }
    }
}
