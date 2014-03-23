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
    public class RolesDao:EntityDao <Roles>
    {
        public override int Insert(Roles obj)
        {
            return base.Insert(obj);
        }

        public override void Insert(IEnumerable<Roles> objList)
        {
            base.Insert(objList);
        }

        public override List<Roles> Select(Roles obj)
        {
            return base.Select(obj);
        }

        public override int Update(Roles obj)
        {
            return base.Update(obj);
        }

        public override int Delete(Roles obj)
        {
            return base.Delete(obj);
        }
     
    }
}
