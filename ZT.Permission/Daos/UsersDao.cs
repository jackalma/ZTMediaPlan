using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using ZT.Permission.Models;
using ZT.Framework.DataAccess;
using ZT.Framework.Data;

namespace ZT.Permission.Daos
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
    [Serializable]
    public class UsersDao : EntityDao<Users>
    {
        public override int Insert(Users obj)
        {
            return base.Insert(obj);
        }

        public override void Insert(IEnumerable<Users> objList)
        {
            base.Insert(objList);
        }

        public override int Update(Users obj)
        {
            return base.Update(obj);
        }

        public override List<Users> Select(Users obj)
        {
            return base.Select(obj);
        }

        public override int Delete(Users obj)
        {
            return base.Delete(obj);
        }

        public DataSet SelectDirectUser(Users us)
        {
            DbCommand selectCommand = us.SelectDirectUser(DataAccess.Db);

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
