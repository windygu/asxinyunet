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
    /// <summary>日志信息</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class Log : Log<Log> { }
    
    /// <summary>日志信息</summary>
    public partial class Log<TEntity> : Entity<TEntity> where TEntity : Log<TEntity>, new()
    {
        #region 对象操作﻿
        static Log()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }
        #endregion

        #region 扩展属性﻿
        [NonSerialized]
        private SystemDb _SystemDb;
        /// <summary>该日志信息所对应的数据库基本信息表</summary>
        [XmlIgnore]
        public SystemDb SystemDb
        {
            get
            {
                if (_SystemDb == null && SystemDbId > 0 && !Dirtys.ContainsKey("SystemDb"))
                {
                    _SystemDb = SystemDb.FindById(SystemDbId);
                    Dirtys["SystemDb"] = true;
                }
                return _SystemDb;
            }
            set { _SystemDb = value; }
        }

        [NonSerialized]
        private User _User;
        /// <summary>该日志信息所对应的用户信息</summary>
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

        /// <summary>根据表编号查找</summary>
        /// <param name="systemdbid">表编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllBySystemDbId(Int32 systemdbid)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.SystemDbId, systemdbid);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.SystemDbId, systemdbid);
        }

        /// <summary>根据表编号、用户编号查找</summary>
        /// <param name="systemdbid">表编号</param>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<TEntity> FindAllBySystemDbIdAndUserId(Int32 systemdbid, Int32 userid)
        {
            if (Meta.Count >= 1000)
                return FindAll(new String[] { _.SystemDbId, _.UserId }, new Object[] { systemdbid, userid });
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(e => e.SystemDbId == systemdbid && e.UserId == userid);
        }
        #endregion

        #region 高级查询
        /// <summary>
        /// 构造搜索条件
        /// </summary>
        /// <param name="key">关键字</param>        
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

        #region ILog接口
        //TODO:完善写日志接口的处理，做到尽量简单，是否重新设计表结构
        #endregion
    }

    public partial interface ILog
    {
        
        /// <summary>写日志</summary>
        /// <param name="type">类型</param>
        /// <param name="action">操作</param>
        /// <param name="remark">备注</param>
        //void WriteLog(int systemDbId, String userId, String category,string action);
    }
}