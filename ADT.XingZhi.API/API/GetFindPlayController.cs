using ADT.XingZhi.API.library;
using AtvSystemIntegration.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace ADT.XingZhi.API.API
{
    public class GetFindPlayController : ApiController, IRequiresSessionState
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();
        public static string ApiPath = ConfigurationManager.AppSettings["ApiPath"].ToString();
        public static string ManagerPath = ConfigurationManager.AppSettings["ManagerPath"].ToString();
        /// <summary>
        /// 默认头像
        /// </summary>
        public static string TouXiang = ConfigurationManager.AppSettings["TouXiang"].ToString();

        /// <summary>
        /// 获取影视剧模块
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindPlay(string type)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindPlay");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        string _FMpath = dt.Rows[i]["CoverImg_Path"].ToString().Trim();
                        if (!string.IsNullOrEmpty(_FMpath))
                        {
                            if (_FMpath.Substring(0, 1) == "~")
                                _FMpath = _FMpath.Replace("~", "");
                            _FMpath = ManagerPath + System.Web.HttpUtility.UrlEncode(_FMpath);
                        }
                        str += "{\"_titleid\":\"" + dt.Rows[i]["Title_ID"].ToString().Trim()
                            + "\",\"_FMpath\":\"" + _FMpath
                            + "\"},";
                    }
                    str = str.Substring(0, str.Length - 1);
                    flag = true;
                    code = 200;
                    Msg = "获取成功";
                }
                else
                {
                    flag = true;
                    code = 202;
                    Msg = "没有查询到数据";
                }
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + str.ToString() + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetFindPlay", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 根据标题ID获取全部的评论数量
        /// </summary>
        /// <param name="titleid">标题ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindPlayByCounts(string titleid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindPlayByCounts");
                db.AddInParameter(cmd, "@titleid", DbType.String, titleid);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                str = "{\"_count\":\"" + dt.Rows[0][0].ToString()
                   + "\",\"_titleid\":\"" + titleid
                    + "\"}";
                flag = true;
                code = 200;
                Msg = "获取成功";

                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + str.ToString() + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetFindPlay", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 点赞操作
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="id">评论ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindPlayByLike(string userid, string commentid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindPlayByLike");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@commentid", DbType.String, commentid);
                DataTable dt = db.ExecuteDataTable(cmd);
                flag = true;
                code = 200;
                Msg = "操作成功";
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                return ToJson.toJson(returnString.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetFindPlayByLike", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                return ToJson.toJson(returnString.ToString());
            }
        }

        /// <summary>
        /// 新增评论
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="username">用户名称</param>
        /// <param name="comment">评论</param>
        /// <param name="titleid">标题ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindPlayByAddComment(string userid, string comment, string titleid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindPlayByAddComment");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@comment", DbType.String, comment);
                db.AddInParameter(cmd, "@titleid", DbType.String, titleid);
                DataTable dt = db.ExecuteDataTable(cmd);
                flag = true;
                code = 200;
                Msg = "操作成功";
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetFindPlayByAddComment", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }


        /// <summary>
        /// 获取评论
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="titleid">标题ID</param>
        /// <param name="pagesize">条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        [HttpGet]
        public string GetFindPlayByComment(string userid, string titleid, int pagesize, int pageindex)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindPlayByComment");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@titleid", DbType.String, titleid);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataSet ds = db.ExecuteDataSet(cmd);
                DataTable dt = ds.Tables[1];
                string length = ds.Tables[0].Rows[0]["total"].ToString();//获取总行数

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string _path = dt.Rows[i]["User_Pic"].ToString();
                    _path = _path == "" ? TouXiang : _path;
                    builder.AppendFormat("<li class=\"pxLine\" data-id=\"{0}\">", length);
                    builder.Append("<div class=\"item-inner\">");
                    builder.Append("<div class=\"item-media\">");
                    builder.AppendFormat("<img src=\"{0}\" width=\"36\" height=\"36\" />", _path);
                    builder.Append("</div>");
                    builder.Append("<div class=\"item-title-row\">");
                    builder.Append("<div class=\"item-title\">");
                    builder.AppendFormat("<span>{0}</span>", dt.Rows[i]["username"]);
                    if (dt.Rows[i]["flag"].ToString() == "1")
                    {
                        builder.AppendFormat("<div class=\"item-after active\" onclick=\"dolike('{0}','{1}',this)\">{2}</div>", userid, dt.Rows[i]["id"], dt.Rows[i]["likeon"]);
                    }
                    else
                    {
                        builder.AppendFormat("<div class=\"item-after\" onclick=\"dolike('{0}','{1}',this)\">{2}</div>", userid, dt.Rows[i]["id"], dt.Rows[i]["likeon"]);
                    }
                    builder.Append("</div>");
                    builder.AppendFormat("<div class=\"item-subtitle\">{0}</div>", dt.Rows[i]["createdtime"]);
                    builder.Append("</div>");
                    builder.Append("</div>");
                    builder.AppendFormat("<div class=\"item-text\">{0}</div>", dt.Rows[i]["comment"]);
                    builder.Append("</li>");
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetFindPlayByComment", ex.Message.ToString());
                return builder.ToString();
            }
        }

        /// <summary>
        /// 加载影视剧列表
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="type">类型：电视剧/演员</param>
        /// <param name="pagesize">条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        public string GetFindPlayByAll(string userid, string type, int pagesize, int pageindex)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindPlayByALL");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataSet ds = db.ExecuteDataSet(cmd);
                DataTable dt = ds.Tables[0];
                string total = ds.Tables[1].Rows[0]["total"].ToString();//总行数
                int len = dt.Rows.Count;

                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        string _createdtime = dt.Rows[i]["createdtime"].ToString();
                        string _NRpath = dt.Rows[i]["Img_Path"].ToString();
                        if (dt.Rows[i]["createdtime"].ToString().Length == 16)
                        {
                            _createdtime = Convert.ToDateTime(dt.Rows[i]["createdtime"].ToString()).ToString("MM-dd HH:mm");
                        }
                        if (!string.IsNullOrEmpty(_NRpath))
                        {
                            if (_NRpath.Substring(0, 1) == "~")
                                _NRpath = _NRpath.Replace("~", "");
                            _NRpath = ManagerPath + System.Web.HttpUtility.UrlEncode(_NRpath);
                        }
                        builder.AppendFormat("<li class=\"rn-media-listItem pxLine\" onclick=\"javascript:window.location.href='{0}MoviesInfo.aspx?userid={1}&titleid={2}'\" data-id=\"{3}\">", ApiPath, userid, dt.Rows[i]["Title_ID"].ToString(), total);
                        builder.Append("<div class=\"title\">");
                        builder.AppendFormat("<span class=\"time\">{0}</span>", _createdtime);
                        builder.AppendFormat("<span class=\"text\">{0}</span>", dt.Rows[i]["Title_Name"].ToString());
                        builder.Append("</div>");
                        builder.Append("<div class=\"title-sub\">");
                        if (dt.Rows[i]["Comment_Type"].ToString() == "组讯")
                            builder.AppendFormat("<span class=\"ts-tip color1\">{0}</span>", dt.Rows[i]["Comment_Type"].ToString());
                        else if (dt.Rows[i]["Comment_Type"].ToString() == "推广")
                            builder.AppendFormat("<span class=\"ts-tip color2\">{0}</span>", dt.Rows[i]["Comment_Type"].ToString());
                        else
                            builder.AppendFormat("<span class=\"ts-tip color3\">{0}</span>", dt.Rows[i]["Comment_Type"].ToString());
                        builder.AppendFormat("<span class=\"ts-com\">{0} 评论</span>", dt.Rows[i]["counts"].ToString());
                        builder.AppendFormat("<span class=\"ts-read\">阅读 {0}</span>", dt.Rows[i]["readed"].ToString());
                        builder.Append("</div>");
                        builder.Append("<div class=\"rn-meida-img-wrap\">");
                        builder.AppendFormat("<img src=\"{0}\" alt=\"\" />", _NRpath);
                        builder.Append("</div>");
                        builder.Append("</li>");
                    }
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetFindPlayByAll", ex.Message.ToString());
                return builder.ToString();
            }
        }

        /// <summary>
        /// 根据标题ID获取具体信息
        /// </summary>
        /// <param name="titleid">标题ID</param>
        /// <returns></returns>
        [HttpGet]
        public string GetFindPlayByTitle(string titleid)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindPlayByTitle");
                db.AddInParameter(cmd, "@titleid", DbType.String, titleid);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                if (len > 0)
                {
                    string _createdtime = dt.Rows[0]["createdtime"].ToString();
                    string _NRpath = dt.Rows[0]["Img_Path"].ToString();
                    if (dt.Rows[0]["createdtime"].ToString().Length == 16)
                    {
                        _createdtime = Convert.ToDateTime(_createdtime).ToString("MM-dd HH:mm");
                    }

                    if (!string.IsNullOrEmpty(_NRpath))
                    {
                        if (_NRpath.Substring(0, 1) == "~")
                            _NRpath = _NRpath.Replace("~", "");
                        _NRpath = ManagerPath + System.Web.HttpUtility.UrlEncode(_NRpath);
                    }
                    builder.AppendFormat("<li class=\"rn-media-listItem pxLine hasFadeBg\">");
                    builder.AppendFormat("<div class=\"title\">");
                    builder.AppendFormat("<span class=\"text\">{0}</span>", dt.Rows[0]["Title_Name"].ToString());
                    builder.AppendFormat("</div>");
                    builder.AppendFormat("<div class=\"title-sub\">");
                    if (dt.Rows[0]["Comment_Type"].ToString() == "组讯")
                        builder.AppendFormat("<span class=\"ts-tip color1\">{0}</span>", dt.Rows[0]["Comment_Type"].ToString());
                    else if (dt.Rows[0]["Comment_Type"].ToString() == "推广")
                        builder.AppendFormat("<span class=\"ts-tip color2\">{0}</span>", dt.Rows[0]["Comment_Type"].ToString());
                    else
                        builder.AppendFormat("<span class=\"ts-tip color3\">{0}</span>", dt.Rows[0]["Comment_Type"].ToString());
                    builder.AppendFormat("<span class=\"ts-com\">{0}</span>", _createdtime);
                    builder.AppendFormat("</div>");
                    builder.AppendFormat("<div class=\"rn-meida-img-wrap\">");
                    builder.AppendFormat("<img src=\"{0}\" alt=\"\" />", _NRpath);
                    builder.AppendFormat("</div>");
                    builder.AppendFormat("<div class=\"rn-text-wrap\">");
                    builder.AppendFormat("{0}", dt.Rows[0]["Content"].ToString());
                    builder.AppendFormat("</div>");
                    builder.AppendFormat("</li>");
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetFindPlayByTitle", ex.Message.ToString());
                return builder.ToString();
            }
        }

        /// <summary>
        /// 获取热门评论
        /// </summary>
        /// <param name="titleid">标题ID</param>
        /// <returns></returns>
        [HttpGet]
        public string GetFindPlayByHotComment(string userid, string titleid)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindPlayByHotComment");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@titleid", DbType.String, titleid);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                if (len > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Comment com = new Comment();
                        string _createdtime = dt.Rows[i]["createdtime"].ToString();
                        if (_createdtime.Length == 16)//数据是时间格式--转换为相应时间
                        {
                            _createdtime = Convert.ToDateTime(_createdtime).ToString("MM-dd HH:mm");
                        }
                        string _path = dt.Rows[i]["User_Pic"].ToString();
                        _path = _path == "" ? TouXiang : _path;

                        builder.Append("<li class=\"pxLine\">");
                        builder.Append("<div class=\"item-inner\">");
                        builder.Append("<div class=\"item-media\">");
                        builder.AppendFormat("<img src=\"{0}\" width=\"36\" height=\"36\" />", _path);
                        builder.Append("</div>");
                        builder.Append("<div class=\"item-title-row\">");
                        builder.Append("<div class=\"item-title\">");
                        builder.AppendFormat("<span>{0}</span>", dt.Rows[i]["username"].ToString());
                        if (dt.Rows[i]["flag"].ToString() == "1")
                        {
                            builder.AppendFormat("<div class=\"item-after active\" onclick=\"dolike('{0}','{1}',this)\">{2}</div>", userid, dt.Rows[i]["ID"].ToString(), dt.Rows[i]["likeon"].ToString());
                        }
                        else
                        {
                            builder.AppendFormat("<div class=\"item-after\" onclick=\"dolike('{0}','{1}',this)\">{2}</div>", userid, dt.Rows[i]["ID"].ToString(), dt.Rows[i]["likeon"].ToString());
                        }
                        builder.Append("</div>");
                        builder.AppendFormat("<div class=\"item-subtitle\">{0}</div>", _createdtime);
                        builder.Append("</div>");
                        builder.Append("</div>");
                        builder.AppendFormat("<div class=\"item-text\">{0}</div>", dt.Rows[i]["comment"].ToString());
                        builder.Append("</li>");
                    }
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetFindPlayByTitle", ex.Message.ToString());
                return builder.ToString();
            }
        }

    }
}