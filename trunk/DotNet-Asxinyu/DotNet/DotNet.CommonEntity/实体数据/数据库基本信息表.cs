﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>数据库基本信息表</summary>
    [Serializable]
    [DataObject]
    [Description("数据库基本信息表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("SystemId", false, "SystemId")]
    [BindIndex("DataBaseName", false, "DataBaseName")]
    [BindIndex("TableName", false, "DataBaseName,TableName")]
    [BindRelation("Id", true, "Log", "SystemDbId")]
    [BindRelation("Id", true, "Menu", "SystemDbId")]
    [BindRelation("Id", true, "Permission", "SystemDbId")]
    [BindTable("SystemDb", Description = "数据库基本信息表", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class SystemDb<TEntity> : ISystemDb
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
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "SystemId", "系统编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 SystemId
        {
            get { return _SystemId; }
            set { if (OnPropertyChanging("SystemId", value)) { _SystemId = value; OnPropertyChanged("SystemId"); } }
        }

        private String _DataBaseName;
        /// <summary>数据库名称</summary>
        [DisplayName("数据库名称")]
        [Description("数据库名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(3, "DataBaseName", "数据库名称", null, "varchar(20)", 0, 0, false)]
        public virtual String DataBaseName
        {
            get { return _DataBaseName; }
            set { if (OnPropertyChanging("DataBaseName", value)) { _DataBaseName = value; OnPropertyChanged("DataBaseName"); } }
        }

        private String _TableName;
        /// <summary>表名称</summary>
        [DisplayName("表名称")]
        [Description("表名称")]
        [DataObjectField(false, false, false, 30)]
        [BindColumn(4, "TableName", "表名称", null, "varchar(30)", 0, 0, false)]
        public virtual String TableName
        {
            get { return _TableName; }
            set { if (OnPropertyChanging("TableName", value)) { _TableName = value; OnPropertyChanged("TableName"); } }
        }

        private String _Description;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(5, "Description", "描述", null, "varchar(30)", 0, 0, false)]
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
                    case "DataBaseName" : return _DataBaseName;
                    case "TableName" : return _TableName;
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
                    case "DataBaseName" : _DataBaseName = Convert.ToString(value); break;
                    case "TableName" : _TableName = Convert.ToString(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得数据库基本信息表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>系统编号</summary>
            public static readonly Field SystemId = FindByName("SystemId");

            ///<summary>数据库名称</summary>
            public static readonly Field DataBaseName = FindByName("DataBaseName");

            ///<summary>表名称</summary>
            public static readonly Field TableName = FindByName("TableName");

            ///<summary>描述</summary>
            public static readonly Field Description = FindByName("Description");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>数据库基本信息表接口</summary>
    public partial interface ISystemDb
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>系统编号</summary>
        Int32 SystemId { get; set; }

        /// <summary>数据库名称</summary>
        String DataBaseName { get; set; }

        /// <summary>表名称</summary>
        String TableName { get; set; }

        /// <summary>描述</summary>
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