using System;
using ZT.Permission.Models;
using ZT.Permission.Daos;
using ZT.Framework.Common;

namespace ZT.Permission.Logics
{
   public class MHSeqNoLogic
    {
        private static readonly object lockObj = new object();

        /// <summary>
        /// 获取用户编号并更新
        /// </summary>
        /// <returns></returns>
        public static int GetUserId()
        {
            int userId = 0;

            lock (lockObj)
            {
                MHSeqNo snm = new MHSeqNo();

                //获取编号
                var listMS = new MHSeqNoDao().Select(snm);
                
                if (listMS.Count > 0)
                {
                    userId = listMS[0].UserId;
                    snm.UserId = ++userId;
                    snm.Last_Changed = DateTime.Now;

                    //更新编号
                    var result = new MHSeqNoDao().UpdateUserId(snm);
                }                               
            }

            return userId;
        }

        /// <summary>
        /// 获取角色编号并更新
        /// </summary>
        /// <returns></returns>
        public static int GetRoleId()
        {
            int roleId = 0;

            lock (lockObj)
            {
                MHSeqNo snm = new MHSeqNo();

                //获取编号
                var listMS = new MHSeqNoDao().Select(snm);

                if (listMS.Count > 0)
                {
                    roleId = listMS[0].RoleId;
                    snm.RoleId = ++roleId;
                    snm.Last_Changed = DateTime.Now;

                    //更新编号
                    var result = new MHSeqNoDao().UpdateRoleId(snm);
                }                               
            }

            return roleId;
        }

        /// <summary>
        /// 获取动作编号并更新
        /// </summary>
        /// <returns></returns>
        public static int GetActionId()
        {
            int actionId = 0;

            lock (lockObj)
            {
                MHSeqNo snm = new MHSeqNo();

                //获取编号
                var listMS = new MHSeqNoDao().Select(snm);

                if (listMS.Count > 0)
                {
                    actionId = listMS[0].ActionId;
                    snm.ActionId = ++actionId;
                    snm.Last_Changed = DateTime.Now;

                    //更新编号
                    var result = new MHSeqNoDao().UpdateActionId(snm);
                }                                
            }

            return actionId;
        }
    }
}
