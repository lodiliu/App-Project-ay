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

    public class Activaty
    {
        private readonly IActivaty dal = null;
        public Activaty()
        {
            dal = DataAccess.CreateActivaty();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Activaty model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int a_id)
        {
            return dal.Delete(a_id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Activaty model)
        {
            return dal.Update(model);
        }
          /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(int aid, int state, string mid)
        {
            return dal.Update(aid, state,mid);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(int aid, string gid)
        {
            return dal.Update(aid,gid);
        }
        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Activaty GetModelById(int a_id)
        {
            return dal.GetModelById(a_id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int twoid, int oneid, int mtepyid, int most, int lately)
        {
            return dal.GetTable(twoid, oneid,  mtepyid,  most,  lately);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int id)
        {
            return dal.GetTable(id);
        }

          /// <summary>
        /// 更新点赞
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public int UpdatePraise(int aid,int pnum)
        {
            return dal.UpdatePraise(aid,pnum);
        }

         /// <summary>
        /// 更新报名人数
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="type">0添加1减少</param>
        /// <returns></returns>
        public int UpdateNumber(int aid,int type)
        {
            return dal.UpdateNumber(aid,type);
        }
        #endregion


    }
}