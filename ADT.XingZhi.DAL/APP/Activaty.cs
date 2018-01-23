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

    public class Activaty : IActivaty
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Activaty() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Activaty model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@tp_id",model.tp_id),
				new SqlParameter("@title",model.title),
				new SqlParameter("@context",model.context),
				new SqlParameter("@type",model.type),
				new SqlParameter("@bytime",model.bytime),
				new SqlParameter("@begintime",model.begintime),
				new SqlParameter("@endtime",model.endtime),
				new SqlParameter("@organizers",model.organizers),
				new SqlParameter("@contact",model.contact),
				new SqlParameter("@phone",model.phone),
				new SqlParameter("@praise",model.praise),
				new SqlParameter("@number",model.number),
				new SqlParameter("@numberlimit",model.numberlimit),
				new SqlParameter("@money",model.money),
				new SqlParameter("@ptype",model.ptype),
				new SqlParameter("@state",model.state),
				new SqlParameter("@address",model.address),
				new SqlParameter("@isactivaty",model.isactivaty),
				new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
				new SqlParameter("@pic",model.pic),
				new SqlParameter("@specifictime",model.specifictime),
				new SqlParameter("@endspecifictime",model.endspecifictime),
				new SqlParameter("@other",model.other),
				new SqlParameter("@longitude",model.longitude),
				new SqlParameter("@latitude",model.latitude),
				new SqlParameter("@mypic",model.mypic),
				new SqlParameter("@duserid",model.duserid)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_Activaty(
			           				tp_id
						 	        ,title
						 	        ,context
						 	        ,type
						 	        ,bytime
						 	        ,begintime
						 	        ,endtime
						 	        ,organizers
						 	        ,contact
						 	        ,phone
						 	        ,praise
						 	        ,number
						 	        ,numberlimit
						 	        ,money
						 	        ,ptype
						 	        ,state
						 	        ,address
						 	        ,isactivaty
						 	        ,city
						 	        ,district
						 	        ,createtime
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid
						 	        ,pic
						 	        ,specifictime
						 	        ,endspecifictime
						 	        ,other
						 	        ,longitude
						 	        ,latitude
						 	        ,mypic
                                    ,duserid
						  ) VALUES(
									@tp_id
									,@title
									,@context
									,@type
									,@bytime
									,@begintime
									,@endtime
									,@organizers
									,@contact
									,@phone
									,@praise
									,@number
									,@numberlimit
									,@money
									,@ptype
									,@state
									,@address
									,@isactivaty
									,@city
									,@district
									,@createtime
									,@modifytime
									,@userid
									,@muserid
									,@pic
									,@specifictime
									,@endspecifictime
									,@other
									,@longitude
									,@latitude
									,@mypic
                                    ,@duserid
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
        public int Delete(int a_id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@a_id",a_id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Activaty]
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
        public int Update(int aid, int state, string mid)
        {
            try
            {

                SqlParameter[] para = 
			          {
				new SqlParameter("@a_id",aid),			
				new SqlParameter("@state",state),	
			    new SqlParameter("@muserid",mid),
				new SqlParameter("@modifytime",DateTime.Now)
                      };

                StringBuilder cmdText = new StringBuilder();
                if (mid != "")
                {
                    cmdText.Append(@"UPDATE [App_Activaty]
								SET [state]=@state
							  	   ,[modifytime]=@modifytime
							  	   ,[muserid]=@muserid
							  WHERE [a_id]=@a_id");
                }
                else
                {
                    cmdText.Append(@"UPDATE [App_Activaty]
								SET [state]=@state
							  	   ,[modifytime]=@modifytime
							  WHERE [a_id]=@a_id");
                }
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
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(int aid, string gid)
        {
            try
            {

                SqlParameter[] para = 
			          {
				new SqlParameter("@a_id",aid),			
				new SqlParameter("@g_id",gid),	
                      };

                StringBuilder cmdText = new StringBuilder();

                cmdText.Append(@"UPDATE [App_Activaty]
								SET [g_id]=@g_id
							  WHERE [a_id]=@a_id");

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
        /// 修改一个实体
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public int Update(Models.APP.Activaty model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@tp_id",model.tp_id),
				new SqlParameter("@title",model.title),
				new SqlParameter("@context",model.context),
				new SqlParameter("@type",model.type),
				new SqlParameter("@bytime",model.bytime),
				new SqlParameter("@begintime",model.begintime),
				new SqlParameter("@endtime",model.endtime),
				new SqlParameter("@organizers",model.organizers),
				new SqlParameter("@contact",model.contact),
				new SqlParameter("@phone",model.phone),
				new SqlParameter("@praise",model.praise),
				new SqlParameter("@number",model.number),
				new SqlParameter("@numberlimit",model.numberlimit),
				new SqlParameter("@money",model.money),
				new SqlParameter("@ptype",model.ptype),
				new SqlParameter("@state",model.state),
				new SqlParameter("@address",model.address),
				new SqlParameter("@isactivaty",model.isactivaty),
				new SqlParameter("@city",model.city),
				new SqlParameter("@district",model.district),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
				new SqlParameter("@pic",model.pic),
				new SqlParameter("@specifictime",model.specifictime),
				new SqlParameter("@endspecifictime",model.endspecifictime),
				new SqlParameter("@other",model.other),
				new SqlParameter("@longitude",model.longitude),
				new SqlParameter("@latitude",model.latitude),
				new SqlParameter("@mypic",model.mypic)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Activaty]
								SET [tp_id]=@tp_id
									   ,[title]=@title
							  	   ,[context]=@context
							  	   ,[type]=@type
							  	   ,[bytime]=@bytime
							  	   ,[begintime]=@begintime
							  	   ,[endtime]=@endtime
							  	   ,[organizers]=@organizers
							  	   ,[contact]=@contact
							  	   ,[phone]=@phone
							  	   ,[praise]=@praise
							  	   ,[number]=@number
							  	   ,[numberlimit]=@numberlimit
							  	   ,[money]=@money
							  	   ,[ptype]=@ptype
							  	   ,[state]=@state
							  	   ,[address]=@address
							  	   ,[isactivaty]=@isactivaty
							  	   ,[city]=@city
							  	   ,[district]=@district
							  	   ,[createtime]=@createtime
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  	   ,[pic]=@pic
							  	   ,[specifictime]=@specifictime
							  	   ,[endspecifictime]=@endspecifictime
							  	   ,[other]=@other
							  	   ,[longitude]=@longitude
							  	   ,[latitude]=@latitude
							  	   ,[mypic]=@mypic
							  WHERE [a_id]=@a_id");
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
        public Models.APP.Activaty GetModelById(int a_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@a_id",a_id),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Activaty WHERE a_id=@a_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Activaty>.GetModelByReader(reader);
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
        /// 获得数据根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public DataTable GetTable(int a_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@a_id",a_id),
			};

                return SqlHelper.ExecuteDataTable(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM View_Activaty WHERE a_id=@a_id", para);

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
        public DataTable GetTable(int twoid, int oneid, int mtepyid, int most, int lately)
        {
            try
            {

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM App_Activaty");

                //  DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString(), page.Value, row.Value, out recordCount);

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
        /// 更新点赞
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public int UpdatePraise(int aid, int pnum)
        {
            try
            {
                SqlParameter[] para = { new SqlParameter("@a_id", aid) };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Activaty]	SET  [praise]=[praise]+" + pnum + "  WHERE [a_id]=@a_id");
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString(), para);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法UpdatePraise()发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法UpdatePraise()发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法UpdatePraise()发生Exception", ex);
            }
            return -1;
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
                    cmdText.Append(@"UPDATE [App_Activaty]	SET  [number]=[number]+1 WHERE [a_id]=@a_id");
                else if (type == 1)
                    cmdText.Append(@"UPDATE [App_Activaty]	SET  [number]=[number]-1 WHERE [a_id]=@a_id");
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