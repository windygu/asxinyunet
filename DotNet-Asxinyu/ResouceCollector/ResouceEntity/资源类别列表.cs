﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace ResouceEntity
{
    /// <summary>资源类别列表</summary>
    [Serializable]
    [DataObject]
    [Description("资源类别列表")]
    [BindIndex("PRIMARY", true, "URL")]
    [BindTable("tb_typelist", Description = "资源类别列表", ConnName = "ResourceConn", DbType = DatabaseType.MySql)]
    public partial class tb_typelist : Itb_typelist
    {
        #region 属性
        private String _URL;
        /// <summary>网址</summary>
        [DisplayName("网址")]
        [Description("网址")]
        [DataObjectField(true, false, false, 100)]
        [BindColumn(1, "URL", "网址", null, "varchar(100)", 0, 0, false)]
        public virtual String URL
        {
            get { return _URL; }
            set { if (OnPropertyChanging("URL", value)) { _URL = value; OnPropertyChanged("URL"); } }
        }

        private String _TypeName;
        /// <summary>大类名称</summary>
        [DisplayName("大类名称")]
        [Description("大类名称")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(2, "TypeName", "大类名称", null, "varchar(20)", 0, 0, false)]
        public virtual String TypeName
        {
            get { return _TypeName; }
            set { if (OnPropertyChanging("TypeName", value)) { _TypeName = value; OnPropertyChanged("TypeName"); } }
        }

        private String _SubClassName;
        /// <summary>子类名称</summary>
        [DisplayName("子类名称")]
        [Description("子类名称")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(3, "SubClassName", "子类名称", null, "varchar(20)", 0, 0, false)]
        public virtual String SubClassName
        {
            get { return _SubClassName; }
            set { if (OnPropertyChanging("SubClassName", value)) { _SubClassName = value; OnPropertyChanged("SubClassName"); } }
        }

        private String _ResType;
        /// <summary>资源类型</summary>
        [DisplayName("资源类型")]
        [Description("资源类型")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(4, "ResType", "资源类型", null, "varchar(20)", 0, 0, false)]
        public virtual String ResType
        {
            get { return _ResType; }
            set { if (OnPropertyChanging("ResType", value)) { _ResType = value; OnPropertyChanged("ResType"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn(5, "UpdateTime", "更新时间", null, "datetime", 0, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(6, "Remark", "备注", null, "varchar(100)", 0, 0, false)]
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
                    case "URL" : return _URL;
                    case "TypeName" : return _TypeName;
                    case "SubClassName" : return _SubClassName;
                    case "ResType" : return _ResType;
                    case "UpdateTime" : return _UpdateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "URL" : _URL = Convert.ToString(value); break;
                    case "TypeName" : _TypeName = Convert.ToString(value); break;
                    case "SubClassName" : _SubClassName = Convert.ToString(value); break;
                    case "ResType" : _ResType = Convert.ToString(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得资源类别列表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>网址</summary>
            public static readonly Field URL = FindByName("URL");

            ///<summary>大类名称</summary>
            public static readonly Field TypeName = FindByName("TypeName");

            ///<summary>子类名称</summary>
            public static readonly Field SubClassName = FindByName("SubClassName");

            ///<summary>资源类型</summary>
            public static readonly Field ResType = FindByName("ResType");

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>资源类别列表接口</summary>
    public partial interface Itb_typelist
    {
        #region 属性
        /// <summary>网址</summary>
        String URL { get; set; }

        /// <summary>大类名称</summary>
        String TypeName { get; set; }

        /// <summary>子类名称</summary>
        String SubClassName { get; set; }

        /// <summary>资源类型</summary>
        String ResType { get; set; }

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