using ADT.CMS.Utility.Db;
using ADT.XingZhi.IDAL.S;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADT.XingZhi.DAL.S
{
    public class LoginTimes : ILoginTimes
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LoginTimes()
		{}
        #region  Method
        /// <summary>
        /// 新增一条数据
        /// </summary>
        public int Add(ADT.XingZhi.Models.S.LoginTimes model)
        {
            try
            {
                SqlParameter[] param = { 
					new SqlParameter("@userName", SqlDbType.VarChar,20),
                    new SqlParameter("@ip",SqlDbType.VarChar,20), 
                    new SqlParameter("@isAdmin",SqlDbType.Bit) };
                param[0].Value = model.UserName;
                param[1].Value = model.IP;
                param[2].Value = model.IsAdmin; 
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "INSERT INTO [S_LOGINTIMES](U_NAME,LT_IP,LT_LOGINTIME,LT_ISADMIN,LT_TIMES) VALUES(@userName,@ip,GETDATE(),@isAdmin,1)", param);
                return Convert.ToInt32(param[6].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.LoginTimes model)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.LoginTimes model)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.LoginTimes model)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(ADT.XingZhi.Models.S.LoginTimes model)
        {
            try
            {
                SqlParameter[] param = { 
					new SqlParameter("@userName", SqlDbType.VarChar,20),
                    new SqlParameter("@ip",SqlDbType.VarChar,20), 
                    new SqlParameter("@isAdmin",SqlDbType.Bit) };
                param[0].Value = model.UserName;
                param[1].Value = model.IP;
                param[2].Value = model.IsAdmin; 
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE [S_LOGINTIMES] SET LT_IP=@ip,LT_LOGINTIME=GETDATE(),LT_TIMES=LT_TIMES+1 WHERE U_NAME=@userName AND LT_ISADMIN=@isAdmin", param); 
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Update(ADT.XingZhi.Models.S.LoginTimes model)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Update(ADT.XingZhi.Models.S.LoginTimes model)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Update(ADT.XingZhi.Models.S.LoginTimes model)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string userName, bool isAdmin)
        {
            try
            {
                SqlParameter[] param = { 
                                           new SqlParameter("@userName", SqlDbType.NVarChar,20),
                                           new SqlParameter("@isAdmin",SqlDbType.Bit)
                                       };
                param[0].Value = userName;
                param[1].Value = isAdmin;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "DELETE FROM [S_LOGINTIMES] WHERE U_NAME=@userName AND LT_ISADMIN=@isAdmin", param);
                return Convert.ToInt32(param[1].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Delete(string userName, bool isAdmin)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Delete(string userName, bool isAdmin)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Delete(string userName, bool isAdmin)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.LoginTimes GetModel(string userName,bool isAdmin)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] param = { 
                                           new SqlParameter("@userName", SqlDbType.NVarChar,20),
                                           new SqlParameter("@isAdmin",SqlDbType.Bit)
                                       };
                param[0].Value = userName;
                param[1].Value = isAdmin;
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT * FROM [S_LOGINTIMES] WHERE U_NAME=@userName AND LT_ISADMIN=@isAdmin", param);
                return Data2Model<ADT.XingZhi.Models.S.LoginTimes>.GetModelByReader(reader);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetModel(string userName,bool isAdmin)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetModel(string userName,bool isAdmin)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetModel(string userName,bool isAdmin)发生Exception", ex);
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
