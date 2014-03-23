
namespace ZT.Permission.Enums
{
    public class MHEnum
    {
        #region 性别
        public static string MapSexEnum(SexEnum v)
        {
            switch (v)
            {
                case SexEnum.Female:
                    return "女";
                case SexEnum.Male:
                    return "男";               
            }
            return "";
        }
        public static string MapSexEnum(int v)
        {
            return MapSexEnum((SexEnum)v);
        }
        #endregion

        #region 婚姻状况
        public static string MapMaritalEnum(MaritalEnum v)
        {
            switch (v)
            {
                case MaritalEnum.Married:
                    return "已婚";
                case MaritalEnum.Love:
                    return "恋爱中";
                case MaritalEnum.Single:
                    return "单身";
                case MaritalEnum.Separate:
                    return "分居";
                case MaritalEnum.Divorce:
                    return "离异";
                case MaritalEnum.Secrecy:
                    return "保密";
            }
            return "";
        }
        public static string MapMaritalEnum(int v)
        {
            return MapMaritalEnum((MaritalEnum)v);
        }
        #endregion

        #region 数据状态
        public static string MapDataStatus(DataStatusEnum v)
        {
            switch (v)
            { 
                case DataStatusEnum.Disabled:
                    return "不可用";
                case DataStatusEnum.Enabled:
                    return "正常";
            }
            return "";
        }
        public static string MapDataStatus(int v)
        {
            return MapDataStatus((DataStatusEnum)v);
        }
        #endregion

        #region 用户状态
        public static string MapAccountStatus(AccountStatusEnum v)
        {
            switch (v)
            {
                case AccountStatusEnum.Forbidden:
                    return "已锁定";
                case AccountStatusEnum.Deleted:
                    return "已注销";
                case AccountStatusEnum.Inexistence:
                    return "不存在";
                case AccountStatusEnum.Active:
                    return "正常";
                case AccountStatusEnum.Quit:
                    return "离职";
            }
            return "";
        }
        public static string MapAccountStatus(int v)
        {
            return MapAccountStatus((AccountStatusEnum)v);
        }
        #endregion

        #region 职位
        public static string MapJobTitle(JobTitleEnum v)
        {
            switch (v)
            {
                case JobTitleEnum.DirectSales:
                    return "直客销售";
                case JobTitleEnum.ChannelSales:
                    return "渠道销售";
                case JobTitleEnum.TeamLeader:
                    return "团队负责人";
                case JobTitleEnum.DeptManager:
                    return "部门经理";
                case JobTitleEnum.CEO:
                    return "CEO";
            }
            return "";
        }
        public static string MapJobTitle(int v)
        {
            return MapJobTitle((JobTitleEnum)v);
        }
        #endregion

        #region 部门
        public static string MapDept(DeptEnum v)
        {
            switch (v)
            {
                case DeptEnum.Sales:
                    return "销售部";
                case DeptEnum.MediaPlanning:
                    return "策划部";
                case DeptEnum.CE:
                    return "客户服务部";
                case DeptEnum.BD:
                    return "业务拓展部";
                case DeptEnum.Creative:
                    return "创意部";
            }
            return "";
        }
        public static string MapDept(int v)
        {
            return MapDept((DeptEnum)v);
        }
        #endregion
    }

    public enum SexEnum
    {
        /// <summary>
        /// 女
        /// </summary>
        Female = 1,

        /// <summary>
        /// 男
        /// </summary>
        Male = 2
    }

    public enum MaritalEnum
    {
        /// <summary>
        /// 已婚
        /// </summary>
        Married = 1,

        /// <summary>
        /// 恋爱中
        /// </summary>
        Love = 2,

        /// <summary>
        /// 单身
        /// </summary>
        Single = 3,

        /// <summary>
        /// 分居
        /// </summary>
        Separate = 4,

        /// <summary>
        /// 离异
        /// </summary>
        Divorce = 5,

        /// <summary>
        /// 保密
        /// </summary>
        Secrecy = 6
    }

    /// <summary>
    /// 数据状态
    /// </summary>
    public enum DataStatusEnum
    {
        /// <summary>
        /// 不可用
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// 正常
        /// </summary>
        Enabled = 1
    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum AccountStatusEnum
    {
        /// <summary>
        /// 已锁定
        /// </summary>
        Forbidden = -2,

        /// <summary>
        /// 已注销
        /// </summary>
        Deleted = -1,

        /// <summary>
        /// 不存在
        /// </summary>
        Inexistence = 0,

        /// <summary>
        /// 正常
        /// </summary>
        Active = 1,

        /// <summary>
        /// 离职
        /// </summary>
        Quit = 2
    }

    /// <summary>
    /// 职位
    /// </summary>
    public enum JobTitleEnum
    {
        /// <summary>
        /// 直客销售
        /// </summary>
        DirectSales = 1,

        /// <summary>
        /// 渠道销售
        /// </summary>
        ChannelSales = 2,

        /// <summary>
        /// 团队负责人
        /// </summary>
        TeamLeader = 3,

        /// <summary>
        /// 部门经理
        /// </summary>
        DeptManager = 4,

        /// <summary>
        /// CEO
        /// </summary>
        CEO = 5
    }

    /// <summary>
    /// 部门
    /// </summary>
    public enum DeptEnum
    {
        /// <summary>
        /// 销售部
        /// </summary>
        Sales = 1,

        /// <summary>
        /// 策划
        /// </summary>
        MediaPlanning = 2,

        /// <summary>
        /// 客服
        /// </summary>
        CE = 3,

        /// <summary>
        /// 业务拓展
        /// </summary>
        BD = 4,

        /// <summary>
        /// 创意
        /// </summary>
        Creative = 5

    }
}
