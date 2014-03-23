using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using ZT.Permission.Models;
using ZT.Framework.DataAccess;
using ZT.Framework.Data ;

namespace ZT.Permission.Daos
{
    /// <summary>
    /// 用户登录信息
    /// </summary>
    [Serializable]
    public class MembershipDao : EntityDao<Membership>
    {
        public override int Insert(Membership obj)
        {
            return base.Insert(obj);
        }

        public override void Insert(IEnumerable<Membership> objList)
        {
            base.Insert(objList);
        }

        public override List<Membership> Select(Membership obj)
        {
            return base.Select(obj);
        }

        public override int Update(Membership obj)
        {
            return base.Update(obj);
        }

        public override int Delete(Membership obj)
        {
            return base.Delete(obj);
        }

    }
}
