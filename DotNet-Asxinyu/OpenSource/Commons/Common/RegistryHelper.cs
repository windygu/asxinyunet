namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Win32;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public sealed class RegistryHelper
    {
        private static string mUvqAX6rk = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1da0);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool CheckStartWithWindows()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1ccc));
            if ((key != null) && (((string) key.GetValue(Application.ProductName, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1d2a), RegistryValueOptions.None)) != kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1d36)))
            {
                Registry.CurrentUser.Flush();
                return true;
            }
            Registry.CurrentUser.Flush();
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetValue(string key)
        {
            return GetValue(mUvqAX6rk, key);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetValue(string softwareKey, string key)
        {
            if (null == key)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1caa));
            }
            try
            {
                return Registry.CurrentUser.OpenSubKey(softwareKey).GetValue(key).ToString();
            }
            catch
            {
                return "";
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool SaveValue(string key, string value)
        {
            return SaveValue(mUvqAX6rk, key, value);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool SaveValue(string softwareKey, string key, string value)
        {
            if (null == key)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1cb4));
            }
            if (null == value)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1cbe));
            }
            RegistryKey key2 = Registry.CurrentUser.OpenSubKey(softwareKey, true);
            if (null == key2)
            {
                key2 = Registry.CurrentUser.CreateSubKey(softwareKey);
            }
            key2.SetValue(key, value);
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetStartWithWindows(bool startWin)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x1d42), true);
            if (key != null)
            {
                if (startWin)
                {
                    key.SetValue(Application.ProductName, Application.ExecutablePath, RegistryValueKind.String);
                }
                else
                {
                    key.DeleteValue(Application.ProductName, false);
                }
                Registry.CurrentUser.Flush();
            }
        }
    }
}

