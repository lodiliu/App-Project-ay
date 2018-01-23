using ADT.XingZhi.IDAL.S;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADT.XingZhi.DAL.S
{
    public class Role :IRole
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Role()
        { }
        #region  Method

        /// <summary>
        /// 保存一条数据
        /// </summary>
        public int Save(ADT.XingZhi.Models.S.Role model)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@id", SqlDbType.Int),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@desc", SqlDbType.NVarChar,255),
                    new SqlParameter("@orderid", SqlDbType.Int),
					new SqlParameter("@result", SqlDbType.Int)};
                param[0].Value = model.Id;
                param[1].Value = model.Name;
                param[2].Value = model.Desc;
                param[3].Value = model.OrderId;
                param[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_save_S_ROLE", param);
                return Convert.ToInt32(param[4].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Save(ADT.XingZhi.Models.S.Role model)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Save(ADT.XingZhi.Models.S.Role model)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Save(ADT.XingZhi.Models.S.Role model)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteById(int id)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@id", SqlDbType.Int),
                                   new SqlParameter("@result",SqlDbType.Int) };
                param[0].Value = id;
                param[1].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_delete_S_ROLE", param);
                return Convert.ToInt32(param[1].Value);
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
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.Role GetModelById(int id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@id", SqlDbType.Int) };
                param[0].Value = id;
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT * FROM [S_ROLE] WHERE R_ID=@id", param);
                return ADT.CMS.Utility.Db.Data2Model<ADT.XingZhi.Models.S.Role>.GetModelByReader(reader);
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
        /// 获取最大排序编号
        /// </summary>
        /// <returns></returns>
        public int GetMaxOrderId()
        {
            try
            {
                object orderId = SqlHelper.ExecuteScalar(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT MAX(R_ORDERID) FROM [S_ROLE]");
                if (orderId != null && !Convert.IsDBNull(orderId))
                {
                    return Convert.ToInt32(orderId) + 1;
                }
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetMaxOrderId()发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetMaxOrderId()发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetMaxOrderId()发生Exception", ex);
            }
            return 0;
        }
        /// <summary>
        /// 更新排序值
        /// </summary>
        /// <returns></returns>
        public void UpdateOrderId(DataTable dt)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@OrderData",SqlDbType.Structured) };
                param[0].Value = dt;
                param[0].TypeName = "dbo.OrderTableType";
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE a SET a.R_ORDERID=b.orderid FROM [S_ROLE] AS a JOIN @OrderData AS b ON b.id=a.R_ID", param);
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
        #endregion  Method
    }
}
