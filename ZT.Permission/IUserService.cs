using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZT.Permission.Models;
using ZT.Permission.Enums;

namespace ZT.Permission
{
    public interface IUserService
    {
        #region 编号
        int GetUserId();
        #endregion

        #region 查询用户

        List<Users> GetAllUser();

        List<Users> GetAllUser(AccountStatusEnum status);

        Users GetUserInfo(int userId);

        List<Users> GetUserByUserName(string userName);

        #endregion

        #region 创建用户

        bool CreateUser(string jsonBase, string jsonLogin);

        #endregion

        #region 删除用户 & 编辑用户

        bool UpdateUser(Users us);

        bool DeleteUser(Users us);

        #endregion
        
        #region 动作
        
        List<Actions> GetActionByActionName(string actionName);

        bool CreateAction(Actions action);

        bool DeleteAction(Actions action);

        bool EnbaleAction(Actions action);

        #endregion

        #region 角色

        List<Roles> GetAllRoleByRoleName(string roleName);

        bool CreateRole(Roles role);

        bool DeleteRole(Roles role);

        bool EnableRole(Roles role);

        #endregion
    }
}
