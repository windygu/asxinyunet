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
    [BindIndex("PK_Base_ContactDetails", true, "Id")]
    [BindTable("BaseContactDetails", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseContactDetails : IBaseContactDetails
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

        private String _ContactId;
        /// <summary></summary>
        [DisplayName("ContactId")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(2, "ContactId", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String ContactId
        {
            get { return _ContactId; }
            set { if (OnPropertyChanging("ContactId", value)) { _ContactId = value; OnPropertyChanged("ContactId"); } }
        }

        private String _Category;
        /// <summary></summary>
        [DisplayName("Category")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(3, "Category", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String Category
        {
            get { return _Category; }
            set { if (OnPropertyChanging("Category", value)) { _Category = value; OnPropertyChanged("Category"); } }
        }

        private String _ReceiverId;
        /// <summary></summary>
        [DisplayName("ReceiverId")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(4, "ReceiverId", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String ReceiverId
        {
            get { return _ReceiverId; }
            set { if (OnPropertyChanging("ReceiverId", value)) { _ReceiverId = value; OnPropertyChanged("ReceiverId"); } }
        }

        private String _ReceiverRealName;
        /// <summary></summary>
        [DisplayName("ReceiverRealName")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(5, "ReceiverRealName", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String ReceiverRealName
        {
            get { return _ReceiverRealName; }
            set { if (OnPropertyChanging("ReceiverRealName", value)) { _ReceiverRealName = value; OnPropertyChanged("ReceiverRealName"); } }
        }

        private Boolean _IsNew;
        /// <summary></summary>
        [DisplayName("IsNew")]
        [Description("")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(6, "IsNew", "", "1", "bit", 0, 0, false)]
        public virtual Boolean IsNew
        {
            get { return _IsNew; }
            set { if (OnPropertyChanging("IsNew", value)) { _IsNew = value; OnPropertyChanged("IsNew"); } }
        }

        private Boolean _NewComment;
        /// <summary></summary>
        [DisplayName("NewComment")]
        [Description("")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(7, "NewComment", "", "1", "bit", 0, 0, false)]
        public virtual Boolean NewComment
        {
            get { return _NewComment; }
            set { if (OnPropertyChanging("NewComment", value)) { _NewComment = value; OnPropertyChanged("NewComment"); } }
        }

        private String _LastViewIP;
        /// <summary></summary>
        [DisplayName("LastViewIP")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(8, "LastViewIP", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String LastViewIP
        {
            get { return _LastViewIP; }
            set { if (OnPropertyChanging("LastViewIP", value)) { _LastViewIP = value; OnPropertyChanged("LastViewIP"); } }
        }

        private String _LastViewDate;
        /// <summary></summary>
        [DisplayName("LastViewDate")]
        [Description("")]
        [DataObjectField(false, false, true, 40)]
        [BindColumn(9, "LastViewDate", "", null, "nvarchar(40)", 0, 0, true)]
        public virtual String LastViewDate
        {
            get { return _LastViewDate; }
            set { if (OnPropertyChanging("LastViewDate", value)) { _LastViewDate = value; OnPropertyChanged("LastViewDate"); } }
        }

        private Boolean _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(10, "Enabled", "", "1", "bit", 0, 0, false)]
        public virtual Boolean Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Boolean _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, false, 1)]
        [BindColumn(11, "DeletionStateCode", "", "0", "bit", 0, 0, false)]
        public virtual Boolean DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(12, "SortCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(13, "Description", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private DateTime _CreateOn;
        /// <summary></summary>
        [DisplayName("CreateOn")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(14, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(15, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(16, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(17, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(18, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(19, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "ContactId" : return _ContactId;
                    case "Category" : return _Category;
                    case "ReceiverId" : return _ReceiverId;
                    case "ReceiverRealName" : return _ReceiverRealName;
                    case "IsNew" : return _IsNew;
                    case "NewComment" : return _NewComment;
                    case "LastViewIP" : return _LastViewIP;
                    case "LastViewDate" : return _LastViewDate;
                    case "Enabled" : return _Enabled;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "SortCode" : return _SortCode;
                    case "Description" : return _Description;
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
                    case "ContactId" : _ContactId = Convert.ToString(value); break;
                    case "Category" : _Category = Convert.ToString(value); break;
                    case "ReceiverId" : _ReceiverId = Convert.ToString(value); break;
                    case "ReceiverRealName" : _ReceiverRealName = Convert.ToString(value); break;
                    case "IsNew" : _IsNew = Convert.ToBoolean(value); break;
                    case "NewComment" : _NewComment = Convert.ToBoolean(value); break;
                    case "LastViewIP" : _LastViewIP = Convert.ToString(value); break;
                    case "LastViewDate" : _LastViewDate = Convert.ToString(value); break;
                    case "Enabled" : _Enabled = Convert.ToBoolean(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToBoolean(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
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
            public static readonly Field ContactId = FindByName("ContactId");

            ///<summary></summary>
            public static readonly Field Category = FindByName("Category");

            ///<summary></summary>
            public static readonly Field ReceiverId = FindByName("ReceiverId");

            ///<summary></summary>
            public static readonly Field ReceiverRealName = FindByName("ReceiverRealName");

            ///<summary></summary>
            public static readonly Field IsNew = FindByName("IsNew");

            ///<summary></summary>
            public static readonly Field NewComment = FindByName("NewComment");

            ///<summary></summary>
            public static readonly Field LastViewIP = FindByName("LastViewIP");

            ///<summary></summary>
            public static readonly Field LastViewDate = FindByName("LastViewDate");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

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
    public partial interface IBaseContactDetails
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String ContactId { get; set; }

        /// <summary></summary>
        String Category { get; set; }

        /// <summary></summary>
        String ReceiverId { get; set; }

        /// <summary></summary>
        String ReceiverRealName { get; set; }

        /// <summary></summary>
        Boolean IsNew { get; set; }

        /// <summary></summary>
        Boolean NewComment { get; set; }

        /// <summary></summary>
        String LastViewIP { get; set; }

        /// <summary></summary>
        String LastViewDate { get; set; }

        /// <summary></summary>
        Boolean Enabled { get; set; }

        /// <summary></summary>
        Boolean DeletionStateCode { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

        /// <summary></summary>
        String Description { get; set; }

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