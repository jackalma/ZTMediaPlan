//==================================================================
//Create by jackal on 2014-04-23
//Last Changed by jackal on 2014-04-24
//==================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace ZT.MediaPlan.Common
{
    /// <summary>
    /// Cache缓存类
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CacheHelper()
        { 
            
        }

        /// <summary>
        /// 是否存在CACHE
        /// </summary>
        /// <param name="chacheKey"></param>
        /// <returns></returns>
        public static bool IsCacheExist(string chacheKey)
        {
            object objCache = GetCache(chacheKey);
            if (objCache == null)
                return false;
            return true;
        }

        /// <summary>
        /// 获取一个CACHE
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string cacheKey)
        {
            Cache objCache = HttpRuntime.Cache;
            return objCache[cacheKey];
        }

        /// <summary>
        /// 清空Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        public static void RemoveCache(string cacheKey)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Remove(cacheKey);
        }

        #region 设置Cache
        /// <summary>
        /// 设置Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="obj"></param>
        public static void SetCache(string cacheKey, object obj)
        {
            if (obj != null)
            {
                System.Web.Caching.Cache cache = HttpRuntime.Cache;

                if (GetCache(cacheKey) != null) RemoveCache(cacheKey);

                cache.Insert(cacheKey, obj);
            }
        }

        /// <summary>
        /// 设置Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="obj"></param>
        /// <param name="expireTime"></param>
        public static void SetCache(string cacheKey, object obj, DateTime expireTime)
        {
            if (obj != null)
            {
                System.Web.Caching.Cache cache = HttpRuntime.Cache;
               
                if (GetCache(cacheKey) != null) RemoveCache(cacheKey);
             
                cache.Insert(cacheKey, obj, null, expireTime, TimeSpan.Zero);
            }
        }

        /// <summary>
        /// 设置Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="obj"></param>
        /// <param name="cacheDependencyFile"></param>
        public static void SetCache(string cacheKey, object obj, string[] cacheDependencyFile)
        {
            if (obj != null)
            {
                System.Web.Caching.Cache cache = HttpRuntime.Cache;
                System.Web.Caching.CacheDependency cacheDependency = null;
                if (cacheDependencyFile != null && cacheDependencyFile.Length > 0)
                {
                    cacheDependency = new CacheDependency(cacheDependencyFile);
                }

                if (GetCache(cacheKey) != null) RemoveCache(cacheKey);

                cache.Insert(cacheKey, obj, cacheDependency);
            }
        }

        /// <summary>
        /// 设置Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="obj"></param>
        /// <param name="cacheDependencyFile"></param>
        /// <param name="lockObj"></param>
        public static void SetCache(string cacheKey, object obj, string[] cacheDependencyFile, ref object lockObj)
        {
            if (obj != null)
            {
                System.Web.Caching.Cache cache = HttpRuntime.Cache;
                System.Web.Caching.CacheDependency cacheDependency = null;
                if (cacheDependencyFile != null && cacheDependencyFile.Length > 0)
                {
                    cacheDependency = new CacheDependency(cacheDependencyFile);
                }
                
                lock (lockObj)
                {
                    if (GetCache(cacheKey) != null) RemoveCache(cacheKey);

                    cache.Insert(cacheKey, obj, cacheDependency);
                }
            }
        }

        /// <summary>
        /// 设置Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="obj"></param>
        /// <param name="cacheDependencyFile"></param>
        /// <param name="expireTime"></param>
        public static void SetCache(string cacheKey, object obj, string[] cacheDependencyFile, DateTime expireTime)
        {
            if (obj != null)
            {                
                System.Web.Caching.Cache cache = HttpRuntime.Cache;                
                System.Web.Caching.CacheDependency cacheDependency = null;
                if (cacheDependencyFile != null && cacheDependencyFile.Length > 0)
                {
                    cacheDependency = new System.Web.Caching.CacheDependency(cacheDependencyFile);
                }

                if (GetCache(cacheKey) != null) RemoveCache(cacheKey);

                cache.Insert(cacheKey, obj, cacheDependency, expireTime, TimeSpan.Zero);
            }
        }

        /// <summary>
        /// 设置Cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="obj"></param>
        /// <param name="cacheDependencyFile"></param>
        /// <param name="expireTime"></param>
        /// <param name="lockObj"></param>
        public static void SetCache(string cacheKey, object obj, string[] cacheDependencyFile, DateTime expireTime, object lockObj)
        {
            if (obj != null)
            {
                System.Web.Caching.Cache cache = HttpRuntime.Cache;
                System.Web.Caching.CacheDependency cacheDependency = null;
                if (cacheDependencyFile != null && cacheDependencyFile.Length > 0)
                {
                    cacheDependency = new System.Web.Caching.CacheDependency(cacheDependencyFile);
                }

                lock (lockObj)
                {
                    if (GetCache(cacheKey) != null) RemoveCache(cacheKey);

                    cache.Insert(cacheKey, obj, cacheDependency, expireTime, TimeSpan.Zero);   
                }              
            }
        }
        #endregion
    }
}