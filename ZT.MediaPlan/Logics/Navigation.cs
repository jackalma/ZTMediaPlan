//==================================================================
//Create by jackal on 2014-04-25
//Last Changed by jackal on 2014-04-25
//==================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZT.MediaPlan.Models;
using System.Xml;
using ZT.Framework.Common;

namespace ZT.MediaPlan.Logics
{
    /// <summary>
    /// 导航菜单逻辑
    /// </summary>
    public class Navigation
    {

        /// <summary>
        /// 获取用户权限内的菜单
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static IList<NavNodeInfo> GetUserNavNodes(int UserId)
        {
            IList<NavNodeInfo> listNodes = GetAllNavNodes();

            //去掉用户没有权限的菜单


            return listNodes;
        }

        /// <summary>
        /// 获取所有可用的菜单
        /// </summary>
        /// <returns></returns>
        public static IList<NavNodeInfo> GetAllNavNodes()
        {
            IList<NavNodeInfo> listNodes = new List<NavNodeInfo>();
            
            XmlDocument doc = Common.XmlHelper.DocNavigation();

            XmlNodeList nodes = doc.SelectSingleNode("Navigation").ChildNodes;

            foreach (XmlNode n in nodes)
            {
                if (n.Attributes["Status"] == null || !n.Attributes["Status"].Value.ToBool()) continue;
                
                //父菜单
                NavNodeInfo nav = new NavNodeInfo();
                nav.Text = n.Attributes["Text"].Value;
                nav.Src = n.Attributes["Src"].Value;
                nav.ActionName = n.Attributes["ActionName"].Value;
                nav.TabId = n.Attributes["TabId"].Value;

                //子菜单
                IList<NavNodeInfo> cListNodes = new List<NavNodeInfo>();
                foreach (XmlNode c in n.ChildNodes)
                {
                    if (c.NodeType == XmlNodeType.Comment) continue;
                    if (c.Attributes["Status"] == null || !c.Attributes["Status"].Value.ToBool()) continue;

                    NavNodeInfo cNav = new NavNodeInfo();
                    cNav.Text = c.Attributes["Text"].Value;
                    cNav.Src = c.Attributes["Src"].Value;
                    cNav.ActionName = c.Attributes["ActionName"].Value;
                    cNav.TabId = c.Attributes["TabId"].Value;
                    cNav.ParentNode = nav;
                    cListNodes.Add(cNav);
                }
                nav.ChildNodes = cListNodes;
                listNodes.Add(nav);
            }
            return listNodes;
        }
    }
}