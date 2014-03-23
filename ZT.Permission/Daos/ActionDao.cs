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
    public class ActionDao : EntityDao<Actions>
    {
        public override int Insert(Actions obj)
        {
            try
            {
                return base.Insert(obj);
            }
            catch (Exception ex)
            {
                //写入调试日志
                try
                {
                    if (obj != null)
                    {

                    }
                }
                catch { }

                throw ex;
            }          
        }

        public override void Insert(IEnumerable<Actions> objList)
        {            
            try
            {
                base.Insert(objList);
            }
            catch (Exception ex)
            {
                //写入调试日志
                try
                {
                    if (objList != null)
                    {

                    }
                }
                catch { }

                throw ex;
            }  
        }

        public override int Update(Actions obj)
        {            
            try
            {
                return base.Update(obj);
            }
            catch (Exception ex)
            {
                //写入调试日志
                try
                {
                    if (obj != null)
                    {

                    }
                }
                catch { }

                throw ex;
            }  
        }

        public override List<Actions> Select(Actions obj)
        {            
            try
            {
                return base.Select(obj);
            }
            catch (Exception ex)
            {
                //写入调试日志
                try
                {
                    if (obj != null)
                    {

                    }
                }
                catch { }

                throw ex;
            }  
        }

        public override int Delete(Actions obj)
        {            
            try
            {
                return base.Delete(obj);
            }
            catch (Exception ex)
            {
                //写入调试日志
                try
                {
                    if (obj != null)
                    {

                    }
                }
                catch { }

                throw ex;
            }  
        }

    }
}
