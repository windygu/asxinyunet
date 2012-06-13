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
    /// <summary>用户角色表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class UserRole : UserRole<UserRole> { }
    
    /// <summary>用户角色表</summary>
    public partial class UserRole<TEntity> : Entity<TEntity> where TEntity : UserRole<TEntity>, new()
    {
        #region 对象操作
        static UserRole()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        #endregion

        #region 扩展属性
        [NonSerialized]
        private Role _Role;
        /// <summary>该用户角色表所对应的角色表</summary>
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
        private User _User;
        /// <summary>该用户角色表所对应的用户信息</summary>
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

        /// <summary>根据用户编号、角色编号查找</summary>
        /// <param name="userid">用户编号</param>
        /// <param name="roleid">角色编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindByUserIdAndRoleId(Int32 userid, Int32 roleid)
        {
            if (Meta.Count >= 1000)
                return Find(new String[] { _.UserId, _.RoleId }, new Object[] { userid, roleid });
            else // 实体缓存
                return Meta.Cache.Entities.Find(e => e.UserId == userid && e.RoleId == roleid);
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

        /// <summary>根据角色编号查找</summary>
        /// <param name="roleid">角色编号</param>
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