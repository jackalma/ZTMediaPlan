using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ZT.Framework.DataAccess
{
    public class DataAccess
    {
        private static Database db;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataAccess()
        {

        }

        public static Database Db
        {
            get
            {
                if (db == null)
                {
                    db = DatabaseFactory.CreateDatabase("ztcon");

                }
                return db;
            }
        } 
    }
}
