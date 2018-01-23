
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
    public interface IType
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.Type model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.Type model);

        int SetDisabled(int id, bool disabled);
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
        ADT.XingZhi.Models.APP.Type GetModelById(int id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
         DataTable GetTable();

         /// <summary>
         /// 查询所有数据
         /// </summary>
         /// <param name="top">前几条记录0为全部</param>
         /// <param name="typeid">类型id</param>
         /// <returns></returns>
         DataTable GetTable(int top,int typeid);

         /// <summary>
         /// 根据id组查询数据
         /// </summary>
         /// <param name="tpid">查询id</param>
         /// <returns></returns>
         DataTable GetTableIn(string tpid);

         /// <summary>
         /// 根据id组查询所有id组以外数据
         /// </summary>
         /// <param name="tpid">查询id</param>
         /// <returns></returns>
         DataTable GetTableNotIn(string tpid, int typeid);

         void UpdateOrderId(DataTable dt);
        #endregion  成员方法
	
		
    }
  
}
