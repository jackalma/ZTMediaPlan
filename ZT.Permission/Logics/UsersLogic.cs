using System.Collections.Generic;
using System.Data;
using ZT.Permission.Models;
using ZT.Permission.Daos;
using ZT.Framework.Common;
using ZT.Permission.Enums;

namespace ZT.Permission.Logics
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
    public class UsersLogic
    {
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public List<Users> GetAllUser(string where)
        {
            UsersDao ud = new UsersDao();
            Users user = new Users();
            user.Where = where;

            return ud.Select(user);
        }

        /// <summary>
        /// 获取某个用户基本信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public Users GetUserInfo(int userId)
        {
            string where = string.Format("UserId = {0}", userId);

            List<Users> listUsers = GetAllUser(where);

            if (listUsers.Count > 0)
                return listUsers[0];

            return null;
        }

        /// <summary>
        /// 模糊查询用户
        /// </summary>
        /// <param name="userName">昵称</param>
        /// <returns></returns>
        public List<Users> GetUserByUserName(string userName)
        {
            string where = string.Format("UserName like '%{0}%' OR EngName like '%{0}%'", userName);

            List<Users> listUsers = GetAllUser(where);

            return listUsers;
        }

        
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool CreateUser(Users us)
        {
            UsersDao ud = new UsersDao();
            if (ud.Insert(us) > 0)
                return true;

            return false;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool UpdateUser(Users us)
        {
            UsersDao ud = new UsersDao();
            if (ud.Update(us) > 0)
                return true;

            return false;
        }
                      
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool DeleteUser(Users us)
        {
            UsersDao ud = new UsersDao();
            us.Status = (int)DataStatusEnum.Disabled;

            if (ud.Update(us) > 0)
                return true;

            return false;
        }

        #region 私有方法
        private List<Users> GetListUsers(DataSet ds)
        {
            List<Users> listUsers = new List<Users>();
            DataTable dt = ds.Tables[0];
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Users us = new Users();
                us.UserId = dt.Rows[i]["UserId"].ToString().ToInteger();
                us.UserName = dt.Rows[i]["UserName"].ToString();
                us.Sex = dt.Rows[i]["Sex"].ToString().ToInteger();
                us.Age = dt.Rows[i]["Age"].ToString().ToInteger();
                us.ICNumber = dt.Rows[i]["ICNumber"].ToString();
                us.PhoneNumber = dt.Rows[i]["PhoneNumber"].ToString();
                us.Email = dt.Rows[i]["Email"].ToString();
                us.Birthday = dt.Rows[i]["Birthday"].ToString().ToDateTime();
                us.Constellation = dt.Rows[i]["Constellation"].ToString();
                us.MaritalStatus = dt.Rows[i]["MaritalStatus"].ToString().ToInteger();
                us.Profession = dt.Rows[i]["Profession"].ToString();
                us.CorporationName = dt.Rows[i]["CorporationName"].ToString();
                us.Country = dt.Rows[i]["Country"].ToString();
                us.Province = dt.Rows[i]["Province"].ToString();
                us.City = dt.Rows[i]["City"].ToString();
                us.Address = dt.Rows[i]["Address"].ToString();
                us.HomePage = dt.Rows[i]["HomePage"].ToString();                
                us.TotalPoints = dt.Rows[i]["TotalPoints"].ToString().ToInteger();
                us.AvailablePoints = dt.Rows[i]["AvailablePoints"].ToString().ToInteger();
                us.Signature = dt.Rows[i]["Signature"].ToString();
                us.Status = dt.Rows[i]["Status"].ToString().ToInteger();

                listUsers.Add(us);
            }
            return listUsers;
        }
        #endregion
    }
}
