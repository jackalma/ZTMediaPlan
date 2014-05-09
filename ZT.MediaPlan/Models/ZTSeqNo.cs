//==================================================================
//实现自动生成编号，包括客户编号
//Create by jackal on 2014-05-9
//Last Changed by jackal on 2014-05-9
//==================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ZT.Framework.Data;

namespace ZT.MediaPlan.Models
{
    [Serializable]
    public class ZTSeqNo : Entity
    {
        #region 构造函数
        public ZTSeqNo()
        {

        }
        #endregion

        #region 字段
        //客户编号
        private int _customerNo = 0;
        private DateTime _last_Changed = DateTime.MinValue;

        #endregion

        #region 属性
        /// <summary>
        /// 客户编号
        /// </summary>
        public int CustomerNo
        {
            get { return _customerNo; }
            set { _customerNo = value; }
        }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime Last_Changed
        {
            get { return _last_Changed; }
            set { _last_Changed = value; }
        }

        #endregion

        #region 实现方法

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand GetSelectCommand(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = "SELECT CUSTOMERNO,LAST_CHANGED FROM ZT_SEQNO";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand GetUpdateCommand(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_update = "UPDATE ZT_SEQNO SET CUSTOMERNO=@CUSTOMERNO,LAST_CHANGED=@LAST_CHANGED";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_update);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@CUSTOMERNO", DbType.Int32, CustomerNo);
            db.AddInParameter(dbCommand, "@LAST_CHANGED", DbType.Int32, Last_Changed);
            dbCommand.Dispose();

            return dbCommand;
        }

        public override DbCommand GetDeleteCommand(Database db)
        {
            throw new NotImplementedException();
        }

        public override DbCommand GetInsertCommand(Database db)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="row"></param>
        public override void GetData(DataRow row)
        {
            CustomerNo = DataConvert.GetInt32Value(row["CUSTOMERNO"]);
            Last_Changed = DataConvert.GetDateTimeValue(row["LAST_CHANGED"]);
        }

        #endregion

        #region 方法
        public DbCommand GetSeqNo(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = "SELECT CUSTOMERNO FROM ZT_SEQNO";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Dispose();

            return dbCommand;
        }
        #endregion

    }
}