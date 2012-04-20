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
    [BindIndex("PK_Base_Organize", true, "Id")]
    [BindTable("BaseOrganize", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseOrganize : IBaseOrganize
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

        private Int32 _ParentId;
        /// <summary></summary>
        [DisplayName("ParentId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "ParentId", "", null, "int", 10, 0, false)]
        public virtual Int32 ParentId
        {
            get { return _ParentId; }
            set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } }
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

        private String _ShortName;
        /// <summary></summary>
        [DisplayName("ShortName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "ShortName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ShortName
        {
            get { return _ShortName; }
            set { if (OnPropertyChanging("ShortName", value)) { _ShortName = value; OnPropertyChanged("ShortName"); } }
        }

        private String _Category;
        /// <summary></summary>
        [DisplayName("Category")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "Category", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Category
        {
            get { return _Category; }
            set { if (OnPropertyChanging("Category", value)) { _Category = value; OnPropertyChanged("Category"); } }
        }

        private String _OuterPhone;
        /// <summary></summary>
        [DisplayName("OuterPhone")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(7, "OuterPhone", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String OuterPhone
        {
            get { return _OuterPhone; }
            set { if (OnPropertyChanging("OuterPhone", value)) { _OuterPhone = value; OnPropertyChanged("OuterPhone"); } }
        }

        private String _InnerPhone;
        /// <summary></summary>
        [DisplayName("InnerPhone")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(8, "InnerPhone", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String InnerPhone
        {
            get { return _InnerPhone; }
            set { if (OnPropertyChanging("InnerPhone", value)) { _InnerPhone = value; OnPropertyChanged("InnerPhone"); } }
        }

        private String _Fax;
        /// <summary></summary>
        [DisplayName("Fax")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "Fax", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Fax
        {
            get { return _Fax; }
            set { if (OnPropertyChanging("Fax", value)) { _Fax = value; OnPropertyChanged("Fax"); } }
        }

        private String _Postalcode;
        /// <summary></summary>
        [DisplayName("Postalcode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "Postalcode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Postalcode
        {
            get { return _Postalcode; }
            set { if (OnPropertyChanging("Postalcode", value)) { _Postalcode = value; OnPropertyChanged("Postalcode"); } }
        }

        private String _Address;
        /// <summary></summary>
        [DisplayName("Address")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "Address", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Address
        {
            get { return _Address; }
            set { if (OnPropertyChanging("Address", value)) { _Address = value; OnPropertyChanged("Address"); } }
        }

        private String _Web;
        /// <summary></summary>
        [DisplayName("Web")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "Web", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Web
        {
            get { return _Web; }
            set { if (OnPropertyChanging("Web", value)) { _Web = value; OnPropertyChanged("Web"); } }
        }

        private String _Bank;
        /// <summary></summary>
        [DisplayName("Bank")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "Bank", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Bank
        {
            get { return _Bank; }
            set { if (OnPropertyChanging("Bank", value)) { _Bank = value; OnPropertyChanged("Bank"); } }
        }

        private String _BankAccount;
        /// <summary></summary>
        [DisplayName("BankAccount")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "BankAccount", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String BankAccount
        {
            get { return _BankAccount; }
            set { if (OnPropertyChanging("BankAccount", value)) { _BankAccount = value; OnPropertyChanged("BankAccount"); } }
        }

        private String _LeadershipRoleId;
        /// <summary></summary>
        [DisplayName("LeadershipRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "LeadershipRoleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LeadershipRoleId
        {
            get { return _LeadershipRoleId; }
            set { if (OnPropertyChanging("LeadershipRoleId", value)) { _LeadershipRoleId = value; OnPropertyChanged("LeadershipRoleId"); } }
        }

        private String _AssistantLeadershipRoleId;
        /// <summary></summary>
        [DisplayName("AssistantLeadershipRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(16, "AssistantLeadershipRoleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AssistantLeadershipRoleId
        {
            get { return _AssistantLeadershipRoleId; }
            set { if (OnPropertyChanging("AssistantLeadershipRoleId", value)) { _AssistantLeadershipRoleId = value; OnPropertyChanged("AssistantLeadershipRoleId"); } }
        }

        private String _ManagerRoleId;
        /// <summary></summary>
        [DisplayName("ManagerRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(17, "ManagerRoleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ManagerRoleId
        {
            get { return _ManagerRoleId; }
            set { if (OnPropertyChanging("ManagerRoleId", value)) { _ManagerRoleId = value; OnPropertyChanged("ManagerRoleId"); } }
        }

        private String _AssistantManagerRoleId;
        /// <summary></summary>
        [DisplayName("AssistantManagerRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(18, "AssistantManagerRoleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AssistantManagerRoleId
        {
            get { return _AssistantManagerRoleId; }
            set { if (OnPropertyChanging("AssistantManagerRoleId", value)) { _AssistantManagerRoleId = value; OnPropertyChanged("AssistantManagerRoleId"); } }
        }

        private String _FinancialRoleId;
        /// <summary></summary>
        [DisplayName("FinancialRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(19, "FinancialRoleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FinancialRoleId
        {
            get { return _FinancialRoleId; }
            set { if (OnPropertyChanging("FinancialRoleId", value)) { _FinancialRoleId = value; OnPropertyChanged("FinancialRoleId"); } }
        }

        private String _AccountingRoleId;
        /// <summary></summary>
        [DisplayName("AccountingRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(20, "AccountingRoleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AccountingRoleId
        {
            get { return _AccountingRoleId; }
            set { if (OnPropertyChanging("AccountingRoleId", value)) { _AccountingRoleId = value; OnPropertyChanged("AccountingRoleId"); } }
        }

        private String _CashierRoleId;
        /// <summary></summary>
        [DisplayName("CashierRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(21, "CashierRoleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CashierRoleId
        {
            get { return _CashierRoleId; }
            set { if (OnPropertyChanging("CashierRoleId", value)) { _CashierRoleId = value; OnPropertyChanged("CashierRoleId"); } }
        }

        private String _SystemManagerRoleId;
        /// <summary></summary>
        [DisplayName("SystemManagerRoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(22, "SystemManagerRoleId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SystemManagerRoleId
        {
            get { return _SystemManagerRoleId; }
            set { if (OnPropertyChanging("SystemManagerRoleId", value)) { _SystemManagerRoleId = value; OnPropertyChanged("SystemManagerRoleId"); } }
        }

        private Int32 _Layer;
        /// <summary></summary>
        [DisplayName("Layer")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(23, "Layer", "", null, "int", 10, 0, false)]
        public virtual Int32 Layer
        {
            get { return _Layer; }
            set { if (OnPropertyChanging("Layer", value)) { _Layer = value; OnPropertyChanged("Layer"); } }
        }

        private String _AssistantManager;
        /// <summary></summary>
        [DisplayName("AssistantManager")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(24, "AssistantManager", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AssistantManager
        {
            get { return _AssistantManager; }
            set { if (OnPropertyChanging("AssistantManager", value)) { _AssistantManager = value; OnPropertyChanged("AssistantManager"); } }
        }

        private Int32 _IsInnerOrganize;
        /// <summary></summary>
        [DisplayName("IsInnerOrganize")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(25, "IsInnerOrganize", "", "1", "int", 10, 0, false)]
        public virtual Int32 IsInnerOrganize
        {
            get { return _IsInnerOrganize; }
            set { if (OnPropertyChanging("IsInnerOrganize", value)) { _IsInnerOrganize = value; OnPropertyChanged("IsInnerOrganize"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(26, "SortCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(27, "Description", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(28, "DeletionStateCode", "", "0", "int", 10, 0, false)]
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
        [BindColumn(29, "Enabled", "", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private DateTime _CreateOn;
        /// <summary></summary>
        [DisplayName("CreateOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(30, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(31, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(32, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(33, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(34, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(35, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "ParentId" : return _ParentId;
                    case "Code" : return _Code;
                    case "FullName" : return _FullName;
                    case "ShortName" : return _ShortName;
                    case "Category" : return _Category;
                    case "OuterPhone" : return _OuterPhone;
                    case "InnerPhone" : return _InnerPhone;
                    case "Fax" : return _Fax;
                    case "Postalcode" : return _Postalcode;
                    case "Address" : return _Address;
                    case "Web" : return _Web;
                    case "Bank" : return _Bank;
                    case "BankAccount" : return _BankAccount;
                    case "LeadershipRoleId" : return _LeadershipRoleId;
                    case "AssistantLeadershipRoleId" : return _AssistantLeadershipRoleId;
                    case "ManagerRoleId" : return _ManagerRoleId;
                    case "AssistantManagerRoleId" : return _AssistantManagerRoleId;
                    case "FinancialRoleId" : return _FinancialRoleId;
                    case "AccountingRoleId" : return _AccountingRoleId;
                    case "CashierRoleId" : return _CashierRoleId;
                    case "SystemManagerRoleId" : return _SystemManagerRoleId;
                    case "Layer" : return _Layer;
                    case "AssistantManager" : return _AssistantManager;
                    case "IsInnerOrganize" : return _IsInnerOrganize;
                    case "SortCode" : return _SortCode;
                    case "Description" : return _Description;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "Enabled" : return _Enabled;
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
                    case "ParentId" : _ParentId = Convert.ToInt32(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "FullName" : _FullName = Convert.ToString(value); break;
                    case "ShortName" : _ShortName = Convert.ToString(value); break;
                    case "Category" : _Category = Convert.ToString(value); break;
                    case "OuterPhone" : _OuterPhone = Convert.ToString(value); break;
                    case "InnerPhone" : _InnerPhone = Convert.ToString(value); break;
                    case "Fax" : _Fax = Convert.ToString(value); break;
                    case "Postalcode" : _Postalcode = Convert.ToString(value); break;
                    case "Address" : _Address = Convert.ToString(value); break;
                    case "Web" : _Web = Convert.ToString(value); break;
                    case "Bank" : _Bank = Convert.ToString(value); break;
                    case "BankAccount" : _BankAccount = Convert.ToString(value); break;
                    case "LeadershipRoleId" : _LeadershipRoleId = Convert.ToString(value); break;
                    case "AssistantLeadershipRoleId" : _AssistantLeadershipRoleId = Convert.ToString(value); break;
                    case "ManagerRoleId" : _ManagerRoleId = Convert.ToString(value); break;
                    case "AssistantManagerRoleId" : _AssistantManagerRoleId = Convert.ToString(value); break;
                    case "FinancialRoleId" : _FinancialRoleId = Convert.ToString(value); break;
                    case "AccountingRoleId" : _AccountingRoleId = Convert.ToString(value); break;
                    case "CashierRoleId" : _CashierRoleId = Convert.ToString(value); break;
                    case "SystemManagerRoleId" : _SystemManagerRoleId = Convert.ToString(value); break;
                    case "Layer" : _Layer = Convert.ToInt32(value); break;
                    case "AssistantManager" : _AssistantManager = Convert.ToString(value); break;
                    case "IsInnerOrganize" : _IsInnerOrganize = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
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
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary></summary>
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field FullName = FindByName("FullName");

            ///<summary></summary>
            public static readonly Field ShortName = FindByName("ShortName");

            ///<summary></summary>
            public static readonly Field Category = FindByName("Category");

            ///<summary></summary>
            public static readonly Field OuterPhone = FindByName("OuterPhone");

            ///<summary></summary>
            public static readonly Field InnerPhone = FindByName("InnerPhone");

            ///<summary></summary>
            public static readonly Field Fax = FindByName("Fax");

            ///<summary></summary>
            public static readonly Field Postalcode = FindByName("Postalcode");

            ///<summary></summary>
            public static readonly Field Address = FindByName("Address");

            ///<summary></summary>
            public static readonly Field Web = FindByName("Web");

            ///<summary></summary>
            public static readonly Field Bank = FindByName("Bank");

            ///<summary></summary>
            public static readonly Field BankAccount = FindByName("BankAccount");

            ///<summary></summary>
            public static readonly Field LeadershipRoleId = FindByName("LeadershipRoleId");

            ///<summary></summary>
            public static readonly Field AssistantLeadershipRoleId = FindByName("AssistantLeadershipRoleId");

            ///<summary></summary>
            public static readonly Field ManagerRoleId = FindByName("ManagerRoleId");

            ///<summary></summary>
            public static readonly Field AssistantManagerRoleId = FindByName("AssistantManagerRoleId");

            ///<summary></summary>
            public static readonly Field FinancialRoleId = FindByName("FinancialRoleId");

            ///<summary></summary>
            public static readonly Field AccountingRoleId = FindByName("AccountingRoleId");

            ///<summary></summary>
            public static readonly Field CashierRoleId = FindByName("CashierRoleId");

            ///<summary></summary>
            public static readonly Field SystemManagerRoleId = FindByName("SystemManagerRoleId");

            ///<summary></summary>
            public static readonly Field Layer = FindByName("Layer");

            ///<summary></summary>
            public static readonly Field AssistantManager = FindByName("AssistantManager");

            ///<summary></summary>
            public static readonly Field IsInnerOrganize = FindByName("IsInnerOrganize");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

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
    public partial interface IBaseOrganize
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        Int32 ParentId { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        String FullName { get; set; }

        /// <summary></summary>
        String ShortName { get; set; }

        /// <summary></summary>
        String Category { get; set; }

        /// <summary></summary>
        String OuterPhone { get; set; }

        /// <summary></summary>
        String InnerPhone { get; set; }

        /// <summary></summary>
        String Fax { get; set; }

        /// <summary></summary>
        String Postalcode { get; set; }

        /// <summary></summary>
        String Address { get; set; }

        /// <summary></summary>
        String Web { get; set; }

        /// <summary></summary>
        String Bank { get; set; }

        /// <summary></summary>
        String BankAccount { get; set; }

        /// <summary></summary>
        String LeadershipRoleId { get; set; }

        /// <summary></summary>
        String AssistantLeadershipRoleId { get; set; }

        /// <summary></summary>
        String ManagerRoleId { get; set; }

        /// <summary></summary>
        String AssistantManagerRoleId { get; set; }

        /// <summary></summary>
        String FinancialRoleId { get; set; }

        /// <summary></summary>
        String AccountingRoleId { get; set; }

        /// <summary></summary>
        String CashierRoleId { get; set; }

        /// <summary></summary>
        String SystemManagerRoleId { get; set; }

        /// <summary></summary>
        Int32 Layer { get; set; }

        /// <summary></summary>
        String AssistantManager { get; set; }

        /// <summary></summary>
        Int32 IsInnerOrganize { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

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