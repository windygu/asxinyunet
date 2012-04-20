/*
 * XCoder v4.7.4486.37599
 * 作者：Administrator/WIN-7ZX6E2GYT38
 * 时间：2012-04-20 08:38:02
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.Entites
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_Base_Sequence", true, "Id")]
    [BindTable("BaseSequence", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseSequence : IBaseSequence
    {
        #region 属性
        private String _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "Id", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _FullName;
        /// <summary></summary>
        [DisplayName("FullName")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "FullName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FullName
        {
            get { return _FullName; }
            set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } }
        }

        private String _Prefix;
        /// <summary></summary>
        [DisplayName("Prefix")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Prefix", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Prefix
        {
            get { return _Prefix; }
            set { if (OnPropertyChanging("Prefix", value)) { _Prefix = value; OnPropertyChanged("Prefix"); } }
        }

        private String _Separator;
        /// <summary></summary>
        [DisplayName("Separator")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Separator", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Separator
        {
            get { return _Separator; }
            set { if (OnPropertyChanging("Separator", value)) { _Separator = value; OnPropertyChanged("Separator"); } }
        }

        private Int32 _Sequence;
        /// <summary></summary>
        [DisplayName("Sequence")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "Sequence", "", "10000000", "int", 10, 0, false)]
        public virtual Int32 Sequence
        {
            get { return _Sequence; }
            set { if (OnPropertyChanging("Sequence", value)) { _Sequence = value; OnPropertyChanged("Sequence"); } }
        }

        private Int32 _Reduction;
        /// <summary></summary>
        [DisplayName("Reduction")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "Reduction", "", "9999999", "int", 10, 0, false)]
        public virtual Int32 Reduction
        {
            get { return _Reduction; }
            set { if (OnPropertyChanging("Reduction", value)) { _Reduction = value; OnPropertyChanged("Reduction"); } }
        }

        private Int32 _Step;
        /// <summary></summary>
        [DisplayName("Step")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "Step", "", "1", "int", 10, 0, false)]
        public virtual Int32 Step
        {
            get { return _Step; }
            set { if (OnPropertyChanging("Step", value)) { _Step = value; OnPropertyChanged("Step"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(8, "Description", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private DateTime _CreateOn;
        /// <summary></summary>
        [DisplayName("CreateOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }

        private String _CreateUserId;
        /// <summary></summary>
        [DisplayName("CreateUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(10, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String CreateUserId
        {
            get { return _CreateUserId; }
            set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } }
        }

        private String _CreateBy;
        /// <summary></summary>
        [DisplayName("CreateBy")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(11, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String CreateBy
        {
            get { return _CreateBy; }
            set { if (OnPropertyChanging("CreateBy", value)) { _CreateBy = value; OnPropertyChanged("CreateBy"); } }
        }

        private DateTime _ModifiedOn;
        /// <summary></summary>
        [DisplayName("ModifiedOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(12, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging("ModifiedOn", value)) { _ModifiedOn = value; OnPropertyChanged("ModifiedOn"); } }
        }

        private String _ModifiedUserId;
        /// <summary></summary>
        [DisplayName("ModifiedUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(13, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String ModifiedUserId
        {
            get { return _ModifiedUserId; }
            set { if (OnPropertyChanging("ModifiedUserId", value)) { _ModifiedUserId = value; OnPropertyChanged("ModifiedUserId"); } }
        }

        private String _ModifiedBy;
        /// <summary></summary>
        [DisplayName("ModifiedBy")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(14, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String ModifiedBy
        {
            get { return _ModifiedBy; }
            set { if (OnPropertyChanging("ModifiedBy", value)) { _ModifiedBy = value; OnPropertyChanged("ModifiedBy"); } }
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
                    case "Id" : return _Id;
                    case "FullName" : return _FullName;
                    case "Prefix" : return _Prefix;
                    case "Separator" : return _Separator;
                    case "Sequence" : return _Sequence;
                    case "Reduction" : return _Reduction;
                    case "Step" : return _Step;
                    case "Description" : return _Description;
                    case "CreateOn" : return _CreateOn;
                    case "CreateUserId" : return _CreateUserId;
                    case "CreateBy" : return _CreateBy;
                    case "ModifiedOn" : return _ModifiedOn;
                    case "ModifiedUserId" : return _ModifiedUserId;
                    case "ModifiedBy" : return _ModifiedBy;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToString(value); break;
                    case "FullName" : _FullName = Convert.ToString(value); break;
                    case "Prefix" : _Prefix = Convert.ToString(value); break;
                    case "Separator" : _Separator = Convert.ToString(value); break;
                    case "Sequence" : _Sequence = Convert.ToInt32(value); break;
                    case "Reduction" : _Reduction = Convert.ToInt32(value); break;
                    case "Step" : _Step = Convert.ToInt32(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "CreateOn" : _CreateOn = Convert.ToDateTime(value); break;
                    case "CreateUserId" : _CreateUserId = Convert.ToString(value); break;
                    case "CreateBy" : _CreateBy = Convert.ToString(value); break;
                    case "ModifiedOn" : _ModifiedOn = Convert.ToDateTime(value); break;
                    case "ModifiedUserId" : _ModifiedUserId = Convert.ToString(value); break;
                    case "ModifiedBy" : _ModifiedBy = Convert.ToString(value); break;
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
            public static readonly Field Id = FindByName("Id");

            ///<summary></summary>
            public static readonly Field FullName = FindByName("FullName");

            ///<summary></summary>
            public static readonly Field Prefix = FindByName("Prefix");

            ///<summary></summary>
            public static readonly Field Separator = FindByName("Separator");

            ///<summary></summary>
            public static readonly Field Sequence = FindByName("Sequence");

            ///<summary></summary>
            public static readonly Field Reduction = FindByName("Reduction");

            ///<summary></summary>
            public static readonly Field Step = FindByName("Step");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field CreateOn = FindByName("CreateOn");

            ///<summary></summary>
            public static readonly Field CreateUserId = FindByName("CreateUserId");

            ///<summary></summary>
            public static readonly Field CreateBy = FindByName("CreateBy");

            ///<summary></summary>
            public static readonly Field ModifiedOn = FindByName("ModifiedOn");

            ///<summary></summary>
            public static readonly Field ModifiedUserId = FindByName("ModifiedUserId");

            ///<summary></summary>
            public static readonly Field ModifiedBy = FindByName("ModifiedBy");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IBaseSequence
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String FullName { get; set; }

        /// <summary></summary>
        String Prefix { get; set; }

        /// <summary></summary>
        String Separator { get; set; }

        /// <summary></summary>
        Int32 Sequence { get; set; }

        /// <summary></summary>
        Int32 Reduction { get; set; }

        /// <summary></summary>
        Int32 Step { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        DateTime CreateOn { get; set; }

        /// <summary></summary>
        String CreateUserId { get; set; }

        /// <summary></summary>
        String CreateBy { get; set; }

        /// <summary></summary>
        DateTime ModifiedOn { get; set; }

        /// <summary></summary>
        String ModifiedUserId { get; set; }

        /// <summary></summary>
        String ModifiedBy { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}