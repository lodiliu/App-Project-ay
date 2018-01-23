using ADT.XingZhi.IDAL.S;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADT.XingZhi.DAL.S
{
    public class Log:ILog
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Log()
        { }
        #region  Method
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public int Add(Models.S.Log model)
        {
            try
            {
                SqlParameter[] param = {
					new SqlParameter("@action", SqlDbType.VarChar,20),
                    new SqlParameter("@link",SqlDbType.NVarChar,255),
                    new SqlParameter("@method",SqlDbType.VarChar,20),
                    new SqlParameter("@data",SqlDbType.NText),
                    new SqlParameter("@userid",SqlDbType.Int),
                    new SqlParameter("@username",SqlDbType.VarChar,20),
                    new SqlParameter("@ip",SqlDbType.VarChar,20),
                    new SqlParameter("@time",SqlDbType.DateTime)
                };
                param[0].Value = model.Action;
                param[1].Value = model.Link;
                param[2].Value = model.Method;
                param[3].Value = model.Data;
                param[4].Value = model.UserId;
                param[5].Value = model.UserName;
                param[6].Value = model.IP;
                param[7].Value = model.Time;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "INSERT INTO S_LOG(L_ACTION,L_LINK,L_METHOD,L_DATA,U_ID,U_NAME,L_IP,L_TIME) VALUES(@action,@link,@method,@data,@userid,@username,@ip,@time)", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Add(Models.S.Log model)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Add(Models.S.Log model)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Add(Models.S.Log model)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int DeleteById(int id)
        {
            try
            {
                SqlParameter[] param = {
					new SqlParameter("@id", SqlDbType.Int)};
                param[0].Value = id;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "DELETE [S_LOG] WHERE L_ID=@id", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法DeleteById(int id)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法DeleteById(int id)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法DeleteById(int id)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 批量删除（以英文","隔开)
        /// </summary>
        /// <param name="ids">编号组</param>
        public int BatchDelete(string ids)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@ids", SqlDbType.VarChar, 8000) };
                param[0].Value = ids;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "DELETE FROM a FROM [S_LOG] a JOIN dbo.fn_SplitStr(@ids,',') b ON b.column1=a.L_ID", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法BatchDelete(string ids)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法BatchDelete(string ids)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法BatchDelete(string ids)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.Log GetModelById(int id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@id", SqlDbType.Int) };
                param[0].Value = id;
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT * FROM [S_LOG] WHERE L_ID=@id", param);
                return ADT.CMS.Utility.Db.Data2Model<ADT.XingZhi.Models.S.Log>.GetModelByReader(reader);
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
        #endregion  Method
    }
}
