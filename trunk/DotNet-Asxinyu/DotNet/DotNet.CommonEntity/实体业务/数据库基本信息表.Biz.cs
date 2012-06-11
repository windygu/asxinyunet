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
    /// <summary>数据库基本信息表</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class SystemDb : SystemDb<SystemDb> { }
    
    /// <summary>数据库基本信息表</summary>
    public partial class SystemDb<TEntity> : Entity<TEntity> where TEntity : SystemDb<TEntity>, new()
    {
        #region 对象操作﻿
        static SystemDb()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            //TODO:处理关联删除请求，只标记或禁止使用
			if (Logs != null) Logs.Delete();
			if (Menus != null) Menus.Delete();
			if (Permissions != null) Permissions.Delete();

            return base.OnDelete();
        }
        #endregion

        #region 扩展属性﻿
        [NonSerialized]
		private EntityList<Log> _Logs;
		/// <summary>该数据库基本信息所对应的日志信息集合</summary>
		[XmlIgnore]
		public EntityList<Log> Logs
		{
			get
			{
				if (_Logs == null && Id > 0 && !Dirtys.ContainsKey("Logs"))
                {
					_Logs = Log.FindAllBySystemDbId(Id);
					Dirtys["Logs"] = true;
				}
				return _Logs;
			}
			set { _Logs = value; }
		}

        [NonSerialized]
		private EntityList<Menu> _Menus;
		/// <summary>该数据库基本信息所对应的菜单集合</summary>
		[XmlIgnore]
		public EntityList<Menu> Menus
		{
			get
			{
				if (_Menus == null && Id > 0 && !Dirtys.ContainsKey("Menus"))
                {
					_Menus = Menu.FindAllBySystemDbId(Id);
					Dirtys["Menus"] = true;
				}
				return _Menus;
			}
			set { _Menus = value; }
		}

        [NonSerialized]
		private EntityList<Permission> _Permissions;
		/// <summary>该数据库基本信息所拥有的权限表集合</summary>
		[XmlIgnore]
		public EntityList<Permission> Permissions
		{
			get
			{
				if (_Permissions == null && Id > 0 && !Dirtys.ContainsKey("Permissions"))
                {
					_Permissions = Permission.FindAllBySystemDbId(Id);
					Dirtys["Permissions"] = true;
				}
				return _Permissions;
			}
			set { _Permissions = value; }
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

        /// <summary>根据数据库名称查找</summary>
        /// <param name="databasename">数据库名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByDataBaseName(String databasename)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.DataBaseName, databasename);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.DataBaseName, databasename);
        }

        /// <summary>根据数据库名称、表名称查找</summary>
        /// <param name="databasename">数据库名称</param>
        /// <param name="tablename">表名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByDataBaseNameAndTableName(String databasename, String tablename)
        {
            if (Meta.Count >= 1000)
                return FindAll(new String[] { _.DataBaseName, _.TableName }, new Object[] { databasename, tablename });
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(e => e.DataBaseName == databasename && e.TableName == tablename);
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