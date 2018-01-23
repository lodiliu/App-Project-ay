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
    
	public class District
    {
          private readonly IDistrict dal = null;
        public District()
        {
            dal = DataAccess.CreateDistrict();
        }
      
		#region  Method 
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.District model)
        { 
            return dal.Add(model);
        }        
        
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int  Id)
		{
           return dal.Delete(Id);
        }
        
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.District model)
        {  
             return dal.Update(model);
        }

		 /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.District GetModelById(int Id)
        {
           return dal.GetModelById(Id);
        }
       /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.District GetModelByName(string name)
        {
            return dal.GetModelByName(name);
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int cid)
        { 
            return dal.GetTable(cid);
        }

		#endregion

		
    }
}