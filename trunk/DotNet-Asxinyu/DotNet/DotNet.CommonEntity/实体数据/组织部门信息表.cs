﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>组织部门信息表</summary>
    [Serializable]
    [DataObject]
    [Description("组织部门信息表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("OrganizeCode", false, "OrganizeCode")]
    [BindIndex("ShortName", false, "ShortName")]
    [BindIndex("FullName", false, "FullName")]
    [BindRelation("Id", true, "Role", "OrganizeId")]
    [BindRelation("Id", true, "Staff", "OrganizeId")]
    [BindTable("Organize", Description = "组织部门信息表", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class Organize<TEntity> : IOrganize
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

        private Int32 _ParentId;
        /// <summary>父编号</summary>
        [DisplayName("父编号")]
        [Description("父编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "ParentId", "父编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 ParentId
        {
            get { return _ParentId; }
            set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } }
        }

        private String _OrganizeCode;
        /// <summary>组织代码</summary>
        [DisplayName("组织代码")]
        [Description("组织代码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "OrganizeCode", "组织代码", null, "varchar(50)", 0, 0, false)]
        public virtual String OrganizeCode
        {
            get { return _OrganizeCode; }
            set { if (OnPropertyChanging("OrganizeCode", value)) { _OrganizeCode = value; OnPropertyChanged("OrganizeCode"); } }
        }

        private String _ShortName;
        /// <summary>简称</summary>
        [DisplayName("简称")]
        [Description("简称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "ShortName", "简称", null, "varchar(50)", 0, 0, false)]
        public virtual String ShortName
        {
            get { return _ShortName; }
            set { if (OnPropertyChanging("ShortName", value)) { _ShortName = value; OnPropertyChanged("ShortName"); } }
        }

        private String _FullName;
        /// <summary>组织名称</summary>
        [DisplayName("组织名称")]
        [Description("组织名称")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(5, "FullName", "组织名称", null, "varchar(100)", 0, 0, false)]
        public virtual String FullName
        {
            get { return _FullName; }
            set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } }
        }

        private String _Category;
        /// <summary>组织类别</summary>
        [DisplayName("组织类别")]
        [Description("组织类别")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(6, "Category", "组织类别", null, "varchar(30)", 0, 0, false)]
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
                    case "ParentId" : return _ParentId;
                    case "OrganizeCode" : return _OrganizeCode;
                    case "ShortName" : return _ShortName;
                    case "FullName" : return _FullName;
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
                    case "ParentId" : _ParentId = Convert.ToInt32(value); break;
                    case "OrganizeCode" : _OrganizeCode = Convert.ToString(value); break;
                    case "ShortName" : _ShortName = Convert.ToString(value); break;
                    case "FullName" : _FullName = Convert.ToString(value); break;
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
        /// <summary>取得组织部门信息表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>父编号</summary>
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary>组织代码</summary>
            public static readonly Field OrganizeCode = FindByName("OrganizeCode");

            ///<summary>简称</summary>
            public static readonly Field ShortName = FindByName("ShortName");

            ///<summary>组织名称</summary>
            public static readonly Field FullName = FindByName("FullName");

            ///<summary>组织类别</summary>
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

    /// <summary>组织部门信息表接口</summary>
    public partial interface IOrganize
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>父编号</summary>
        Int32 ParentId { get; set; }

        /// <summary>组织代码</summary>
        String OrganizeCode { get; set; }

        /// <summary>简称</summary>
        String ShortName { get; set; }

        /// <summary>组织名称</summary>
        String FullName { get; set; }

        /// <summary>组织类别</summary>
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