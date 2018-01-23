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

    public class Member
    {
        private readonly IMember dal = null;
        public Member()
        {
            dal = DataAccess.CreateMember();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Member model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int m_id)
        {
            return dal.Delete(m_id);
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Member model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Member GetModelById(int m_id)
        {
            return dal.GetModelById(m_id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int m_id)
        {
            return dal.GetTable(m_id);
        }

        /// <summary>
        /// 根据帐号得到一个实体
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Member GetModelByAccount(string account)
        {
            return dal.GetModelByAccount(account);
        }

          /// <summary>
        /// 第三方得到一个实体
        /// </summary>
        /// <param name="phon"></param>
        /// <returns></returns>
        public Models.APP.Member GetModelByLoginOpen(string openid, int opentype)
        {
            return dal.GetModelByLoginOpen(openid, opentype);
        }

        /// <summary>
        /// 根据用户名查询不是我的好友
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(string username,int mid)
        {
            return dal.GetTable(username, mid);
        }
        #endregion


    }
}