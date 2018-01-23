
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
    public interface IComments
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.Comments model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.Comments model);
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
        ADT.XingZhi.Models.APP.Comments GetModelById(int id);
        /// <summary>
        /// 查询数据
        /// </summary>
        ///  <param name="top">前几条（0全部）</param>
        ///   <param name="aid">活动id</param>
        /// <returns></returns>
         DataTable GetTable(int top,int aid);
        #endregion  成员方法
	
		
    }
  
}
