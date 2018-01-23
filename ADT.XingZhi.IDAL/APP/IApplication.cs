
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
    public interface IApplication
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.Application model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.Application model);

         /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="apid">id</param>
        ///  <param name="state">状态</param>
        ///   <param name="mtime">修改时间</param>
        ///    <param name="muserid">修改人id</param>
        /// <returns></returns>
        int Update(int apid, int state,string muserid);
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
        ADT.XingZhi.Models.APP.Application GetModelById(int id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
         DataTable GetTable();

         /// <summary>
         /// 根据活动id查询数据
         /// </summary>
         /// <param name="top">前几条</param>
         /// <param name="aid">活动id</param>
         /// <param name="type">类型（0、活动2、约吧）</param>
         /// <returns></returns>
         DataTable GetTableTOP(int top, int aid, int type);

         /// <summary>
         /// 根据活动id，报名id查询数据
         /// </summary>
         /// <param name="mid">报名id</param>
         /// <param name="aid">活动id</param>
         /// <param name="type">类型（0、活动2、约吧）</param>
         /// <returns></returns>
         DataTable GetTable(int mid, int aid, int type);

         /// <summary>
         /// 根据报名id查询数据
         /// </summary>
         /// <param name="mid">报名id</param>
         /// <param name="aid">0参加1取消</param>
         /// <param name="type">类型（0、活动2、约吧）</param>
         /// <returns></returns>
         DataTable GetTableCancel(int mid, int id, int type, int page, int row, out  int recordCount);
        #endregion  成员方法
	
		
    }
  
}
