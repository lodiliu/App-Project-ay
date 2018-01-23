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

    public class Application
    {
        private readonly IApplication dal = null;
        public Application()
        {
            dal = DataAccess.CreateApplication();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Application model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int ap_id)
        {
            return dal.Delete(ap_id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Application model)
        {
            return dal.Update(model);
        }
         /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="apid">id</param>
        ///  <param name="state">状态</param>
        ///   <param name="mtime">修改时间</param>
        ///    <param name="muserid">修改人id</param>
        /// <returns></returns>
        public int Update(int apid, int state, string muserid)
        {
            return dal.Update(apid, state,  muserid);
        }
        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Application GetModelById(int ap_id)
        {
            return dal.GetModelById(ap_id);
        }
         /// <summary>
        /// 根据活动id查询数据
        /// </summary>
        /// <param name="top">前几条</param>
        /// <param name="aid">活动id</param>
        /// <param name="type">类型（0、活动2、约吧）</param>
        /// <returns></returns>
        public DataTable GetTableTOP(int top, int aid, int type)
        {
            return dal.GetTableTOP(top, aid, type);
        }

          /// <summary>
        /// 根据活动id，报名id查询数据
        /// </summary>
        /// <param name="mid">报名id</param>
        /// <param name="aid">活动id</param>
        /// <param name="type">类型（0、活动2、约吧）</param>
        /// <returns></returns>
        public DataTable GetTable(int mid, int aid, int type)
        {
            return dal.GetTable(mid, aid, type);
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
        /// 根据报名id查询数据
        /// </summary>
        /// <param name="mid">报名id</param>
        /// <param name="aid">0参加1取消2全部</param>
        /// <param name="type">类型（0、活动2、约吧）</param>
        /// <returns></returns>
        public DataTable GetTableCancel(int mid, int id, int type, int page, int row, out int recordCount)
        {
            return dal.GetTableCancel(mid, id, type,  page,  row,out recordCount);
        }

        #endregion


    }
}