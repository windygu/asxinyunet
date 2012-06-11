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
    /// <summary>组织部门信息表</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class Organize : Organize<Organize> { }
    
    /// <summary>组织部门信息表</summary>
    public partial class Organize<TEntity> : EntityTree<TEntity> where TEntity : Organize<TEntity>, new()
    {
        #region 对象操作﻿
        static Organize()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }        
        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            //TODO:处理关联删除
			if (Roles != null) Roles.Delete();
			if (Staffs != null) Staffs.Delete();
            return base.OnDelete();
        }
        #endregion

        #region 扩展属性﻿
        [NonSerialized]
		private EntityList<Role> _Roles;
		/// <summary>该组织部门所拥有的角色表集合</summary>
		[XmlIgnore]
		public EntityList<Role> Roles
		{
			get
			{
				if (_Roles == null && Id > 0 && !Dirtys.ContainsKey("Roles"))
                {
					_Roles = Role.FindAllByOrganizeId(Id);
					Dirtys["Roles"] = true;
				}
				return _Roles;
			}
			set { _Roles = value; }
		}

        [NonSerialized]
		private EntityList<Staff> _Staffs;
		/// <summary>该组织部门所拥有的员工集合</summary>
		[XmlIgnore]
		public EntityList<Staff> Staffs
		{
			get
			{
				if (_Staffs == null && Id > 0 && !Dirtys.ContainsKey("Staffs"))
                {
					_Staffs = Staff.FindAllByOrganizeId(Id);
					Dirtys["Staffs"] = true;
				}
				return _Staffs;
			}
			set { _Staffs = value; }
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

        /// <summary>根据组织代码查找</summary>
        /// <param name="organizecode">组织代码</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindAllByOrganizeCode(String organizecode)
        {
            if (Meta.Count >= 1000)
                return Find(_.OrganizeCode, organizecode);
            else // 实体缓存
                return Meta.Cache.Entities.Find(_.OrganizeCode, organizecode);
        }

        /// <summary>根据简称查找</summary>
        /// <param name="shortname">简称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByShortName(String shortname)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.ShortName, shortname);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.ShortName, shortname);
        }

        /// <summary>根据组织名称查找</summary>
        /// <param name="fullname">组织名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByFullName(String fullname)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.FullName, fullname);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.FullName, fullname);
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