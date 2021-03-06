﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using XCode;
using XCode.Configuration;

namespace ResouceEntity
{
    /// <summary>资源链接表</summary>
    public partial class tb_resoucelink : Entity<tb_resoucelink>
    {
        #region 对象操作﻿

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnInsert()
        //{
        //    return base.OnInsert();
        //}

        ///// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        ///// <param name="isNew"></param>
        //public override void Valid(Boolean isNew)
        //{
        //    // 建议先调用基类方法，基类方法会对唯一索引的数据进行验证
        //    base.Valid(isNew);

        //    // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
        //    if (String.IsNullOrEmpty(Name)) throw new ArgumentNullException(_.Name, _.Name.Description + "无效！");
        //    if (!isNew && ID < 1) throw new ArgumentOutOfRangeException(_.ID, _.ID.Description + "必须大于0！");

        //    // 在新插入数据或者修改了指定字段时进行唯一性验证，CheckExist内部抛出参数异常
        //    if (isNew || Dirtys[_.Name]) CheckExist(_.Name);
        //    if (isNew || Dirtys[_.Name] || Dirtys[_.DbType]) CheckExist(_.Name, _.DbType);
        //    if ((isNew || Dirtys[_.Name]) && Exist(_.Name)) throw new ArgumentException(_.Name, "值为" + Name + "的" + _.Name.Description + "已存在！");
        //}


        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    base.InitData();

        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    // Meta.Count是快速取得表记录数
        //    if (Meta.Count > 0) return;

        //    // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}资源链接表数据……", typeof(tb_resoucelink).Name);

        //    TEntity user = new TEntity();
        //    user.Name = "admin";
        //    user.Password = DataHelper.Hash("admin");
        //    user.DisplayName = "管理员";
        //    user.RoleID = 1;
        //    user.IsEnable = true;
        //    user.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}资源链接表数据！", typeof(tb_resoucelink).Name);
        //}
        #endregion

        #region 扩展属性﻿
        #endregion

        #region 扩展查询﻿
        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static tb_resoucelink FindById(Int32 id)
        {
            if (Meta.Count >= 1000)
                return Find(_.Id, id);
            else // 实体缓存
                return Meta.Cache.Entities.Find(_.Id, id);
            // 单对象缓存
            //return Meta.SingleCache[id];
        }

        /// <summary>根据资源名称查找</summary>
        /// <param name="resoucename">资源名称</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<tb_resoucelink> FindAllByResouceName(String resoucename)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.ResouceName, resoucename);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.ResouceName, resoucename);
        }

        /// <summary>根据资源MD5值查找</summary>
        /// <param name="resoucemd5">资源MD5值</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static EntityList<tb_resoucelink> FindAllByResouceMD5(String resoucemd5)
        {
            if (Meta.Count >= 1000)
                return FindAll(_.ResouceMD5, resoucemd5);
            else // 实体缓存
                return Meta.Cache.Entities.FindAll(_.ResouceMD5, resoucemd5);
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

            // 以下仅为演示，2、3行是同一个意思的不同写法，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //exp &= _.Name == "testName"
            //    & !String.IsNullOrEmpty(key) & _.Name == key
            //    .AndIf(!String.IsNullOrEmpty(key), _.Name == key)
            //    | _.ID > 0;

            return exp;
        }
        //获取分页数据
        public static EntityList<tb_resoucelink> GetPageEntityList(int pageIndex, int pageSize)
        {
            return FindAllByName("", "", "", pageSize * (pageIndex - 1), pageSize);
        }
        public static EntityList<tb_resoucelink> GetPageEntityList(string name, object value, int pageIndex, int pageSize)
        {
            return FindAllByName(name, value, "", pageSize * (pageIndex - 1), pageSize);
        }
        public static EntityList<tb_resoucelink> GetPageEntityList(string whereClause, string orderClause, string selects,
            int pageIndex, int pageSize)
        {
            return FindAll(whereClause, orderClause, selects, pageSize * (pageIndex - 1), pageSize);
        }
        #endregion

        #region 扩展操作
        #endregion

        #region 业务      
        #endregion
    }
}