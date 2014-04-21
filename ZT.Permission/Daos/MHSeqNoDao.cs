using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using ZT.Permission.Models;
using ZT.Framework.DataAccess;
using ZT.Framework.Data;

namespace ZT.Permission.Daos
{
    [Serializable]
    public class MHSeqNoDao : EntityDao<MHSeqNo>
    {
        #region 实现方法
        public override int Insert(MHSeqNo obj)
        {
            return base.Insert(obj);
        }

        public override void Insert(IEnumerable<MHSeqNo> objList)
        {
            base.Insert(objList);
        }

        public override List<MHSeqNo> Select(MHSeqNo obj)
        {
            return base.Select(obj);
        }

        public override int Update(MHSeqNo obj)
        {
            return base.Update(obj);
        }

        public override int Delete(MHSeqNo obj)
        {
            return base.Delete(obj);
        }
        #endregion

        /// <summary>
        /// 更新用户编号
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public int UpdateUserId(MHSeqNo sn)
        {
            DbCommand updateCommand = sn.UpdateUserId(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteNonQuery(updateCommand);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// 更新角色编号
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public int UpdateRoleId(MHSeqNo sn)
        {
            DbCommand updateCommand = sn.UpdateRoleId(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteNonQuery(updateCommand);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// 更新动作编号
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public int UpdateActionId(MHSeqNo sn)
        {
            DbCommand updateCommand = sn.UpdateActionId(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteNonQuery(updateCommand);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
    }
}
