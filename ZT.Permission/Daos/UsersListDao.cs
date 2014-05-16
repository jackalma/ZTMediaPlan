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
    public class UsersListDao:EntityDao<UsersList>
    {
        public override int Insert(UsersList obj)
        {
            return base.Insert(obj);
        }

        public override void Insert(IEnumerable<UsersList> objList)
        {
            base.Insert(objList);
        }

        public override List<UsersList> Select(UsersList obj)
        {
            return base.Select(obj);
        }

        public override int Update(UsersList obj)
        {
            return base.Update(obj);
        }

        public override int Delete(UsersList obj)
        {
            return base.Delete(obj);
        }

        public DataSet SelectUsersList(UsersList ul)
        {
            DbCommand selectCommand = ul.SelectUsersList(DataAccess.Db);

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
