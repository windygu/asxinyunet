﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace DotNet.CommonEntity
{
    /// <summary>用户权限表</summary>
    [Serializable]
    [DataObject]
    [Description("用户权限表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("UserPermission", false, "PermissionId,UserId")]
    [BindIndex("UserId", false, "UserId")]
    [BindIndex("PermissionId", false, "PermissionId")]
    [BindRelation("PermissionId", false, "Permission", "Id")]
    [BindRelation("UserId", false, "User", "Id")]
    [BindRelation("PermissionId", false, "Permission", "Id")]
    [BindRelation("UserId", false, "User", "Id")]
    [BindTable("UserPermission", Description = "用户权限表", ConnName = "DotNetCommon", DbType = DatabaseType.MySql)]
    public partial class UserPermission<TEntity> : IUserPermission
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

        private Int32 _PermissionId;
        /// <summary>权限编号</summary>
        [DisplayName("权限编号")]
        [Description("权限编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(2, "PermissionId", "权限编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 PermissionId
        {
            get { return _PermissionId; }
            set { if (OnPropertyChanging("PermissionId", value)) { _PermissionId = value; OnPropertyChanged("PermissionId"); } }
        }

        private Int32 _UserId;
        /// <summary>用户编号</summary>
        [DisplayName("用户编号")]
        [Description("用户编号")]
        [DataObjectField(false, false, false, 10)]
        [BindColumn(3, "UserId", "用户编号", null, "int(11)", 10, 0, false)]
        public virtual Int32 UserId
        {
            get { return _UserId; }
            set { if (OnPropertyChanging("UserId", value)) { _UserId = value; OnPropertyChanged("UserId"); } }
        }

        private SByte _IsEnable;
        /// <summary>是否有效</summary>
        [DisplayName("是否有效")]
        [Description("是否有效")]
        [DataObjectField(false, false, false, 3)]
        [BindColumn(4, "IsEnable", "是否有效", "1", "tinyint(4)", 3, 0, false)]
        public virtual SByte IsEnable
        {
            get { return _IsEnable; }
            set { if (OnPropertyChanging("IsEnable", value)) { _IsEnable = value; OnPropertyChanged("IsEnable"); } }
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
                    case "PermissionId" : return _PermissionId;
                    case "UserId" : return _UserId;
                    case "IsEnable" : return _IsEnable;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id" : _Id = Convert.ToInt32(value); break;
                    case "PermissionId" : _PermissionId = Convert.ToInt32(value); break;
                    case "UserId" : _UserId = Convert.ToInt32(value); break;
                    case "IsEnable" : _IsEnable = Convert.ToSByte(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户权限表字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>编号</summary>
            public static readonly Field Id = FindByName("Id");

            ///<summary>权限编号</summary>
            public static readonly Field PermissionId = FindByName("PermissionId");

            ///<summary>用户编号</summary>
            public static readonly Field UserId = FindByName("UserId");

            ///<summary>是否有效</summary>
            public static readonly Field IsEnable = FindByName("IsEnable");

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }
        #endregion
    }

    /// <summary>用户权限表接口</summary>
    public partial interface IUserPermission
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 Id { get; set; }

        /// <summary>权限编号</summary>
        Int32 PermissionId { get; set; }

        /// <summary>用户编号</summary>
        Int32 UserId { get; set; }

        /// <summary>是否有效</summary>
        SByte IsEnable { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}