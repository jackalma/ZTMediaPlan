using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ZT.Framework.Data;

namespace ZT.Permission.Models
{
    /// <summary>
    /// 用户列表信息
    /// </summary>
    [Serializable]
    public class UsersList : Entity
    {
        #region 构造函数
        public UsersList()
        {

        }
        #endregion

        #region 字段
        private string _userName = string.Empty;
        private string _engName = string.Empty;
        private string _loginName = string.Empty;
        private int _jobTitle = 0;
        private int _status = -2;
        private int _deptId = 0;
        private int _parentId = 0;
        private DateTime _joinDate = DateTime.MinValue;
        private DateTime _leaveDate = DateTime.MinValue;
        #endregion

        #region 属性
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string UserName { get { return _userName; } set { _userName = value; } }

        /// <summary>
        /// 英文名
        /// </summary>
        public string EngName { get { return _engName; } set { _engName = value; } }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get { return _loginName; } set { _loginName = value; } }

        /// <summary>
        /// 部门编号
        /// </summary>
        public int DeptId { get { return _deptId; } set { _deptId = value; } }

        /// <summary>
        /// 职位
        /// </summary>
        public int JobTitle { get { return _jobTitle; } set { _jobTitle = value; } }

        /// <summary>
        /// 直接上级
        /// </summary>
        public int ParentId { get { return _parentId; } set { _parentId = value; } }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime JoinDate { get { return _joinDate; } set { _joinDate = value; } }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime LeaveDate { get { return _leaveDate; } set { _leaveDate = value; } }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get { return _status; } set { _status = value; } }
        #endregion

        #region SQL属性
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where { get; set; }
        #endregion

        #region 实现方法
        public override DbCommand GetSelectCommand(Database db)
        {
            throw new NotImplementedException();
        }

        public override DbCommand GetUpdateCommand(Database db)
        {
            throw new NotImplementedException();
        }

        public override DbCommand GetInsertCommand(Database db)
        {
            throw new NotImplementedException();
        }

        public override DbCommand GetDeleteCommand(Database db)
        {
            throw new NotImplementedException();
        }

        public override void GetData(DataRow row)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 方法

        /// <summary>
        /// 获取简单的用户信息
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public DbCommand SelectUsersList(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = @"SELECT u.ID,u.UserId,
m.LoginName,u.UserName,u.EngName,u.DeptId,u.JobTitle,u.ParentId,u.JoinDate,u.LeaveDate,u.Status 
FROM mh_users u
INNER JOIN mh_membership m
ON u.UserId=m.UserId
WHERE u.Status = @Status";

            if (!string.IsNullOrEmpty(Where)) sql_select += " AND ";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);

            dbCommand.Dispose();

            return dbCommand;
        }

        #endregion


    }
}
