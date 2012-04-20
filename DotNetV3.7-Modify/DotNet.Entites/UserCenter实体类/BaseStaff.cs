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
    [BindIndex("PK_Base_Staff", true, "Id")]
    [BindTable("BaseStaff", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseStaff : IBaseStaff
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

        private Int32 _UserId;
        /// <summary></summary>
        [DisplayName("UserId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "UserId", "", null, "int", 10, 0, false)]
        public virtual Int32 UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } }
        }

        private String _UserName;
        /// <summary></summary>
        [DisplayName("UserName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "UserName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserName
        {
            get { return _UserName; }
            set { if (OnPropertyChanging("UserName", value)) { _UserName = value; OnPropertyChanged("UserName"); } }
        }

        private String _RealName;
        /// <summary></summary>
        [DisplayName("RealName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "RealName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String RealName
        {
            get { return _RealName; }
            set { if (OnPropertyChanging("RealName", value)) { _RealName = value; OnPropertyChanged("RealName"); } }
        }

        private String _QuickQuery;
        /// <summary></summary>
        [DisplayName("QuickQuery")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(6, "QuickQuery", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String QuickQuery
        {
            get { return _QuickQuery; }
            set { if (OnPropertyChanging("QuickQuery", value)) { _QuickQuery = value; OnPropertyChanged("QuickQuery"); } }
        }

        private Int32 _CompanyId;
        /// <summary></summary>
        [DisplayName("CompanyId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "CompanyId", "", null, "int", 10, 0, false)]
        public virtual Int32 CompanyId
        {
            get { return _CompanyId; }
            set { if (OnPropertyChanging("CompanyId", value)) { _CompanyId = value; OnPropertyChanged("CompanyId"); } }
        }

        private Int32 _DepartmentId;
        /// <summary></summary>
        [DisplayName("DepartmentId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "DepartmentId", "", null, "int", 10, 0, false)]
        public virtual Int32 DepartmentId
        {
            get { return _DepartmentId; }
            set { if (OnPropertyChanging("DepartmentId", value)) { _DepartmentId = value; OnPropertyChanged("DepartmentId"); } }
        }

        private Int32 _WorkgroupId;
        /// <summary></summary>
        [DisplayName("WorkgroupId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "WorkgroupId", "", null, "int", 10, 0, false)]
        public virtual Int32 WorkgroupId
        {
            get { return _WorkgroupId; }
            set { if (OnPropertyChanging("WorkgroupId", value)) { _WorkgroupId = value; OnPropertyChanged("WorkgroupId"); } }
        }

        private String _DutyId;
        /// <summary></summary>
        [DisplayName("DutyId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "DutyId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DutyId
        {
            get { return _DutyId; }
            set { if (OnPropertyChanging("DutyId", value)) { _DutyId = value; OnPropertyChanged("DutyId"); } }
        }

        private String _Gender;
        /// <summary></summary>
        [DisplayName("Gender")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "Gender", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(12, "Birthday", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Birthday
        {
            get { return _Birthday; }
            set { if (OnPropertyChanging("Birthday", value)) { _Birthday = value; OnPropertyChanged("Birthday"); } }
        }

        private String _Age;
        /// <summary></summary>
        [DisplayName("Age")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "Age", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Age
        {
            get { return _Age; }
            set { if (OnPropertyChanging("Age", value)) { _Age = value; OnPropertyChanged("Age"); } }
        }

        private String _IdentificationCode;
        /// <summary></summary>
        [DisplayName("IdentificationCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "IdentificationCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String IdentificationCode
        {
            get { return _IdentificationCode; }
            set { if (OnPropertyChanging("IdentificationCode", value)) { _IdentificationCode = value; OnPropertyChanged("IdentificationCode"); } }
        }

        private String _IDCard;
        /// <summary></summary>
        [DisplayName("IDCard")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "IDCard", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String IDCard
        {
            get { return _IDCard; }
            set { if (OnPropertyChanging("IDCard", value)) { _IDCard = value; OnPropertyChanged("IDCard"); } }
        }

        private String _Nation;
        /// <summary></summary>
        [DisplayName("Nation")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(16, "Nation", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Nation
        {
            get { return _Nation; }
            set { if (OnPropertyChanging("Nation", value)) { _Nation = value; OnPropertyChanged("Nation"); } }
        }

        private String _Education;
        /// <summary></summary>
        [DisplayName("Education")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(17, "Education", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Education
        {
            get { return _Education; }
            set { if (OnPropertyChanging("Education", value)) { _Education = value; OnPropertyChanged("Education"); } }
        }

        private String _School;
        /// <summary></summary>
        [DisplayName("School")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(18, "School", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String School
        {
            get { return _School; }
            set { if (OnPropertyChanging("School", value)) { _School = value; OnPropertyChanged("School"); } }
        }

        private String _Degree;
        /// <summary></summary>
        [DisplayName("Degree")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(19, "Degree", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Degree
        {
            get { return _Degree; }
            set { if (OnPropertyChanging("Degree", value)) { _Degree = value; OnPropertyChanged("Degree"); } }
        }

        private String _TitleId;
        /// <summary></summary>
        [DisplayName("TitleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(20, "TitleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String TitleId
        {
            get { return _TitleId; }
            set { if (OnPropertyChanging("TitleId", value)) { _TitleId = value; OnPropertyChanged("TitleId"); } }
        }

        private String _TitleDate;
        /// <summary></summary>
        [DisplayName("TitleDate")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(21, "TitleDate", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String TitleDate
        {
            get { return _TitleDate; }
            set { if (OnPropertyChanging("TitleDate", value)) { _TitleDate = value; OnPropertyChanged("TitleDate"); } }
        }

        private String _TitleLevel;
        /// <summary></summary>
        [DisplayName("TitleLevel")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(22, "TitleLevel", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String TitleLevel
        {
            get { return _TitleLevel; }
            set { if (OnPropertyChanging("TitleLevel", value)) { _TitleLevel = value; OnPropertyChanged("TitleLevel"); } }
        }

        private String _WorkingDate;
        /// <summary></summary>
        [DisplayName("WorkingDate")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(23, "WorkingDate", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String WorkingDate
        {
            get { return _WorkingDate; }
            set { if (OnPropertyChanging("WorkingDate", value)) { _WorkingDate = value; OnPropertyChanged("WorkingDate"); } }
        }

        private String _JoinInDate;
        /// <summary></summary>
        [DisplayName("JoinInDate")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(24, "JoinInDate", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String JoinInDate
        {
            get { return _JoinInDate; }
            set { if (OnPropertyChanging("JoinInDate", value)) { _JoinInDate = value; OnPropertyChanged("JoinInDate"); } }
        }

        private String _OfficeZipCode;
        /// <summary></summary>
        [DisplayName("OfficeZipCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(25, "OfficeZipCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String OfficeZipCode
        {
            get { return _OfficeZipCode; }
            set { if (OnPropertyChanging("OfficeZipCode", value)) { _OfficeZipCode = value; OnPropertyChanged("OfficeZipCode"); } }
        }

        private String _OfficeAddress;
        /// <summary></summary>
        [DisplayName("OfficeAddress")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(26, "OfficeAddress", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String OfficeAddress
        {
            get { return _OfficeAddress; }
            set { if (OnPropertyChanging("OfficeAddress", value)) { _OfficeAddress = value; OnPropertyChanged("OfficeAddress"); } }
        }

        private String _OfficeFax;
        /// <summary></summary>
        [DisplayName("OfficeFax")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(27, "OfficeFax", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String OfficeFax
        {
            get { return _OfficeFax; }
            set { if (OnPropertyChanging("OfficeFax", value)) { _OfficeFax = value; OnPropertyChanged("OfficeFax"); } }
        }

        private String _OfficePhone;
        /// <summary></summary>
        [DisplayName("OfficePhone")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(28, "OfficePhone", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String OfficePhone
        {
            get { return _OfficePhone; }
            set { if (OnPropertyChanging("OfficePhone", value)) { _OfficePhone = value; OnPropertyChanged("OfficePhone"); } }
        }

        private String _HomeZipCode;
        /// <summary></summary>
        [DisplayName("HomeZipCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(29, "HomeZipCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String HomeZipCode
        {
            get { return _HomeZipCode; }
            set { if (OnPropertyChanging("HomeZipCode", value)) { _HomeZipCode = value; OnPropertyChanged("HomeZipCode"); } }
        }

        private String _HomeAddress;
        /// <summary></summary>
        [DisplayName("HomeAddress")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(30, "HomeAddress", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String HomeAddress
        {
            get { return _HomeAddress; }
            set { if (OnPropertyChanging("HomeAddress", value)) { _HomeAddress = value; OnPropertyChanged("HomeAddress"); } }
        }

        private String _HomeFax;
        /// <summary></summary>
        [DisplayName("HomeFax")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(31, "HomeFax", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String HomeFax
        {
            get { return _HomeFax; }
            set { if (OnPropertyChanging("HomeFax", value)) { _HomeFax = value; OnPropertyChanged("HomeFax"); } }
        }

        private String _HomePhone;
        /// <summary></summary>
        [DisplayName("HomePhone")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(32, "HomePhone", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String HomePhone
        {
            get { return _HomePhone; }
            set { if (OnPropertyChanging("HomePhone", value)) { _HomePhone = value; OnPropertyChanged("HomePhone"); } }
        }

        private String _CarCode;
        /// <summary></summary>
        [DisplayName("CarCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(33, "CarCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CarCode
        {
            get { return _CarCode; }
            set { if (OnPropertyChanging("CarCode", value)) { _CarCode = value; OnPropertyChanged("CarCode"); } }
        }

        private String _Email;
        /// <summary></summary>
        [DisplayName("Email")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(34, "Email", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String Email
        {
            get { return _Email; }
            set { if (OnPropertyChanging("Email", value)) { _Email = value; OnPropertyChanged("Email"); } }
        }

        private String _Mobile;
        /// <summary></summary>
        [DisplayName("Mobile")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(35, "Mobile", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Mobile
        {
            get { return _Mobile; }
            set { if (OnPropertyChanging("Mobile", value)) { _Mobile = value; OnPropertyChanged("Mobile"); } }
        }

        private String _ShortNumber;
        /// <summary></summary>
        [DisplayName("ShortNumber")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(36, "ShortNumber", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ShortNumber
        {
            get { return _ShortNumber; }
            set { if (OnPropertyChanging("ShortNumber", value)) { _ShortNumber = value; OnPropertyChanged("ShortNumber"); } }
        }

        private String _Telephone;
        /// <summary></summary>
        [DisplayName("Telephone")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(37, "Telephone", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Telephone
        {
            get { return _Telephone; }
            set { if (OnPropertyChanging("Telephone", value)) { _Telephone = value; OnPropertyChanged("Telephone"); } }
        }

        private String _EmergencyContact;
        /// <summary></summary>
        [DisplayName("EmergencyContact")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(38, "EmergencyContact", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String EmergencyContact
        {
            get { return _EmergencyContact; }
            set { if (OnPropertyChanging("EmergencyContact", value)) { _EmergencyContact = value; OnPropertyChanged("EmergencyContact"); } }
        }

        private String _OICQ;
        /// <summary></summary>
        [DisplayName("OICQ")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(39, "OICQ", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String OICQ
        {
            get { return _OICQ; }
            set { if (OnPropertyChanging("OICQ", value)) { _OICQ = value; OnPropertyChanged("OICQ"); } }
        }

        private String _DimissionDate;
        /// <summary></summary>
        [DisplayName("DimissionDate")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(40, "DimissionDate", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DimissionDate
        {
            get { return _DimissionDate; }
            set { if (OnPropertyChanging("DimissionDate", value)) { _DimissionDate = value; OnPropertyChanged("DimissionDate"); } }
        }

        private String _DimissionCause;
        /// <summary></summary>
        [DisplayName("DimissionCause")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(41, "DimissionCause", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DimissionCause
        {
            get { return _DimissionCause; }
            set { if (OnPropertyChanging("DimissionCause", value)) { _DimissionCause = value; OnPropertyChanged("DimissionCause"); } }
        }

        private String _NativePlace;
        /// <summary></summary>
        [DisplayName("NativePlace")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(42, "NativePlace", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String NativePlace
        {
            get { return _NativePlace; }
            set { if (OnPropertyChanging("NativePlace", value)) { _NativePlace = value; OnPropertyChanged("NativePlace"); } }
        }

        private String _BankCode;
        /// <summary></summary>
        [DisplayName("BankCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(43, "BankCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String BankCode
        {
            get { return _BankCode; }
            set { if (OnPropertyChanging("BankCode", value)) { _BankCode = value; OnPropertyChanged("BankCode"); } }
        }

        private String _Party;
        /// <summary></summary>
        [DisplayName("Party")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(44, "Party", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Party
        {
            get { return _Party; }
            set { if (OnPropertyChanging("Party", value)) { _Party = value; OnPropertyChanged("Party"); } }
        }

        private String _Nationality;
        /// <summary></summary>
        [DisplayName("Nationality")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(45, "Nationality", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Nationality
        {
            get { return _Nationality; }
            set { if (OnPropertyChanging("Nationality", value)) { _Nationality = value; OnPropertyChanged("Nationality"); } }
        }

        private String _Major;
        /// <summary></summary>
        [DisplayName("Major")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(46, "Major", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Major
        {
            get { return _Major; }
            set { if (OnPropertyChanging("Major", value)) { _Major = value; OnPropertyChanged("Major"); } }
        }

        private String _WorkingProperty;
        /// <summary></summary>
        [DisplayName("WorkingProperty")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(47, "WorkingProperty", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String WorkingProperty
        {
            get { return _WorkingProperty; }
            set { if (OnPropertyChanging("WorkingProperty", value)) { _WorkingProperty = value; OnPropertyChanged("WorkingProperty"); } }
        }

        private String _Competency;
        /// <summary></summary>
        [DisplayName("Competency")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(48, "Competency", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Competency
        {
            get { return _Competency; }
            set { if (OnPropertyChanging("Competency", value)) { _Competency = value; OnPropertyChanged("Competency"); } }
        }

        private String _IsDimission;
        /// <summary></summary>
        [DisplayName("IsDimission")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(49, "IsDimission", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String IsDimission
        {
            get { return _IsDimission; }
            set { if (OnPropertyChanging("IsDimission", value)) { _IsDimission = value; OnPropertyChanged("IsDimission"); } }
        }

        private String _DimissionWhither;
        /// <summary></summary>
        [DisplayName("DimissionWhither")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(50, "DimissionWhither", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DimissionWhither
        {
            get { return _DimissionWhither; }
            set { if (OnPropertyChanging("DimissionWhither", value)) { _DimissionWhither = value; OnPropertyChanged("DimissionWhither"); } }
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

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(52, "Enabled", "", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(53, "SortCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(54, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(55, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(56, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(57, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(58, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(59, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(60, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "UserId" : return _UserId;
                    case "UserName" : return _UserName;
                    case "RealName" : return _RealName;
                    case "QuickQuery" : return _QuickQuery;
                    case "CompanyId" : return _CompanyId;
                    case "DepartmentId" : return _DepartmentId;
                    case "WorkgroupId" : return _WorkgroupId;
                    case "DutyId" : return _DutyId;
                    case "Gender" : return _Gender;
                    case "Birthday" : return _Birthday;
                    case "Age" : return _Age;
                    case "IdentificationCode" : return _IdentificationCode;
                    case "IDCard" : return _IDCard;
                    case "Nation" : return _Nation;
                    case "Education" : return _Education;
                    case "School" : return _School;
                    case "Degree" : return _Degree;
                    case "TitleId" : return _TitleId;
                    case "TitleDate" : return _TitleDate;
                    case "TitleLevel" : return _TitleLevel;
                    case "WorkingDate" : return _WorkingDate;
                    case "JoinInDate" : return _JoinInDate;
                    case "OfficeZipCode" : return _OfficeZipCode;
                    case "OfficeAddress" : return _OfficeAddress;
                    case "OfficeFax" : return _OfficeFax;
                    case "OfficePhone" : return _OfficePhone;
                    case "HomeZipCode" : return _HomeZipCode;
                    case "HomeAddress" : return _HomeAddress;
                    case "HomeFax" : return _HomeFax;
                    case "HomePhone" : return _HomePhone;
                    case "CarCode" : return _CarCode;
                    case "Email" : return _Email;
                    case "Mobile" : return _Mobile;
                    case "ShortNumber" : return _ShortNumber;
                    case "Telephone" : return _Telephone;
                    case "EmergencyContact" : return _EmergencyContact;
                    case "OICQ" : return _OICQ;
                    case "DimissionDate" : return _DimissionDate;
                    case "DimissionCause" : return _DimissionCause;
                    case "NativePlace" : return _NativePlace;
                    case "BankCode" : return _BankCode;
                    case "Party" : return _Party;
                    case "Nationality" : return _Nationality;
                    case "Major" : return _Major;
                    case "WorkingProperty" : return _WorkingProperty;
                    case "Competency" : return _Competency;
                    case "IsDimission" : return _IsDimission;
                    case "DimissionWhither" : return _DimissionWhither;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "Enabled" : return _Enabled;
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
                    case "UserId" : _UserId = Convert.ToInt32(value); break;
                    case "UserName" : _UserName = Convert.ToString(value); break;
                    case "RealName" : _RealName = Convert.ToString(value); break;
                    case "QuickQuery" : _QuickQuery = Convert.ToString(value); break;
                    case "CompanyId" : _CompanyId = Convert.ToInt32(value); break;
                    case "DepartmentId" : _DepartmentId = Convert.ToInt32(value); break;
                    case "WorkgroupId" : _WorkgroupId = Convert.ToInt32(value); break;
                    case "DutyId" : _DutyId = Convert.ToString(value); break;
                    case "Gender" : _Gender = Convert.ToString(value); break;
                    case "Birthday" : _Birthday = Convert.ToString(value); break;
                    case "Age" : _Age = Convert.ToString(value); break;
                    case "IdentificationCode" : _IdentificationCode = Convert.ToString(value); break;
                    case "IDCard" : _IDCard = Convert.ToString(value); break;
                    case "Nation" : _Nation = Convert.ToString(value); break;
                    case "Education" : _Education = Convert.ToString(value); break;
                    case "School" : _School = Convert.ToString(value); break;
                    case "Degree" : _Degree = Convert.ToString(value); break;
                    case "TitleId" : _TitleId = Convert.ToString(value); break;
                    case "TitleDate" : _TitleDate = Convert.ToString(value); break;
                    case "TitleLevel" : _TitleLevel = Convert.ToString(value); break;
                    case "WorkingDate" : _WorkingDate = Convert.ToString(value); break;
                    case "JoinInDate" : _JoinInDate = Convert.ToString(value); break;
                    case "OfficeZipCode" : _OfficeZipCode = Convert.ToString(value); break;
                    case "OfficeAddress" : _OfficeAddress = Convert.ToString(value); break;
                    case "OfficeFax" : _OfficeFax = Convert.ToString(value); break;
                    case "OfficePhone" : _OfficePhone = Convert.ToString(value); break;
                    case "HomeZipCode" : _HomeZipCode = Convert.ToString(value); break;
                    case "HomeAddress" : _HomeAddress = Convert.ToString(value); break;
                    case "HomeFax" : _HomeFax = Convert.ToString(value); break;
                    case "HomePhone" : _HomePhone = Convert.ToString(value); break;
                    case "CarCode" : _CarCode = Convert.ToString(value); break;
                    case "Email" : _Email = Convert.ToString(value); break;
                    case "Mobile" : _Mobile = Convert.ToString(value); break;
                    case "ShortNumber" : _ShortNumber = Convert.ToString(value); break;
                    case "Telephone" : _Telephone = Convert.ToString(value); break;
                    case "EmergencyContact" : _EmergencyContact = Convert.ToString(value); break;
                    case "OICQ" : _OICQ = Convert.ToString(value); break;
                    case "DimissionDate" : _DimissionDate = Convert.ToString(value); break;
                    case "DimissionCause" : _DimissionCause = Convert.ToString(value); break;
                    case "NativePlace" : _NativePlace = Convert.ToString(value); break;
                    case "BankCode" : _BankCode = Convert.ToString(value); break;
                    case "Party" : _Party = Convert.ToString(value); break;
                    case "Nationality" : _Nationality = Convert.ToString(value); break;
                    case "Major" : _Major = Convert.ToString(value); break;
                    case "WorkingProperty" : _WorkingProperty = Convert.ToString(value); break;
                    case "Competency" : _Competency = Convert.ToString(value); break;
                    case "IsDimission" : _IsDimission = Convert.ToString(value); break;
                    case "DimissionWhither" : _DimissionWhither = Convert.ToString(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
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
            public static readonly Field UserId = FindByName("UserId");

            ///<summary></summary>
            public static readonly Field UserName = FindByName("UserName");

            ///<summary></summary>
            public static readonly Field RealName = FindByName("RealName");

            ///<summary></summary>
            public static readonly Field QuickQuery = FindByName("QuickQuery");

            ///<summary></summary>
            public static readonly Field CompanyId = FindByName("CompanyId");

            ///<summary></summary>
            public static readonly Field DepartmentId = FindByName("DepartmentId");

            ///<summary></summary>
            public static readonly Field WorkgroupId = FindByName("WorkgroupId");

            ///<summary></summary>
            public static readonly Field DutyId = FindByName("DutyId");

            ///<summary></summary>
            public static readonly Field Gender = FindByName("Gender");

            ///<summary></summary>
            public static readonly Field Birthday = FindByName("Birthday");

            ///<summary></summary>
            public static readonly Field Age = FindByName("Age");

            ///<summary></summary>
            public static readonly Field IdentificationCode = FindByName("IdentificationCode");

            ///<summary></summary>
            public static readonly Field IDCard = FindByName("IDCard");

            ///<summary></summary>
            public static readonly Field Nation = FindByName("Nation");

            ///<summary></summary>
            public static readonly Field Education = FindByName("Education");

            ///<summary></summary>
            public static readonly Field School = FindByName("School");

            ///<summary></summary>
            public static readonly Field Degree = FindByName("Degree");

            ///<summary></summary>
            public static readonly Field TitleId = FindByName("TitleId");

            ///<summary></summary>
            public static readonly Field TitleDate = FindByName("TitleDate");

            ///<summary></summary>
            public static readonly Field TitleLevel = FindByName("TitleLevel");

            ///<summary></summary>
            public static readonly Field WorkingDate = FindByName("WorkingDate");

            ///<summary></summary>
            public static readonly Field JoinInDate = FindByName("JoinInDate");

            ///<summary></summary>
            public static readonly Field OfficeZipCode = FindByName("OfficeZipCode");

            ///<summary></summary>
            public static readonly Field OfficeAddress = FindByName("OfficeAddress");

            ///<summary></summary>
            public static readonly Field OfficeFax = FindByName("OfficeFax");

            ///<summary></summary>
            public static readonly Field OfficePhone = FindByName("OfficePhone");

            ///<summary></summary>
            public static readonly Field HomeZipCode = FindByName("HomeZipCode");

            ///<summary></summary>
            public static readonly Field HomeAddress = FindByName("HomeAddress");

            ///<summary></summary>
            public static readonly Field HomeFax = FindByName("HomeFax");

            ///<summary></summary>
            public static readonly Field HomePhone = FindByName("HomePhone");

            ///<summary></summary>
            public static readonly Field CarCode = FindByName("CarCode");

            ///<summary></summary>
            public static readonly Field Email = FindByName("Email");

            ///<summary></summary>
            public static readonly Field Mobile = FindByName("Mobile");

            ///<summary></summary>
            public static readonly Field ShortNumber = FindByName("ShortNumber");

            ///<summary></summary>
            public static readonly Field Telephone = FindByName("Telephone");

            ///<summary></summary>
            public static readonly Field EmergencyContact = FindByName("EmergencyContact");

            ///<summary></summary>
            public static readonly Field OICQ = FindByName("OICQ");

            ///<summary></summary>
            public static readonly Field DimissionDate = FindByName("DimissionDate");

            ///<summary></summary>
            public static readonly Field DimissionCause = FindByName("DimissionCause");

            ///<summary></summary>
            public static readonly Field NativePlace = FindByName("NativePlace");

            ///<summary></summary>
            public static readonly Field BankCode = FindByName("BankCode");

            ///<summary></summary>
            public static readonly Field Party = FindByName("Party");

            ///<summary></summary>
            public static readonly Field Nationality = FindByName("Nationality");

            ///<summary></summary>
            public static readonly Field Major = FindByName("Major");

            ///<summary></summary>
            public static readonly Field WorkingProperty = FindByName("WorkingProperty");

            ///<summary></summary>
            public static readonly Field Competency = FindByName("Competency");

            ///<summary></summary>
            public static readonly Field IsDimission = FindByName("IsDimission");

            ///<summary></summary>
            public static readonly Field DimissionWhither = FindByName("DimissionWhither");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

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
    public partial interface IBaseStaff
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        Int32 UserId { get; set; }

        /// <summary></summary>
        String UserName { get; set; }

        /// <summary></summary>
        String RealName { get; set; }

        /// <summary></summary>
        String QuickQuery { get; set; }

        /// <summary></summary>
        Int32 CompanyId { get; set; }

        /// <summary></summary>
        Int32 DepartmentId { get; set; }

        /// <summary></summary>
        Int32 WorkgroupId { get; set; }

        /// <summary></summary>
        String DutyId { get; set; }

        /// <summary></summary>
        String Gender { get; set; }

        /// <summary></summary>
        String Birthday { get; set; }

        /// <summary></summary>
        String Age { get; set; }

        /// <summary></summary>
        String IdentificationCode { get; set; }

        /// <summary></summary>
        String IDCard { get; set; }

        /// <summary></summary>
        String Nation { get; set; }

        /// <summary></summary>
        String Education { get; set; }

        /// <summary></summary>
        String School { get; set; }

        /// <summary></summary>
        String Degree { get; set; }

        /// <summary></summary>
        String TitleId { get; set; }

        /// <summary></summary>
        String TitleDate { get; set; }

        /// <summary></summary>
        String TitleLevel { get; set; }

        /// <summary></summary>
        String WorkingDate { get; set; }

        /// <summary></summary>
        String JoinInDate { get; set; }

        /// <summary></summary>
        String OfficeZipCode { get; set; }

        /// <summary></summary>
        String OfficeAddress { get; set; }

        /// <summary></summary>
        String OfficeFax { get; set; }

        /// <summary></summary>
        String OfficePhone { get; set; }

        /// <summary></summary>
        String HomeZipCode { get; set; }

        /// <summary></summary>
        String HomeAddress { get; set; }

        /// <summary></summary>
        String HomeFax { get; set; }

        /// <summary></summary>
        String HomePhone { get; set; }

        /// <summary></summary>
        String CarCode { get; set; }

        /// <summary></summary>
        String Email { get; set; }

        /// <summary></summary>
        String Mobile { get; set; }

        /// <summary></summary>
        String ShortNumber { get; set; }

        /// <summary></summary>
        String Telephone { get; set; }

        /// <summary></summary>
        String EmergencyContact { get; set; }

        /// <summary></summary>
        String OICQ { get; set; }

        /// <summary></summary>
        String DimissionDate { get; set; }

        /// <summary></summary>
        String DimissionCause { get; set; }

        /// <summary></summary>
        String NativePlace { get; set; }

        /// <summary></summary>
        String BankCode { get; set; }

        /// <summary></summary>
        String Party { get; set; }

        /// <summary></summary>
        String Nationality { get; set; }

        /// <summary></summary>
        String Major { get; set; }

        /// <summary></summary>
        String WorkingProperty { get; set; }

        /// <summary></summary>
        String Competency { get; set; }

        /// <summary></summary>
        String IsDimission { get; set; }

        /// <summary></summary>
        String DimissionWhither { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

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