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
    [BindIndex("PK_Base_Businesscard", true, "Id")]
    [BindTable("BusinessCard", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BusinessCard : IBusinessCard
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

        private String _FullName;
        /// <summary></summary>
        [DisplayName("FullName")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(2, "FullName", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String FullName
        {
            get { return _FullName; }
            set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } }
        }

        private String _Company;
        /// <summary></summary>
        [DisplayName("Company")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(3, "Company", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Company
        {
            get { return _Company; }
            set { if (OnPropertyChanging("Company", value)) { _Company = value; OnPropertyChanged("Company"); } }
        }

        private String _Title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(4, "Title", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging("Title", value)) { _Title = value; OnPropertyChanged("Title"); } }
        }

        private String _Phone;
        /// <summary></summary>
        [DisplayName("Phone")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(5, "Phone", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Phone
        {
            get { return _Phone; }
            set { if (OnPropertyChanging("Phone", value)) { _Phone = value; OnPropertyChanged("Phone"); } }
        }

        private String _Postalcode;
        /// <summary></summary>
        [DisplayName("Postalcode")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(6, "Postalcode", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Postalcode
        {
            get { return _Postalcode; }
            set { if (OnPropertyChanging("Postalcode", value)) { _Postalcode = value; OnPropertyChanged("Postalcode"); } }
        }

        private String _Mobile;
        /// <summary></summary>
        [DisplayName("Mobile")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(7, "Mobile", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Mobile
        {
            get { return _Mobile; }
            set { if (OnPropertyChanging("Mobile", value)) { _Mobile = value; OnPropertyChanged("Mobile"); } }
        }

        private String _Address;
        /// <summary></summary>
        [DisplayName("Address")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(8, "Address", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Address
        {
            get { return _Address; }
            set { if (OnPropertyChanging("Address", value)) { _Address = value; OnPropertyChanged("Address"); } }
        }

        private String _Email;
        /// <summary></summary>
        [DisplayName("Email")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(9, "Email", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Email
        {
            get { return _Email; }
            set { if (OnPropertyChanging("Email", value)) { _Email = value; OnPropertyChanged("Email"); } }
        }

        private String _OfficePhone;
        /// <summary></summary>
        [DisplayName("OfficePhone")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(10, "OfficePhone", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String OfficePhone
        {
            get { return _OfficePhone; }
            set { if (OnPropertyChanging("OfficePhone", value)) { _OfficePhone = value; OnPropertyChanged("OfficePhone"); } }
        }

        private String _QQ;
        /// <summary></summary>
        [DisplayName("QQ")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(11, "QQ", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String QQ
        {
            get { return _QQ; }
            set { if (OnPropertyChanging("QQ", value)) { _QQ = value; OnPropertyChanged("QQ"); } }
        }

        private String _Fax;
        /// <summary></summary>
        [DisplayName("Fax")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(12, "Fax", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Fax
        {
            get { return _Fax; }
            set { if (OnPropertyChanging("Fax", value)) { _Fax = value; OnPropertyChanged("Fax"); } }
        }

        private String _Web;
        /// <summary></summary>
        [DisplayName("Web")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(13, "Web", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Web
        {
            get { return _Web; }
            set { if (OnPropertyChanging("Web", value)) { _Web = value; OnPropertyChanged("Web"); } }
        }

        private String _BankName;
        /// <summary></summary>
        [DisplayName("BankName")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(14, "BankName", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String BankName
        {
            get { return _BankName; }
            set { if (OnPropertyChanging("BankName", value)) { _BankName = value; OnPropertyChanged("BankName"); } }
        }

        private String _BankAccount;
        /// <summary></summary>
        [DisplayName("BankAccount")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(15, "BankAccount", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String BankAccount
        {
            get { return _BankAccount; }
            set { if (OnPropertyChanging("BankAccount", value)) { _BankAccount = value; OnPropertyChanged("BankAccount"); } }
        }

        private String _TaxAccount;
        /// <summary></summary>
        [DisplayName("TaxAccount")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(16, "TaxAccount", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String TaxAccount
        {
            get { return _TaxAccount; }
            set { if (OnPropertyChanging("TaxAccount", value)) { _TaxAccount = value; OnPropertyChanged("TaxAccount"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(17, "Description", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private Int32 _Personal;
        /// <summary></summary>
        [DisplayName("Personal")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(18, "Personal", "", null, "int", 10, 0, false)]
        public virtual Int32 Personal
        {
            get { return _Personal; }
            set { if (OnPropertyChanging("Personal", value)) { _Personal = value; OnPropertyChanged("Personal"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(19, "DeletionStateCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(20, "SortCode", "", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private DateTime _CreateOn;
        /// <summary></summary>
        [DisplayName("CreateOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(21, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(22, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(23, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(24, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(25, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(26, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "Company" : return _Company;
                    case "Title" : return _Title;
                    case "Phone" : return _Phone;
                    case "Postalcode" : return _Postalcode;
                    case "Mobile" : return _Mobile;
                    case "Address" : return _Address;
                    case "Email" : return _Email;
                    case "OfficePhone" : return _OfficePhone;
                    case "QQ" : return _QQ;
                    case "Fax" : return _Fax;
                    case "Web" : return _Web;
                    case "BankName" : return _BankName;
                    case "BankAccount" : return _BankAccount;
                    case "TaxAccount" : return _TaxAccount;
                    case "Description" : return _Description;
                    case "Personal" : return _Personal;
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
                    case "FullName" : _FullName = Convert.ToString(value); break;
                    case "Company" : _Company = Convert.ToString(value); break;
                    case "Title" : _Title = Convert.ToString(value); break;
                    case "Phone" : _Phone = Convert.ToString(value); break;
                    case "Postalcode" : _Postalcode = Convert.ToString(value); break;
                    case "Mobile" : _Mobile = Convert.ToString(value); break;
                    case "Address" : _Address = Convert.ToString(value); break;
                    case "Email" : _Email = Convert.ToString(value); break;
                    case "OfficePhone" : _OfficePhone = Convert.ToString(value); break;
                    case "QQ" : _QQ = Convert.ToString(value); break;
                    case "Fax" : _Fax = Convert.ToString(value); break;
                    case "Web" : _Web = Convert.ToString(value); break;
                    case "BankName" : _BankName = Convert.ToString(value); break;
                    case "BankAccount" : _BankAccount = Convert.ToString(value); break;
                    case "TaxAccount" : _TaxAccount = Convert.ToString(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "Personal" : _Personal = Convert.ToInt32(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
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
            public static readonly Field Company = FindByName("Company");

            ///<summary></summary>
            public static readonly Field Title = FindByName("Title");

            ///<summary></summary>
            public static readonly Field Phone = FindByName("Phone");

            ///<summary></summary>
            public static readonly Field Postalcode = FindByName("Postalcode");

            ///<summary></summary>
            public static readonly Field Mobile = FindByName("Mobile");

            ///<summary></summary>
            public static readonly Field Address = FindByName("Address");

            ///<summary></summary>
            public static readonly Field Email = FindByName("Email");

            ///<summary></summary>
            public static readonly Field OfficePhone = FindByName("OfficePhone");

            ///<summary></summary>
            public static readonly Field QQ = FindByName("QQ");

            ///<summary></summary>
            public static readonly Field Fax = FindByName("Fax");

            ///<summary></summary>
            public static readonly Field Web = FindByName("Web");

            ///<summary></summary>
            public static readonly Field BankName = FindByName("BankName");

            ///<summary></summary>
            public static readonly Field BankAccount = FindByName("BankAccount");

            ///<summary></summary>
            public static readonly Field TaxAccount = FindByName("TaxAccount");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field Personal = FindByName("Personal");

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
    public partial interface IBusinessCard
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String FullName { get; set; }

        /// <summary></summary>
        String Company { get; set; }

        /// <summary></summary>
        String Title { get; set; }

        /// <summary></summary>
        String Phone { get; set; }

        /// <summary></summary>
        String Postalcode { get; set; }

        /// <summary></summary>
        String Mobile { get; set; }

        /// <summary></summary>
        String Address { get; set; }

        /// <summary></summary>
        String Email { get; set; }

        /// <summary></summary>
        String OfficePhone { get; set; }

        /// <summary></summary>
        String QQ { get; set; }

        /// <summary></summary>
        String Fax { get; set; }

        /// <summary></summary>
        String Web { get; set; }

        /// <summary></summary>
        String BankName { get; set; }

        /// <summary></summary>
        String BankAccount { get; set; }

        /// <summary></summary>
        String TaxAccount { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        Int32 Personal { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

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