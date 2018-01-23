using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using ADT.XingZhi.DALFactory.APP;
using ADT.XingZhi.IDAL.APP;

namespace ADT.XingZhi.BLL.APP
{

    public class Applicationitem
    {
        private readonly IApplicationitem dal = null;
        public Applicationitem()
        {
            dal = DataAccess.CreateApplicationitem();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Applicationitem model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int api_id)
        {
            return dal.Delete(api_id);
        }
          /// <summary>
        /// 删除
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int DeleteByAid(int aid, string mid, int type)
        {
            return dal.DeleteByAid(aid, mid, type);
        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Applicationitem model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Applicationitem GetModelById(int api_id)
        {
            return dal.GetModelById(api_id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int aid, int mid,int pid)
        {
            return dal. GetTable(aid,mid,pid);
        }

         /// <summary>
        /// 查询活动添加的字段
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int a_id)
        {
            return dal.GetTable(a_id);
        }

        #endregion


    }
}