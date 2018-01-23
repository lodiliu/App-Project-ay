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

    public class package : Ipackage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public package() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.package model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@title",model.title),
				new SqlParameter("@amount",model.amount),
				new SqlParameter("@number",model.number),
				new SqlParameter("@numberlimit",model.numberlimit),
				new SqlParameter("@context",model.context),
				new SqlParameter("@bytime",model.bytime),
				new SqlParameter("@begintime",model.begintime),
				new SqlParameter("@endtime",model.endtime),
				new SqlParameter("@address",model.address),
				new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@longitude",model.longitude),
				new SqlParameter("@latitude",model.latitude),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
				new SqlParameter("@createtime",model.createtime),
                	new SqlParameter("@ptype",model.ptype)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_package(
			           				a_id
						 	        ,title
						 	        ,amount
						 	        ,number
						 	        ,numberlimit
						 	        ,context
						 	        ,bytime
						 	        ,begintime
						 	        ,endtime
						 	        ,address
						 	        ,city
						 	        ,district
						 	        ,longitude
						 	        ,latitude
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid
						 	        ,createtime
                                    ,ptype
						  ) VALUES(
									@a_id
									,@title
									,@amount
									,@number
									,@numberlimit
									,@context
									,@bytime
									,@begintime
									,@endtime
									,@address
									,@city
									,@district
									,@longitude
									,@latitude
									,@modifytime
									,@userid
									,@muserid
									,@createtime
                                    ,@ptype
					);SELECT @@Identity;");

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
        public int Delete(int pk_id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@pk_id",pk_id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_package]
     							   WHERE pk_id=@pk_id");
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
        public int DeleteByaid(int aid)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@a_id",aid)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_package]
     							   WHERE a_id=@a_id");
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
        public int Update(Models.APP.package model)
        {

            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@pk_id",model.pk_id),
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@title",model.title),
				new SqlParameter("@amount",model.amount),
				new SqlParameter("@number",model.number),
				new SqlParameter("@numberlimit",model.numberlimit),
				new SqlParameter("@context",model.context),
				new SqlParameter("@bytime",model.bytime),
				new SqlParameter("@begintime",model.begintime),
				new SqlParameter("@endtime",model.endtime),
				new SqlParameter("@address",model.address),
				new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@longitude",model.longitude),
				new SqlParameter("@latitude",model.latitude),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
				new SqlParameter("@createtime",model.createtime),
                new SqlParameter("@ptype",model.ptype)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_package]
								SET [a_id]=@a_id
									   ,[title]=@title
							  	   ,[amount]=@amount
							  	   ,[number]=@number
							  	   ,[numberlimit]=@numberlimit
							  	   ,[context]=@context
							  	   ,[bytime]=@bytime
							  	   ,[begintime]=@begintime
							  	   ,[endtime]=@endtime
							  	   ,[address]=@address
							  	   ,[city]=@city
							  	   ,[district]=@district
							  	   ,[longitude]=@longitude
							  	   ,[latitude]=@latitude
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  	   ,[createtime]=@createtime
                                   ,[ptype]=@ptype
							  WHERE [pk_id]=@pk_id");
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
        /// 更新报名人数
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="type">0添加1减少</param>
        /// <returns></returns>
        public int UpdateNumber(int pkid, int type)
        {
            try
            {
                SqlParameter[] para = { new SqlParameter("@pk_id", pkid) };

                StringBuilder cmdText = new StringBuilder();
                if (type == 0)
                    cmdText.Append(@"UPDATE [App_package]	SET  [number]=[number]+1 WHERE [pk_id]=@pk_id");
                else if (type == 1)
                    cmdText.Append(@"UPDATE [App_package]	SET  [number]=[number]-1 WHERE [pk_id]=@pk_id");
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString(), para);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法UpdateNumber()发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法UpdateNumber()发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法UpdateNumber()发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.package GetModelById(int pk_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@pk_id",pk_id),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_package WHERE pk_id=@pk_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.package>.GetModelByReader(reader);
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
        public DataTable GetTable(DateTime dtime)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM App_package where  endtime>='" + dtime + "' and begintime<='" + dtime + "'");

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
        /// 查询培训套餐
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int a_id)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM App_package where a_id=" + a_id);

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