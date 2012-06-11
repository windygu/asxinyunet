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
    /// <summary>角色表</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class Role : Role<Role> { }
    
    /// <summary>角色表</summary>
    public partial class Role<TEntity> : Entity<TEntity> where TEntity : Role<TEntity>, new()
    {
        #region 对象操作﻿
        static Role()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        
        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
			if (RolePermissions != null) RolePermissions.Delete();
            //TODO:不能删除用户,更改为其他普通的权限，需建立一个基本角色，用于初始化基本操作
            //if (Users != null) Users.Delete();
			if (UserRoles != null) UserRoles.Delete();
            return base.OnDelete();
        }     
        #endregion

        #region 扩展属性﻿
        [NonSerialized]
        private Organize _Organize;
        /// <summary>该角色所对应的组织部门信息</summary>
        [XmlIgnore]
        public Organize Organize
        {
            get
            {
                if (_Organize == null && OrganizeId > 0 && !Dirtys.ContainsKey("Organize"))
                {
                    _Organize = Organize.FindById(OrganizeId);
                    Dirtys["Organize"] = true;
                }
                return _Organize;
            }
            set { _Organize = value; }
        }

        [NonSerialized]
		private EntityList<RolePermission> _RolePermissions;
		/// <summary>该角色所拥有的所有权限集合</summary>
		[XmlIgnore]
		public EntityList<RolePermission> RolePermissions
		{
			get
			{
				if (_RolePermissions == null && Id > 0 && !Dirtys.ContainsKey("RolePermissions"))
                {
					_RolePermissions = RolePermission.FindAllByRoleId(Id);
					Dirtys["RolePermissions"] = true;
				}
				return _RolePermissions;
			}
			set { _RolePermissions = value; }
		}
       
        [NonSerialized]
		private EntityList<UserRole> _UserRoles;
		/// <summary>该角色所拥有的所有用户集合</summary>
		[XmlIgnore]
		public EntityList<UserRole> UserRoles
		{
			get
			{
				if (_UserRoles == null && Id > 0 && !Dirtys.ContainsKey("UserRoles"))
                {
					_UserRoles = UserRole.FindAllByRoleId(Id);
					Dirtys["UserRoles"] = true;
				}
				return _UserRoles;
			}
			set { _UserRoles = value; }
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

        /// <summary>根据系统编号查找</summary>
        /// <param name="systemid">系统编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllBySystemId(Int32 systemid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.SystemId, systemid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.SystemId, systemid);
        }

        /// <summary>根据部门编号查找</summary>
        /// <param name="organizeid">部门编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByOrganizeId(Int32 organizeid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.OrganizeId, organizeid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.OrganizeId, organizeid);
        }

        /// <summary>根据系统编号、部门编号查找</summary>
        /// <param name="systemid">系统编号</param>
        /// <param name="organizeid">部门编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllBySystemIdAndOrganizeId(Int32 systemid, Int32 organizeid)
        {
            if (Meta.Count >= 1000)
                return FindAll(new String[] { _.SystemId, _.OrganizeId }, new Object[] { systemid, organizeid });
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(e => e.SystemId == systemid && e.OrganizeId == organizeid);
        }
        #endregion

        #region 高级查询
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