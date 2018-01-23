using ADT.XingZhi.IDAL.S;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADT.XingZhi.DAL.S
{
    public class User : IUser
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public User()
        { }
        #region  Method
        /// <summary>
        /// 新增一条数据
        /// </summary>
        /// <param name="model">ADT.XingZhi.Models.S.User</param>
        /// <param name="userRoleDT">用户角色信息DataTable</param>
        public int Add(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)
        {
            try
            {
                SqlParameter[] param = { 
					new SqlParameter("@name", SqlDbType.NVarChar,20),
					new SqlParameter("@pwd", SqlDbType.VarChar,32),
                    new SqlParameter("@encrypt",SqlDbType.VarChar,6), 
					new SqlParameter("@realName", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,50),
                    new SqlParameter("@mobile", SqlDbType.VarChar,50), 
                    new SqlParameter("@tel",SqlDbType.VarChar,50),
                    new SqlParameter("@disabled",SqlDbType.Bit),
                    new SqlParameter("@userRole",SqlDbType.Structured),
					new SqlParameter("@result", SqlDbType.Int) };
                param[0].Value = model.Name;
                param[1].Value = model.Pwd;
                param[2].Value = model.Encrypt;
                param[3].Value = model.RealName;
                param[4].Value = model.Email;
                param[5].Value = model.Mobile;
                param[6].Value = model.Tel;
                param[7].Value = model.Disabled;
                param[8].Value = userRoleDT;
                param[8].TypeName = "dbo.RoleUserTableType";
                param[9].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_add_S_USER", param);
                return Convert.ToInt32(param[9].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="model">ADT.XingZhi.Models.S.User</param>
        /// <param name="userRoleDT">用户角色信息DataTable</param>
        public int Modify(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@id", SqlDbType.Int), 
					new SqlParameter("@pwd", SqlDbType.VarChar,32),
                    new SqlParameter("@encrypt",SqlDbType.VarChar,6),
                    new SqlParameter("@realName", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,50),
                    new SqlParameter("@mobile", SqlDbType.VarChar,50), 
                    new SqlParameter("@tel",SqlDbType.VarChar,50),
                    new SqlParameter("@disabled",SqlDbType.Bit), 
                    new SqlParameter("@userRole",SqlDbType.Structured),
					new SqlParameter("@result", SqlDbType.Int) };
                param[0].Value = model.Id;
                param[1].Value = model.Pwd;
                param[2].Value = model.Encrypt;
                param[3].Value = model.RealName;
                param[4].Value = model.Email;
                param[5].Value = model.Mobile;
                param[6].Value = model.Tel;
                param[7].Value = model.Disabled;
                param[8].Value = userRoleDT;
                param[8].TypeName = "dbo.RoleUserTableType";
                param[9].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_modify_S_USER", param);
                return Convert.ToInt32(param[9].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Modify(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Modify(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Modify(ADT.XingZhi.Models.S.User model, DataTable userRoleDT)发生Exception", ex);
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
                    new SqlParameter("@disabled", SqlDbType.Bit)                   
                };
                param[0].Value = id;
                param[1].Value = disabled;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE [S_USER] SET U_DISABLED=@disabled WHERE U_ID=@id", param); 
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
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.User GetModelById(int id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@id", SqlDbType.Int) };
                param[0].Value = id;
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT * FROM [S_USER] WHERE U_ID=@id", param);
                return ADT.CMS.Utility.Db.Data2Model<ADT.XingZhi.Models.S.User>.GetModelByReader(reader);
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
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username">用户名(也可以为姓名）</param>
        /// <returns></returns>
        public ADT.XingZhi.Models.S.User GetModelByUserName(string username)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@name", SqlDbType.NVarChar, 50) };
                param[0].Value = username;
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT * FROM [S_USER] WHERE U_NAME=@name", param);
                return Data2Model<ADT.XingZhi.Models.S.User>.GetModelByReader(reader);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetModelByUserName(string username)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetModelByUserName(string username)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetModelByUserName(string username)发生Exception", ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return null;
        }
        /// <summary>
        /// 根据登录情况更新登录用户信息
        /// </summary>
        public int UpdateByLogin(int id, string ip)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@id", SqlDbType.Int),
					new SqlParameter("@lastLoginIP", SqlDbType.NVarChar,50) };
                param[0].Value = id;
                param[1].Value = ip;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE [S_USER] SET U_PREVLOGINTIME=U_LASTLOGINTIME,U_PREVLOGINIP=U_LASTLOGINIP,U_LASTLOGINTIME=GETDATE(),U_LASTLOGINIP=@lastLoginIP,U_LOGINTIMES=U_LOGINTIMES+1,U_UPDATETIME=GETDATE() WHERE U_ID=@id", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法UpdateByLogin(int id, string ip)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法UpdateByLogin(int id, string ip)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法UpdateByLogin(int id, string ip)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 修改档案
        /// </summary>
        /// <param name="model">Model</param>
        /// <returns></returns>
        public int ModifyInfo(Models.S.User model)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@id", SqlDbType.Int), 
                    new SqlParameter("@realName", SqlDbType.NVarChar,20),
					new SqlParameter("@email", SqlDbType.VarChar,50),
                    new SqlParameter("@mobile", SqlDbType.VarChar,50), 
                    new SqlParameter("@tel",SqlDbType.VarChar,50) };
                param[0].Value = model.Id;
                param[1].Value = model.RealName;
                param[2].Value = model.Email;
                param[3].Value = model.Mobile;
                param[4].Value = model.Tel;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE [S_USER] SET U_REALNAME=@realName,U_EMAIL=@email,U_MOBILE=@mobile,U_TEL=@tel,U_UPDATETIME=GETDATE() WHERE U_ID=@id", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法ModifyInfo(Models.S.User model)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法ModifyInfo(Models.S.User model)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法ModifyInfo(Models.S.User model)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">用户编号</param> 
        /// <param name="pwd">新密码</param>
        /// <param name="encrypt">安全密钥</param>
        /// <returns></returns>
        public int ModifyPwd(int id, string pwd, string encrypt)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@id", SqlDbType.Int), 
                    new SqlParameter("@pwd", SqlDbType.VarChar,32),
                    new SqlParameter("@encrypt",SqlDbType.VarChar,6) 
                };
                param[0].Value = id; 
                param[1].Value = pwd;
                param[2].Value = encrypt;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE [S_USER] SET U_PWD=@pwd,U_ENCRYPT=@encrypt,U_UPDATETIME=GETDATE(),U_LASTMODIFYPASSWORDTIME=GETDATE() WHERE U_ID=@id", param); 
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法ModifyPwd(int id, string pwd, string encrypt)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法ModifyPwd(int id, string pwd, string encrypt)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法ModifyPwd(int id, string pwd, string encrypt)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 根据用户编号获取权限值列表
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public DataTable GetPermissionByUserId(int userId)
        {
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@id",SqlDbType.Int)
                                     };
                param[0].Value = userId;
                return SqlHelper.ExecuteDataTable(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT DISTINCT MPC_CODE FROM [S_ROLE_MENU_PURVIEWCODE] rmp JOIN [S_ROLE_USER] ru ON ru.R_ID = rmp.R_ID AND ru.U_ID=@id", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetPermissionByUserId(int userId)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetPermissionByUserId(int userId)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetPermissionByUserId(int userId)发生Exception", ex);
            }
            return null;
        }
        /// <summary>
        /// 根据用户编号获取角色信息
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public string GetRoleByUserId(int userId)
        {
            try
            {
                SqlParameter[] param ={
                                          new SqlParameter("@id",SqlDbType.Int)
                                     };
                param[0].Value = userId;
                object result = SqlHelper.ExecuteScalar(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT CONVERT(varchar,R_ID)+',' FROM [S_ROLE_USER] WHERE U_ID=@id FOR XML PATH('')", param);
                if (result != null && !Convert.IsDBNull(result))
                {
                    return result.ToString();
                }
                return String.Empty;
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetRoleByUserId(int userId)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetRoleByUserId(int userId)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetRoleByUserId(int userId)发生Exception", ex);
            }
            return String.Empty;
        }



        /// <summary>
        ///  根据用户名查询除去本身数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetTable(string user)
        {
            try
            {
                StringBuilder cmdText = new StringBuilder();
                cmdText.Append(@"SELECT * FROM S_USER where  U_NAME not in('"+user+"')");

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
        #endregion  Method
    }
}
