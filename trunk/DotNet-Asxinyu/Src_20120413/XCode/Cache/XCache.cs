using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Web;
using NewLife.Configuration;
using NewLife.Log;
using NewLife.Reflection;
using XCode.DataAccessLayer;

namespace XCode.Cache
{
    /// <summary>���ݻ�����</summary>
    /// <remarks>
    /// ��SQLΪ���Բ�ѯ���л��棬ͬʱ������ִ��SQLʱ�����ݹ�����ɾ�����档
    /// </remarks>
    static class XCache
    {
        #region ��ʼ��
        private static Dictionary<String, CacheItem<DataSet>> _TableCache = new Dictionary<String, CacheItem<DataSet>>();
        private static Dictionary<String, CacheItem<Int32>> _IntCache = new Dictionary<String, CacheItem<Int32>>();

        static readonly String _dst = "XCache_DataSet_";
        static readonly String _int = "XCache_Int32_";

        /// <summary>
        /// ���������Ч�ڡ�
        /// -2	�رջ���
        /// -1	�Ƕ�ռ���ݿ⣬���ⲿϵͳ�������ݿ⣬ʹ�����󼶻��棻
        ///  0	���þ�̬���棻
        /// >0	��̬����ʱ�䣬��λ���룻
        /// </summary>
        public static Int32 Expiration = -1;

        /// <summary>���ݻ�������</summary>
        static CacheKinds Kind { get { return Expiration > 0 ? CacheKinds.��Ч�ڻ��� : (CacheKinds)Expiration; } }

        /// <summary>
        /// ��ʼ�����á�
        /// ��ȡ���ã�
        /// </summary>
        static XCache()
        {
            //��ȡ������Ч��
            Expiration = Config.GetMutilConfig<Int32>(-2, "XCode.Cache.Expiration", "XCacheExpiration");
            //��ȡ�������
            CheckPeriod = Config.GetMutilConfig<Int32>(5, "XCode.Cache.CheckPeriod", "XCacheCheckPeriod");

            if (Expiration < -2) Expiration = -2;
            if (CheckPeriod <= 0) CheckPeriod = 5;

            if (DAL.Debug)
            {
                // ��Ҫ����һ�£�������ֱ����Kindת���������ַ��������������Ϊö���»�������޷���ʾ��ȷ������
                String name = null;
                switch (Kind)
                {
                    case CacheKinds.�رջ���:
                        name = "�رջ���";
                        break;
                    case CacheKinds.���󼶻���:
                        name = "���󼶻���";
                        break;
                    case CacheKinds.���þ�̬����:
                        name = "���þ�̬����";
                        break;
                    case CacheKinds.��Ч�ڻ���:
                        name = "��Ч�ڻ���";
                        break;
                    default:
                        break;
                }
                if (Kind < CacheKinds.��Ч�ڻ���)
                    DAL.WriteLog("һ�����棺{0}", name);
                else
                    DAL.WriteLog("һ�����棺{0}��{1}", Expiration, name);
            }
        }
        #endregion

        #region ����ά��
        /// <summary>����ά����ʱ��</summary>
        private static Timer AutoCheckCacheTimer;

        /// <summary>ά����ʱ���ļ�����ڣ�Ĭ��5��</summary>
        public static Int32 CheckPeriod = 5;

        /// <summary>ά��</summary>
        /// <param name="obj"></param>
        private static void Check(Object obj)
        {
            //�رջ��桢���þ�̬��������󼶻���ʱ������Ҫ���
            if (Kind != CacheKinds.��Ч�ڻ���) return;

            if (_TableCache.Count > 0)
            {
                lock (_TableCache)
                {
                    if (_TableCache.Count > 0)
                    {
                        List<String> toDel = null;
                        foreach (String sql in _TableCache.Keys)
                            if (_TableCache[sql].ExpireTime < DateTime.Now)
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
                            if (_IntCache[sql].ExpireTime < DateTime.Now)
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
            //�رջ��桢���þ�̬��������󼶻���ʱ������Ҫ���
            if (Kind != CacheKinds.��Ч�ڻ���) return;

            if (AutoCheckCacheTimer != null) return;

            // ������ʱ���������ӳ�ʱ�䣬ʵ���ϲ�����
            AutoCheckCacheTimer = new Timer(new TimerCallback(Check), null, Timeout.Infinite, Timeout.Infinite);
            // �ı䶨ʱ��Ϊ5��󴥷�һ�Ρ�
            AutoCheckCacheTimer.Change(CheckPeriod * 1000, CheckPeriod * 1000);
        }
        #endregion

        #region ��ӻ���
        /// <summary>������ݱ��档</summary>
        /// <param name="sql">SQL���</param>
        /// <param name="ds">�������¼��</param>
        /// <param name="tableNames">��������</param>
        public static void Add(String sql, DataSet ds, String[] tableNames)
        {
            //�رջ���
            if (Kind == CacheKinds.�رջ���) return;

            //���󼶻���
            if (Kind == CacheKinds.���󼶻���)
            {
                if (Items == null) return;
                Items.Add(_dst + sql, new CacheItem<DataSet>(tableNames, ds));
                return;
            }

            //��̬����
            if (_TableCache.ContainsKey(sql)) return;
            lock (_TableCache)
            {
                if (_TableCache.ContainsKey(sql)) return;

                _TableCache.Add(sql, new CacheItem<DataSet>(tableNames, ds, Expiration));
            }

            //����Ч��
            if (Kind == CacheKinds.��Ч�ڻ���) CreateTimer();
        }

        /// <summary>���Int32���档</summary>
        /// <param name="sql">SQL���</param>
        /// <param name="n">����������</param>
        /// <param name="tableNames">��������</param>
        public static void Add(String sql, Int32 n, String[] tableNames)
        {
            //�رջ���
            if (Kind == CacheKinds.�رջ���) return;

            //���󼶻���
            if (Kind == CacheKinds.���󼶻���)
            {
                if (Items == null) return;
                Items.Add(_int + sql, new CacheItem<Int32>(tableNames, n));
                return;
            }

            //��̬����
            if (_IntCache.ContainsKey(sql)) return;
            lock (_IntCache)
            {
                if (_IntCache.ContainsKey(sql)) return;

                _IntCache.Add(sql, new CacheItem<Int32>(tableNames, n, Expiration));
            }

            //����Ч��
            if (Kind == CacheKinds.��Ч�ڻ���) CreateTimer();
        }
        #endregion

        #region ɾ������
        /// <summary>�Ƴ�������ĳ�����ݱ�Ļ���</summary>
        /// <param name="tableName">���ݱ�</param>
        public static void Remove(String tableName)
        {
            //���󼶻���
            if (Kind == CacheKinds.���󼶻���)
            {
                var cs = Items;
                if (cs == null) return;

                List<Object> toDel = new List<Object>();
                foreach (Object obj in cs.Keys)
                {
                    String str = obj as String;
                    if (!String.IsNullOrEmpty(str) && (str.StartsWith(_dst) || str.StartsWith(_int)))
                    {
                        CacheItem ci = cs[obj] as CacheItem;
                        if (ci != null && ci.IsDependOn(tableName)) toDel.Add(obj);
                    }
                }
                foreach (Object obj in toDel)
                    cs.Remove(obj);
                return;
            }

            //��̬����
            lock (_TableCache)
            {
                // 2011-03-11 ��ʯͷ �����Ѿ���Ϊ����ƿ����������Ҫ�Ż���ƿ������_TableCache[sql]
                // 2011-11-22 ��ʯͷ ��Ϊ�������ϣ������Ǽ�ֵ������ÿ��ȡֵ��ʱ��Ҫ���²���
                List<String> toDel = new List<String>();
                foreach (var item in _TableCache)
                    if (item.Value.IsDependOn(tableName)) toDel.Add(item.Key);

                foreach (String sql in toDel)
                    _TableCache.Remove(sql);
            }
            lock (_IntCache)
            {
                List<String> toDel = new List<String>();
                foreach (var item in _IntCache)
                    if (item.Value.IsDependOn(tableName)) toDel.Add(item.Key);

                foreach (String sql in toDel)
                    _IntCache.Remove(sql);
            }
        }

        /// <summary>�Ƴ�������һ�����ݱ�Ļ���</summary>
        /// <param name="tableNames"></param>
        public static void Remove(String[] tableNames)
        {
            foreach (String tn in tableNames) Remove(tn);
        }

        /// <summary>��ջ���</summary>
        public static void RemoveAll()
        {
            //���󼶻���
            if (Kind == CacheKinds.���󼶻���)
            {
                var cs = Items;
                if (cs == null) return;

                List<Object> toDel = new List<Object>();
                foreach (Object obj in cs.Keys)
                {
                    String str = obj as String;
                    if (!String.IsNullOrEmpty(str) && (str.StartsWith(_dst) || str.StartsWith(_int))) toDel.Add(obj);
                }
                foreach (Object obj in toDel)
                    cs.Remove(obj);
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
        /// <summary>��ȡDataSet����</summary>
        /// <param name="sql">SQL���</param>
        /// <param name="ds">���</param>
        /// <returns></returns>
        public static Boolean TryGetItem(String sql, out DataSet ds)
        {
            ds = null;

            //�رջ���
            if (Kind == CacheKinds.�رջ���) return false;

            CheckShowStatics(ref NextShow, ref Total, ShowStatics);

            //���󼶻���
            if (Kind == CacheKinds.���󼶻���)
            {
                if (Items == null) return false;

                CacheItem<DataSet> ci = Items[_dst + sql] as CacheItem<DataSet>;
                if (ci == null) return false;

                ds = ci.Value;
            }
            else
            {
                CacheItem<DataSet> ci = null;
                if (!_TableCache.TryGetValue(sql, out ci) || ci == null) return false;
                ds = ci.Value;
            }

            Interlocked.Increment(ref Shoot);

            return true;
        }

        /// <summary>��ȡInt32����</summary>
        /// <param name="sql">SQL���</param>
        /// <param name="count">���</param>
        /// <returns></returns>
        public static Boolean TryGetItem(String sql, out Int32 count)
        {
            count = -1;

            //�رջ���
            if (Kind == CacheKinds.�رջ���) return false;

            CheckShowStatics(ref NextShow, ref Total, ShowStatics);

            //���󼶻���
            if (Kind == CacheKinds.���󼶻���)
            {
                if (Items == null) return false;

                CacheItem<Int32> ci = Items[_int + sql] as CacheItem<Int32>;
                if (ci == null) return false;

                count = ci.Value;
            }
            else
            {
                CacheItem<Int32> ci = null;
                if (!_IntCache.TryGetValue(sql, out ci) || ci == null) return false;
                count = ci.Value;
            }
            count = _IntCache[sql].Value;

            Interlocked.Increment(ref Shoot);

            return true;
        }
        #endregion

        #region ����
        /// <summary>�������</summary>
        internal static Int32 Count
        {
            get
            {
                //�رջ���
                if (Kind == CacheKinds.�رջ���) return 0;
                //���󼶻���
                if (Kind == CacheKinds.���󼶻���)
                {
                    if (Items == null) return 0;
                    Int32 k = 0;
                    foreach (Object obj in Items.Keys)
                    {
                        String str = obj as String;
                        if (!String.IsNullOrEmpty(str) && (str.StartsWith(_dst) || str.StartsWith(_int))) k++;
                    }
                    return k;
                }
                return _TableCache.Count + _IntCache.Count;
            }
        }

        /// <summary>���󼶻�����</summary>
        static IDictionary Items { get { return HttpContext.Current != null ? HttpContext.Current.Items : null; } }

        //private static Boolean? _Debug;
        ///// <summary>�Ƿ����</summary>
        //public static Boolean Debug
        //{
        //    get
        //    {
        //        if (_Debug == null) _Debug = Config.GetConfig<Boolean>("XCode.Cache.Debug", false);
        //        return _Debug.Value;
        //    }
        //    set { _Debug = value; }
        //}
        #endregion

        #region ͳ��
        /// <summary>�ܴ���</summary>
        public static Int32 Total;

        /// <summary>����</summary>
        public static Int32 Shoot;

        /// <summary>��һ����ʾʱ��</summary>
        public static DateTime NextShow;

        /// <summary>��鲢��ʾͳ����Ϣ</summary>
        /// <param name="next"></param>
        /// <param name="total"></param>
        /// <param name="show"></param>
        public static void CheckShowStatics(ref DateTime next, ref Int32 total, Func show)
        {
            if (next < DateTime.Now)
            {
                Boolean isfirst = next == DateTime.MinValue;
                next = DAL.Debug ? DateTime.Now.AddMinutes(10) : DateTime.Now.AddHours(24);

                if (!isfirst) show();
            }

            Interlocked.Increment(ref total);
        }

        /// <summary>��ʾͳ����Ϣ</summary>
        public static void ShowStatics()
        {
            if (Total > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("һ������<{0}>", Kind);
                sb.AppendFormat("�ܴ���{0}", Total);
                if (Shoot > 0) sb.AppendFormat("������{0}��{1:P02}��", Shoot, (Double)Shoot / Total);

                XTrace.WriteLine(sb.ToString());
            }
        }
        #endregion

        #region ��������
        /// <summary>���ݻ�������</summary>
        enum CacheKinds
        {
            /// <summary>�رջ���</summary>
            �رջ��� = -2,

            /// <summary>���󼶻���</summary>
            ���󼶻��� = -1,

            /// <summary>���þ�̬����</summary>
            ���þ�̬���� = 0,

            /// <summary>����Ч�ڻ���</summary>
            ��Ч�ڻ��� = 1
        }
        #endregion
    }
}