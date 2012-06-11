﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using System.Linq;
 using XCode;
using XCode.Configuration;
using System.Web;

namespace DotNet.CommonEntity
{
    /// <summary>菜单表</summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public class Menu : Menu<Menu> { }
    
    /// <summary>菜单表</summary>
    public partial class Menu<TEntity> : EntityTree<TEntity> where TEntity : Menu<TEntity>, new()
    {
        #region 对象操作﻿
        static Menu()
        {
            // 用于引发基类的静态构造函数，所有层次的泛型实体类都应该有一个
            TEntity entity = new TEntity();
        }       
        #endregion

        #region 扩展属性
        /// <summary>父菜单名</summary>
        [XmlIgnore]
        public virtual String ParentMenuName { get { return Parent == null ? null : Parent.MenuName; } set { } }
        #endregion

        #region 扩展属性﻿
        [NonSerialized]
        private SystemDb _SystemDb;
        /// <summary>该菜单表所对应的数据库基本信息表</summary>
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
        #endregion

        #region 扩展查询﻿
        /// <summary>根据编号查找</summary>
        /// <param name="id">编号</param>       
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindById(Int32 id)
        {
            if (Meta.Count >= 1000)
                return Find(_.Id, id);
            else // 实体缓存
                return Meta.Cache.Entities.Find(_.Id, id);           
        }

        /// <summary>根据表编号查找：查找某一个表的所有相关页面</summary>
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

        /// <summary>根据表编号和菜单名称查找单个菜单</summary>
        /// <param name="systemdbid">表编号</param>
        /// <param name="menuname">菜单名称</param>        
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TEntity FindBySystemDbIdAndMenuName(Int32 systemdbid, String menuname)
        {
            if (Meta.Count >= 1000)
                return Find(new String[] { _.SystemDbId, _.MenuName }, new Object[] { systemdbid, menuname });
            else // 实体缓存
                return Meta.Cache.Entities.Find(e => e.SystemDbId == systemdbid && e.MenuName == menuname);
        }
        /// <summary>查找指定菜单的子菜单</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EntityList<TEntity> FindAllByParentID(Int32 id)
        {
            EntityList<TEntity> list = Meta.Cache.Entities.FindAll(_.ParentId, id);
            if (list != null && list.Count > 0) list.Sort(new String[] { _.SortCode , _.Id }, new Boolean[] { true, false });
            return list;
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
        //获取分页数据
        public static EntityList<TEntity> GetPageEntityList(int pageIndex,int pageSize)
        {
            return FindAllByName("", "", "",pageSize * (pageIndex - 1), pageSize);
        }
        public static EntityList<TEntity> GetPageEntityList(string name,object value, int pageIndex, int pageSize)
        {            
            return FindAllByName(name ,value ,"", pageSize * (pageIndex - 1), pageSize);
        }
        public static EntityList<TEntity> GetPageEntityList(string whereClause,string orderClause,string selects, 
            int pageIndex, int pageSize)
        {            
            return FindAll(whereClause, orderClause, selects, pageSize * (pageIndex - 1), pageSize);
        }
        #endregion

        #region 扩展操作
        /// <summary>已重载。</summary>
        /// <returns></returns>
        public override string ToString()
        {
            var path = FullPath;
            if (!String.IsNullOrEmpty(path))
                return path;
            return base.ToString();
        }
        #endregion

        #region 业务
        /// <summary>添加子菜单</summary>
        public virtual TEntity AddChild(String menuName, String url,string displayName="",string iconUrl="")
        {
            TEntity entity = new TEntity();
            entity.ParentId = Id;
            entity.MenuName  = menuName ;
            entity.Url = url;
            entity.DisplayName = (displayName==""? DisplayName:displayName);
            entity.IconsUrl = (iconUrl == "" ? IconsUrl : iconUrl);
            entity.Category = Category;
            entity.IsEnable = 1 ;
            entity.DeletionStatusCode = 0;
            entity.Save();
            return entity;
        }
        /// <summary>取得全路径的实体，由上向下排序</summary>
        /// <param name="includeSelf">是否包含自己</param>
        /// <param name="separator">分隔符</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        string IMenu.GetFullPath(bool includeSelf, string separator, Func<IMenu, string> func)
        {
            Func<TEntity, String> d = null;
            if (func != null) d = item => func(item);
            return GetFullPath(includeSelf, separator, d);
        }       

        /// <summary>父菜单</summary>
        IMenu IMenu.Parent { get { return Parent; } }

        /// <summary>子菜单</summary>
        IList<IMenu> IMenu.Childs { get { return Childs.OfType<IMenu>().ToList(); } }

        /// <summary>子孙菜单</summary>
        IList<IMenu> IMenu.AllChilds { get { return AllChilds.OfType<IMenu>().ToList(); } }

        /// <summary>根据层次路径查找</summary>
        /// <param name="path">层次路径</param>
        /// <returns></returns>
        IMenu IMenu.FindByPath(String path) { return FindByPath(path, _.MenuName,_.Description); }        

        #endregion
    }

    public partial interface IMenu
    {
        /// <summary>取得全路径的实体，由上向下排序</summary>
        /// <param name="includeSelf">是否包含自己</param>
        /// <param name="separator">分隔符</param>
        /// <param name="func">回调</param>
        /// <returns></returns>
        String GetFullPath(Boolean includeSelf, String separator, Func<IMenu, String> func);

        /// <summary>检查菜单名称，修改为新名称。返回自身，支持链式写法</summary>
        /// <param name="oldName"></param>
        /// <param name="newName"></param>
        //IMenu CheckMenuName(String oldName, String newName);

        /// <summary>父菜单</summary>
        IMenu Parent { get; }

        /// <summary>子菜单</summary>
        IList<IMenu> Childs { get; }

        /// <summary>子孙菜单</summary>
        IList<IMenu> AllChilds { get; }

        /// <summary>深度</summary>
        Int32 Deepth { get; }

        /// <summary>根据层次路径查找</summary>
        /// <param name="path">层次路径</param>
        /// <returns></returns>
        IMenu FindByPath(String path);
    }
}


   