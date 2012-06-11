﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>权限表</summary>
    [Serializable]
    [DataObject]
    [Description("权限表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("SystemDbId", false, "SystemDbId")]
    [BindIndex("Name", false, "Name")]
    [BindRelation("SystemDbId", false, "SystemDb", "Id")]
    [BindRelation("Id", true, "RolePermission", "PermissionId")]
    [BindRelation("Id", true, "UserPermission", "PermissionId")]
    [BindTable("Permission", Description = "权限表", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class Permission : IPermission
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private Int32 _SystemDbId;
        /// <summary>表编号</summary>
        [DisplayName("表编号")]
        [Description("表编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "SystemDbId", "表编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 SystemDbId
        {
            get { return _SystemDbId; }
            set { if (OnPropertyChanging("SystemDbId", value)) { _SystemDbId = value; OnPropertyChanged("SystemDbId"); } }
        }

        private Int32 _ParentId;
        /// <summary>父编号</summary>
        [DisplayName("父编号")]
        [Description("父编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "ParentId", "父编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 ParentId
        {
            get { return _ParentId; }
            set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } }
        }

        private String _Name;
        /// <summary>权限名称</summary>
        [DisplayName("权限名称")]
        [Description("权限名称")]
        [DataObjectField(false, false, false, 30)]
        [BindColumn(4, "Name", "权限名称", null, "varchar(30)", 0, 0, false)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
        }

        private SByte _IsDataPermission;
        /// <summary>是否开启数据权限</summary>
        [DisplayName("是否开启数据权限")]
        [Description("是否开启数据权限")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "IsDataPermission", "是否开启数据权限", "0", "tinyint(4)", 3, 0, false)]
        public virtual SByte IsDataPermission
        {
            get { return _IsDataPermission; }
            set { if (OnPropertyChanging("IsDataPermission", value)) { _IsDataPermission = value; OnPropertyChanged("IsDataPermission"); } }
        }

        private String _Constraint;
        /// <summary>数据条件</summary>
        [DisplayName("数据条件")]
        [Description("数据条件")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(6, "Constraint", "数据条件", null, "varchar(100)", 0, 0, false)]
        public virtual String Constraint
        {
            get { return _Constraint; }
            set { if (OnPropertyChanging("Constraint", value)) { _Constraint = value; OnPropertyChanged("Constraint"); } }
        }

        private Int32 _SortCode;
        /// <summary>排序码</summary>
        [DisplayName("排序码")]
        [Description("排序码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "SortCode", "排序码", "9999", "int(11)", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private SByte _IsEnable;
        /// <summary>是否有效</summary>
        [DisplayName("是否有效")]
        [Description("是否有效")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(8, "IsEnable", "是否有效", "1", "tinyint(4)", 3, 0, false)]
        public virtual SByte IsEnable
        {
            get { return _IsEnable; }
            set { if (OnPropertyChanging("IsEnable", value)) { _IsEnable = value; OnPropertyChanged("IsEnable"); } }
        }

        private SByte _DeletionStatusCode;
        /// <summary>删除状态</summary>
        [DisplayName("删除状态")]
        [Description("删除状态")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(9, "DeletionStatusCode", "删除状态", "0", "tinyint(4)", 3, 0, false)]
        public virtual SByte DeletionStatusCode
        {
            get { return _DeletionStatusCode; }
            set { if (OnPropertyChanging("DeletionStatusCode", value)) { _DeletionStatusCode = value; OnPropertyChanged("DeletionStatusCode"); } }
        }

        private String _Description;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "Description", "备注", "", "varchar(50)", 0, 0, false)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
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
                    case "SystemDbId" : return _SystemDbId;
                    case "ParentId" : return _ParentId;
                    case "Name" : return _Name;
                    case "IsDataPermission" : return _IsDataPermission;
                    case "Constraint" : return _Constraint;
                    case "SortCode" : return _SortCode;
                    case "IsEnable" : return _IsEnable;
                    case "DeletionStatusCode" : return _DeletionStatusCode;
                    case "Description" : return _Description;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "SystemDbId" : _SystemDbId = Convert.ToInt32(value); break;
                    case "ParentId" : _ParentId = Convert.ToInt32(value); break;
                    case "Name" : _Name = Convert.ToString(value); break;
                    case "IsDataPermission" : _IsDataPermission = Convert.ToSByte(value); break;
                    case "Constraint" : _Constraint = Convert.ToString(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "IsEnable" : _IsEnable = Convert.ToSByte(value); break;
                    case "DeletionStatusCode" : _DeletionStatusCode = Convert.ToSByte(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得权限表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>表编号</summary>
            public static readonly Field SystemDbId = FindByName("SystemDbId");

            ///<summary>父编号</summary>
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary>权限名称</summary>
            public static readonly Field Name = FindByName("Name");

            ///<summary>是否开启数据权限</summary>
            public static readonly Field IsDataPermission = FindByName("IsDataPermission");

            ///<summary>数据条件</summary>
            public static readonly Field Constraint = FindByName("Constraint");

            ///<summary>排序码</summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary>是否有效</summary>
            public static readonly Field IsEnable = FindByName("IsEnable");

            ///<summary>删除状态</summary>
            public static readonly Field DeletionStatusCode = FindByName("DeletionStatusCode");

            ///<summary>备注</summary>
            public static readonly Field Description = FindByName("Description");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>权限表接口</summary>
    public partial interface IPermission
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>表编号</summary>
        Int32 SystemDbId { get; set; }

        /// <summary>父编号</summary>
        Int32 ParentId { get; set; }

        /// <summary>权限名称</summary>
        String Name { get; set; }

        /// <summary>是否开启数据权限</summary>
        SByte IsDataPermission { get; set; }

        /// <summary>数据条件</summary>
        String Constraint { get; set; }

        /// <summary>排序码</summary>
        Int32 SortCode { get; set; }

        /// <summary>是否有效</summary>
        SByte IsEnable { get; set; }

        /// <summary>删除状态</summary>
        SByte DeletionStatusCode { get; set; }

        /// <summary>备注</summary>
        String Description { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}