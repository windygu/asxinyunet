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
    [BindIndex("PK_APPMODIFYINFORMATION", true, "Id")]
    [BindTable("ModifyInformation", Description = "", ConnName = "WorkFlowDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class ModifyInformation : IModifyInformation
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

        private String _Telephone;
        /// <summary></summary>
        [DisplayName("Telephone")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "Telephone", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Telephone
        {
            get { return _Telephone; }
            set { if (OnPropertyChanging("Telephone", value)) { _Telephone = value; OnPropertyChanged("Telephone"); } }
        }

        private String _Mobile;
        /// <summary></summary>
        [DisplayName("Mobile")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "Mobile", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Mobile
        {
            get { return _Mobile; }
            set { if (OnPropertyChanging("Mobile", value)) { _Mobile = value; OnPropertyChanged("Mobile"); } }
        }

        private String _EquipmentPositionNumber;
        /// <summary></summary>
        [DisplayName("EquipmentPositionNumber")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "EquipmentPositionNumber", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String EquipmentPositionNumber
        {
            get { return _EquipmentPositionNumber; }
            set { if (OnPropertyChanging("EquipmentPositionNumber", value)) { _EquipmentPositionNumber = value; OnPropertyChanged("EquipmentPositionNumber"); } }
        }

        private String _System;
        /// <summary></summary>
        [DisplayName("System")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(10, "System", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String System
        {
            get { return _System; }
            set { if (OnPropertyChanging("System", value)) { _System = value; OnPropertyChanged("System"); } }
        }

        private String _ModifyCause;
        /// <summary></summary>
        [DisplayName("ModifyCause")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(11, "ModifyCause", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String ModifyCause
        {
            get { return _ModifyCause; }
            set { if (OnPropertyChanging("ModifyCause", value)) { _ModifyCause = value; OnPropertyChanged("ModifyCause"); } }
        }

        private String _ModifyContent;
        /// <summary></summary>
        [DisplayName("ModifyContent")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(12, "ModifyContent", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String ModifyContent
        {
            get { return _ModifyContent; }
            set { if (OnPropertyChanging("ModifyContent", value)) { _ModifyContent = value; OnPropertyChanged("ModifyContent"); } }
        }

        private DateTime _ApplyDate;
        /// <summary></summary>
        [DisplayName("ApplyDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "ApplyDate", "", null, "datetime", 3, 0, false)]
        public virtual DateTime ApplyDate
        {
            get { return _ApplyDate; }
            set { if (OnPropertyChanging("ApplyDate", value)) { _ApplyDate = value; OnPropertyChanged("ApplyDate"); } }
        }

        private DateTime _PlanCompletionDate;
        /// <summary></summary>
        [DisplayName("PlanCompletionDate")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(14, "PlanCompletionDate", "", null, "datetime", 3, 0, false)]
        public virtual DateTime PlanCompletionDate
        {
            get { return _PlanCompletionDate; }
            set { if (OnPropertyChanging("PlanCompletionDate", value)) { _PlanCompletionDate = value; OnPropertyChanged("PlanCompletionDate"); } }
        }

        private String _ModifyPerson;
        /// <summary></summary>
        [DisplayName("ModifyPerson")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "ModifyPerson", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ModifyPerson
        {
            get { return _ModifyPerson; }
            set { if (OnPropertyChanging("ModifyPerson", value)) { _ModifyPerson = value; OnPropertyChanged("ModifyPerson"); } }
        }

        private Int32 _AttchmentOriginal;
        /// <summary></summary>
        [DisplayName("AttchmentOriginal")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(16, "AttchmentOriginal", "", null, "int", 10, 0, false)]
        public virtual Int32 AttchmentOriginal
        {
            get { return _AttchmentOriginal; }
            set { if (OnPropertyChanging("AttchmentOriginal", value)) { _AttchmentOriginal = value; OnPropertyChanged("AttchmentOriginal"); } }
        }

        private Int32 _AttchmentModified;
        /// <summary></summary>
        [DisplayName("AttchmentModified")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(17, "AttchmentModified", "", null, "int", 10, 0, false)]
        public virtual Int32 AttchmentModified
        {
            get { return _AttchmentModified; }
            set { if (OnPropertyChanging("AttchmentModified", value)) { _AttchmentModified = value; OnPropertyChanged("AttchmentModified"); } }
        }

        private String _CompletionSituation;
        /// <summary></summary>
        [DisplayName("CompletionSituation")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(18, "CompletionSituation", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String CompletionSituation
        {
            get { return _CompletionSituation; }
            set { if (OnPropertyChanging("CompletionSituation", value)) { _CompletionSituation = value; OnPropertyChanged("CompletionSituation"); } }
        }

        private String _AuditStatus;
        /// <summary></summary>
        [DisplayName("AuditStatus")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(19, "AuditStatus", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AuditStatus
        {
            get { return _AuditStatus; }
            set { if (OnPropertyChanging("AuditStatus", value)) { _AuditStatus = value; OnPropertyChanged("AuditStatus"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(20, "SortCode", "", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(21, "DeletionStateCode", "", "0", "int", 10, 0, false)]
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
        [BindColumn(22, "Enabled", "", "1", "int", 10, 0, false)]
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
        [BindColumn(23, "Description", "", null, "nvarchar(200)", 0, 0, true)]
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
        [BindColumn(24, "CreateOn", "", null, "datetime", 3, 0, false)]
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
        [BindColumn(25, "CreateUserId", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(26, "CreateBy", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(27, "ModifiedOn", "", null, "datetime", 3, 0, false)]
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
        [BindColumn(28, "ModifiedUserId", "", null, "nvarchar(50)", 0, 0, true)]
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
        [BindColumn(29, "ModifiedBy", "", null, "nvarchar(50)", 0, 0, true)]
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
                    case "Telephone" : return _Telephone;
                    case "Mobile" : return _Mobile;
                    case "EquipmentPositionNumber" : return _EquipmentPositionNumber;
                    case "System" : return _System;
                    case "ModifyCause" : return _ModifyCause;
                    case "ModifyContent" : return _ModifyContent;
                    case "ApplyDate" : return _ApplyDate;
                    case "PlanCompletionDate" : return _PlanCompletionDate;
                    case "ModifyPerson" : return _ModifyPerson;
                    case "AttchmentOriginal" : return _AttchmentOriginal;
                    case "AttchmentModified" : return _AttchmentModified;
                    case "CompletionSituation" : return _CompletionSituation;
                    case "AuditStatus" : return _AuditStatus;
                    case "SortCode" : return _SortCode;
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
                    case "Telephone" : _Telephone = Convert.ToString(value); break;
                    case "Mobile" : _Mobile = Convert.ToString(value); break;
                    case "EquipmentPositionNumber" : _EquipmentPositionNumber = Convert.ToString(value); break;
                    case "System" : _System = Convert.ToString(value); break;
                    case "ModifyCause" : _ModifyCause = Convert.ToString(value); break;
                    case "ModifyContent" : _ModifyContent = Convert.ToString(value); break;
                    case "ApplyDate" : _ApplyDate = Convert.ToDateTime(value); break;
                    case "PlanCompletionDate" : _PlanCompletionDate = Convert.ToDateTime(value); break;
                    case "ModifyPerson" : _ModifyPerson = Convert.ToString(value); break;
                    case "AttchmentOriginal" : _AttchmentOriginal = Convert.ToInt32(value); break;
                    case "AttchmentModified" : _AttchmentModified = Convert.ToInt32(value); break;
                    case "CompletionSituation" : _CompletionSituation = Convert.ToString(value); break;
                    case "AuditStatus" : _AuditStatus = Convert.ToString(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
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
            public static readonly Field Telephone = FindByName("Telephone");

            ///<summary></summary>
            public static readonly Field Mobile = FindByName("Mobile");

            ///<summary></summary>
            public static readonly Field EquipmentPositionNumber = FindByName("EquipmentPositionNumber");

            ///<summary></summary>
            public static readonly Field System = FindByName("System");

            ///<summary></summary>
            public static readonly Field ModifyCause = FindByName("ModifyCause");

            ///<summary></summary>
            public static readonly Field ModifyContent = FindByName("ModifyContent");

            ///<summary></summary>
            public static readonly Field ApplyDate = FindByName("ApplyDate");

            ///<summary></summary>
            public static readonly Field PlanCompletionDate = FindByName("PlanCompletionDate");

            ///<summary></summary>
            public static readonly Field ModifyPerson = FindByName("ModifyPerson");

            ///<summary></summary>
            public static readonly Field AttchmentOriginal = FindByName("AttchmentOriginal");

            ///<summary></summary>
            public static readonly Field AttchmentModified = FindByName("AttchmentModified");

            ///<summary></summary>
            public static readonly Field CompletionSituation = FindByName("CompletionSituation");

            ///<summary></summary>
            public static readonly Field AuditStatus = FindByName("AuditStatus");

            ///<summary></summary>
            public static readonly Field SortCode = FindByName("SortCode");

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
    public partial interface IModifyInformation
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
        String Telephone { get; set; }

        /// <summary></summary>
        String Mobile { get; set; }

        /// <summary></summary>
        String EquipmentPositionNumber { get; set; }

        /// <summary></summary>
        String System { get; set; }

        /// <summary></summary>
        String ModifyCause { get; set; }

        /// <summary></summary>
        String ModifyContent { get; set; }

        /// <summary></summary>
        DateTime ApplyDate { get; set; }

        /// <summary></summary>
        DateTime PlanCompletionDate { get; set; }

        /// <summary></summary>
        String ModifyPerson { get; set; }

        /// <summary></summary>
        Int32 AttchmentOriginal { get; set; }

        /// <summary></summary>
        Int32 AttchmentModified { get; set; }

        /// <summary></summary>
        String CompletionSituation { get; set; }

        /// <summary></summary>
        String AuditStatus { get; set; }

        /// <summary></summary>
        Int32 SortCode { get; set; }

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