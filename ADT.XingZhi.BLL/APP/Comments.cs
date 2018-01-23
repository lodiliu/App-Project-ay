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

    public class Comments
    {
        private readonly IComments dal = null;
        public Comments()
        {
            dal = DataAccess.CreateComments();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Comments model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int c_id)
        {
            return dal.Delete(c_id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Comments model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Comments GetModelById(int c_id)
        {
            return dal.GetModelById(c_id);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        ///  <param name="top">前几条（0全部）</param>
        ///   <param name="aid">活动id</param>
        /// <returns></returns>
        public DataTable GetTable(int top, int aid)
        {
            return dal.GetTable(top,aid);
        }

        #endregion


    }
}