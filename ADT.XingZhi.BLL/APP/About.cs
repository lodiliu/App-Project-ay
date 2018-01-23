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

    public class About
    {
        private readonly IAbout dal = null;
        public About()
        {
            dal = DataAccess.CreateAbout();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.About model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int ab_id)
        {
            return dal.Delete(ab_id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.About model)
        {
            return dal.Update(model);
        }

         /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(int aid, int type, int mid)
        {
            return dal.Update(aid,type,mid);
        }
        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.About GetModelById(int ab_id)
        {
            return dal.GetModelById(ab_id);
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
        ///  根据id查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int abid)
        {
            return dal.GetTable(abid);
        }

        /// <summary>
        /// 更新报名人数
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="type">0添加1减少</param>
        /// <returns></returns>
        public int UpdateNumber(int aid, int type)
        {
            return dal.UpdateNumber(aid,type);
        }
        #endregion


    }
}