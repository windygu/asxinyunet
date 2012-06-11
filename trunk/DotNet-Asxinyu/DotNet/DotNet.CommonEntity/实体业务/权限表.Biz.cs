﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using XCode;
using XCode.Configuration;

namespace DotNet.CommonEntity
{
    /// <summary>权限表</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class Permission : Permission<Permission> { }
    
    /// <summary>权限表</summary>
    public partial class Permission<TEntity> : EntityTree<TEntity> where TEntity : Permission<TEntity>, new()
    {
        #region 对象操作﻿
        static Permission()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            //TODO:不物理删除，只更改状态值
			if (RolePermissions != null) RolePermissions.Delete();
			if (UserPermissions != null) UserPermissions.Delete();
            return base.OnDelete();
        }
        #endregion

        #region 扩展属性﻿
        [NonSerialized]
        private SystemDb _SystemDb;
        /// <summary>该权限所对应的数据库基本信息</summary>
        [XmlIgnore]
        public SystemDb SystemDb
        {
            get
            {
                if (_SystemDb == null && SystemDbId > 0 && !Dirtys.ContainsKey("SystemDb"))
                {
                    _SystemDb = SystemDb.FindById(SystemDbId);
                    Dirtys["SystemDb"] = true;
                }
                return _SystemDb;
            }
            set { _SystemDb = value; }
        }

        [NonSerialized]
		private EntityList<RolePermission> _RolePermissions;
		/// <summary>与该权限相关的角色权限集合</summary>
		[XmlIgnore]
		public EntityList<RolePermission> RolePermissions
		{
			get
			{
				if (_RolePermissions == null && Id > 0 && !Dirtys.ContainsKey("RolePermissions"))
                {
					_RolePermissions = RolePermission.FindAllByPermissionId(Id);
					Dirtys["RolePermissions"] = true;
				}
				return _RolePermissions;
			}
			set { _RolePermissions = value; }
		}

        [NonSerialized]
		private EntityList<UserPermission> _UserPermissions;
		/// <summary>与该权限相关的用户权限集合</summary>
		[XmlIgnore]
		public EntityList<UserPermission> UserPermissions
		{
			get
			{
				if (_UserPermissions == null && Id > 0 && !Dirtys.ContainsKey("UserPermissions"))
                {
					_UserPermissions = UserPermission.FindAllByPermissionId(Id);
					Dirtys["UserPermissions"] = true;
				}
				return _UserPermissions;
			}
			set { _UserPermissions = value; }
		}
        #endregion

        #region 扩展查询﻿
        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindById(Int32 id)
        {
            if (Meta.Count >= 1000)
                return Find(_.Id, id);
            else // 实体缓存
                return Meta.Cache.Entities.Find(_.Id, id);        
        }

        /// <summary>根据表编号查找</summary>
        /// <param name="systemdbid">表编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllBySystemDbId(Int32 systemdbid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.SystemDbId, systemdbid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.SystemDbId, systemdbid);
        }

        /// <summary>根据权限名称查找</summary>
        /// <param name="name">权限名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByName(String name)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.Name, name);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.Name, name);
        }
        /// <summary>根据父编号查找</summary>
        /// <param name="name">父编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByParentId(String parentId)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.ParentId,parentId);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.ParentId, parentId);
        }
        #endregion

        #region 高级查询
        /// <summary>
        /// 构造搜索条件
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        private static String SearchWhere(String key)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            WhereExpression exp = new WhereExpression();
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            if (!String.IsNullOrEmpty(key)) SearchWhereByKeys(exp.Builder, key);
            return exp;
        }
        #endregion

        #region 扩展操作
        #endregion

        #region 业务
        #endregion
    }
}