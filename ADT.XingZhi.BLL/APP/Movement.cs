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

    public class Movement
    {
        private readonly IMovement dal = null;
        public Movement()
        {
            dal = DataAccess.CreateMovement();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Movement model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int m_id, int tp_id)
        {
            return dal.Delete(m_id,tp_id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Movement model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Movement GetModelById(int mo_id)
        {
            return dal.GetModelById(mo_id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <param name="mid">用户id</param>
        /// <returns></returns>
        public DataTable GetTable(int mid)
        {
            return dal.GetTable(mid);
        }
        /// <summary>
        /// 更新排序值
        /// </summary>
        /// <returns></returns>
        public void UpdateOrderId(DataTable dt,int mid)
        {
            dal.UpdateOrderId(dt,mid);
        }
        #endregion


    }
}