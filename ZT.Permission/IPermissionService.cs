using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZT.Permission.Models;
using ZT.Permission.Enums;

namespace ZT.Permission
{
    interface IPermissionService
    {
        #region 用户关系权限
        
        List<Users> GetDirectLowers(int userId);

        List<int> GetDirectLowerIds(int userId);

        List<Users> GetLowers(int userId);

        List<int> GetLowersId(int userId);

        List<Users> GetDirectUppers(int userId);

        List<int> GetDirectUpperIds(int userId);

        List<Users> GetUppers(int userId);

        List<int> GetUpperIds(int userId);
        #endregion

        #region 用户动作权限

        bool AddRolesForUser(int userId, int roleId);

        bool OptRolesForUser(int userId, int roleId, DataStatusEnum status);

        List<Roles> GetRolesForUser(int userId, DataStatusEnum status);

        bool AddActionForRole(int roleId, int actionId);

        bool OptActionForRole(int roleId, int actionId, DataStatusEnum status);

        List<Actions> GetActionsForRole(int roleId, DataStatusEnum status);

        List<Actions> GetAllActionsForUser(int userId);
        #endregion
       
    }
}
