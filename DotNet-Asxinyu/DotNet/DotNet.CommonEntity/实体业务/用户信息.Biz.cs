﻿﻿using System;
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
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class User : User<User> { }
    
    /// <summary>用户信息</summary>
    public partial class User<TEntity> : Entity<TEntity> where TEntity : User<TEntity>, new()
    {
        #region 对象操作﻿
        static User()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
			if (Logs != null) Logs.Delete();
			if (UserPermissions != null) UserPermissions.Delete();
			if (UserProfiles != null) UserProfiles.Delete();
			if (UserRoles != null) UserRoles.Delete();

            return base.OnDelete();
        }
        //TODO:统一在用户信息这里处理初始数据
        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    base.InitData();

        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    // Meta.Count是快速取得表记录数
        //    if (Meta.Count > 0) return;

        //    // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}用户信息数据……", typeof(TEntity).Name);

        //    TEntity user = new TEntity();
        //    user.Name = "admin";
        //    user.Password = DataHelper.Hash("admin");
        //    user.DisplayName = "管理员";
        //    user.RoleID = 1;
        //    user.IsEnable = true;
        //    user.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}用户信息数据！", typeof(TEntity).Name);
        //}
        #endregion

        #region 扩展属性﻿
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
        private Role _Role;
        /// <summary>该用户信息所对应的角色表</summary>
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

        [NonSerialized]
        private Staff _Staff;
        /// <summary>该用户信息所对应的员工信息表</summary>
        [XmlIgnore]
        public Staff Staff
        {
            get
            {
                if (_Staff == null && StaffId > 0 && !Dirtys.ContainsKey("Staff"))
                {
                    _Staff = Staff.FindById(StaffId);
                    Dirtys["Staff"] = true;
                }
                return _Staff;
            }
            set { _Staff = value; }
        }

        [NonSerialized]
		private EntityList<UserPermission> _UserPermissions;
		/// <summary>该用户信息所拥有的用户权限表集合</summary>
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
		/// <summary>该用户信息所拥有的用户配置信息表集合</summary>
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
		/// <summary>该用户信息所拥有的用户角色表集合</summary>
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

        /// <summary>根据员工编号查找</summary>
        /// <param name="staffid">员工编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByStaffId(Int32 staffid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.StaffId, staffid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.StaffId, staffid);
        }

        /// <summary>根据用户名、角色编号查找</summary>
        /// <param name="username">用户名</param>
        /// <param name="roleid">角色编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllByUserNameAndRoleId(String username, Int32 roleid)
        {
            if (Meta.Count >= 1000)
                return FindAll(new String[] { _.UserName, _.RoleId }, new Object[] { username, roleid });
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(e => e.UserName == username && e.RoleId == roleid);
        }

        /// <summary>根据员工编号、角色编号查找</summary>
        /// <param name="staffid">员工编号</param>
        /// <param name="roleid">角色编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindByStaffIdAndRoleId(Int32 staffid, Int32 roleid)
        {
            if (Meta.Count >= 1000)
                return Find(new String[] { _.StaffId, _.RoleId }, new Object[] { staffid, roleid });
            else // 实体缓存
                return Meta.Cache.Entities.Find(e => e.StaffId == staffid && e.RoleId == roleid);
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