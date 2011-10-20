using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web;
using NewLife.Configuration;

namespace XCode.Cache
{
    /// <summary>
    /// ���ݻ�����
    /// </summary>
    internal static class XCache
    {
        #region ��ʼ��
        private static SqlCache<CacheItem<DataSet>> _TableCache = new SqlCache<CacheItem<DataSet>>();
        private static SqlCache<CacheItem<Int32>> _IntCache = new SqlCache<CacheItem<Int32>>();

        /// <summary>
        /// ���������Ч�ڡ�
        /// -2	�رջ���
        /// -1	�Ƕ�ռ���ݿ⣬���ⲿϵͳ�������ݿ⣬ʹ�����󼶻��棻
        ///  0	���þ�̬���棻
        /// >0	��̬����ʱ�䣬��λ���룻
        /// </summary>
        public static Int32 Expiration = -1;

        /// <summary>
        /// ���ݻ�������
        /// </summary>
        public static XCacheType CacheType
        {
            get
            {
                if (Expiration > 0) return XCacheType.Period;
                return (XCacheType)Expiration;
            }
        }

        /// <summary>
        /// ��ʼ�����á�
        /// ��ȡ���ã�
        /// </summary>
        static XCache()
        {
            //��ȡ����
            //��ȡ������Ч��
            //String str = ConfigurationManager.AppSettings["XCacheExpiration"];
            Expiration = Config.GetConfig<Int32>("XCode.Cache.Expiration", Config.GetConfig<Int32>("XCacheExpiration", -2));
            //if (!String.IsNullOrEmpty(str))
            //{
            //    Int32 k = 0;
            //    if (Int32.TryParse(str, out k))
            //    {
            //        if (k >= -2) Expiration = k;
            //    }
            //}
            //��ȡ�������
            //str = ConfigurationManager.AppSettings["XCacheCheckPeriod"];
            CheckPeriod = Config.GetConfig<Int32>("XCode.Cache.CheckPeriod", Config.GetConfig<Int32>("XCacheCheckPeriod"));
            //if (!String.IsNullOrEmpty(str))
            //{
            //    Int32 k = 0;
            //    if (Int32.TryParse(str, out k))
            //    {
            //        if (k > 0) CheckPeriod = k;
            //    }
            //}
        }
        #endregion

        #region ����ά��
        /// <summary>
        /// ����ά����ʱ��
        /// </summary>
        private static Timer AutoCheckCacheTimer;

        /// <summary>
        /// ά����ʱ���ļ�����ڣ�Ĭ��5��
        /// </summary>
        public static Int32 CheckPeriod = 5;

        /// <summary>
        /// ά��
        /// </summary>
        /// <param name="obj"></param>
        private static void Check(Object obj)
        {
            //�رջ��桢���þ�̬��������󼶻���ʱ������Ҫ���
            if (CacheType != XCacheType.Period) return;

            if (_TableCache.Count > 0)
            {
                lock (_TableCache)
                {
                    if (_TableCache.Count > 0)
                    {
                        List<String> toDel = null;
                        foreach (String sql in _TableCache.Keys)
                            if (_TableCache[sql].CacheTime.AddSeconds(Expiration) < DateTime.Now)
                            {
                                if (toDel == null) toDel = new List<String>();
                                toDel.Add(sql);
                            }
                        if (toDel != null && toDel.Count > 0)
                            foreach (String sql in toDel)
                                _TableCache.Remove(sql);
                    }
                }
            }
            if (_IntCache.Count > 0)
            {
                lock (_IntCache)
                {
                    if (_IntCache.Count > 0)
                    {
                        List<String> toDel = null;
                        foreach (String sql in _IntCache.Keys)
                            if (_IntCache[sql].CacheTime.AddSeconds(Expiration) < DateTime.Now)
                            {
                                if (toDel == null) toDel = new List<String>();
                                toDel.Add(sql);
                            }
                        if (toDel != null && toDel.Count > 0)
                            foreach (String sql in toDel)
                                _IntCache.Remove(sql);
                    }
                }
            }
        }

        /// <summary>
        /// ������ʱ����
        /// ��Ϊ��ʱ����ԭ��ʵ�ʻ���ʱ�����Ҫ��ExpirationҪ��
        /// </summary>
        private static void CreateTimer()
        {
            if (AutoCheckCacheTimer != null) return;

            // ������ʱ���������ӳ�ʱ�䣬ʵ���ϲ�����
            AutoCheckCacheTimer = new Timer(new TimerCallback(Check), null, Timeout.Infinite, Timeout.Infinite);
            // �ı䶨ʱ��Ϊ5��󴥷�һ�Ρ�
            AutoCheckCacheTimer.Change(CheckPeriod * 1000, CheckPeriod * 1000);
        }
        #endregion

        #region ��ӻ���
        /// <summary>
        /// ������ݱ��档
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="ds">�������¼��</param>
        /// <param name="tableNames">��������</param>
        public static void Add(String sql, DataSet ds, String[] tableNames)
        {
            //�رջ���
            if (CacheType == XCacheType.Close) return;
            //���󼶻���
            if (CacheType == XCacheType.RequestCache)
            {
                if (HttpContext.Current == null) return;
                HttpContext.Current.Items.Add("XCache_DataSet_" + sql, new CacheItem<DataSet>(tableNames, ds));
                return;
            }
            //��̬����
            if (_TableCache.ContainsKey(sql)) return;
            lock (_TableCache)
            {
                if (_TableCache.ContainsKey(sql)) return;

                _TableCache.Add(sql, new CacheItem<DataSet>(tableNames, ds));
            }
            //����Ч��
            if (CacheType == XCacheType.Period) CreateTimer();

            ////��黺����Ȩ
            //if (License.CacheCount != Count)
            //    License.CacheCount = Count;
        }

        /// <summary>
        /// ���Int32���档
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <param name="n">����������</param>
        /// <param name="tableNames">��������</param>
        public static void Add(String sql, Int32 n, String[] tableNames)
        {
            //�رջ���
            if (CacheType == XCacheType.Close) return;
            //���󼶻���
            if (CacheType == XCacheType.RequestCache)
            {
                if (HttpContext.Current == null) return;
                HttpContext.Current.Items.Add("XCache_Int32_" + sql, new CacheItem<Int32>(tableNames, n));
                return;
            }
            //��̬����
            if (_IntCache.ContainsKey(sql)) return;
            lock (_IntCache)
            {
                if (_IntCache.ContainsKey(sql)) return;

                _IntCache.Add(sql, new CacheItem<Int32>(tableNames, n));
            }
            //����Ч��
            if (CacheType == XCacheType.Period) CreateTimer();

            ////��黺����Ȩ
            //if (License.CacheCount != Count)
            //    License.CacheCount = Count;
        }
        #endregion

        #region ɾ������
        /// <summary>
        /// �Ƴ�������ĳ�����ݱ�Ļ���
        /// </summary>
        /// <param name="tableName">���ݱ�</param>
        public static void Remove(String tableName)
        {
            //���󼶻���
            if (CacheType == XCacheType.RequestCache)
            {
                if (HttpContext.Current == null) return;
                List<Object> toDel = new List<Object>();
                foreach (Object obj in HttpContext.Current.Items.Keys)
                {
                    String str = obj as String;
                    if (!String.IsNullOrEmpty(str))
                    {
                        if (str.StartsWith("XCache_DataSet_"))
                        {
                            CacheItem<DataSet> ci = HttpContext.Current.Items[obj] as CacheItem<DataSet>;
                            if (ci != null && ci.IsDependOn(tableName)) toDel.Add(obj);
                        }
                        if (str.StartsWith("XCache_Int32_"))
                        {
                            CacheItem<Int32> ci = HttpContext.Current.Items[obj] as CacheItem<Int32>;
                            if (ci != null && ci.IsDependOn(tableName)) toDel.Add(obj);
                        }
                    }
                }
                foreach (Object obj in toDel)
                    HttpContext.Current.Items.Remove(obj);
                return;
            }
            //��̬����
            lock (_TableCache)
            {
                //TODO 2011-03-11 ��ʯͷ �����Ѿ���Ϊ����ƿ����������Ҫ�Ż���ƿ������_TableCache[sql]
                List<String> toDel = new List<String>();
                foreach (String sql in _TableCache.Keys)
                    if (_TableCache[sql].IsDependOn(tableName)) toDel.Add(sql);
                foreach (String sql in toDel)
                    _TableCache.Remove(sql);
            }
            lock (_IntCache)
            {
                List<String> toDel = new List<String>();
                foreach (String sql in _IntCache.Keys)
                    if (_IntCache[sql].IsDependOn(tableName)) toDel.Add(sql);
                foreach (String sql in toDel)
                    _IntCache.Remove(sql);
            }
        }

        /// <summary>
        /// �Ƴ�������һ�����ݱ�Ļ���
        /// </summary>
        /// <param name="tableNames"></param>
        public static void Remove(String[] tableNames)
        {
            foreach (String tn in tableNames) Remove(tn);
        }

        /// <summary>
        /// ��ջ���
        /// </summary>
        public static void RemoveAll()
        {
            //���󼶻���
            if (CacheType == XCacheType.RequestCache)
            {
                if (HttpContext.Current == null) return;
                List<Object> toDel = new List<Object>();
                foreach (Object obj in HttpContext.Current.Items.Keys)
                {
                    String str = obj as String;
                    if (!String.IsNullOrEmpty(str))
                    {
                        if (str.StartsWith("XCache_DataSet_") || str.StartsWith("XCache_Int32_")) toDel.Add(obj);
                    }
                }
                foreach (Object obj in toDel)
                    HttpContext.Current.Items.Remove(obj);
                return;
            }
            //��̬����
            lock (_TableCache)
            {
                _TableCache.Clear();
            }
            lock (_IntCache)
            {
                _IntCache.Clear();
            }
        }
        #endregion

        #region ���һ���
        /// <summary>
        /// ���һ������Ƿ����ĳһ��
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns></returns>
        public static Boolean Contain(String sql)
        {
            //�رջ���
            if (CacheType == XCacheType.Close) return false;
            //���󼶻���
            if (CacheType == XCacheType.RequestCache)
            {
                if (HttpContext.Current == null) return false;
                return HttpContext.Current.Items.Contains("XCache_DataSet_" + sql);
            }
            return _TableCache.ContainsKey(sql);
        }

        /// <summary>
        /// ��ȡDataSet����
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns></returns>
        public static DataSet Item(String sql)
        {
            //�رջ���
            if (CacheType == XCacheType.Close) return null;
            //���󼶻���
            if (CacheType == XCacheType.RequestCache)
            {
                if (HttpContext.Current == null) return null;
                CacheItem<DataSet> ci = HttpContext.Current.Items["XCache_DataSet_" + sql] as CacheItem<DataSet>;
                if (ci == null) return null;
                return ci.TValue;
            }
            return _TableCache[sql].TValue;
        }

        /// <summary>
        /// ����Int32�������Ƿ����ĳһ��
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns></returns>
        public static Boolean IntContain(String sql)
        {
            //�رջ���
            if (CacheType == XCacheType.Close) return false;
            //���󼶻���
            if (CacheType == XCacheType.RequestCache)
            {
                if (HttpContext.Current == null) return false;
                return HttpContext.Current.Items.Contains("XCache_Int32_" + sql);
            }
            return _IntCache.ContainsKey(sql);
        }

        /// <summary>
        /// ��ȡInt32����
        /// </summary>
        /// <param name="sql">SQL���</param>
        /// <returns></returns>
        public static Int32 IntItem(String sql)
        {
            //�رջ���
            if (CacheType == XCacheType.Close) return -1;
            //���󼶻���
            if (CacheType == XCacheType.RequestCache)
            {
                if (HttpContext.Current == null) return -1;
                CacheItem<Int32> ci = HttpContext.Current.Items["XCache_Int32_" + sql] as CacheItem<Int32>;
                if (ci == null) return -1;
                return ci.TValue;
            }
            return _IntCache[sql].TValue;
        }
        #endregion

        /// <summary>
        /// �������
        /// </summary>
        internal static Int32 Count
        {
            get
            {
                //�رջ���
                if (CacheType == XCacheType.Close) return 0;
                //���󼶻���
                if (CacheType == XCacheType.RequestCache)
                {
                    if (HttpContext.Current == null) return 0;
                    Int32 k = 0;
                    foreach (Object obj in HttpContext.Current.Items.Keys)
                    {
                        String str = obj as String;
                        if (!String.IsNullOrEmpty(str))
                        {
                            if (str.StartsWith("XCache_DataSet_") || str.StartsWith("XCache_Int32_")) k++;
                        }
                    }
                    return k;
                }
                return _TableCache.Count + _IntCache.Count;
            }
        }
    }

    /// <summary>
    /// ���ݻ�������
    /// </summary>
    internal enum XCacheType
    {
        /// <summary>
        /// �رջ���
        /// </summary>
        Close = -2,
        /// <summary>
        /// ���󼶻���
        /// </summary>
        RequestCache = -1,
        /// <summary>
        /// ���þ�̬����
        /// </summary>
        Infinite = 0,
        /// <summary>
        /// ����Ч�ڻ���
        /// </summary>
        Period = 1
    }
}