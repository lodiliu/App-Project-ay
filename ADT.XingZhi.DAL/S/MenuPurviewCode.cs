using ADT.XingZhi.IDAL.S;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADT.XingZhi.DAL.S
{
    public class MenuPurviewCode:IMenuPurviewCode
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MenuPurviewCode()
		{}
        #region  Method

        /// <summary>
        /// 保存一条数据
        /// </summary>
        public int Save(ADT.XingZhi.Models.S.MenuPurviewCode model)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@id",SqlDbType.Int),
					new SqlParameter("@menuid", SqlDbType.Int),
					new SqlParameter("@name", SqlDbType.VarChar,50),
					new SqlParameter("@code", SqlDbType.VarChar,20),
                    new SqlParameter("@disabled",SqlDbType.Bit),
                    new SqlParameter("@result",SqlDbType.Int) };
                param[0].Value = model.Id;
                param[1].Value = model.MenuId;
                param[2].Value = model.Name;
                param[3].Value = model.Code;
                param[4].Value = model.Disabled;
                param[5].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_save_S_MENU_PURVIEWCODE", param);
                return Convert.ToInt32(param[5].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Save(ADT.XingZhi.Models.S.MenuPurviewCode model)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Save(ADT.XingZhi.Models.S.MenuPurviewCode model)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Save(ADT.XingZhi.Models.S.MenuPurviewCode model)发生Exception", ex);
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
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE S_MENU_PURVIEWCODE SET MPC_DISABLED=@disabled WHERE MPC_ID=@id", param); 
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
        public ADT.XingZhi.Models.S.MenuPurviewCode GetModelById(int id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@id", SqlDbType.Int) };
                param[0].Value = id;
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "select * from [S_MENU_PURVIEWCODE] where MPC_ID=@id", param);
                return ADT.CMS.Utility.Db.Data2Model<ADT.XingZhi.Models.S.MenuPurviewCode>.GetModelByReader(reader);
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
