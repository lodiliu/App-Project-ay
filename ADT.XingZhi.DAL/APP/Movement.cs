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

    public class Movement : IMovement
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Movement() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Movement model)
        {

            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@tp_id",model.tp_id),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@type",model.type),
				new SqlParameter("@sort",model.sort)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_Movement(
			           				m_id
						 	        ,tp_id
						 	        ,createtime
						 	        ,userid
						 	        ,type
						 	        ,sort
						  ) VALUES(
									@m_id
									,@tp_id
									,@createtime
									,@userid
									,@type
									,@sort
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
        public int Delete(int m_id,int tp_id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@m_id",m_id),
                      new SqlParameter("@tp_id",tp_id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Movement]
     							   WHERE m_id=@m_id and tp_id=@tp_id and type=1");
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
        public int Update(Models.APP.Movement model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@mo_id",model.mo_id),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@tp_id",model.tp_id),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@type",model.type),
				new SqlParameter("@sort",model.sort)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Movement]
								SET [m_id]=@m_id
									   ,[tp_id]=@tp_id
							  	   ,[createtime]=@createtime
							  	   ,[userid]=@userid
							  	   ,[type]=@type
							  	   ,[sort]=@sort
							  WHERE [mo_id]=@mo_id");
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
        public Models.APP.Movement GetModelById(int mo_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@mo_id",mo_id),
			};
              
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Movement WHERE mo_id=@mo_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Movement>.GetModelByReader(reader);
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
        /// <param name="mid">用户id</param>
        /// <returns></returns>
        public DataTable GetTable(int mid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM View_Movement where m_id ='" + mid + "'  order by sort asc,createtime asc");

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
        /// 更新排序值
        /// </summary>
        /// <returns></returns>
        public void UpdateOrderId(DataTable dt,int mid)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@OrderData", SqlDbType.Structured) };
                param[0].Value = dt;
                param[0].TypeName = "dbo.OrderTableType";
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE a SET a.sort=b.orderid FROM [App_Movement] AS a JOIN @OrderData AS b ON b.id=a.tp_id where a.m_id='"+mid+"'", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法UpdateOrderId(DataTable dt)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法UpdateOrderId(DataTable dt)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法UpdateOrderId(DataTable dt)发生Exception", ex);
            }
        }

        ///// <summary>
        ///// 根据id组查询数据
        ///// </summary>
        ///// <param name="tpid">查询id</param>
        ///// <returns></returns>
        //public DataTable GetTableIn(string mid)
        //{
        //    try
        //    {
        //        StringBuilder cmdText = new StringBuilder();

        //        cmdText.Append(@"SELECT * FROM View_Movement where m_id ='" + mid + "'  order by sort");

        //        return SqlHelper.ExecuteDataTable(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString());
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        logger.Error("调用方法GetTableIn发生ArgumentNullException", ex);
        //    }
        //    catch (SqlException ex)
        //    {
        //        logger.Error("调用方法GetTableIn发生SqlException", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("调用方法GetTableIn发生Exception", ex);
        //    }
        //    return null;
        //}
        #endregion


    }
}