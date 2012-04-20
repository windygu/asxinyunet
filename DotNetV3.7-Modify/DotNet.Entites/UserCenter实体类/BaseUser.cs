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
    [BindIndex("PK_Base_User", true, "Id")]
    [BindTable("BaseUser", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseUser : IBaseUser
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

        private String _UserName;
        /// <summary></summary>
        [DisplayName("UserName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "UserName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserName
        {
            get { return _UserName; }
            set { if (OnPropertyChanging("UserName", value)) { _UserName = value; OnPropertyChanged("UserName"); } }
        }

        private String _Realname;
        /// <summary></summary>
        [DisplayName("Realname")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Realname", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Realname
        {
            get { return _Realname; }
            set { if (OnPropertyChanging("Realname", value)) { _Realname = value; OnPropertyChanged("Realname"); } }
        }

        private String _QuickQuery;
        /// <summary></summary>
        [DisplayName("QuickQuery")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(5, "QuickQuery", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String QuickQuery
        {
            get { return _QuickQuery; }
            set { if (OnPropertyChanging("QuickQuery", value)) { _QuickQuery = value; OnPropertyChanged("QuickQuery"); } }
        }

        private Int32 _RoleId;
        /// <summary></summary>
        [DisplayName("RoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "RoleId", "", null, "int", 10, 0, false)]
        public virtual Int32 RoleId
        {
            get { return _RoleId; }
            set { if (OnPropertyChanging("RoleId", value)) { _RoleId = value; OnPropertyChanged("RoleId"); } }
        }

        private Int32 _SecurityLevel;
        /// <summary></summary>
        [DisplayName("SecurityLevel")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "SecurityLevel", "", null, "int", 10, 0, false)]
        public virtual Int32 SecurityLevel
        {
            get { return _SecurityLevel; }
            set { if (OnPropertyChanging("SecurityLevel", value)) { _SecurityLevel = value; OnPropertyChanged("SecurityLevel"); } }
        }

        private String _UserFrom;
        /// <summary></summary>
        [DisplayName("UserFrom")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "UserFrom", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserFrom
        {
            get { return _UserFrom; }
            set { if (OnPropertyChanging("UserFrom", value)) { _UserFrom = value; OnPropertyChanged("UserFrom"); } }
        }

        private String _CompanyId;
        /// <summary></summary>
        [DisplayName("CompanyId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "CompanyId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CompanyId
        {
            get { return _CompanyId; }
            set { if (OnPropertyChanging("CompanyId", value)) { _CompanyId = value; OnPropertyChanged("CompanyId"); } }
        }

        private String _CompanyName;
        /// <summary></summary>
        [DisplayName("CompanyName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "CompanyName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CompanyName
        {
            get { return _CompanyName; }
            set { if (OnPropertyChanging("CompanyName", value)) { _CompanyName = value; OnPropertyChanged("CompanyName"); } }
        }

        private String _DepartmentId;
        /// <summary></summary>
        [DisplayName("DepartmentId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "DepartmentId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DepartmentId
        {
            get { return _DepartmentId; }
            set { if (OnPropertyChanging("DepartmentId", value)) { _DepartmentId = value; OnPropertyChanged("DepartmentId"); } }
        }

        private String _DepartmentName;
        /// <summary></summary>
        [DisplayName("DepartmentName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "DepartmentName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DepartmentName
        {
            get { return _DepartmentName; }
            set { if (OnPropertyChanging("DepartmentName", value)) { _DepartmentName = value; OnPropertyChanged("DepartmentName"); } }
        }

        private String _WorkgroupId;
        /// <summary></summary>
        [DisplayName("WorkgroupId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "WorkgroupId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String WorkgroupId
        {
            get { return _WorkgroupId; }
            set { if (OnPropertyChanging("WorkgroupId", value)) { _WorkgroupId = value; OnPropertyChanged("WorkgroupId"); } }
        }

        private String _WorkgroupName;
        /// <summary></summary>
        [DisplayName("WorkgroupName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "WorkgroupName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String WorkgroupName
        {
            get { return _WorkgroupName; }
            set { if (OnPropertyChanging("WorkgroupName", value)) { _WorkgroupName = value; OnPropertyChanged("WorkgroupName"); } }
        }

        private String _WorkCategory;
        /// <summary></summary>
        [DisplayName("WorkCategory")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "WorkCategory", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String WorkCategory
        {
            get { return _WorkCategory; }
            set { if (OnPropertyChanging("WorkCategory", value)) { _WorkCategory = value; OnPropertyChanged("WorkCategory"); } }
        }

        private String _UserPassword;
        /// <summary></summary>
        [DisplayName("UserPassword")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(16, "UserPassword", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String UserPassword
        {
            get { return _UserPassword; }
            set { if (OnPropertyChanging("UserPassword", value)) { _UserPassword = value; OnPropertyChanged("UserPassword"); } }
        }

        private DateTime _ChangePasswordDate;
        /// <summary></summary>
        [DisplayName("ChangePasswordDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(17, "ChangePasswordDate", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime ChangePasswordDate
        {
            get { return _ChangePasswordDate; }
            set { if (OnPropertyChanging("ChangePasswordDate", value)) { _ChangePasswordDate = value; OnPropertyChanged("ChangePasswordDate"); } }
        }

        private String _CommunicationPassword;
        /// <summary></summary>
        [DisplayName("CommunicationPassword")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(18, "CommunicationPassword", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String CommunicationPassword
        {
            get { return _CommunicationPassword; }
            set { if (OnPropertyChanging("CommunicationPassword", value)) { _CommunicationPassword = value; OnPropertyChanged("CommunicationPassword"); } }
        }

        private String _SignedPassword;
        /// <summary></summary>
        [DisplayName("SignedPassword")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(19, "SignedPassword", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String SignedPassword
        {
            get { return _SignedPassword; }
            set { if (OnPropertyChanging("SignedPassword", value)) { _SignedPassword = value; OnPropertyChanged("SignedPassword"); } }
        }

        private String _PublicKey;
        /// <summary></summary>
        [DisplayName("PublicKey")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(20, "PublicKey", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String PublicKey
        {
            get { return _PublicKey; }
            set { if (OnPropertyChanging("PublicKey", value)) { _PublicKey = value; OnPropertyChanged("PublicKey"); } }
        }

        private String _Duty;
        /// <summary></summary>
        [DisplayName("Duty")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(21, "Duty", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Duty
        {
            get { return _Duty; }
            set { if (OnPropertyChanging("Duty", value)) { _Duty = value; OnPropertyChanged("Duty"); } }
        }

        private String _Title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(22, "Title", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging("Title", value)) { _Title = value; OnPropertyChanged("Title"); } }
        }

        private String _Email;
        /// <summary></summary>
        [DisplayName("Email")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(23, "Email", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String Email
        {
            get { return _Email; }
            set { if (OnPropertyChanging("Email", value)) { _Email = value; OnPropertyChanged("Email"); } }
        }

        private String _Lang;
        /// <summary></summary>
        [DisplayName("Lang")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(24, "Lang", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Lang
        {
            get { return _Lang; }
            set { if (OnPropertyChanging("Lang", value)) { _Lang = value; OnPropertyChanged("Lang"); } }
        }

        private String _Gender;
        /// <summary></summary>
        [DisplayName("Gender")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(25, "Gender", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Gender
        {
            get { return _Gender; }
            set { if (OnPropertyChanging("Gender", value)) { _Gender = value; OnPropertyChanged("Gender"); } }
        }

        private String _Birthday;
        /// <summary></summary>
        [DisplayName("Birthday")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(26, "Birthday", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Birthday
        {
            get { return _Birthday; }
            set { if (OnPropertyChanging("Birthday", value)) { _Birthday = value; OnPropertyChanged("Birthday"); } }
        }

        private String _Mobile;
        /// <summary></summary>
        [DisplayName("Mobile")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(27, "Mobile", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Mobile
        {
            get { return _Mobile; }
            set { if (OnPropertyChanging("Mobile", value)) { _Mobile = value; OnPropertyChanged("Mobile"); } }
        }

        private String _Telephone;
        /// <summary></summary>
        [DisplayName("Telephone")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(28, "Telephone", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Telephone
        {
            get { return _Telephone; }
            set { if (OnPropertyChanging("Telephone", value)) { _Telephone = value; OnPropertyChanged("Telephone"); } }
        }

        private String _OICQ;
        /// <summary></summary>
        [DisplayName("OICQ")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(29, "OICQ", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String OICQ
        {
            get { return _OICQ; }
            set { if (OnPropertyChanging("OICQ", value)) { _OICQ = value; OnPropertyChanged("OICQ"); } }
        }

        private String _HomeAddress;
        /// <summary></summary>
        [DisplayName("HomeAddress")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(30, "HomeAddress", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String HomeAddress
        {
            get { return _HomeAddress; }
            set { if (OnPropertyChanging("HomeAddress", value)) { _HomeAddress = value; OnPropertyChanged("HomeAddress"); } }
        }

        private String _Theme;
        /// <summary></summary>
        [DisplayName("Theme")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(31, "Theme", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Theme
        {
            get { return _Theme; }
            set { if (OnPropertyChanging("Theme", value)) { _Theme = value; OnPropertyChanged("Theme"); } }
        }

        private DateTime _AllowStartTime;
        /// <summary></summary>
        [DisplayName("AllowStartTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(32, "AllowStartTime", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime AllowStartTime
        {
            get { return _AllowStartTime; }
            set { if (OnPropertyChanging("AllowStartTime", value)) { _AllowStartTime = value; OnPropertyChanged("AllowStartTime"); } }
        }

        private DateTime _AllowEndTime;
        /// <summary></summary>
        [DisplayName("AllowEndTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(33, "AllowEndTime", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime AllowEndTime
        {
            get { return _AllowEndTime; }
            set { if (OnPropertyChanging("AllowEndTime", value)) { _AllowEndTime = value; OnPropertyChanged("AllowEndTime"); } }
        }

        private DateTime _LockStartDate;
        /// <summary></summary>
        [DisplayName("LockStartDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(34, "LockStartDate", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime LockStartDate
        {
            get { return _LockStartDate; }
            set { if (OnPropertyChanging("LockStartDate", value)) { _LockStartDate = value; OnPropertyChanged("LockStartDate"); } }
        }

        private DateTime _LockEndDate;
        /// <summary></summary>
        [DisplayName("LockEndDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(35, "LockEndDate", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime LockEndDate
        {
            get { return _LockEndDate; }
            set { if (OnPropertyChanging("LockEndDate", value)) { _LockEndDate = value; OnPropertyChanged("LockEndDate"); } }
        }

        private DateTime _FirstVisit;
        /// <summary></summary>
        [DisplayName("FirstVisit")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(36, "FirstVisit", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime FirstVisit
        {
            get { return _FirstVisit; }
            set { if (OnPropertyChanging("FirstVisit", value)) { _FirstVisit = value; OnPropertyChanged("FirstVisit"); } }
        }

        private DateTime _PreviousVisit;
        /// <summary></summary>
        [DisplayName("PreviousVisit")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(37, "PreviousVisit", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime PreviousVisit
        {
            get { return _PreviousVisit; }
            set { if (OnPropertyChanging("PreviousVisit", value)) { _PreviousVisit = value; OnPropertyChanged("PreviousVisit"); } }
        }

        private DateTime _LastVisit;
        /// <summary></summary>
        [DisplayName("LastVisit")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(38, "LastVisit", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime LastVisit
        {
            get { return _LastVisit; }
            set { if (OnPropertyChanging("LastVisit", value)) { _LastVisit = value; OnPropertyChanged("LastVisit"); } }
        }

        private Int32 _LogOnCount;
        /// <summary></summary>
        [DisplayName("LogOnCount")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(39, "LogOnCount", "", "0", "int", 10, 0, false)]
        public virtual Int32 LogOnCount
        {
            get { return _LogOnCount; }
            set { if (OnPropertyChanging("LogOnCount", value)) { _LogOnCount = value; OnPropertyChanged("LogOnCount"); } }
        }

        private Int32 _IsStaff;
        /// <summary></summary>
        [DisplayName("IsStaff")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(40, "IsStaff", "", "1", "int", 10, 0, false)]
        public virtual Int32 IsStaff
        {
            get { return _IsStaff; }
            set { if (OnPropertyChanging("IsStaff", value)) { _IsStaff = value; OnPropertyChanged("IsStaff"); } }
        }

        private Int32 _UserOnLine;
        /// <summary></summary>
        [DisplayName("UserOnLine")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(41, "UserOnLine", "", "1", "int", 10, 0, false)]
        public virtual Int32 UserOnLine
        {
            get { return _UserOnLine; }
            set { if (OnPropertyChanging("UserOnLine", value)) { _UserOnLine = value; OnPropertyChanged("UserOnLine"); } }
        }

        private Int32 _IsVisible;
        /// <summary></summary>
        [DisplayName("IsVisible")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(42, "IsVisible", "", "1", "int", 10, 0, false)]
        public virtual Int32 IsVisible
        {
            get { return _IsVisible; }
            set { if (OnPropertyChanging("IsVisible", value)) { _IsVisible = value; OnPropertyChanged("IsVisible"); } }
        }

        private String _OpenId;
        /// <summary></summary>
        [DisplayName("OpenId")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(43, "OpenId", "", "newid()", "nvarchar(50)", 0, 0, true)]
        public virtual String OpenId
        {
            get { return _OpenId; }
            set { if (OnPropertyChanging("OpenId", value)) { _OpenId = value; OnPropertyChanged("OpenId"); } }
        }

        private String _IPAddress;
        /// <summary></summary>
        [DisplayName("IPAddress")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(44, "IPAddress", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String IPAddress
        {
            get { return _IPAddress; }
            set { if (OnPropertyChanging("IPAddress", value)) { _IPAddress = value; OnPropertyChanged("IPAddress"); } }
        }

        private String _MACAddress;
        /// <summary></summary>
        [DisplayName("MACAddress")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(45, "MACAddress", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String MACAddress
        {
            get { return _MACAddress; }
            set { if (OnPropertyChanging("MACAddress", value)) { _MACAddress = value; OnPropertyChanged("MACAddress"); } }
        }

        private String _Question;
        /// <summary></summary>
        [DisplayName("Question")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(46, "Question", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Question
        {
            get { return _Question; }
            set { if (OnPropertyChanging("Question", value)) { _Question = value; OnPropertyChanged("Question"); } }
        }

        private String _AnswerQuestion;
        /// <summary></summary>
        [DisplayName("AnswerQuestion")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(47, "AnswerQuestion", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String AnswerQuestion
        {
            get { return _AnswerQuestion; }
            set { if (OnPropertyChanging("AnswerQuestion", value)) { _AnswerQuestion = value; OnPropertyChanged("AnswerQuestion"); } }
        }

        private Int32 _UserAddressId;
        /// <summary></summary>
        [DisplayName("UserAddressId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(48, "UserAddressId", "", null, "int", 10, 0, false)]
        public virtual Int32 UserAddressId
        {
            get { return _UserAddressId; }
            set { if (OnPropertyChanging("UserAddressId", value)) { _UserAddressId = value; OnPropertyChanged("UserAddressId"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(49, "Enabled", "", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private String _AuditStatus;
        /// <summary></summary>
        [DisplayName("AuditStatus")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(50, "AuditStatus", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditStatus
        {
            get { return _AuditStatus; }
            set { if (OnPropertyChanging("AuditStatus", value)) { _AuditStatus = value; OnPropertyChanged("AuditStatus"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(51, "DeletionStateCode", "", "0", "int", 10, 0, false)]
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
        [BindColumn(52, "SortCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(53, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(54, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(55, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(56, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(57, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(58, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(59, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "UserName" : return _UserName;
                    case "Realname" : return _Realname;
                    case "QuickQuery" : return _QuickQuery;
                    case "RoleId" : return _RoleId;
                    case "SecurityLevel" : return _SecurityLevel;
                    case "UserFrom" : return _UserFrom;
                    case "CompanyId" : return _CompanyId;
                    case "CompanyName" : return _CompanyName;
                    case "DepartmentId" : return _DepartmentId;
                    case "DepartmentName" : return _DepartmentName;
                    case "WorkgroupId" : return _WorkgroupId;
                    case "WorkgroupName" : return _WorkgroupName;
                    case "WorkCategory" : return _WorkCategory;
                    case "UserPassword" : return _UserPassword;
                    case "ChangePasswordDate" : return _ChangePasswordDate;
                    case "CommunicationPassword" : return _CommunicationPassword;
                    case "SignedPassword" : return _SignedPassword;
                    case "PublicKey" : return _PublicKey;
                    case "Duty" : return _Duty;
                    case "Title" : return _Title;
                    case "Email" : return _Email;
                    case "Lang" : return _Lang;
                    case "Gender" : return _Gender;
                    case "Birthday" : return _Birthday;
                    case "Mobile" : return _Mobile;
                    case "Telephone" : return _Telephone;
                    case "OICQ" : return _OICQ;
                    case "HomeAddress" : return _HomeAddress;
                    case "Theme" : return _Theme;
                    case "AllowStartTime" : return _AllowStartTime;
                    case "AllowEndTime" : return _AllowEndTime;
                    case "LockStartDate" : return _LockStartDate;
                    case "LockEndDate" : return _LockEndDate;
                    case "FirstVisit" : return _FirstVisit;
                    case "PreviousVisit" : return _PreviousVisit;
                    case "LastVisit" : return _LastVisit;
                    case "LogOnCount" : return _LogOnCount;
                    case "IsStaff" : return _IsStaff;
                    case "UserOnLine" : return _UserOnLine;
                    case "IsVisible" : return _IsVisible;
                    case "OpenId" : return _OpenId;
                    case "IPAddress" : return _IPAddress;
                    case "MACAddress" : return _MACAddress;
                    case "Question" : return _Question;
                    case "AnswerQuestion" : return _AnswerQuestion;
                    case "UserAddressId" : return _UserAddressId;
                    case "Enabled" : return _Enabled;
                    case "AuditStatus" : return _AuditStatus;
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
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "UserName" : _UserName = Convert.ToString(value); break;
                    case "Realname" : _Realname = Convert.ToString(value); break;
                    case "QuickQuery" : _QuickQuery = Convert.ToString(value); break;
                    case "RoleId" : _RoleId = Convert.ToInt32(value); break;
                    case "SecurityLevel" : _SecurityLevel = Convert.ToInt32(value); break;
                    case "UserFrom" : _UserFrom = Convert.ToString(value); break;
                    case "CompanyId" : _CompanyId = Convert.ToString(value); break;
                    case "CompanyName" : _CompanyName = Convert.ToString(value); break;
                    case "DepartmentId" : _DepartmentId = Convert.ToString(value); break;
                    case "DepartmentName" : _DepartmentName = Convert.ToString(value); break;
                    case "WorkgroupId" : _WorkgroupId = Convert.ToString(value); break;
                    case "WorkgroupName" : _WorkgroupName = Convert.ToString(value); break;
                    case "WorkCategory" : _WorkCategory = Convert.ToString(value); break;
                    case "UserPassword" : _UserPassword = Convert.ToString(value); break;
                    case "ChangePasswordDate" : _ChangePasswordDate = Convert.ToDateTime(value); break;
                    case "CommunicationPassword" : _CommunicationPassword = Convert.ToString(value); break;
                    case "SignedPassword" : _SignedPassword = Convert.ToString(value); break;
                    case "PublicKey" : _PublicKey = Convert.ToString(value); break;
                    case "Duty" : _Duty = Convert.ToString(value); break;
                    case "Title" : _Title = Convert.ToString(value); break;
                    case "Email" : _Email = Convert.ToString(value); break;
                    case "Lang" : _Lang = Convert.ToString(value); break;
                    case "Gender" : _Gender = Convert.ToString(value); break;
                    case "Birthday" : _Birthday = Convert.ToString(value); break;
                    case "Mobile" : _Mobile = Convert.ToString(value); break;
                    case "Telephone" : _Telephone = Convert.ToString(value); break;
                    case "OICQ" : _OICQ = Convert.ToString(value); break;
                    case "HomeAddress" : _HomeAddress = Convert.ToString(value); break;
                    case "Theme" : _Theme = Convert.ToString(value); break;
                    case "AllowStartTime" : _AllowStartTime = Convert.ToDateTime(value); break;
                    case "AllowEndTime" : _AllowEndTime = Convert.ToDateTime(value); break;
                    case "LockStartDate" : _LockStartDate = Convert.ToDateTime(value); break;
                    case "LockEndDate" : _LockEndDate = Convert.ToDateTime(value); break;
                    case "FirstVisit" : _FirstVisit = Convert.ToDateTime(value); break;
                    case "PreviousVisit" : _PreviousVisit = Convert.ToDateTime(value); break;
                    case "LastVisit" : _LastVisit = Convert.ToDateTime(value); break;
                    case "LogOnCount" : _LogOnCount = Convert.ToInt32(value); break;
                    case "IsStaff" : _IsStaff = Convert.ToInt32(value); break;
                    case "UserOnLine" : _UserOnLine = Convert.ToInt32(value); break;
                    case "IsVisible" : _IsVisible = Convert.ToInt32(value); break;
                    case "OpenId" : _OpenId = Convert.ToString(value); break;
                    case "IPAddress" : _IPAddress = Convert.ToString(value); break;
                    case "MACAddress" : _MACAddress = Convert.ToString(value); break;
                    case "Question" : _Question = Convert.ToString(value); break;
                    case "AnswerQuestion" : _AnswerQuestion = Convert.ToString(value); break;
                    case "UserAddressId" : _UserAddressId = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "AuditStatus" : _AuditStatus = Convert.ToString(value); break;
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
            public static readonly Field Id = FindByName("Id");

            ///<summary></summary>
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field UserName = FindByName("UserName");

            ///<summary></summary>
            public static readonly Field Realname = FindByName("Realname");

            ///<summary></summary>
            public static readonly Field QuickQuery = FindByName("QuickQuery");

            ///<summary></summary>
            public static readonly Field RoleId = FindByName("RoleId");

            ///<summary></summary>
            public static readonly Field SecurityLevel = FindByName("SecurityLevel");

            ///<summary></summary>
            public static readonly Field UserFrom = FindByName("UserFrom");

            ///<summary></summary>
            public static readonly Field CompanyId = FindByName("CompanyId");

            ///<summary></summary>
            public static readonly Field CompanyName = FindByName("CompanyName");

            ///<summary></summary>
            public static readonly Field DepartmentId = FindByName("DepartmentId");

            ///<summary></summary>
            public static readonly Field DepartmentName = FindByName("DepartmentName");

            ///<summary></summary>
            public static readonly Field WorkgroupId = FindByName("WorkgroupId");

            ///<summary></summary>
            public static readonly Field WorkgroupName = FindByName("WorkgroupName");

            ///<summary></summary>
            public static readonly Field WorkCategory = FindByName("WorkCategory");

            ///<summary></summary>
            public static readonly Field UserPassword = FindByName("UserPassword");

            ///<summary></summary>
            public static readonly Field ChangePasswordDate = FindByName("ChangePasswordDate");

            ///<summary></summary>
            public static readonly Field CommunicationPassword = FindByName("CommunicationPassword");

            ///<summary></summary>
            public static readonly Field SignedPassword = FindByName("SignedPassword");

            ///<summary></summary>
            public static readonly Field PublicKey = FindByName("PublicKey");

            ///<summary></summary>
            public static readonly Field Duty = FindByName("Duty");

            ///<summary></summary>
            public static readonly Field Title = FindByName("Title");

            ///<summary></summary>
            public static readonly Field Email = FindByName("Email");

            ///<summary></summary>
            public static readonly Field Lang = FindByName("Lang");

            ///<summary></summary>
            public static readonly Field Gender = FindByName("Gender");

            ///<summary></summary>
            public static readonly Field Birthday = FindByName("Birthday");

            ///<summary></summary>
            public static readonly Field Mobile = FindByName("Mobile");

            ///<summary></summary>
            public static readonly Field Telephone = FindByName("Telephone");

            ///<summary></summary>
            public static readonly Field OICQ = FindByName("OICQ");

            ///<summary></summary>
            public static readonly Field HomeAddress = FindByName("HomeAddress");

            ///<summary></summary>
            public static readonly Field Theme = FindByName("Theme");

            ///<summary></summary>
            public static readonly Field AllowStartTime = FindByName("AllowStartTime");

            ///<summary></summary>
            public static readonly Field AllowEndTime = FindByName("AllowEndTime");

            ///<summary></summary>
            public static readonly Field LockStartDate = FindByName("LockStartDate");

            ///<summary></summary>
            public static readonly Field LockEndDate = FindByName("LockEndDate");

            ///<summary></summary>
            public static readonly Field FirstVisit = FindByName("FirstVisit");

            ///<summary></summary>
            public static readonly Field PreviousVisit = FindByName("PreviousVisit");

            ///<summary></summary>
            public static readonly Field LastVisit = FindByName("LastVisit");

            ///<summary></summary>
            public static readonly Field LogOnCount = FindByName("LogOnCount");

            ///<summary></summary>
            public static readonly Field IsStaff = FindByName("IsStaff");

            ///<summary></summary>
            public static readonly Field UserOnLine = FindByName("UserOnLine");

            ///<summary></summary>
            public static readonly Field IsVisible = FindByName("IsVisible");

            ///<summary></summary>
            public static readonly Field OpenId = FindByName("OpenId");

            ///<summary></summary>
            public static readonly Field IPAddress = FindByName("IPAddress");

            ///<summary></summary>
            public static readonly Field MACAddress = FindByName("MACAddress");

            ///<summary></summary>
            public static readonly Field Question = FindByName("Question");

            ///<summary></summary>
            public static readonly Field AnswerQuestion = FindByName("AnswerQuestion");

            ///<summary></summary>
            public static readonly Field UserAddressId = FindByName("UserAddressId");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field AuditStatus = FindByName("AuditStatus");

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
    public partial interface IBaseUser
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        String UserName { get; set; }

        /// <summary></summary>
        String Realname { get; set; }

        /// <summary></summary>
        String QuickQuery { get; set; }

        /// <summary></summary>
        Int32 RoleId { get; set; }

        /// <summary></summary>
        Int32 SecurityLevel { get; set; }

        /// <summary></summary>
        String UserFrom { get; set; }

        /// <summary></summary>
        String CompanyId { get; set; }

        /// <summary></summary>
        String CompanyName { get; set; }

        /// <summary></summary>
        String DepartmentId { get; set; }

        /// <summary></summary>
        String DepartmentName { get; set; }

        /// <summary></summary>
        String WorkgroupId { get; set; }

        /// <summary></summary>
        String WorkgroupName { get; set; }

        /// <summary></summary>
        String WorkCategory { get; set; }

        /// <summary></summary>
        String UserPassword { get; set; }

        /// <summary></summary>
        DateTime ChangePasswordDate { get; set; }

        /// <summary></summary>
        String CommunicationPassword { get; set; }

        /// <summary></summary>
        String SignedPassword { get; set; }

        /// <summary></summary>
        String PublicKey { get; set; }

        /// <summary></summary>
        String Duty { get; set; }

        /// <summary></summary>
        String Title { get; set; }

        /// <summary></summary>
        String Email { get; set; }

        /// <summary></summary>
        String Lang { get; set; }

        /// <summary></summary>
        String Gender { get; set; }

        /// <summary></summary>
        String Birthday { get; set; }

        /// <summary></summary>
        String Mobile { get; set; }

        /// <summary></summary>
        String Telephone { get; set; }

        /// <summary></summary>
        String OICQ { get; set; }

        /// <summary></summary>
        String HomeAddress { get; set; }

        /// <summary></summary>
        String Theme { get; set; }

        /// <summary></summary>
        DateTime AllowStartTime { get; set; }

        /// <summary></summary>
        DateTime AllowEndTime { get; set; }

        /// <summary></summary>
        DateTime LockStartDate { get; set; }

        /// <summary></summary>
        DateTime LockEndDate { get; set; }

        /// <summary></summary>
        DateTime FirstVisit { get; set; }

        /// <summary></summary>
        DateTime PreviousVisit { get; set; }

        /// <summary></summary>
        DateTime LastVisit { get; set; }

        /// <summary></summary>
        Int32 LogOnCount { get; set; }

        /// <summary></summary>
        Int32 IsStaff { get; set; }

        /// <summary></summary>
        Int32 UserOnLine { get; set; }

        /// <summary></summary>
        Int32 IsVisible { get; set; }

        /// <summary></summary>
        String OpenId { get; set; }

        /// <summary></summary>
        String IPAddress { get; set; }

        /// <summary></summary>
        String MACAddress { get; set; }

        /// <summary></summary>
        String Question { get; set; }

        /// <summary></summary>
        String AnswerQuestion { get; set; }

        /// <summary></summary>
        Int32 UserAddressId { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

        /// <summary></summary>
        String AuditStatus { get; set; }

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