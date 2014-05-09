using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ZT.Framework.Data
{
    /// <summary>
    /// 实体抽象类
    /// </summary>
    [Serializable]
    public abstract class Entity
    {
        #region 方法

        /// <summary>
        /// 获取唯一键。
        /// </summary>
        /// <returns></returns>
        public abstract string GetKey();

        /// <summary>
        /// 获取插入命令。
        /// </summary>
        /// <param name="dataAccess">数据访问对象。</param>
        /// <returns>数据访问命令。</returns>
        public abstract DbCommand GetInsertCommand(Database db);

        /// <summary>
        /// 获取删除命令。
        /// </summary>
        /// <param name="dataAccess">数据访问对象。</param>
        /// <returns>数据访问命令。</returns>
        public abstract DbCommand GetDeleteCommand(Database db);

        /// <summary>
        /// 获取更新命令。
        /// </summary>
        /// <param name="dataAccess">数据访问对象。</param>
        /// <returns>数据访问命令。</returns>
        public abstract DbCommand GetUpdateCommand(Database db);

        /// <summary>
        /// 获取查询命令。
        /// </summary>
        /// <param name="dataAccess">数据访问对象。</param>
        /// <returns>数据访问命令。</returns>
        public abstract DbCommand GetSelectCommand(Database db);

        /// <summary>
        /// 从DataRow获取数据。
        /// </summary>
        /// <param name="row">DataRow。</param>
        public abstract void GetData(System.Data.DataRow row);
        #endregion
    }
}
