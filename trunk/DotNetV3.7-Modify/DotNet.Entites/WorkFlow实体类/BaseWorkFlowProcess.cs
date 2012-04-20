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
    [BindIndex("PK_BASE_WORKFLOW", true, "Id")]
    [BindTable("BaseWorkFlowProcess", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseWorkFlowProcess : IBaseWorkFlowProcess
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

        private String _BillTemplateId;
        /// <summary></summary>
        [DisplayName("BillTemplateId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "BillTemplateId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String BillTemplateId
        {
            get { return _BillTemplateId; }
            set { if (OnPropertyChanging("BillTemplateId", value)) { _BillTemplateId = value; OnPropertyChanged("BillTemplateId"); } }
        }

        private String _OrganizeId;
        /// <summary></summary>
        [DisplayName("OrganizeId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "OrganizeId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String OrganizeId
        {
            get { return _OrganizeId; }
            set { if (OnPropertyChanging("OrganizeId", value)) { _OrganizeId = value; OnPropertyChanged("OrganizeId"); } }
        }

        private String _UserId;
        /// <summary></summary>
        [DisplayName("UserId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "UserId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } }
        }

        private String _AuditCategoryCode;
        /// <summary></summary>
        [DisplayName("AuditCategoryCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "AuditCategoryCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditCategoryCode
        {
            get { return _AuditCategoryCode; }
            set { if (OnPropertyChanging("AuditCategoryCode", value)) { _AuditCategoryCode = value; OnPropertyChanged("AuditCategoryCode"); } }
        }

        private String _BillCategoryCode;
        /// <summary></summary>
        [DisplayName("BillCategoryCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "BillCategoryCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String BillCategoryCode
        {
            get { return _BillCategoryCode; }
            set { if (OnPropertyChanging("BillCategoryCode", value)) { _BillCategoryCode = value; OnPropertyChanged("BillCategoryCode"); } }
        }

        private String _CategoryCode;
        /// <summary></summary>
        [DisplayName("CategoryCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "CategoryCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CategoryCode
        {
            get { return _CategoryCode; }
            set { if (OnPropertyChanging("CategoryCode", value)) { _CategoryCode = value; OnPropertyChanged("CategoryCode"); } }
        }

        private String _Code;
        /// <summary></summary>
        [DisplayName("Code")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "Code", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } }
        }

        private String _FullName;
        /// <summary></summary>
        [DisplayName("FullName")]
        [Description("")]
        [DataObjectField(false, false, false, 200)]
        [BindColumn(9, "FullName", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String FullName
        {
            get { return _FullName; }
            set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } }
        }

        private String _Contents;
        /// <summary></summary>
        [DisplayName("Contents")]
        [Description("")]
        [DataObjectField(false, false, true, -1)]
        [BindColumn(10, "Contents", "", null, "nvarchar(MAX)", 0, 0, true)]
        public virtual String Contents
        {
            get { return _Contents; }
            set { if (OnPropertyChanging("Contents", value)) { _Contents = value; OnPropertyChanged("Contents"); } }
        }

        private String _CallBackClass;
        /// <summary></summary>
        [DisplayName("CallBackClass")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(11, "CallBackClass", "", "DotNet.Business.UserBillManager", "nvarchar(100)", 0, 0, true)]
        public virtual String CallBackClass
        {
            get { return _CallBackClass; }
            set { if (OnPropertyChanging("CallBackClass", value)) { _CallBackClass = value; OnPropertyChanged("CallBackClass"); } }
        }

        private String _CallBackTable;
        /// <summary></summary>
        [DisplayName("CallBackTable")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(12, "CallBackTable", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String CallBackTable
        {
            get { return _CallBackTable; }
            set { if (OnPropertyChanging("CallBackTable", value)) { _CallBackTable = value; OnPropertyChanged("CallBackTable"); } }
        }

        private String _AddPage;
        /// <summary></summary>
        [DisplayName("AddPage")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(13, "AddPage", "", "../HtmlBill/HtmlBillEdit.aspx?TemplateId={Id}", "nvarchar(200)", 0, 0, true)]
        public virtual String AddPage
        {
            get { return _AddPage; }
            set { if (OnPropertyChanging("AddPage", value)) { _AddPage = value; OnPropertyChanged("AddPage"); } }
        }

        private String _EditPage;
        /// <summary></summary>
        [DisplayName("EditPage")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(14, "EditPage", "", "HtmlBill/HtmlBillEdit.aspx?Id={Id}", "nvarchar(200)", 0, 0, true)]
        public virtual String EditPage
        {
            get { return _EditPage; }
            set { if (OnPropertyChanging("EditPage", value)) { _EditPage = value; OnPropertyChanged("EditPage"); } }
        }

        private String _ShowPage;
        /// <summary></summary>
        [DisplayName("ShowPage")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(15, "ShowPage", "", "HtmlBill/HtmlBillShow.aspx?Id={Id}", "nvarchar(200)", 0, 0, true)]
        public virtual String ShowPage
        {
            get { return _ShowPage; }
            set { if (OnPropertyChanging("ShowPage", value)) { _ShowPage = value; OnPropertyChanged("ShowPage"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(16, "SortCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(17, "Enabled", "", "1", "int", 10, 0, false)]
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
        [BindColumn(18, "DeletionStateCode", "", "0", "int", 10, 0, false)]
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
        [BindColumn(19, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(20, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(21, "CreateUserId", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(22, "CreateBy", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(23, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(24, "ModifiedUserId", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(25, "ModifiedBy", "", null, "nvarchar(50)", 0, 0, true)]
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
                    case "BillTemplateId" : return _BillTemplateId;
                    case "OrganizeId" : return _OrganizeId;
                    case "UserId" : return _UserId;
                    case "AuditCategoryCode" : return _AuditCategoryCode;
                    case "BillCategoryCode" : return _BillCategoryCode;
                    case "CategoryCode" : return _CategoryCode;
                    case "Code" : return _Code;
                    case "FullName" : return _FullName;
                    case "Contents" : return _Contents;
                    case "CallBackClass" : return _CallBackClass;
                    case "CallBackTable" : return _CallBackTable;
                    case "AddPage" : return _AddPage;
                    case "EditPage" : return _EditPage;
                    case "ShowPage" : return _ShowPage;
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
                    case "BillTemplateId" : _BillTemplateId = Convert.ToString(value); break;
                    case "OrganizeId" : _OrganizeId = Convert.ToString(value); break;
                    case "UserId" : _UserId = Convert.ToString(value); break;
                    case "AuditCategoryCode" : _AuditCategoryCode = Convert.ToString(value); break;
                    case "BillCategoryCode" : _BillCategoryCode = Convert.ToString(value); break;
                    case "CategoryCode" : _CategoryCode = Convert.ToString(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "FullName" : _FullName = Convert.ToString(value); break;
                    case "Contents" : _Contents = Convert.ToString(value); break;
                    case "CallBackClass" : _CallBackClass = Convert.ToString(value); break;
                    case "CallBackTable" : _CallBackTable = Convert.ToString(value); break;
                    case "AddPage" : _AddPage = Convert.ToString(value); break;
                    case "EditPage" : _EditPage = Convert.ToString(value); break;
                    case "ShowPage" : _ShowPage = Convert.ToString(value); break;
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
            public static readonly Field BillTemplateId = FindByName("BillTemplateId");

            ///<summary></summary>
            public static readonly Field OrganizeId = FindByName("OrganizeId");

            ///<summary></summary>
            public static readonly Field UserId = FindByName("UserId");

            ///<summary></summary>
            public static readonly Field AuditCategoryCode = FindByName("AuditCategoryCode");

            ///<summary></summary>
            public static readonly Field BillCategoryCode = FindByName("BillCategoryCode");

            ///<summary></summary>
            public static readonly Field CategoryCode = FindByName("CategoryCode");

            ///<summary></summary>
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field FullName = FindByName("FullName");

            ///<summary></summary>
            public static readonly Field Contents = FindByName("Contents");

            ///<summary></summary>
            public static readonly Field CallBackClass = FindByName("CallBackClass");

            ///<summary></summary>
            public static readonly Field CallBackTable = FindByName("CallBackTable");

            ///<summary></summary>
            public static readonly Field AddPage = FindByName("AddPage");

            ///<summary></summary>
            public static readonly Field EditPage = FindByName("EditPage");

            ///<summary></summary>
            public static readonly Field ShowPage = FindByName("ShowPage");

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
    public partial interface IBaseWorkFlowProcess
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String BillTemplateId { get; set; }

        /// <summary></summary>
        String OrganizeId { get; set; }

        /// <summary></summary>
        String UserId { get; set; }

        /// <summary></summary>
        String AuditCategoryCode { get; set; }

        /// <summary></summary>
        String BillCategoryCode { get; set; }

        /// <summary></summary>
        String CategoryCode { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        String FullName { get; set; }

        /// <summary></summary>
        String Contents { get; set; }

        /// <summary></summary>
        String CallBackClass { get; set; }

        /// <summary></summary>
        String CallBackTable { get; set; }

        /// <summary></summary>
        String AddPage { get; set; }

        /// <summary></summary>
        String EditPage { get; set; }

        /// <summary></summary>
        String ShowPage { get; set; }

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