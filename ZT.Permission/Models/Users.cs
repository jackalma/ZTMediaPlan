using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ZT.Framework.Data;

namespace ZT.Permission.Models
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
    [Serializable]
    public class Users : Entity
    {
        #region 构造函数
        public Users()
        {

        }
        #endregion

        #region 字段
        private string _userName = string.Empty;
        private string _engName = string.Empty;
        private int _sex = 0;
        private int _age = 0;
        private string _icnumber = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _taxNumber = string.Empty;
        private DateTime _birthday = DateTime.MinValue;
        private string _email = string.Empty;
        private string _constellation = string.Empty;
        private int _maritalStatus = 0;
        private string _profession = string.Empty;
        private string _corporationName = string.Empty;
        private int _jobTitle = 0;
        private string _country = string.Empty;
        private string _province = string.Empty;
        private string _city = string.Empty;
        private string _address = string.Empty;
        private string _homePage = string.Empty;
        private int _totalPoints = 0;
        private int _availablePoints = 0;
        private string _signature = string.Empty;
        private int _status = -2;
        private int _deptId = 0;
        private int _parentId = 0;
        private DateTime _joinDate = DateTime.MinValue;
        private DateTime _leaveDate = DateTime.MinValue;
        private DateTime _createDate=DateTime.MinValue;
        private DateTime _lastChanged=DateTime .MinValue;        
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
        /// 性别
        /// </summary>
        public int Sex { get { return _sex; } set { _sex = value; } }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get { return _age; } set { _age = value; } }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string ICNumber { get { return _icnumber; } set { _icnumber = value; } }

        /// <summary>
        /// 电话
        /// </summary>
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

        /// <summary>
        /// 座机
        /// </summary>
        public string TaxNumber { get { return _taxNumber; } set { _taxNumber = value; } }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get { return _email; } set { _email = value; } }

        /// <summary>
        /// 出生日
        /// </summary>
        public DateTime Birthday { get { return _birthday; } set { _birthday = value; } }

        /// <summary>
        /// 星座
        /// </summary>
        public string Constellation { get { return _constellation; } set { _constellation = value; } }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public int MaritalStatus { get { return _maritalStatus; } set { _maritalStatus = value; } }

        /// <summary>
        /// 职业
        /// </summary>
        public string Profession { get { return _profession; } set { _profession = value; } }

        /// <summary>
        /// 公司名
        /// </summary>
        public string CorporationName { get { return _corporationName; } set { _corporationName = value; } }

        /// <summary>
        /// 职位
        /// </summary>
        public int JobTitle{ get { return _jobTitle; } set { _jobTitle = value; } }
        
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get { return _country; } set { _country = value; } }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get { return _province; } set { _province = value; } }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get { return _city; } set { _city = value; } }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get { return _address; } set { _address = value; } }

        /// <summary>
        /// 主页
        /// </summary>
        public string HomePage { get { return _homePage; } set { _homePage = value; } }        

        /// <summary>
        /// 总积分
        /// </summary>
        public int TotalPoints { get { return _totalPoints; } set { _totalPoints = value; } }

        /// <summary>
        /// 可用积分
        /// </summary>
        public int AvailablePoints { get { return _availablePoints; } set { _availablePoints = value; } }

        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get { return _signature; } set { _signature = value; } }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get { return _status; } set { _status = value; } }

        /// <summary>
        /// 部门编号
        /// </summary>
        public int DeptId { get { return _deptId; } set { _deptId = value; } }

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
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get { return _createDate; } set { _createDate = value; } }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastChanged { get { return _lastChanged; } set { _lastChanged = value; } }
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

            string sql_select = @"SELECT ID,UserId,UserName,EngName,Sex,Age,ICNumber,PhoneNumber,TaxNumber,Email,Birthday,Constellation,MaritalStatus,
                                  Profession,CorporationName,JobTitle,Country,Province,City,Address,HomePage,TotalPoints,AvailablePoints,
                                  Signature,Status,DeptId,ParentId,JoinDate,LeaveDate,CreateDate,LastChanged FROM mh_Users";

            if (!string.IsNullOrEmpty(Where)) sql_select += " Where " + Where;

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;

            dbCommand.Dispose();

            return dbCommand;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override DbCommand GetInsertCommand(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");
            string sql_insert = @"INSERT 
                                  INTO mh_Users(ID,UserId,UserName,EngName,Sex,Age,ICNumber,PhoneNumber,TaxNumber,Email,Birthday,Constellation,MaritalStatus,Profession,CorporationName,
                                                JobTitle,Country,Province,City,Address,HomePage,TotalPoints,AvailablePoints,Signature,Status,DeptId,ParentId,JoinDate,LeaveDate,CreateDate,LastChanged)
                                  VALUES(@ID,@UserId,@UserName,@EngName,@Sex,@Age,@ICNumber,@PhoneNumber,@TaxNumber,@Email,@Birthday,@Constellation,@MaritalStatus,@Profession,@CorporationName,
                                         @JobTitle,@Country,@Province,@City,@Address,@HomePage,@TotalPoints,@AvailablePoints,@Signature,@Status,@DeptId,@ParentId,@JoinDate,@LeaveDate,@CreateDate,@LastChanged)";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_insert);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@ID", DbType.String, ID);
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, UserId);
            db.AddInParameter(dbCommand, "@UserName", DbType.String, UserName);
            db.AddInParameter(dbCommand, "@EngName", DbType.String, EngName);
            db.AddInParameter(dbCommand, "@Sex", DbType.Int32, Sex);
            db.AddInParameter(dbCommand, "@Age", DbType.Int32, Age);
            db.AddInParameter(dbCommand, "@ICNumber", DbType.String, ICNumber);
            db.AddInParameter(dbCommand, "@PhoneNumber", DbType.String, PhoneNumber);
            db.AddInParameter(dbCommand, "@TaxNumber", DbType.String, TaxNumber);
            db.AddInParameter(dbCommand, "@Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "@Birthday", DbType.DateTime, Birthday);
            db.AddInParameter(dbCommand, "@Constellation", DbType.String, Constellation);
            db.AddInParameter(dbCommand, "@MaritalStatus", DbType.Int32, MaritalStatus);
            db.AddInParameter(dbCommand, "@Profession", DbType.String, Profession);
            db.AddInParameter(dbCommand, "@CorporationName", DbType.String, CorporationName);
            db.AddInParameter(dbCommand, "@JobTitle", DbType.Int32, JobTitle);
            db.AddInParameter(dbCommand, "@Country", DbType.String, Country);
            db.AddInParameter(dbCommand, "@Province", DbType.String, Province);
            db.AddInParameter(dbCommand, "@City", DbType.String, City);
            db.AddInParameter(dbCommand, "@Address", DbType.String, Address);
            db.AddInParameter(dbCommand, "@HomePage", DbType.String, HomePage);            
            db.AddInParameter(dbCommand, "@TotalPoints", DbType.Int32, TotalPoints);
            db.AddInParameter(dbCommand, "@AvailablePoints", DbType.Int32, AvailablePoints);
            db.AddInParameter(dbCommand, "@Signature", DbType.String, Signature);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);
            db.AddInParameter(dbCommand, "@DeptId", DbType.Int32, DeptId);
            db.AddInParameter(dbCommand, "@ParentId", DbType.Int32, ParentId);
            db.AddInParameter(dbCommand, "@JoinDate", DbType.DateTime, JoinDate);
            db.AddInParameter(dbCommand, "@LeaveDate", DbType.DateTime, LeaveDate);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, CreateDate);
            db.AddInParameter(dbCommand, "@LastChanged", DbType.DateTime, LastChanged);
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
            string sql_update = @"UPDATE mh_Users SET 
                                    UserName=@UserName,EngName=@EngName,Sex=@Sex,Age=@Age,ICNumber=@ICNumber,PhoneNumber=@PhoneNumber,TaxNumber=@TaxNumber,Email=@Email,Birthday=@Birthday,
                                    Constellation=@Constellation,MaritalStatus=@MaritalStatus,
                                    Profession=@Profession,CorporationName=@CorporationName,JobTitle=@JobTitle,Country=@Country,Province=@Province,
                                    City=@City,Address=@Address,HomePage=@HomePage,TotalPoints=@TotalPoints,AvailablePoints=@AvailablePoints,
                                    Signature=@Signature,Status=@Status,DeptId=@DeptId,ParentId=@ParentId,JoinDate=@JoinDate,LeaveDate=@LeaveDate,CreateDate=@CreateDate,LastChanged=@LastChanged WHERE UserId=@UserId";                                    

            DbCommand dbCommand = db.GetSqlStringCommand(sql_update);
            dbCommand.CommandType = CommandType.Text;
            db.AddInParameter(dbCommand, "@UserId", DbType.Int32, UserId);
            db.AddInParameter(dbCommand, "@UserName", DbType.String, UserName);
            db.AddInParameter(dbCommand, "@EngName", DbType.String, EngName);
            db.AddInParameter(dbCommand, "@Sex", DbType.Int32, Sex);
            db.AddInParameter(dbCommand, "@Age", DbType.Int32, Age);
            db.AddInParameter(dbCommand, "@ICNumber", DbType.String, ICNumber);
            db.AddInParameter(dbCommand, "@PhoneNumber", DbType.String, PhoneNumber);
            db.AddInParameter(dbCommand, "@TaxNumber", DbType.String, TaxNumber);
            db.AddInParameter(dbCommand, "@Email", DbType.String, Email);
            db.AddInParameter(dbCommand, "@Birthday", DbType.DateTime, Birthday);
            db.AddInParameter(dbCommand, "@Constellation", DbType.String, Constellation);
            db.AddInParameter(dbCommand, "@MaritalStatus", DbType.Int32, MaritalStatus);
            db.AddInParameter(dbCommand, "@Profession", DbType.String, Profession);
            db.AddInParameter(dbCommand, "@CorporationName", DbType.String, CorporationName);
            db.AddInParameter(dbCommand, "@JobTitle", DbType.Int32, JobTitle);
            db.AddInParameter(dbCommand, "@Country", DbType.String, Country);
            db.AddInParameter(dbCommand, "@Province", DbType.String, Province);
            db.AddInParameter(dbCommand, "@City", DbType.String, City);
            db.AddInParameter(dbCommand, "@Address", DbType.String, Address);
            db.AddInParameter(dbCommand, "@HomePage", DbType.String, HomePage);
            db.AddInParameter(dbCommand, "@TotalPoints", DbType.Int32, TotalPoints);
            db.AddInParameter(dbCommand, "@AvailablePoints", DbType.Int32, AvailablePoints);
            db.AddInParameter(dbCommand, "@Signature", DbType.String, Signature);
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);
            db.AddInParameter(dbCommand, "@DeptId", DbType.Int32, DeptId);
            db.AddInParameter(dbCommand, "@ParentId", DbType.Int32, ParentId);
            db.AddInParameter(dbCommand, "@JoinDate", DbType.DateTime, JoinDate);
            db.AddInParameter(dbCommand, "@LeaveDate", DbType.DateTime, LeaveDate);
            db.AddInParameter(dbCommand, "@CreateDate", DbType.DateTime, CreateDate);
            db.AddInParameter(dbCommand, "@LastChanged", DbType.DateTime, LastChanged);
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
            UserName = DataConvert.GetStringValue(row["UserName"]);
            EngName = DataConvert.GetStringValue(row["EngName"]);
            Sex = DataConvert.GetInt32Value(row["Sex"]);
            Age = DataConvert.GetInt32Value(row["Age"]);
            ICNumber = DataConvert.GetStringValue(row["ICNumber"]);
            PhoneNumber = DataConvert.GetStringValue(row["PhoneNumber"]);
            TaxNumber = DataConvert.GetStringValue(row["TaxNumber"]);
            Email = DataConvert.GetStringValue(row["Email"]);
            Birthday = DataConvert.GetDateTimeValue(row["Birthday"]);
            Constellation = DataConvert.GetStringValue(row["Constellation"]);
            MaritalStatus = DataConvert.GetInt32Value(row["MaritalStatus"]);
            Profession = DataConvert.GetStringValue(row["Profession"]);
            CorporationName = DataConvert.GetStringValue(row["CorporationName"]);
            JobTitle = DataConvert.GetInt32Value(row["JobTitle"]);
            Country = DataConvert.GetStringValue(row["Country"]);
            Province = DataConvert.GetStringValue(row["Province"]);
            City = DataConvert.GetStringValue(row["City"]);
            Address = DataConvert.GetStringValue(row["Address"]);
            HomePage = DataConvert.GetStringValue(row["HomePage"]);
            TotalPoints = DataConvert.GetInt32Value(row["TotalPoints"]);
            AvailablePoints = DataConvert.GetInt32Value(row["AvailablePoints"]);
            Signature = DataConvert.GetStringValue(row["Signature"]);
            Status = DataConvert.GetInt32Value(row["Status"]);
            DeptId = DataConvert.GetInt32Value(row["DeptId"]);
            ParentId = DataConvert.GetInt32Value(row["ParentId"]);
            JoinDate = DataConvert.GetDateTimeValue(row["JoinDate"]);
            LeaveDate = DataConvert.GetDateTimeValue(row["LeaveDate"]);
            CreateDate = DataConvert.GetDateTimeValue(row["CreateDate"]);
            LastChanged = DataConvert.GetDateTimeValue(row["LastChanged"]);
        }       

        #endregion

        #region 方法

        /// <summary>
        /// 获取简单的用户信息
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public DbCommand SelectDirectUser(Database db)
        {
            if (db == null) throw new ArgumentNullException("dataAccess");

            string sql_select = @"SELECT UserId,UserName,JobTitle,DeptId FROM mh_users WHERE Status = @Status";

            DbCommand dbCommand = db.GetSqlStringCommand(sql_select);
            dbCommand.CommandType = CommandType.Text;            
            db.AddInParameter(dbCommand, "@Status", DbType.Int32, Status);

            dbCommand.Dispose();

            return dbCommand;
        }

        #endregion
    }
}
