using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ZT.Framework.Data ;

namespace ZT.Permission.Models
{
    /// <summary>
    /// 角色信息
    /// </summary>
    [Serializable]
    public class Roles:Entity
    {
        #region 构造函数
        public Roles()
        { 
            
        }
        #endregion

        #region 字段
        private string _roleName = string.Empty;
        private string _loweredRoleName = string.Empty;
        private DateTime _createDate = DateTime.MinValue;
        private int _status = 1;
        private string _description = string.Empty;
        #endregion

        #region 属性
        public string ID { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get { return _roleName; } set { _roleName = value; } }
        public string LoweredRoleName { get { return _loweredRoleName; } set { _loweredRoleName = value; } }
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
        /// 查询
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand  GetSelectCommand(Database db)
        {
 	        if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = @"SELECT ID,RoleId,RoleName,LoweredRoleName,CreateDate,[Status],[Description] FROM mh_Roles";

            if (!string.IsNullOrEmpty(Where)) sql_select += " Where " + Where;

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;

            dbCommand.Dispose();

            return dbCommand;
        }               

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand GetInsertCommand(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");
            string sql_insert = @"INSERT INTO mh_Roles(ID,RoleId,RoleName,LoweredRoleName,CreateDate,[Status],[Description])
                                  VALUES(@ID,@RoleId,@RoleName,@LoweredRoleName,@CreateDate,@Status,@Description)";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_insert);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@ID", DbType.String, ID);
            db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, RoleId);
            db.AddInParameter(dbCommand, "@RoleName", DbType.String, RoleName);
            db.AddInParameter(dbCommand, "@LoweredRoleName", DbType.String, LoweredRoleName);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, CreateDate);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);
            db.AddInParameter(dbCommand, "@Description", DbType.String, Description);

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
            string sql_update = @"UPDATE mh_Roles SET RoleName=@RoleName,LoweredRoleName=@LoweredRoleName,
                                  CreateDate=@CreateDate,[Status]=@Status,[Description]=@Description WHERE RoleId=@RoleId";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_update);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, RoleId);
            db.AddInParameter(dbCommand, "@RoleName", DbType.String, RoleName);
            db.AddInParameter(dbCommand, "@LoweredRoleName", DbType.String, LoweredRoleName);
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
            ID = DataConvert.GetStringValue(row["ID"]);
            RoleId = DataConvert.GetInt32Value(row["RoleId"]);
            RoleName = DataConvert.GetStringValue(row["RoleName"]);
            LoweredRoleName = DataConvert.GetStringValue(row["LoweredRoleName"]);
            CreateDate = DataConvert.GetDateTimeValue(row["CreateDate"]);
            Status = DataConvert.GetInt32Value(row["Status"]);
            Description = DataConvert.GetStringValue(row["Description"]);
        }
                
        #endregion
    }
}
