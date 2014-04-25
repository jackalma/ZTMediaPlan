//==================================================================
//Create by jackal on 2014-04-24
//Last Changed by jackal on 2014-04-24
//==================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Xml;

namespace ZT.MediaPlan.Common
{
    /// <summary>
    /// 读取App_Data/xml下面XML配置文件
    /// 如果缓存中存在直接从缓存中读取，否则重新读取XML并设置缓存
    /// </summary>
    public sealed class GetXmlDocument
    {
        /// <summary>
        /// 获取导航菜单配置文件
        /// </summary>
        /// <returns></returns>
        public static XmlDocument DocNavigation()
        {
            XmlDocument doc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;

            if (Common.CacheHelper.IsCacheExist(Common.Constants.CACHE_NAVIGATION))
            {
                doc = (XmlDocument)Common.CacheHelper.GetCache(Common.Constants.CACHE_NAVIGATION);
            }
            else
            {
                var absolutePath = GetAppDataXML("HeadNavigation.xml");

                if (System.IO.File.Exists(absolutePath))
                {
                    XmlReader reader = XmlReader.Create(absolutePath, settings);

                    doc.Load(reader);

                    Common.CacheHelper.SetCache(Common.Constants.CACHE_NAVIGATION, doc, new string[] { absolutePath });
                }
            }

            return doc;
        }

        /// <summary>
        /// 获取XML物理路径
        /// </summary>
        /// <param name="xmlName"></param>
        /// <returns></returns>
        private static string GetAppDataXML(string xmlName)
        {
            StringBuilder sb = new StringBuilder();
            string path = sb.AppendFormat("~/App_Data/xml/{0}", xmlName).ToString();

            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(path);
            }
            else
            {
                path = path.Replace("~", "").TrimEnd('/').Replace("/", "\\");
                path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, path);
            }
            return path;
        }
    }
}