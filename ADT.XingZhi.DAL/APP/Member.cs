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

    public class Member : IMember
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Member() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Member model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@username",model.username),
				new SqlParameter("@account",model.account),
				new SqlParameter("@pwd",model.pwd),
				new SqlParameter("@pic",model.pic),
				new SqlParameter("@name",model.name),
				new SqlParameter("@phon",model.phon),
				new SqlParameter("@sex",model.sex),
				new SqlParameter("@age",model.age),
                new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@address",model.address),
				new SqlParameter("@tp_pfid",model.tp_pfid),
				new SqlParameter("@tp_id",model.tp_id),
				new SqlParameter("@context",model.context),
				new SqlParameter("@isopen",model.isopen),
				new SqlParameter("@type",model.type),
				new SqlParameter("@ip",model.ip),
				new SqlParameter("@logintype",model.logintype),
				new SqlParameter("@loginnum",model.loginnum),
				new SqlParameter("@logintime",model.logintime),
				new SqlParameter("@openid",model.openid),
				new SqlParameter("@opentype",model.opentype),
				new SqlParameter("@datum",model.datum),
				new SqlParameter("@signnum",model.signnum),
				new SqlParameter("@sharenum",model.sharenum),
				new SqlParameter("@pushuserid",model.pushuserid),
				new SqlParameter("@pushchannelid",model.pushchannelid),
				new SqlParameter("@m_valid",model.m_valid)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_Member(
			           				username
						 	        ,account
						 	        ,pwd
						 	        ,pic
						 	        ,name
						 	        ,phon
						 	        ,sex
						 	        ,age
                                    ,city
						 	        ,district
						 	        ,address
						 	        ,tp_pfid
						 	        ,tp_id
						 	        ,context
						 	        ,isopen
						 	        ,type
						 	        ,ip
						 	        ,logintype
						 	        ,loginnum
						 	        ,logintime
						 	        ,openid
						 	        ,opentype
						 	        ,datum
						 	        ,signnum
						 	        ,sharenum
						 	        ,pushuserid
						 	        ,pushchannelid
						 	        ,m_valid
						  ) VALUES(
									@username
									,@account
									,@pwd
									,@pic
									,@name
									,@phon
									,@sex
									,@age
                                    ,@city
									,@district
									,@address
									,@tp_pfid
									,@tp_id
									,@context
									,@isopen
									,@type
									,@ip
									,@logintype
									,@loginnum
									,@logintime
									,@openid
									,@opentype
									,@datum
									,@signnum
									,@sharenum
									,@pushuserid
									,@pushchannelid
									,@m_valid
					);SELECT @@Identity");

                return Convert.ToInt32(SqlHelper.ExecuteScalar(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString(), para));
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
        public int Delete(int m_id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@m_id",m_id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Member]
     							   WHERE m_id=@m_id");
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
        public int Update(Models.APP.Member model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@username",model.username),
				new SqlParameter("@account",model.account),
				new SqlParameter("@pwd",model.pwd),
				new SqlParameter("@pic",model.pic),
				new SqlParameter("@name",model.name),
				new SqlParameter("@phon",model.phon),
				new SqlParameter("@sex",model.sex),
				new SqlParameter("@age",model.age),
                new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@address",model.address),
				new SqlParameter("@tp_pfid",model.tp_pfid),
				new SqlParameter("@tp_id",model.tp_id),
				new SqlParameter("@context",model.context),
				new SqlParameter("@isopen",model.isopen),
				new SqlParameter("@type",model.type),
				new SqlParameter("@ip",model.ip),
				new SqlParameter("@logintype",model.logintype),
				new SqlParameter("@loginnum",model.loginnum),
				new SqlParameter("@logintime",model.logintime),
				new SqlParameter("@openid",model.openid),
				new SqlParameter("@opentype",model.opentype),
				new SqlParameter("@datum",model.datum),
				new SqlParameter("@signnum",model.signnum),
				new SqlParameter("@sharenum",model.sharenum),
				new SqlParameter("@pushuserid",model.pushuserid),
				new SqlParameter("@pushchannelid",model.pushchannelid),
				new SqlParameter("@m_valid",model.m_valid),
                	new SqlParameter("@modifytime",model.modifytime)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Member]
								SET [username]=@username
									   ,[account]=@account
							  	   ,[pwd]=@pwd
							  	   ,[pic]=@pic
							  	   ,[name]=@name
							  	   ,[phon]=@phon
							  	   ,[sex]=@sex
							  	   ,[age]=@age
                                   ,[city]=@city
 							  	   ,[district]=@district
							  	   ,[address]=@address
							  	   ,[tp_pfid]=@tp_pfid
							  	   ,[tp_id]=@tp_id
							  	   ,[context]=@context
							  	   ,[isopen]=@isopen
							  	   ,[type]=@type
							  	   ,[ip]=@ip
							  	   ,[logintype]=@logintype
							  	   ,[loginnum]=@loginnum
                                   ,[modifytime]=@modifytime
							  	   ,[logintime]=@logintime
							  	   ,[openid]=@openid
							  	   ,[opentype]=@opentype
							  	   ,[datum]=@datum
							  	   ,[signnum]=@signnum
							  	   ,[sharenum]=@sharenum
							  	   ,[pushuserid]=@pushuserid
							  	   ,[pushchannelid]=@pushchannelid
							  	   ,[m_valid]=@m_valid
							  WHERE [m_id]=@m_id");
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
        public Models.APP.Member GetModelById(int m_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@m_id",m_id),
			};

            
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Member WHERE m_id=@m_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Member>.GetModelByReader(reader);
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
        public DataTable GetTable(int m_id)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM View_Member where m_id="+m_id);

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
        /// 根据手机号得到一个实体
        /// </summary>
        /// <param name="phon"></param>
        /// <returns></returns>
        public Models.APP.Member GetModelByAccount(string account)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@account",account),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Member WHERE account=@account", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Member>.GetModelByReader(reader);
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
        /// 第三方得到一个实体
        /// </summary>
        /// <param name="phon"></param>
        /// <returns></returns>
        public Models.APP.Member GetModelByLoginOpen(string openid, int opentype)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@openid",openid),
                new SqlParameter("@opentype",opentype)
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Member WHERE openid=@openid and opentype=@opentype", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Member>.GetModelByReader(reader);
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
        public DataTable GetTable(string username,int mid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM View_Member where m_id not in(select m_id from App_Friends where userid=" + mid + ") and m_id not in('"+mid+"') and username  like '%" + username + "%'");

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