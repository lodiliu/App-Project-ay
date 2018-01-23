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

    public class Application : IApplication
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Application() { }
        #region  Method
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <returns></returns>
        public int Add(Models.APP.Application model)
        {
            try
            {
                SqlParameter[] para = 
			         {
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@type",model.type),
				new SqlParameter("@state",model.state),
				new SqlParameter("@code",model.code),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@name",model.name),
				new SqlParameter("@phon",model.phon),
				new SqlParameter("@sex",model.sex),
				new SqlParameter("@age",model.age),
				new SqlParameter("@address",model.address),
				new SqlParameter("@professional",model.professional),
				new SqlParameter("@company",model.company),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
				new SqlParameter("@pk_id",model.pk_id),
              	new SqlParameter("@amount",model.amount)
                     };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"INSERT INTO App_Application(
			           				a_id
						 	        ,type
						 	        ,state
						 	        ,code
						 	        ,m_id
						 	        ,name
						 	        ,phon
						 	        ,sex
						 	        ,age
						 	        ,address
						 	        ,professional
						 	        ,company
						 	        ,createtime
						 	        ,modifytime
						 	        ,userid
						 	        ,muserid
						 	        ,pk_id
                                    ,amount
						  ) VALUES(
									@a_id
									,@type
									,@state
									,@code
									,@m_id
									,@name
									,@phon
									,@sex
									,@age
									,@address
									,@professional
									,@company
									,@createtime
									,@modifytime
									,@userid
									,@muserid
									,@pk_id
                                    ,@amount
					);SELECT @@Identity;");

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
        public int Delete(int ap_id)
        {
            try
            {
                SqlParameter[] para = 
			      {new SqlParameter("@ap_id",ap_id)
			       };
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"DELETE FROM [App_Application]
     							   WHERE ap_id=@ap_id");
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
        public int Update(Models.APP.Application model)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@ap_id",model.ap_id),
				new SqlParameter("@a_id",model.a_id),
				new SqlParameter("@type",model.type),
				new SqlParameter("@state",model.state),
				new SqlParameter("@code",model.code),
				new SqlParameter("@m_id",model.m_id),
				new SqlParameter("@name",model.name),
				new SqlParameter("@phon",model.phon),
				new SqlParameter("@sex",model.sex),
				new SqlParameter("@age",model.age),
				new SqlParameter("@address",model.address),
				new SqlParameter("@professional",model.professional),
				new SqlParameter("@company",model.company),
				new SqlParameter("@createtime",model.createtime),
				new SqlParameter("@modifytime",model.modifytime),
				new SqlParameter("@userid",model.userid),
				new SqlParameter("@muserid",model.muserid),
				new SqlParameter("@pk_id",model.pk_id)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Application]
								SET [a_id]=@a_id
									   ,[type]=@type
							  	   ,[state]=@state
							  	   ,[code]=@code
							  	   ,[m_id]=@m_id
							  	   ,[name]=@name
							  	   ,[phon]=@phon
							  	   ,[sex]=@sex
							  	   ,[age]=@age
							  	   ,[address]=@address
							  	   ,[professional]=@professional
							  	   ,[company]=@company
							  	   ,[createtime]=@createtime
							  	   ,[modifytime]=@modifytime
							  	   ,[userid]=@userid
							  	   ,[muserid]=@muserid
							  	   ,[pk_id]=@pk_id
							  WHERE [ap_id]=@ap_id");
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
        /// <param name="apid">id</param>
        ///  <param name="state">状态</param>
        ///   <param name="mtime">修改时间</param>
        ///    <param name="muserid">修改人id</param>
        /// <returns></returns>
        public int Update(int apid, int state, string muserid)
        {
            try
            {
                SqlParameter[] para = 
			          {
				new SqlParameter("@ap_id",apid),				
				new SqlParameter("@state",state),				
				new SqlParameter("@modifytime",DateTime.Now),				
				new SqlParameter("@muserid",muserid)
                      };

                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"UPDATE [App_Application]
								SET [state]=@state							  	  
							  	   ,[modifytime]=@modifytime							  	  
							  	   ,[muserid]=@muserid
							  WHERE [ap_id]=@ap_id");
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, cmdText.ToString(), para);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Update(int apid,int state,DateTime mtime,int muserid)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Update(int apid,int state,DateTime mtime,int muserid)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Update(int apid,int state,DateTime mtime,int muserid)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 获得一个实体根据ID
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Models.APP.Application GetModelById(int ap_id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] para = 
			{
                new SqlParameter("@ap_id",ap_id),
			};

                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, @"SELECT * FROM App_Application WHERE ap_id=@ap_id", para);
                return ADT.CMS.Utility.Db.Data2Model<Models.APP.Application>.GetModelByReader(reader);
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
                cmdText.Append(@"SELECT * FROM App_Application");

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
        /// 根据活动id查询报名数据
        /// </summary>
        /// <param name="top">前几条(0为全部)</param>
        /// <param name="aid">活动id</param>
        /// <param name="type">类型（0、活动1、培训2、约吧）</param>
        /// <returns></returns>
        public DataTable GetTableTOP(int top, int aid, int type)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                if (top == 0)
                    cmdText.Append(@"SELECT App_Application.* ,username,pic FROM App_Application left join App_Member on App_Member.m_id=App_Application.m_id where state in ('1','-1') and a_id=" + aid + " and App_Application.type=" + type + " order by createtime desc");
                else
                    cmdText.Append(@"SELECT top " + top + " App_Application.* ,username,pic FROM App_Application left join App_Member on App_Member.m_id=App_Application.m_id where state in ('1','-1') and a_id=" + aid + " and App_Application.type=" + type + " order by createtime desc");


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
        /// 根据活动id，报名id查询数据
        /// </summary>
        /// <param name="mid">报名id</param>
        /// <param name="aid">活动id</param>
        /// <param name="type">类型（0、活动1、培训2、约吧）</param>
        /// <returns></returns>
        public DataTable GetTable(int mid, int aid, int type)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                if (type == 0)
                    cmdText.Append(@"SELECT * FROM App_Application where m_id=" + mid + " and a_id=" + aid + " and type in('0','1')  order by createtime desc");
                else
                    cmdText.Append(@"SELECT * FROM App_Application where m_id=" + mid + " and a_id=" + aid + " and type=" + type + "  order by createtime desc");

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
        /// 根据报名id查询数据
        /// </summary>
        /// <param name="mid">报名id</param>
        /// <param name="id">0参加1取消2全部</param>
        /// <param name="type">类型（-1所有取消的活动（赛事/培训）,0、赛事1、培训2、约吧）</param>
        /// <returns></returns>
        public DataTable GetTableCancel(int mid, int id, int type, int page, int row, out int recordCount)
        {
            recordCount = 0;

            try
            {
           
                StringBuilder where = new StringBuilder();
                //  where.AppendFormat(" m_id ={0}  and isactivaty={1}", mids, type);

                StringBuilder order = new StringBuilder();
                order.AppendFormat(" order by App_Application.createtime desc");

                StringBuilder cmdText = new StringBuilder();
                StringBuilder cmdtable = new StringBuilder();
                if (type == 2)
                {
                    cmdtable.Append("App_Application left join View_About on App_Application.a_id=View_About.ab_id");
                    cmdText.Append("ap_id,ab_id,pic,AnOrangepic,IosOrangepic,title,View_About.address,number,View_About.sex,numberlimit,movement,begintime,specifictime");
                    where.Append("App_Application.m_id=" + mid + " and App_Application.state not in('-1') and App_Application.type=" + type + "  ");
                }
                else
                {
                    cmdtable.Append(" App_Application left join View_Activaty on App_Application.a_id=View_Activaty.a_id");
                    cmdText.Append("ap_id,View_Activaty.a_id,pic,App_Application.state,AnOrangepic,IosOrangepic,title,View_Activaty.address,movement,praise,eventname,isactivaty,App_Application.modifytime");
                    if (type == -1)
                    {
                        where.Append("App_Application.m_id=" + mid + " and App_Application.state  in('2','3','4','5')   and App_Application.type in('0','1') ");
                    }
                    else
                    {
                        if (id == 0)
                            where.Append("App_Application.m_id=" + mid + " and App_Application.state=1  and App_Application.type=" + type + "  ");
                        else if (id == 1)
                            where.Append("App_Application.m_id=" + mid + " and App_Application.state in('2','3','4','5') and App_Application.type=" + type + " ");
                        else
                            where.Append("App_Application.m_id=" + mid + " and App_Application.state not in('-1','0') and App_Application.type=" + type + "  ");
                    }
                }


                return SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, cmdText.ToString(), cmdtable.ToString(), where.ToString(), order.ToString(), page, row, out recordCount);


            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetTableCancel发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetTableCancel发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetTableCancel发生Exception", ex);
            }
            return null;
        }
        #endregion


    }
}