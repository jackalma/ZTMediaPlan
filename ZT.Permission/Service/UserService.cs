using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZT.Permission.Enums;
using ZT.Permission.Models;
using ZT.Permission.Logics;
using Newtonsoft.Json;
using ZT.Framework.Common;

namespace ZT.Permission.Service
{
    public class UserService : IUserService
    {
        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <returns></returns>
        public int GetUserId()
        {
            var num = 0;
            try
            {
                num = MHSeqNoLogic.GetUserId();
            }
            catch (Exception ex)
            {
                //写日志
            }
            return num;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<Users> GetAllUser()
        {
            UsersLogic ul = new UsersLogic();

            return ul.GetAllUser("");
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<Users> GetAllUser(AccountStatusEnum status)
        {
            UsersLogic ul = new UsersLogic();
         
            var where = string.Format(" Status = {0}", (int)status);
            
            return ul.GetAllUser(where);
        }

        public Users GetUserInfo(int userId)
        {
            return null;
        }

        public List<Users> GetUserByUserName(string userName)
        {
            return null;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="jsonBase">用户基本信息</param>
        /// <param name="jsonLogin">用户登录信息</param>
        /// <returns></returns>
        public bool CreateUser(string jsonBase, string jsonLogin)
        {
            //用户基本信息
            var _jsonBase = SystemDataProvider.GetStandardJson(jsonBase.ToString());
            Users user = JsonConvert.DeserializeObject<Users>(_jsonBase);
            user.ID = Guid.NewGuid().ToString("N").ToUpper();
            user.CreateDate = DateTime.Now;
            user.LastChanged = DateTime.Now;

            //用户登录信息
            var _jsonLogin = SystemDataProvider.GetStandardJson(jsonLogin.ToString());
            Membership member = JsonConvert.DeserializeObject<Membership>(_jsonLogin);
            member.ID = Guid.NewGuid().ToString("N").ToUpper();
            member.UserId = user.UserId;
            member.LoweredLoginName = member.LoginName.ToLower();
            member.Email = user.Email;
            member.LoweredEmail = user.Email.ToLower();
            member.CreateDate = DateTime.Now;

            //创建用户基本信息
            UsersLogic uLogic = new UsersLogic();
            var value = uLogic.CreateUser(user);

            //创建用户登录信息
            MembershipLogic mLogic = new MembershipLogic();
            value = mLogic.CreateMember(member);

            return value;
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
