using ADT.XingZhi.IDAL.S;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADT.XingZhi.DAL.S
{
    public class Menu:IMenu
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Menu()
		{}
        #region  Method
        /// <summary>
        /// 新增一条数据
        /// </summary>
        public int Add(ADT.XingZhi.Models.S.Menu model)
        {
            try
            {
                SqlParameter[] param = { 
					new SqlParameter("@pid", SqlDbType.Int),  
					new SqlParameter("@name", SqlDbType.NVarChar,50),
                    new SqlParameter("@code",SqlDbType.VarChar,10),
					new SqlParameter("@icon", SqlDbType.NVarChar,200),
					new SqlParameter("@link", SqlDbType.NVarChar,200),
                    new SqlParameter("@disabled",SqlDbType.Bit),
					new SqlParameter("@result",SqlDbType.Int) };
                param[0].Value = model.ParentId; 
                param[1].Value = model.Name;
                param[2].Value = model.Code;
                param[3].Value = model.Icon;
                param[4].Value = model.Link;
                param[5].Value = model.Disabled;
                param[6].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_add_S_Menu", param);
                return Convert.ToInt32(param[6].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.Menu model)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.Menu model)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.Menu model)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public int Modify(ADT.XingZhi.Models.S.Menu model)
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@id", SqlDbType.Int),
					new SqlParameter("@pid", SqlDbType.Int), 
					new SqlParameter("@name", SqlDbType.NVarChar,50),
                    new SqlParameter("@code",SqlDbType.VarChar,10),
					new SqlParameter("@icon", SqlDbType.NVarChar,200),
					new SqlParameter("@link", SqlDbType.NVarChar,200),
                    new SqlParameter("@disabled",SqlDbType.Bit),
					new SqlParameter("@result",SqlDbType.Int) };
                param[0].Value = model.Id;
                param[1].Value = model.ParentId; 
                param[2].Value = model.Name;
                param[3].Value = model.Code;
                param[4].Value = model.Icon;
                param[5].Value = model.Link;
                param[6].Value = model.Disabled;
                param[7].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_modify_S_Menu", param);
                return Convert.ToInt32(param[7].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Modify(ADT.XingZhi.Models.S.Menu model)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Modify(ADT.XingZhi.Models.S.Menu model)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Modify(ADT.XingZhi.Models.S.Menu model)发生Exception", ex);
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
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "UPDATE [S_MENU] SET M_DISABLED=@disabled WHERE M_ID=@id", param);  
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
        public ADT.XingZhi.Models.S.Menu GetModelById(int id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] param = { new SqlParameter("@id", SqlDbType.Int) };
                param[0].Value = id;
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT * FROM [S_MENU] WHERE M_ID=@id", param);
                return ADT.CMS.Utility.Db.Data2Model<ADT.XingZhi.Models.S.Menu>.GetModelByReader(reader);
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
        /// 改变一条数据排序
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="sortType">排序类型</param>
        /// <returns></returns>
        public int ChangeSort(int id, SortType sortType)
        {
            try
            {
                SqlParameter[] param = {
					new SqlParameter("@id", SqlDbType.Int),
                    new SqlParameter("@sortType",SqlDbType.Int),
                    new SqlParameter("@result",SqlDbType.Int)
                };
                param[0].Value = id;
                param[1].Value = (Int32)sortType;
                param[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.StoredProcedure, "sp_change_S_Menu_Sort", param);
                return Convert.ToInt32(param[2].Value);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法ChangeSort(int id, SortType sortType)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法ChangeSort(int id, SortType sortType)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法ChangeSort(int id, SortType sortType)发生Exception", ex);
            }
            return -1;
        }
        #endregion  Method
    }
}
