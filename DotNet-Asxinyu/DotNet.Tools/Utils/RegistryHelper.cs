namespace Utils
{
    using Microsoft.Win32;
    using System;

    /// <summary><para>　</para>
    /// 类名：常用工具类——注册表操作类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>------------------------------------------------------------------------------------------------------</para><para>　GetRegValue：读取路径为不包含根键的keypath，键名为keyname的注册表键值，缺省返回null</para><para>　SetRegValue：设置路径为不包含根键的keypath，键名为keyname的注册表键值为SetValue，失败返回False</para><para>　CreateRegPath：创建不含根键的路径为regpath的路径</para><para>　CreateRegKeyPath： 创建一个注册表路径，新建一个键名，并设置键值</para><para>　DeleteSubKey：删除路径为SubKey的子项</para><para>　DeleteSubKeyTree：删除路径为SubPath的子项及其附属子项</para><para>　DeleteRegKeyName：删除指定键名的键名</para></summary>
    public class RegistryHelper
    {
        /// <summary>创建一个注册表路径，新建一个键名，并设置键值</summary>
        /// <param name="RootKey">根键枚举</param>
        /// <param name="RegPath">要创建的键路径</param>
        /// <param name="KeyName">要创建的键名</param>
        /// <param name="KeyValue">键名的键值</param>
        /// <returns></returns>
        public static bool CreateRegKeyPath(RootKey RootKey, string RegPath, string KeyName, object KeyValue)
        {
            bool flag = false;
            try
            {
                x8bf904f219e107b4(RootKey).CreateSubKey(RegPath);
                x8bf904f219e107b4(RootKey).OpenSubKey(RegPath, true).SetValue(KeyName, KeyValue);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        /// <summary>创建不含根键的路径为regpath的路径</summary>
        /// <param name="RootKey">根键枚举</param>
        /// <param name="RegPath">要创建的键值路径</param>
        /// <returns></returns>
        public static bool CreateRegPath(RootKey RootKey, string RegPath)
        {
            bool flag = false;
            try
            {
                x8bf904f219e107b4(RootKey).CreateSubKey(RegPath);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        /// <summary>删除指定键名的键名</summary>
        /// <param name="RootKey">根键枚举</param>
        /// <param name="SubPath">路径</param>
        /// <param name="KeyName">键名</param>
        /// <returns></returns>
        public static bool DeleteRegKeyName(RootKey RootKey, string SubPath, string KeyName)
        {
            bool flag = false;
            try
            {
                x8bf904f219e107b4(RootKey).OpenSubKey(SubPath, true).DeleteValue(KeyName);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        /// <summary>删除路径为SubKey的子项</summary>
        /// <param name="RootKey">根键枚举</param>
        /// <param name="SubPath">要删除的键路径</param>
        /// <returns></returns>
        public static bool DeleteSubKey(RootKey RootKey, string SubPath)
        {
            bool flag = false;
            try
            {
                x8bf904f219e107b4(RootKey).DeleteSubKey(SubPath);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        /// <summary>删除路径为SubPath的子项及其附属子项</summary>
        /// <param name="RootKey">根键枚举</param>
        /// <param name="SubPath">要删除的路径</param>
        /// <returns></returns>
        public static bool DeleteSubKeyTree(RootKey RootKey, string SubPath)
        {
            bool flag = false;
            try
            {
                x8bf904f219e107b4(RootKey).DeleteSubKeyTree(SubPath);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        /// <summary>读取路径为不包含根键的keypath，键名为keyname的注册表键值，缺省返回null</summary>
        /// <param name="RootKey">根键枚举</param>
        /// <param name="KeyPath">健路径(不含根键)</param>
        /// <param name="KeyName">键名</param>
        /// <returns>读取到的注册表键值</returns>
        public static string GetRegValue(RootKey RootKey, string KeyPath, string KeyName)
        {
            string str = null;
            try
            {
                str = x8bf904f219e107b4(RootKey).OpenSubKey(KeyPath).GetValue(KeyName, null).ToString();
            }
            catch (Exception)
            {
            }
            return str;
        }

        /// <summary>设置路径为不包含根键的keypath，键名为keyname的注册表键值为SetValue，失败返回False</summary>
        /// <param name="RootKey">根键枚举</param>
        /// <param name="KeyPath">健路径(不含根键)</param>
        /// <param name="KeyName">键名</param>
        /// <param name="KeyValue">键值</param>
        /// <returns></returns>
        public static bool SetRegValue(RootKey RootKey, string KeyPath, string KeyName, object KeyValue)
        {
            bool flag = false;
            try
            {
                x8bf904f219e107b4(RootKey).OpenSubKey(KeyPath, true).SetValue(KeyName, KeyValue);
                flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }

        private static RegistryKey x8bf904f219e107b4(RootKey x343126c412047c1f)
        {
            RegistryKey localMachine = null;
            switch (x343126c412047c1f)
            {
                case RootKey.ClassesRoot:
                    return Registry.ClassesRoot;

                case RootKey.CurrentUser:
                    return Registry.CurrentUser;

                case RootKey.LocalMachine:
                    localMachine = Registry.LocalMachine;
                    if (0 == 0)
                    {
                    }
                    return localMachine;

                case RootKey.Users:
                    return Registry.Users;

                case RootKey.CurrentConfig:
                    return Registry.CurrentConfig;

                case RootKey.DynData:
                    break;

                case RootKey.PerformanceData:
                    return Registry.PerformanceData;

                default:
                    if (0 != 0) break;
                    return Registry.CurrentUser;
            }
            return Registry.DynData;
        }

        /// <summary>当前操作的注册表根键</summary>
        public enum RootKey
        {
            ClassesRoot,
            CurrentUser,
            LocalMachine,
            Users,
            CurrentConfig,
            DynData,
            PerformanceData
        }
    }
}
