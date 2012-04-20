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
    [BindIndex("PK_Base_Comment", true, "Id")]
    [BindTable("BaseComment", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseComment : IBaseComment
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

        private String _ParentId;
        /// <summary></summary>
        [DisplayName("ParentId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "ParentId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ParentId
        {
            get { return _ParentId; }
            set { if (OnPropertyChanging("ParentId", value)) { _ParentId = value; OnPropertyChanged("ParentId"); } }
        }

        private String _CategoryCode;
        /// <summary></summary>
        [DisplayName("CategoryCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "CategoryCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CategoryCode
        {
            get { return _CategoryCode; }
            set { if (OnPropertyChanging("CategoryCode", value)) { _CategoryCode = value; OnPropertyChanged("CategoryCode"); } }
        }

        private String _ObjectId;
        /// <summary></summary>
        [DisplayName("ObjectId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "ObjectId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ObjectId
        {
            get { return _ObjectId; }
            set { if (OnPropertyChanging("ObjectId", value)) { _ObjectId = value; OnPropertyChanged("ObjectId"); } }
        }

        private String _Title;
        /// <summary></summary>
        [DisplayName("Title")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "Title", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Title
        {
            get { return _Title; }
            set { if (OnPropertyChanging("Title", value)) { _Title = value; OnPropertyChanged("Title"); } }
        }

        private Int32 _Worked;
        /// <summary></summary>
        [DisplayName("Worked")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "Worked", "", null, "int", 10, 0, false)]
        public virtual Int32 Worked
        {
            get { return _Worked; }
            set { if (OnPropertyChanging("Worked", value)) { _Worked = value; OnPropertyChanged("Worked"); } }
        }

        private String _Contents;
        /// <summary></summary>
        [DisplayName("Contents")]
        [Description("")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(7, "Contents", "", null, "ntext", 0, 0, true)]
        public virtual String Contents
        {
            get { return _Contents; }
            set { if (OnPropertyChanging("Contents", value)) { _Contents = value; OnPropertyChanged("Contents"); } }
        }

        private Int32 _Important;
        /// <summary></summary>
        [DisplayName("Important")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "Important", "", "0", "int", 10, 0, false)]
        public virtual Int32 Important
        {
            get { return _Important; }
            set { if (OnPropertyChanging("Important", value)) { _Important = value; OnPropertyChanged("Important"); } }
        }

        private String _PriorityId;
        /// <summary></summary>
        [DisplayName("PriorityId")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(9, "PriorityId", "", null, "varchar(20)", 0, 0, false)]
        public virtual String PriorityId
        {
            get { return _PriorityId; }
            set { if (OnPropertyChanging("PriorityId", value)) { _PriorityId = value; OnPropertyChanged("PriorityId"); } }
        }

        private String _IPAddress;
        /// <summary></summary>
        [DisplayName("IPAddress")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "IPAddress", "", null, "varchar(50)", 0, 0, false)]
        public virtual String IPAddress
        {
            get { return _IPAddress; }
            set { if (OnPropertyChanging("IPAddress", value)) { _IPAddress = value; OnPropertyChanged("IPAddress"); } }
        }

        private String _TargetURL;
        /// <summary></summary>
        [DisplayName("TargetURL")]
        [Description("")]
        [DataObjectField(false, false, true, 400)]
        [BindColumn(11, "TargetURL", "", null, "nvarchar(400)", 0, 0, true)]
        public virtual String TargetURL
        {
            get { return _TargetURL; }
            set { if (OnPropertyChanging("TargetURL", value)) { _TargetURL = value; OnPropertyChanged("TargetURL"); } }
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
        [DataObjectField(false, false, true, 10)]
        [BindColumn(13, "DeletionStateCode", "", "0", "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(14, "Enabled", "", "1", "int", 10, 0, false)]
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
                    case "CategoryCode" : return _CategoryCode;
                    case "ObjectId" : return _ObjectId;
                    case "Title" : return _Title;
                    case "Worked" : return _Worked;
                    case "Contents" : return _Contents;
                    case "Important" : return _Important;
                    case "PriorityId" : return _PriorityId;
                    case "IPAddress" : return _IPAddress;
                    case "TargetURL" : return _TargetURL;
                    case "Description" : return _Description;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "Enabled" : return _Enabled;
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
                    case "CategoryCode" : _CategoryCode = Convert.ToString(value); break;
                    case "ObjectId" : _ObjectId = Convert.ToString(value); break;
                    case "Title" : _Title = Convert.ToString(value); break;
                    case "Worked" : _Worked = Convert.ToInt32(value); break;
                    case "Contents" : _Contents = Convert.ToString(value); break;
                    case "Important" : _Important = Convert.ToInt32(value); break;
                    case "PriorityId" : _PriorityId = Convert.ToString(value); break;
                    case "IPAddress" : _IPAddress = Convert.ToString(value); break;
                    case "TargetURL" : _TargetURL = Convert.ToString(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
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
            public static readonly Field CategoryCode = FindByName("CategoryCode");

            ///<summary></summary>
            public static readonly Field ObjectId = FindByName("ObjectId");

            ///<summary></summary>
            public static readonly Field Title = FindByName("Title");

            ///<summary></summary>
            public static readonly Field Worked = FindByName("Worked");

            ///<summary></summary>
            public static readonly Field Contents = FindByName("Contents");

            ///<summary></summary>
            public static readonly Field Important = FindByName("Important");

            ///<summary></summary>
            public static readonly Field PriorityId = FindByName("PriorityId");

            ///<summary></summary>
            public static readonly Field IPAddress = FindByName("IPAddress");

            ///<summary></summary>
            public static readonly Field TargetURL = FindByName("TargetURL");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

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
    public partial interface IBaseComment
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String ParentId { get; set; }

        /// <summary></summary>
        String CategoryCode { get; set; }

        /// <summary></summary>
        String ObjectId { get; set; }

        /// <summary></summary>
        String Title { get; set; }

        /// <summary></summary>
        Int32 Worked { get; set; }

        /// <summary></summary>
        String Contents { get; set; }

        /// <summary></summary>
        Int32 Important { get; set; }

        /// <summary></summary>
        String PriorityId { get; set; }

        /// <summary></summary>
        String IPAddress { get; set; }

        /// <summary></summary>
        String TargetURL { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

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