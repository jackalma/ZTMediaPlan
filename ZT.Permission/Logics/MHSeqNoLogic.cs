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
                var ds = new MHSeqNoDao().SelectAllId(snm);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    userId = ds.Tables[0].Rows[0]["UserId"].ToString().ToInteger();
                    snm.UserId = ++userId;
                    snm.Last_Changed = DateTime.Now;
                }
                else
                {
                    snm.UserId = 1;
                    snm.Last_Changed = DateTime.Now;
                }

                //更新编号
                var result = new MHSeqNoDao().UpdateUserId(snm);
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
                var ds = new MHSeqNoDao().SelectAllId(snm);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    roleId = ds.Tables[0].Rows[0]["RoleId"].ToString().ToInteger();
                    snm.RoleId = ++roleId;
                    snm.Last_Changed = DateTime.Now;
                }
                else
                {
                    snm.RoleId = 1;
                    snm.Last_Changed = DateTime.Now;
                }

                //更新编号
                var result = new MHSeqNoDao().UpdateRoleId(snm);
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
                var ds = new MHSeqNoDao().SelectAllId(snm);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    actionId = ds.Tables[0].Rows[0]["ActionId"].ToString().ToInteger();
                    snm.ActionId = ++actionId;
                    snm.Last_Changed = DateTime.Now;
                }
                else
                {
                    snm.ActionId = 1;
                    snm.Last_Changed = DateTime.Now;
                }

                //更新编号
                var result = new MHSeqNoDao().UpdateActionId(snm);
            }

            return actionId;
        }
    }
}
