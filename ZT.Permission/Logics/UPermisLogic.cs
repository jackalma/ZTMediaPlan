using System;
using System.Collections.Generic;
using System.Data;
using ZT.Framework.Common;
using ZT.Permission.Models;
using ZT.Permission.Daos;

namespace ZT.Permission.Logics
{
    public class UPermisLogic
    {
        /// <summary>
        /// 用户添加角色
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public bool AddRolesForUser(int userId, int roleId)
        {
            UPermis up = new UPermis();
            up.ID = Guid.NewGuid().ToString();
            up.UserId = userId;
            up.RoleId = roleId;

            if (new UPermisDao().AddRolesForUser(up) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除用户角色
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public bool DeleteRolesForUser(int userId, int roleId)
        {
            UPermis up = new UPermis();
            up.UserId = userId;
            up.RoleId = roleId;

            if (new UPermisDao().DeleteRolesForUser(up) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取用户拥有的角色是
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Roles> GetRolesForUser(int userId)
        {
            UPermis up = new UPermis();
            up.UserId = userId;

            DataSet ds = new UPermisDao().SelectRolesForUser(up);

            return ToListRoles(ds);
        }

        /// <summary>
        /// 角色添加Action
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="actionId">活动编号</param>
        /// <returns></returns>
        public bool AddActionForRole(int roleId, int actionId)
        {
            UPermis up = new UPermis();
            up.ID = Guid.NewGuid().ToString();
            up.RoleId = roleId;
            up.ActionId = actionId;

            if (new UPermisDao().AddActionsForRole(up) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 角色删除Action
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="actionId">活动编号</param>
        /// <returns></returns>
        public bool DeleteActionForRole(int roleId, int actionId)
        {
            UPermis up = new UPermis();
            up.RoleId = roleId;
            up.ActionId = actionId;

            if (new UPermisDao().DeleteActionsForRole(up) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取角色拥有的Action
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public List<Actions> GetActionsForRole(int roleId)
        {
            UPermis up = new UPermis();
            up.RoleId = roleId;

            DataSet ds = new UPermisDao().SelectActionsForRole(up);

            return ToListActions(ds);
        }

        /// <summary>
        /// 获取用户拥有的Action
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public List<Actions> GetAllActionsForUser(int userId)
        {
            UPermis up = new UPermis();
            up.UserId = userId;

            DataSet ds = new UPermisDao().SelectAllActionsForUser(up);

            return ToListActions(ds);
        }
        #region 私有方法
        public List<Roles> ToListRoles(DataSet ds)
        {
            List<Roles> listRoles = new List<Roles>();
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Roles rl = new Roles();
                rl.RoleId = dt.Rows[i]["RoleId"].ToString().ToInteger();
                rl.RoleName = dt.Rows[i]["RoleName"].ToString();
                rl.Description = dt.Rows[i]["Description"].ToString();

                listRoles.Add(rl);
            }
            return listRoles;
        }

        public List<Actions> ToListActions(DataSet ds)
        {
            List<Actions> listActions = new List<Actions>();
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Actions ac = new Actions();
                ac.ActionId = dt.Rows[i]["ActionId"].ToString().ToInteger();
                ac.ActionName = dt.Rows[i]["ActionName"].ToString();

                listActions.Add(ac);
            }
            return listActions;
        }
        #endregion
    }
}
