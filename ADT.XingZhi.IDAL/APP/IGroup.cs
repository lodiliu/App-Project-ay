
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
    public interface IGroup
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.Group model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.Group model);
           /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        int Update(string gid, string name);
      	/// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(string id,string mid);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ADT.XingZhi.Models.APP.Group GetModelById(string id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
         DataTable GetTable(int mid);
        #endregion  成员方法
	
		
    }
  
}
