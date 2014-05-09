//==================================================================
//实现自动生成编号，包括客户编号
//Create by jackal on 2014-05-9
//Last Changed by jackal on 2014-05-9
//==================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZT.Framework.DataAccess;
using ZT.Framework.Data;
using ZT.MediaPlan.Models;

namespace ZT.MediaPlan.Daos
{
    [Serializable]
    public class ZTSeqNoDao : EntityDao<ZTSeqNo>
    {
        public override int Insert(ZT.MediaPlan.Models.ZTSeqNo obj)
        {
            return base.Insert(obj);
        }

        public override void Insert(IEnumerable<ZTSeqNo> objList)
        {
            base.Insert(objList);
        }

        public override List<ZTSeqNo> Select(ZTSeqNo obj)
        {
            return base.Select(obj);
        }

        public override int Update(ZTSeqNo obj)
        {
            return base.Update(obj);
        }

        public override int Delete(ZTSeqNo obj)
        {
            return base.Delete(obj);
        }
    }
}