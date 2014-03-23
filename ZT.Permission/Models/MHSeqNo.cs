using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ZT.Framework.Data;

namespace ZT.Permission.Models
{
    [Serializable]
    public class MHSeqNo : Entity
    {
        #region 构造参数
        public MHSeqNo()
        {

        }
        #endregion

        #region 字段
        private int _userId = 0;
        private int _roleId = 0;
        private int _actionId = 0;
        private DateTime _last_Changed = DateTime.MinValue;
        #endregion

        #region 属性
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

        /// <summary>
        /// 动作编号
        /// </summary>
        public int ActionId
        {
            get { return _actionId; }
            set { _actionId = value; }
        }

        public DateTime Last_Changed
        {
            get { return _last_Changed; }
            set { _last_Changed = value; }
        }
        #endregion

        #region 实现方法
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand GetSelectCommand(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = "SELECT UserId,RoleId,ActionId,Last_Changed FROM mh_SeqNo";

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

            string sql_update = "UPDATE mh_SeqNo SET UserId=@UserId,RoleId=@RoleId,ActionId=@ActionId,Last_Changed=@Last_Changed";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_update);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, RoleId);
            db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, RoleId);
            db.AddInParameter(dbCommand, "@ActionId", DbType.Int32, RoleId);
            db.AddInParameter(dbCommand, "@Last_Changed", DbType.DateTime, Last_Changed);
            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand GetDeleteCommand(Database db)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
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
            UserId = DataConvert.GetInt32Value(row["UserId"]);
            RoleId = DataConvert.GetInt32Value(row["RoleId"]);
            ActionId = DataConvert.GetInt32Value(row["ActionId"]);
            Last_Changed = DataConvert.GetDateTimeValue(row["Last_Changed"]);
        }
        #endregion
    }
}
