using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZT.Framework.Common
{
    public sealed class SystemDataProvider
    {
        /// <summary>
        /// 获取标准Json字符串。
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string GetStandardJson(string json)
        {
            if (string.IsNullOrEmpty(json)) return string.Empty;

            //对日期值进行修正，否则无法反序列化
            return json.Replace(" 0800)", "+0800)");
        }
    }
}
