using System;
using System.Reflection;

namespace XCode
{
    /// <summary>
    /// ָ��ʵ�����������������ֶ���Ϣ��
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class BindColumnAttribute : Attribute
    {
        #region ����
        private Int32 _Order;
        /// <summary>˳��</summary>
        public Int32 Order
        {
            get { return _Order; }
            set { _Order = value; }
        }

        private String _Name;
        /// <summary>�ֶ���</summary>
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

        private String _DefaultValue;
        /// <summary>Ĭ��ֵ</summary>
        public String DefaultValue
        {
            get { return _DefaultValue; }
            set { _DefaultValue = value; }
        }

        private String _RawType;
        /// <summary>
        /// ԭʼ�������͡�
        /// ���ҽ���Ŀ�����ݿ�ͬΪ�����ݿ�����ʱ������ʵ��������Ϣ�ϵ�RawType��Ϊ���򹤳̵�Ŀ���ֶ����ͣ����ڻ�ÿ�������������Ѽ��ݡ�
        /// </summary>
        public String RawType
        {
            get { return _RawType; }
            set { _RawType = value; }
        }

        private Int32 _Precision;
        /// <summary>����</summary>
        public Int32 Precision
        {
            get { return _Precision; }
            set { _Precision = value; }
        }

        private Int32 _Scale;
        /// <summary>λ��</summary>
        public Int32 Scale
        {
            get { return _Scale; }
            set { _Scale = value; }
        }

        private Boolean _IsUnicode;
        /// <summary>�Ƿ�Unicode</summary>
        public Boolean IsUnicode
        {
            get { return _IsUnicode; }
            set { _IsUnicode = value; }
        }
        #endregion

        #region ����
        /// <summary>
        /// ���캯��
        /// </summary>
        public BindColumnAttribute() { }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name">�ֶ���</param>
        public BindColumnAttribute(String name)
        {
            Name = name;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="order"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="defaultValue"></param>
        public BindColumnAttribute(Int32 order, String name, String description, String defaultValue)
        {
            Order = order;
            Name = name;
            Description = description;
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="order"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="defaultValue"></param>
        /// <param name="rawType"></param>
        /// <param name="precision"></param>
        /// <param name="scale"></param>
        /// <param name="isUnicode"></param>
        public BindColumnAttribute(Int32 order, String name, String description, String defaultValue, String rawType, Int32 precision, Int32 scale, Boolean isUnicode)
            : this(order, name, description, defaultValue)
        {
            RawType = rawType;
            Precision = precision;
            Scale = scale;
            IsUnicode = isUnicode;
        }
        #endregion

        #region ����
        /// <summary>
        /// ����Ӧ�������ͳ�Ա���Զ������ԡ�
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static BindColumnAttribute GetCustomAttribute(MemberInfo element)
        {
            return GetCustomAttribute(element, typeof(BindColumnAttribute)) as BindColumnAttribute;
        }
        #endregion
    }
}