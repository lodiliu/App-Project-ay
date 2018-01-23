using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using ADT.XingZhi.DALFactory.APP;
using ADT.XingZhi.IDAL.APP;
using ADT.CMS.Utility;

namespace ADT.XingZhi.BLL.APP
{

    public class Type
    {
        private readonly IType dal = null;
        public Type()
        {
            dal = DataAccess.CreateType();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Type model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int t_id)
        {
            return dal.Delete(t_id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Type model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 设置禁用
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="disabled">true-已禁用，false-未禁用</param>
        /// <returns></returns>
        public int SetDisabled(int id, bool disabled)
        {
            return dal.SetDisabled(id, disabled);
        }
        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Type GetModelById(int t_id)
        {
            return dal.GetModelById(t_id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            return dal.GetTable();
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="top">前几条记录0为全部</param>
        /// <param name="typeid">类型id</param>
        /// <returns></returns>
        public DataTable GetTable(int top, int typeid)
        {
            return dal.GetTable(top, typeid);
        }

         /// <summary>
        /// 根据id组查询数据
        /// </summary>
        /// <param name="mid">查询id</param>
        /// <returns></returns>
        public DataTable GetTableIn(string mid)
        {
            return dal.GetTableIn(mid);
        }

          /// <summary>
        /// 根据id组查询所有id组以外数据
        /// </summary>
        /// <param name="tpid">查询id</param>
        /// <returns></returns>
        public DataTable GetTableNotIn(string tpid, int typeid)
        {
            return dal.GetTableNotIn(tpid,typeid);
        }

        /// <summary>
        /// 更新排序值
        /// </summary>
        /// <returns></returns>
        public void UpdateOrderId(DataTable dt)
        {
            dal.UpdateOrderId(dt);
        }
        #endregion


    }
}