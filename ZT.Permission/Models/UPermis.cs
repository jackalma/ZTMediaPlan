using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ZT.Framework.Data;

namespace ZT.Permission.Models
{
    /// <summary>
    /// 用户角色/角色动作 关系
    /// </summary>
    [Serializable]
    public class UPermis : Entity
    {
        #region 构造函数

        #endregion

        #region 属性
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int ActionId { get; set; }
        public int Status { get; set; }
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
        /// 用户添加角色
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public DbCommand AddRolesForUser(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_insert = @"INSERT INTO mh_UsersInRoles(UserId,RoleId,[Status])
                                  VALUES(@UserId,@RoleId,@Status)";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_insert);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, UserId);
            db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, RoleId);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);

            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 用户删除/启用角色
        /// 给用户添加角色之前，先检查此用户是否已经有这个角色，状态是删除。如果有直接更改状态启用。
        /// 如果没有，则添加用户和角色对应关系
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public DbCommand OptRolesForUser(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_delete = @"UPDATE mh_UsersInRoles SET [Status] =@Status WHERE UserId = @UserId AND RoleId =@RoleId";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_delete);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, UserId);
            db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, RoleId);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);

            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 根据状态查看用户拥有启用的角色或者删除的角色
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public DbCommand SelectRolesForUser(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = @"SELECT M.UserId,M.RoleId,R.RoleName,R.LoweredRoleName,R.[Description] FROM mh_UsersInRoles M,mh_Roles R
                                  WHERE M.UserId=@UserId AND M.[Status]=@Status AND R.RoleId=M.RoleId";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, UserId);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);

            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 角色添加Action
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public DbCommand AddActionsForRole(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_insert = @"INSERT INTO mh_RolesInActions(RoleId,ActionId,[Status])
                                  VALUES(@RoleId,@ActionId,@Status)";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_insert);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, RoleId);
            db.AddInParameter(dbCommand, "@ActionId", DbType.Int32, ActionId);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);

            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 角色删除/启用动作
        /// 给角色添加动作之前，先检查此角色是否已经有这个动作，状态是删除。如果有直接更改状态启用。
        /// 如果没有，则添加角色和动作对应关系
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public DbCommand OptActionsForRole(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_delete = @"UPDATE mh_RolesInActions SET [Status] =@Status WHERE ActionId = @ActionId AND RoleId =@RoleId";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_delete);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);
            db.AddInParameter(dbCommand, "@ActionId", DbType.Int32, ActionId);
            db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, RoleId);

            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 查看角色拥有的Action
        /// 或者查看角色被删除过的Action
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public DbCommand SelectActionsForRole(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = @"SELECT M.RoleId,M.ActionId,A.ActionName,A.LoweredActionName,A.Description FROM mh_RolesInActions M,mh_Actions A
                                  WHERE M.[Status]=@Status AND M.RoleId=@RoleId AND A.ActionId =M.ActionId";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);
            db.AddInParameter(dbCommand, "@RoleId", DbType.Int32, RoleId);

            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 查看用户拥有的所有Action
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public DbCommand SelectAllActionsForUser(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = @"select distinct A.ActionId,ActionName,LoweredActionName,Description
from mh_actions A
join mh_rolesinactions R on A.ActionId=R.ActionId and R.Status=1
join mh_usersinroles U on U.RoleId=R.RoleId and U.Status=1
where U.userId=@UserId";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, UserId);

            dbCommand.Dispose();

            return dbCommand;
        }

        #endregion
    }
}
