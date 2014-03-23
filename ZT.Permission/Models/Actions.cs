using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ZT.Framework.Data;

namespace ZT.Permission.Models
{
    /// <summary>
    /// 动作
    /// </summary>
    [Serializable]
    public class Actions : Entity
    {
        #region 构造函数
        public Actions()
        {

        }
        #endregion

        #region 字段
        private string _actionName = string.Empty;
        private string _loweredActionName = string.Empty;
        private DateTime _createDate = DateTime.MinValue;
        private int _status = 1;
        private string _description = string.Empty;
        #endregion

        #region 属性
        public string ID { get; set; }
        public int ActionId { get; set; }
        public string ActionName { get { return _actionName; } set { _actionName = value; } }
        public string LoweredActionName { get { return _loweredActionName; } set { _loweredActionName = value; } }
        public DateTime CreateDate { get { return _createDate; } set { _createDate = value; } }
        public int Status { get { return _status; } set { _status = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        #endregion

        #region SQL属性
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where { get; set; }
        #endregion

        #region 实现方法
        
        /// <summary>
        /// 查询动作
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand GetSelectCommand(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = @"SELECT ID,ActionId,ActionName,LoweredActionName,CreateDate,[Status],[Description] FROM mh_Actions";

            if (!string.IsNullOrEmpty(Where)) sql_select += " Where " + Where;

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;

            dbCommand.Dispose();

            return dbCommand;
        }
        
        /// <summary>
        /// 创建动作
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand GetInsertCommand(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");
            string sql_insert = @"INSERT INTO mh_Actions(ID,ActionId,ActionName,LoweredActionName,CreateDate,[Description],[Status] 
                                  VALUES(@ID,@ActionId,@ActionName,@LoweredActionName,@CreateDate,@Status,@Description)";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_insert);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@ID", DbType.String, ID);
            db.AddInParameter(dbCommand, "@ActionId", DbType.Int32, ActionId);
            db.AddInParameter(dbCommand, "@ActionName", DbType.String, ActionName);
            db.AddInParameter(dbCommand, "@LoweredActionName", DbType.String, _loweredActionName);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, CreateDate);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);
            db.AddInParameter(dbCommand, "@Description", DbType.String, Description);

            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 更新动作
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand GetUpdateCommand(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_update = @"UPDATE mh_Actions SET ActionName=@ActionName,LoweredActionName=@LoweredActionName,CreateDate=@CreateDate,[Description]=@Description,[Status]=@Status WHERE ActionId=@ActionId";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_update);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@ActionId", DbType.Int32, ActionId);
            db.AddInParameter(dbCommand, "@ActionName", DbType.String, ActionName);
            db.AddInParameter(dbCommand, "@LoweredActionName", DbType.String, _loweredActionName);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, CreateDate);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);
            db.AddInParameter(dbCommand, "@Description", DbType.String, Description);

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
        /// 获取数据
        /// </summary>
        /// <param name="row"></param>
        public override void GetData(DataRow row)
        {
            if (row == null) throw new ArgumentNullException("row");

            ID = DataConvert.GetStringValue(row["ID"]);
            ActionId = DataConvert.GetInt32Value(row["ActionId"]);
            ActionName = DataConvert.GetStringValue(row["ActionName"]);
            LoweredActionName = DataConvert.GetStringValue(row["LoweredActionName"]);
            CreateDate = DataConvert.GetDateTimeValue(row["CreateDate"]);
            Status = DataConvert.GetInt32Value(row["Status"]);
            Description = DataConvert.GetStringValue(row["Description"]);
        }
        #endregion
    }
}
