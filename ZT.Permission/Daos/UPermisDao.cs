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
    public class UPermisDao : EntityDao<UPermis>
    {
        #region 实现方法
        public override int Insert(UPermis obj)
        {
            return base.Insert(obj);
        }

        public override void Insert(IEnumerable<UPermis> objList)
        {
            base.Insert(objList);
        }

        public override List<UPermis> Select(UPermis obj)
        {
            return base.Select(obj);
        }

        public override int Update(UPermis obj)
        {
            return base.Update(obj);
        }

        public override int Delete(UPermis obj)
        {
            return base.Delete(obj);
        }
        #endregion

        /// <summary>
        /// 用户添加角色
        /// </summary>
        /// <param name="ac"></param>
        /// <returns></returns>
        public int AddRolesForUser(UPermis up)
        {
            DbCommand addCommand = up.AddRolesForUser(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteNonQuery(addCommand);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// 用户删除角色或者启用角色
        /// </summary>
        /// <param name="ac"></param>
        /// <returns></returns>
        public int OptRolesForUser(UPermis up)
        {
            DbCommand addCommand = up.OptRolesForUser(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteNonQuery(addCommand);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// 查看用户拥有的角色或者删除的角色
        /// </summary>
        /// <param name="ac"></param>
        /// <returns></returns>
        public DataSet SelectRolesForUser(UPermis up)
        {
            DbCommand selectCommand = up.SelectRolesForUser(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        /// <summary>
        /// 角色添加Action
        /// </summary>
        /// <param name="ac"></param>
        /// <returns></returns>
        public int AddActionsForRole(UPermis up)
        {
            DbCommand addCommand = up.AddActionsForRole(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteNonQuery(addCommand);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// 角色删除Action或者启用Action
        /// </summary>
        /// <param name="ac"></param>
        /// <returns></returns>
        public int OptActionsForRole(UPermis up)
        {
            DbCommand deleteCommand = up.OptActionsForRole(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteNonQuery(deleteCommand);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// 查看角色拥有的Action
        /// </summary>
        /// <param name="ac"></param>
        /// <returns></returns>
        public DataSet SelectActionsForRole(UPermis up)
        {
            DbCommand selectCommand = up.SelectActionsForRole(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        /// <summary>
        /// 查看用户拥有的所有Action
        /// </summary>
        /// <param name="ac"></param>
        /// <returns></returns>
        public DataSet SelectAllActionsForUser(UPermis up)
        {
            DbCommand selectCommand = up.SelectAllActionsForUser(DataAccess.Db);

            try
            {
                return DataAccess.Db.ExecuteDataSet(selectCommand);
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }
    }
}
