﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace ResouceEntity
{
    /// <summary>资源网络存储信息</summary>
    [Serializable]
    [DataObject]
    [Description("资源网络存储信息")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("IX_WebUrlInfo", false, "Name")]
    [BindIndex("IX_WebUrlInfo_Md5", false, "Md5")]
    [BindTable("tb_weburlinfo", Description = "资源网络存储信息", ConnName = "ResourceConn", DbType = DatabaseType.MySql)]
    public partial class tb_weburlinfo : Itb_weburlinfo
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

        private Int32 _ResourceId;
        /// <summary>资源编号</summary>
        [DisplayName("资源编号")]
        [Description("资源编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "ResourceId", "资源编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 ResourceId
        {
            get { return _ResourceId; }
            set { if (OnPropertyChanging("ResourceId", value)) { _ResourceId = value; OnPropertyChanged("ResourceId"); } }
        }

        private String _Name;
        /// <summary>资源名称</summary>
        [DisplayName("资源名称")]
        [Description("资源名称")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(3, "Name", "资源名称", null, "varchar(150)", 0, 0, false)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
        }

        private String _Md5;
        /// <summary>Md5值</summary>
        [DisplayName("Md5值")]
        [Description("Md5值")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(4, "Md5", "Md5值", null, "varchar(50)", 0, 0, false)]
        public virtual String Md5
        {
            get { return _Md5; }
            set { if (OnPropertyChanging("Md5", value)) { _Md5 = value; OnPropertyChanged("Md5"); } }
        }

        private String _Website;
        /// <summary>网盘名称</summary>
        [DisplayName("网盘名称")]
        [Description("网盘名称")]
        [DataObjectField(false, false, false, 20)]
        [BindColumn(5, "Website", "网盘名称", null, "varchar(20)", 0, 0, false)]
        public virtual String Website
        {
            get { return _Website; }
            set { if (OnPropertyChanging("Website", value)) { _Website = value; OnPropertyChanged("Website"); } }
        }

        private String _DownloadURL;
        /// <summary>下载地址</summary>
        [DisplayName("下载地址")]
        [Description("下载地址")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(6, "DownloadURL", "下载地址", null, "varchar(100)", 0, 0, false)]
        public virtual String DownloadURL
        {
            get { return _DownloadURL; }
            set { if (OnPropertyChanging("DownloadURL", value)) { _DownloadURL = value; OnPropertyChanged("DownloadURL"); } }
        }

        private String _DownloadCode;
        /// <summary>提取码</summary>
        [DisplayName("提取码")]
        [Description("提取码")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(7, "DownloadCode", "提取码", null, "varchar(20)", 0, 0, false)]
        public virtual String DownloadCode
        {
            get { return _DownloadCode; }
            set { if (OnPropertyChanging("DownloadCode", value)) { _DownloadCode = value; OnPropertyChanged("DownloadCode"); } }
        }

        private String _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "UpdateTime", "更新时间", null, "char(10)", 0, 0, false)]
        public virtual String UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "Remark", "备注", null, "char(10)", 0, 0, false)]
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
                    case "ResourceId" : return _ResourceId;
                    case "Name" : return _Name;
                    case "Md5" : return _Md5;
                    case "Website" : return _Website;
                    case "DownloadURL" : return _DownloadURL;
                    case "DownloadCode" : return _DownloadCode;
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
                    case "ResourceId" : _ResourceId = Convert.ToInt32(value); break;
                    case "Name" : _Name = Convert.ToString(value); break;
                    case "Md5" : _Md5 = Convert.ToString(value); break;
                    case "Website" : _Website = Convert.ToString(value); break;
                    case "DownloadURL" : _DownloadURL = Convert.ToString(value); break;
                    case "DownloadCode" : _DownloadCode = Convert.ToString(value); break;
                    case "UpdateTime" : _UpdateTime = Convert.ToString(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得资源网络存储信息字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>资源编号</summary>
            public static readonly Field ResourceId = FindByName("ResourceId");

            ///<summary>资源名称</summary>
            public static readonly Field Name = FindByName("Name");

            ///<summary>Md5值</summary>
            public static readonly Field Md5 = FindByName("Md5");

            ///<summary>网盘名称</summary>
            public static readonly Field Website = FindByName("Website");

            ///<summary>下载地址</summary>
            public static readonly Field DownloadURL = FindByName("DownloadURL");

            ///<summary>提取码</summary>
            public static readonly Field DownloadCode = FindByName("DownloadCode");

            ///<summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName("UpdateTime");

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>资源网络存储信息接口</summary>
    public partial interface Itb_weburlinfo
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>资源编号</summary>
        Int32 ResourceId { get; set; }

        /// <summary>资源名称</summary>
        String Name { get; set; }

        /// <summary>Md5值</summary>
        String Md5 { get; set; }

        /// <summary>网盘名称</summary>
        String Website { get; set; }

        /// <summary>下载地址</summary>
        String DownloadURL { get; set; }

        /// <summary>提取码</summary>
        String DownloadCode { get; set; }

        /// <summary>更新时间</summary>
        String UpdateTime { get; set; }

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