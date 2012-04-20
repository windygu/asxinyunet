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
    [BindIndex("PK_BASE_WORKFLOWHISTORY", true, "Id")]
    [BindTable("BaseWorkFlowHistory", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseWorkFlowHistory : IBaseWorkFlowHistory
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

        private String _CurrentFlowId;
        /// <summary></summary>
        [DisplayName("CurrentFlowId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "CurrentFlowId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CurrentFlowId
        {
            get { return _CurrentFlowId; }
            set { if (OnPropertyChanging("CurrentFlowId", value)) { _CurrentFlowId = value; OnPropertyChanged("CurrentFlowId"); } }
        }

        private Int32 _WorkFlowId;
        /// <summary></summary>
        [DisplayName("WorkFlowId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "WorkFlowId", "", null, "int", 10, 0, false)]
        public virtual Int32 WorkFlowId
        {
            get { return _WorkFlowId; }
            set { if (OnPropertyChanging("WorkFlowId", value)) { _WorkFlowId = value; OnPropertyChanged("WorkFlowId"); } }
        }

        private Int32 _ActivityId;
        /// <summary></summary>
        [DisplayName("ActivityId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "ActivityId", "", null, "int", 10, 0, false)]
        public virtual Int32 ActivityId
        {
            get { return _ActivityId; }
            set { if (OnPropertyChanging("ActivityId", value)) { _ActivityId = value; OnPropertyChanged("ActivityId"); } }
        }

        private String _ActivityFullName;
        /// <summary></summary>
        [DisplayName("ActivityFullName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "ActivityFullName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ActivityFullName
        {
            get { return _ActivityFullName; }
            set { if (OnPropertyChanging("ActivityFullName", value)) { _ActivityFullName = value; OnPropertyChanged("ActivityFullName"); } }
        }

        private Int32 _ToDepartmentId;
        /// <summary></summary>
        [DisplayName("ToDepartmentId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "ToDepartmentId", "", null, "int", 10, 0, false)]
        public virtual Int32 ToDepartmentId
        {
            get { return _ToDepartmentId; }
            set { if (OnPropertyChanging("ToDepartmentId", value)) { _ToDepartmentId = value; OnPropertyChanged("ToDepartmentId"); } }
        }

        private String _ToDepartmentName;
        /// <summary></summary>
        [DisplayName("ToDepartmentName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "ToDepartmentName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ToDepartmentName
        {
            get { return _ToDepartmentName; }
            set { if (OnPropertyChanging("ToDepartmentName", value)) { _ToDepartmentName = value; OnPropertyChanged("ToDepartmentName"); } }
        }

        private Int32 _ToUserId;
        /// <summary></summary>
        [DisplayName("ToUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "ToUserId", "", null, "int", 10, 0, false)]
        public virtual Int32 ToUserId
        {
            get { return _ToUserId; }
            set { if (OnPropertyChanging("ToUserId", value)) { _ToUserId = value; OnPropertyChanged("ToUserId"); } }
        }

        private String _ToUserRealname;
        /// <summary></summary>
        [DisplayName("ToUserRealname")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "ToUserRealname", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ToUserRealname
        {
            get { return _ToUserRealname; }
            set { if (OnPropertyChanging("ToUserRealname", value)) { _ToUserRealname = value; OnPropertyChanged("ToUserRealname"); } }
        }

        private Int32 _ToRoleId;
        /// <summary></summary>
        [DisplayName("ToRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "ToRoleId", "", null, "int", 10, 0, false)]
        public virtual Int32 ToRoleId
        {
            get { return _ToRoleId; }
            set { if (OnPropertyChanging("ToRoleId", value)) { _ToRoleId = value; OnPropertyChanged("ToRoleId"); } }
        }

        private String _ToRoleRealname;
        /// <summary></summary>
        [DisplayName("ToRoleRealname")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "ToRoleRealname", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ToRoleRealname
        {
            get { return _ToRoleRealname; }
            set { if (OnPropertyChanging("ToRoleRealname", value)) { _ToRoleRealname = value; OnPropertyChanged("ToRoleRealname"); } }
        }

        private Int32 _AuditUserId;
        /// <summary></summary>
        [DisplayName("AuditUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(12, "AuditUserId", "", null, "int", 10, 0, false)]
        public virtual Int32 AuditUserId
        {
            get { return _AuditUserId; }
            set { if (OnPropertyChanging("AuditUserId", value)) { _AuditUserId = value; OnPropertyChanged("AuditUserId"); } }
        }

        private String _AuditUserCode;
        /// <summary></summary>
        [DisplayName("AuditUserCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "AuditUserCode", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(14, "AuditUserRealname", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditUserRealname
        {
            get { return _AuditUserRealname; }
            set { if (OnPropertyChanging("AuditUserRealname", value)) { _AuditUserRealname = value; OnPropertyChanged("AuditUserRealname"); } }
        }

        private String _AuditIdea;
        /// <summary></summary>
        [DisplayName("AuditIdea")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(15, "AuditIdea", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String AuditIdea
        {
            get { return _AuditIdea; }
            set { if (OnPropertyChanging("AuditIdea", value)) { _AuditIdea = value; OnPropertyChanged("AuditIdea"); } }
        }

        private DateTime _SendDate;
        /// <summary></summary>
        [DisplayName("SendDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(16, "SendDate", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime SendDate
        {
            get { return _SendDate; }
            set { if (OnPropertyChanging("SendDate", value)) { _SendDate = value; OnPropertyChanged("SendDate"); } }
        }

        private DateTime _AuditDate;
        /// <summary></summary>
        [DisplayName("AuditDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(17, "AuditDate", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime AuditDate
        {
            get { return _AuditDate; }
            set { if (OnPropertyChanging("AuditDate", value)) { _AuditDate = value; OnPropertyChanged("AuditDate"); } }
        }

        private String _AuditStatus;
        /// <summary></summary>
        [DisplayName("AuditStatus")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(18, "AuditStatus", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditStatus
        {
            get { return _AuditStatus; }
            set { if (OnPropertyChanging("AuditStatus", value)) { _AuditStatus = value; OnPropertyChanged("AuditStatus"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(19, "SortCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(20, "Enabled", "", "1", "int", 10, 0, false)]
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
        [BindColumn(21, "DeletionStateCode", "", "0", "int", 10, 0, false)]
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
        [BindColumn(22, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(23, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(24, "CreateUserId", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(25, "CreateBy", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(26, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(27, "ModifiedUserId", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(28, "ModifiedBy", "", null, "nvarchar(50)", 0, 0, true)]
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
                    case "CurrentFlowId" : return _CurrentFlowId;
                    case "WorkFlowId" : return _WorkFlowId;
                    case "ActivityId" : return _ActivityId;
                    case "ActivityFullName" : return _ActivityFullName;
                    case "ToDepartmentId" : return _ToDepartmentId;
                    case "ToDepartmentName" : return _ToDepartmentName;
                    case "ToUserId" : return _ToUserId;
                    case "ToUserRealname" : return _ToUserRealname;
                    case "ToRoleId" : return _ToRoleId;
                    case "ToRoleRealname" : return _ToRoleRealname;
                    case "AuditUserId" : return _AuditUserId;
                    case "AuditUserCode" : return _AuditUserCode;
                    case "AuditUserRealname" : return _AuditUserRealname;
                    case "AuditIdea" : return _AuditIdea;
                    case "SendDate" : return _SendDate;
                    case "AuditDate" : return _AuditDate;
                    case "AuditStatus" : return _AuditStatus;
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
                    case "CurrentFlowId" : _CurrentFlowId = Convert.ToString(value); break;
                    case "WorkFlowId" : _WorkFlowId = Convert.ToInt32(value); break;
                    case "ActivityId" : _ActivityId = Convert.ToInt32(value); break;
                    case "ActivityFullName" : _ActivityFullName = Convert.ToString(value); break;
                    case "ToDepartmentId" : _ToDepartmentId = Convert.ToInt32(value); break;
                    case "ToDepartmentName" : _ToDepartmentName = Convert.ToString(value); break;
                    case "ToUserId" : _ToUserId = Convert.ToInt32(value); break;
                    case "ToUserRealname" : _ToUserRealname = Convert.ToString(value); break;
                    case "ToRoleId" : _ToRoleId = Convert.ToInt32(value); break;
                    case "ToRoleRealname" : _ToRoleRealname = Convert.ToString(value); break;
                    case "AuditUserId" : _AuditUserId = Convert.ToInt32(value); break;
                    case "AuditUserCode" : _AuditUserCode = Convert.ToString(value); break;
                    case "AuditUserRealname" : _AuditUserRealname = Convert.ToString(value); break;
                    case "AuditIdea" : _AuditIdea = Convert.ToString(value); break;
                    case "SendDate" : _SendDate = Convert.ToDateTime(value); break;
                    case "AuditDate" : _AuditDate = Convert.ToDateTime(value); break;
                    case "AuditStatus" : _AuditStatus = Convert.ToString(value); break;
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
            public static readonly Field CurrentFlowId = FindByName("CurrentFlowId");

            ///<summary></summary>
            public static readonly Field WorkFlowId = FindByName("WorkFlowId");

            ///<summary></summary>
            public static readonly Field ActivityId = FindByName("ActivityId");

            ///<summary></summary>
            public static readonly Field ActivityFullName = FindByName("ActivityFullName");

            ///<summary></summary>
            public static readonly Field ToDepartmentId = FindByName("ToDepartmentId");

            ///<summary></summary>
            public static readonly Field ToDepartmentName = FindByName("ToDepartmentName");

            ///<summary></summary>
            public static readonly Field ToUserId = FindByName("ToUserId");

            ///<summary></summary>
            public static readonly Field ToUserRealname = FindByName("ToUserRealname");

            ///<summary></summary>
            public static readonly Field ToRoleId = FindByName("ToRoleId");

            ///<summary></summary>
            public static readonly Field ToRoleRealname = FindByName("ToRoleRealname");

            ///<summary></summary>
            public static readonly Field AuditUserId = FindByName("AuditUserId");

            ///<summary></summary>
            public static readonly Field AuditUserCode = FindByName("AuditUserCode");

            ///<summary></summary>
            public static readonly Field AuditUserRealname = FindByName("AuditUserRealname");

            ///<summary></summary>
            public static readonly Field AuditIdea = FindByName("AuditIdea");

            ///<summary></summary>
            public static readonly Field SendDate = FindByName("SendDate");

            ///<summary></summary>
            public static readonly Field AuditDate = FindByName("AuditDate");

            ///<summary></summary>
            public static readonly Field AuditStatus = FindByName("AuditStatus");

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
    public partial interface IBaseWorkFlowHistory
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String CurrentFlowId { get; set; }

        /// <summary></summary>
        Int32 WorkFlowId { get; set; }

        /// <summary></summary>
        Int32 ActivityId { get; set; }

        /// <summary></summary>
        String ActivityFullName { get; set; }

        /// <summary></summary>
        Int32 ToDepartmentId { get; set; }

        /// <summary></summary>
        String ToDepartmentName { get; set; }

        /// <summary></summary>
        Int32 ToUserId { get; set; }

        /// <summary></summary>
        String ToUserRealname { get; set; }

        /// <summary></summary>
        Int32 ToRoleId { get; set; }

        /// <summary></summary>
        String ToRoleRealname { get; set; }

        /// <summary></summary>
        Int32 AuditUserId { get; set; }

        /// <summary></summary>
        String AuditUserCode { get; set; }

        /// <summary></summary>
        String AuditUserRealname { get; set; }

        /// <summary></summary>
        String AuditIdea { get; set; }

        /// <summary></summary>
        DateTime SendDate { get; set; }

        /// <summary></summary>
        DateTime AuditDate { get; set; }

        /// <summary></summary>
        String AuditStatus { get; set; }

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