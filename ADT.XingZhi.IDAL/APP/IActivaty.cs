
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
    public interface IActivaty
    {
        
         #region  成员方法
         /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Add(ADT.XingZhi.Models.APP.Activaty model);        
          /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        int Update(ADT.XingZhi.Models.APP.Activaty model);
            /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        int Update(int aid, int state, string mid);

        int Update(int aid,  string gid);
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
        ADT.XingZhi.Models.APP.Activaty GetModelById(int id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        DataTable GetTable(int twoid, int oneid, int mtepyid, int most, int lately);

         /// <summary>
         /// 查询所有数据
         /// </summary>
         /// <returns></returns>
         DataTable GetTable(int id);

         /// <summary>
         /// 更新点赞
         /// </summary>
         /// <param name="test"></param>
         /// <returns></returns>
         int UpdatePraise(int aid,int pnum);

         /// <summary>
         /// 更新报名人数
         /// </summary>
         /// <param name="test"></param>
         /// <returns></returns>
         int UpdateNumber(int aid,int type);
        #endregion  成员方法
	
		
    }
  
}
