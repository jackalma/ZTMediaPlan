using System.Collections.Generic;
using System.Data;
using ZT.Framework.Common;
using ZT.Permission.Models;
using ZT.Permission.Daos;
using ZT.Permission.Enums;

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
        //public List<Membership> GetAllMembers(string where)
        //{
        //    MembershipDao md = new MembershipDao();

        //}

        /// <summary>
        /// 创建登录用户（注册）
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public int CreateMember(Membership ms)
        {
            MembershipDao md = new MembershipDao();
            return md.Insert(ms);
        }    

        /// <summary>
        /// 通过登录名或邮箱获取登录信息
        /// </summary>
        /// <param name="mailName"></param>
        /// <param name="vt">条件类别</param>
        /// <returns></returns>
        public List<Membership> GetMemberByMailName(string mailName, ValidType vt)
        {
            MembershipDao md = new MembershipDao();
            Membership ms = new Membership();
            if (string.IsNullOrEmpty(mailName))
                return null;

            switch (vt)
            {
                case ValidType.All:
                    ms.Where = string.Format("LoweredLoginName = {0} OR LoweredEmail= {0}", mailName.ToLower());
                    break;
                case ValidType.Mail:
                    ms.Where = string.Format("LoweredEmail= {0}", mailName.ToLower());
                    break;
                case ValidType.LoginName:
                    ms.Where = string.Format("LoweredLoginName = {0}", mailName.ToLower());
                    break;
                default:
                    ms.Where = string.Format("LoweredLoginName = {0} OR LoweredEmail= {0}", mailName.ToLower());
                    break;
            }
            
            return md.Select(ms);
        }

        /// <summary>
        /// 登录名或邮箱是否重复
        /// </summary>
        /// <param name="mailName"></param>
        /// <param name="vt">条件类别</param>
        /// <returns></returns>
        public bool RepeatMailName(string mailName,ValidType vt)
        {
            List<Membership> lms = GetMemberByMailName(mailName, vt);
            if (lms.Count > 0)
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
            List<Membership> lms = GetMemberByMailName(loginName, ValidType.All);
            if (lms.Count > 0)
            {
                Membership ms = lms[0];
                if (passWord.Equals(ms.Password))
                {
                    return true;
                }
            }

            return false;
        }
              
        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="ms"></param>
        /// <returns></returns>
        public bool UpdatePassword(Membership ms)
        {
            MembershipDao md = new MembershipDao();
            return md.Update(ms) > 0;
        }                                                                    
    }
}
