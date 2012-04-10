namespace WHC.Pager.WinControl
{
    using Microsoft.Win32;
    using System;

    public sealed class RegistryHelper
    {
        private static string string_0 = @"Software\DeepLand\OrderWater";

        public static string GetValue(string key)
        {
            if (null == key)
            {
                throw new ArgumentNullException("key");
            }
            try
            {
                return Registry.CurrentUser.OpenSubKey(string_0).GetValue(key).ToString();
            }
            catch
            {
                return "";
            }
        }

        public static bool SaveValue(string key, string value)
        {
            if (null == key)
            {
                throw new ArgumentNullException("key");
            }
            if (null == value)
            {
                throw new ArgumentNullException("value");
            }
            RegistryKey key2 = Registry.CurrentUser.OpenSubKey(string_0, true);
            if (null == key2)
            {
                key2 = Registry.CurrentUser.CreateSubKey(string_0);
            }
            key2.SetValue(key, value);
            return false;
        }
    }
}

