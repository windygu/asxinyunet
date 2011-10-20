﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using NewLife.Reflection;

namespace NewLife.Configuration
{
    /// <summary>
    /// 通用配置辅助类
    /// </summary>
    public static class Config
    {
        #region 属性
        private static List<String> hasLoad = new List<String>();

        private static NameValueCollection _AppSettings;
        /// <summary>应用设置</summary>
        public static NameValueCollection AppSettings
        {
            get
            {
                if (_AppSettings == null && !hasLoad.Contains("AppSettings"))
                {
                    _AppSettings = ConfigurationManager.AppSettings;
                    hasLoad.Add("AppSettings");
                }
                return _AppSettings;
            }
            //set { _AppSettings = value; }
        }

        private static ConnectionStringSettingsCollection _ConnectionStrings;
        /// <summary>连接字符串设置</summary>
        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                if (_ConnectionStrings == null && !hasLoad.Contains("ConnectionStrings"))
                {
                    _ConnectionStrings = ConfigurationManager.ConnectionStrings;
                    hasLoad.Add("ConnectionStrings");
                }
                return _ConnectionStrings;
            }
            //set { _ConnectionStrings = value; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 是否包含指定项的设置
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Boolean Contain(String name)
        {
            if (AppSettings == null || AppSettings.Count < 1) return false;

            return Array.IndexOf(AppSettings.AllKeys, name) >= 0;
        }

        /// <summary>
        /// 取得指定名称的设置项，并转为指定类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetConfig<T>(String name)
        {
            if (AppSettings == null || AppSettings.Count < 1) return default(T);

            return GetConfig<T>(name, default(T));
        }

        /// <summary>
        /// 取得指定名称的设置项，并转为指定类型。如果设置不存在，则返回默认值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetConfig<T>(String name, T defaultValue)
        {
            if (AppSettings == null || AppSettings.Count < 1) return defaultValue;

            String str = AppSettings[name];
            if (String.IsNullOrEmpty(str)) return defaultValue;

            Type type = typeof(T);
            TypeCode code = Type.GetTypeCode(type);

            if (code == TypeCode.String) return (T)(Object)str;

            if (code == TypeCode.Int32)
            {
                return (T)(Object)Convert.ToInt32(str);
            }

            if (code == TypeCode.Boolean)
            {
                //if (str == "1" || String.Equals(str, Boolean.TrueString, StringComparison.OrdinalIgnoreCase))
                //    return (T)(Object)true;
                //else if (str == "0" || String.Equals(str, Boolean.FalseString, StringComparison.OrdinalIgnoreCase))
                //    return (T)(Object)false;

                if (str == "1" || str.EqualIgnoreCase(Boolean.TrueString))
                    return (T)(Object)true;
                else if (str == "0" || str.EqualIgnoreCase(Boolean.FalseString))
                    return (T)(Object)false;

                Boolean b = false;
                if (Boolean.TryParse(str.ToLower(), out b)) return (T)(Object)b;
            }

            T value = (T)TypeX.ChangeType(str, type);

            return value;
        }

        /// <summary>
        /// 根据指定前缀，获取设置项
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static NameValueCollection GetConfigByPrefix(String prefix)
        {
            if (AppSettings == null || AppSettings.Count < 1) return null;

            //List<String> list = new List<String>();
            NameValueCollection nv = new NameValueCollection();
            foreach (String item in AppSettings.Keys)
            {
                //if (item.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) list.Add(AppSettings[item]);
                if (item.Length > prefix.Length && item.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) nv.Add(item, AppSettings[item]);
            }
            //return list.Count > 0 ? list.ToArray() : null;
            return nv.Count > 0 ? nv : null;
        }

        /// <summary>
        /// 取得指定名称的设置项，并分割为指定类型数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="split"></param>
        /// <returns></returns>
        public static T[] GetConfigSplit<T>(String name, String split)
        {
            if (AppSettings == null || AppSettings.Count < 1) return null;

            return GetConfigSplit<T>(name, split, null);
        }

        /// <summary>
        /// 取得指定名称的设置项，并分割为指定类型数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="split"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T[] GetConfigSplit<T>(String name, String split, T[] defaultValue)
        {
            if (AppSettings == null || AppSettings.Count < 1) return defaultValue;

            String str = GetConfig<String>(name);
            if (String.IsNullOrEmpty(str)) return defaultValue;

            String[] sps = String.IsNullOrEmpty(split) ? new String[] { ",", ";" } : new String[] { split };
            String[] ss = str.Split(sps, StringSplitOptions.RemoveEmptyEntries);
            if (ss == null || ss.Length < 1) return defaultValue;

            //List<T> list = new List<T>(ss.Length);
            //foreach (String item in ss)
            //{
            //    str = item.Trim();
            //    if (String.IsNullOrEmpty(str)) continue;

            //    T result = TypeX.ChangeType<T>(str);
            //    list.Add(result);
            //}
            T[] arr = new T[ss.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                str = ss[i].Trim();
                if (String.IsNullOrEmpty(str)) continue;

                arr[i] = TypeX.ChangeType<T>(str);
            }

            return arr;
        }
        #endregion
    }
}