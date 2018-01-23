using System;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using ADT.XingZhi.DALFactory.APP;
using ADT.XingZhi.IDAL.APP;
using ADT.CMS.Utility;

namespace ADT.XingZhi.BLL.APP
{
    
	public class Evaluate
    {
          private readonly IEvaluate dal = null;
        public Evaluate()
        {
            dal = DataAccess.CreateEvaluate();
        }
      
		#region  Method 
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Evaluate model)
        { 
            return dal.Add(model);
        }        
        
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int  ev_id)
		{
           return dal.Delete(ev_id);
        }
        
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Evaluate model)
        {  
             return dal.Update(model);
        }

		 /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Evaluate GetModelById(int ev_id)
        {
           return dal.GetModelById(ev_id);
        }
     
        /// <summary>
        /// 查询数据
        /// </summary>
        ///  <param name="top">前几条（0全部）</param>
        ///   <param name="mid">被评论人id</param>
        /// <returns></returns>
        public DataTable GetTable(int top, int mid)
        {
            return dal.GetTable(top,mid);
        }

           /// <summary>
        /// 查询平均值
        /// </summary>
        /// <returns></returns>
        public int GetAvg(int mid)
        {
            return dal.GetAvg(mid);
        }

		#endregion

		
    }
}