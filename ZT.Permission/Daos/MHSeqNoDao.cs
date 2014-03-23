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

    }
}
