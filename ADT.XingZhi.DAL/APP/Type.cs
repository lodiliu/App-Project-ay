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

    public class Type : IType
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Type() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Type model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@text",model.text),
				new SqlParameter("@Anpic",model.Anpic),
				new SqlParameter("@AnIsHomepic",model.AnIsHomepic),
				new SqlParameter("@AnHomepic",model.AnHomepic),
				new SqlParameter("@AnWhitepic",model.AnWhitepic),
				new SqlParameter("@AnOrangepic",model.AnOrangepic),
				new SqlParameter("@AnIsAllpic",model.AnIsAllpic),
				new SqlParameter("@AnAllpic",model.AnAllpic),
				new SqlParameter("@Anpicguanfang",model.Anpicguanfang),
				new SqlParameter("@Anpicminjian",model.Anpicminjian),
				new SqlParameter("@Iospic",model.Iospic),
				new SqlParameter("@IosIsHomepic",model.IosIsHomepic),
				new SqlParameter("@IosHomepic",model.IosHomepic),
				new SqlParameter("@IosWhitepic",model.IosWhitepic),
				new SqlParameter("@IosOrangepic",model.IosOrangepic),
				new SqlParameter("@IosIsAllpic",model.IosIsAllpic),
				new SqlParameter("@IosAllpic",model.IosAllpic),
				new SqlParameter("@Iospicguanfang",model.Iospicguanfang),
				new SqlParameter("@Iospicminjian",model.Iospicminjian),
				new SqlParameter("@type",model.type),
				new SqlParameter("@sort",model.sort),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
                new SqlParameter("@tdisabled",model.tdisabled)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_Type(
			           				text
						 	        ,Anpic
						 	        ,AnIsHomepic
						 	        ,AnHomepic
						 	        ,AnWhitepic
						 	        ,AnOrangepic
						 	        ,AnIsAllpic
						 	        ,AnAllpic
						 	        ,Anpicguanfang
						 	        ,Anpicminjian
						 	        ,Iospic
						 	        ,IosIsHomepic
						 	        ,IosHomepic
						 	        ,IosWhitepic
						 	        ,IosOrangepic
						 	        ,IosIsAllpic
						 	        ,IosAllpic
						 	        ,Iospicguanfang
						 	        ,Iospicminjian
						 	        ,type
						 	        ,sort
						 	        ,createtime
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid,tdisabled
						  ) VALUES(
									@text
									,@Anpic
									,@AnIsHomepic
									,@AnHomepic
									,@AnWhitepic
									,@AnOrangepic
									,@AnIsAllpic
									,@AnAllpic
									,@Anpicguanfang
									,@Anpicminjian
									,@Iospic
									,@IosIsHomepic
									,@IosHomepic
									,@IosWhitepic
									,@IosOrangepic
									,@IosIsAllpic
									,@IosAllpic
									,@Iospicguanfang
									,@Iospicminjian
									,@type
									,@sort
									,@createtime
									,@modifytime
									,@userid
									,@muserid,@tdisabled
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
        public int Delete(int t_id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@t_id",t_id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Type]
     							   WHERE t_id=@t_id");
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
        public int Update(Models.APP.Type model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@t_id",model.t_id),
				new SqlParameter("@text",model.text),
				new SqlParameter("@Anpic",model.Anpic),
				new SqlParameter("@AnIsHomepic",model.AnIsHomepic),
				new SqlParameter("@AnHomepic",model.AnHomepic),
				new SqlParameter("@AnWhitepic",model.AnWhitepic),
				new SqlParameter("@AnOrangepic",model.AnOrangepic),
				new SqlParameter("@AnIsAllpic",model.AnIsAllpic),
				new SqlParameter("@AnAllpic",model.AnAllpic),
				new SqlParameter("@Anpicguanfang",model.Anpicguanfang),
				new SqlParameter("@Anpicminjian",model.Anpicminjian),
				new SqlParameter("@Iospic",model.Iospic),
				new SqlParameter("@IosIsHomepic",model.IosIsHomepic),
				new SqlParameter("@IosHomepic",model.IosHomepic),
				new SqlParameter("@IosWhitepic",model.IosWhitepic),
				new SqlParameter("@IosOrangepic",model.IosOrangepic),
				new SqlParameter("@IosIsAllpic",model.IosIsAllpic),
				new SqlParameter("@IosAllpic",model.IosAllpic),
				new SqlParameter("@Iospicguanfang",model.Iospicguanfang),
				new SqlParameter("@Iospicminjian",model.Iospicminjian),
				new SqlParameter("@type",model.type),
				new SqlParameter("@sort",model.sort),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Type]
								SET [text]=@text
									   ,[Anpic]=@Anpic
							  	   ,[AnIsHomepic]=@AnIsHomepic
							  	   ,[AnHomepic]=@AnHomepic
							  	   ,[AnWhitepic]=@AnWhitepic
							  	   ,[AnOrangepic]=@AnOrangepic
							  	   ,[AnIsAllpic]=@AnIsAllpic
							  	   ,[AnAllpic]=@AnAllpic
							  	   ,[Anpicguanfang]=@Anpicguanfang
							  	   ,[Anpicminjian]=@Anpicminjian
							  	   ,[Iospic]=@Iospic
							  	   ,[IosIsHomepic]=@IosIsHomepic
							  	   ,[IosHomepic]=@IosHomepic
							  	   ,[IosWhitepic]=@IosWhitepic
							  	   ,[IosOrangepic]=@IosOrangepic
							  	   ,[IosIsAllpic]=@IosIsAllpic
							  	   ,[IosAllpic]=@IosAllpic
							  	   ,[Iospicguanfang]=@Iospicguanfang
							  	   ,[Iospicminjian]=@Iospicminjian
							  	   ,[type]=@type
							  	   ,[sort]=@sort
							  	   ,[createtime]=@createtime
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  WHERE [t_id]=@t_id");
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
                    new SqlParameter("@disabled",SqlDbType.Bit) 
                };
                param[0].Value = id;
                param[1].Value = disabled;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE [App_Type] SET tdisabled=@disabled WHERE t_id=@id", param);
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
        public Models.APP.Type GetModelById(int t_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@t_id",t_id),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Type WHERE t_id=@t_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Type>.GetModelByReader(reader);
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
                cmdText.Append(@"SELECT * FROM App_Type");

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
        /// <param name="top">前几条记录0为全部</param>
        /// <param name="typeid">类型id</param>
        /// <returns></returns>
        public DataTable GetTable(int top, int typeid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                if (top == 0)
                    cmdText.Append(@"SELECT * FROM App_Type where tdisabled='True' and type=" + typeid + "  order by sort");
                else
                    cmdText.Append(@"SELECT top " + top + " * FROM App_Type where tdisabled='True' and type=" + typeid + "  order by sort");

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
        /// 根据id组查询数据
        /// </summary>
        /// <param name="tpid">查询id</param>
        /// <returns></returns>
        public DataTable GetTableIn(string mid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();

                cmdText.Append(@"SELECT * FROM App_Type where tdisabled='True' and t_id in(" + mid + ")  order by sort");

                return SqlHelper.ExecuteDataTable(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString());
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetTableIn发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetTableIn发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetTableIn发生Exception", ex);
            }
            return null;
        }

        /// <summary>
        /// 根据id组查询所有id组以外数据
        /// </summary>
        /// <param name="tpid">查询id</param>
        /// <returns></returns>
        public DataTable GetTableNotIn(string tpid, int typeid)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();

                cmdText.Append(@"SELECT * FROM App_Type where tdisabled='True' and type=" + typeid + " and t_id not in(" + tpid + ")  order by sort");

                return SqlHelper.ExecuteDataTable(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString());
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetTableNotIn发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetTableNotIn发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetTableNotIn发生Exception", ex);
            }
            return null;
        }

        /// <summary>
        /// 更新排序值
        /// </summary>
        /// <returns></returns>
        public void UpdateOrderId(DataTable dt)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@OrderData", SqlDbType.Structured) };
                param[0].Value = dt;
                param[0].TypeName = "dbo.OrderTableType";
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE a SET a.sort=b.orderid FROM [App_Type] AS a JOIN @OrderData AS b ON b.id=a.t_id", param);
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
        #endregion


    }
}