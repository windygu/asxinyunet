﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace ResouceEntity
{
    /// <summary>资源基本信息</summary>
    [Serializable]
    [DataObject]
    [Description("资源基本信息")]
    [BindIndex("IX_ResourceInfo", false, "ResourceName")]
    [BindIndex("IX_ResourceInfo_keywords", false, "Keywords")]
    [BindIndex("PK_ResourceInfo", true, "Id")]
    [BindTable("ResourceInfo", Description = "资源基本信息", ConnName = "ResouceCollector", DbType = DatabaseType.SqlServer)]
    public partial class ResourceInfo : IResourceInfo
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "编号", null, "int", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _BigCategory;
        /// <summary>类别名称</summary>
        [DisplayName("类别名称")]
        [Description("类别名称")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(2, "BigCategory", "类别名称", "未分类", "nvarchar(30)", 0, 0, true)]
        public virtual String BigCategory
        {
            get { return _BigCategory; }
            set { if (OnPropertyChanging("BigCategory", value)) { _BigCategory = value; OnPropertyChanged("BigCategory"); } }
        }

        private String _SmallCategory;
        /// <summary>小类名称</summary>
        [DisplayName("小类名称")]
        [Description("小类名称")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(3, "SmallCategory", "小类名称", "未分类", "nvarchar(30)", 0, 0, true)]
        public virtual String SmallCategory
        {
            get { return _SmallCategory; }
            set { if (OnPropertyChanging("SmallCategory", value)) { _SmallCategory = value; OnPropertyChanged("SmallCategory"); } }
        }

        private String _ResourceName;
        /// <summary>资源名称</summary>
        [DisplayName("资源名称")]
        [Description("资源名称")]
        [DataObjectField(false, false, false, 150)]
        [BindColumn(4, "ResourceName", "资源名称", null, "nvarchar(150)", 0, 0, true)]
        public virtual String ResourceName
        {
            get { return _ResourceName; }
            set { if (OnPropertyChanging("ResourceName", value)) { _ResourceName = value; OnPropertyChanged("ResourceName"); } }
        }

        private String _ContentIntroduce;
        /// <summary>内容介绍</summary>
        [DisplayName("内容介绍")]
        [Description("内容介绍")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(5, "ContentIntroduce", "内容介绍", null, "ntext", 0, 0, true)]
        public virtual String ContentIntroduce
        {
            get { return _ContentIntroduce; }
            set { if (OnPropertyChanging("ContentIntroduce", value)) { _ContentIntroduce = value; OnPropertyChanged("ContentIntroduce"); } }
        }

        private String _Author;
        /// <summary>作者</summary>
        [DisplayName("作者")]
        [Description("作者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "Author", "作者", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Author
        {
            get { return _Author; }
            set { if (OnPropertyChanging("Author", value)) { _Author = value; OnPropertyChanged("Author"); } }
        }

        private String _PublishingCompany;
        /// <summary>出版社</summary>
        [DisplayName("出版社")]
        [Description("出版社")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "PublishingCompany", "出版社", null, "nvarchar(50)", 0, 0, true)]
        public virtual String PublishingCompany
        {
            get { return _PublishingCompany; }
            set { if (OnPropertyChanging("PublishingCompany", value)) { _PublishingCompany = value; OnPropertyChanged("PublishingCompany"); } }
        }

        private Int64 _Size;
        /// <summary>资源大小</summary>
        [DisplayName("资源大小")]
        [Description("资源大小")]
        [DataObjectField(false, false, false, 19)]
        [BindColumn(8, "Size", "资源大小", "1", "bigint", 19, 0, false)]
        public virtual Int64 Size
        {
            get { return _Size; }
            set { if (OnPropertyChanging("Size", value)) { _Size = value; OnPropertyChanged("Size"); } }
        }

        private String _Format;
        /// <summary>资源格式</summary>
        [DisplayName("资源格式")]
        [Description("资源格式")]
        [DataObjectField(false, false, false, 15)]
        [BindColumn(9, "Format", "资源格式", null, "nvarchar(15)", 0, 0, true)]
        public virtual String Format
        {
            get { return _Format; }
            set { if (OnPropertyChanging("Format", value)) { _Format = value; OnPropertyChanged("Format"); } }
        }

        private String _Keywords;
        /// <summary>关键词</summary>
        [DisplayName("关键词")]
        [Description("关键词")]
        [DataObjectField(false, false, true, 80)]
        [BindColumn(10, "Keywords", "关键词", null, "nvarchar(80)", 0, 0, true)]
        public virtual String Keywords
        {
            get { return _Keywords; }
            set { if (OnPropertyChanging("Keywords", value)) { _Keywords = value; OnPropertyChanged("Keywords"); } }
        }

        private String _Md5;
        /// <summary>MD5值</summary>
        [DisplayName("MD5值")]
        [Description("MD5值")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "Md5", "MD5值", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Md5
        {
            get { return _Md5; }
            set { if (OnPropertyChanging("Md5", value)) { _Md5 = value; OnPropertyChanged("Md5"); } }
        }

        private String _ISBN;
        /// <summary>ISBN号</summary>
        [DisplayName("ISBN号")]
        [Description("ISBN号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "ISBN", "ISBN号", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ISBN
        {
            get { return _ISBN; }
            set { if (OnPropertyChanging("ISBN", value)) { _ISBN = value; OnPropertyChanged("ISBN"); } }
        }

        private DateTime _PublishingDate;
        /// <summary>出版时间</summary>
        [DisplayName("出版时间")]
        [Description("出版时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "PublishingDate", "出版时间", "(2010)-(1))-(1", "datetime", 3, 0, false)]
        public virtual DateTime PublishingDate
        {
            get { return _PublishingDate; }
            set { if (OnPropertyChanging("PublishingDate", value)) { _PublishingDate = value; OnPropertyChanged("PublishingDate"); } }
        }

        private String _Source;
        /// <summary>来源地</summary>
        [DisplayName("来源地")]
        [Description("来源地")]
        [DataObjectField(false, false, true, 150)]
        [BindColumn(14, "Source", "来源地", null, "nvarchar(150)", 0, 0, true)]
        public virtual String Source
        {
            get { return _Source; }
            set { if (OnPropertyChanging("Source", value)) { _Source = value; OnPropertyChanged("Source"); } }
        }

        private Int32 _ResourceScore;
        /// <summary>资源评分</summary>
        [DisplayName("资源评分")]
        [Description("资源评分")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "ResourceScore", "资源评分", "7", "int", 10, 0, false)]
        public virtual Int32 ResourceScore
        {
            get { return _ResourceScore; }
            set { if (OnPropertyChanging("ResourceScore", value)) { _ResourceScore = value; OnPropertyChanged("ResourceScore"); } }
        }

        private String _StorageLocation;
        /// <summary>存储位置</summary>
        [DisplayName("存储位置")]
        [Description("存储位置")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(16, "StorageLocation", "存储位置", null, "ntext", 0, 0, true)]
        public virtual String StorageLocation
        {
            get { return _StorageLocation; }
            set { if (OnPropertyChanging("StorageLocation", value)) { _StorageLocation = value; OnPropertyChanged("StorageLocation"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(17, "Remark", "备注", null, "ntext", 0, 0, true)]
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
                    case "BigCategory" : return _BigCategory;
                    case "SmallCategory" : return _SmallCategory;
                    case "ResourceName" : return _ResourceName;
                    case "ContentIntroduce" : return _ContentIntroduce;
                    case "Author" : return _Author;
                    case "PublishingCompany" : return _PublishingCompany;
                    case "Size" : return _Size;
                    case "Format" : return _Format;
                    case "Keywords" : return _Keywords;
                    case "Md5" : return _Md5;
                    case "ISBN" : return _ISBN;
                    case "PublishingDate" : return _PublishingDate;
                    case "Source" : return _Source;
                    case "ResourceScore" : return _ResourceScore;
                    case "StorageLocation" : return _StorageLocation;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "BigCategory" : _BigCategory = Convert.ToString(value); break;
                    case "SmallCategory" : _SmallCategory = Convert.ToString(value); break;
                    case "ResourceName" : _ResourceName = Convert.ToString(value); break;
                    case "ContentIntroduce" : _ContentIntroduce = Convert.ToString(value); break;
                    case "Author" : _Author = Convert.ToString(value); break;
                    case "PublishingCompany" : _PublishingCompany = Convert.ToString(value); break;
                    case "Size" : _Size = Convert.ToInt64(value); break;
                    case "Format" : _Format = Convert.ToString(value); break;
                    case "Keywords" : _Keywords = Convert.ToString(value); break;
                    case "Md5" : _Md5 = Convert.ToString(value); break;
                    case "ISBN" : _ISBN = Convert.ToString(value); break;
                    case "PublishingDate" : _PublishingDate = Convert.ToDateTime(value); break;
                    case "Source" : _Source = Convert.ToString(value); break;
                    case "ResourceScore" : _ResourceScore = Convert.ToInt32(value); break;
                    case "StorageLocation" : _StorageLocation = Convert.ToString(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得资源基本信息字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>类别名称</summary>
            public static readonly Field BigCategory = FindByName("BigCategory");

            ///<summary>小类名称</summary>
            public static readonly Field SmallCategory = FindByName("SmallCategory");

            ///<summary>资源名称</summary>
            public static readonly Field ResourceName = FindByName("ResourceName");

            ///<summary>内容介绍</summary>
            public static readonly Field ContentIntroduce = FindByName("ContentIntroduce");

            ///<summary>作者</summary>
            public static readonly Field Author = FindByName("Author");

            ///<summary>出版社</summary>
            public static readonly Field PublishingCompany = FindByName("PublishingCompany");

            ///<summary>资源大小</summary>
            public static readonly Field Size = FindByName("Size");

            ///<summary>资源格式</summary>
            public static readonly Field Format = FindByName("Format");

            ///<summary>关键词</summary>
            public static readonly Field Keywords = FindByName("Keywords");

            ///<summary>MD5值</summary>
            public static readonly Field Md5 = FindByName("Md5");

            ///<summary>ISBN号</summary>
            public static readonly Field ISBN = FindByName("ISBN");

            ///<summary>出版时间</summary>
            public static readonly Field PublishingDate = FindByName("PublishingDate");

            ///<summary>来源地</summary>
            public static readonly Field Source = FindByName("Source");

            ///<summary>资源评分</summary>
            public static readonly Field ResourceScore = FindByName("ResourceScore");

            ///<summary>存储位置</summary>
            public static readonly Field StorageLocation = FindByName("StorageLocation");

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>资源基本信息接口</summary>
    public partial interface IResourceInfo
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>类别名称</summary>
        String BigCategory { get; set; }

        /// <summary>小类名称</summary>
        String SmallCategory { get; set; }

        /// <summary>资源名称</summary>
        String ResourceName { get; set; }

        /// <summary>内容介绍</summary>
        String ContentIntroduce { get; set; }

        /// <summary>作者</summary>
        String Author { get; set; }

        /// <summary>出版社</summary>
        String PublishingCompany { get; set; }

        /// <summary>资源大小</summary>
        Int64 Size { get; set; }

        /// <summary>资源格式</summary>
        String Format { get; set; }

        /// <summary>关键词</summary>
        String Keywords { get; set; }

        /// <summary>MD5值</summary>
        String Md5 { get; set; }

        /// <summary>ISBN号</summary>
        String ISBN { get; set; }

        /// <summary>出版时间</summary>
        DateTime PublishingDate { get; set; }

        /// <summary>来源地</summary>
        String Source { get; set; }

        /// <summary>资源评分</summary>
        Int32 ResourceScore { get; set; }

        /// <summary>存储位置</summary>
        String StorageLocation { get; set; }

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