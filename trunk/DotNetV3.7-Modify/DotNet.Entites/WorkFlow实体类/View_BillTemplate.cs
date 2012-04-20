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
    [BindTable("View_BillTemplate", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class View_BillTemplate : IView_BillTemplate
    {
        #region 属性
        private String _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "Id", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _Code;
        /// <summary></summary>
        [DisplayName("Code")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "Code", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } }
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

        private String _CategoryCode;
        /// <summary></summary>
        [DisplayName("CategoryCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "CategoryCode", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(5, "Source", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Source
        {
            get { return _Source; }
            set { if (OnPropertyChanging("Source", value)) { _Source = value; OnPropertyChanged("Source"); } }
        }

        private String _AddPage;
        /// <summary></summary>
        [DisplayName("AddPage")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(6, "AddPage", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(7, "EditPage", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(8, "ShowPage", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(9, "ListPage", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(10, "AdminPage", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String AdminPage
        {
            get { return _AdminPage; }
            set { if (OnPropertyChanging("AdminPage", value)) { _AdminPage = value; OnPropertyChanged("AdminPage"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(11, "Enabled", "", null, "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(12, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(13, "DeletionStateCode", "", null, "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
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
                    case "Code" : return _Code;
                    case "Title" : return _Title;
                    case "CategoryCode" : return _CategoryCode;
                    case "Source" : return _Source;
                    case "AddPage" : return _AddPage;
                    case "EditPage" : return _EditPage;
                    case "ShowPage" : return _ShowPage;
                    case "ListPage" : return _ListPage;
                    case "AdminPage" : return _AdminPage;
                    case "Enabled" : return _Enabled;
                    case "Description" : return _Description;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToString(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "Title" : _Title = Convert.ToString(value); break;
                    case "CategoryCode" : _CategoryCode = Convert.ToString(value); break;
                    case "Source" : _Source = Convert.ToString(value); break;
                    case "AddPage" : _AddPage = Convert.ToString(value); break;
                    case "EditPage" : _EditPage = Convert.ToString(value); break;
                    case "ShowPage" : _ShowPage = Convert.ToString(value); break;
                    case "ListPage" : _ListPage = Convert.ToString(value); break;
                    case "AdminPage" : _AdminPage = Convert.ToString(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
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
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field Title = FindByName("Title");

            ///<summary></summary>
            public static readonly Field CategoryCode = FindByName("CategoryCode");

            ///<summary></summary>
            public static readonly Field Source = FindByName("Source");

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
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IView_BillTemplate
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        String Title { get; set; }

        /// <summary></summary>
        String CategoryCode { get; set; }

        /// <summary></summary>
        String Source { get; set; }

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
        Int32 Enabled { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}