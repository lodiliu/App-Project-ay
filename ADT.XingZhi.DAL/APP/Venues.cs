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
    public class Venues : IVenues
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Venues() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Venues model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@title",model.title),
				new SqlParameter("@pic",model.pic),
				new SqlParameter("@address",model.address),
				new SqlParameter("@province",model.province),
				new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@longitude",model.longitude),
				new SqlParameter("@latitude",model.latitude),
				new SqlParameter("@context",model.context),
				new SqlParameter("@type",model.type),
				new SqlParameter("@environmentType",model.environmentType),
				new SqlParameter("@openness",model.openness),
				new SqlParameter("@state",model.state),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_Venues(
			           				title
						 	        ,pic
						 	        ,address
						 	        ,province
						 	        ,city
						 	        ,district
						 	        ,longitude
						 	        ,latitude
						 	        ,context
						 	        ,type
						 	        ,environmentType
						 	        ,openness
						 	        ,state
						 	        ,createtime
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid
						  ) VALUES(
									@title
									,@pic
									,@address
									,@province
									,@city
									,@district
									,@longitude
									,@latitude
									,@context
									,@type
									,@environmentType
									,@openness
									,@state
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
        public int Delete(int Id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@Id",Id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Venues]
     							   WHERE Id=@Id");
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
        public int Update(Models.APP.Venues model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@Id",model.Id),
				new SqlParameter("@title",model.title),
				new SqlParameter("@pic",model.pic),
				new SqlParameter("@address",model.address),
				new SqlParameter("@province",model.province),
				new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@longitude",model.longitude),
				new SqlParameter("@latitude",model.latitude),
				new SqlParameter("@context",model.context),
				new SqlParameter("@type",model.type),
				new SqlParameter("@environmentType",model.environmentType),
				new SqlParameter("@openness",model.openness),
				new SqlParameter("@state",model.state),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Venues]
								SET [title]=@title
									   ,[pic]=@pic
							  	   ,[address]=@address
							  	   ,[province]=@province
							  	   ,[city]=@city
							  	   ,[district]=@district
							  	   ,[longitude]=@longitude
							  	   ,[latitude]=@latitude
							  	   ,[context]=@context
							  	   ,[type]=@type
							  	   ,[environmentType]=@environmentType
							  	   ,[openness]=@openness
							  	   ,[state]=@state
							  	   ,[createtime]=@createtime
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  WHERE [Id]=@Id");
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
        /// 设置禁用
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="disabled">true-已禁用，false-未禁用</param>
        /// <returns></returns>
        public int SetDisabled(int id, bool disabled)
        {
            try
            {
                SqlParameter[] param = {
					new SqlParameter("@id", SqlDbType.Int),
                    new SqlParameter("@state",SqlDbType.Bit) 
                };
                param[0].Value = id;
                param[1].Value = disabled;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE [App_Venues] SET state=@state WHERE Id=@id", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法SetDisabled(int id, bool disabled)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法SetDisabled(int id, bool disabled)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法SetDisabled(int id, bool disabled)发生Exception", ex);
            }
            return -1;
        }

        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Venues GetModelById(int Id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@Id",Id),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Venues WHERE Id=@Id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Venues>.GetModelByReader(reader);
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
        public DataTable GetTable(int id)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                if (id == 0)
                    cmdText.Append(@"SELECT * FROM View_Venues");
                else
                    cmdText.Append(@"SELECT * FROM View_Venues  where Id=" + id);

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
