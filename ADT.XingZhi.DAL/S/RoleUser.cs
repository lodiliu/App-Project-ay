using ADT.XingZhi.IDAL.S;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADT.XingZhi.DAL.S
{
    public class RoleUser:IRoleUser
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public RoleUser()
		{}
        /// <summary>
        /// 根据DataTable批量添加角色用户(利用表变量类型结合方式）--SQLServer2008或以上用
        /// </summary>
        /// <param name="dt">DataTable</param>
        public int BatchSave(DataTable dt)
        {
            try
            {
                SqlParameter[] param = {
                                         new SqlParameter("@data",SqlDbType.Structured)
                                       };
                param[0].Value = dt;
                param[0].TypeName = "dbo.RoleUserTableType";
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "INSERT INTO S_ROLE_USER(R_ID,U_ID) SELECT d.roleid,d.userid FROM @data AS d", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法BatchSave(DataTable dt)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法BatchSave(DataTable dt)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法BatchSave(DataTable dt)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 根据角色编号和用户编号删除一条数据
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public int Delete(int roleId, int userId)
        {
            try
            {
                SqlParameter[] param = {
					new SqlParameter("@roleId", SqlDbType.Int),
                    new SqlParameter("@userId", SqlDbType.Int)                 
                };
                param[0].Value = roleId;
                param[1].Value = userId;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "DELETE [S_ROLE_USER] WHERE R_ID=@roleId AND U_ID=@userId", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Delete(int roleId,int userId)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Delete(int roleId,int userId)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Delete(int roleId,int userId)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 根据角色编号和用户编号组批量删除（以英文","隔开)
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="userId">用户编号组</param>
        public int BatchDelete(int roleId, string ids)
        {
            try
            {
                SqlParameter[] param = { 
                                           new SqlParameter("@roleId", SqlDbType.Int),
                                           new SqlParameter("@ids", SqlDbType.VarChar, 8000) 
                                       };
                param[0].Value = roleId;
                param[1].Value = ids;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "DELETE FROM a FROM [S_ROLE_USER] a JOIN dbo.fn_SplitStr(@ids,',') b ON b.column1=a.U_ID WHERE R_ID=@roleId", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法BatchDelete(int roleId, string ids)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法BatchDelete(int roleId, string ids)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法BatchDelete(int roleId, string ids)发生Exception", ex);
            }
            return -1;
        }
    }
}
