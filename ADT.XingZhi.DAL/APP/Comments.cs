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

    public class Comments : IComments
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Comments() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Comments model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@context",model.context),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@type",model.type),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_Comments(
			           				context
						 	        ,m_id
						 	        ,a_id
						 	        ,type
						 	        ,createtime
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid
						  ) VALUES(
									@context
									,@m_id
									,@a_id
									,@type
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
        public int Delete(int c_id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@c_id",c_id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Comments]
     							   WHERE c_id=@c_id");
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
        public int Update(Models.APP.Comments model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@c_id",model.c_id),
				new SqlParameter("@context",model.context),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@type",model.type),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Comments]
								SET [context]=@context
									   ,[m_id]=@m_id
							  	   ,[a_id]=@a_id
							  	   ,[type]=@type
							  	   ,[createtime]=@createtime
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  WHERE [c_id]=@c_id");
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
        public Models.APP.Comments GetModelById(int c_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@c_id",c_id),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Comments WHERE c_id=@c_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Comments>.GetModelByReader(reader);
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
        /// 查询数据
        /// </summary>
        ///  <param name="top">前几条（0全部）</param>
        ///   <param name="aid">活动id</param>
        /// <returns></returns>
        public DataTable GetTable(int top, int aid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                if (top == 0)
                    cmdText.Append(@"SELECT App_Comments.* ,username,pic FROM App_Comments left join App_Member on App_Member.m_id=App_Comments.m_id where a_id=" + aid + " order by createtime desc");
                else
                    cmdText.Append(@"SELECT top " + top + " App_Comments.* ,username,pic FROM App_Comments left join App_Member on App_Member.m_id=App_Comments.m_id where a_id=" + aid + " order by createtime desc");
               
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