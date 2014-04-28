using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZT.Permission.Models;

namespace ZT.Permission.Logics
{
    /// <summary>
    /// 上下级权限关系
    /// </summary>
    public class AccountService
    {
        /// <summary>
        /// 获取指定账号直接下级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Users> GetDirectLowers(int userId)
        {
            return null;
        }

        /// <summary>
        /// 获取指定账号直接下级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<int> GetDirectLowerIds(int userId)
        {
            return null;
        }

        /// <summary>
        /// 获取指定账号所有下级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Users> GetLowers(int userId)
        {
            return null;
        }

        /// <summary>
        /// 获取指定账号所有下级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<int> GetLowersId(int userId)
        {
            return null;
        }

        /// <summary>
        /// 获取指定账号直接上级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Users> GetDirectUppers(int userId)
        {
            return null;
        }

        /// <summary>
        /// 获取指定账号直接上级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<int> GetDirectUpperIds(int userId)
        {
            return null;
        }

        /// <summary>
        /// 获取指定账号所有上级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Users> GetUppers(int userId)
        {
            return null;
        }

        /// <summary>
        /// 获取指定账号所有上级
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<int> GetUpperIds(int userId)
        {
            return null;
        }
    }
}
