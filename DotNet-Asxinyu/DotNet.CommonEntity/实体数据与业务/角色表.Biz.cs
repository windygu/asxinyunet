using System;
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
    public partial class Role<TEntity> : Entity<TEntity> where TEntity : Role<TEntity>, new()
    {
        #region 对象操作
        static Role()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }       
        #endregion

        #region 扩展属性
        [NonSerialized]
		private EntityList<RolePermission> _RolePermissions;
		/// <summary>该角色表所拥有的角色权限表集合</summary>
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
		/// <summary>该角色表所拥有的用户角色表集合</summary>
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

        #region 扩展查询
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

        /// <summary>根据角色名称查找</summary>
        /// <param name="rolename">角色名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByRoleName(String rolename)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.RoleName, rolename);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.RoleName, rolename);
        }

        /// <summary>根据角色分类查找</summary>
        /// <param name="category">角色分类</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByCategory(String category)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.Category, category);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.Category, category);
        }
        #endregion

        #region 高级查询
        /// <summary>构造搜索条件</summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        private static String SearchWhere(String key)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            var exp = new WhereExpression();

            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            if (!String.IsNullOrEmpty(key)) SearchWhereByKeys(exp.Builder, key);

            // 以下仅为演示，2、3行是同一个意思的不同写法，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //exp &= _.Name == "testName"
            //    & !String.IsNullOrEmpty(key) & _.Name == key
            //    .AndIf(!String.IsNullOrEmpty(key), _.Name == key)
            //    | _.ID > 0;

            return exp;
        }
        #endregion

        #region 数据分页
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据量</param>
        /// <returns>数据列表</returns>
        public static EntityList<TEntity> GetPageEntityList(int pageIndex,int pageSize)
        {
            return FindAllByName("", "", "",pageSize * (pageIndex - 1), pageSize);
        }
        /// <summary>
        /// 根据名称和对应的值来获取分页数据
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">值</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据量</param>
        /// <returns>数据列表</returns>
        public static EntityList<TEntity> GetPageEntityList(string name,object value, int pageIndex, int pageSize)
        {            
            return FindAllByName(name ,value ,"", pageSize * (pageIndex - 1), pageSize);
        }
        /// <summary>
        /// 根据条件来获取对应的分页数据
        /// </summary>
        /// <param name="whereClause">条件</param>
        /// <param name="orderClause">排序</param>
        /// <param name="selects">选择列</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页数据量</param>
        /// <returns>数据列表</returns>
        public static EntityList<TEntity> GetPageEntityList(string whereClause,string orderClause,string selects, 
            int pageIndex, int pageSize)
        {            
            return FindAll(whereClause, orderClause, selects, pageSize * (pageIndex - 1), pageSize);
        }
        #endregion

        #region 业务
        #endregion
    }
}