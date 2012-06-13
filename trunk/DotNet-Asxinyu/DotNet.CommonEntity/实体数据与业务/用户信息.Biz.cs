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
  
    /// <summary>用户信息</summary>
    public partial class User<TEntity> : Entity<TEntity> where TEntity : User<TEntity>, new()
    {
        #region 对象操作
        static User()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }

        
        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            //TODO:删除逻辑处理
			if (Logs != null) Logs.Delete();		
			if (UserPermissions != null) UserPermissions.Delete();
			if (UserProfiles != null) UserProfiles.Delete();
			if (UserRoles != null) UserRoles.Delete();

            return base.OnDelete();
        }      
        #endregion

        #region 扩展属性
        [NonSerialized]
		private EntityList<Log> _Logs;
		/// <summary>该用户信息所拥有的日志信息集合</summary>
		[XmlIgnore]
		public EntityList<Log> Logs
		{
			get
			{
				if (_Logs == null && Id > 0 && !Dirtys.ContainsKey("Logs"))
                {
					_Logs = Log.FindAllByUserId(Id);
					Dirtys["Logs"] = true;
				}
				return _Logs;
			}
			set { _Logs = value; }
		}       
        [NonSerialized]
        private Staff _Staff;
        /// <summary>该用户信息所对应的员工信息表</summary>
        [XmlIgnore]
        public Staff Staff
        {
            get
            {
                if (_Staff == null && !String.IsNullOrEmpty(UserName) && !Dirtys.ContainsKey("Staff"))
                {
                    _Staff = Staff.FindById(Id );
                    Dirtys["Staff"] = true;
                }
                return _Staff;
            }
            set { _Staff = value; }
        }

        [NonSerialized]
		private EntityList<UserPermission> _UserPermissions;
		/// <summary>该用户信息所拥有的用户权限集合</summary>
		[XmlIgnore]
		public EntityList<UserPermission> UserPermissions
		{
			get
			{
				if (_UserPermissions == null && Id > 0 && !Dirtys.ContainsKey("UserPermissions"))
                {
					_UserPermissions = UserPermission.FindAllByUserId(Id);
					Dirtys["UserPermissions"] = true;
				}
				return _UserPermissions;
			}
			set { _UserPermissions = value; }
		}

        [NonSerialized]
		private EntityList<UserProfile> _UserProfiles;
		/// <summary>该用户信息所拥有的用户配置信息集合</summary>
		[XmlIgnore]
		public EntityList<UserProfile> UserProfiles
		{
			get
			{
				if (_UserProfiles == null && Id > 0 && !Dirtys.ContainsKey("UserProfiles"))
                {
					_UserProfiles = UserProfile.FindAllByUserId(Id);
					Dirtys["UserProfiles"] = true;
				}
				return _UserProfiles;
			}
			set { _UserProfiles = value; }
		}

        [NonSerialized]
		private EntityList<UserRole> _UserRoles;
		/// <summary>该用户信息所拥有的用户角色集合</summary>
		[XmlIgnore]
		public EntityList<UserRole> UserRoles
		{
			get
			{
				if (_UserRoles == null && Id > 0 && !Dirtys.ContainsKey("UserRoles"))
                {
					_UserRoles = UserRole.FindAllByUserId(Id);
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

        /// <summary>根据用户名查找</summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindByUserName(String username)
        {
            if (Meta.Count >= 1000)
                return Find(_.UserName, username);
            else // 实体缓存
                return Meta.Cache.Entities.Find(_.UserName, username);
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