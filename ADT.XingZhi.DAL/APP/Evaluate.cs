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

    public class Evaluate : IEvaluate
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Evaluate() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Evaluate model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@star",model.star),
				new SqlParameter("@context",model.context),
				new SqlParameter("@type",model.type),
				new SqlParameter("@createtime",model.createtime)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_Evaluate(
			           				m_id
						 	        ,userid
						 	        ,star
						 	        ,context
						 	        ,type
						 	        ,createtime
						  ) VALUES(
									@m_id
									,@userid
									,@star
									,@context
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
        public int Delete(int ev_id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@ev_id",ev_id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Evaluate]
     							   WHERE ev_id=@ev_id");
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
        public int Update(Models.APP.Evaluate model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@ev_id",model.ev_id),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@star",model.star),
				new SqlParameter("@context",model.context),
				new SqlParameter("@type",model.type),
				new SqlParameter("@createtime",model.createtime)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Evaluate]
								SET [m_id]=@m_id
									   ,[userid]=@userid
							  	   ,[star]=@star
							  	   ,[context]=@context
							  	   ,[type]=@type
							  	   ,[createtime]=@createtime
							  WHERE [ev_id]=@ev_id");
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
        public Models.APP.Evaluate GetModelById(int ev_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@ev_id",ev_id),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Evaluate WHERE ev_id=@ev_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Evaluate>.GetModelByReader(reader);
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
        ///   <param name="mid">被评论人id</param>
        /// <returns></returns>
        public DataTable GetTable(int top, int mid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                //   cmdText.Append(@"SELECT * FROM App_Evaluate");


                if (top == 0)
                    cmdText.Append(@"SELECT App_Evaluate.* ,username,pic FROM App_Evaluate left join App_Member on App_Member.m_id=App_Evaluate.m_id where m_id=" + mid + " order by createtime desc");
                else
                    cmdText.Append(@"SELECT top " + top + " App_Evaluate.* ,username,pic FROM App_Evaluate left join App_Member on App_Member.m_id=App_Evaluate.m_id where m_id=" + mid + " order by createtime desc");

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
        /// 查询平均值
        /// </summary>
        /// <returns></returns>
        public int GetAvg(int mid)
        {
            try
            {
                return Convert.ToInt32(SqlHelper.ExecuteScalar(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "select AVG(star) from App_Evaluate where star not in('0') and m_id=" + mid + ";SELECT @@Identity"));
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetAvg发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetAvg发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetAvg发生Exception", ex);
            }
            return 0;
        }

        #endregion


    }
}