namespace EntLib.Controls.DataPrinter
{
    using Microsoft.Win32;
    using System;

    internal class Register
    {
        public bool DeleteSubKey(string subtree)
        {
            try
            {
                Registry.CurrentUser.DeleteSubKey(subtree);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string[] GetSubKey(string subtree)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(subtree);
                if (key == null)
                {
                    key = Registry.CurrentUser.CreateSubKey(subtree);
                    Registry.CurrentUser.CreateSubKey(subtree + @"\默认方案");
                }
                string[] subKeyNames = key.GetSubKeyNames();
                key.Close();
                return subKeyNames;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object ReadReg(string subtree, string key, object defaultValue, bool write, RegistryValueKind rvk)
        {
            object obj2 = null;
            try
            {
                RegistryKey key2 = Registry.CurrentUser.OpenSubKey(subtree);
                if (write && key2 == null)
                {
                    key2 = Registry.CurrentUser.CreateSubKey(subtree, RegistryKeyPermissionCheck.ReadWriteSubTree);
                    this.WriteReg(subtree, key, defaultValue, rvk);
                    return defaultValue;
                }
                obj2 = key2.GetValue(key);
                key2.Close();
                if (obj2 == null)
                {
                    this.WriteReg(subtree, key, defaultValue, rvk);
                    return defaultValue;
                }
                return obj2;
            }
            catch
            {
                return defaultValue;
            }
        }

        public bool WriteReg(string subtree, string key, object value, RegistryValueKind rvk)
        {
            try
            {
                RegistryKey key2 = Registry.CurrentUser.CreateSubKey(subtree, RegistryKeyPermissionCheck.ReadWriteSubTree);
                key2.SetValue(key, value, rvk);
                key2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
