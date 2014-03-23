using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ZT.Framework.Common
{
    public static class StringHelper
    {
        /// <summary>
        /// 获取左侧几位字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GetLeft(this string str, int Length)
        {
            if (!String.IsNullOrEmpty(str))
            {
                if (Length >= str.Length)
                    return str;
                else
                    return str.Substring(0, Length);
            }
            else
                return "";
        }
        /// <summary>
        /// 获取右侧几位字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GetRight(this string str, int Length)
        {
            if (!String.IsNullOrEmpty(str))
            {
                if (Length >= str.Length)
                    return str;
                else
                    return str.Substring(str.Length - Length);
            }
            else
                return "";
        }
        /// <summary>
        /// 转换为md5
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMD5(this string str)
        {
            using (System.Security.Cryptography.MD5CryptoServiceProvider provider = new System.Security.Cryptography.MD5CryptoServiceProvider())
            {
                return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "").ToLower();
            }
        }
        /// <summary>
        /// 转换为可空的bool类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool? ToBoolOrNull(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                if (str.ToUpper() == "TRUE" || str == "1")
                    return true;
                else if (str.ToUpper() == "FALSE" || str == "0")
                    return false;
                else
                    return null;
            }
            else
                return null;
        }
        public static string ToBit(this bool str)
        {
            if (str)
                return "1";
            else if (!str)
                return "0";
            return "0";
        }
        public static string ToBitOrEmpty(this bool? str)
        {
            if (str == null)
                return "";
            if (str == true)
                return "1";
            else if (!str == false)
                return "0";
            return "";
        }
        /// <summary>
        /// 转换为bool类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ToBool(this string str)
        {
            if (!string.IsNullOrEmpty(str) && (str.ToUpper() == "TRUE" || str == "1" || str.ToUpper() == "ON"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// 转换为正整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToNumber(this string str)
        {
            return int.Parse(str.ToNumeric());
        }
        /// <summary>
        /// 转换为纯数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToNumeric(this string str)
        {
            if (String.IsNullOrEmpty(str))
                return "0";
            else
            {
                str = Regex.Replace(str, "\\D", string.Empty);
                if (str == "")
                    return "0";
                else
                    return str;
            }
        }
        /// <summary>
        /// 转换为整数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInteger(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                str = Regex.Replace(str, "[^0-9^-]", string.Empty);
                if (str != "")
                {
                    str = str.GetLeft(1) + str.Substring(1).Replace('-', '\0');
                }
                int result;
                int.TryParse(str, out result);
                return result;
            }
            else
                return -1;
        }

        public static decimal ToDecimal(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str != "")
                {
                    str = str.GetLeft(1) + str.Substring(1).Replace('-', '\0');
                }

                decimal result;
                decimal.TryParse(str, out result);
                return result;
            }

            return -1;
        }

        /// <summary>
        /// 转换为浮点数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float ToFloat(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                str = Regex.Replace(str, "[^0-9^-^.]", string.Empty);
                if (str != "")
                    str = str.GetLeft(1) + str.Substring(1).Replace('-', '\0');

                int dotIndex = str.IndexOf('.');
                if (dotIndex == -1)
                    return float.Parse(str);
                else
                    str = str.Substring(0, dotIndex) + "." + str.Substring(dotIndex + 1).Replace('.', '\0');

                float result;
                float.TryParse(str, out result);
                return result;
            }
            else
                return -1;
        }

        /// <summary>
        /// 转换为浮点数(包括负数)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float ToFloatB(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                if (str != "")
                    str = str.GetLeft(1) + str.Substring(1).Replace('-', '\0');

                int dotIndex = str.IndexOf('.');
                if (dotIndex == -1)
                    return float.Parse(str);
                else
                    str = str.Substring(0, dotIndex) + "." + str.Substring(dotIndex + 1).Replace('.', '\0');

                float result;
                float.TryParse(str, out result);
                return result;
            }
            else
                return -1;
        }


        public static DateTime ToDateTime(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime _time;
                DateTime.TryParse(str, out _time);

                return _time;
            }
            else
                return DateTime.MinValue;
        }

        /// <summary>
        /// false  null 转换成"" 返回
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToEmptyString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            else if (str.ToLower().Equals("false"))
            {
                return "";
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 重复字符串次数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GetRepeater(this string str, int Times)
        {
            if (Times < 1)
                return "";
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < Times; i++)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }

        public static string ToHTML(this string str)
        {
            if (!String.IsNullOrEmpty(str))
                return str.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;").Replace(" ", "&nbsp;").Replace("\n", "<br />");
            else
                return "";
        }

        public static string ToMoneyFormat(this decimal dec)
        {
            string ft = dec.ToString("0.00");
            if (ft.Substring(ft.Length - 2, 2) == "00")
                return ft.Split('.')[0];
            else
                return ft;
        }

        public static string ToText(this string str)
        {
            if (!String.IsNullOrEmpty(str))
                return str.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&nbsp;", " ").Replace("<br />", "\n");
            else
                return "";
        }

        public static string ToJs(this string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                str = str.Replace("\"", "\\\"").Replace("'", "\\\'").Replace("/", "\\/").Replace("<\\/script>", "<\\/s\'+\'cript>");
                str = Regex.Replace(str, @"\s+", " ", RegexOptions.Multiline);
                str = "document.write('" + str + "');";
                return str;
            }
            else
                return "";
        }


        public static string LeftSubstring(this string str, int length, string ellipsis)
        {
            string result = "";//返回值   
            if (str.Length <= length / 2)
            {
                result = str;
            }
            else
            {
                int t = 0;
                char[] tmp = str.ToCharArray();
                for (int i = 0; i < str.Length; i++)
                {
                    int c;
                    c = (int)tmp[i];
                    if (c < 0)
                        c = c + 65536;
                    if (c > 255)
                        t = t + 2;
                    else
                        t = t + 1;
                    if (t > length)
                        break;
                    result = result + str.Substring(i, 1);
                }
                result = result + ellipsis;
            }
            return result;

        }


        /// <summary>
        /// 判断是否为数字by add  cjh
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            foreach (char c in str)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }            
    }
}
