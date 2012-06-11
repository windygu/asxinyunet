﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>角色表</summary>
    [Serializable]
    [DataObject]
    [Description("角色表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("SystemId", false, "SystemId")]
    [BindIndex("OrganizeId", false, "OrganizeId")]
    [BindIndex("SysetmOrganize", false, "SystemId,OrganizeId")]
    [BindRelation("OrganizeId", false, "Organize", "Id")]
    [BindRelation("Id", true, "RolePermission", "RoleId")]
    [BindRelation("Id", true, "User", "RoleId")]
    [BindRelation("Id", true, "UserRole", "RoleId")]
    [BindTable("Role", Description = "角色表", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class Role<TEntity> : IRole
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

        private Int32 _SystemId;
        /// <summary>系统编号</summary>
        [DisplayName("系统编号")]
        [Description("系统编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "SystemId", "系统编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 SystemId
        {
            get { return _SystemId; }
            set { if (OnPropertyChanging("SystemId", value)) { _SystemId = value; OnPropertyChanged("SystemId"); } }
        }

        private Int32 _OrganizeId;
        /// <summary>部门编号</summary>
        [DisplayName("部门编号")]
        [Description("部门编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "OrganizeId", "部门编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 OrganizeId
        {
            get { return _OrganizeId; }
            set { if (OnPropertyChanging("OrganizeId", value)) { _OrganizeId = value; OnPropertyChanged("OrganizeId"); } }
        }

        private String _RoleName;
        /// <summary>角色名称</summary>
        [DisplayName("角色名称")]
        [Description("角色名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(4, "RoleName", "角色名称", "", "varchar(20)", 0, 0, false)]
        public virtual String RoleName
        {
            get { return _RoleName; }
            set { if (OnPropertyChanging("RoleName", value)) { _RoleName = value; OnPropertyChanged("RoleName"); } }
        }

        private String _Category;
        /// <summary>角色分类</summary>
        [DisplayName("角色分类")]
        [Description("角色分类")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(5, "Category", "角色分类", "", "varchar(30)", 0, 0, false)]
        public virtual String Category
        {
            get { return _Category; }
            set { if (OnPropertyChanging("Category", value)) { _Category = value; OnPropertyChanged("Category"); } }
        }

        private Int32 _SortCode;
        /// <summary>排序码</summary>
        [DisplayName("排序码")]
        [Description("排序码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "SortCode", "排序码", "9999", "int(11)", 10, 0, false)]
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
        [BindColumn(7, "IsEnable", "是否有效", "1", "tinyint(4)", 3, 0, false)]
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
        [BindColumn(8, "DeletionStatusCode", "删除状态", "0", "tinyint(4)", 3, 0, false)]
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
        [BindColumn(9, "Description", "备注", "", "varchar(50)", 0, 0, false)]
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
                    case "SystemId" : return _SystemId;
                    case "OrganizeId" : return _OrganizeId;
                    case "RoleName" : return _RoleName;
                    case "Category" : return _Category;
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
                    case "SystemId" : _SystemId = Convert.ToInt32(value); break;
                    case "OrganizeId" : _OrganizeId = Convert.ToInt32(value); break;
                    case "RoleName" : _RoleName = Convert.ToString(value); break;
                    case "Category" : _Category = Convert.ToString(value); break;
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
        /// <summary>取得角色表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>系统编号</summary>
            public static readonly Field SystemId = FindByName("SystemId");

            ///<summary>部门编号</summary>
            public static readonly Field OrganizeId = FindByName("OrganizeId");

            ///<summary>角色名称</summary>
            public static readonly Field RoleName = FindByName("RoleName");

            ///<summary>角色分类</summary>
            public static readonly Field Category = FindByName("Category");

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

    /// <summary>角色表接口</summary>
    public partial interface IRole
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>系统编号</summary>
        Int32 SystemId { get; set; }

        /// <summary>部门编号</summary>
        Int32 OrganizeId { get; set; }

        /// <summary>角色名称</summary>
        String RoleName { get; set; }

        /// <summary>角色分类</summary>
        String Category { get; set; }

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