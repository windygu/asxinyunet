/*
 * XCoder v4.7.4486.37599
 * 作者：Administrator/WIN-7ZX6E2GYT38
 * 时间：2012-04-20 09:19:21
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.Entites.WorkFlow
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_Base_Parameter", true, "ID")]
    [BindTable("BaseParameter", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseParameter : IBaseParameter
    {
        #region 属性
        private String _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, false, false, 40)]
        [BindColumn(1, "ID", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private String _CategoryID;
        /// <summary></summary>
        [DisplayName("CategoryID")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(2, "CategoryID", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String CategoryID
        {
            get { return _CategoryID; }
            set { if (OnPropertyChanging("CategoryID", value)) { _CategoryID = value; OnPropertyChanged("CategoryID"); } }
        }

        private String _ParameterID;
        /// <summary></summary>
        [DisplayName("ParameterID")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(3, "ParameterID", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String ParameterID
        {
            get { return _ParameterID; }
            set { if (OnPropertyChanging("ParameterID", value)) { _ParameterID = value; OnPropertyChanged("ParameterID"); } }
        }

        private String _ParameterCode;
        /// <summary></summary>
        [DisplayName("ParameterCode")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(4, "ParameterCode", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String ParameterCode
        {
            get { return _ParameterCode; }
            set { if (OnPropertyChanging("ParameterCode", value)) { _ParameterCode = value; OnPropertyChanged("ParameterCode"); } }
        }

        private String _ParameterContent;
        /// <summary></summary>
        [DisplayName("ParameterContent")]
        [Description("")]
        [DataObjectField(false, false, true, 2000)]
        [BindColumn(5, "ParameterContent", "", null, "nvarchar(2000)", 0, 0, true)]
        public virtual String ParameterContent
        {
            get { return _ParameterContent; }
            set { if (OnPropertyChanging("ParameterContent", value)) { _ParameterContent = value; OnPropertyChanged("ParameterContent"); } }
        }

        private Int32 _Worked;
        /// <summary></summary>
        [DisplayName("Worked")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "Worked", "", null, "int", 10, 0, false)]
        public virtual Int32 Worked
        {
            get { return _Worked; }
            set { if (OnPropertyChanging("Worked", value)) { _Worked = value; OnPropertyChanged("Worked"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "Enabled", "", null, "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "DeletionStateCode", "", null, "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "SortCode", "", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(10, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(11, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(12, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(13, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(14, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(15, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(16, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "ID" : return _ID;
                    case "CategoryID" : return _CategoryID;
                    case "ParameterID" : return _ParameterID;
                    case "ParameterCode" : return _ParameterCode;
                    case "ParameterContent" : return _ParameterContent;
                    case "Worked" : return _Worked;
                    case "Enabled" : return _Enabled;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "SortCode" : return _SortCode;
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
                    case "ID" : _ID = Convert.ToString(value); break;
                    case "CategoryID" : _CategoryID = Convert.ToString(value); break;
                    case "ParameterID" : _ParameterID = Convert.ToString(value); break;
                    case "ParameterCode" : _ParameterCode = Convert.ToString(value); break;
                    case "ParameterContent" : _ParameterContent = Convert.ToString(value); break;
                    case "Worked" : _Worked = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
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
            public static readonly Field ID = FindByName("ID");

            ///<summary></summary>
            public static readonly Field CategoryID = FindByName("CategoryID");

            ///<summary></summary>
            public static readonly Field ParameterID = FindByName("ParameterID");

            ///<summary></summary>
            public static readonly Field ParameterCode = FindByName("ParameterCode");

            ///<summary></summary>
            public static readonly Field ParameterContent = FindByName("ParameterContent");

            ///<summary></summary>
            public static readonly Field Worked = FindByName("Worked");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

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
    public partial interface IBaseParameter
    {
        #region 属性
        /// <summary></summary>
        String ID { get; set; }

        /// <summary></summary>
        String CategoryID { get; set; }

        /// <summary></summary>
        String ParameterID { get; set; }

        /// <summary></summary>
        String ParameterCode { get; set; }

        /// <summary></summary>
        String ParameterContent { get; set; }

        /// <summary></summary>
        Int32 Worked { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

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