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
    [BindIndex("PK_Base_UserAddress", true, "Id")]
    [BindTable("BaseUserAddress", Description = "", ConnName = "UserCenterDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class BaseUserAddress : IBaseUserAddress
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "", null, "int", 10, 0, false)]
        public virtual Int32 Id
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

        private String _RealName;
        /// <summary></summary>
        [DisplayName("RealName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "RealName", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String RealName
        {
            get { return _RealName; }
            set { if (OnPropertyChanging("RealName", value)) { _RealName = value; OnPropertyChanged("RealName"); } }
        }

        private String _Province;
        /// <summary></summary>
        [DisplayName("Province")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "Province", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Province
        {
            get { return _Province; }
            set { if (OnPropertyChanging("Province", value)) { _Province = value; OnPropertyChanged("Province"); } }
        }

        private String _ProvinceId;
        /// <summary></summary>
        [DisplayName("ProvinceId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "ProvinceId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ProvinceId
        {
            get { return _ProvinceId; }
            set { if (OnPropertyChanging("ProvinceId", value)) { _ProvinceId = value; OnPropertyChanged("ProvinceId"); } }
        }

        private String _City;
        /// <summary></summary>
        [DisplayName("City")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "City", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String City
        {
            get { return _City; }
            set { if (OnPropertyChanging("City", value)) { _City = value; OnPropertyChanged("City"); } }
        }

        private String _CityId;
        /// <summary></summary>
        [DisplayName("CityId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "CityId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CityId
        {
            get { return _CityId; }
            set { if (OnPropertyChanging("CityId", value)) { _CityId = value; OnPropertyChanged("CityId"); } }
        }

        private String _Area;
        /// <summary></summary>
        [DisplayName("Area")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "Area", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Area
        {
            get { return _Area; }
            set { if (OnPropertyChanging("Area", value)) { _Area = value; OnPropertyChanged("Area"); } }
        }

        private String _AreaId;
        /// <summary></summary>
        [DisplayName("AreaId")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "AreaId", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String AreaId
        {
            get { return _AreaId; }
            set { if (OnPropertyChanging("AreaId", value)) { _AreaId = value; OnPropertyChanged("AreaId"); } }
        }

        private String _Address;
        /// <summary></summary>
        [DisplayName("Address")]
        [Description("")]
        [DataObjectField(false, false, true, 400)]
        [BindColumn(10, "Address", "", null, "nvarchar(400)", 0, 0, true)]
        public virtual String Address
        {
            get { return _Address; }
            set { if (OnPropertyChanging("Address", value)) { _Address = value; OnPropertyChanged("Address"); } }
        }

        private String _PostCode;
        /// <summary></summary>
        [DisplayName("PostCode")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(11, "PostCode", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String PostCode
        {
            get { return _PostCode; }
            set { if (OnPropertyChanging("PostCode", value)) { _PostCode = value; OnPropertyChanged("PostCode"); } }
        }

        private String _Phone;
        /// <summary></summary>
        [DisplayName("Phone")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "Phone", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Phone
        {
            get { return _Phone; }
            set { if (OnPropertyChanging("Phone", value)) { _Phone = value; OnPropertyChanged("Phone"); } }
        }

        private String _Mobile;
        /// <summary></summary>
        [DisplayName("Mobile")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "Mobile", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Mobile
        {
            get { return _Mobile; }
            set { if (OnPropertyChanging("Mobile", value)) { _Mobile = value; OnPropertyChanged("Mobile"); } }
        }

        private String _Fax;
        /// <summary></summary>
        [DisplayName("Fax")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "Fax", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Fax
        {
            get { return _Fax; }
            set { if (OnPropertyChanging("Fax", value)) { _Fax = value; OnPropertyChanged("Fax"); } }
        }

        private String _Email;
        /// <summary></summary>
        [DisplayName("Email")]
        [Description("")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn(15, "Email", "", null, "nvarchar(200)", 0, 0, true)]
        public virtual String Email
        {
            get { return _Email; }
            set { if (OnPropertyChanging("Email", value)) { _Email = value; OnPropertyChanged("Email"); } }
        }

        private String _DeliverCategory;
        /// <summary></summary>
        [DisplayName("DeliverCategory")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(16, "DeliverCategory", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DeliverCategory
        {
            get { return _DeliverCategory; }
            set { if (OnPropertyChanging("DeliverCategory", value)) { _DeliverCategory = value; OnPropertyChanged("DeliverCategory"); } }
        }

        private Int32 _SortCode;
        /// <summary></summary>
        [DisplayName("SortCode")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(17, "SortCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(18, "DeletionStateCode", "", null, "int", 10, 0, false)]
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
        [BindColumn(19, "Enabled", "", null, "int", 10, 0, false)]
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
        [BindColumn(21, "CreateOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(22, "CreateUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(23, "CreateBy", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(24, "ModifiedOn", "", "getdate()", "smalldatetime", 3, 0, false)]
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
        [BindColumn(25, "ModifiedUserId", "", null, "nvarchar(20)", 0, 0, true)]
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
        [BindColumn(26, "ModifiedBy", "", null, "nvarchar(20)", 0, 0, true)]
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
                    case "RealName" : return _RealName;
                    case "Province" : return _Province;
                    case "ProvinceId" : return _ProvinceId;
                    case "City" : return _City;
                    case "CityId" : return _CityId;
                    case "Area" : return _Area;
                    case "AreaId" : return _AreaId;
                    case "Address" : return _Address;
                    case "PostCode" : return _PostCode;
                    case "Phone" : return _Phone;
                    case "Mobile" : return _Mobile;
                    case "Fax" : return _Fax;
                    case "Email" : return _Email;
                    case "DeliverCategory" : return _DeliverCategory;
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
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "UserId" : _UserId = Convert.ToString(value); break;
                    case "RealName" : _RealName = Convert.ToString(value); break;
                    case "Province" : _Province = Convert.ToString(value); break;
                    case "ProvinceId" : _ProvinceId = Convert.ToString(value); break;
                    case "City" : _City = Convert.ToString(value); break;
                    case "CityId" : _CityId = Convert.ToString(value); break;
                    case "Area" : _Area = Convert.ToString(value); break;
                    case "AreaId" : _AreaId = Convert.ToString(value); break;
                    case "Address" : _Address = Convert.ToString(value); break;
                    case "PostCode" : _PostCode = Convert.ToString(value); break;
                    case "Phone" : _Phone = Convert.ToString(value); break;
                    case "Mobile" : _Mobile = Convert.ToString(value); break;
                    case "Fax" : _Fax = Convert.ToString(value); break;
                    case "Email" : _Email = Convert.ToString(value); break;
                    case "DeliverCategory" : _DeliverCategory = Convert.ToString(value); break;
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
            public static readonly Field RealName = FindByName("RealName");

            ///<summary></summary>
            public static readonly Field Province = FindByName("Province");

            ///<summary></summary>
            public static readonly Field ProvinceId = FindByName("ProvinceId");

            ///<summary></summary>
            public static readonly Field City = FindByName("City");

            ///<summary></summary>
            public static readonly Field CityId = FindByName("CityId");

            ///<summary></summary>
            public static readonly Field Area = FindByName("Area");

            ///<summary></summary>
            public static readonly Field AreaId = FindByName("AreaId");

            ///<summary></summary>
            public static readonly Field Address = FindByName("Address");

            ///<summary></summary>
            public static readonly Field PostCode = FindByName("PostCode");

            ///<summary></summary>
            public static readonly Field Phone = FindByName("Phone");

            ///<summary></summary>
            public static readonly Field Mobile = FindByName("Mobile");

            ///<summary></summary>
            public static readonly Field Fax = FindByName("Fax");

            ///<summary></summary>
            public static readonly Field Email = FindByName("Email");

            ///<summary></summary>
            public static readonly Field DeliverCategory = FindByName("DeliverCategory");

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
    public partial interface IBaseUserAddress
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String UserId { get; set; }

        /// <summary></summary>
        String RealName { get; set; }

        /// <summary></summary>
        String Province { get; set; }

        /// <summary></summary>
        String ProvinceId { get; set; }

        /// <summary></summary>
        String City { get; set; }

        /// <summary></summary>
        String CityId { get; set; }

        /// <summary></summary>
        String Area { get; set; }

        /// <summary></summary>
        String AreaId { get; set; }

        /// <summary></summary>
        String Address { get; set; }

        /// <summary></summary>
        String PostCode { get; set; }

        /// <summary></summary>
        String Phone { get; set; }

        /// <summary></summary>
        String Mobile { get; set; }

        /// <summary></summary>
        String Fax { get; set; }

        /// <summary></summary>
        String Email { get; set; }

        /// <summary></summary>
        String DeliverCategory { get; set; }

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