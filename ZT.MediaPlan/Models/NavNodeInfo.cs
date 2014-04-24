//==================================================================
//Create by jackal on 2014-04-23
//Last Changed by jackal on 2014-04-23
//==================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZT.MediaPlan.Models
{
    /// <summary>
    /// 导航菜单类型
    /// 目前暂时只支持2级菜单
    /// </summary>
    public class NavNodeInfo
    {
        private string n_text = string.Empty;
        private string n_actionName = string.Empty;
        private string n_src = string.Empty;
        private NavNodeInfo n_parentNode = null;
        private List<NavNodeInfo> n_childNodes = null;
        private bool n_status = true;

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Text
        {
            get { return n_text; }
            set { n_text = value; }
        }

        /// <summary>
        /// 动作名称 
        /// </summary>
        public string ActionName
        {
            get { return n_actionName; }
            set { n_actionName = value; }
        }

        /// <summary>
        /// 地址 
        /// </summary>
        public string Src
        {
            get { return n_src; }
            set { n_src = value; }
        }

        /// <summary>
        /// 父级菜单 
        /// </summary>
        public NavNodeInfo ParentNode
        {
            get { return n_parentNode; }
            set { n_parentNode = value; }
        }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<NavNodeInfo> ChildNodes
        {
            get { return n_childNodes; }
            set { n_childNodes = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public bool Status
        {
            get { return n_status; }
            set { n_status = value; }
        }

    }
}