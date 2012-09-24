﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Bioinfo.Entites
{
    /// <summary>系统设置表</summary>
    [Serializable]
    [DataObject]
    [Description("系统设置表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("Name", false, "Name,CodeType")]
    [BindIndex("IX_Setting_CategoryId", false, "CategoryId")]
    [BindRelation("CategoryId", false, "Category", "Id")]
    [BindTable("WebSetting", Description = "系统设置表", ConnName = "Common", DbType = DatabaseType.MySql)]
    public partial class Setting : ISetting
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

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(2, "Name", "名称", null, "varchar(100)", 0, 0, false)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
        }

        private String _Value;
        /// <summary>值</summary>
        [DisplayName("值")]
        [Description("值")]
        [DataObjectField(false, false, true, 65535)]
        [BindColumn(3, "Value", "值", null, "text", 0, 0, false)]
        public virtual String Value
        {
            get { return _Value; }
            set { if (OnPropertyChanging("Value", value)) { _Value = value; OnPropertyChanged("Value"); } }
        }

        private Int32 _CategoryId;
        /// <summary>类别</summary>
        [DisplayName("类别")]
        [Description("类别")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "CategoryId", "类别", null, "int(11)", 10, 0, false)]
        public virtual Int32 CategoryId
        {
            get { return _CategoryId; }
            set { if (OnPropertyChanging("CategoryId", value)) { _CategoryId = value; OnPropertyChanged("CategoryId"); } }
        }

        private Int32 _CodeType;
        /// <summary>编码类型</summary>
        [DisplayName("编码类型")]
        [Description("编码类型")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "CodeType", "编码类型", "1", "int(11)", 10, 0, false)]
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
        [BindColumn(6, "Sort", "排序码", null, "int(11)", 10, 0, false)]
        public virtual Int32 Sort
        {
            get { return _Sort; }
            set { if (OnPropertyChanging("Sort", value)) { _Sort = value; OnPropertyChanged("Sort"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(7, "Remark", "备注", null, "varchar(100)", 0, 0, false)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } }
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
                    case "Name" : return _Name;
                    case "Value" : return _Value;
                    case "CategoryId" : return _CategoryId;
                    case "CodeType" : return _CodeType;
                    case "Sort" : return _Sort;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "Name" : _Name = Convert.ToString(value); break;
                    case "Value" : _Value = Convert.ToString(value); break;
                    case "CategoryId" : _CategoryId = Convert.ToInt32(value); break;
                    case "CodeType" : _CodeType = Convert.ToInt32(value); break;
                    case "Sort" : _Sort = Convert.ToInt32(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
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

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName("Name");

            ///<summary>值</summary>
            public static readonly Field Value = FindByName("Value");

            ///<summary>类别</summary>
            public static readonly Field CategoryId = FindByName("CategoryId");

            ///<summary>编码类型</summary>
            public static readonly Field CodeType = FindByName("CodeType");

            ///<summary>排序码</summary>
            public static readonly Field Sort = FindByName("Sort");

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

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

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>值</summary>
        String Value { get; set; }

        /// <summary>类别</summary>
        Int32 CategoryId { get; set; }

        /// <summary>编码类型</summary>
        Int32 CodeType { get; set; }

        /// <summary>排序码</summary>
        Int32 Sort { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}