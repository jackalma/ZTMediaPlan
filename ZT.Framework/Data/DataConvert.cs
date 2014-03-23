using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ZT.Framework.Data
{
    public class DataConvert
    {
        /// <summary>
        /// 将指定对象转换为String类型。
        /// </summary>
        /// <param name="value">要转换的对象。</param>
        /// <returns>转换后的值。</returns>
        public static string GetStringValue(object value)
        {
            if (value == null || value == DBNull.Value) return string.Empty;
            if (string.IsNullOrEmpty(value.ToString())) return string.Empty;
            return value.ToString();
        }

        /// <summary>
        /// 将指定对象转换为DateTime类型。
        /// </summary>
        /// <param name="value">要转换的对象。</param>
        /// <returns>转换后的值。</returns>
        public static DateTime GetDateTimeValue(object value)
        {
            if (value == null || value == DBNull.Value) return DateTime.MinValue;
            if (string.IsNullOrEmpty(value.ToString())) return DateTime.MinValue;
            return Convert.ToDateTime(value, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 将指定对象转换为Int32类型。
        /// </summary>
        /// <param name="value">要转换的对象。</param>
        /// <returns>转换后的值。</returns>
        public static int GetInt32Value(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;
            return Convert.ToInt32(value, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 将指定对象转换为Int64类型。
        /// </summary>
        /// <param name="value">要转换的对象。</param>
        /// <returns>转换后的值。</returns>
        public static long GetInt64Value(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;
            return Convert.ToInt64(value, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 将指定对象转换为Single类型。
        /// </summary>
        /// <param name="value">要转换的对象。</param>
        /// <returns>转换后的值。</returns>
        public static float GetSingleValue(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;
            return Convert.ToSingle(value, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 将指定对象转换为Decimal类型。
        /// </summary>
        /// <param name="value">要转换的对象。</param>
        /// <returns>转换后的值。</returns>
        public static decimal GetDecimalValue(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;
            return Convert.ToDecimal(value, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 将指定对象转换为Byte[]类型。
        /// </summary>
        /// <param name="value">要转换的对象。</param>
        /// <returns>转换后的值。</returns>
        public static byte[] GetBytesValue(object value)
        {
            if (value == null || value == DBNull.Value) return new byte[] { };
            byte[] bytes = value as byte[];
            if (bytes == null) bytes = new byte[] { };
            return bytes;
        }

        /// <summary>
        /// 将指定String值转换为数据库值。
        /// </summary>
        /// <param name="obj">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static object GetStringDbValue(string obj)
        {
            if (string.IsNullOrEmpty(obj)) return DBNull.Value;
            return obj;
        }

        /// <summary>
        /// 将指定DateTime值转换为数据库值。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static object GetDateTimeDbValue(DateTime value)
        {
            if (value == DateTime.MinValue) return DBNull.Value;
            return value;
        }

        /// <summary>
        /// 将指定Int32值转换为数据库值。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static object GetInt32DbValue(int value)
        {
            return value;
        }

        /// <summary>
        /// 将指定Int64值转换为数据库值。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static object GetInt64DbValue(long value)
        {
            return value;
        }

        /// <summary>
        /// 将指定Single值转换为数据库值。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static object GetSingleDbValue(float value)
        {
            return value;
        }

        /// <summary>
        /// 将指定Decimal值转换为数据库值。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static object GetDecimalDbValue(decimal value)
        {
            return value;
        }

        /// <summary>
        /// 将指定Byte[]值转换为数据库值。
        /// </summary>
        /// <param name="obj">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static object GetBytesDbValue(byte[] obj)
        {
            if (obj == null) return new byte[] { };
            return obj;
        }

        /// <summary>
        /// 将指定Int64值转换为数据库值。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns>转换后的值。</returns>
        public static object GetUInt64DbValue(UInt64 value)
        {
            return value;
        }

        /// <summary>
        /// 将指定对象转换为Int64类型。
        /// </summary>
        /// <param name="value">要转换的对象。</param>
        /// <returns>转换后的值。</returns>
        public static UInt64 GetUInt64Value(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            if (string.IsNullOrEmpty(value.ToString())) return 0;
            return Convert.ToUInt64(value, CultureInfo.CurrentCulture);
        }
    }
}
