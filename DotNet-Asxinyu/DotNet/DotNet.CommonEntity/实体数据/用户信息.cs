﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>用户信息</summary>
    [Serializable]
    [DataObject]
    [Description("用户信息")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("StaffId", false, "StaffId")]
    [BindIndex("UserRole", false, "UserName,RoleId")]
    [BindIndex("StaffRole", false, "StaffId,RoleId")]
    [BindIndex("IX_User_RoleId", false, "RoleId")]
    [BindRelation("Id", true, "Log", "UserId")]
    [BindRelation("RoleId", false, "Role", "Id")]
    [BindRelation("StaffId", false, "Staff", "Id")]
    [BindRelation("Id", true, "UserPermission", "UserId")]
    [BindRelation("Id", true, "UserProfile", "UserId")]
    [BindRelation("Id", true, "UserRole", "UserId")]
    [BindTable("User", Description = "用户信息", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class User<TEntity> : IUser
    {
        #region 属性
        private Int32 _Id;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } }
        }

        private Int32 _StaffId;
        /// <summary>员工编号</summary>
        [DisplayName("员工编号")]
        [Description("员工编号")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "StaffId", "员工编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 StaffId
        {
            get { return _StaffId; }
            set { if (OnPropertyChanging("StaffId", value)) { _StaffId = value; OnPropertyChanged("StaffId"); } }
        }

        private String _UserName;
        /// <summary>用户名</summary>
        [DisplayName("用户名")]
        [Description("用户名")]
        [DataObjectField(false, false, false, 30)]
        [BindColumn(3, "UserName", "用户名", null, "varchar(30)", 0, 0, false)]
        public virtual String UserName
        {
            get { return _UserName; }
            set { if (OnPropertyChanging("UserName", value)) { _UserName = value; OnPropertyChanged("UserName"); } }
        }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(4, "Password", "密码", null, "varchar(50)", 0, 0, false)]
        public virtual String Password
        {
            get { return _Password; }
            set { if (OnPropertyChanging("Password", value)) { _Password = value; OnPropertyChanged("Password"); } }
        }

        private Int32 _RoleId;
        /// <summary>角色编号</summary>
        [DisplayName("角色编号")]
        [Description("角色编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(5, "RoleId", "角色编号", null, "int(20)", 10, 0, false)]
        public virtual Int32 RoleId
        {
            get { return _RoleId; }
            set { if (OnPropertyChanging("RoleId", value)) { _RoleId = value; OnPropertyChanged("RoleId"); } }
        }

        private Int32 _SortCode;
        /// <summary>排序码</summary>
        [DisplayName("排序码")]
        [Description("排序码")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "SortCode", "排序码", null, "int(10)", 10, 0, false)]
        public virtual Int32 SortCode
        {
            get { return _SortCode; }
            set { if (OnPropertyChanging("SortCode", value)) { _SortCode = value; OnPropertyChanged("SortCode"); } }
        }

        private SByte _IsEnable;
        /// <summary>是否有效</summary>
        [DisplayName("是否有效")]
        [Description("是否有效")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(7, "IsEnable", "是否有效", "1", "tinyint(4)", 3, 0, false)]
        public virtual SByte IsEnable
        {
            get { return _IsEnable; }
            set { if (OnPropertyChanging("IsEnable", value)) { _IsEnable = value; OnPropertyChanged("IsEnable"); } }
        }

        private SByte _DeletionStatusCode;
        /// <summary>删除标志</summary>
        [DisplayName("删除标志")]
        [Description("删除标志")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(8, "DeletionStatusCode", "删除标志", "0", "tinyint(4)", 3, 0, false)]
        public virtual SByte DeletionStatusCode
        {
            get { return _DeletionStatusCode; }
            set { if (OnPropertyChanging("DeletionStatusCode", value)) { _DeletionStatusCode = value; OnPropertyChanged("DeletionStatusCode"); } }
        }

        private String _Description;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "Description", "备注", "", "varchar(50)", 0, 0, false)]
        public virtual String Description
        {
            get { return _Description; }
            set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } }
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
                    case "StaffId" : return _StaffId;
                    case "UserName" : return _UserName;
                    case "Password" : return _Password;
                    case "RoleId" : return _RoleId;
                    case "SortCode" : return _SortCode;
                    case "IsEnable" : return _IsEnable;
                    case "DeletionStatusCode" : return _DeletionStatusCode;
                    case "Description" : return _Description;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "StaffId" : _StaffId = Convert.ToInt32(value); break;
                    case "UserName" : _UserName = Convert.ToString(value); break;
                    case "Password" : _Password = Convert.ToString(value); break;
                    case "RoleId" : _RoleId = Convert.ToInt32(value); break;
                    case "SortCode" : _SortCode = Convert.ToInt32(value); break;
                    case "IsEnable" : _IsEnable = Convert.ToSByte(value); break;
                    case "DeletionStatusCode" : _DeletionStatusCode = Convert.ToSByte(value); break;
                    case "Description" : _Description = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户信息字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>员工编号</summary>
            public static readonly Field StaffId = FindByName("StaffId");

            ///<summary>用户名</summary>
            public static readonly Field UserName = FindByName("UserName");

            ///<summary>密码</summary>
            public static readonly Field Password = FindByName("Password");

            ///<summary>角色编号</summary>
            public static readonly Field RoleId = FindByName("RoleId");

            ///<summary>排序码</summary>
            public static readonly Field SortCode = FindByName("SortCode");

            ///<summary>是否有效</summary>
            public static readonly Field IsEnable = FindByName("IsEnable");

            ///<summary>删除标志</summary>
            public static readonly Field DeletionStatusCode = FindByName("DeletionStatusCode");

            ///<summary>备注</summary>
            public static readonly Field Description = FindByName("Description");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>用户信息接口</summary>
    public partial interface IUser
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>员工编号</summary>
        Int32 StaffId { get; set; }

        /// <summary>用户名</summary>
        String UserName { get; set; }

        /// <summary>密码</summary>
        String Password { get; set; }

        /// <summary>角色编号</summary>
        Int32 RoleId { get; set; }

        /// <summary>排序码</summary>
        Int32 SortCode { get; set; }

        /// <summary>是否有效</summary>
        SByte IsEnable { get; set; }

        /// <summary>删除标志</summary>
        SByte DeletionStatusCode { get; set; }

        /// <summary>备注</summary>
        String Description { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}