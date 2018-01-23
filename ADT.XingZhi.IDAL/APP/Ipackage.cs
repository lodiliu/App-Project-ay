
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
    public interface Ipackage
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.package model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.package model);
          /// <summary>
        /// 更新报名人数
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="type">0添加1减少</param>
        /// <returns></returns>
        int UpdateNumber(int pkid, int type);
      	/// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(int id);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int DeleteByaid(int id);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ADT.XingZhi.Models.APP.package GetModelById(int id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        DataTable GetTable(DateTime dtime);

         /// <summary>
         /// 查询培训套餐
         /// </summary>
         /// <returns></returns>
         DataTable GetTable(int a_id);
        #endregion  成员方法
	
		
    }
  
}
