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
    [BindIndex("PK_Base_Module", true, "Id")]
    [BindTable("BaseModule", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseModule : IBaseModule
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
        [DataObjectField(false, false, true, 100)]
        [BindColumn(3, "Code", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } }
        }

        private String _FullName;
        /// <summary></summary>
        [DisplayName("FullName")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "FullName", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String FullName
        {
            get { return _FullName; }
            set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } }
        }

        private String _Category;
        /// <summary></summary>
        [DisplayName("Category")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "Category", "", "Application", "nvarchar(50)", 0, 0, true)]
        public virtual String Category
        {
            get { return _Category; }
            set { if (OnPropertyChanging("Category", value)) { _Category = value; OnPropertyChanged("Category"); } }
        }

        private String _NavigateUrl;
        /// <summary></summary>
        [DisplayName("NavigateUrl")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "NavigateUrl", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String NavigateUrl
        {
            get { return _NavigateUrl; }
            set { if (OnPropertyChanging("NavigateUrl", value)) { _NavigateUrl = value; OnPropertyChanged("NavigateUrl"); } }
        }

        private String _ImageIndex;
        /// <summary></summary>
        [DisplayName("ImageIndex")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "ImageIndex", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ImageIndex
        {
            get { return _ImageIndex; }
            set { if (OnPropertyChanging("ImageIndex", value)) { _ImageIndex = value; OnPropertyChanged("ImageIndex"); } }
        }

        private String _SelectedImageIndex;
        /// <summary></summary>
        [DisplayName("SelectedImageIndex")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "SelectedImageIndex", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SelectedImageIndex
        {
            get { return _SelectedImageIndex; }
            set { if (OnPropertyChanging("SelectedImageIndex", value)) { _SelectedImageIndex = value; OnPropertyChanged("SelectedImageIndex"); } }
        }

        private String _Target;
        /// <summary></summary>
        [DisplayName("Target")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(9, "Target", "", "fraContent", "nvarchar(100)", 0, 0, true)]
        public virtual String Target
        {
            get { return _Target; }
            set { if (OnPropertyChanging("Target", value)) { _Target = value; OnPropertyChanged("Target"); } }
        }

        private String _PermissionItemCode;
        /// <summary></summary>
        [DisplayName("PermissionItemCode")]
        [Description("")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(10, "PermissionItemCode", "", "Resource.AccessPermission", "nvarchar(50)", 0, 0, true)]
        public virtual String PermissionItemCode
        {
            get { return _PermissionItemCode; }
            set { if (OnPropertyChanging("PermissionItemCode", value)) { _PermissionItemCode = value; OnPropertyChanged("PermissionItemCode"); } }
        }

        private String _PermissionScopeTables;
        /// <summary></summary>
        [DisplayName("PermissionScopeTables")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(11, "PermissionScopeTables", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String PermissionScopeTables
        {
            get { return _PermissionScopeTables; }
            set { if (OnPropertyChanging("PermissionScopeTables", value)) { _PermissionScopeTables = value; OnPropertyChanged("PermissionScopeTables"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(12, "SortCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(13, "Enabled", "", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(14, "DeletionStateCode", "", "0", "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private Int32 _IsPublic;
        /// <summary></summary>
        [DisplayName("IsPublic")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(15, "IsPublic", "", "1", "int", 10, 0, false)]
        public virtual Int32 IsPublic
        {
            get { return _IsPublic; }
            set { if (OnPropertyChanging("IsPublic", value)) { _IsPublic = value; OnPropertyChanged("IsPublic"); } }
        }

        private Int32 _IsMenu;
        /// <summary></summary>
        [DisplayName("IsMenu")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(16, "IsMenu", "", "1", "int", 10, 0, false)]
        public virtual Int32 IsMenu
        {
            get { return _IsMenu; }
            set { if (OnPropertyChanging("IsMenu", value)) { _IsMenu = value; OnPropertyChanged("IsMenu"); } }
        }

        private Int32 _Expand;
        /// <summary></summary>
        [DisplayName("Expand")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(17, "Expand", "", "1", "int", 10, 0, false)]
        public virtual Int32 Expand
        {
            get { return _Expand; }
            set { if (OnPropertyChanging("Expand", value)) { _Expand = value; OnPropertyChanged("Expand"); } }
        }

        private Int32 _AllowEdit;
        /// <summary></summary>
        [DisplayName("AllowEdit")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(18, "AllowEdit", "", "1", "int", 10, 0, false)]
        public virtual Int32 AllowEdit
        {
            get { return _AllowEdit; }
            set { if (OnPropertyChanging("AllowEdit", value)) { _AllowEdit = value; OnPropertyChanged("AllowEdit"); } }
        }

        private Int32 _AllowDelete;
        /// <summary></summary>
        [DisplayName("AllowDelete")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(19, "AllowDelete", "", "1", "int", 10, 0, false)]
        public virtual Int32 AllowDelete
        {
            get { return _AllowDelete; }
            set { if (OnPropertyChanging("AllowDelete", value)) { _AllowDelete = value; OnPropertyChanged("AllowDelete"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(20, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
                    case "ParentId" : return _ParentId;
                    case "Code" : return _Code;
                    case "FullName" : return _FullName;
                    case "Category" : return _Category;
                    case "NavigateUrl" : return _NavigateUrl;
                    case "ImageIndex" : return _ImageIndex;
                    case "SelectedImageIndex" : return _SelectedImageIndex;
                    case "Target" : return _Target;
                    case "PermissionItemCode" : return _PermissionItemCode;
                    case "PermissionScopeTables" : return _PermissionScopeTables;
                    case "SortCode" : return _SortCode;
                    case "Enabled" : return _Enabled;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "IsPublic" : return _IsPublic;
                    case "IsMenu" : return _IsMenu;
                    case "Expand" : return _Expand;
                    case "AllowEdit" : return _AllowEdit;
                    case "AllowDelete" : return _AllowDelete;
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
                    case "ParentId" : _ParentId = Convert.ToInt32(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "FullName" : _FullName = Convert.ToString(value); break;
                    case "Category" : _Category = Convert.ToString(value); break;
                    case "NavigateUrl" : _NavigateUrl = Convert.ToString(value); break;
                    case "ImageIndex" : _ImageIndex = Convert.ToString(value); break;
                    case "SelectedImageIndex" : _SelectedImageIndex = Convert.ToString(value); break;
                    case "Target" : _Target = Convert.ToString(value); break;
                    case "PermissionItemCode" : _PermissionItemCode = Convert.ToString(value); break;
                    case "PermissionScopeTables" : _PermissionScopeTables = Convert.ToString(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "IsPublic" : _IsPublic = Convert.ToInt32(value); break;
                    case "IsMenu" : _IsMenu = Convert.ToInt32(value); break;
                    case "Expand" : _Expand = Convert.ToInt32(value); break;
                    case "AllowEdit" : _AllowEdit = Convert.ToInt32(value); break;
                    case "AllowDelete" : _AllowDelete = Convert.ToInt32(value); break;
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
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary></summary>
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field FullName = FindByName("FullName");

            ///<summary></summary>
            public static readonly Field Category = FindByName("Category");

            ///<summary></summary>
            public static readonly Field NavigateUrl = FindByName("NavigateUrl");

            ///<summary></summary>
            public static readonly Field ImageIndex = FindByName("ImageIndex");

            ///<summary></summary>
            public static readonly Field SelectedImageIndex = FindByName("SelectedImageIndex");

            ///<summary></summary>
            public static readonly Field Target = FindByName("Target");

            ///<summary></summary>
            public static readonly Field PermissionItemCode = FindByName("PermissionItemCode");

            ///<summary></summary>
            public static readonly Field PermissionScopeTables = FindByName("PermissionScopeTables");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field IsPublic = FindByName("IsPublic");

            ///<summary></summary>
            public static readonly Field IsMenu = FindByName("IsMenu");

            ///<summary></summary>
            public static readonly Field Expand = FindByName("Expand");

            ///<summary></summary>
            public static readonly Field AllowEdit = FindByName("AllowEdit");

            ///<summary></summary>
            public static readonly Field AllowDelete = FindByName("AllowDelete");

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
    public partial interface IBaseModule
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
        String Category { get; set; }

        /// <summary></summary>
        String NavigateUrl { get; set; }

        /// <summary></summary>
        String ImageIndex { get; set; }

        /// <summary></summary>
        String SelectedImageIndex { get; set; }

        /// <summary></summary>
        String Target { get; set; }

        /// <summary></summary>
        String PermissionItemCode { get; set; }

        /// <summary></summary>
        String PermissionScopeTables { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        Int32 IsPublic { get; set; }

        /// <summary></summary>
        Int32 IsMenu { get; set; }

        /// <summary></summary>
        Int32 Expand { get; set; }

        /// <summary></summary>
        Int32 AllowEdit { get; set; }

        /// <summary></summary>
        Int32 AllowDelete { get; set; }

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