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

    public class Feedback
    {
        private readonly IFeedback dal = null;
        public Feedback()
        {
            dal = DataAccess.CreateFeedback();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Feedback model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int fb_id)
        {
            return dal.Delete(fb_id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Feedback model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Feedback GetModelById(int fb_id)
        {
            return dal.GetModelById(fb_id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
            return dal.GetTable();
        }

        #endregion


    }
}