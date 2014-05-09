using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using ZT.Framework.DataAccess;

namespace ZT.Framework.Data
{
    public class EntityDao<T>
        where T : Entity, new()
    {
        #region 构造区域

        /// <summary>
        /// 构造函数。
        /// </summary>
        public EntityDao()
        {
        }

        #endregion


        #region 方法区域

        /// <summary>
        /// 插入指定的实体。
        /// </summary>
        /// <param name="obj">要插入的实体。</param>
        /// <returns>受影响行数。</returns>
        /// <exception cref="ArgumentNullException">如果obj为空引用，则抛出该异常。</exception>
        public virtual int Insert(T obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            DbCommand cmd = obj.GetInsertCommand(DataAccess.DataAccess.Db);

            return DataAccess.DataAccess.Db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 插入指定的一组实体（在同一个事务中）。
        /// </summary>
        /// <param name="objList">要插入的一组实体。</param>
        /// <exception cref="ArgumentNullException">如果objList为空引用，则抛出该异常。</exception>
        public virtual void Insert(IEnumerable<T> objList)
        {
            if (objList == null) throw new ArgumentNullException("objList");

            foreach (T obj in objList)
            {
                DbCommand cmd = obj.GetInsertCommand(DataAccess.DataAccess.Db);
                DataAccess.DataAccess.Db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// 删除指定条件的实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual int Delete(T obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            DbCommand cmd = obj.GetDeleteCommand(DataAccess.DataAccess.Db);

            return DataAccess.DataAccess.Db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 更新指定的实体。
        /// </summary>
        /// <param name="obj">要更新的对象。</param>
        /// <returns>受影响行数。</returns>
        /// <exception cref="ArgumentNullException">如果obj为空引用，则抛出该异常。</exception>
        public virtual int Update(T obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            DbCommand cmd = obj.GetUpdateCommand(DataAccess.DataAccess.Db);

            return DataAccess.DataAccess.Db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// 查询指定实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual List<T> Select(T obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");

            DbCommand cmd = obj.GetSelectCommand(DataAccess.DataAccess.Db);

            List<T> list = new List<T>();
            System.Data.DataTable dt = DataAccess.DataAccess.Db.ExecuteDataSet(cmd).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    T tObj = new T();
                    tObj.GetData(row);
                    list.Add(tObj);
                }
                dt.Clear();
            }

            return list;
        }

        /// <summary>
        /// 查询指定条件的实体。
        /// </summary>
        /// <param name="where">查询条件（不含WHERE关键字，如果为空则返回所有对象）。</param>
        /// <returns>查询到的对象的集合。</returns>
        public EntityCollection<T> Select(string where)
        {
            return Select(where, string.Empty);
        }

        /// <summary>
        /// 查询指定条件的实体。
        /// </summary>
        /// <param name="where">查询条件（不含WHERE关键字，如果为空则返回所有对象）。</param>
        /// <param name="sort">排序条件（不含ORDER BY关键字，如果为空则不排序）。</param>
        /// <returns>查询到的实体的集合。</returns>
        public EntityCollection<T> Select(string where, string sort)
        {
            return SelectPage(where, sort, null);
        }

        /// <summary>
        /// 查询指定条件的实体。
        /// </summary>
        /// <param name="where">查询条件（不含WHERE关键字，如果为空则返回所有对象）。</param>
        /// <param name="sort">排序条件（不含ORDER BY关键字，如果为空则不排序）。</param>
        /// <param name="paging">分页方案（如果为空引用，则不分页）。</param>
        /// <returns>查询到的实体的集合。</returns>
        public virtual EntityCollection<T> SelectPage(string where, string sort, DataAccessPaging paging)
        {
            DataAccess dataAccess = new DataAccess(Provider, ConnectionString);
            DataAccessCommand cmd = new T().GetSelectCommand(dataAccess);
            if (!string.IsNullOrEmpty(where)) cmd.Sql += Environment.NewLine + " WHERE " + where;
            if (!string.IsNullOrEmpty(sort)) cmd.Sql += Environment.NewLine + " ORDER BY " + sort;

            EntityCollection<T> list = new EntityCollection<T>();
            using (System.Data.DataTable dt = dataAccess.ExecuteDataTable(cmd, paging))
            {
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    T obj = new T();
                    obj.GetData(row);
                    list.Add(obj);
                }
                dt.Clear();
            }

            return list;
        }

        /// <summary>
        /// 查询指定条件的第一个实体。
        /// </summary>
        /// <param name="where">查询条件（不含WHERE关键字）。</param>
        /// <returns>查询到的实体的集合。</returns>
        public T SelectFirst(string where)
        {
            return SelectFirst(where, string.Empty);
        }

        /// <summary>
        /// 查询指定条件的第一个实体。
        /// </summary>
        /// <param name="where">查询条件（不含WHERE关键字）。</param>
        /// <param name="sort">排序条件（不含ORDER BY关键字，如果为空则不排序）。</param>
        /// <returns>查询到的实体的集合。</returns>
        public virtual T SelectFirst(string where, string sort)
        {
            DataAccess dataAccess = new DataAccess(Provider, ConnectionString);
            DataAccessCommand cmd = new T().GetSelectCommand(dataAccess);
            if (!string.IsNullOrEmpty(where)) cmd.Sql += Environment.NewLine + " WHERE " + where;
            if (!string.IsNullOrEmpty(sort)) cmd.Sql += Environment.NewLine + " ORDER BY " + sort;

            cmd.ReturnCount = 1;

            T obj = null;
            using (System.Data.DataTable dt = dataAccess.ExecuteDataTable(cmd))
            {
                if (dt.Rows.Count > 0)
                {
                    obj = new T();
                    obj.GetData(dt.Rows[0]);
                }
                dt.Clear();
            }

            return obj;
        }

        #endregion
    }
}
