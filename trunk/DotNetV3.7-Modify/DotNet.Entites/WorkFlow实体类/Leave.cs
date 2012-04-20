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
    [BindIndex("PK_APPLEAVE", true, "Id")]
    [BindTable("Leave", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class Leave : ILeave
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

        private String _UserId;
        /// <summary></summary>
        [DisplayName("UserId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "UserId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } }
        }

        private String _UserName;
        /// <summary></summary>
        [DisplayName("UserName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "UserName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserName
        {
            get { return _UserName; }
            set { if (OnPropertyChanging("UserName", value)) { _UserName = value; OnPropertyChanged("UserName"); } }
        }

        private Int32 _DepartmentId;
        /// <summary></summary>
        [DisplayName("DepartmentId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "DepartmentId", "", null, "int", 10, 0, false)]
        public virtual Int32 DepartmentId
        {
            get { return _DepartmentId; }
            set { if (OnPropertyChanging("DepartmentId", value)) { _DepartmentId = value; OnPropertyChanged("DepartmentId"); } }
        }

        private String _DepartmentName;
        /// <summary></summary>
        [DisplayName("DepartmentName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "DepartmentName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DepartmentName
        {
            get { return _DepartmentName; }
            set { if (OnPropertyChanging("DepartmentName", value)) { _DepartmentName = value; OnPropertyChanged("DepartmentName"); } }
        }

        private String _Code;
        /// <summary></summary>
        [DisplayName("Code")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "Code", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Code
        {
            get { return _Code; }
            set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } }
        }

        private String _TransferOfPeople;
        /// <summary></summary>
        [DisplayName("TransferOfPeople")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "TransferOfPeople", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String TransferOfPeople
        {
            get { return _TransferOfPeople; }
            set { if (OnPropertyChanging("TransferOfPeople", value)) { _TransferOfPeople = value; OnPropertyChanged("TransferOfPeople"); } }
        }

        private String _Telephone;
        /// <summary></summary>
        [DisplayName("Telephone")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "Telephone", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Telephone
        {
            get { return _Telephone; }
            set { if (OnPropertyChanging("Telephone", value)) { _Telephone = value; OnPropertyChanged("Telephone"); } }
        }

        private String _Day;
        /// <summary></summary>
        [DisplayName("Day")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "Day", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Day
        {
            get { return _Day; }
            set { if (OnPropertyChanging("Day", value)) { _Day = value; OnPropertyChanged("Day"); } }
        }

        private Int32 _Hours;
        /// <summary></summary>
        [DisplayName("Hours")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "Hours", "", null, "int", 10, 0, false)]
        public virtual Int32 Hours
        {
            get { return _Hours; }
            set { if (OnPropertyChanging("Hours", value)) { _Hours = value; OnPropertyChanged("Hours"); } }
        }

        private String _TransferInstructions;
        /// <summary></summary>
        [DisplayName("TransferInstructions")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "TransferInstructions", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String TransferInstructions
        {
            get { return _TransferInstructions; }
            set { if (OnPropertyChanging("TransferInstructions", value)) { _TransferInstructions = value; OnPropertyChanged("TransferInstructions"); } }
        }

        private String _ItemsLeaveCategory;
        /// <summary></summary>
        [DisplayName("ItemsLeaveCategory")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "ItemsLeaveCategory", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ItemsLeaveCategory
        {
            get { return _ItemsLeaveCategory; }
            set { if (OnPropertyChanging("ItemsLeaveCategory", value)) { _ItemsLeaveCategory = value; OnPropertyChanged("ItemsLeaveCategory"); } }
        }

        private DateTime _StartTime;
        /// <summary></summary>
        [DisplayName("StartTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "StartTime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime StartTime
        {
            get { return _StartTime; }
            set { if (OnPropertyChanging("StartTime", value)) { _StartTime = value; OnPropertyChanged("StartTime"); } }
        }

        private DateTime _EndTime;
        /// <summary></summary>
        [DisplayName("EndTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(14, "EndTime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime EndTime
        {
            get { return _EndTime; }
            set { if (OnPropertyChanging("EndTime", value)) { _EndTime = value; OnPropertyChanged("EndTime"); } }
        }

        private String _Reason;
        /// <summary></summary>
        [DisplayName("Reason")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(15, "Reason", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Reason
        {
            get { return _Reason; }
            set { if (OnPropertyChanging("Reason", value)) { _Reason = value; OnPropertyChanged("Reason"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(16, "SortCode", "", "0", "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private String _AuditStatus;
        /// <summary></summary>
        [DisplayName("AuditStatus")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(17, "AuditStatus", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditStatus
        {
            get { return _AuditStatus; }
            set { if (OnPropertyChanging("AuditStatus", value)) { _AuditStatus = value; OnPropertyChanged("AuditStatus"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(18, "DeletionStateCode", "", "0", "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(19, "Enabled", "", "1", "int", 10, 0, false)]
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
        [BindColumn(20, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(21, "CreateOn", "", null, "datetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }

        private String _CreateUserId;
        /// <summary></summary>
        [DisplayName("CreateUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(22, "CreateUserId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateUserId
        {
            get { return _CreateUserId; }
            set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } }
        }

        private String _CreateBy;
        /// <summary></summary>
        [DisplayName("CreateBy")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(23, "CreateBy", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(24, "ModifiedOn", "", null, "datetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging("ModifiedOn", value)) { _ModifiedOn = value; OnPropertyChanged("ModifiedOn"); } }
        }

        private String _ModifiedUserId;
        /// <summary></summary>
        [DisplayName("ModifiedUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(25, "ModifiedUserId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ModifiedUserId
        {
            get { return _ModifiedUserId; }
            set { if (OnPropertyChanging("ModifiedUserId", value)) { _ModifiedUserId = value; OnPropertyChanged("ModifiedUserId"); } }
        }

        private String _ModifiedBy;
        /// <summary></summary>
        [DisplayName("ModifiedBy")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(26, "ModifiedBy", "", null, "nvarchar(50)", 0, 0, true)]
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
                    case "UserId" : return _UserId;
                    case "UserName" : return _UserName;
                    case "DepartmentId" : return _DepartmentId;
                    case "DepartmentName" : return _DepartmentName;
                    case "Code" : return _Code;
                    case "TransferOfPeople" : return _TransferOfPeople;
                    case "Telephone" : return _Telephone;
                    case "Day" : return _Day;
                    case "Hours" : return _Hours;
                    case "TransferInstructions" : return _TransferInstructions;
                    case "ItemsLeaveCategory" : return _ItemsLeaveCategory;
                    case "StartTime" : return _StartTime;
                    case "EndTime" : return _EndTime;
                    case "Reason" : return _Reason;
                    case "SortCode" : return _SortCode;
                    case "AuditStatus" : return _AuditStatus;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "Enabled" : return _Enabled;
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
                    case "UserId" : _UserId = Convert.ToString(value); break;
                    case "UserName" : _UserName = Convert.ToString(value); break;
                    case "DepartmentId" : _DepartmentId = Convert.ToInt32(value); break;
                    case "DepartmentName" : _DepartmentName = Convert.ToString(value); break;
                    case "Code" : _Code = Convert.ToString(value); break;
                    case "TransferOfPeople" : _TransferOfPeople = Convert.ToString(value); break;
                    case "Telephone" : _Telephone = Convert.ToString(value); break;
                    case "Day" : _Day = Convert.ToString(value); break;
                    case "Hours" : _Hours = Convert.ToInt32(value); break;
                    case "TransferInstructions" : _TransferInstructions = Convert.ToString(value); break;
                    case "ItemsLeaveCategory" : _ItemsLeaveCategory = Convert.ToString(value); break;
                    case "StartTime" : _StartTime = Convert.ToDateTime(value); break;
                    case "EndTime" : _EndTime = Convert.ToDateTime(value); break;
                    case "Reason" : _Reason = Convert.ToString(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "AuditStatus" : _AuditStatus = Convert.ToString(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
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
            public static readonly Field UserId = FindByName("UserId");

            ///<summary></summary>
            public static readonly Field UserName = FindByName("UserName");

            ///<summary></summary>
            public static readonly Field DepartmentId = FindByName("DepartmentId");

            ///<summary></summary>
            public static readonly Field DepartmentName = FindByName("DepartmentName");

            ///<summary></summary>
            public static readonly Field Code = FindByName("Code");

            ///<summary></summary>
            public static readonly Field TransferOfPeople = FindByName("TransferOfPeople");

            ///<summary></summary>
            public static readonly Field Telephone = FindByName("Telephone");

            ///<summary></summary>
            public static readonly Field Day = FindByName("Day");

            ///<summary></summary>
            public static readonly Field Hours = FindByName("Hours");

            ///<summary></summary>
            public static readonly Field TransferInstructions = FindByName("TransferInstructions");

            ///<summary></summary>
            public static readonly Field ItemsLeaveCategory = FindByName("ItemsLeaveCategory");

            ///<summary></summary>
            public static readonly Field StartTime = FindByName("StartTime");

            ///<summary></summary>
            public static readonly Field EndTime = FindByName("EndTime");

            ///<summary></summary>
            public static readonly Field Reason = FindByName("Reason");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary></summary>
            public static readonly Field AuditStatus = FindByName("AuditStatus");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

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
    public partial interface ILeave
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String UserId { get; set; }

        /// <summary></summary>
        String UserName { get; set; }

        /// <summary></summary>
        Int32 DepartmentId { get; set; }

        /// <summary></summary>
        String DepartmentName { get; set; }

        /// <summary></summary>
        String Code { get; set; }

        /// <summary></summary>
        String TransferOfPeople { get; set; }

        /// <summary></summary>
        String Telephone { get; set; }

        /// <summary></summary>
        String Day { get; set; }

        /// <summary></summary>
        Int32 Hours { get; set; }

        /// <summary></summary>
        String TransferInstructions { get; set; }

        /// <summary></summary>
        String ItemsLeaveCategory { get; set; }

        /// <summary></summary>
        DateTime StartTime { get; set; }

        /// <summary></summary>
        DateTime EndTime { get; set; }

        /// <summary></summary>
        String Reason { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

        /// <summary></summary>
        String AuditStatus { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

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