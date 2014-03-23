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
        public List<Roles> GetAllRole(string roleName)
        {
            RolesDao ad = new RolesDao();
            Roles role = new Roles();
            role.Where = string.IsNullOrEmpty(roleName) ? "" : "LoweredRoleName = " + roleName.ToLower();
            return ad.Select(role);
        }

        /// <summary>
        /// 通过角色名获取一个角色
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public Roles GetRoleByRoleName(string roleName)
        {
            Roles rs = new Roles();
            rs.LoweredRoleName = roleName.ToLower();

            DataSet ds = new RolesDao().SelectRoleByRoleName(rs);

            if (ds.Tables[0].Rows.Count > 0)
            {
                rs.RoleId = ds.Tables[0].Rows[0]["RoleId"].ToString().ToInteger();
                rs.RoleName = ds.Tables[0].Rows[0]["RoleName"].ToString();
                rs.CreateDate = ds.Tables[0].Rows[0]["CreateDate"].ToString().ToDateTime();
                rs.Status = ds.Tables[0].Rows[0]["Status"].ToString().ToInteger();
                rs.Description = ds.Tables[0].Rows[0]["Description"].ToString();

                return rs;
            }
            return null;                
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public int CreateRole(Roles rs)
        {
            return new RolesDao().CreateRole(rs);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int DeleteRole(int roleId)
        {
            Roles rs = new Roles();
            rs.RoleId = roleId;

            return new RolesDao().DeleteAction(rs);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public int DeleteRole(string roleName)
        {
            Roles rs = new Roles();
            rs.LoweredRoleName = roleName.ToLower();

            return new RolesDao().DeleteAction(rs);
        }
    }
}
