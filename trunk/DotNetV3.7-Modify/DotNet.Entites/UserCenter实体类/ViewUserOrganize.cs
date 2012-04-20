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
    [BindTable("ViewUserOrganize", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class ViewUserOrganize : IViewUserOrganize
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn(1, "Id", "", null, "int", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private Int32 _UserId;
        /// <summary></summary>
        [DisplayName("UserId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "UserId", "", null, "int", 10, 0, false)]
        public virtual Int32 UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } }
        }

        private Int32 _CompanyId;
        /// <summary></summary>
        [DisplayName("CompanyId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "CompanyId", "", null, "int", 10, 0, false)]
        public virtual Int32 CompanyId
        {
            get { return _CompanyId; }
            set { if (OnPropertyChanging("CompanyId", value)) { _CompanyId = value; OnPropertyChanged("CompanyId"); } }
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

        private Int32 _WorkgroupId;
        /// <summary></summary>
        [DisplayName("WorkgroupId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(5, "WorkgroupId", "", null, "int", 10, 0, false)]
        public virtual Int32 WorkgroupId
        {
            get { return _WorkgroupId; }
            set { if (OnPropertyChanging("WorkgroupId", value)) { _WorkgroupId = value; OnPropertyChanged("WorkgroupId"); } }
        }

        private Int32 _RoleId;
        /// <summary></summary>
        [DisplayName("RoleId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "RoleId", "", null, "int", 10, 0, false)]
        public virtual Int32 RoleId
        {
            get { return _RoleId; }
            set { if (OnPropertyChanging("RoleId", value)) { _RoleId = value; OnPropertyChanged("RoleId"); } }
        }

        private Int32 _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [Description("")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(7, "Enabled", "", null, "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary></summary>
        [DisplayName("DeletionStateCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "DeletionStateCode", "", null, "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(9, "Description", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private String _CreateUserId;
        /// <summary></summary>
        [DisplayName("CreateUserId")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(10, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
        public virtual String CreateUserId
        {
            get { return _CreateUserId; }
            set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } }
        }

        private String _RoleCode;
        /// <summary></summary>
        [DisplayName("RoleCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "RoleCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String RoleCode
        {
            get { return _RoleCode; }
            set { if (OnPropertyChanging("RoleCode", value)) { _RoleCode = value; OnPropertyChanged("RoleCode"); } }
        }

        private String _RoleName;
        /// <summary></summary>
        [DisplayName("RoleName")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(12, "RoleName", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String RoleName
        {
            get { return _RoleName; }
            set { if (OnPropertyChanging("RoleName", value)) { _RoleName = value; OnPropertyChanged("RoleName"); } }
        }

        private String _CompanyName;
        /// <summary></summary>
        [DisplayName("CompanyName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "CompanyName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CompanyName
        {
            get { return _CompanyName; }
            set { if (OnPropertyChanging("CompanyName", value)) { _CompanyName = value; OnPropertyChanged("CompanyName"); } }
        }

        private String _DepartmentName;
        /// <summary></summary>
        [DisplayName("DepartmentName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "DepartmentName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DepartmentName
        {
            get { return _DepartmentName; }
            set { if (OnPropertyChanging("DepartmentName", value)) { _DepartmentName = value; OnPropertyChanged("DepartmentName"); } }
        }

        private String _WorkgroupName;
        /// <summary></summary>
        [DisplayName("WorkgroupName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "WorkgroupName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String WorkgroupName
        {
            get { return _WorkgroupName; }
            set { if (OnPropertyChanging("WorkgroupName", value)) { _WorkgroupName = value; OnPropertyChanged("WorkgroupName"); } }
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
                    case "CompanyId" : return _CompanyId;
                    case "DepartmentId" : return _DepartmentId;
                    case "WorkgroupId" : return _WorkgroupId;
                    case "RoleId" : return _RoleId;
                    case "Enabled" : return _Enabled;
                    case "DeletionStateCode" : return _DeletionStateCode;
                    case "Description" : return _Description;
                    case "CreateUserId" : return _CreateUserId;
                    case "RoleCode" : return _RoleCode;
                    case "RoleName" : return _RoleName;
                    case "CompanyName" : return _CompanyName;
                    case "DepartmentName" : return _DepartmentName;
                    case "WorkgroupName" : return _WorkgroupName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "UserId" : _UserId = Convert.ToInt32(value); break;
                    case "CompanyId" : _CompanyId = Convert.ToInt32(value); break;
                    case "DepartmentId" : _DepartmentId = Convert.ToInt32(value); break;
                    case "WorkgroupId" : _WorkgroupId = Convert.ToInt32(value); break;
                    case "RoleId" : _RoleId = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    case "CreateUserId" : _CreateUserId = Convert.ToString(value); break;
                    case "RoleCode" : _RoleCode = Convert.ToString(value); break;
                    case "RoleName" : _RoleName = Convert.ToString(value); break;
                    case "CompanyName" : _CompanyName = Convert.ToString(value); break;
                    case "DepartmentName" : _DepartmentName = Convert.ToString(value); break;
                    case "WorkgroupName" : _WorkgroupName = Convert.ToString(value); break;
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
            public static readonly Field CompanyId = FindByName("CompanyId");

            ///<summary></summary>
            public static readonly Field DepartmentId = FindByName("DepartmentId");

            ///<summary></summary>
            public static readonly Field WorkgroupId = FindByName("WorkgroupId");

            ///<summary></summary>
            public static readonly Field RoleId = FindByName("RoleId");

            ///<summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary></summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary></summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary></summary>
            public static readonly Field CreateUserId = FindByName("CreateUserId");

            ///<summary></summary>
            public static readonly Field RoleCode = FindByName("RoleCode");

            ///<summary></summary>
            public static readonly Field RoleName = FindByName("RoleName");

            ///<summary></summary>
            public static readonly Field CompanyName = FindByName("CompanyName");

            ///<summary></summary>
            public static readonly Field DepartmentName = FindByName("DepartmentName");

            ///<summary></summary>
            public static readonly Field WorkgroupName = FindByName("WorkgroupName");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IViewUserOrganize
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        Int32 UserId { get; set; }

        /// <summary></summary>
        Int32 CompanyId { get; set; }

        /// <summary></summary>
        Int32 DepartmentId { get; set; }

        /// <summary></summary>
        Int32 WorkgroupId { get; set; }

        /// <summary></summary>
        Int32 RoleId { get; set; }

        /// <summary></summary>
        Int32 Enabled { get; set; }

        /// <summary></summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        String CreateUserId { get; set; }

        /// <summary></summary>
        String RoleCode { get; set; }

        /// <summary></summary>
        String RoleName { get; set; }

        /// <summary></summary>
        String CompanyName { get; set; }

        /// <summary></summary>
        String DepartmentName { get; set; }

        /// <summary></summary>
        String WorkgroupName { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}