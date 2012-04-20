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
    [BindIndex("PK_MAINTAIN", true, "Id")]
    [BindTable("Maintain", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class Maintain : IMaintain
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

        private String _Code;
        /// <summary></summary>
        [DisplayName("Code")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Code", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } }
        }

        private String _DepartmentId;
        /// <summary></summary>
        [DisplayName("DepartmentId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "DepartmentId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DepartmentId
        {
            get { return _DepartmentId; }
            set { if (OnPropertyChanging("DepartmentId", value)) { _DepartmentId = value; OnPropertyChanged("DepartmentId"); } }
        }

        private String _UserCode;
        /// <summary></summary>
        [DisplayName("UserCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "UserCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserCode
        {
            get { return _UserCode; }
            set { if (OnPropertyChanging("UserCode", value)) { _UserCode = value; OnPropertyChanged("UserCode"); } }
        }

        private String _DepartmentName;
        /// <summary></summary>
        [DisplayName("DepartmentName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "DepartmentName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DepartmentName
        {
            get { return _DepartmentName; }
            set { if (OnPropertyChanging("DepartmentName", value)) { _DepartmentName = value; OnPropertyChanged("DepartmentName"); } }
        }

        private String _OfficeLocation;
        /// <summary></summary>
        [DisplayName("OfficeLocation")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "OfficeLocation", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String OfficeLocation
        {
            get { return _OfficeLocation; }
            set { if (OnPropertyChanging("OfficeLocation", value)) { _OfficeLocation = value; OnPropertyChanged("OfficeLocation"); } }
        }

        private String _Telephone;
        /// <summary></summary>
        [DisplayName("Telephone")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "Telephone", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Telephone
        {
            get { return _Telephone; }
            set { if (OnPropertyChanging("Telephone", value)) { _Telephone = value; OnPropertyChanged("Telephone"); } }
        }

        private DateTime _ReportingTime;
        /// <summary></summary>
        [DisplayName("ReportingTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(8, "ReportingTime", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime ReportingTime
        {
            get { return _ReportingTime; }
            set { if (OnPropertyChanging("ReportingTime", value)) { _ReportingTime = value; OnPropertyChanged("ReportingTime"); } }
        }

        private DateTime _CompletionTime;
        /// <summary></summary>
        [DisplayName("CompletionTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(9, "CompletionTime", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime CompletionTime
        {
            get { return _CompletionTime; }
            set { if (OnPropertyChanging("CompletionTime", value)) { _CompletionTime = value; OnPropertyChanged("CompletionTime"); } }
        }

        private String _MaintenancePersonnel;
        /// <summary></summary>
        [DisplayName("MaintenancePersonnel")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "MaintenancePersonnel", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String MaintenancePersonnel
        {
            get { return _MaintenancePersonnel; }
            set { if (OnPropertyChanging("MaintenancePersonnel", value)) { _MaintenancePersonnel = value; OnPropertyChanged("MaintenancePersonnel"); } }
        }

        private String _MalfunctionCause;
        /// <summary></summary>
        [DisplayName("MalfunctionCause")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "MalfunctionCause", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String MalfunctionCause
        {
            get { return _MalfunctionCause; }
            set { if (OnPropertyChanging("MalfunctionCause", value)) { _MalfunctionCause = value; OnPropertyChanged("MalfunctionCause"); } }
        }

        private String _BugLevel;
        /// <summary></summary>
        [DisplayName("BugLevel")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "BugLevel", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String BugLevel
        {
            get { return _BugLevel; }
            set { if (OnPropertyChanging("BugLevel", value)) { _BugLevel = value; OnPropertyChanged("BugLevel"); } }
        }

        private String _BugCategory;
        /// <summary></summary>
        [DisplayName("BugCategory")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "BugCategory", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String BugCategory
        {
            get { return _BugCategory; }
            set { if (OnPropertyChanging("BugCategory", value)) { _BugCategory = value; OnPropertyChanged("BugCategory"); } }
        }

        private Int32 _ProcessTime;
        /// <summary></summary>
        [DisplayName("ProcessTime")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(14, "ProcessTime", "", null, "int", 10, 0, false)]
        public virtual Int32 ProcessTime
        {
            get { return _ProcessTime; }
            set { if (OnPropertyChanging("ProcessTime", value)) { _ProcessTime = value; OnPropertyChanged("ProcessTime"); } }
        }

        private String _IP;
        /// <summary></summary>
        [DisplayName("IP")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "IP", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String IP
        {
            get { return _IP; }
            set { if (OnPropertyChanging("IP", value)) { _IP = value; OnPropertyChanged("IP"); } }
        }

        private String _ComputerUserName;
        /// <summary></summary>
        [DisplayName("ComputerUserName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(16, "ComputerUserName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ComputerUserName
        {
            get { return _ComputerUserName; }
            set { if (OnPropertyChanging("ComputerUserName", value)) { _ComputerUserName = value; OnPropertyChanged("ComputerUserName"); } }
        }

        private String _ComputerPassword;
        /// <summary></summary>
        [DisplayName("ComputerPassword")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(17, "ComputerPassword", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ComputerPassword
        {
            get { return _ComputerPassword; }
            set { if (OnPropertyChanging("ComputerPassword", value)) { _ComputerPassword = value; OnPropertyChanged("ComputerPassword"); } }
        }

        private String _ProcessorId;
        /// <summary></summary>
        [DisplayName("ProcessorId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(18, "ProcessorId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ProcessorId
        {
            get { return _ProcessorId; }
            set { if (OnPropertyChanging("ProcessorId", value)) { _ProcessorId = value; OnPropertyChanged("ProcessorId"); } }
        }

        private String _ProcessorName;
        /// <summary></summary>
        [DisplayName("ProcessorName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(19, "ProcessorName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ProcessorName
        {
            get { return _ProcessorName; }
            set { if (OnPropertyChanging("ProcessorName", value)) { _ProcessorName = value; OnPropertyChanged("ProcessorName"); } }
        }

        private String _ServiceState;
        /// <summary></summary>
        [DisplayName("ServiceState")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(20, "ServiceState", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ServiceState
        {
            get { return _ServiceState; }
            set { if (OnPropertyChanging("ServiceState", value)) { _ServiceState = value; OnPropertyChanged("ServiceState"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(21, "SortCode", "", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(22, "DeletionStateCode", "", "0", "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(23, "Enabled", "", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 800)]
        [BindColumn(24, "Description", "", null, "nvarchar(800)", 0, 0, true)]
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
        [BindColumn(25, "CreateOn", "", null, "smalldatetime", 3, 0, false)]
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
        [BindColumn(26, "CreateUserId", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(27, "CreateBy", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(28, "ModifiedOn", "", null, "smalldatetime", 3, 0, false)]
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
        [BindColumn(29, "ModifiedUserId", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(30, "ModifiedBy", "", null, "nvarchar(50)", 0, 0, true)]
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
                    case "Code" : return _Code;
                    case "DepartmentId" : return _DepartmentId;
                    case "UserCode" : return _UserCode;
                    case "DepartmentName" : return _DepartmentName;
                    case "OfficeLocation" : return _OfficeLocation;
                    case "Telephone" : return _Telephone;
                    case "ReportingTime" : return _ReportingTime;
                    case "CompletionTime" : return _CompletionTime;
                    case "MaintenancePersonnel" : return _MaintenancePersonnel;
                    case "MalfunctionCause" : return _MalfunctionCause;
                    case "BugLevel" : return _BugLevel;
                    case "BugCategory" : return _BugCategory;
                    case "ProcessTime" : return _ProcessTime;
                    case "IP" : return _IP;
                    case "ComputerUserName" : return _ComputerUserName;
                    case "ComputerPassword" : return _ComputerPassword;
                    case "ProcessorId" : return _ProcessorId;
                    case "ProcessorName" : return _ProcessorName;
                    case "ServiceState" : return _ServiceState;
                    case "SortCode" : return _SortCode;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "Enabled" : return _Enabled;
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
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "DepartmentId" : _DepartmentId = Convert.ToString(value); break;
                    case "UserCode" : _UserCode = Convert.ToString(value); break;
                    case "DepartmentName" : _DepartmentName = Convert.ToString(value); break;
                    case "OfficeLocation" : _OfficeLocation = Convert.ToString(value); break;
                    case "Telephone" : _Telephone = Convert.ToString(value); break;
                    case "ReportingTime" : _ReportingTime = Convert.ToDateTime(value); break;
                    case "CompletionTime" : _CompletionTime = Convert.ToDateTime(value); break;
                    case "MaintenancePersonnel" : _MaintenancePersonnel = Convert.ToString(value); break;
                    case "MalfunctionCause" : _MalfunctionCause = Convert.ToString(value); break;
                    case "BugLevel" : _BugLevel = Convert.ToString(value); break;
                    case "BugCategory" : _BugCategory = Convert.ToString(value); break;
                    case "ProcessTime" : _ProcessTime = Convert.ToInt32(value); break;
                    case "IP" : _IP = Convert.ToString(value); break;
                    case "ComputerUserName" : _ComputerUserName = Convert.ToString(value); break;
                    case "ComputerPassword" : _ComputerPassword = Convert.ToString(value); break;
                    case "ProcessorId" : _ProcessorId = Convert.ToString(value); break;
                    case "ProcessorName" : _ProcessorName = Convert.ToString(value); break;
                    case "ServiceState" : _ServiceState = Convert.ToString(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
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
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field DepartmentId = FindByName("DepartmentId");

            ///<summary></summary>
            public static readonly Field UserCode = FindByName("UserCode");

            ///<summary></summary>
            public static readonly Field DepartmentName = FindByName("DepartmentName");

            ///<summary></summary>
            public static readonly Field OfficeLocation = FindByName("OfficeLocation");

            ///<summary></summary>
            public static readonly Field Telephone = FindByName("Telephone");

            ///<summary></summary>
            public static readonly Field ReportingTime = FindByName("ReportingTime");

            ///<summary></summary>
            public static readonly Field CompletionTime = FindByName("CompletionTime");

            ///<summary></summary>
            public static readonly Field MaintenancePersonnel = FindByName("MaintenancePersonnel");

            ///<summary></summary>
            public static readonly Field MalfunctionCause = FindByName("MalfunctionCause");

            ///<summary></summary>
            public static readonly Field BugLevel = FindByName("BugLevel");

            ///<summary></summary>
            public static readonly Field BugCategory = FindByName("BugCategory");

            ///<summary></summary>
            public static readonly Field ProcessTime = FindByName("ProcessTime");

            ///<summary></summary>
            public static readonly Field IP = FindByName("IP");

            ///<summary></summary>
            public static readonly Field ComputerUserName = FindByName("ComputerUserName");

            ///<summary></summary>
            public static readonly Field ComputerPassword = FindByName("ComputerPassword");

            ///<summary></summary>
            public static readonly Field ProcessorId = FindByName("ProcessorId");

            ///<summary></summary>
            public static readonly Field ProcessorName = FindByName("ProcessorName");

            ///<summary></summary>
            public static readonly Field ServiceState = FindByName("ServiceState");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

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
    public partial interface IMaintain
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        String DepartmentId { get; set; }

        /// <summary></summary>
        String UserCode { get; set; }

        /// <summary></summary>
        String DepartmentName { get; set; }

        /// <summary></summary>
        String OfficeLocation { get; set; }

        /// <summary></summary>
        String Telephone { get; set; }

        /// <summary></summary>
        DateTime ReportingTime { get; set; }

        /// <summary></summary>
        DateTime CompletionTime { get; set; }

        /// <summary></summary>
        String MaintenancePersonnel { get; set; }

        /// <summary></summary>
        String MalfunctionCause { get; set; }

        /// <summary></summary>
        String BugLevel { get; set; }

        /// <summary></summary>
        String BugCategory { get; set; }

        /// <summary></summary>
        Int32 ProcessTime { get; set; }

        /// <summary></summary>
        String IP { get; set; }

        /// <summary></summary>
        String ComputerUserName { get; set; }

        /// <summary></summary>
        String ComputerPassword { get; set; }

        /// <summary></summary>
        String ProcessorId { get; set; }

        /// <summary></summary>
        String ProcessorName { get; set; }

        /// <summary></summary>
        String ServiceState { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

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