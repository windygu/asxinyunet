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
    [BindTable("ViewSystemRole", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class ViewSystemRole : IViewSystemRole
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn(1, "Id", "", null, "int", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _SystemId;
        /// <summary></summary>
        [DisplayName("SystemId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "SystemId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String SystemId
        {
            get { return _SystemId; }
            set { if (OnPropertyChanging("SystemId", value)) { _SystemId = value; OnPropertyChanged("SystemId"); } }
        }

        private Int32 _OrganizeId;
        /// <summary></summary>
        [DisplayName("OrganizeId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "OrganizeId", "", null, "int", 10, 0, false)]
        public virtual Int32 OrganizeId
        {
            get { return _OrganizeId; }
            set { if (OnPropertyChanging("OrganizeId", value)) { _OrganizeId = value; OnPropertyChanged("OrganizeId"); } }
        }

        private String _Code;
        /// <summary></summary>
        [DisplayName("Code")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Code", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } }
        }

        private String _Realname;
        /// <summary></summary>
        [DisplayName("Realname")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(5, "Realname", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Realname
        {
            get { return _Realname; }
            set { if (OnPropertyChanging("Realname", value)) { _Realname = value; OnPropertyChanged("Realname"); } }
        }

        private String _CategoryCode;
        /// <summary></summary>
        [DisplayName("CategoryCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "CategoryCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CategoryCode
        {
            get { return _CategoryCode; }
            set { if (OnPropertyChanging("CategoryCode", value)) { _CategoryCode = value; OnPropertyChanged("CategoryCode"); } }
        }

        private Int32 _AllowEdit;
        /// <summary></summary>
        [DisplayName("AllowEdit")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "AllowEdit", "", null, "int", 10, 0, false)]
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
        [BindColumn(8, "AllowDelete", "", null, "int", 10, 0, false)]
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

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(10, "DeletionStateCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(11, "Enabled", "", null, "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
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
        [BindColumn(13, "CreateOn", "", null, "smalldatetime", 3, 0, false)]
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
        [BindColumn(16, "ModifiedOn", "", null, "smalldatetime", 3, 0, false)]
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
                    case "SystemId" : return _SystemId;
                    case "OrganizeId" : return _OrganizeId;
                    case "Code" : return _Code;
                    case "Realname" : return _Realname;
                    case "CategoryCode" : return _CategoryCode;
                    case "AllowEdit" : return _AllowEdit;
                    case "AllowDelete" : return _AllowDelete;
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
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "SystemId" : _SystemId = Convert.ToString(value); break;
                    case "OrganizeId" : _OrganizeId = Convert.ToInt32(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "Realname" : _Realname = Convert.ToString(value); break;
                    case "CategoryCode" : _CategoryCode = Convert.ToString(value); break;
                    case "AllowEdit" : _AllowEdit = Convert.ToInt32(value); break;
                    case "AllowDelete" : _AllowDelete = Convert.ToInt32(value); break;
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
            public static readonly Field SystemId = FindByName("SystemId");

            ///<summary></summary>
            public static readonly Field OrganizeId = FindByName("OrganizeId");

            ///<summary></summary>
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field Realname = FindByName("Realname");

            ///<summary></summary>
            public static readonly Field CategoryCode = FindByName("CategoryCode");

            ///<summary></summary>
            public static readonly Field AllowEdit = FindByName("AllowEdit");

            ///<summary></summary>
            public static readonly Field AllowDelete = FindByName("AllowDelete");

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
    public partial interface IViewSystemRole
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String SystemId { get; set; }

        /// <summary></summary>
        Int32 OrganizeId { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        String Realname { get; set; }

        /// <summary></summary>
        String CategoryCode { get; set; }

        /// <summary></summary>
        Int32 AllowEdit { get; set; }

        /// <summary></summary>
        Int32 AllowDelete { get; set; }

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