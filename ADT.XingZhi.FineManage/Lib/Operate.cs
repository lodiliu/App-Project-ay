using ADT.XingZhi.API.library;
using ADT.XingZhi.Models.X;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;

namespace ADT.XingZhi.FineManage.Lib
{
    public class Operate
    {
        DbHelper db = new DbHelper();

        /// <summary>
        /// 获取全部的明星
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPerson()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select personid,CName from xz_export_person order by CName asc");
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            DataTable dt = db.ExecuteDataTable(cmd);
            return dt;
        }

        #region 推送消息
        /// <summary>
        /// 新增一条推送消息
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="context">正文</param>
        /// <param name="userid">用户名称</param>
        public int InsertMessage(string title, string context, string userid)
        {
            StringBuilder sb = new StringBuilder();
            DbCommand cmd = db.GetStoredProcCommond("user_insert_Message");
            db.AddInParameter(cmd, "@title", DbType.String, title);
            db.AddInParameter(cmd, "@context", DbType.String, context);
            db.AddInParameter(cmd, "@userid", DbType.String, userid);
            int a = Convert.ToInt16(db.ExecuteDataTable(cmd).Rows[0][0].ToString());
            return a;
        }

        /// <summary>
        /// 获取一条消息
        /// </summary>
        /// <param name="id">消息ID</param>
        /// <returns></returns>
        public DataTable GetMessageByID(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from S_Message where ID={0}", id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            DataTable dt = db.ExecuteDataTable(cmd);
            return dt;
        }

        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="id">消息ID</param>
        /// <returns></returns>
        public int DeleteMessageByID(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" delete from S_Message where ID={0} delete from TB_ReadMessage where Message_ID='{0}' ", id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            int dt = db.ExecuteNonQuery(cmd);
            return dt;
        }
        #endregion

        #region 反馈
        /// <summary>
        /// 获取一条反馈
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetOpinionByID(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from TB_Opinion where ID={0}", id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            DataTable dt = db.ExecuteDataTable(cmd);
            return dt;
        }

        /// <summary>
        /// 删除反馈
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteOpinionByID(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" delete from TB_Opinion where ID={0}", id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            int dt = db.ExecuteNonQuery(cmd);
            return dt;
        }
        #endregion

        #region 潜力作品
        /// <summary>
        /// 插入潜力作品表数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int InsertPotential(Potential model)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("INSERT INTO [db_xingzhi].[dbo].[TB_Potential] ([PersonID],[PersonName],[WorkName],[WorkType],[dy],[zy],[WorkInfo],[Release],[ImgPath],[CreatedTime])VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", model._PersonID, model._PersonName, model._WorkName, model._WorkType, model._dy, model._zy, model._WorkInfo, model._Release, model._ImgPath, model._CreatedTime);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            int a = db.ExecuteNonQuery(cmd);
            return a;
        }

        /// <summary>
        /// 获取一条潜力作品数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public DataTable GetPotentialByID(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@" select ID,PersonID,PersonName,WorkName,WorkType,dy,zy,WorkInfo,convert(nvarchar(10),Release,120) as Release,ImgPath,CreatedTime from TB_Potential where ID=" + id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            DataTable dt = db.ExecuteDataTable(cmd);
            return dt;
        }

        /// <summary>
        /// 修改一条潜力作品数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public int UpdatePotentialByID(Potential model, int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"update TB_Potential set PersonID='{0}',PersonName='{1}',WorkName='{2}',WorkType='{3}',dy='{4}',zy='{5}',
WorkInfo='{6}',Release='{7}',ImgPath='{8}',CreatedTime='{9}'where ID={10}", model._PersonID, model._PersonName, model._WorkName, model._WorkType, model._dy, model._zy, model._WorkInfo, model._Release, model._ImgPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            int a = db.ExecuteNonQuery(cmd);
            return a;
        }

        /// <summary>
        /// 删除潜力作品
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public int DeletePotentialByID(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" delete from TB_Potential where ID={0}", id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            int dt = db.ExecuteNonQuery(cmd);
            return dt;
        }
        #endregion

        #region 页面权限
        /// <summary>
        /// 获取一条页面权限数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetPageRoleByID(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@" SELECT [ID],[PageCode],[CodeName],[Flag] FROM [dbo].[MS_Page] where ID=" + id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            DataTable dt = db.ExecuteDataTable(cmd);
            return dt;
        }

        /// <summary>
        /// 插入页面权限数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public int InsertPageRole(PageRole model)
        {
            int flag = 0;
            StringBuilder sbtemp = new StringBuilder();
            sbtemp.AppendFormat("select * from MS_Page where PageCode='{0}'", model._PageCode);
            DbCommand cmdtemp = db.GetSqlStringCommond(sbtemp.ToString());
            DataTable dt = db.ExecuteDataTable(cmdtemp);
            if (dt.Rows.Count > 0)
            {
                flag = 100;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("insert into MS_Page(PageCode,CodeName,Flag)values('{0}','{1}','{2}')", model._PageCode, model._CodeName, model._Flag);
                DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
                flag = db.ExecuteNonQuery(cmd);
            }
            return flag;
        }
        /// <summary>
        /// 修改页面权限数据
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public int UpdatePageRole(PageRole model, int id)
        {
            int flag = 0;
            StringBuilder sbtemp = new StringBuilder();
            sbtemp.AppendFormat("select * from MS_Page where PageCode='{0}' and ID not in({1})", model._PageCode, id);
            DbCommand cmdtemp = db.GetSqlStringCommond(sbtemp.ToString());
            DataTable dt = db.ExecuteDataTable(cmdtemp);
            if (dt.Rows.Count > 0)
            {
                flag = 100;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("update MS_Page set PageCode='{0}',CodeName='{1}',Flag='{2}' where ID={3}", model._PageCode, model._CodeName, model._Flag, id);
                DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
                flag = db.ExecuteNonQuery(cmd);
            }
            return flag;
        }
        /// <summary>
        /// 修改是否启用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdatePageRoleByID(int id, bool isEnable)
        {
            int flag = 0;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update MS_Page set Flag='{0}' where ID={1}", isEnable, id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            flag = db.ExecuteNonQuery(cmd);

            return flag;
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public int DeletePageRoleByID(int id)
        {
            int flag = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("delete from MS_Page where ID={0}", id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        #endregion

        #region 选角推荐
        /// <summary>
        ///  新增选角推荐数据
        /// </summary>
        /// <param name="typename">类型名称</param>
        /// <param name="personid">选择的演员</param>
        /// <param name="flag">是否启用</param>
        public string InsertRecommend(string typename, string personid, string reasons, bool flag, string works)
        {
            DbCommand cmd = db.GetStoredProcCommond("user_save_Recommend");
            db.AddInParameter(cmd, "@typename", DbType.String, typename);
            db.AddInParameter(cmd, "@personid", DbType.String, personid);
            db.AddInParameter(cmd, "@reasons", DbType.String, reasons);
            db.AddInParameter(cmd, "@flag", DbType.Boolean, flag);
            db.AddInParameter(cmd, "@works", DbType.String, works);
            DataTable dt = db.ExecuteDataTable(cmd);
            string a = dt.Rows[0][0].ToString();
            return a;
        }
        /// <summary>
        /// 修改选角推荐数据
        /// </summary>
        /// <param name="typename">类型名称</param>
        /// <param name="personid">选择的演员</param>
        /// <param name="flag">是否启用</param>
        public string UpdateRecommend(string typename, string personid, string reasons, bool flag, string works)
        {
            DbCommand cmd = db.GetStoredProcCommond("user_update_Recommend");
            db.AddInParameter(cmd, "@typename", DbType.String, typename);
            db.AddInParameter(cmd, "@personid", DbType.String, personid);
            db.AddInParameter(cmd, "@reasons", DbType.String, reasons);
            db.AddInParameter(cmd, "@flag", DbType.Boolean, flag);
            db.AddInParameter(cmd, "@works", DbType.String, works);
            DataTable dt = db.ExecuteDataTable(cmd);
            string a = dt.Rows[0][0].ToString();
            return a;
        }

        /// <summary>
        /// 更新选角是否启用
        /// </summary>
        public int UpdateRecommendByTypeName(string TypeName, bool isenable)
        {
            DbCommand cmd = db.GetSqlStringCommond("update TB_Recommend set Flag='" + isenable + "' where TypeName='" + TypeName + "'");
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        /// <summary>
        /// 删除
        /// </summary>
        public int DeleteRecommendByTypeName(string TypeName)
        {
            DbCommand cmd = db.GetSqlStringCommond("delete from TB_Recommend where TypeName='" + TypeName + "'");
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        /// <summary>
        /// 根据类型获取选角推荐数据--集合数据
        /// </summary>
        public DataTable GetRecommendByTypeName(string TypeName)
        {
            DbCommand cmd = db.GetSqlStringCommond("select * from view_Recommend where TypeName='" + TypeName + "'");
            DataTable dt = db.ExecuteDataTable(cmd);
            return dt;
        }

        /// <summary>
        /// 根据类型获取选角推荐数据--分开数据
        /// </summary>
        public DataTable GetRecommendByTypeNameEach(string TypeName)
        {
            DbCommand cmd = db.GetSqlStringCommond("select * from TB_Recommend where TypeName='" + TypeName + "'");
            DataTable dt = db.ExecuteDataTable(cmd);
            return dt;
        }

        public void GetRecommendByMove(int id, string type)
        {
            DbCommand cmd = db.GetStoredProcCommond("user_reset_Sort");
            db.AddInParameter(cmd, "@moveid", DbType.String, id);
            db.AddInParameter(cmd, "@type", DbType.String, type);
            db.ExecuteNonQuery(cmd);
        }
        #endregion

        #region 关于我们
        public int InsertAboutUS(string address, string phone, string info)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into MS_AboutUS(introduction,phone,address,createdtime) values('{0}','{1}','{2}',GETDATE())", info, phone, address);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        #endregion

        #region 版本介绍
        public int InsertEdition(string id, string info)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into MS_Edition(version,edition,createdtime) values('{0}','{1}',GETDATE())", id, info);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        #endregion

        #region 发现内容发布
        /// <summary>
        /// 根据ID删除发布
        /// </summary>
        public int DeletePublishByID(int id)
        {
            DbCommand cmd = db.GetSqlStringCommond("delete from TB_Publish where ID=" + id);
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        /// <summary>
        /// 根据ID删除评论
        /// </summary>
        public int DeleteCommentByID(string id)
        {
            DbCommand cmd = db.GetSqlStringCommond("delete from TB_Comment where ID='" + id + "'");
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        /// <summary>
        /// 根据ID修改是否推荐状态
        /// </summary>
        public int UpdatePublishByID(int id, bool isenable)
        {
            DbCommand cmd = db.GetSqlStringCommond("update TB_Publish set Flag='" + isenable + "' where id=" + id);
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        /// <summary>
        /// 新增发布
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="ttype">发布类别</param>
        /// <param name="ctype">内容分类</param>
        /// <param name="isenable">是否推荐</param>
        /// <param name="content">内容</param>
        /// <param name="FMpath">封面图片</param>
        /// <param name="NRpath">内容图片</param>
        /// <returns></returns>
        public int InsertPublish(string title, string ttype, string ctype, bool isenable, string content, string FMpath, string NRpath)
        {
            DbCommand cmd = db.GetSqlStringCommond(@" insert into TB_Publish(Title_ID,Title_Name,Title_Type,Comment_Type,Flag,Content,CoverImg_Path,Img_Path,createdtime,Readed) 
                values(NEWID(),'" + title + "','" + ttype + "','" + ctype + "','" + isenable + "','" + content + "','" + FMpath + "','" + NRpath + "',GETDATE(),0) ");
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        /// <summary>
        /// 修改发布
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="ttype">发布类别</param>
        /// <param name="ctype">内容分类</param>
        /// <param name="isenable">是否推荐</param>
        /// <param name="content">内容</param>
        /// <param name="FMpath">封面图片</param>
        /// <param name="NRpath">内容图片</param>
        public int UpdatePublish(int id, string title, string ttype, string ctype, bool isenable, string content, string FMpath, string NRpath)
        {
            DbCommand cmd = db.GetSqlStringCommond(@" update TB_Publish set Title_Name='" + title + "',Title_Type='" + ttype + "',Comment_Type='" + ctype + "',Flag='" + isenable + "',Content='" + content + "',CoverImg_Path='" + FMpath + "',Img_Path='" + NRpath + "',createdtime=GETDATE() where ID=" + id);
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        /// <summary>
        /// 获取一条发布的数据
        /// </summary>
        public DataTable GetPublishByID(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@" select ID,Title_ID,Title_Name,Title_Type,Comment_Type,Flag,Content,CoverImg_Path,Img_Path,createdtime from TB_Publish  where ID=" + id);
            DbCommand cmd = db.GetSqlStringCommond(sb.ToString());
            DataTable dt = db.ExecuteDataTable(cmd);
            return dt;
        }

        #endregion

        #region 帮助页面
        /// <summary>
        /// 插入帮助页面信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertHelpPage(string info, string type)
        {
            DbCommand cmd = db.GetSqlStringCommond(" delete from MS_HelpPage where Type='" + type + "' insert into MS_HelpPage(HelpInfo,Type) values('" + info + "','" + type + "')");
            int flag = db.ExecuteNonQuery(cmd);
            return flag;
        }
        #endregion
    }
}