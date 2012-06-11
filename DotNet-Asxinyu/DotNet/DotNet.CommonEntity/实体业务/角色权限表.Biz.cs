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
    /// <summary>角色权限表</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class RolePermission : RolePermission<RolePermission> { }
    
    /// <summary>角色权限表</summary>
    public partial class RolePermission<TEntity> : Entity<TEntity> where TEntity : RolePermission<TEntity>, new()
    {
        #region 对象操作﻿
        static RolePermission()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        #endregion

        #region 扩展属性﻿
        [NonSerialized]
        private Permission _Permission;
        /// <summary>该角色权限所对应的权限对象</summary>
        [XmlIgnore]
        public Permission Permission
        {
            get
            {
                if (_Permission == null && PermissionId > 0 && !Dirtys.ContainsKey("Permission"))
                {
                    _Permission = Permission.FindById(PermissionId);
                    Dirtys["Permission"] = true;
                }
                return _Permission;
            }
            set { _Permission = value; }
        }

        /// <summary>该角色权限所对应的权限表权限名称</summary>
        [XmlIgnore]
        public String PermissionName { get { return Permission != null ? Permission.Name : null; } }

        [NonSerialized]
        private Role _Role;
        /// <summary>该角色权限所对应的角色对象</summary>
        [XmlIgnore]
        public Role Role
        {
            get
            {
                if (_Role == null && RoleId > 0 && !Dirtys.ContainsKey("Role"))
                {
                    _Role = Role.FindById(RoleId);
                    Dirtys["Role"] = true;
                }
                return _Role;
            }
            set { _Role = value; }
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
            // 单对象缓存
            //return Meta.SingleCache[id];
        }

        /// <summary>根据用户编号、权限编号查找对象</summary>
        /// <param name="roleid">角色编号</param>
        /// <param name="permissionid">权限编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindAllByRoleIdAndPermissionId(Int32 roleid, Int32 permissionid)
        {
            if (Meta.Count >= 1000)
                return Find(new String[] { _.RoleId, _.PermissionId }, new Object[] { roleid, permissionid });
            else // 实体缓存
                return Meta.Cache.Entities.Find(e => e.RoleId == roleid && e.PermissionId == permissionid);
        }

        /// <summary>根据权限编号查找</summary>
        /// <param name="permissionid">权限编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByPermissionId(Int32 permissionid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.PermissionId, permissionid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.PermissionId, permissionid);
        }

        /// <summary>根据角色编号查找</summary>
        /// <param name="roleid">用户编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByRoleId(Int32 roleid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.RoleId, roleid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.RoleId, roleid);
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