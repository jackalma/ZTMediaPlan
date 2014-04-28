using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZT.Permission.Enums;
using ZT.Permission.Models;

namespace ZT.Permission.Service
{
    public class UserService : IUserService
    {
        public List<Users> GetAllUser()
        {
            return null;
        }

        public List<Users> GetAllUser(AccountStatusEnum status)
        {
            return null;
        }

        public Users GetUserInfo(int userId)
        {
            return null;
        }

        public List<Users> GetUserByUserName(string userName)
        {
            return null;
        }

        public bool CreateUser(Users us)
        {
            return false;
        }

        public bool UpdateUser(Users us)
        {
            return true;
        }

        public bool DeleteUser(Users us)
        {
            return true;
        }

        public List<Actions> GetActionByActionName(string actionName)
        {
            return null;
        }

        public bool CreateAction(Actions action)
        {
            return true;
        }

        public bool DeleteAction(Actions action)
        {
            return false;
        }

        public bool EnbaleAction(Actions action)
        {
            return true;
        }

        public List<Roles> GetAllRoleByRoleName(string roleName)
        {
            return null;
        }

        public bool CreateRole(Roles role)
        {
            return true;
        }

        public bool DeleteRole(Roles role)
        {
            return true;
        }

        public bool EnableRole(Roles role)
        {
            return false;
        }
    }
}
