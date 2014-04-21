using System.Data;
using System.Collections.Generic;
using ZT.Framework.Common;
using ZT.Permission.Models;
using ZT.Permission.Daos;
using ZT.Permission.Enums;

namespace ZT.Permission.Logics
{
    public class RolesLogic
    {
        /// <summary>
        /// 通过活动名称选择一个角色
        /// 角色名为空，返回所有角色
        /// </summary>
        /// <returns></returns>
        public List<Roles> GetAllRoleByRoleName(string roleName)
        {
            RolesDao ad = new RolesDao();
            Roles role = new Roles();
            role.Where = string.IsNullOrEmpty(roleName) ? "" : "LoweredRoleName = " + roleName.ToLower();
            return ad.Select(role);
        }      

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public int CreateRole(Roles role)
        {
            RolesDao rd = new RolesDao();
            return rd.Insert(role);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int DeleteRole(Roles role)
        {
            RolesDao rd = new RolesDao();
            role.Status = (int)DataStatusEnum.Disabled;
            return rd.Update(role);
        }

        /// <summary>
        /// 启用角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int EnableRole(Roles role)
        {
            RolesDao rd = new RolesDao();
            role.Status = (int)DataStatusEnum.Enabled;
            return rd.Update(role);
        }
    }
}
