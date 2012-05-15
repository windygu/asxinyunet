﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace ResourceEnties
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_PERSON", true, "PERSONID")]
    [BindTable("PERSON", Description = "", ConnName = "StudentConn", DbType = DatabaseType.SqlServer)]
    public partial class PERSON : IPERSON
    {
        #region 属性
        private String _PERSONID;
        /// <summary></summary>
        [DisplayName("PERSONID")]
        [Description("")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn(1, "PERSONID", "", null, "varchar(10)", 0, 0, false)]
        public virtual String PERSONID
        {
            get { return _PERSONID; }
            set { if (OnPropertyChanging("PERSONID", value)) { _PERSONID = value; OnPropertyChanged("PERSONID"); } }
        }

        private String _NAME;
        /// <summary></summary>
        [DisplayName("NAME")]
        [Description("")]
        [DataObjectField(false, false, true, 60)]
        [BindColumn(2, "NAME", "", null, "varchar(60)", 0, 0, false)]
        public virtual String NAME
        {
            get { return _NAME; }
            set { if (OnPropertyChanging("NAME", value)) { _NAME = value; OnPropertyChanged("NAME"); } }
        }

        private String _IDCARD;
        /// <summary></summary>
        [DisplayName("IDCARD")]
        [Description("")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(3, "IDCARD", "", null, "varchar(18)", 0, 0, false)]
        public virtual String IDCARD
        {
            get { return _IDCARD; }
            set { if (OnPropertyChanging("IDCARD", value)) { _IDCARD = value; OnPropertyChanged("IDCARD"); } }
        }

        private String _SEX;
        /// <summary></summary>
        [DisplayName("SEX")]
        [Description("")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(4, "SEX", "", null, "varchar(1)", 0, 0, false)]
        public virtual String SEX
        {
            get { return _SEX; }
            set { if (OnPropertyChanging("SEX", value)) { _SEX = value; OnPropertyChanged("SEX"); } }
        }

        private DateTime _BIRTHDAY;
        /// <summary></summary>
        [DisplayName("BIRTHDAY")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "BIRTHDAY", "", null, "datetime", 3, 0, false)]
        public virtual DateTime BIRTHDAY
        {
            get { return _BIRTHDAY; }
            set { if (OnPropertyChanging("BIRTHDAY", value)) { _BIRTHDAY = value; OnPropertyChanged("BIRTHDAY"); } }
        }

        private Int32 _YEAROLD;
        /// <summary></summary>
        [DisplayName("YEAROLD")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "YEAROLD", "", null, "int", 10, 0, false)]
        public virtual Int32 YEAROLD
        {
            get { return _YEAROLD; }
            set { if (OnPropertyChanging("YEAROLD", value)) { _YEAROLD = value; OnPropertyChanged("YEAROLD"); } }
        }

        private String _TEL;
        /// <summary></summary>
        [DisplayName("TEL")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "TEL", "", null, "varchar(50)", 0, 0, false)]
        public virtual String TEL
        {
            get { return _TEL; }
            set { if (OnPropertyChanging("TEL", value)) { _TEL = value; OnPropertyChanged("TEL"); } }
        }

        private String _EMAIL;
        /// <summary></summary>
        [DisplayName("EMAIL")]
        [Description("")]
        [DataObjectField(false, false, true, 60)]
        [BindColumn(8, "EMAIL", "", null, "varchar(60)", 0, 0, false)]
        public virtual String EMAIL
        {
            get { return _EMAIL; }
            set { if (OnPropertyChanging("EMAIL", value)) { _EMAIL = value; OnPropertyChanged("EMAIL"); } }
        }

        private String _BAK;
        /// <summary></summary>
        [DisplayName("BAK")]
        [Description("")]
        [DataObjectField(false, false, true, 4000)]
        [BindColumn(9, "BAK", "", null, "varchar(4000)", 0, 0, false)]
        public virtual String BAK
        {
            get { return _BAK; }
            set { if (OnPropertyChanging("BAK", value)) { _BAK = value; OnPropertyChanged("BAK"); } }
        }

        private String _PLACECODE;
        /// <summary></summary>
        [DisplayName("PLACECODE")]
        [Description("")]
        [DataObjectField(false, false, true, 6)]
        [BindColumn(10, "PLACECODE", "", null, "varchar(6)", 0, 0, false)]
        public virtual String PLACECODE
        {
            get { return _PLACECODE; }
            set { if (OnPropertyChanging("PLACECODE", value)) { _PLACECODE = value; OnPropertyChanged("PLACECODE"); } }
        }
		#endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "PERSONID" : return _PERSONID;
                    case "NAME" : return _NAME;
                    case "IDCARD" : return _IDCARD;
                    case "SEX" : return _SEX;
                    case "BIRTHDAY" : return _BIRTHDAY;
                    case "YEAROLD" : return _YEAROLD;
                    case "TEL" : return _TEL;
                    case "EMAIL" : return _EMAIL;
                    case "BAK" : return _BAK;
                    case "PLACECODE" : return _PLACECODE;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "PERSONID" : _PERSONID = Convert.ToString(value); break;
                    case "NAME" : _NAME = Convert.ToString(value); break;
                    case "IDCARD" : _IDCARD = Convert.ToString(value); break;
                    case "SEX" : _SEX = Convert.ToString(value); break;
                    case "BIRTHDAY" : _BIRTHDAY = Convert.ToDateTime(value); break;
                    case "YEAROLD" : _YEAROLD = Convert.ToInt32(value); break;
                    case "TEL" : _TEL = Convert.ToString(value); break;
                    case "EMAIL" : _EMAIL = Convert.ToString(value); break;
                    case "BAK" : _BAK = Convert.ToString(value); break;
                    case "PLACECODE" : _PLACECODE = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary></summary>
            public static readonly Field PERSONID = FindByName("PERSONID");

            ///<summary></summary>
            public static readonly Field NAME = FindByName("NAME");

            ///<summary></summary>
            public static readonly Field IDCARD = FindByName("IDCARD");

            ///<summary></summary>
            public static readonly Field SEX = FindByName("SEX");

            ///<summary></summary>
            public static readonly Field BIRTHDAY = FindByName("BIRTHDAY");

            ///<summary></summary>
            public static readonly Field YEAROLD = FindByName("YEAROLD");

            ///<summary></summary>
            public static readonly Field TEL = FindByName("TEL");

            ///<summary></summary>
            public static readonly Field EMAIL = FindByName("EMAIL");

            ///<summary></summary>
            public static readonly Field BAK = FindByName("BAK");

            ///<summary></summary>
            public static readonly Field PLACECODE = FindByName("PLACECODE");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IPERSON
    {
        #region 属性
        /// <summary></summary>
        String PERSONID { get; set; }

        /// <summary></summary>
        String NAME { get; set; }

        /// <summary></summary>
        String IDCARD { get; set; }

        /// <summary></summary>
        String SEX { get; set; }

        /// <summary></summary>
        DateTime BIRTHDAY { get; set; }

        /// <summary></summary>
        Int32 YEAROLD { get; set; }

        /// <summary></summary>
        String TEL { get; set; }

        /// <summary></summary>
        String EMAIL { get; set; }

        /// <summary></summary>
        String BAK { get; set; }

        /// <summary></summary>
        String PLACECODE { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}