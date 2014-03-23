using System.Collections.Generic;
using System.Data;
using ZT.Framework.Common;
using ZT.Permission.Models;
using ZT.Permission.Daos;

namespace ZT.Permission.Logics
{
    /// <summary>
    /// 用户登录信息
    /// </summary>
    public class MembershipLogic
    {
        /// <summary>
        /// 获取所有登录用户信息
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public List<Membership> GetAllMembers(string where)
        {
            Membership ms = new Membership();
            ms.Where = where;

            return GetListMemberships(new MembershipDao().SelectAllMembers(ms));
        }

        /// <summary>
        /// 创建登录用户（注册）
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public int CreateMember(Membership ms)
        {
            return new MembershipDao().CreateMember(ms);
        }

        /// <summary>
        /// 登录名是否存在
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ExistLoginName(string loginName)
        {
            Membership ms = new Membership();
            ms.LoweredLoginName = loginName.ToLower();

            if (new MembershipDao().SelectExistLoginName(ms) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 邮箱是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistEmail(string email)
        {
            Membership ms = new Membership();
            ms.LoweredEmail = email.ToLower();

            if (new MembershipDao().SelectExistEmail(ms) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 登录判断
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool Login(string loginName, string passWord)
        {
            Membership ms = GetLoginInfo(loginName);
            if (ms != null)
            {
                if (ms.Password.Equals(passWord))
                    return true;
                else
                    return false;
            }
            return false;
        }

        /// <summary>
        /// 通过登录名获取用户所有信息
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public Membership GetMemberInfo(string loginName)
        {
            string where="LoweredLoginName = " + loginName.ToLower();

            List<Membership> limb = new List<Membership>();
            limb = GetAllMembers(where);

            if (limb != null && limb.Count > 0)
            {
                return limb[0];
            }
            return null;
        }

        /// <summary>
        /// 通过登录名获取用户编号、密码、邮箱
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public Membership GetLoginInfo(string loginName)
        {
            Membership ms = new Membership();
            ms.LoweredLoginName = loginName.ToLower();

            DataSet ds = new MembershipDao().SelectLoginInfo(ms);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ms.UserId = ds.Tables[0].Rows[0]["UserId"].ToString().ToInteger();
                ms.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                ms.Email = ds.Tables[0].Rows[0]["Email"].ToString();

                return ms;
            }
            return null;
        }

        /// <summary>
        /// 获取问题答案
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetAnswer(int userId)
        {
            Membership ms = new Membership();
            ms.UserId = userId;

            DataSet ds = new MembershipDao().SelectAnswer(ms);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["PasswordAnswer"].ToString();
            }
            return "";
        }

        /// <summary>
        /// 获取问题答案
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public string GetAnswer(string loginName)
        {
            Membership ms = new Membership();
            ms.LoweredLoginName = loginName.ToLower();

            DataSet ds = new MembershipDao().SelectAnswer(ms);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["PasswordAnswer"].ToString();
            }
            return "";
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public bool UpdatePassword(int userId, string newPwd)
        {
            Membership ms = new Membership();
            ms.UserId = userId;
            ms.Password = newPwd;

            if (new MembershipDao().UpdatePassword(ms) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public bool UpdatePassword(string loginName, string newPwd)
        {
            Membership ms = new Membership();
            ms.LoweredLoginName = loginName.ToLower();
            ms.Password = newPwd;

            if (new MembershipDao().UpdatePassword(ms) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改邮箱
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        public bool UpdateEmail(int userId, string newEmail)
        {
            Membership ms = new Membership();
            ms.UserId = userId;
            ms.Email = newEmail;
            ms.LoweredEmail = newEmail.ToLower();

            if (new MembershipDao().UpdateEmail(ms) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改邮箱
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="newEmail"></param>
        /// <returns></returns>
        public bool UpdateEmail(string loginName, string newEmail)
        {
            Membership ms = new Membership();
            ms.LoweredLoginName = loginName.ToLower();
            ms.Email = newEmail;
            ms.LoweredEmail = newEmail.ToLower();

            if (new MembershipDao().UpdateEmail(ms) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改问题及答案
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool UpdateQuestionAndAnswer(int userId, string question, string answer)
        {
            Membership ms = new Membership();
            ms.UserId = userId;
            ms.PasswordQuestion = question;
            ms.PasswordAnswer = answer;

            if (new MembershipDao().UpdateQuestionAndAnswer(ms) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 修改问题及答案
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public bool UpdateQuestionAndAnswer(string loginName, string question, string answer)
        {
            Membership ms = new Membership();
            ms.LoweredLoginName = loginName.ToLower();
            ms.PasswordQuestion = question;
            ms.PasswordAnswer = answer;

            if (new MembershipDao().UpdateQuestionAndAnswer(ms) > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 注销账号
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public bool MemberDisable(int userId)
        //{
        //    Membership ms = new Membership();
        //    ms.UserId = userId;

        //    if (new MembershipDao().UpdateStatusFalse(ms) > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// 注销账号
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        //public bool MemberDisable(string loginName)
        //{
        //    Membership ms = new Membership();
        //    ms.LoweredLoginName = loginName.ToLower();

        //    if (new MembershipDao().UpdateStatusFalse(ms) > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        /// <summary>
        /// 启用账号
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        //public bool MemberEnable(string loginNameOrEmail)
        //{
        //    Membership ms = new Membership();
        //    ms.LoweredEmail = loginNameOrEmail.ToLower();
        //    ms.LoweredLoginName = loginNameOrEmail.ToLower();

        //    if (new MembershipDao().UpdateStatusTrue(ms) > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        #region 私有方法
        private List<Membership> GetListMemberships(DataSet ds)
        {
            List<Membership> listMemberships = new List<Membership>();
            DataTable dt = ds.Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Membership mb = new Membership();
                mb.UserId = dt.Rows[i]["UserId"].ToString().ToInteger();
                mb.LoginName = dt.Rows[i]["LoginName"].ToString();
                mb.LoweredLoginName = dt.Rows[i]["LoweredLoginName"].ToString();
                mb.Password = dt.Rows[i]["Password"].ToString();
                mb.Email = dt.Rows[i]["Email"].ToString();
                mb.LoweredEmail = dt.Rows[i]["LoweredEmail"].ToString();
                mb.PasswordQuestion = dt.Rows[i]["PasswordQuestion"].ToString();
                mb.PasswordAnswer = dt.Rows[i]["PasswordAnswer"].ToString();
                mb.CreateDate = dt.Rows[i]["CreateDate"].ToString().ToDateTime();
                mb.LastLoginDate = dt.Rows[i]["LastLoginDate"].ToString().ToDateTime();
                mb.LastLoginIP = dt.Rows[i]["LastLoginIP"].ToString();
                mb.FailedPasswordAttemptCount = dt.Rows[i]["FailedPasswordAttemptCount"].ToString().ToInteger();               

                listMemberships.Add(mb);
            }
            return listMemberships;
        }
        #endregion
    }
}
