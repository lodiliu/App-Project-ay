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
    
	public class GroupMember : IGroupMember
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public GroupMember (){ }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.GroupMember model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@g_id",model.g_id),
				new SqlParameter("@type",model.type),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_GroupMember(
			           				m_id
						 	        ,g_id
						 	        ,type
						 	        ,createtime
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid
						  ) VALUES(
									@m_id
									,@g_id
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
        public int Delete(string m_id, string gid)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@m_id",m_id),
                      new SqlParameter("@g_id",gid)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_GroupMember]
     							   WHERE m_id=@m_id and g_id=@g_id");
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
        /// 删除一组实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(string gid)
        {
            try
            {
                SqlParameter[] para = 
			      {
                      new SqlParameter("@g_id",gid)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_GroupMember]
     							   WHERE g_id=@g_id");
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
        public int Update(Models.APP.GroupMember model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@gm_id",model.gm_id),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@g_id",model.g_id),
				new SqlParameter("@type",model.type),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_GroupMember]
								SET [m_id]=@m_id
									   ,[g_id]=@g_id
							  	   ,[type]=@type
							  	   ,[createtime]=@createtime
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  WHERE [gm_id]=@gm_id");
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
        public Models.APP.GroupMember GetModelById(string gid,string mid)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@g_id",gid),
                 new SqlParameter("@m_id",mid)
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_GroupMember WHERE g_id=@g_id and m_id=@m_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.GroupMember>.GetModelByReader(reader);
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
        public DataTable GetTable(int top,string gid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                if(top==0)
                    cmdText.Append(@"SELECT * FROM View_GroupMember where g_id='" + gid + "' order by createtime asc");
                else
                    cmdText.Append(@"SELECT top " + top + " * FROM View_GroupMember where g_id='" + gid + "' order by createtime asc");

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