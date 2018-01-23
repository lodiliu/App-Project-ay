using ADT.XingZhi.IDAL.S;
using ADT.CMS.Utility.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ADT.XingZhi.DAL.S
{
    public class Config : IConfig
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Config()
		{}
        #region  Method

        /// <summary>
        /// 根据表添加数据
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="groupId">组编号</param>
        public int BatchSave(DataTable dt, int groupId)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@dt",SqlDbType.Structured),
                    new SqlParameter("@groupid", SqlDbType.Int),
                    new SqlParameter("@result",SqlDbType.Int)
                };
                param[0].Value = dt;
                param[0].TypeName = "dbo.ConfigTableType";
                param[1].Value = groupId;
                param[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_save_S_CONFIG", param);
                return Convert.ToInt32(param[2].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法BatchSave(DataTable dt, int groupId)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法BatchSave(DataTable dt, int groupId)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法BatchSave(DataTable dt, int groupId)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 根据组编号获取配置信息
        /// </summary>
        /// <param name="groupId">类型名称,若需要获取所有的，则groupId=0</param>
        /// <returns></returns>
        public Dictionary<string, string> GetConfigByGroupId(int groupId)
        {
            SqlDataReader reader = null;
            try
            {
                if (groupId == 0)
                {
                    reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT * FROM [S_CONFIG]");
                }
                else
                {
                    SqlParameter[] parame = { new SqlParameter("@groupid", SqlDbType.Int) };
                    parame[0].Value = groupId;
                    reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT * FROM [S_CONFIG] WHERE C_GROUPID=@groupid", parame);
                }
                if (reader.HasRows)
                {
                    Dictionary<string, string> settings = new Dictionary<string, string>();
                    while (reader.Read())
                        settings.Add(reader["C_KEY"].ToString(), Convert.IsDBNull(reader["C_VALUES"]) ? String.Empty : reader["C_VALUES"].ToString());
                    return settings;
                }
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetConfigByGroupId(int groupId)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetConfigByGroupId(int groupId)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetConfigByGroupId(int groupId)发生Exception", ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return null;
        }
        /// <summary>
        /// 根据键名和组名获取键值
        /// </summary>
        /// <param name="keyName">键名</param>
        /// <param name="groupId">组名编号</param>
        /// <returns></returns>
        public string GetValuesByKeyAndGroupId(string keyName, int groupId)
        {
            try
            {
                SqlParameter[] parame = { 
                    new SqlParameter("@key", SqlDbType.VarChar, 50),
                    new SqlParameter("@groupid", SqlDbType.Int) 
                };
                parame[0].Value = keyName;
                parame[1].Value = groupId;
                object obj = SqlHelper.ExecuteScalar(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT C_VALUES FROM [S_CONFIG] WHERE C_GROUPID=@groupid and C_KEY=@key", parame);
                if (obj != null && !Convert.IsDBNull(obj))
                {
                    return obj.ToString();
                }
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetValuesByKeyAndGroupId(string keyName, int groupId)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetValuesByKeyAndGroupId(string keyName, int groupId)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetValuesByKeyAndGroupId(string keyName, int groupId)发生Exception", ex);
            }
            return String.Empty;
        }

        #endregion  Method
	}
}
