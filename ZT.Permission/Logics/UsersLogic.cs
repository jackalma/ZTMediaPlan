using System.Collections.Generic;
using System.Data;
using ZT.Permission.Models;
using ZT.Permission.Daos;
using ZT.Framework.Common;

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
            Users us = new Users();
            us.Where = where;

            DataSet ds = new UsersDao().SelectAllUser(us);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetListUsers(ds);
            }
            return null;
        }

        /// <summary>
        /// 获取某个用户基本信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public Users GetUserInfo(int userId)
        {
            Users us = new Users();
            us.UserId = userId;

            DataSet ds = new UsersDao().SelectUserByUserId(us);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetListUsers(ds)[0];    
            }
            return null;
        }

        /// <summary>
        /// 模糊查询用户
        /// </summary>
        /// <param name="userName">昵称</param>
        /// <returns></returns>
        public List<Users> GetUserByUserName(string userName)
        {
            Users us = new Users();
            us.UserName = userName;

            DataSet ds = new UsersDao().SelectUserByUserName(us);

            if (ds.Tables[0].Rows.Count > 0)
            {
                return GetListUsers(ds);
            }
            return null;
        }

        /// <summary>
        /// 获取用户总积分
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Users GetPoints(int userId)
        {
            Users us = new Users();
            us.UserId = userId;

            DataSet ds = new UsersDao().SelectUserPoints(us);

            if (ds.Tables[0].Rows.Count > 0)
            {
                us.TotalPoints = ds.Tables[0].Rows[0]["TotalPoints"].ToString().ToInteger();
                us.AvailablePoints = ds.Tables[0].Rows[0]["AvailablePoints"].ToString().ToInteger();
            }
            else
            {
                us.TotalPoints = 0;
                us.AvailablePoints = 0;
            }
            return us;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool CreateUser(Users us)
        {
            if (new UsersDao().CreateUser(us) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public bool UpdateUser(Users us)
        {
            if (new UsersDao().UpdateUser(us) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新积分
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="totalPoints">总积分</param>
        /// <param name="availablePoints">可用积分</param>
        /// <returns></returns>
        public bool UpdatePoints(int userId, int totalPoints, int availablePoints)
        {
            Users us = new Users();
            us.UserId = userId;
            us.TotalPoints = totalPoints;
            us.AvailablePoints = availablePoints;

            if (new UsersDao().UpdatePoints(us) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新头像地址
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="headUrl"></param>
        /// <returns></returns>
        public bool UpdateHeadUrl(int userId,string headUrl)
        {
            Users us = new Users();
            us.UserId = userId;
            us.HeadUrl = headUrl;

            if (new UsersDao().UpdateHeadUrl(us) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新签名
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public bool UpdateSignature(int userId, string signature)
        {
            Users us = new Users();
            us.UserId = userId;
            us.Signature = signature;

            if (new UsersDao().UpdateSignature(us) > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(int userId)
        {
            Users us = new Users();
            us.UserId = userId;

            if (new UsersDao().DeleteUser(us) > 0)
                return true;
            else
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
                us.HeadUrl = dt.Rows[i]["HeadUrl"].ToString();
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
