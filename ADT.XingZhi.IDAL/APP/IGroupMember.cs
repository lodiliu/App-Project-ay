
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
    public interface IGroupMember
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.GroupMember model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.GroupMember model);
      	/// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(string m_id, string gid);
        /// <summary>
        /// 删除一组记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Delete(string gid);
        /// <summary>
        /// 得到一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ADT.XingZhi.Models.APP.GroupMember GetModelById(string gid, string mid);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        DataTable GetTable(int top, string gid);
        #endregion  成员方法
	
		
    }
  
}
