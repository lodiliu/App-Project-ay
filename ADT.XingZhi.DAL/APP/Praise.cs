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
    
	public class Praise : IPraise
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Praise (){ }
		#region  Method 
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Praise model)
        { 
             try
            {
                 SqlParameter[] para = 
			         {
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@type",model.type),
				new SqlParameter("@createtime",model.createtime)
                     };
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(@"INSERT INTO App_Praise(
			           				m_id
						 	        ,a_id
						 	        ,type
						 	        ,createtime
						  ) VALUES(
									@m_id
									,@a_id
									,@type
									,@createtime
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
        public int Delete(int  pr_id)
		{
           try
            {
			SqlParameter[] para = 
			      {new SqlParameter("@pr_id",pr_id)
			       };
            StringBuilder cmdText = new StringBuilder();
			cmdText.Append(@"DELETE FROM [App_Praise]
     							   WHERE pr_id=@pr_id");
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
        public int Update(Models.APP.Praise model)
        {  
            try
            {
			 SqlParameter[] para = 
			          {
				new SqlParameter("@pr_id",model.pr_id),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@type",model.type),
				new SqlParameter("@createtime",model.createtime)
                      };
            
            StringBuilder cmdText = new StringBuilder();
			cmdText.Append(@"UPDATE [App_Praise]
								SET [m_id]=@m_id
									   ,[a_id]=@a_id
							  	   ,[type]=@type
							  	   ,[createtime]=@createtime
							  WHERE [pr_id]=@pr_id");
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
        public Models.APP.Praise GetModelById(int pr_id)
        {
             SqlDataReader reader = null;
            try
            {
			SqlParameter[] para = 
			{
                new SqlParameter("@pr_id",pr_id),
			};
           
            reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Praise WHERE pr_id=@pr_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Praise >.GetModelByReader(reader);
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
               cmdText.Append(@"SELECT * FROM App_Praise");
           
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

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="aid"></param>
        /// <returns></returns>
        public DataTable GetTable(int mid, int aid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM App_Praise where m_id="+mid+" and a_id="+aid);

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