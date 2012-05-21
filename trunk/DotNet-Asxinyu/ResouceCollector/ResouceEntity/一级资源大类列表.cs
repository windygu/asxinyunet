﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace ResouceEntity
{
    /// <summary>一级资源大类列表</summary>
    [Serializable]
    [DataObject]
    [Description("一级资源大类列表")]
    [BindIndex("PRIMARY", true, "WebURL")]
    [BindTable("tb_fistclasslist", Description = "一级资源大类列表", ConnName = "ResourceConn", DbType = DatabaseType.MySql)]
    public partial class tb_fistclasslist : Itb_fistclasslist
    {
        #region 属性
        private String _WebURL;
        /// <summary>网址</summary>
        [DisplayName("网址")]
        [Description("网址")]
        [DataObjectField(true, false, false, 100)]
        [BindColumn(1, "WebURL", "网址", null, "varchar(100)", 0, 0, false)]
        public virtual String WebURL
        {
            get { return _WebURL; }
            set { if (OnPropertyChanging("WebURL", value)) { _WebURL = value; OnPropertyChanged("WebURL"); } }
        }

        private String _ClassName;
        /// <summary>一级大类名称</summary>
        [DisplayName("一级大类名称")]
        [Description("一级大类名称")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(2, "ClassName", "一级大类名称", null, "varchar(20)", 0, 0, false)]
        public virtual String ClassName
        {
            get { return _ClassName; }
            set { if (OnPropertyChanging("ClassName", value)) { _ClassName = value; OnPropertyChanged("ClassName"); } }
        }

        private String _ResouceType;
        /// <summary>资源类型</summary>
        [DisplayName("资源类型")]
        [Description("资源类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "ResouceType", "资源类型", null, "varchar(10)", 0, 0, false)]
        public virtual String ResouceType
        {
            get { return _ResouceType; }
            set { if (OnPropertyChanging("ResouceType", value)) { _ResouceType = value; OnPropertyChanged("ResouceType"); } }
        }

        private UInt32 _CollectionMark;
        /// <summary>采集标志</summary>
        [DisplayName("采集标志")]
        [Description("采集标志")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "CollectionMark", "采集标志", null, "int(10) unsigned", 10, 0, false)]
        public virtual UInt32 CollectionMark
        {
            get { return _CollectionMark; }
            set { if (OnPropertyChanging("CollectionMark", value)) { _CollectionMark = value; OnPropertyChanged("CollectionMark"); } }
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

        private String _InfoOrigin;
        /// <summary>来源网站</summary>
        [DisplayName("来源网站")]
        [Description("来源网站")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(6, "InfoOrigin", "来源网站", null, "varchar(20)", 0, 0, false)]
        public virtual String InfoOrigin
        {
            get { return _InfoOrigin; }
            set { if (OnPropertyChanging("InfoOrigin", value)) { _InfoOrigin = value; OnPropertyChanged("InfoOrigin"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 65535)]
        [BindColumn(7, "Remark", "备注", null, "text", 0, 0, false)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } }
        }

        private String _SubClassName;
        /// <summary>子类名称</summary>
        [DisplayName("子类名称")]
        [Description("子类名称")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(8, "SubClassName", "子类名称", null, "varchar(20)", 0, 0, false)]
        public virtual String SubClassName
        {
            get { return _SubClassName; }
            set { if (OnPropertyChanging("SubClassName", value)) { _SubClassName = value; OnPropertyChanged("SubClassName"); } }
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
                    case "WebURL" : return _WebURL;
                    case "ClassName" : return _ClassName;
                    case "ResouceType" : return _ResouceType;
                    case "CollectionMark" : return _CollectionMark;
                    case "UpdateTime" : return _UpdateTime;
                    case "InfoOrigin" : return _InfoOrigin;
                    case "Remark" : return _Remark;
                    case "SubClassName" : return _SubClassName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "WebURL" : _WebURL = Convert.ToString(value); break;
                    case "ClassName" : _ClassName = Convert.ToString(value); break;
                    case "ResouceType" : _ResouceType = Convert.ToString(value); break;
                    case "CollectionMark" : _CollectionMark = Convert.ToUInt32(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "InfoOrigin" : _InfoOrigin = Convert.ToString(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    case "SubClassName" : _SubClassName = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得一级资源大类列表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>网址</summary>
            public static readonly Field WebURL = FindByName("WebURL");

            ///<summary>一级大类名称</summary>
            public static readonly Field ClassName = FindByName("ClassName");

            ///<summary>资源类型</summary>
            public static readonly Field ResouceType = FindByName("ResouceType");

            ///<summary>采集标志</summary>
            public static readonly Field CollectionMark = FindByName("CollectionMark");

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            ///<summary>来源网站</summary>
            public static readonly Field InfoOrigin = FindByName("InfoOrigin");

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            ///<summary>子类名称</summary>
            public static readonly Field SubClassName = FindByName("SubClassName");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>一级资源大类列表接口</summary>
    public partial interface Itb_fistclasslist
    {
        #region 属性
        /// <summary>网址</summary>
        String WebURL { get; set; }

        /// <summary>一级大类名称</summary>
        String ClassName { get; set; }

        /// <summary>资源类型</summary>
        String ResouceType { get; set; }

        /// <summary>采集标志</summary>
        UInt32 CollectionMark { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>来源网站</summary>
        String InfoOrigin { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>子类名称</summary>
        String SubClassName { get; set; }
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