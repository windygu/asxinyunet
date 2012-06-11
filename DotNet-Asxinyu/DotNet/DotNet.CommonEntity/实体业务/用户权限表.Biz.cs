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
    /// <summary>用户权限表</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class UserPermission : UserPermission<UserPermission> { }
    
    /// <summary>用户权限表</summary>
    public partial class UserPermission<TEntity> : Entity<TEntity> where TEntity : UserPermission<TEntity>, new()
    {
        #region 对象操作﻿
        static UserPermission()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        #endregion

        #region 扩展属性﻿
        [NonSerialized]
        private Permission _Permission;
        /// <summary>该用户权限对象所对应的权限对象</summary>
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

        /// <summary>该用户权限对象所对应的权限名称</summary>
        [XmlIgnore]
        public String PermissionName { get { return Permission != null ? Permission.Name : null; } }

        [NonSerialized]
        private User _User;
        /// <summary>该用户权限对象所对应的用户信息</summary>
        [XmlIgnore]
        public User User
        {
            get
            {
                if (_User == null && UserId > 0 && !Dirtys.ContainsKey("User"))
                {
                    _User = User.FindById(UserId);
                    Dirtys["User"] = true;
                }
                return _User;
            }
            set { _User = value; }
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

        /// <summary>根据权限编号、用户编号查找</summary>
        /// <param name="permissionid">权限编号</param>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindByPermissionIdAndUserId(Int32 permissionid, Int32 userid)
        {
            if (Meta.Count >= 1000)
                return Find(new String[] { _.PermissionId, _.UserId }, new Object[] { permissionid, userid });
            else // 实体缓存
                return Meta.Cache.Entities.Find(e => e.PermissionId == permissionid && e.UserId == userid);
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

        /// <summary>根据用户编号查找</summary>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByUserId(Int32 userid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.UserId, userid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.UserId, userid);
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