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
    [BindIndex("PK_Base_WorkReport", true, "Id")]
    [BindTable("BaseWorkReport", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseWorkReport : IBaseWorkReport
    {
        #region 属性
        private String _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, false, false, 40)]
        [BindColumn(1, "Id", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _CompanyId;
        /// <summary></summary>
        [DisplayName("CompanyId")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(2, "CompanyId", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String CompanyId
        {
            get { return _CompanyId; }
            set { if (OnPropertyChanging("CompanyId", value)) { _CompanyId = value; OnPropertyChanged("CompanyId"); } }
        }

        private String _DepartmentId;
        /// <summary></summary>
        [DisplayName("DepartmentId")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(3, "DepartmentId", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String DepartmentId
        {
            get { return _DepartmentId; }
            set { if (OnPropertyChanging("DepartmentId", value)) { _DepartmentId = value; OnPropertyChanged("DepartmentId"); } }
        }

        private String _StaffId;
        /// <summary></summary>
        [DisplayName("StaffId")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(4, "StaffId", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String StaffId
        {
            get { return _StaffId; }
            set { if (OnPropertyChanging("StaffId", value)) { _StaffId = value; OnPropertyChanged("StaffId"); } }
        }

        private String _CategoryID;
        /// <summary></summary>
        [DisplayName("CategoryID")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(5, "CategoryID", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String CategoryID
        {
            get { return _CategoryID; }
            set { if (OnPropertyChanging("CategoryID", value)) { _CategoryID = value; OnPropertyChanged("CategoryID"); } }
        }

        private String _WorkDate;
        /// <summary></summary>
        [DisplayName("WorkDate")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(6, "WorkDate", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String WorkDate
        {
            get { return _WorkDate; }
            set { if (OnPropertyChanging("WorkDate", value)) { _WorkDate = value; OnPropertyChanged("WorkDate"); } }
        }

        private String _Content;
        /// <summary></summary>
        [DisplayName("Content")]
        [Description("")]
        [DataObjectField(false, false, true, 800)]
        [BindColumn(7, "Content", "", null, "nvarchar(800)", 0, 0, true)]
        public virtual String Content
        {
            get { return _Content; }
            set { if (OnPropertyChanging("Content", value)) { _Content = value; OnPropertyChanged("Content"); } }
        }

        private Decimal _ManHour;
        /// <summary></summary>
        [DisplayName("ManHour")]
        [Description("")]
        [DataObjectField(false, false, false, 18)]
        [BindColumn(8, "ManHour", "", "0", "numeric(18,1)", 18, 1, false)]
        public virtual Decimal ManHour
        {
            get { return _ManHour; }
            set { if (OnPropertyChanging("ManHour", value)) { _ManHour = value; OnPropertyChanged("ManHour"); } }
        }

        private String _ProjectId;
        /// <summary></summary>
        [DisplayName("ProjectId")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(9, "ProjectId", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String ProjectId
        {
            get { return _ProjectId; }
            set { if (OnPropertyChanging("ProjectId", value)) { _ProjectId = value; OnPropertyChanged("ProjectId"); } }
        }

        private Int32 _Score;
        /// <summary></summary>
        [DisplayName("Score")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(10, "Score", "", "0", "int", 10, 0, false)]
        public virtual Int32 Score
        {
            get { return _Score; }
            set { if (OnPropertyChanging("Score", value)) { _Score = value; OnPropertyChanged("Score"); } }
        }

        private String _AuditStaffId;
        /// <summary></summary>
        [DisplayName("AuditStaffId")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(11, "AuditStaffId", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String AuditStaffId
        {
            get { return _AuditStaffId; }
            set { if (OnPropertyChanging("AuditStaffId", value)) { _AuditStaffId = value; OnPropertyChanged("AuditStaffId"); } }
        }

        private String _AuditStaffFullName;
        /// <summary></summary>
        [DisplayName("AuditStaffFullName")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(12, "AuditStaffFullName", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String AuditStaffFullName
        {
            get { return _AuditStaffFullName; }
            set { if (OnPropertyChanging("AuditStaffFullName", value)) { _AuditStaffFullName = value; OnPropertyChanged("AuditStaffFullName"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(13, "Description", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private Int32 _StateCode;
        /// <summary></summary>
        [DisplayName("StateCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(14, "StateCode", "", null, "int", 10, 0, false)]
        public virtual Int32 StateCode
        {
            get { return _StateCode; }
            set { if (OnPropertyChanging("StateCode", value)) { _StateCode = value; OnPropertyChanged("StateCode"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(15, "Enabled", "", null, "int", 10, 0, false)]
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
        [BindColumn(16, "DeletionStateCode", "", null, "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private String _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(17, "SortCode", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private DateTime _CreateOn;
        /// <summary></summary>
        [DisplayName("CreateOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(18, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(19, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(20, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(21, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(22, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(23, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "CompanyId" : return _CompanyId;
                    case "DepartmentId" : return _DepartmentId;
                    case "StaffId" : return _StaffId;
                    case "CategoryID" : return _CategoryID;
                    case "WorkDate" : return _WorkDate;
                    case "Content" : return _Content;
                    case "ManHour" : return _ManHour;
                    case "ProjectId" : return _ProjectId;
                    case "Score" : return _Score;
                    case "AuditStaffId" : return _AuditStaffId;
                    case "AuditStaffFullName" : return _AuditStaffFullName;
                    case "Description" : return _Description;
                    case "StateCode" : return _StateCode;
                    case "Enabled" : return _Enabled;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "SortCode" : return _SortCode;
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
                    case "CompanyId" : _CompanyId = Convert.ToString(value); break;
                    case "DepartmentId" : _DepartmentId = Convert.ToString(value); break;
                    case "StaffId" : _StaffId = Convert.ToString(value); break;
                    case "CategoryID" : _CategoryID = Convert.ToString(value); break;
                    case "WorkDate" : _WorkDate = Convert.ToString(value); break;
                    case "Content" : _Content = Convert.ToString(value); break;
                    case "ManHour" : _ManHour = Convert.ToDecimal(value); break;
                    case "ProjectId" : _ProjectId = Convert.ToString(value); break;
                    case "Score" : _Score = Convert.ToInt32(value); break;
                    case "AuditStaffId" : _AuditStaffId = Convert.ToString(value); break;
                    case "AuditStaffFullName" : _AuditStaffFullName = Convert.ToString(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "StateCode" : _StateCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToString(value); break;
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
            public static readonly Field CompanyId = FindByName("CompanyId");

            ///<summary></summary>
            public static readonly Field DepartmentId = FindByName("DepartmentId");

            ///<summary></summary>
            public static readonly Field StaffId = FindByName("StaffId");

            ///<summary></summary>
            public static readonly Field CategoryID = FindByName("CategoryID");

            ///<summary></summary>
            public static readonly Field WorkDate = FindByName("WorkDate");

            ///<summary></summary>
            public static readonly Field Content = FindByName("Content");

            ///<summary></summary>
            public static readonly Field ManHour = FindByName("ManHour");

            ///<summary></summary>
            public static readonly Field ProjectId = FindByName("ProjectId");

            ///<summary></summary>
            public static readonly Field Score = FindByName("Score");

            ///<summary></summary>
            public static readonly Field AuditStaffId = FindByName("AuditStaffId");

            ///<summary></summary>
            public static readonly Field AuditStaffFullName = FindByName("AuditStaffFullName");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field StateCode = FindByName("StateCode");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

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
    public partial interface IBaseWorkReport
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String CompanyId { get; set; }

        /// <summary></summary>
        String DepartmentId { get; set; }

        /// <summary></summary>
        String StaffId { get; set; }

        /// <summary></summary>
        String CategoryID { get; set; }

        /// <summary></summary>
        String WorkDate { get; set; }

        /// <summary></summary>
        String Content { get; set; }

        /// <summary></summary>
        Decimal ManHour { get; set; }

        /// <summary></summary>
        String ProjectId { get; set; }

        /// <summary></summary>
        Int32 Score { get; set; }

        /// <summary></summary>
        String AuditStaffId { get; set; }

        /// <summary></summary>
        String AuditStaffFullName { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        Int32 StateCode { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        String SortCode { get; set; }

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