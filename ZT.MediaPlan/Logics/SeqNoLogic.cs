//==================================================================
//实现自动生成编号，包括客户编号
//Create by jackal on 2014-05-9
//Last Changed by jackal on 2014-05-9
//==================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZT.MediaPlan.Daos;
using ZT.MediaPlan.Models;
using ZT.MediaPlan.Enums;

namespace ZT.MediaPlan.Logics
{
    public class SeqNoLogic
    {
        private static readonly object lockObj = new object();

        /// <summary>
        /// 获取用户编号
        /// </summary>
        /// <returns></returns>
        public static int GetCustomerNo(SeqNoEnum em)
        {
            int num = 0;

            lock (lockObj)
            {
                try
                {
                    ZTSeqNo z = new ZTSeqNo();
                    List<ZTSeqNo> lno = new ZTSeqNoDao().Select(z);
                    z = lno[0];

                    switch (em)
                    {
                        case SeqNoEnum.CustomerNo:
                            num = z.CustomerNo;
                            z.CustomerNo++;
                            break;
                    }
                                        
                    z.Last_Changed = DateTime.Now;

                    new ZTSeqNoDao().Update(z);
                }
                catch (Exception ex)
                {
                    //写日志
                }
            }

            return num;
        }
    }
}