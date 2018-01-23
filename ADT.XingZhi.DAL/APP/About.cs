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

    public class About : IAbout
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public About() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.About model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@title",model.title),
				new SqlParameter("@context",model.context),
				new SqlParameter("@tp_id",model.tp_id),
				new SqlParameter("@begintime",model.begintime),
				new SqlParameter("@contact",model.contact),
				new SqlParameter("@phone",model.phone),
				new SqlParameter("@praise",model.praise),
				new SqlParameter("@number",model.number),
				new SqlParameter("@numberlimit",model.numberlimit),
				new SqlParameter("@age",model.age),
				new SqlParameter("@sex",model.sex),
				new SqlParameter("@address",model.address),
				new SqlParameter("@province",model.province),
				new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@state",model.state),
				new SqlParameter("@specifictime",model.specifictime),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
				new SqlParameter("@pic",model.pic),
				new SqlParameter("@other",model.other)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_About(
			           				title
						 	        ,context
						 	        ,tp_id
						 	        ,begintime
						 	        ,contact
						 	        ,phone
						 	        ,praise
						 	        ,number
						 	        ,numberlimit
						 	        ,age
						 	        ,sex
						 	        ,address
						 	        ,province
						 	        ,city
						 	        ,district
						 	        ,state
						 	        ,specifictime
						 	        ,createtime
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid
						 	        ,pic
						 	        ,other
						  ) VALUES(
									@title
									,@context
									,@tp_id
									,@begintime
									,@contact
									,@phone
									,@praise
									,@number
									,@numberlimit
									,@age
									,@sex
									,@address
									,@province
									,@city
									,@district
									,@state
									,@specifictime
									,@createtime
									,@modifytime
									,@userid
									,@muserid
									,@pic
									,@other
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
        public int Delete(int ab_id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@ab_id",ab_id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_About]
     							   WHERE ab_id=@ab_id");
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
        public int Update(Models.APP.About model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@ab_id",model.ab_id),
				new SqlParameter("@title",model.title),
				new SqlParameter("@context",model.context),
				new SqlParameter("@tp_id",model.tp_id),
				new SqlParameter("@begintime",model.begintime),
				new SqlParameter("@contact",model.contact),
				new SqlParameter("@phone",model.phone),
				new SqlParameter("@praise",model.praise),
				new SqlParameter("@number",model.number),
				new SqlParameter("@numberlimit",model.numberlimit),
				new SqlParameter("@age",model.age),
				new SqlParameter("@sex",model.sex),
				new SqlParameter("@address",model.address),
				new SqlParameter("@province",model.province),
				new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@state",model.state),
				new SqlParameter("@specifictime",model.specifictime),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
				new SqlParameter("@pic",model.pic),
				new SqlParameter("@other",model.other)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_About]
								SET [title]=@title
									   ,[context]=@context
							  	   ,[tp_id]=@tp_id
							  	   ,[begintime]=@begintime
							  	   ,[contact]=@contact
							  	   ,[phone]=@phone
							  	   ,[praise]=@praise
							  	   ,[number]=@number
							  	   ,[numberlimit]=@numberlimit
							  	   ,[age]=@age
							  	   ,[sex]=@sex
							  	   ,[address]=@address
							  	   ,[province]=@province
							  	   ,[city]=@city
							  	   ,[district]=@district
							  	   ,[state]=@state
							  	   ,[specifictime]=@specifictime
							  	   ,[createtime]=@createtime
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  	   ,[pic]=@pic
							  	   ,[other]=@other
							  WHERE [ab_id]=@ab_id");
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
        /// 修改状态
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(int aid,int type,int mid)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@ab_id",aid),
				
				new SqlParameter("@state",type),
				
				new SqlParameter("@modifytime",DateTime.Now),
				
				new SqlParameter("@muserid",mid)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_About]
								SET[state]=@state							  	   
							  	   ,[modifytime]=@modifytime							  	
							  	   ,[muserid]=@muserid							  	  
							  WHERE [ab_id]=@ab_id");
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
        public Models.APP.About GetModelById(int ab_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@ab_id",ab_id),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_About WHERE ab_id=@ab_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.About>.GetModelByReader(reader);
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
                cmdText.Append(@"SELECT * FROM App_About");

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
        ///  根据id查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(int abid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT ab_id,pic,AnOrangepic,IosOrangepic,title,username,phone,address,number,sex,context,agename,numberlimit,movement,begintime,specifictime,userid FROM View_About where ab_id=" + abid);

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
        /// 更新报名人数
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="type">0添加1减少</param>
        /// <returns></returns>
        public int UpdateNumber(int aid, int type)
        {
            try
            {
                SqlParameter[] para = { new SqlParameter("@a_id", aid) };

                StringBuilder cmdText = new StringBuilder();
                if (type == 0)
                    cmdText.Append(@"UPDATE [App_About]	SET  [number]=[number]+1 WHERE [ab_id]=@a_id");
                else if (type == 1)
                    cmdText.Append(@"UPDATE [App_About]	SET  [number]=[number]-1 WHERE [ab_id]=@a_id");

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
        #endregion


    }
}