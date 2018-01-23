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

    public class GroupMember
    {
        private readonly IGroupMember dal = null;
        public GroupMember()
        {
            dal = DataAccess.CreateGroupMember();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.GroupMember model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(string m_id, string gid)
        {
            return dal.Delete(m_id,gid);
        }

        /// <summary>
        /// 删除一组实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(string gid)
        {
            return dal.Delete( gid);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.GroupMember model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.GroupMember GetModelById(string gid, string mid)
        {
            return dal.GetModelById( gid, mid);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int top, string gid)
        {
            return dal.GetTable( top, gid);
        }

        #endregion


    }
}