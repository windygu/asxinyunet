/*
 * XCoder v4.7.4486.37599
 * 作者：Administrator/WIN-7ZX6E2GYT38
 * 时间：2012-04-20 08:38:02
 * 版权：版权所有 (C) 新生命开发团队 2012
*/
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.Entites
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_Base_Contact", true, "Id")]
    [BindTable("BaseContact", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseContact : IBaseContact
    {
        #region 属性
        private String _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, false, false, 40)]
        [BindColumn(1, "Id", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private String _ParentId;
        /// <summary></summary>
        [DisplayName("ParentId")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(2, "ParentId", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String ParentId
        {
            get { return _ParentId; }
            set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } }
        }

        private String _Title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(3, "Title", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging("Title", value)) { _Title = value; OnPropertyChanged("Title"); } }
        }

        private String _Content;
        /// <summary></summary>
        [DisplayName("Content")]
        [Description("")]
        [DataObjectField(false, false, true, 400)]
        [BindColumn(4, "Content", "", null, "nvarchar(400)", 0, 0, true)]
        public virtual String Content
        {
            get { return _Content; }
            set { if (OnPropertyChanging("Content", value)) { _Content = value; OnPropertyChanged("Content"); } }
        }

        private String _Priority;
        /// <summary></summary>
        [DisplayName("Priority")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(5, "Priority", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Priority
        {
            get { return _Priority; }
            set { if (OnPropertyChanging("Priority", value)) { _Priority = value; OnPropertyChanged("Priority"); } }
        }

        private Int32 _SendCount;
        /// <summary></summary>
        [DisplayName("SendCount")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "SendCount", "", "0", "int", 10, 0, false)]
        public virtual Int32 SendCount
        {
            get { return _SendCount; }
            set { if (OnPropertyChanging("SendCount", value)) { _SendCount = value; OnPropertyChanged("SendCount"); } }
        }

        private Int32 _ReadCount;
        /// <summary></summary>
        [DisplayName("ReadCount")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "ReadCount", "", "0", "int", 10, 0, false)]
        public virtual Int32 ReadCount
        {
            get { return _ReadCount; }
            set { if (OnPropertyChanging("ReadCount", value)) { _ReadCount = value; OnPropertyChanged("ReadCount"); } }
        }

        private Int32 _IsOpen;
        /// <summary></summary>
        [DisplayName("IsOpen")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "IsOpen", "", null, "int", 10, 0, false)]
        public virtual Int32 IsOpen
        {
            get { return _IsOpen; }
            set { if (OnPropertyChanging("IsOpen", value)) { _IsOpen = value; OnPropertyChanged("IsOpen"); } }
        }

        private String _CommentUserID;
        /// <summary></summary>
        [DisplayName("CommentUserID")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(9, "CommentUserID", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String CommentUserID
        {
            get { return _CommentUserID; }
            set { if (OnPropertyChanging("CommentUserID", value)) { _CommentUserID = value; OnPropertyChanged("CommentUserID"); } }
        }

        private String _CommentUserRealName;
        /// <summary></summary>
        [DisplayName("CommentUserRealName")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(10, "CommentUserRealName", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String CommentUserRealName
        {
            get { return _CommentUserRealName; }
            set { if (OnPropertyChanging("CommentUserRealName", value)) { _CommentUserRealName = value; OnPropertyChanged("CommentUserRealName"); } }
        }

        private DateTime _CommentDate;
        /// <summary></summary>
        [DisplayName("CommentDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(11, "CommentDate", "", null, "datetime", 3, 0, false)]
        public virtual DateTime CommentDate
        {
            get { return _CommentDate; }
            set { if (OnPropertyChanging("CommentDate", value)) { _CommentDate = value; OnPropertyChanged("CommentDate"); } }
        }

        private Boolean _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(12, "DeletionStateCode", "", "0", "bit", 0, 0, false)]
        public virtual Boolean DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private Boolean _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(13, "Enabled", "", "0", "bit", 0, 0, false)]
        public virtual Boolean Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(14, "Description", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "SortCode", "", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private DateTime _CreateOn;
        /// <summary></summary>
        [DisplayName("CreateOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(16, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(17, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(18, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(19, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(20, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(21, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "ParentId" : return _ParentId;
                    case "Title" : return _Title;
                    case "Content" : return _Content;
                    case "Priority" : return _Priority;
                    case "SendCount" : return _SendCount;
                    case "ReadCount" : return _ReadCount;
                    case "IsOpen" : return _IsOpen;
                    case "CommentUserID" : return _CommentUserID;
                    case "CommentUserRealName" : return _CommentUserRealName;
                    case "CommentDate" : return _CommentDate;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "Enabled" : return _Enabled;
                    case "Description" : return _Description;
                    case "SortCode" : return _SortCode;
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
                    case "ParentId" : _ParentId = Convert.ToString(value); break;
                    case "Title" : _Title = Convert.ToString(value); break;
                    case "Content" : _Content = Convert.ToString(value); break;
                    case "Priority" : _Priority = Convert.ToString(value); break;
                    case "SendCount" : _SendCount = Convert.ToInt32(value); break;
                    case "ReadCount" : _ReadCount = Convert.ToInt32(value); break;
                    case "IsOpen" : _IsOpen = Convert.ToInt32(value); break;
                    case "CommentUserID" : _CommentUserID = Convert.ToString(value); break;
                    case "CommentUserRealName" : _CommentUserRealName = Convert.ToString(value); break;
                    case "CommentDate" : _CommentDate = Convert.ToDateTime(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToBoolean(value); break;
                    case "Enabled" : _Enabled = Convert.ToBoolean(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
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
            public static readonly Field ParentId = FindByName("ParentId");

            ///<summary></summary>
            public static readonly Field Title = FindByName("Title");

            ///<summary></summary>
            public static readonly Field Content = FindByName("Content");

            ///<summary></summary>
            public static readonly Field Priority = FindByName("Priority");

            ///<summary></summary>
            public static readonly Field SendCount = FindByName("SendCount");

            ///<summary></summary>
            public static readonly Field ReadCount = FindByName("ReadCount");

            ///<summary></summary>
            public static readonly Field IsOpen = FindByName("IsOpen");

            ///<summary></summary>
            public static readonly Field CommentUserID = FindByName("CommentUserID");

            ///<summary></summary>
            public static readonly Field CommentUserRealName = FindByName("CommentUserRealName");

            ///<summary></summary>
            public static readonly Field CommentDate = FindByName("CommentDate");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

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
    public partial interface IBaseContact
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String ParentId { get; set; }

        /// <summary></summary>
        String Title { get; set; }

        /// <summary></summary>
        String Content { get; set; }

        /// <summary></summary>
        String Priority { get; set; }

        /// <summary></summary>
        Int32 SendCount { get; set; }

        /// <summary></summary>
        Int32 ReadCount { get; set; }

        /// <summary></summary>
        Int32 IsOpen { get; set; }

        /// <summary></summary>
        String CommentUserID { get; set; }

        /// <summary></summary>
        String CommentUserRealName { get; set; }

        /// <summary></summary>
        DateTime CommentDate { get; set; }

        /// <summary></summary>
        Boolean DeletionStateCode { get; set; }

        /// <summary></summary>
        Boolean Enabled { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

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