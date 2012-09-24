﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Bioinfo.Entites
{
    /// <summary>类别信息</summary>
    [Serializable]
    [DataObject]
    [Description("类别信息")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("Name", false, "Name")]
    [BindIndex("ParentId", false, "ParentId")]
    [BindTable("Category", Description = "类别信息", ConnName = "Common", DbType = DatabaseType.MySql)]
    public partial class Category : ICategory
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

        private String _Name;
        /// <summary>类名称</summary>
        [DisplayName("类名称")]
        [Description("类名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "Name", "类名称", null, "varchar(50)", 0, 0, false)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
        }

        private Int32 _CodeType;
        /// <summary>编码类型</summary>
        [DisplayName("编码类型")]
        [Description("编码类型")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(4, "CodeType", "编码类型", "1", "int(11)", 10, 0, false)]
        public virtual Int32 CodeType
        {
            get { return _CodeType; }
            set { if (OnPropertyChanging("CodeType", value)) { _CodeType = value; OnPropertyChanged("CodeType"); } }
        }

        private Int32 _Sort;
        /// <summary>排序码</summary>
        [DisplayName("排序码")]
        [Description("排序码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "Sort", "排序码", "9999", "int(11)", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging("Sort", value)) { _Sort = value; OnPropertyChanged("Sort"); } }
        }

        private String _Description;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "Description", "备注", null, "varchar(50)", 0, 0, false)]
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
                    case "Name" : return _Name;
                    case "CodeType" : return _CodeType;
                    case "Sort" : return _Sort;
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
                    case "Name" : _Name = Convert.ToString(value); break;
                    case "CodeType" : _CodeType = Convert.ToInt32(value); break;
                    case "Sort" : _Sort = Convert.ToInt32(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得类别信息字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>父编号</summary>
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary>类名称</summary>
            public static readonly Field Name = FindByName("Name");

            ///<summary>编码类型</summary>
            public static readonly Field CodeType = FindByName("CodeType");

            ///<summary>排序码</summary>
            public static readonly Field Sort = FindByName("Sort");

            ///<summary>备注</summary>
            public static readonly Field Description = FindByName("Description");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>类别信息接口</summary>
    public partial interface ICategory
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>父编号</summary>
        Int32 ParentId { get; set; }

        /// <summary>类名称</summary>
        String Name { get; set; }

        /// <summary>编码类型</summary>
        Int32 CodeType { get; set; }

        /// <summary>排序码</summary>
        Int32 Sort { get; set; }

        /// <summary>备注</summary>
        String Description { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}