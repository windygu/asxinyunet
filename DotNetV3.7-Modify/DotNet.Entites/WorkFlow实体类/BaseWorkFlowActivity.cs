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
    [BindIndex("PK_Base_WorkFlowActivity", true, "Id")]
    [BindTable("BaseWorkFlowActivity", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseWorkFlowActivity : IBaseWorkFlowActivity
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "", null, "int", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private Int32 _WorkFlowId;
        /// <summary></summary>
        [DisplayName("WorkFlowId")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "WorkFlowId", "", null, "int", 10, 0, false)]
        public virtual Int32 WorkFlowId
        {
            get { return _WorkFlowId; }
            set { if (OnPropertyChanging("WorkFlowId", value)) { _WorkFlowId = value; OnPropertyChanged("WorkFlowId"); } }
        }

        private String _Code;
        /// <summary></summary>
        [DisplayName("Code")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Code", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } }
        }

        private String _FullName;
        /// <summary></summary>
        [DisplayName("FullName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "FullName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FullName
        {
            get { return _FullName; }
            set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } }
        }

        private String _AuditDepartmentId;
        /// <summary></summary>
        [DisplayName("AuditDepartmentId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "AuditDepartmentId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditDepartmentId
        {
            get { return _AuditDepartmentId; }
            set { if (OnPropertyChanging("AuditDepartmentId", value)) { _AuditDepartmentId = value; OnPropertyChanged("AuditDepartmentId"); } }
        }

        private String _AuditDepartmentName;
        /// <summary></summary>
        [DisplayName("AuditDepartmentName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "AuditDepartmentName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditDepartmentName
        {
            get { return _AuditDepartmentName; }
            set { if (OnPropertyChanging("AuditDepartmentName", value)) { _AuditDepartmentName = value; OnPropertyChanged("AuditDepartmentName"); } }
        }

        private String _AuditUserId;
        /// <summary></summary>
        [DisplayName("AuditUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "AuditUserId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditUserId
        {
            get { return _AuditUserId; }
            set { if (OnPropertyChanging("AuditUserId", value)) { _AuditUserId = value; OnPropertyChanged("AuditUserId"); } }
        }

        private String _AuditUserCode;
        /// <summary></summary>
        [DisplayName("AuditUserCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "AuditUserCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditUserCode
        {
            get { return _AuditUserCode; }
            set { if (OnPropertyChanging("AuditUserCode", value)) { _AuditUserCode = value; OnPropertyChanged("AuditUserCode"); } }
        }

        private String _AuditUserRealname;
        /// <summary></summary>
        [DisplayName("AuditUserRealname")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "AuditUserRealname", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditUserRealname
        {
            get { return _AuditUserRealname; }
            set { if (OnPropertyChanging("AuditUserRealname", value)) { _AuditUserRealname = value; OnPropertyChanged("AuditUserRealname"); } }
        }

        private String _AuditRoleId;
        /// <summary></summary>
        [DisplayName("AuditRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "AuditRoleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditRoleId
        {
            get { return _AuditRoleId; }
            set { if (OnPropertyChanging("AuditRoleId", value)) { _AuditRoleId = value; OnPropertyChanged("AuditRoleId"); } }
        }

        private String _AuditRoleRealname;
        /// <summary></summary>
        [DisplayName("AuditRoleRealname")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "AuditRoleRealname", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditRoleRealname
        {
            get { return _AuditRoleRealname; }
            set { if (OnPropertyChanging("AuditRoleRealname", value)) { _AuditRoleRealname = value; OnPropertyChanged("AuditRoleRealname"); } }
        }

        private String _ActivityType;
        /// <summary></summary>
        [DisplayName("ActivityType")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "ActivityType", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ActivityType
        {
            get { return _ActivityType; }
            set { if (OnPropertyChanging("ActivityType", value)) { _ActivityType = value; OnPropertyChanged("ActivityType"); } }
        }

        private Int32 _AllowPrint;
        /// <summary></summary>
        [DisplayName("AllowPrint")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(13, "AllowPrint", "", "0", "int", 10, 0, false)]
        public virtual Int32 AllowPrint
        {
            get { return _AllowPrint; }
            set { if (OnPropertyChanging("AllowPrint", value)) { _AllowPrint = value; OnPropertyChanged("AllowPrint"); } }
        }

        private Int32 _AllowEditDocuments;
        /// <summary></summary>
        [DisplayName("AllowEditDocuments")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(14, "AllowEditDocuments", "", "0", "int", 10, 0, false)]
        public virtual Int32 AllowEditDocuments
        {
            get { return _AllowEditDocuments; }
            set { if (OnPropertyChanging("AllowEditDocuments", value)) { _AllowEditDocuments = value; OnPropertyChanged("AllowEditDocuments"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(15, "SortCode", "", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(16, "Enabled", "", "1", "int", 10, 0, false)]
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
        [BindColumn(17, "DeletionStateCode", "", "0", "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(18, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(19, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }

        private String _CreateUserId;
        /// <summary></summary>
        [DisplayName("CreateUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(20, "CreateUserId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateUserId
        {
            get { return _CreateUserId; }
            set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } }
        }

        private String _CreateBy;
        /// <summary></summary>
        [DisplayName("CreateBy")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(21, "CreateBy", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(22, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging("ModifiedOn", value)) { _ModifiedOn = value; OnPropertyChanged("ModifiedOn"); } }
        }

        private String _ModifiedUserId;
        /// <summary></summary>
        [DisplayName("ModifiedUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(23, "ModifiedUserId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ModifiedUserId
        {
            get { return _ModifiedUserId; }
            set { if (OnPropertyChanging("ModifiedUserId", value)) { _ModifiedUserId = value; OnPropertyChanged("ModifiedUserId"); } }
        }

        private String _ModifiedBy;
        /// <summary></summary>
        [DisplayName("ModifiedBy")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(24, "ModifiedBy", "", null, "nvarchar(50)", 0, 0, true)]
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
                    case "WorkFlowId" : return _WorkFlowId;
                    case "Code" : return _Code;
                    case "FullName" : return _FullName;
                    case "AuditDepartmentId" : return _AuditDepartmentId;
                    case "AuditDepartmentName" : return _AuditDepartmentName;
                    case "AuditUserId" : return _AuditUserId;
                    case "AuditUserCode" : return _AuditUserCode;
                    case "AuditUserRealname" : return _AuditUserRealname;
                    case "AuditRoleId" : return _AuditRoleId;
                    case "AuditRoleRealname" : return _AuditRoleRealname;
                    case "ActivityType" : return _ActivityType;
                    case "AllowPrint" : return _AllowPrint;
                    case "AllowEditDocuments" : return _AllowEditDocuments;
                    case "SortCode" : return _SortCode;
                    case "Enabled" : return _Enabled;
                    case "DeletionStateCode" : return _DeletionStateCode;
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
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "WorkFlowId" : _WorkFlowId = Convert.ToInt32(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "FullName" : _FullName = Convert.ToString(value); break;
                    case "AuditDepartmentId" : _AuditDepartmentId = Convert.ToString(value); break;
                    case "AuditDepartmentName" : _AuditDepartmentName = Convert.ToString(value); break;
                    case "AuditUserId" : _AuditUserId = Convert.ToString(value); break;
                    case "AuditUserCode" : _AuditUserCode = Convert.ToString(value); break;
                    case "AuditUserRealname" : _AuditUserRealname = Convert.ToString(value); break;
                    case "AuditRoleId" : _AuditRoleId = Convert.ToString(value); break;
                    case "AuditRoleRealname" : _AuditRoleRealname = Convert.ToString(value); break;
                    case "ActivityType" : _ActivityType = Convert.ToString(value); break;
                    case "AllowPrint" : _AllowPrint = Convert.ToInt32(value); break;
                    case "AllowEditDocuments" : _AllowEditDocuments = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
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
            public static readonly Field WorkFlowId = FindByName("WorkFlowId");

            ///<summary></summary>
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field FullName = FindByName("FullName");

            ///<summary></summary>
            public static readonly Field AuditDepartmentId = FindByName("AuditDepartmentId");

            ///<summary></summary>
            public static readonly Field AuditDepartmentName = FindByName("AuditDepartmentName");

            ///<summary></summary>
            public static readonly Field AuditUserId = FindByName("AuditUserId");

            ///<summary></summary>
            public static readonly Field AuditUserCode = FindByName("AuditUserCode");

            ///<summary></summary>
            public static readonly Field AuditUserRealname = FindByName("AuditUserRealname");

            ///<summary></summary>
            public static readonly Field AuditRoleId = FindByName("AuditRoleId");

            ///<summary></summary>
            public static readonly Field AuditRoleRealname = FindByName("AuditRoleRealname");

            ///<summary></summary>
            public static readonly Field ActivityType = FindByName("ActivityType");

            ///<summary></summary>
            public static readonly Field AllowPrint = FindByName("AllowPrint");

            ///<summary></summary>
            public static readonly Field AllowEditDocuments = FindByName("AllowEditDocuments");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

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
    public partial interface IBaseWorkFlowActivity
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        Int32 WorkFlowId { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        String FullName { get; set; }

        /// <summary></summary>
        String AuditDepartmentId { get; set; }

        /// <summary></summary>
        String AuditDepartmentName { get; set; }

        /// <summary></summary>
        String AuditUserId { get; set; }

        /// <summary></summary>
        String AuditUserCode { get; set; }

        /// <summary></summary>
        String AuditUserRealname { get; set; }

        /// <summary></summary>
        String AuditRoleId { get; set; }

        /// <summary></summary>
        String AuditRoleRealname { get; set; }

        /// <summary></summary>
        String ActivityType { get; set; }

        /// <summary></summary>
        Int32 AllowPrint { get; set; }

        /// <summary></summary>
        Int32 AllowEditDocuments { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

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