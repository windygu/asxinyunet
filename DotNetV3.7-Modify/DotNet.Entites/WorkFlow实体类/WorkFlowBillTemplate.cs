/*
 * XCoder v4.7.4486.37599
 * 作者：Administrator/WIN-7ZX6E2GYT38
 * 时间：2012-04-20 09:19:21
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.Entites.WorkFlow
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_BillTemplate", true, "Id")]
    [BindTable("WorkFlowBillTemplate", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class WorkFlowBillTemplate : IWorkFlowBillTemplate
    {
        #region 属性
        private String _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "Id", "", "newid()", "nvarchar(50)", 0, 0, true)]
        public virtual String Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _FolderId;
        /// <summary></summary>
        [DisplayName("FolderId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "FolderId", "", "WorkFlowBill", "nvarchar(50)", 0, 0, true)]
        public virtual String FolderId
        {
            get { return _FolderId; }
            set { if (OnPropertyChanging("FolderId", value)) { _FolderId = value; OnPropertyChanged("FolderId"); } }
        }

        private String _Title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(3, "Title", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging("Title", value)) { _Title = value; OnPropertyChanged("Title"); } }
        }

        private String _Code;
        /// <summary></summary>
        [DisplayName("Code")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Code", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } }
        }

        private String _FilePath;
        /// <summary></summary>
        [DisplayName("FilePath")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(5, "FilePath", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String FilePath
        {
            get { return _FilePath; }
            set { if (OnPropertyChanging("FilePath", value)) { _FilePath = value; OnPropertyChanged("FilePath"); } }
        }

        private String _CategoryCode;
        /// <summary></summary>
        [DisplayName("CategoryCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "CategoryCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CategoryCode
        {
            get { return _CategoryCode; }
            set { if (OnPropertyChanging("CategoryCode", value)) { _CategoryCode = value; OnPropertyChanged("CategoryCode"); } }
        }

        private String _Source;
        /// <summary></summary>
        [DisplayName("Source")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(7, "Source", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Source
        {
            get { return _Source; }
            set { if (OnPropertyChanging("Source", value)) { _Source = value; OnPropertyChanged("Source"); } }
        }

        private String _Introduction;
        /// <summary></summary>
        [DisplayName("Introduction")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(8, "Introduction", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Introduction
        {
            get { return _Introduction; }
            set { if (OnPropertyChanging("Introduction", value)) { _Introduction = value; OnPropertyChanged("Introduction"); } }
        }

        private String _Keywords;
        /// <summary></summary>
        [DisplayName("Keywords")]
        [Description("")]
        [DataObjectField(false, false, true, 500)]
        [BindColumn(9, "Keywords", "", null, "nvarchar(500)", 0, 0, true)]
        public virtual String Keywords
        {
            get { return _Keywords; }
            set { if (OnPropertyChanging("Keywords", value)) { _Keywords = value; OnPropertyChanged("Keywords"); } }
        }

        private String _Contents;
        /// <summary></summary>
        [DisplayName("Contents")]
        [Description("")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(10, "Contents", "", null, "text", 0, 0, false)]
        public virtual String Contents
        {
            get { return _Contents; }
            set { if (OnPropertyChanging("Contents", value)) { _Contents = value; OnPropertyChanged("Contents"); } }
        }

        private Int32 _ReadCount;
        /// <summary></summary>
        [DisplayName("ReadCount")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "ReadCount", "", "0", "int", 10, 0, false)]
        public virtual Int32 ReadCount
        {
            get { return _ReadCount; }
            set { if (OnPropertyChanging("ReadCount", value)) { _ReadCount = value; OnPropertyChanged("ReadCount"); } }
        }

        private Int32 _FileSize;
        /// <summary></summary>
        [DisplayName("FileSize")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(12, "FileSize", "", "0", "int", 10, 0, false)]
        public virtual Int32 FileSize
        {
            get { return _FileSize; }
            set { if (OnPropertyChanging("FileSize", value)) { _FileSize = value; OnPropertyChanged("FileSize"); } }
        }

        private String _ImageUrl;
        /// <summary></summary>
        [DisplayName("ImageUrl")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(13, "ImageUrl", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String ImageUrl
        {
            get { return _ImageUrl; }
            set { if (OnPropertyChanging("ImageUrl", value)) { _ImageUrl = value; OnPropertyChanged("ImageUrl"); } }
        }

        private Int32 _HomePage;
        /// <summary></summary>
        [DisplayName("HomePage")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(14, "HomePage", "", null, "int", 10, 0, false)]
        public virtual Int32 HomePage
        {
            get { return _HomePage; }
            set { if (OnPropertyChanging("HomePage", value)) { _HomePage = value; OnPropertyChanged("HomePage"); } }
        }

        private Int32 _SubPage;
        /// <summary></summary>
        [DisplayName("SubPage")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "SubPage", "", null, "int", 10, 0, false)]
        public virtual Int32 SubPage
        {
            get { return _SubPage; }
            set { if (OnPropertyChanging("SubPage", value)) { _SubPage = value; OnPropertyChanged("SubPage"); } }
        }

        private String _AddPage;
        /// <summary></summary>
        [DisplayName("AddPage")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(16, "AddPage", "", "../HtmlBill/HtmlBillEdit.aspx?TemplateId={Id}", "nvarchar(200)", 0, 0, true)]
        public virtual String AddPage
        {
            get { return _AddPage; }
            set { if (OnPropertyChanging("AddPage", value)) { _AddPage = value; OnPropertyChanged("AddPage"); } }
        }

        private String _EditPage;
        /// <summary></summary>
        [DisplayName("EditPage")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(17, "EditPage", "", "HtmlBill/HtmlBillEdit.aspx?Id={Id}", "nvarchar(200)", 0, 0, true)]
        public virtual String EditPage
        {
            get { return _EditPage; }
            set { if (OnPropertyChanging("EditPage", value)) { _EditPage = value; OnPropertyChanged("EditPage"); } }
        }

        private String _ShowPage;
        /// <summary></summary>
        [DisplayName("ShowPage")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(18, "ShowPage", "", "HtmlBill/HtmlBillShow.aspx?Id={Id}", "nvarchar(200)", 0, 0, true)]
        public virtual String ShowPage
        {
            get { return _ShowPage; }
            set { if (OnPropertyChanging("ShowPage", value)) { _ShowPage = value; OnPropertyChanged("ShowPage"); } }
        }

        private String _ListPage;
        /// <summary></summary>
        [DisplayName("ListPage")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(19, "ListPage", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String ListPage
        {
            get { return _ListPage; }
            set { if (OnPropertyChanging("ListPage", value)) { _ListPage = value; OnPropertyChanged("ListPage"); } }
        }

        private String _AdminPage;
        /// <summary></summary>
        [DisplayName("AdminPage")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(20, "AdminPage", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String AdminPage
        {
            get { return _AdminPage; }
            set { if (OnPropertyChanging("AdminPage", value)) { _AdminPage = value; OnPropertyChanged("AdminPage"); } }
        }

        private String _AuditStatus;
        /// <summary></summary>
        [DisplayName("AuditStatus")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(21, "AuditStatus", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String AuditStatus
        {
            get { return _AuditStatus; }
            set { if (OnPropertyChanging("AuditStatus", value)) { _AuditStatus = value; OnPropertyChanged("AuditStatus"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(22, "Enabled", "", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(23, "SortCode", "", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(24, "Description", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(25, "DeletionStateCode", "", "0", "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private DateTime _CreateOn;
        /// <summary></summary>
        [DisplayName("CreateOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(26, "CreateOn", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }

        private String _CreateUserId;
        /// <summary></summary>
        [DisplayName("CreateUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(27, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String CreateUserId
        {
            get { return _CreateUserId; }
            set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } }
        }

        private String _CreateBy;
        /// <summary></summary>
        [DisplayName("CreateBy")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(28, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String CreateBy
        {
            get { return _CreateBy; }
            set { if (OnPropertyChanging("CreateBy", value)) { _CreateBy = value; OnPropertyChanged("CreateBy"); } }
        }

        private DateTime _ModifiedOn;
        /// <summary></summary>
        [DisplayName("ModifiedOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(29, "ModifiedOn", "", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging("ModifiedOn", value)) { _ModifiedOn = value; OnPropertyChanged("ModifiedOn"); } }
        }

        private String _ModifiedUserId;
        /// <summary></summary>
        [DisplayName("ModifiedUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(30, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String ModifiedUserId
        {
            get { return _ModifiedUserId; }
            set { if (OnPropertyChanging("ModifiedUserId", value)) { _ModifiedUserId = value; OnPropertyChanged("ModifiedUserId"); } }
        }

        private String _ModifiedBy;
        /// <summary></summary>
        [DisplayName("ModifiedBy")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(31, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String ModifiedBy
        {
            get { return _ModifiedBy; }
            set { if (OnPropertyChanging("ModifiedBy", value)) { _ModifiedBy = value; OnPropertyChanged("ModifiedBy"); } }
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
                    case "FolderId" : return _FolderId;
                    case "Title" : return _Title;
                    case "Code" : return _Code;
                    case "FilePath" : return _FilePath;
                    case "CategoryCode" : return _CategoryCode;
                    case "Source" : return _Source;
                    case "Introduction" : return _Introduction;
                    case "Keywords" : return _Keywords;
                    case "Contents" : return _Contents;
                    case "ReadCount" : return _ReadCount;
                    case "FileSize" : return _FileSize;
                    case "ImageUrl" : return _ImageUrl;
                    case "HomePage" : return _HomePage;
                    case "SubPage" : return _SubPage;
                    case "AddPage" : return _AddPage;
                    case "EditPage" : return _EditPage;
                    case "ShowPage" : return _ShowPage;
                    case "ListPage" : return _ListPage;
                    case "AdminPage" : return _AdminPage;
                    case "AuditStatus" : return _AuditStatus;
                    case "Enabled" : return _Enabled;
                    case "SortCode" : return _SortCode;
                    case "Description" : return _Description;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "CreateOn" : return _CreateOn;
                    case "CreateUserId" : return _CreateUserId;
                    case "CreateBy" : return _CreateBy;
                    case "ModifiedOn" : return _ModifiedOn;
                    case "ModifiedUserId" : return _ModifiedUserId;
                    case "ModifiedBy" : return _ModifiedBy;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToString(value); break;
                    case "FolderId" : _FolderId = Convert.ToString(value); break;
                    case "Title" : _Title = Convert.ToString(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "FilePath" : _FilePath = Convert.ToString(value); break;
                    case "CategoryCode" : _CategoryCode = Convert.ToString(value); break;
                    case "Source" : _Source = Convert.ToString(value); break;
                    case "Introduction" : _Introduction = Convert.ToString(value); break;
                    case "Keywords" : _Keywords = Convert.ToString(value); break;
                    case "Contents" : _Contents = Convert.ToString(value); break;
                    case "ReadCount" : _ReadCount = Convert.ToInt32(value); break;
                    case "FileSize" : _FileSize = Convert.ToInt32(value); break;
                    case "ImageUrl" : _ImageUrl = Convert.ToString(value); break;
                    case "HomePage" : _HomePage = Convert.ToInt32(value); break;
                    case "SubPage" : _SubPage = Convert.ToInt32(value); break;
                    case "AddPage" : _AddPage = Convert.ToString(value); break;
                    case "EditPage" : _EditPage = Convert.ToString(value); break;
                    case "ShowPage" : _ShowPage = Convert.ToString(value); break;
                    case "ListPage" : _ListPage = Convert.ToString(value); break;
                    case "AdminPage" : _AdminPage = Convert.ToString(value); break;
                    case "AuditStatus" : _AuditStatus = Convert.ToString(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "CreateOn" : _CreateOn = Convert.ToDateTime(value); break;
                    case "CreateUserId" : _CreateUserId = Convert.ToString(value); break;
                    case "CreateBy" : _CreateBy = Convert.ToString(value); break;
                    case "ModifiedOn" : _ModifiedOn = Convert.ToDateTime(value); break;
                    case "ModifiedUserId" : _ModifiedUserId = Convert.ToString(value); break;
                    case "ModifiedBy" : _ModifiedBy = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary></summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary></summary>
            public static readonly Field FolderId = FindByName("FolderId");

            ///<summary></summary>
            public static readonly Field Title = FindByName("Title");

            ///<summary></summary>
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field FilePath = FindByName("FilePath");

            ///<summary></summary>
            public static readonly Field CategoryCode = FindByName("CategoryCode");

            ///<summary></summary>
            public static readonly Field Source = FindByName("Source");

            ///<summary></summary>
            public static readonly Field Introduction = FindByName("Introduction");

            ///<summary></summary>
            public static readonly Field Keywords = FindByName("Keywords");

            ///<summary></summary>
            public static readonly Field Contents = FindByName("Contents");

            ///<summary></summary>
            public static readonly Field ReadCount = FindByName("ReadCount");

            ///<summary></summary>
            public static readonly Field FileSize = FindByName("FileSize");

            ///<summary></summary>
            public static readonly Field ImageUrl = FindByName("ImageUrl");

            ///<summary></summary>
            public static readonly Field HomePage = FindByName("HomePage");

            ///<summary></summary>
            public static readonly Field SubPage = FindByName("SubPage");

            ///<summary></summary>
            public static readonly Field AddPage = FindByName("AddPage");

            ///<summary></summary>
            public static readonly Field EditPage = FindByName("EditPage");

            ///<summary></summary>
            public static readonly Field ShowPage = FindByName("ShowPage");

            ///<summary></summary>
            public static readonly Field ListPage = FindByName("ListPage");

            ///<summary></summary>
            public static readonly Field AdminPage = FindByName("AdminPage");

            ///<summary></summary>
            public static readonly Field AuditStatus = FindByName("AuditStatus");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field CreateOn = FindByName("CreateOn");

            ///<summary></summary>
            public static readonly Field CreateUserId = FindByName("CreateUserId");

            ///<summary></summary>
            public static readonly Field CreateBy = FindByName("CreateBy");

            ///<summary></summary>
            public static readonly Field ModifiedOn = FindByName("ModifiedOn");

            ///<summary></summary>
            public static readonly Field ModifiedUserId = FindByName("ModifiedUserId");

            ///<summary></summary>
            public static readonly Field ModifiedBy = FindByName("ModifiedBy");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IWorkFlowBillTemplate
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String FolderId { get; set; }

        /// <summary></summary>
        String Title { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        String FilePath { get; set; }

        /// <summary></summary>
        String CategoryCode { get; set; }

        /// <summary></summary>
        String Source { get; set; }

        /// <summary></summary>
        String Introduction { get; set; }

        /// <summary></summary>
        String Keywords { get; set; }

        /// <summary></summary>
        String Contents { get; set; }

        /// <summary></summary>
        Int32 ReadCount { get; set; }

        /// <summary></summary>
        Int32 FileSize { get; set; }

        /// <summary></summary>
        String ImageUrl { get; set; }

        /// <summary></summary>
        Int32 HomePage { get; set; }

        /// <summary></summary>
        Int32 SubPage { get; set; }

        /// <summary></summary>
        String AddPage { get; set; }

        /// <summary></summary>
        String EditPage { get; set; }

        /// <summary></summary>
        String ShowPage { get; set; }

        /// <summary></summary>
        String ListPage { get; set; }

        /// <summary></summary>
        String AdminPage { get; set; }

        /// <summary></summary>
        String AuditStatus { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        DateTime CreateOn { get; set; }

        /// <summary></summary>
        String CreateUserId { get; set; }

        /// <summary></summary>
        String CreateBy { get; set; }

        /// <summary></summary>
        DateTime ModifiedOn { get; set; }

        /// <summary></summary>
        String ModifiedUserId { get; set; }

        /// <summary></summary>
        String ModifiedBy { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}