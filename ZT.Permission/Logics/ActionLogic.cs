using System.Data;
using System.Collections.Generic;
using ZT.Permission.Models;
using ZT.Permission.Daos;
using ZT.Framework.Common;
using ZT.Permission.Enums;

namespace ZT.Permission.Logics
{
    public class ActionLogic
    {        
        /// <summary>
        /// 通过活动名称选择一个动作
        /// 动作名为空，返回所有动作
        /// </summary>
        /// <param name="actionName">动作名</param>
        /// <returns></returns>
        public List<Actions> GetActionByActionName(string actionName)
        {
            ActionDao ad = new ActionDao();
            Actions action = new Actions();
            action.Where = string.IsNullOrEmpty(actionName) ? "" : "LoweredActionName = " + actionName.ToLower();
            return ad.Select(action);
        }

        /// <summary>
        /// 创建一个动作
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public int CreateAction(Actions action)
        {
            ActionDao ad = new ActionDao();
            return ad.Insert(action);
        }

        /// <summary>
        /// 删除动作
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public int DeleteAction(Actions action)
        {
            ActionDao ad = new ActionDao();
            action.Status=(int)DataStatusEnum.Disabled;
            return ad.Update(action);
        }

        /// <summary>
        /// 启用动作
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public int EnableAction(Actions action)
        {
            ActionDao ad = new ActionDao();
            action.Status = (int)DataStatusEnum.Enabled;
            return ad.Update(action);
        }        
    }
}
