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
    [BindIndex("PK_BASE_TABLECOLUMNS", true, "Id")]
    [BindTable("BaseTableColumns", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseTableColumns : IBaseTableColumns
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

        private String _TableCode;
        /// <summary></summary>
        [DisplayName("TableCode")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(2, "TableCode", "", null, "varchar(200)", 0, 0, false)]
        public virtual String TableCode
        {
            get { return _TableCode; }
            set { if (OnPropertyChanging("TableCode", value)) { _TableCode = value; OnPropertyChanged("TableCode"); } }
        }

        private String _ColumnCode;
        /// <summary></summary>
        [DisplayName("ColumnCode")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(3, "ColumnCode", "", null, "varchar(200)", 0, 0, false)]
        public virtual String ColumnCode
        {
            get { return _ColumnCode; }
            set { if (OnPropertyChanging("ColumnCode", value)) { _ColumnCode = value; OnPropertyChanged("ColumnCode"); } }
        }

        private String _ColumnName;
        /// <summary></summary>
        [DisplayName("ColumnName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "ColumnName", "", null, "varchar(50)", 0, 0, false)]
        public virtual String ColumnName
        {
            get { return _ColumnName; }
            set { if (OnPropertyChanging("ColumnName", value)) { _ColumnName = value; OnPropertyChanged("ColumnName"); } }
        }

        private Int32 _IsPublic;
        /// <summary></summary>
        [DisplayName("IsPublic")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "IsPublic", "", "0", "int", 10, 0, false)]
        public virtual Int32 IsPublic
        {
            get { return _IsPublic; }
            set { if (OnPropertyChanging("IsPublic", value)) { _IsPublic = value; OnPropertyChanged("IsPublic"); } }
        }

        private Int32 _ColumnAccess;
        /// <summary></summary>
        [DisplayName("ColumnAccess")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "ColumnAccess", "", "0", "int", 10, 0, false)]
        public virtual Int32 ColumnAccess
        {
            get { return _ColumnAccess; }
            set { if (OnPropertyChanging("ColumnAccess", value)) { _ColumnAccess = value; OnPropertyChanged("ColumnAccess"); } }
        }

        private Int32 _ColumnEdit;
        /// <summary></summary>
        [DisplayName("ColumnEdit")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "ColumnEdit", "", "0", "int", 10, 0, false)]
        public virtual Int32 ColumnEdit
        {
            get { return _ColumnEdit; }
            set { if (OnPropertyChanging("ColumnEdit", value)) { _ColumnEdit = value; OnPropertyChanged("ColumnEdit"); } }
        }

        private Int32 _ColumnDeney;
        /// <summary></summary>
        [DisplayName("ColumnDeney")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "ColumnDeney", "", "0", "int", 10, 0, false)]
        public virtual Int32 ColumnDeney
        {
            get { return _ColumnDeney; }
            set { if (OnPropertyChanging("ColumnDeney", value)) { _ColumnDeney = value; OnPropertyChanged("ColumnDeney"); } }
        }

        private Int32 _UseConstraint;
        /// <summary></summary>
        [DisplayName("UseConstraint")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(9, "UseConstraint", "", "0", "int", 10, 0, false)]
        public virtual Int32 UseConstraint
        {
            get { return _UseConstraint; }
            set { if (OnPropertyChanging("UseConstraint", value)) { _UseConstraint = value; OnPropertyChanged("UseConstraint"); } }
        }

        private String _DataType;
        /// <summary></summary>
        [DisplayName("DataType")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "DataType", "", null, "varchar(50)", 0, 0, false)]
        public virtual String DataType
        {
            get { return _DataType; }
            set { if (OnPropertyChanging("DataType", value)) { _DataType = value; OnPropertyChanged("DataType"); } }
        }

        private String _TargetTable;
        /// <summary></summary>
        [DisplayName("TargetTable")]
        [Description("")]
        [DataObjectField(false, false, true, 400)]
        [BindColumn(11, "TargetTable", "", null, "varchar(400)", 0, 0, false)]
        public virtual String TargetTable
        {
            get { return _TargetTable; }
            set { if (OnPropertyChanging("TargetTable", value)) { _TargetTable = value; OnPropertyChanged("TargetTable"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(12, "Enabled", "", "1", "int", 10, 0, false)]
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
        [BindColumn(13, "AllowEdit", "", "1", "int", 10, 0, false)]
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
        [BindColumn(14, "AllowDelete", "", "1", "int", 10, 0, false)]
        public virtual Int32 AllowDelete
        {
            get { return _AllowDelete; }
            set { if (OnPropertyChanging("AllowDelete", value)) { _AllowDelete = value; OnPropertyChanged("AllowDelete"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(15, "DeletionStateCode", "", "0", "int", 10, 0, false)]
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
        [BindColumn(16, "SortCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(17, "Description", "", null, "varchar(200)", 0, 0, false)]
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
                    case "TableCode" : return _TableCode;
                    case "ColumnCode" : return _ColumnCode;
                    case "ColumnName" : return _ColumnName;
                    case "IsPublic" : return _IsPublic;
                    case "ColumnAccess" : return _ColumnAccess;
                    case "ColumnEdit" : return _ColumnEdit;
                    case "ColumnDeney" : return _ColumnDeney;
                    case "UseConstraint" : return _UseConstraint;
                    case "DataType" : return _DataType;
                    case "TargetTable" : return _TargetTable;
                    case "Enabled" : return _Enabled;
                    case "AllowEdit" : return _AllowEdit;
                    case "AllowDelete" : return _AllowDelete;
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
                    case "TableCode" : _TableCode = Convert.ToString(value); break;
                    case "ColumnCode" : _ColumnCode = Convert.ToString(value); break;
                    case "ColumnName" : _ColumnName = Convert.ToString(value); break;
                    case "IsPublic" : _IsPublic = Convert.ToInt32(value); break;
                    case "ColumnAccess" : _ColumnAccess = Convert.ToInt32(value); break;
                    case "ColumnEdit" : _ColumnEdit = Convert.ToInt32(value); break;
                    case "ColumnDeney" : _ColumnDeney = Convert.ToInt32(value); break;
                    case "UseConstraint" : _UseConstraint = Convert.ToInt32(value); break;
                    case "DataType" : _DataType = Convert.ToString(value); break;
                    case "TargetTable" : _TargetTable = Convert.ToString(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "AllowEdit" : _AllowEdit = Convert.ToInt32(value); break;
                    case "AllowDelete" : _AllowDelete = Convert.ToInt32(value); break;
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
            public static readonly Field TableCode = FindByName("TableCode");

            ///<summary></summary>
            public static readonly Field ColumnCode = FindByName("ColumnCode");

            ///<summary></summary>
            public static readonly Field ColumnName = FindByName("ColumnName");

            ///<summary></summary>
            public static readonly Field IsPublic = FindByName("IsPublic");

            ///<summary></summary>
            public static readonly Field ColumnAccess = FindByName("ColumnAccess");

            ///<summary></summary>
            public static readonly Field ColumnEdit = FindByName("ColumnEdit");

            ///<summary></summary>
            public static readonly Field ColumnDeney = FindByName("ColumnDeney");

            ///<summary></summary>
            public static readonly Field UseConstraint = FindByName("UseConstraint");

            ///<summary></summary>
            public static readonly Field DataType = FindByName("DataType");

            ///<summary></summary>
            public static readonly Field TargetTable = FindByName("TargetTable");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field AllowEdit = FindByName("AllowEdit");

            ///<summary></summary>
            public static readonly Field AllowDelete = FindByName("AllowDelete");

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
    public partial interface IBaseTableColumns
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String TableCode { get; set; }

        /// <summary></summary>
        String ColumnCode { get; set; }

        /// <summary></summary>
        String ColumnName { get; set; }

        /// <summary></summary>
        Int32 IsPublic { get; set; }

        /// <summary></summary>
        Int32 ColumnAccess { get; set; }

        /// <summary></summary>
        Int32 ColumnEdit { get; set; }

        /// <summary></summary>
        Int32 ColumnDeney { get; set; }

        /// <summary></summary>
        Int32 UseConstraint { get; set; }

        /// <summary></summary>
        String DataType { get; set; }

        /// <summary></summary>
        String TargetTable { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

        /// <summary></summary>
        Int32 AllowEdit { get; set; }

        /// <summary></summary>
        Int32 AllowDelete { get; set; }

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