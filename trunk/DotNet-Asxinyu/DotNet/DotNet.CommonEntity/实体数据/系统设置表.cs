﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>系统设置表</summary>
    [Serializable]
    [DataObject]
    [Description("系统设置表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("SystemId", false, "SystemId")]
    [BindIndex("Name", false, "SystemId,Name")]
    [BindTable("Setting", Description = "系统设置表", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class Setting<TEntity> : ISetting
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
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(4, "Name", "名称", null, "varchar(50)", 0, 0, false)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
        }

        private String _DisplayName;
        /// <summary>显示名称</summary>
        [DisplayName("显示名称")]
        [Description("显示名称")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(5, "DisplayName", "显示名称", null, "varchar(30)", 0, 0, false)]
        public virtual String DisplayName
        {
            get { return _DisplayName; }
            set { if (OnPropertyChanging("DisplayName", value)) { _DisplayName = value; OnPropertyChanged("DisplayName"); } }
        }

        private String _Value;
        /// <summary>值</summary>
        [DisplayName("值")]
        [Description("值")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(6, "Value", "值", "", "varchar(100)", 0, 0, false)]
        public virtual String Value
        {
            get { return _Value; }
            set { if (OnPropertyChanging("Value", value)) { _Value = value; OnPropertyChanged("Value"); } }
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
                    case "SystemId" : return _SystemId;
                    case "ParentId" : return _ParentId;
                    case "Name" : return _Name;
                    case "DisplayName" : return _DisplayName;
                    case "Value" : return _Value;
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
                    case "ParentId" : _ParentId = Convert.ToInt32(value); break;
                    case "Name" : _Name = Convert.ToString(value); break;
                    case "DisplayName" : _DisplayName = Convert.ToString(value); break;
                    case "Value" : _Value = Convert.ToString(value); break;
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
        /// <summary>取得系统设置表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>系统编号</summary>
            public static readonly Field SystemId = FindByName("SystemId");

            ///<summary>父编号</summary>
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            ///<summary>显示名称</summary>
            public static readonly Field DisplayName = FindByName("DisplayName");

            ///<summary>值</summary>
            public static readonly Field Value = FindByName("Value");

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

    /// <summary>系统设置表接口</summary>
    public partial interface ISetting
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>系统编号</summary>
        Int32 SystemId { get; set; }

        /// <summary>父编号</summary>
        Int32 ParentId { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>显示名称</summary>
        String DisplayName { get; set; }

        /// <summary>值</summary>
        String Value { get; set; }

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