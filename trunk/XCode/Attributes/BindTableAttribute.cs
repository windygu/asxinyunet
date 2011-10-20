using System;
using System.Reflection;
using XCode.DataAccessLayer;

namespace XCode
{
    /// <summary>
    /// ָ��ʵ�������󶨵����ݱ���Ϣ��
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class BindTableAttribute : Attribute
    {
        private String _Name;
        /// <summary>
        /// ������
        /// �����������ļ���ͨ��XCode.ConnMaps��ʵ��ӳ�䵽������ݱ���
        /// </summary>
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private String _Description;
        /// <summary>����</summary>
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private String _ConnName;
        /// <summary>
        /// ��������
        /// ʵ������������ݿ�������������ڸ�������ָ�������ݿ������ϡ�
        /// ���⣬�ɶ�̬�޸�ʵ�����ڵ�ǰ�߳��ϵ�����������Meta.ConnName����
        /// Ҳ�����������ļ���ͨ��XCode.ConnMaps��������ӳ�䵽��������ϡ�
        /// </summary>
        public String ConnName
        {
            get { return _ConnName; }
            set { _ConnName = value; }
        }

        private DatabaseType _DbType;
        /// <summary>
        /// ���ݿ����͡�
        /// �����ڼ�¼ʵ�����ɺ����������ݿ����ɣ����ҽ���Ŀ�����ݿ�ͬΪ�����ݿ�����ʱ������ʵ��������Ϣ�ϵ�RawType��Ϊ���򹤳̵�Ŀ���ֶ����ͣ����ڻ�ÿ�������������Ѽ��ݡ�
        /// </summary>
        public DatabaseType DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name">����</param>
        public BindTableAttribute(String name)
        {
            Name = name;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="description">����</param>
        public BindTableAttribute(String name, String description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// ����Ӧ�������ͳ�Ա���Զ������ԡ�
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static BindTableAttribute GetCustomAttribute(MemberInfo element)
        {
            return GetCustomAttribute(element, typeof(BindTableAttribute)) as BindTableAttribute;
        }
    }
}