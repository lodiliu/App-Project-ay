using ADT.XingZhi.IDAL.S;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADT.XingZhi.DAL.S
{
    public class RoleMenuPurviewCode : IRoleMenuPurviewCode
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public RoleMenuPurviewCode()
		{}
        #region  Method
        /// <summary>
        /// 根据DataTable批量添加(利用表变量类型方式）--SQLServer2008或以上用
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public int BatchSave(DataTable dt, int roleId)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@roleid", SqlDbType.Int), 
                                         new SqlParameter("@data",SqlDbType.Structured),
                                         new SqlParameter("@result",SqlDbType.Int)
                                       };
                param[0].Value = roleId;
                param[1].Value = dt;
                param[1].TypeName = "dbo.PermissionTableType";
                param[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_save_S_ROLE_MENU_PURVIEWCODE", param);
                return Convert.ToInt32(param[2].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法BatchSave(DataTable dt, int roleId)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法BatchSave(DataTable dt, int roleId)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法BatchSave(DataTable dt, int roleId)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 根据角色编号获取权限值列表
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <returns></returns>
        public DataTable GetPurviewCodeListByRoleId(int roleId)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@id", SqlDbType.Int) };
                param[0].Value = roleId;
                return SqlHelper.ExecuteDataTable(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT MPC_CODE FROM [S_ROLE_MENU_PURVIEWCODE] WHERE R_ID=@id", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法DataTable GetPurviewCodeListByRoleId(int roleId)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法DataTable GetPurviewCodeListByRoleId(int roleId)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法DataTable GetPurviewCodeListByRoleId(int roleId)发生Exception", ex);
            }
            return null;
        }
        #endregion  Method
    }
}
