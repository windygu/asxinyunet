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
    
    /// <summary>权限表</summary>
    public partial class Permission<TEntity> : Entity<TEntity> where TEntity : Permission<TEntity>, new()
    {
        #region 对象操作
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

        #region 扩展属性
        [NonSerialized]
		private EntityList<RolePermission> _RolePermissions;
		/// <summary>该权限表所拥有的角色权限表集合</summary>
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
		/// <summary>该权限表所拥有的用户权限表集合</summary>
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

        /// <summary>根据数据库名称查找</summary>
        /// <param name="dbname">数据库名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByDbName(String dbname)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.DbName, dbname);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.DbName, dbname);
        }

        /// <summary>根据表名查找</summary>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByTableName(String tablename)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.TableName, tablename);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.TableName, tablename);
        }

        /// <summary>根据父编号查找</summary>
        /// <param name="parentid">父编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindByParentId(Int32 parentid)
        {
            if (Meta.Count >= 1000)
                return Find(_.ParentId, parentid);
            else // 实体缓存
                return Meta.Cache.Entities.Find(_.ParentId, parentid);
        }

        /// <summary>根据数据库名称、表名查找</summary>
        /// <param name="dbname">数据库名称</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByDbNameAndTableName(String dbname, String tablename)
        {
            if (Meta.Count >= 1000)
                return FindAll(new String[] { _.DbName, _.TableName }, new Object[] { dbname, tablename });
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(e => e.DbName == dbname && e.TableName == tablename);
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