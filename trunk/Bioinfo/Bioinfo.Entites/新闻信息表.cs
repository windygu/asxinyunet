﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Bioinfo.Entites
{
    /// <summary>新闻信息表</summary>
    [Serializable]
    [DataObject]
    [Description("新闻信息表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindTable("News", Description = "新闻信息表", ConnName = "Common", DbType = DatabaseType.MySql)]
    public partial class News : INews
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

        private Int32 _TypeId;
        /// <summary>新闻类别编号</summary>
        [DisplayName("新闻类别编号")]
        [Description("新闻类别编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "TypeId", "新闻类别编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 TypeId
        {
            get { return _TypeId; }
            set { if (OnPropertyChanging("TypeId", value)) { _TypeId = value; OnPropertyChanged("TypeId"); } }
        }

        private String _Title;
        /// <summary>新闻标题</summary>
        [DisplayName("新闻标题")]
        [Description("新闻标题")]
        [DataObjectField(false, false, false, 100)]
        [BindColumn(3, "Title", "新闻标题", null, "varchar(100)", 0, 0, false)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging("Title", value)) { _Title = value; OnPropertyChanged("Title"); } }
        }

        private String _Author;
        /// <summary>作者</summary>
        [DisplayName("作者")]
        [Description("作者")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(4, "Author", "作者", "管理员", "varchar(20)", 0, 0, false)]
        public virtual String Author
        {
            get { return _Author; }
            set { if (OnPropertyChanging("Author", value)) { _Author = value; OnPropertyChanged("Author"); } }
        }

        private String _Origin;
        /// <summary>来源</summary>
        [DisplayName("来源")]
        [Description("来源")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "Origin", "来源", "原创", "varchar(50)", 0, 0, false)]
        public virtual String Origin
        {
            get { return _Origin; }
            set { if (OnPropertyChanging("Origin", value)) { _Origin = value; OnPropertyChanged("Origin"); } }
        }

        private String _KeyWords;
        /// <summary>关键字</summary>
        [DisplayName("关键字")]
        [Description("关键字")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "KeyWords", "关键字", null, "varchar(50)", 0, 0, false)]
        public virtual String KeyWords
        {
            get { return _KeyWords; }
            set { if (OnPropertyChanging("KeyWords", value)) { _KeyWords = value; OnPropertyChanged("KeyWords"); } }
        }

        private String _Review;
        /// <summary>导读</summary>
        [DisplayName("导读")]
        [Description("导读")]
        [DataObjectField(false, false, true, 65535)]
        [BindColumn(7, "Review", "导读", null, "text", 0, 0, false)]
        public virtual String Review
        {
            get { return _Review; }
            set { if (OnPropertyChanging("Review", value)) { _Review = value; OnPropertyChanged("Review"); } }
        }

        private String _Content;
        /// <summary>内容</summary>
        [DisplayName("内容")]
        [Description("内容")]
        [DataObjectField(false, false, true, 65535)]
        [BindColumn(8, "Content", "内容", null, "text", 0, 0, false)]
        public virtual String Content
        {
            get { return _Content; }
            set { if (OnPropertyChanging("Content", value)) { _Content = value; OnPropertyChanged("Content"); } }
        }

        private Int32 _Hits;
        /// <summary>点击数</summary>
        [DisplayName("点击数")]
        [Description("点击数")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(9, "Hits", "点击数", "0", "int(11)", 10, 0, false)]
        public virtual Int32 Hits
        {
            get { return _Hits; }
            set { if (OnPropertyChanging("Hits", value)) { _Hits = value; OnPropertyChanged("Hits"); } }
        }

        private String _Status;
        /// <summary>文章状态</summary>
        [DisplayName("文章状态")]
        [Description("文章状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "Status", "文章状态", null, "varchar(10)", 0, 0, false)]
        public virtual String Status
        {
            get { return _Status; }
            set { if (OnPropertyChanging("Status", value)) { _Status = value; OnPropertyChanged("Status"); } }
        }

        private Int32 _CodeType;
        /// <summary>编码类别</summary>
        [DisplayName("编码类别")]
        [Description("编码类别")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "CodeType", "编码类别", "1", "int(11)", 10, 0, false)]
        public virtual Int32 CodeType
        {
            get { return _CodeType; }
            set { if (OnPropertyChanging("CodeType", value)) { _CodeType = value; OnPropertyChanged("CodeType"); } }
        }

        private DateTime _AddDateTime;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn(12, "AddDateTime", "添加时间", null, "datetime", 0, 0, false)]
        public virtual DateTime AddDateTime
        {
            get { return _AddDateTime; }
            set { if (OnPropertyChanging("AddDateTime", value)) { _AddDateTime = value; OnPropertyChanged("AddDateTime"); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(13, "Remark", "备注", null, "varchar(100)", 0, 0, false)]
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
                    case "TypeId" : return _TypeId;
                    case "Title" : return _Title;
                    case "Author" : return _Author;
                    case "Origin" : return _Origin;
                    case "KeyWords" : return _KeyWords;
                    case "Review" : return _Review;
                    case "Content" : return _Content;
                    case "Hits" : return _Hits;
                    case "Status" : return _Status;
                    case "CodeType" : return _CodeType;
                    case "AddDateTime" : return _AddDateTime;
                    case "Remark" : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "TypeId" : _TypeId = Convert.ToInt32(value); break;
                    case "Title" : _Title = Convert.ToString(value); break;
                    case "Author" : _Author = Convert.ToString(value); break;
                    case "Origin" : _Origin = Convert.ToString(value); break;
                    case "KeyWords" : _KeyWords = Convert.ToString(value); break;
                    case "Review" : _Review = Convert.ToString(value); break;
                    case "Content" : _Content = Convert.ToString(value); break;
                    case "Hits" : _Hits = Convert.ToInt32(value); break;
                    case "Status" : _Status = Convert.ToString(value); break;
                    case "CodeType" : _CodeType = Convert.ToInt32(value); break;
                    case "AddDateTime" : _AddDateTime = Convert.ToDateTime(value); break;
                    case "Remark" : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得新闻信息表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>新闻类别编号</summary>
            public static readonly Field TypeId = FindByName("TypeId");

            ///<summary>新闻标题</summary>
            public static readonly Field Title = FindByName("Title");

            ///<summary>作者</summary>
            public static readonly Field Author = FindByName("Author");

            ///<summary>来源</summary>
            public static readonly Field Origin = FindByName("Origin");

            ///<summary>关键字</summary>
            public static readonly Field KeyWords = FindByName("KeyWords");

            ///<summary>导读</summary>
            public static readonly Field Review = FindByName("Review");

            ///<summary>内容</summary>
            public static readonly Field Content = FindByName("Content");

            ///<summary>点击数</summary>
            public static readonly Field Hits = FindByName("Hits");

            ///<summary>文章状态</summary>
            public static readonly Field Status = FindByName("Status");

            ///<summary>编码类别</summary>
            public static readonly Field CodeType = FindByName("CodeType");

            ///<summary>添加时间</summary>
            public static readonly Field AddDateTime = FindByName("AddDateTime");

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName("Remark");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>新闻信息表接口</summary>
    public partial interface INews
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>新闻类别编号</summary>
        Int32 TypeId { get; set; }

        /// <summary>新闻标题</summary>
        String Title { get; set; }

        /// <summary>作者</summary>
        String Author { get; set; }

        /// <summary>来源</summary>
        String Origin { get; set; }

        /// <summary>关键字</summary>
        String KeyWords { get; set; }

        /// <summary>导读</summary>
        String Review { get; set; }

        /// <summary>内容</summary>
        String Content { get; set; }

        /// <summary>点击数</summary>
        Int32 Hits { get; set; }

        /// <summary>文章状态</summary>
        String Status { get; set; }

        /// <summary>编码类别</summary>
        Int32 CodeType { get; set; }

        /// <summary>添加时间</summary>
        DateTime AddDateTime { get; set; }

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