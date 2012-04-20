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
    [BindIndex("PK_Base_ItemDetails_BulletinCategory", true, "Id")]
    [BindTable("ItemsNewsCategory", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class ItemsNewsCategory : IItemsNewsCategory
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

        private String _ItemCode;
        /// <summary></summary>
        [DisplayName("ItemCode")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(3, "ItemCode", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String ItemCode
        {
            get { return _ItemCode; }
            set { if (OnPropertyChanging("ItemCode", value)) { _ItemCode = value; OnPropertyChanged("ItemCode"); } }
        }

        private String _ItemName;
        /// <summary></summary>
        [DisplayName("ItemName")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "ItemName", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String ItemName
        {
            get { return _ItemName; }
            set { if (OnPropertyChanging("ItemName", value)) { _ItemName = value; OnPropertyChanged("ItemName"); } }
        }

        private String _ItemValue;
        /// <summary></summary>
        [DisplayName("ItemValue")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(5, "ItemValue", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String ItemValue
        {
            get { return _ItemValue; }
            set { if (OnPropertyChanging("ItemValue", value)) { _ItemValue = value; OnPropertyChanged("ItemValue"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(6, "Enabled", "", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Int32 _AllowEdit;
        /// <summary></summary>
        [DisplayName("AllowEdit")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "AllowEdit", "", "1", "int", 10, 0, false)]
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
        [BindColumn(8, "AllowDelete", "", "1", "int", 10, 0, false)]
        public virtual Int32 AllowDelete
        {
            get { return _AllowDelete; }
            set { if (OnPropertyChanging("AllowDelete", value)) { _AllowDelete = value; OnPropertyChanged("AllowDelete"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "SortCode", "", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private Int32 _IsPublic;
        /// <summary></summary>
        [DisplayName("IsPublic")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(10, "IsPublic", "", "1", "int", 10, 0, false)]
        public virtual Int32 IsPublic
        {
            get { return _IsPublic; }
            set { if (OnPropertyChanging("IsPublic", value)) { _IsPublic = value; OnPropertyChanged("IsPublic"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "DeletionStateCode", "", "0", "int", 10, 0, false)]
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
        [BindColumn(12, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(13, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(14, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(15, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(16, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(17, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(18, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "ItemCode" : return _ItemCode;
                    case "ItemName" : return _ItemName;
                    case "ItemValue" : return _ItemValue;
                    case "Enabled" : return _Enabled;
                    case "AllowEdit" : return _AllowEdit;
                    case "AllowDelete" : return _AllowDelete;
                    case "SortCode" : return _SortCode;
                    case "IsPublic" : return _IsPublic;
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
                    case "ParentId" : _ParentId = Convert.ToInt32(value); break;
                    case "ItemCode" : _ItemCode = Convert.ToString(value); break;
                    case "ItemName" : _ItemName = Convert.ToString(value); break;
                    case "ItemValue" : _ItemValue = Convert.ToString(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "AllowEdit" : _AllowEdit = Convert.ToInt32(value); break;
                    case "AllowDelete" : _AllowDelete = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "IsPublic" : _IsPublic = Convert.ToInt32(value); break;
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
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary></summary>
            public static readonly Field ItemCode = FindByName("ItemCode");

            ///<summary></summary>
            public static readonly Field ItemName = FindByName("ItemName");

            ///<summary></summary>
            public static readonly Field ItemValue = FindByName("ItemValue");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field AllowEdit = FindByName("AllowEdit");

            ///<summary></summary>
            public static readonly Field AllowDelete = FindByName("AllowDelete");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary></summary>
            public static readonly Field IsPublic = FindByName("IsPublic");

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
    public partial interface IItemsNewsCategory
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        Int32 ParentId { get; set; }

        /// <summary></summary>
        String ItemCode { get; set; }

        /// <summary></summary>
        String ItemName { get; set; }

        /// <summary></summary>
        String ItemValue { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

        /// <summary></summary>
        Int32 AllowEdit { get; set; }

        /// <summary></summary>
        Int32 AllowDelete { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

        /// <summary></summary>
        Int32 IsPublic { get; set; }

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