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
    /// <summary>系统设置表</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class Setting : Setting<Setting> { }
    
    /// <summary>系统设置表</summary>
    public partial class Setting<TEntity> : Entity<TEntity> where TEntity : Setting<TEntity>, new()
    {
        #region 对象操作﻿
        static Setting()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        #endregion

        #region 扩展属性﻿
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

        /// <summary>根据系统编号查找</summary>
        /// <param name="systemid">系统编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByParentId(Int32 parentId)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.ParentId, parentId);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.ParentId, parentId);
        }

        /// <summary>根据系统编号、名称查找</summary>
        /// <param name="systemid">系统编号</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllBySystemIdAndName(Int32 systemid, String name)
        {
            if (Meta.Count >= 1000)
                return FindAll(new String[] { _.SystemId, _.Name }, new Object[] { systemid, name });
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(e => e.SystemId == systemid && e.Name == name);
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