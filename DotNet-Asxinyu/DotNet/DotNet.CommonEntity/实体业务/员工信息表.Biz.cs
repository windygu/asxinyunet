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
    /// <summary>员工信息表</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class Staff : Staff<Staff> { }
    
    /// <summary>员工信息表</summary>
    public partial class Staff<TEntity> : Entity<TEntity> where TEntity : Staff<TEntity>, new()
    {
        #region 对象操作﻿
        static Staff()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
			if (Users != null) Users.Delete();

            return base.OnDelete();
        }
        #endregion

        #region 扩展属性﻿
        [NonSerialized]
        private Organize _Organize;
        /// <summary>该员工信息表所对应的组织部门信息表</summary>
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
		private EntityList<User> _Users;
		/// <summary>该员工信息表所拥有的用户信息集合</summary>
		[XmlIgnore]
		public EntityList<User> Users
		{
			get
			{
				if (_Users == null && Id > 0 && !Dirtys.ContainsKey("Users"))
                {
					_Users = User.FindAllByStaffId(Id);
					Dirtys["Users"] = true;
				}
				return _Users;
			}
			set { _Users = value; }
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

        /// <summary>根据组织编号查找</summary>
        /// <param name="organizeid">组织编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByOrganizeId(Int32 organizeid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.OrganizeId, organizeid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.OrganizeId, organizeid);
        }

        /// <summary>根据用户名查找</summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByUserName(String username)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.UserName, username);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.UserName, username);
        }

        /// <summary>根据工号查找</summary>
        /// <param name="code">工号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindAByCode(String code)
        {
            if (Meta.Count >= 1000)
                return Find(_.Code, code);
            else // 实体缓存
                return Meta.Cache.Entities.Find(_.Code, code);
        }

        /// <summary>根据身份证号查找</summary>
        /// <param name="idcard">身份证号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindAllByIdCard(String idcard)
        {
            if (Meta.Count >= 1000)
                return Find(_.IdCard, idcard);
            else // 实体缓存
                return Meta.Cache.Entities.Find(_.IdCard, idcard);
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