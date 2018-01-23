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
    
	public class Feedback : IFeedback
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Feedback (){ }
		#region  Method 
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Feedback model)
        { 
             try
            {
                 SqlParameter[] para = 
			         {
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@context",model.context),
				new SqlParameter("@reply",model.reply),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                     };
            StringBuilder cmdText = new StringBuilder();
            cmdText.Append(@"INSERT INTO App_Feedback(
			           				m_id
						 	        ,context
						 	        ,reply
						 	        ,createtime
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid
						  ) VALUES(
									@m_id
									,@context
									,@reply
									,@createtime
									,@modifytime
									,@userid
									,@muserid
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
        public int Delete(int  fb_id)
		{
           try
            {
			SqlParameter[] para = 
			      {new SqlParameter("@fb_id",fb_id)
			       };
            StringBuilder cmdText = new StringBuilder();
			cmdText.Append(@"DELETE FROM [App_Feedback]
     							   WHERE fb_id=@fb_id");
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
        public int Update(Models.APP.Feedback model)
        {  
            try
            {
			 SqlParameter[] para = 
			          {
				new SqlParameter("@fb_id",model.fb_id),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@context",model.context),
				new SqlParameter("@reply",model.reply),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                      };
            
            StringBuilder cmdText = new StringBuilder();
			cmdText.Append(@"UPDATE [App_Feedback]
								SET [m_id]=@m_id
									   ,[context]=@context
							  	   ,[reply]=@reply
							  	   ,[createtime]=@createtime
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  WHERE [fb_id]=@fb_id");
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
        public Models.APP.Feedback GetModelById(int fb_id)
        {
             SqlDataReader reader = null;
            try
            {
			SqlParameter[] para = 
			{
                new SqlParameter("@fb_id",fb_id),
			};
           
            reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Feedback WHERE fb_id=@fb_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Feedback >.GetModelByReader(reader);
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
               cmdText.Append(@"SELECT * FROM App_Feedback");
           
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