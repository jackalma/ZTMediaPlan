using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ZT.Framework.Data;

namespace ZT.Permission.Models
{
    /// <summary>
    /// 用户登录信息
    /// </summary>
    public class Membership:Entity
    {
        #region 构造函数
        public Membership()
        {

        }
        #endregion

        #region 字段
        private string _loginName = string.Empty;
        private string _loweredLoginName = string.Empty;
        private string _password = string.Empty;
        private string _email = string.Empty;
        private string _loweredEmail = string.Empty;
        private string _passwordQuestion = string.Empty;
        private string _passwordAnswer = string.Empty;
        private DateTime _createDate = DateTime.MinValue;
        private DateTime _lastLoginDate = DateTime.MinValue;
        private string _lastLoginIP = string.Empty;
        private int _failedPasswordAttemptCount = 0;        
        #endregion

        #region 属性
        public string ID { get; set; }
        public int UserId { get; set; }
        public string LoginName { get { return _loginName; } set { _loginName = value; } }
        public string LoweredLoginName { get { return _loweredLoginName; } set { _loweredLoginName = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string LoweredEmail { get { return _loweredEmail; } set { _loweredEmail = value; } }
        public string PasswordQuestion { get { return _passwordQuestion; } set { _passwordQuestion = value; } }
        public string PasswordAnswer { get { return _passwordAnswer; } set { _passwordAnswer = value; } }
        public DateTime CreateDate { get { return _createDate; } set { _createDate = value; } }
        public DateTime LastLoginDate { get { return _lastLoginDate; } set { _lastLoginDate = value; } }
        public string LastLoginIP { get { return _lastLoginIP; } set { _lastLoginIP = value; } }
        public int FailedPasswordAttemptCount { get { return _failedPasswordAttemptCount; } set { _failedPasswordAttemptCount = value; } }       
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
        public override DbCommand GetSelectCommand(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = @"SELECT ID,UserId,LoginName,LoweredLoginName,[Password],Email,LoweredEmail,PasswordQuestion,
                                  PasswordAnswer,CreateDate,LastLoginDate,LastLoginIP,FailedPasswordAttemptCount
                                  FROM mh_Membership";

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
            string sql_insert = @" INSERT 
                                   INTO mh_Membership(ID,UserId,LoginName,LoweredLoginName,[Password],Email,LoweredEmail,PasswordQuestion,
                                                      PasswordAnswer,CreateDate,LastLoginDate,LastLoginIP,FailedPasswordAttemptCount)
                                   VALUES(@ID,@UserId,@LoginName,@LoweredLoginName,@Password,@Email,@LoweredEmail,@PasswordQuestion,
                                          @PasswordAnswer,@CreateDate,@LastLoginDate,@LastLoginIP,@FailedPasswordAttemptCount)";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_insert);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@ID", DbType.String, ID);
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, UserId);
            db.AddInParameter(dbCommand, "@LoginName", DbType.String, LoginName);
            db.AddInParameter(dbCommand, "@LoweredLoginName", DbType.String, LoweredLoginName);
            db.AddInParameter(dbCommand, "@Password", DbType.String, Password);
            db.AddInParameter(dbCommand, "@Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "@LoweredEmail", DbType.String, LoweredEmail);
            db.AddInParameter(dbCommand, "@PasswordQuestion", DbType.String, PasswordQuestion);
            db.AddInParameter(dbCommand, "@PasswordAnswer", DbType.String, PasswordAnswer);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, CreateDate);
            db.AddInParameter(dbCommand, "@LastLoginDate", DbType.DateTime, LastLoginDate);
            db.AddInParameter(dbCommand, "@LastLoginIP", DbType.String, LastLoginIP);
            db.AddInParameter(dbCommand, "@FailedPasswordAttemptCount", DbType.Int32, FailedPasswordAttemptCount);

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
            string sql_update = @" UPDATE mh_Membership
                                   SET LoginName=@LoginName,LoweredLoginName=@LoweredLoginName,[Password]=@Password,Email=@Email,LoweredEmail=@LoweredEmail,PasswordQuestion=@PasswordQuestion,
                                   PasswordAnswer=@PasswordAnswer,CreateDate=@CreateDate,LastLoginDate=@LastLoginDate,LastLoginIP=@LastLoginIP,FailedPasswordAttemptCount=@FailedPasswordAttemptCount WHERE UserId=@UserId";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_update);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, UserId);
            db.AddInParameter(dbCommand, "@LoginName", DbType.String, LoginName);
            db.AddInParameter(dbCommand, "@LoweredLoginName", DbType.String, LoweredLoginName);
            db.AddInParameter(dbCommand, "@Password", DbType.String, Password);
            db.AddInParameter(dbCommand, "@Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "@LoweredEmail", DbType.String, LoweredEmail);
            db.AddInParameter(dbCommand, "@PasswordQuestion", DbType.String, PasswordQuestion);
            db.AddInParameter(dbCommand, "@PasswordAnswer", DbType.String, PasswordAnswer);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, CreateDate);
            db.AddInParameter(dbCommand, "@LastLoginDate", DbType.DateTime, LastLoginDate);
            db.AddInParameter(dbCommand, "@LastLoginIP", DbType.String, LastLoginIP);
            db.AddInParameter(dbCommand, "@FailedPasswordAttemptCount", DbType.Int32, FailedPasswordAttemptCount);

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
            UserId = DataConvert.GetInt32Value(row["UserId"]);
            LoginName = DataConvert.GetStringValue(row["LoginName"]);
            LoweredLoginName = DataConvert.GetStringValue(row["LoweredLoginName"]);
            Password = DataConvert.GetStringValue(row["Password"]);
            Email = DataConvert.GetStringValue(row["Email"]);
            LoweredEmail = DataConvert.GetStringValue(row["LoweredEmail"]);
            PasswordQuestion = DataConvert.GetStringValue(row["PasswordQuestion"]);
            PasswordAnswer = DataConvert.GetStringValue(row["PasswordAnswer"]);
            CreateDate = DataConvert.GetDateTimeValue(row["CreateDate"]);
            LastLoginDate = DataConvert.GetDateTimeValue(row["LastLoginDate"]);
            LastLoginIP = DataConvert.GetStringValue(row["LastLoginIP"]);
            FailedPasswordAttemptCount = DataConvert.GetInt32Value(row["FailedPasswordAttemptCount"]);
        }
        #endregion
    }
}
