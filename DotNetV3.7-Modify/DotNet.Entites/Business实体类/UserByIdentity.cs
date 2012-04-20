/*
 * XCoder v4.7.4486.37599
 * 作者：Administrator/WIN-7ZX6E2GYT38
 * 时间：2012-04-20 08:40:35
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
    /// <summary>Usersandglobalprivileges由标识</summary>
    [Serializable]
    [DataObject]
    [Description("Usersandglobalprivileges由标识")]
    [BindIndex("PK_USERBYIDENTITY", true, "ID")]
    [BindTable("UserByIdentity", Description = "Usersandglobalprivileges由标识", ConnName = "BusinessDbConnection", DbType = DatabaseType.SqlServer)]
    public partial class UserByIdentity : IUserByIdentity
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "编号", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
        }

        private String _FullName;
        /// <summary>会议全称</summary>
        [DisplayName("会议全称")]
        [Description("会议全称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "FullName", "会议全称", null, "nvarchar(50)", 0, 0, true)]
        public virtual String FullName
        {
            get { return _FullName; }
            set { if (OnPropertyChanging("FullName", value)) { _FullName = value; OnPropertyChanged("FullName"); } }
        }

        private Decimal _Salary;
        /// <summary>每月薪金</summary>
        [DisplayName("每月薪金")]
        [Description("每月薪金")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "Salary", "每月薪金", "0", "numeric(10,2)", 10, 2, false)]
        public virtual Decimal Salary
        {
            get { return _Salary; }
            set { if (OnPropertyChanging("Salary", value)) { _Salary = value; OnPropertyChanged("Salary"); } }
        }

        private Int32 _Age;
        /// <summary>年龄</summary>
        [DisplayName("年龄")]
        [Description("年龄")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "Age", "年龄", "0", "int", 10, 0, false)]
        public virtual Int32 Age
        {
            get { return _Age; }
            set { if (OnPropertyChanging("Age", value)) { _Age = value; OnPropertyChanged("Age"); } }
        }

        private DateTime _Birthday;
        /// <summary>生日</summary>
        [DisplayName("生日")]
        [Description("生日")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "Birthday", "生日", "getdate()", "smalldatetime", 3, 0, false)]
        public virtual DateTime Birthday
        {
            get { return _Birthday; }
            set { if (OnPropertyChanging("Birthday", value)) { _Birthday = value; OnPropertyChanged("Birthday"); } }
        }

        private Byte[] _Photo;
        /// <summary>相片</summary>
        [DisplayName("相片")]
        [Description("相片")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(6, "Photo", "相片", null, "image", 0, 0, false)]
        public virtual Byte[] Photo
        {
            get { return _Photo; }
            set { if (OnPropertyChanging("Photo", value)) { _Photo = value; OnPropertyChanged("Photo"); } }
        }

        private Int32 _AllowEdit;
        /// <summary>允许编辑</summary>
        [DisplayName("允许编辑")]
        [Description("允许编辑")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(7, "AllowEdit", "允许编辑", "1", "int", 10, 0, false)]
        public virtual Int32 AllowEdit
        {
            get { return _AllowEdit; }
            set { if (OnPropertyChanging("AllowEdit", value)) { _AllowEdit = value; OnPropertyChanged("AllowEdit"); } }
        }

        private Int32 _AllowDelete;
        /// <summary>允许删除</summary>
        [DisplayName("允许删除")]
        [Description("允许删除")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(8, "AllowDelete", "允许删除", "1", "int", 10, 0, false)]
        public virtual Int32 AllowDelete
        {
            get { return _AllowDelete; }
            set { if (OnPropertyChanging("AllowDelete", value)) { _AllowDelete = value; OnPropertyChanged("AllowDelete"); } }
        }

        private Int32 _SortCode;
        /// <summary>排序号</summary>
        [DisplayName("排序号")]
        [Description("排序号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(9, "SortCode", "排序号", null, "int", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private Int32 _Enabled;
        /// <summary>是否可用</summary>
        [DisplayName("是否可用")]
        [Description("是否可用")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "Enabled", "是否可用", "1", "int", 10, 0, false)]
        public virtual Int32 Enabled
        {
            get { return _Enabled; }
            set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } }
        }

        private Int32 _DeletionStateCode;
        /// <summary>用户是否删除</summary>
        [DisplayName("用户是否删除")]
        [Description("用户是否删除")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "DeletionStateCode", "用户是否删除", "0", "int", 10, 0, false)]
        public virtual Int32 DeletionStateCode
        {
            get { return _DeletionStateCode; }
            set { if (OnPropertyChanging("DeletionStateCode", value)) { _DeletionStateCode = value; OnPropertyChanged("DeletionStateCode"); } }
        }

        private String _Description;
        /// <summary>描述</summary>
        [DisplayName("描述")]
        [Description("描述")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "Description", "描述", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
        }

        private DateTime _CreateOn;
        /// <summary>创建上</summary>
        [DisplayName("创建上")]
        [Description("创建上")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "CreateOn", "创建上", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime CreateOn
        {
            get { return _CreateOn; }
            set { if (OnPropertyChanging("CreateOn", value)) { _CreateOn = value; OnPropertyChanged("CreateOn"); } }
        }

        private String _CreateUserId;
        /// <summary>创建人ID</summary>
        [DisplayName("创建人ID")]
        [Description("创建人ID")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(14, "CreateUserId", "创建人ID", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateUserId
        {
            get { return _CreateUserId; }
            set { if (OnPropertyChanging("CreateUserId", value)) { _CreateUserId = value; OnPropertyChanged("CreateUserId"); } }
        }

        private String _CreateBy;
        /// <summary>创建由</summary>
        [DisplayName("创建由")]
        [Description("创建由")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(15, "CreateBy", "创建由", null, "nvarchar(50)", 0, 0, true)]
        public virtual String CreateBy
        {
            get { return _CreateBy; }
            set { if (OnPropertyChanging("CreateBy", value)) { _CreateBy = value; OnPropertyChanged("CreateBy"); } }
        }

        private DateTime _ModifiedOn;
        /// <summary>修改日期</summary>
        [DisplayName("修改日期")]
        [Description("修改日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(16, "ModifiedOn", "修改日期", null, "smalldatetime", 3, 0, false)]
        public virtual DateTime ModifiedOn
        {
            get { return _ModifiedOn; }
            set { if (OnPropertyChanging("ModifiedOn", value)) { _ModifiedOn = value; OnPropertyChanged("ModifiedOn"); } }
        }

        private String _ModifiedUserId;
        /// <summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
        [DisplayName("修改标识1修改0没修改Usersandglobalprivileges编号")]
        [Description("修改标识1修改0没修改Usersandglobalprivileges编号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(17, "ModifiedUserId", "修改标识1修改0没修改Usersandglobalprivileges编号", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ModifiedUserId
        {
            get { return _ModifiedUserId; }
            set { if (OnPropertyChanging("ModifiedUserId", value)) { _ModifiedUserId = value; OnPropertyChanged("ModifiedUserId"); } }
        }

        private String _ModifiedBy;
        /// <summary>修改者</summary>
        [DisplayName("修改者")]
        [Description("修改者")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(18, "ModifiedBy", "修改者", null, "nvarchar(50)", 0, 0, true)]
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
                    case "ID" : return _ID;
                    case "FullName" : return _FullName;
                    case "Salary" : return _Salary;
                    case "Age" : return _Age;
                    case "Birthday" : return _Birthday;
                    case "Photo" : return _Photo;
                    case "AllowEdit" : return _AllowEdit;
                    case "AllowDelete" : return _AllowDelete;
                    case "SortCode" : return _SortCode;
                    case "Enabled" : return _Enabled;
                    case "DeletionStateCode" : return _DeletionStateCode;
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
                    case "ID" : _ID = Convert.ToInt32(value); break;
                    case "FullName" : _FullName = Convert.ToString(value); break;
                    case "Salary" : _Salary = Convert.ToDecimal(value); break;
                    case "Age" : _Age = Convert.ToInt32(value); break;
                    case "Birthday" : _Birthday = Convert.ToDateTime(value); break;
                    case "Photo" : _Photo = (Byte[])value; break;
                    case "AllowEdit" : _AllowEdit = Convert.ToInt32(value); break;
                    case "AllowDelete" : _AllowDelete = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "Enabled" : _Enabled = Convert.ToInt32(value); break;
                    case "DeletionStateCode" : _DeletionStateCode = Convert.ToInt32(value); break;
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
        /// <summary>取得Usersandglobalprivileges由标识字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field ID = FindByName("ID");

            ///<summary>会议全称</summary>
            public static readonly Field FullName = FindByName("FullName");

            ///<summary>每月薪金</summary>
            public static readonly Field Salary = FindByName("Salary");

            ///<summary>年龄</summary>
            public static readonly Field Age = FindByName("Age");

            ///<summary>生日</summary>
            public static readonly Field Birthday = FindByName("Birthday");

            ///<summary>相片</summary>
            public static readonly Field Photo = FindByName("Photo");

            ///<summary>允许编辑</summary>
            public static readonly Field AllowEdit = FindByName("AllowEdit");

            ///<summary>允许删除</summary>
            public static readonly Field AllowDelete = FindByName("AllowDelete");

            ///<summary>排序号</summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary>是否可用</summary>
            public static readonly Field Enabled = FindByName("Enabled");

            ///<summary>用户是否删除</summary>
            public static readonly Field DeletionStateCode = FindByName("DeletionStateCode");

            ///<summary>描述</summary>
            public static readonly Field Description = FindByName("Description");

            ///<summary>创建上</summary>
            public static readonly Field CreateOn = FindByName("CreateOn");

            ///<summary>创建人ID</summary>
            public static readonly Field CreateUserId = FindByName("CreateUserId");

            ///<summary>创建由</summary>
            public static readonly Field CreateBy = FindByName("CreateBy");

            ///<summary>修改日期</summary>
            public static readonly Field ModifiedOn = FindByName("ModifiedOn");

            ///<summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
            public static readonly Field ModifiedUserId = FindByName("ModifiedUserId");

            ///<summary>修改者</summary>
            public static readonly Field ModifiedBy = FindByName("ModifiedBy");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>Usersandglobalprivileges由标识接口</summary>
    public partial interface IUserByIdentity
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>会议全称</summary>
        String FullName { get; set; }

        /// <summary>每月薪金</summary>
        Decimal Salary { get; set; }

        /// <summary>年龄</summary>
        Int32 Age { get; set; }

        /// <summary>生日</summary>
        DateTime Birthday { get; set; }

        /// <summary>相片</summary>
        Byte[] Photo { get; set; }

        /// <summary>允许编辑</summary>
        Int32 AllowEdit { get; set; }

        /// <summary>允许删除</summary>
        Int32 AllowDelete { get; set; }

        /// <summary>排序号</summary>
        Int32 SortCode { get; set; }

        /// <summary>是否可用</summary>
        Int32 Enabled { get; set; }

        /// <summary>用户是否删除</summary>
        Int32 DeletionStateCode { get; set; }

        /// <summary>描述</summary>
        String Description { get; set; }

        /// <summary>创建上</summary>
        DateTime CreateOn { get; set; }

        /// <summary>创建人ID</summary>
        String CreateUserId { get; set; }

        /// <summary>创建由</summary>
        String CreateBy { get; set; }

        /// <summary>修改日期</summary>
        DateTime ModifiedOn { get; set; }

        /// <summary>修改标识1修改0没修改Usersandglobalprivileges编号</summary>
        String ModifiedUserId { get; set; }

        /// <summary>修改者</summary>
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