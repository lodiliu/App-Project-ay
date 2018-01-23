using ADT.XingZhi.IDAL.S;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADT.XingZhi.DAL.S
{
    public class File : IFile
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Method
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ADT.XingZhi.Models.S.File model)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("INSERT INTO [S_FILE] (");
                strSql.Append("F_ID,F_PATH,F_TITLE,F_EXT,F_SIZE,F_OBJECTTYPE,F_CREATEBY,F_CREATETIME,F_IP,F_EXTRA)");
                strSql.Append(" VALUES (");
                strSql.Append("@id,@path,@title,@ext,@size,@objectType,@createby,@createtime,@ip,@extra)");
                SqlParameter[] param = {
					new SqlParameter("@id", SqlDbType.VarChar,36),
					new SqlParameter("@path", SqlDbType.VarChar,100),
                    new SqlParameter("@title", SqlDbType.NVarChar,100),
                    new SqlParameter("@extension", SqlDbType.VarChar,10),
                    new SqlParameter("@size", SqlDbType.BigInt),
                    new SqlParameter("@objectType", SqlDbType.VarChar,30),
                    new SqlParameter("@createby", SqlDbType.NVarChar,30),
                    new SqlParameter("@createtime", SqlDbType.DateTime),
                    new SqlParameter("@ip", SqlDbType.VarChar,30),
                    new SqlParameter("@extra", SqlDbType.VarChar,255)
                };
                param[0].Value = model.Id;
                param[1].Value = model.Path;
                param[2].Value = model.Title;
                param[3].Value = model.Ext;
                param[4].Value = model.Size;
                param[5].Value = model.ObjectType;
                param[6].Value = model.CreateBy;
                param[7].Value = model.CreateTime;
                param[8].Value = model.IP;
                param[9].Value = model.Extra;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, strSql.ToString(), param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.File model)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.File model)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法Add(ADT.XingZhi.Models.S.File model)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.File GetModelById(string id)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter[] param = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
                param[0].Value = id;
                reader = SqlHelper.ExecuteReader(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT * FROM [S_FILE] WHERE f_id=@id", param);
                return Data2Model<ADT.XingZhi.Models.S.File>.GetModelByReader(reader);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetModelById(string id)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetModelById(string id)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetModelById(string id)发生Exception", ex);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return null;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int DeleteById(string id)
        {
            try
            {
                SqlParameter[] param = {
					new SqlParameter("@id", SqlDbType.VarChar,36)};
                param[0].Value = id;
                return SqlHelper.ExecuteNonQuery(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "DELETE [S_FILE] WHERE F_ID=@id", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法DeleteById(string id)发生ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法DeleteById(string id)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法DeleteById(string id)发生Exception", ex);
            }
            return -1;
        }
        /// <summary>
        /// 根据附件编号组获取对应所有的附件信息
        /// </summary>
        /// <param name="attachmentIds">附件编号组</param>
        /// <returns></returns>
        public DataTable GetListByAttachmentIds(string ids)
        {
            try
            {
                SqlParameter[] param = {
					new SqlParameter("@ids", SqlDbType.VarChar,8000)};
                param[0].Value = ids;
                return SqlHelper.ExecuteDataTable(DefaultConnection.ConnectionStringByDefaultDB, CommandType.Text, "SELECT a.* FROM [S_FILE] a JOIN dbo.fn_SplitStr(@ids,',') b ON a.F_ID=b.column1", param);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("调用方法GetListByAttachmentIds(string ids:ArgumentNullException", ex);
            }
            catch (SqlException ex)
            {
                logger.Error("调用方法GetListByAttachmentIds(string ids)发生SqlException", ex);
            }
            catch (Exception ex)
            {
                logger.Error("调用方法GetListByAttachmentIds(string ids)发生Exception", ex);
            }
            return null;
        }
        #endregion
    }
}
