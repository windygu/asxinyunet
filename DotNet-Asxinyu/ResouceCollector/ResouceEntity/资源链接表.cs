﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace ResouceEntity
{
    /// <summary>资源链接表</summary>
    [Serializable]
    [DataObject]
    [Description("资源链接表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("Index_ResourceName", false, "ResouceName")]
    [BindIndex("Index_MD5", false, "ResouceMD5")]
    [BindTable("tb_resoucelink", Description = "资源链接表", ConnName = "ResourceConn", DbType = DatabaseType.MySql)]
    public partial class tb_resoucelink : Itb_resoucelink
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn(1, "Id", "编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _ResouceMD5;
        /// <summary>资源MD5值</summary>
        [DisplayName("资源MD5值")]
        [Description("资源MD5值")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "ResouceMD5", "资源MD5值", null, "varchar(50)", 0, 0, false)]
        public virtual String ResouceMD5
        {
            get { return _ResouceMD5; }
            set { if (OnPropertyChanging("ResouceMD5", value)) { _ResouceMD5 = value; OnPropertyChanged("ResouceMD5"); } }
        }

        private String _ResouceName;
        /// <summary>资源名称</summary>
        [DisplayName("资源名称")]
        [Description("资源名称")]
        [DataObjectField(false, false, true, 250)]
        [BindColumn(3, "ResouceName", "资源名称", null, "varchar(250)", 0, 0, false)]
        public virtual String ResouceName
        {
            get { return _ResouceName; }
            set { if (OnPropertyChanging("ResouceName", value)) { _ResouceName = value; OnPropertyChanged("ResouceName"); } }
        }

        private String _ResouceLink;
        /// <summary>下载链接</summary>
        [DisplayName("下载链接")]
        [Description("下载链接")]
        [DataObjectField(false, false, true, 65535)]
        [BindColumn(4, "ResouceLink", "下载链接", null, "text", 0, 0, false)]
        public virtual String ResouceLink
        {
            get { return _ResouceLink; }
            set { if (OnPropertyChanging("ResouceLink", value)) { _ResouceLink = value; OnPropertyChanged("ResouceLink"); } }
        }

        private UInt64 _Size;
        /// <summary>文件大小</summary>
        [DisplayName("文件大小")]
        [Description("文件大小")]
        [DataObjectField(false, false, true, 19)]
        [BindColumn(5, "Size", "文件大小", null, "bigint(20) unsigned", 19, 0, false)]
        public virtual UInt64 Size
        {
            get { return _Size; }
            set { if (OnPropertyChanging("Size", value)) { _Size = value; OnPropertyChanged("Size"); } }
        }

        private String _ClassName;
        /// <summary>一级大类名称</summary>
        [DisplayName("一级大类名称")]
        [Description("一级大类名称")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(6, "ClassName", "一级大类名称", null, "varchar(20)", 0, 0, false)]
        public virtual String ClassName
        {
            get { return _ClassName; }
            set { if (OnPropertyChanging("ClassName", value)) { _ClassName = value; OnPropertyChanged("ClassName"); } }
        }

        private String _SubClassName;
        /// <summary>子类名称</summary>
        [DisplayName("子类名称")]
        [Description("子类名称")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(7, "SubClassName", "子类名称", null, "varchar(20)", 0, 0, false)]
        public virtual String SubClassName
        {
            get { return _SubClassName; }
            set { if (OnPropertyChanging("SubClassName", value)) { _SubClassName = value; OnPropertyChanged("SubClassName"); } }
        }

        private String _ResouceType;
        /// <summary>资源类型</summary>
        [DisplayName("资源类型")]
        [Description("资源类型")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "ResouceType", "资源类型", null, "varchar(10)", 0, 0, false)]
        public virtual String ResouceType
        {
            get { return _ResouceType; }
            set { if (OnPropertyChanging("ResouceType", value)) { _ResouceType = value; OnPropertyChanged("ResouceType"); } }
        }

        private String _FromURL;
        /// <summary>来源网址</summary>
        [DisplayName("来源网址")]
        [Description("来源网址")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(9, "FromURL", "来源网址", null, "varchar(200)", 0, 0, false)]
        public virtual String FromURL
        {
            get { return _FromURL; }
            set { if (OnPropertyChanging("FromURL", value)) { _FromURL = value; OnPropertyChanged("FromURL"); } }
        }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn(10, "UpdateTime", "更新时间", null, "datetime", 0, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private String _InfoOrigin;
        /// <summary>来源</summary>
        [DisplayName("来源")]
        [Description("来源")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "InfoOrigin", "来源", null, "varchar(10)", 0, 0, false)]
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
        [BindColumn(12, "Remark", "备注", null, "text", 0, 0, false)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } }
        }

        private UInt32 _IsDownload;
        /// <summary>是否下载</summary>
        [DisplayName("是否下载")]
        [Description("是否下载")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(13, "IsDownload", "是否下载", "0", "int(10) unsigned", 10, 0, false)]
        public virtual UInt32 IsDownload
        {
            get { return _IsDownload; }
            set { if (OnPropertyChanging("IsDownload", value)) { _IsDownload = value; OnPropertyChanged("IsDownload"); } }
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
                    case "ResouceMD5" : return _ResouceMD5;
                    case "ResouceName" : return _ResouceName;
                    case "ResouceLink" : return _ResouceLink;
                    case "Size" : return _Size;
                    case "ClassName" : return _ClassName;
                    case "SubClassName" : return _SubClassName;
                    case "ResouceType" : return _ResouceType;
                    case "FromURL" : return _FromURL;
                    case "UpdateTime" : return _UpdateTime;
                    case "InfoOrigin" : return _InfoOrigin;
                    case "Remark" : return _Remark;
                    case "IsDownload" : return _IsDownload;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "ResouceMD5" : _ResouceMD5 = Convert.ToString(value); break;
                    case "ResouceName" : _ResouceName = Convert.ToString(value); break;
                    case "ResouceLink" : _ResouceLink = Convert.ToString(value); break;
                    case "Size" : _Size = Convert.ToUInt64(value); break;
                    case "ClassName" : _ClassName = Convert.ToString(value); break;
                    case "SubClassName" : _SubClassName = Convert.ToString(value); break;
                    case "ResouceType" : _ResouceType = Convert.ToString(value); break;
                    case "FromURL" : _FromURL = Convert.ToString(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
                    case "InfoOrigin" : _InfoOrigin = Convert.ToString(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    case "IsDownload" : _IsDownload = Convert.ToUInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得资源链接表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>资源MD5值</summary>
            public static readonly Field ResouceMD5 = FindByName("ResouceMD5");

            ///<summary>资源名称</summary>
            public static readonly Field ResouceName = FindByName("ResouceName");

            ///<summary>下载链接</summary>
            public static readonly Field ResouceLink = FindByName("ResouceLink");

            ///<summary>文件大小</summary>
            public static readonly Field Size = FindByName("Size");

            ///<summary>一级大类名称</summary>
            public static readonly Field ClassName = FindByName("ClassName");

            ///<summary>子类名称</summary>
            public static readonly Field SubClassName = FindByName("SubClassName");

            ///<summary>资源类型</summary>
            public static readonly Field ResouceType = FindByName("ResouceType");

            ///<summary>来源网址</summary>
            public static readonly Field FromURL = FindByName("FromURL");

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            ///<summary>来源</summary>
            public static readonly Field InfoOrigin = FindByName("InfoOrigin");

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            ///<summary>是否下载</summary>
            public static readonly Field IsDownload = FindByName("IsDownload");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>资源链接表接口</summary>
    public partial interface Itb_resoucelink
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>资源MD5值</summary>
        String ResouceMD5 { get; set; }

        /// <summary>资源名称</summary>
        String ResouceName { get; set; }

        /// <summary>下载链接</summary>
        String ResouceLink { get; set; }

        /// <summary>文件大小</summary>
        UInt64 Size { get; set; }

        /// <summary>一级大类名称</summary>
        String ClassName { get; set; }

        /// <summary>子类名称</summary>
        String SubClassName { get; set; }

        /// <summary>资源类型</summary>
        String ResouceType { get; set; }

        /// <summary>来源网址</summary>
        String FromURL { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>来源</summary>
        String InfoOrigin { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }

        /// <summary>是否下载</summary>
        UInt32 IsDownload { get; set; }
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