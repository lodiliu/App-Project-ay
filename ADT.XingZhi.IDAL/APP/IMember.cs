
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
    public interface IMember
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.Member model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.Member model);
      	/// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(int id);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ADT.XingZhi.Models.APP.Member GetModelById(int id);


         /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ADT.XingZhi.Models.APP.Member GetModelByLoginOpen(string openid, int opentype);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        DataTable GetTable(int m_id);

         /// <summary>
         /// 根据手机号得到一个实体
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
        ADT.XingZhi.Models.APP.Member GetModelByAccount(string account);

         /// <summary>
         /// 查询所有数据
         /// </summary>
         /// <returns></returns>
         DataTable GetTable(string username,int mid);
        #endregion  成员方法
	
		
    }
  
}
