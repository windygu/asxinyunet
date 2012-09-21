using System;
using System.Web.Caching;

namespace Common
{
    /// <summary>
    /// 原始源码来自：http://www.cnblogs.com/wujiang/archive/2012/03/30/2425104.html
    /// 修改asxinyu@qq.com
    /// 1.默认一直缓存，除非单独删除
    /// </summary>
    public class CacheHelp
    {
        protected static volatile System.Web.Caching.Cache webCache = System.Web.HttpRuntime.Cache;
        /// <summary>
        /// 静态构造函数
        /// </summary>
        public static System.Web.Caching.Cache GetWebCacheObj
        {
            get { return webCache; }
        }
        
        #region 添加对象到缓存
        /// <summary>
        /// 加入当前对象到缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        public virtual void AddObject(string objId, object o)
        {
            if (objId == null || objId.Length == 0 || o == null)
            {
                return;
            }

            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);
            webCache.Insert(objId, o, null, DateTime.MaxValue, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, callBack);

            //if (TimeOut == 7200)
            //{
            //    webCache.Insert(objId, o, null, DateTime.MaxValue, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, callBack);
            //}
            //else
            //{
            //    webCache.Insert(objId, o, null, DateTime.Now.AddSeconds(TimeOut), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, callBack);
            //}
        }

        /// <summary>
        /// 加入当前对象到缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        //public virtual void AddObjectWith(string objId, object o)
        //{
        //    if (objId == null || objId.Length == 0 || o == null)
        //    {
        //        return;
        //    }

        //    CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);

        //    webCache.Insert(objId, o, null, System.DateTime.Now.AddSeconds(TimeOut), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, callBack);
        //}


        /// <summary>
        /// 加入当前对象到缓存中,并对相关文件建立依赖
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        /// <param name="files">监视的路径文件</param>
        public virtual void AddObjectWithFileChange(string objId, object o, string[] files)
        {
            if (objId == null || objId.Length == 0 || o == null)
            {
                return;
            }

            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);

            CacheDependency dep = new CacheDependency(files, DateTime.Now);

            webCache.Insert(objId, o, dep, DateTime.MaxValue, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, callBack);
        }



        /// <summary>
        /// 加入当前对象到缓存中,并使用依赖键
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        /// <param name="dependKey">依赖关联的键值</param>
        public virtual void AddObjectWithDepend(string objId, object o, string[] dependKey)
        {
            if (objId == null || objId.Length == 0 || o == null)
            {
                return;
            }

            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);

            CacheDependency dep = new CacheDependency(null, dependKey, DateTime.Now);

            webCache.Insert(objId, o, dep, DateTime.MaxValue, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, callBack);
        }
        #endregion

        #region 删除缓存中的一个对象
        /// <summary>
        /// 建立回调委托的一个实例
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="reason"></param>
        public void onRemove(string key, object val, CacheItemRemovedReason reason)
        {
            switch (reason)
            {
                case CacheItemRemovedReason.DependencyChanged:
                    break;
                case CacheItemRemovedReason.Expired:
                    {
                        //CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(this.onRemove);

                        //webCache.Insert(key, val, null, System.DateTime.Now.AddMinutes(TimeOut),
                        //    System.Web.Caching.Cache.NoSlidingExpiration,
                        //    System.Web.Caching.CacheItemPriority.High,
                        //    callBack);
                        break;
                    }
                case CacheItemRemovedReason.Removed:
                    {
                        break;
                    }
                case CacheItemRemovedReason.Underused:
                    {
                        break;
                    }
                default: break;
            }
            //如需要使用缓存日志,则需要使用下面代码
            //myLogVisitor.WriteLog(this,key,val,reason);            
        }

        /// <summary>
        /// 删除缓存对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        public virtual void RemoveObject(string objId)
        {
            if (objId == null || objId.Length == 0)
            {
                return;
            }
            webCache.Remove(objId);
        }
        #endregion

        #region 查找缓存对象
        /// <summary>
        /// 返回一个指定的对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        /// <returns>对象</returns>
        public virtual object RetrieveObject(string objId)
        {
            if (objId == null || objId.Length == 0)
            {
                return null;
            }
            return webCache.Get(objId);
        }
        #endregion
    }
}