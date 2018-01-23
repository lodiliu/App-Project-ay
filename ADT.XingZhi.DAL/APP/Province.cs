using System;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using ADT.XingZhi.IDAL.APP;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADT.XingZhi.DAL.APP
{
    
	public class Province : IProvince
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Province (){ }
		#region  Method 
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Province model)
        { 
             try
            {
                 SqlParameter[] para = 
			         {
				new SqlParameter("@ProName",model.ProName),
				new SqlParameter("@ProSort",model.ProSort),
				new SqlParameter("@ProRemark",model.ProRemark)
                     };
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(@"INSERT INTO App_Province(
			           				ProName
						 	        ,ProSort
						 	        ,ProRemark
						  ) VALUES(
									@ProName
									,@ProSort
									,@ProRemark
					)");

            return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString(), para);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Add()发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Add()发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Add()发生Exception", ex);
            }
            return -1;
        }
        

       
        
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int  ProID)
		{
           try
            {
			SqlParameter[] para = 
			      {new SqlParameter("@ProID",ProID)
			       };
            StringBuilder cmdText = new StringBuilder();
			cmdText.Append(@"DELETE FROM [App_Province]
     							   WHERE ProID=@ProID");
            return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString(), para);
		     }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Delete()发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Delete()发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Delete()发生Exception", ex);
            }
            return -1;
        }
        
        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Province model)
        {  
            try
            {
			 SqlParameter[] para = 
			          {
				new SqlParameter("@ProID",model.ProID),
				new SqlParameter("@ProName",model.ProName),
				new SqlParameter("@ProSort",model.ProSort),
				new SqlParameter("@ProRemark",model.ProRemark)
                      };
            
            StringBuilder cmdText = new StringBuilder();
			cmdText.Append(@"UPDATE [App_Province]
								SET [ProName]=@ProName
									   ,[ProSort]=@ProSort
							  	   ,[ProRemark]=@ProRemark
							  WHERE [ProID]=@ProID");
            return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString(), para);
             }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Update()发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Update()发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Update()发生Exception", ex);
            }
            return -1;
        }

		 /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Province GetModelById(int ProID)
        {
             SqlDataReader reader = null;
            try
            {
			SqlParameter[] para = 
			{
                new SqlParameter("@ProID",ProID),
			};
           
            reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Province WHERE ProID=@ProID", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Province >.GetModelByReader(reader);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetModelById(int id)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetModelById(int id)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetModelById(int id)发生Exception", ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return null;
        }
     
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable()
        {
             try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM App_Province order by ProSort");
           
             return SqlHelper.ExecuteDataTable(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString());
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetTable发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetTable发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetTable发生Exception", ex);
            }
            return null;
        }

		#endregion

		
    }
}