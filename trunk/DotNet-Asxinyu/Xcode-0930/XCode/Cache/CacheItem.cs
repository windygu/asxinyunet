using System;
using System.Collections.Generic;
using System.Text;

namespace XCode.Cache
{
    internal class CacheItem<T>
    {
        private T _TValue;
        /// <summary>
        /// �����DataSet
        /// </summary>
        public T TValue
        {
            get { return _TValue; }
        }

        /// <summary>
        /// �������ı�ı���
        /// </summary>
        private Dictionary<String, String> _TableNames;
        ///// <summary>
        ///// �������ı�ı���
        ///// </summary>
        //public List<String> TableNames
        //{
        //    get { return _TableNames; }
        //}

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CacheTime = DateTime.Now;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="tableNames"></param>
        /// <param name="tvalue"></param>
        public CacheItem(String[] tableNames, T tvalue)
        {
            if (tableNames != null && tableNames.Length > 0)
            {
                if (_TableNames == null)
                    _TableNames = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);
                else
                    _TableNames.Clear();

                for (Int32 i = 0; i < tableNames.Length; i++)
                    if (!_TableNames.ContainsKey(tableNames[i]))
                        _TableNames.Add(tableNames[i], null);
            }
            _TValue = tvalue;
        }

        /// <summary>
        /// �Ƿ�������ĳ����
        /// </summary>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        public Boolean IsDependOn(String tableName)
        {
            // �ձ���������*����ʾȫ��ƥ��
            if (String.IsNullOrEmpty(tableName) || tableName == "*") return true;
            // ��������������ƥ��
            if (_TableNames.ContainsKey(tableName)) return true;
            // ���Կ�������ʹ��*ʵ��ǰ׺ƥ����׺ƥ��
            return false;
        }
    }
}