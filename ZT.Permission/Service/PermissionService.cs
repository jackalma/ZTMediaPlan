using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZT.Permission.Models;
using ZT.Permission.Enums;

namespace ZT.Permission.Service
{
    public class PermissionService:IPermissionService
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


        public bool AddRolesForUser(int userId, int roleId) 
        {
            return true;
        }

        public bool OptRolesForUser(int userId, int roleId, DataStatusEnum status) 
        {
            return true;
        }

        public List<Roles> GetRolesForUser(int userId, DataStatusEnum status)
        {
            return null;
        }

        public bool AddActionForRole(int roleId, int actionId)
        {
            return true;
        }

        public bool OptActionForRole(int roleId, int actionId, DataStatusEnum status)
        {
            return true;
        }

        public List<Actions> GetActionsForRole(int roleId, DataStatusEnum status)
        {
            return null;
        }

        public List<Actions> GetAllActionsForUser(int userId)
        {
            return null;
        }
    }
}
