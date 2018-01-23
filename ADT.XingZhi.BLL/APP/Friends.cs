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

    public class Friends
    {
        private readonly IFriends dal = null;
        public Friends()
        {
            dal = DataAccess.CreateFriends();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Friends model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int m_id, int fid)
        {
            return dal.Delete(m_id,fid);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Friends model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Friends GetModelById(int fid,int mid)
        {
            return dal.GetModelById(fid,mid);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int mid)
        {
            return dal.GetTable(mid);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int mid,string gid)
        {
            return dal.GetTable(mid,gid);
        }

        #endregion


    }
}