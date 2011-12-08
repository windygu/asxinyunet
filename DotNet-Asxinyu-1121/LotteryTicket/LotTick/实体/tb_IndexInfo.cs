﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using System.Xml.Serialization;
using XCode.Configuration;
using XCode.DataAccessLayer;

#pragma warning disable 3021
#pragma warning disable 3008
namespace LotTick
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PrimaryKey", true, "Id")]
    [BindIndex("Id", false, "Id")]
    [BindTable("tb_IndexInfo", Description = "", ConnName = "LotTick", DbType = DatabaseType.Access)]
    public partial class tb_IndexInfo : Itb_IndexInfo
    
    {
        #region 属性
        private Int32 _Id;
        /// <summary>指标编号</summary>
        [DisplayName("指标编号")]
        [Description("指标编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "指标编号", null, "Long", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _IndexName;
        /// <summary>指标名称</summary>
        [DisplayName("指标名称")]
        [Description("指标名称")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "IndexName", "指标名称", null, "VarChar", 0, 0, false)]
        public virtual String IndexName
        {
            get { return _IndexName; }
            set { if (OnPropertyChanging("IndexName", value)) { _IndexName = value; OnPropertyChanged("IndexName"); } }
        }

        private Int32 _PriorLevel;
        /// <summary>优先级</summary>
        [DisplayName("优先级")]
        [Description("优先级")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "PriorLevel", "优先级", "1", "Long", 10, 0, false)]
        public virtual Int32 PriorLevel
        {
            get { return _PriorLevel; }
            set { if (OnPropertyChanging("PriorLevel", value)) { _PriorLevel = value; OnPropertyChanged("PriorLevel"); } }
        }

        private String _UseExplain;
        /// <summary>使用说明</summary>
        [DisplayName("使用说明")]
        [Description("使用说明")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "UseExplain", "使用说明", null, "VarChar", 0, 0, false)]
        public virtual String UseExplain
        {
            get { return _UseExplain; }
            set { if (OnPropertyChanging("UseExplain", value)) { _UseExplain = value; OnPropertyChanged("UseExplain"); } }
        }

        private String _Description;
        /// <summary>指标描述</summary>
        [DisplayName("指标描述")]
        [Description("指标描述")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(5, "Description", "指标描述", null, "VarChar", 0, 0, false)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, false, 8)]
        [BindColumn(6, "UpdateTime", "更新时间", null, "DateTime", 0, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "Remark", "备注", null, "VarChar", 0, 0, false)]
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
                    case "IndexName" : return _IndexName;
                    case "PriorLevel" : return _PriorLevel;
                    case "UseExplain" : return _UseExplain;
                    case "Description" : return _Description;
                    case "UpdateTime" : return _UpdateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "IndexName" : _IndexName = Convert.ToString(value); break;
                    case "PriorLevel" : _PriorLevel = Convert.ToInt32(value); break;
                    case "UseExplain" : _UseExplain = Convert.ToString(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>指标编号</summary>
            public static readonly FieldItem Id = Meta.Table.FindByName("Id");

            ///<summary>指标名称</summary>
            public static readonly FieldItem IndexName = Meta.Table.FindByName("IndexName");

            ///<summary>优先级</summary>
            public static readonly FieldItem PriorLevel = Meta.Table.FindByName("PriorLevel");

            ///<summary>使用说明</summary>
            public static readonly FieldItem UseExplain = Meta.Table.FindByName("UseExplain");

            ///<summary>指标描述</summary>
            public static readonly FieldItem Description = Meta.Table.FindByName("Description");

            ///<summary>更新时间</summary>
            public static readonly FieldItem UpdateTime = Meta.Table.FindByName("UpdateTime");

            ///<summary>备注</summary>
            public static readonly FieldItem Remark = Meta.Table.FindByName("Remark");
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface Itb_IndexInfo
    {
        #region 属性
        /// <summary>指标编号</summary>
        Int32 Id { get; set; }

        /// <summary>指标名称</summary>
        String IndexName { get; set; }

        /// <summary>优先级</summary>
        Int32 PriorLevel { get; set; }

        /// <summary>使用说明</summary>
        String UseExplain { get; set; }

        /// <summary>指标描述</summary>
        String Description { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
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
#pragma warning restore 3008
#pragma warning restore 3021