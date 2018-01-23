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

    public class Message : IMessage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Message() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Message model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@context",model.context),
				new SqlParameter("@type",model.type),
                new SqlParameter("@pic",model.pic),
				new SqlParameter("@title",model.title),
				new SqlParameter("@isread",model.isread),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
				new SqlParameter("@isactivaty",model.isactivaty)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_Message(
			           				m_id
						 	        ,a_id
						 	        ,context
						 	        ,type
                                    ,pic
						 	        ,title
						 	        ,isread
						 	        ,createtime
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid
                                    ,isactivaty
						  ) VALUES(
									@m_id
									,@a_id
									,@context
									,@type
                                    ,@pic
						 	        ,@title
						 	        ,@isread
									,@createtime
									,@modifytime
									,@userid
									,@muserid
                                    ,@isactivaty
					);SELECT @@Identity");

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
        /// 删除一个实体(0系统消息1好友邀请2二维码)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int aid, int mid,int type)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@a_id",aid),
                      new SqlParameter("@type",type),
                      new SqlParameter("@m_id",mid)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Message]
     							   WHERE a_id=@a_id  and m_id=@m_id and type=@type");
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
        /// 删除一个实体(3添加好友信息)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int userid, int mid)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@userid",userid),
                      new SqlParameter("@type",3),
                      new SqlParameter("@m_id",mid)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Message]
     							   WHERE userid=@userid  and m_id=@m_id and type=@type");
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
        /// 删除一个实体(4公告信息)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int DeleteMessage(int aid)
        {
            try
            {
                SqlParameter[] para = 
			      {
                      new SqlParameter("@type",4),
                      new SqlParameter("@a_id",aid)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Message]
     							   WHERE a_id=@a_id and type=@type");
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
        /// 删除一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Delete(int meid)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@me_id",meid)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Message]
     							   WHERE me_id=@me_id");
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
        public int Update(Models.APP.Message model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@me_id",model.me_id),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@context",model.context),
				new SqlParameter("@type",model.type),
                 new SqlParameter("@pic",model.pic),
				new SqlParameter("@title",model.title),
				new SqlParameter("@isread",model.isread),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Message]
								SET [m_id]=@m_id
									   ,[a_id]=@a_id
							  	   ,[context]=@context
							  	   ,[type]=@type
                                   ,[pic]=@pic
							  	   ,[title]=@title
							  	   ,[isread]=@isread
							  	   ,[createtime]=@createtime
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  WHERE [me_id]=@me_id");
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
        /// 修改状态(0系统消息1好友邀请2二维码)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(int aid, int m_id,int type)
        {
            try
            {
                SqlParameter[] para = 
			          {
                 new SqlParameter("@m_id",m_id),
				new SqlParameter("@a_id",aid),	
		        new SqlParameter("@type",type),	
				new SqlParameter("@isread",1),			
				new SqlParameter("@modifytime",DateTime.Now)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Message] SET [isread]=@isread ,[modifytime]=@modifytime  WHERE [a_id]=@a_id and [m_id]=@m_id and type=@type");
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
        /// 修改状态(3同意好友)
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(int userid, int mid)
        {
            try
            {
                SqlParameter[] para = 
			          {
                 new SqlParameter("@m_id",mid),
				new SqlParameter("@userid",userid),	
		        new SqlParameter("@type",3),	
				new SqlParameter("@isread",1),			
				new SqlParameter("@modifytime",DateTime.Now)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Message] SET [isread]=@isread ,[modifytime]=@modifytime  WHERE [userid]=@userid and [m_id]=@m_id and type=@type");
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
        public Models.APP.Message GetModelById(int me_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@me_id",me_id),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Message WHERE me_id=@me_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Message>.GetModelByReader(reader);
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
        /// 获得一个添加好友信息实体
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Message GetModel(string m_id, string fid)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@userid",m_id),
                 new SqlParameter("@m_id",fid)
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Message WHERE m_id=@m_id and userid=@userid and type=3", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Message>.GetModelByReader(reader);
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
        public DataTable GetTable(int mid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM App_Message");

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
        /// 查询所有数据
        /// </summary>
        /// <param name="top">前几条数据，0全部</param>
        /// <param name="a_id">活动id</param>
        /// <param name="type">类型类型（0、系统消息1、活动邀请2、二维码3、添加好友消息4、活动公告的）</param>
        /// <param name="isread">-1全部0未读1已读</param>
        /// <returns></returns>
        public DataTable GetTable(int top, int a_id, int type)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                if (top == 0)
                    cmdText.Append(@"SELECT * FROM App_Message where a_id=" + a_id + " and type=" + type + " order by createtime desc");
                else
                    cmdText.Append(@"SELECT top " + top + " * FROM App_Message where a_id=" + a_id + " and type=" + type + " order by createtime desc");

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
        /// 查询未读数据
        /// </summary>
        /// <param name="mid">用户id</param>
        /// <param name="a_id">活动id</param>
        /// <param name="type">类型类型（0、系统消息1、活动邀请2、二维码3、添加好友消息4、活动公告的）</param>
        /// <param name="isread">-1全部0未读1已读</param>
        /// <returns></returns>
        public DataTable GetTable(int mid, int a_id, int type, int isread)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                if(isread==-1)
                cmdText.Append(@"SELECT * FROM App_Message where a_id=" + a_id + " and m_id=" + mid + " and type=" + type + " order by createtime desc");
               else
                    cmdText.Append(@"SELECT * FROM App_Message where a_id=" + a_id + " and m_id=" + mid + " and type=" + type + " and isread="+isread+" order by createtime desc");
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