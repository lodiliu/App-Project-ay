
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
namespace ADT.XingZhi.IDAL.APP
{
	/// <summary>
    /// 业务处理层接口
    /// </summary>
    public interface IMessage
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.Message model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.Message model);

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int  Update(int aid, int m_id,int type);
           /// <summary>
        /// 修改状态(3同意好友)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
         int Update(int userid, int mid);
      	/// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(int aid, int mid, int type);
           /// <summary>
        /// 删除一个实体(3添加好友信息)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        int Delete(int userid, int mid);
        int DeleteMessage(int aid);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(int meid);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ADT.XingZhi.Models.APP.Message GetModelById(int id);

          /// <summary>
        /// 获得一个添加好友信息实体
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
         Models.APP.Message GetModel(string m_id, string fid);

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
         DataTable GetTable(int mid);


         /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
         DataTable GetTable(int top, int a_id, int type);

            /// <summary>
        /// 查询未读数据
        /// </summary>
        /// <param name="mid">用户id</param>
        /// <param name="a_id">活动id</param>
        /// <param name="type">类型类型（0、系统消息1、活动邀请2、二维码3、添加好友消息4、活动公告的）</param>
        /// <param name="isread">-1全部0未读1已读</param>
        /// <returns></returns>
         DataTable GetTable(int mid, int a_id, int type, int isread);
        #endregion  成员方法
	
		
    }
  
}
