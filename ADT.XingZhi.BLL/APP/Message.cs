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

    public class Message
    {
        private readonly IMessage dal = null;
        public Message()
        {
            dal = DataAccess.CreateMessage();
        }

        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Message model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除一个实体(0系统消息1好友邀请2二维码)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int aid, int mid, int type)
        {
            return dal.Delete(aid, mid, type);
        }
        /// <summary>
        /// 删除一个实体(3添加好友信息)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int userid, int mid)
        {
            return dal.Delete(userid, mid);
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int meid)
        {
            return dal.Delete(meid);
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int DeleteMessage(int aid)
        {
            return dal.DeleteMessage(aid);
        }
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Message model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 修改状态(0系统消息1好友邀请2二维码)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(int aid, int m_id, int type)
        {
            return dal.Update(aid, m_id, type);
        }

        /// <summary>
        /// 修改状态(3同意好友)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(int userid, int mid)
        {
            return dal.Update(userid, mid);
        }
        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Message GetModelById(int me_id)
        {
            return dal.GetModelById(me_id);
        }

        /// <summary>
        /// 获得一个添加好友信息实体
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Message GetModel(string m_id, string fid)
        {
            return dal.GetModel(m_id, fid);
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
        /// <param name="top">前几条数据，0全部</param>
        /// <param name="a_id">活动id</param>
        /// <param name="type">类型类型（0、系统消息1、活动邀请2、二维码3、添加好友消息4、活动公告的）</param>
        /// <param name="isread">-1全部0未读1已读</param>
        /// <returns></returns>
        public DataTable GetTable(int top, int a_id, int type)
        {
            return dal.GetTable(top, a_id, type);
        }
        /// <summary>
        /// 查询未读数据
        /// </summary>
        /// <param name="mid">用户id</param>
        /// <param name="a_id">活动id</param>
        /// <param name="type">类型类型（0、系统消息1、活动邀请2、二维码3、添加好友消息4、活动公告的）</param>
        /// <param name="isread">-1全部0未读1已读</param>
        /// <returns></returns>
        public DataTable GetTable(int mid, int a_id, int type, int isread)
        {
            return dal.GetTable(mid, a_id, type, isread);
        }
        #endregion


    }
}