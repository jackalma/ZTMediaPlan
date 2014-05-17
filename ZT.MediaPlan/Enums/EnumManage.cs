using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZT.MediaPlan.Enums
{
    /// <summary>
    /// 对应Config文件下的JSON数据，根据编号获取中文名
    /// </summary>
    public class EnumManage
    {
        /// <summary>
        /// 部门
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string Dept(int num)
        {
            return ZT.Permission.Enums.MHEnum.MapDept(num);
        }

        /// <summary>
        /// 职位
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string JobTitle(int num)
        {
            return ZT.Permission.Enums.MHEnum.MapJobTitle(num);
        }

        /// <summary>
        /// 用户状态
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string AccountStatus(int num)
        {
            return ZT.Permission.Enums.MHEnum.MapAccountStatus(num);
        }
        
        /// <summary>
        /// 性别
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string Sex(int num)
        {
            return ZT.Permission.Enums.MHEnum.MapSexEnum(num);
        }
    }
}