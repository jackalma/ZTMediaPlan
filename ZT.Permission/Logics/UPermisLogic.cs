using System;
using System.Collections.Generic;
using System.Data;
using ZT.Framework.Common;
using ZT.Permission.Models;
using ZT.Permission.Daos;
using ZT.Permission.Enums;

namespace ZT.Permission.Logics
{
    public class UPermisLogic
    {
        /// <summary>
        /// 用户添加角色
        /// 给用户添加角色之前，先检查此用户是否已经有这个角色，状态是删除。如果有直接更改状态启用。
        /// 如果没有，则添加用户和角色对应关系
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public bool AddRolesForUser(int userId, int roleId)
        {
            //获取用户已经删除过的角色
            var listRoles = GetRolesForUser(userId, (int)DataStatusEnum.Disabled);
            if (listRoles.Count > 0)
            {
                if (listRoles.Exists(delegate(Roles role) { return role.RoleId == roleId; }))
                {
                    //启用用户角色
                    return OptRolesForUser(userId, roleId, (int)DataStatusEnum.Enabled);
                }
            }            
            
            UPermis up = new UPermis();           
            up.UserId = userId;
            up.RoleId = roleId;
            up.Status = (int)DataStatusEnum.Enabled;

            if (new UPermisDao().AddRolesForUser(up) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 用户删除/启用角色
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="roleId">角色编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public bool OptRolesForUser(int userId, int roleId, int status)
        {
            UPermis up = new UPermis();
            up.UserId = userId;
            up.RoleId = roleId;
            up.Status = status;

            if (new UPermisDao().OptRolesForUser(up) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取用户拥有的角色是,根据状态
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Roles> GetRolesForUser(int userId, int status)
        {
            UPermis up = new UPermis();
            up.UserId = userId;
            up.Status = status;

            DataSet ds = new UPermisDao().SelectRolesForUser(up);

            return ToListRoles(ds);
        }

        /// <summary>
        /// 角色添加Action
        /// 给角色添加动作之前，先检查此角色是否已经有这个动作，状态是删除。如果有直接更改状态启用。
        /// 如果没有，则添加角色和动作对应关系
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="actionId">活动编号</param>
        /// <returns></returns>
        public bool AddActionForRole(int roleId, int actionId)
        {
            //获取角色已经删除过的动作
            var listActions = GetActionsForRole(roleId, (int)DataStatusEnum.Disabled);
            if (listActions.Count > 0)
            {
                if (listActions.Exists(delegate(Actions action) { return action.ActionId == actionId; }))
                {
                    //启用角色动作
                    return OptActionForRole(roleId, actionId, (int)DataStatusEnum.Enabled);
                }
            }  

            UPermis up = new UPermis();            
            up.RoleId = roleId;
            up.ActionId = actionId;
            up.Status = (int)DataStatusEnum.Enabled;

            if (new UPermisDao().AddActionsForRole(up) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 角色删除/启用动作
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="actionId">活动编号</param>
        /// <returns></returns>
        public bool OptActionForRole(int roleId, int actionId, int status)
        {
            UPermis up = new UPermis();
            up.RoleId = roleId;
            up.ActionId = actionId;
            up.Status = status;

            if (new UPermisDao().OptActionsForRole(up) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取角色拥有的Action,根据状态
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<Actions> GetActionsForRole(int roleId, int status)
        {
            UPermis up = new UPermis();
            up.RoleId = roleId;
            up.Status = status;

            DataSet ds = new UPermisDao().SelectActionsForRole(up);

            return ToListActions(ds);
        }

        //////from here 

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
        private List<Roles> ToListRoles(DataSet ds)
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

        private List<Actions> ToListActions(DataSet ds)
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
