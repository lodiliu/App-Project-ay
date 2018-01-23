
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
    public interface IAbout
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.About model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.About model);
         /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        int Update(int aid, int type, int mid);
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
        ADT.XingZhi.Models.APP.About GetModelById(int id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
         DataTable GetTable();

         /// <summary>
         /// 根据id查询数据
         /// </summary>
         /// <returns></returns>
         DataTable GetTable(int abid);

         /// <summary>
         /// 更新报名人数
         /// </summary>
         /// <param name="test"></param>
         /// <returns></returns>
         int UpdateNumber(int aid, int type);
        #endregion  成员方法
	
		
    }
  
}
