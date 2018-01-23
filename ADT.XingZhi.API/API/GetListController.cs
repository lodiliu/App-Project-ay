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
using System.Web.Http;

/*
 * create by :
 * create date:2015-12-30
 * note:根据查询类型获取榜单各个类型
 */
namespace ADT.XingZhi.API.API
{
    public class GetListController : ApiController
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();
        /// <summary>
        /// 根据查询类型获取人气榜单
        /// </summary>
        /// <param name="type">月度，季度，半年，一年</param>
        /// <param name="gender">性别</param>
        /// <param name="orderby">涨幅sr or 评分rating</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetListByRenqi(string type, string gender, string orderby, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListByRenqi");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@orderby", DbType.String, orderby);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                           + "\",\"_CName\":\"" + dt.Rows[i]["姓名"].ToString().Trim()
                           + "\",\"_Gender\":\"" + dt.Rows[i]["性别"].ToString().Trim()
                           + "\",\"_duration\":\"" + dt.Rows[i]["时间粒度"].ToString().Trim()
                           + "\",\"_idx\":\"" + dt.Rows[i]["人气值"].ToString().Trim()
                           + "\",\"_rating\":\"" + dt.Rows[i]["人气指数"].ToString().Trim()
                           + "\",\"_SR\":\"" + dt.Rows[i]["指数变化"].ToString().Trim()
                           + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["头像路径"].ToString().Trim())
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
                logger.WriteLogFile("GetListByRenqi", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }
        /// <summary>
        /// 分享人气榜单
        /// </summary>
        [HttpGet]
        public string GetListByRenqi_Share(string type, string gender, string orderby, int pagesize, int pageindex, int length)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListByRenqi");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@orderby", DbType.String, orderby);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        builder.Append("<li>");
                        builder.Append("<div class=\"item-inner\">");
                        builder.Append("<div class=\"item-media\">");
                        builder.Append("<div class=\"media-img\">");
                        builder.AppendFormat("<img src=\"{0}\">", dt.Rows[i]["头像路径"].ToString().Trim());
                        builder.Append("</div>");
                        builder.AppendFormat("<div class=\"rankTxt\"><span>{0}</span></div>", length + i + 1);
                        builder.Append("</div>");
                        builder.Append("<div class=\"item-title-row\">");
                        builder.Append("<div class=\"item-title\">");
                        builder.AppendFormat("<span>{0}</span>", dt.Rows[i]["姓名"].ToString().Trim());
                        builder.AppendFormat("<div class=\"item-after\">{0}</div>", dt.Rows[i]["人气指数"].ToString().Trim());
                        builder.AppendFormat("<div class=\"item-trend up\"><i></i>{0}</div>", dt.Rows[i]["指数变化"].ToString().Trim());
                        builder.Append("</div>");
                        builder.Append("</div>");
                        builder.Append("</div>");
                        builder.Append("</li>");
                    }
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetListByRenqi_Share", ex.Message.ToString());
                return builder.ToString();
            }
        }

        /// <summary>
        /// 获取榜单-传统媒体
        /// </summary>
        /// <param name="type">all 全部 other 近两年 </param>
        /// <param name="gender"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetListByTV(string type, string gender, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListByTV");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        //截取前两部作品
                        string _playname = string.Empty;//
                        string[] _temp = dt.Rows[i]["电视剧名"].ToString().Split('》');
                        if (_temp.Length == 1)
                        {
                            _playname = "";
                        }
                        else if (_temp.Length == 2)
                        {
                            _playname += dt.Rows[i]["电视剧名"].ToString();
                        }
                        else
                        {
                            for (int m = 0; m < _temp.Length; m++)
                            {
                                if (m == 0 || m == 1)
                                {
                                    _playname += _temp[m] + '》';
                                }
                            }
                        }
                        str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                           + "\",\"_CName\":\"" + dt.Rows[i]["姓名"].ToString().Trim()
                           + "\",\"_Gender\":\"" + dt.Rows[i]["性别"].ToString().Trim()
                           + "\",\"_playname\":\"" + _playname
                           + "\",\"_rating\":\"" + dt.Rows[i]["指数"].ToString().Trim()
                           + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["头像路径"].ToString().Trim())
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
                logger.WriteLogFile("GetListByTV", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }
        /// <summary>
        /// 分享电视榜单
        /// </summary>
        [HttpGet]
        public string GetListByTV_Share(string type, string gender, int pagesize, int pageindex, int length)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListByTV");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        //截取前两部作品
                        string _playname = string.Empty;//
                        string[] _temp = dt.Rows[i]["电视剧名"].ToString().Split('》');
                        if (_temp.Length == 1)
                        {
                            _playname = "";
                        }
                        else if (_temp.Length == 2)
                        {
                            _playname += dt.Rows[i]["电视剧名"].ToString();
                        }
                        else
                        {
                            for (int m = 0; m < _temp.Length; m++)
                            {
                                if (m == 0 || m == 1)
                                {
                                    _playname += _temp[m] + '》';
                                }
                            }
                        }
                        builder.Append("<li>");
                        builder.Append("<div class=\"item-inner\">");
                        builder.Append("<div class=\"item-media\">");
                        builder.Append("<div class=\"media-img\">");
                        builder.AppendFormat("<img src=\"{0}\">", dt.Rows[i]["头像路径"].ToString().Trim());
                        builder.Append("</div>");
                        builder.AppendFormat("<div class=\"rankTxt\"><span>{0}</span></div>", length + i + 1);
                        builder.Append("</div>");
                        builder.Append("<div class=\"item-title-row\">");
                        builder.Append("<div class=\"item-title\">");
                        builder.AppendFormat("<span>{0}</span>", dt.Rows[i]["姓名"].ToString().Trim());
                        builder.AppendFormat("<div class=\"item-after\">{0}</div>", dt.Rows[i]["指数"].ToString().Trim());
                        builder.Append("</div>");
                        builder.AppendFormat("<div class=\"item-subtitle\">{0}</div>", _playname);
                        builder.Append("</div>");
                        builder.Append("</div>");
                        builder.Append("</li>");

                    }

                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetListByTV_Share", ex.Message.ToString());
                return builder.ToString();
            }
        }

        /// <summary>
        /// 获取榜单-新媒体
        /// </summary>
        /// <param name="type">all 全部 other 近两年</param>
        /// <param name="gender">性别 male female</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetListByWeb(string type, string gender, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListByWeb");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        //截取前两部作品
                        string _playname = string.Empty;//
                        string[] _temp = dt.Rows[i]["网络剧名"].ToString().Split('》');
                        if (_temp.Length == 1)
                        {
                            _playname = "";
                        }
                        else if (_temp.Length == 2)
                        {
                            _playname += dt.Rows[i]["网络剧名"].ToString();
                        }
                        else
                        {
                            for (int m = 0; m < _temp.Length; m++)
                            {
                                if (m == 0 || m == 1)
                                {
                                    _playname += _temp[m] + '》';
                                }
                            }
                        }
                        str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                           + "\",\"_CName\":\"" + dt.Rows[i]["姓名"].ToString().Trim()
                           + "\",\"_Gender\":\"" + dt.Rows[i]["性别"].ToString().Trim()
                           + "\",\"_playname\":\"" + _playname
                           + "\",\"_rating\":\"" + dt.Rows[i]["指数"].ToString().Trim()
                           + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["头像路径"].ToString().Trim())
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
                logger.WriteLogFile("GetListByWeb", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 新媒体分享页面
        /// </summary>
        [HttpGet]
        public string GetListByWeb_Share(string type, string gender, int pagesize, int pageindex, int length)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListByWeb");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        //截取前两部作品
                        string _playname = string.Empty;//
                        string[] _temp = dt.Rows[i]["网络剧名"].ToString().Split('》');
                        if (_temp.Length == 1)
                        {
                            _playname = "";
                        }
                        else if (_temp.Length == 2)
                        {
                            _playname += dt.Rows[i]["网络剧名"].ToString();
                        }
                        else
                        {
                            for (int m = 0; m < _temp.Length; m++)
                            {
                                if (m == 0 || m == 1)
                                {
                                    _playname += _temp[m] + '》';
                                }
                            }
                        }
                        builder.Append("<li>");
                        builder.Append("<div class=\"item-inner\">");
                        builder.Append("<div class=\"item-media\">");
                        builder.Append("<div class=\"media-img\">");
                        builder.AppendFormat("<img src=\"{0}\">", dt.Rows[i]["头像路径"].ToString().Trim());
                        builder.Append("</div>");
                        builder.AppendFormat("<div class=\"rankTxt\"><span>{0}</span></div>", length + i + 1);
                        builder.Append("</div>");
                        builder.Append("<div class=\"item-title-row\">");
                        builder.Append("<div class=\"item-title\">");
                        builder.AppendFormat("<span>{0}</span>", dt.Rows[i]["姓名"].ToString().Trim());
                        builder.AppendFormat("<div class=\"item-after\">{0}</div>", dt.Rows[i]["指数"].ToString().Trim());
                        builder.Append("</div>");
                        builder.AppendFormat("<div class=\"item-subtitle\">{0}</div>", _playname);
                        builder.Append("</div>");
                        builder.Append("</div>");
                        builder.Append("</li>");
                    }
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetListByWeb_Share", ex.Message.ToString());
                return builder.ToString();
            }
        }

        /// <summary>
        /// 获取榜单-电影
        /// </summary>
        /// <param name="type">all 全部 other 近两年</param>
        /// <param name="gender">性别 male female</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetListByMovie(string type, string gender, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListByMovie");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        //截取前两部作品
                        string _playname = string.Empty;//
                        string[] _temp = dt.Rows[i]["电影名"].ToString().Split('》');
                        if (_temp.Length == 1)
                        {
                            _playname = "";
                        }
                        else if (_temp.Length == 2)
                        {
                            _playname += dt.Rows[i]["电影名"].ToString();
                        }
                        else
                        {
                            for (int m = 0; m < _temp.Length; m++)
                            {
                                if (m == 0 || m == 1)
                                {
                                    _playname += _temp[m] + '》';
                                }
                            }
                        }
                        str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                           + "\",\"_CName\":\"" + dt.Rows[i]["姓名"].ToString().Trim()
                           + "\",\"_Gender\":\"" + dt.Rows[i]["性别"].ToString().Trim()
                           + "\",\"_playname\":\"" + _playname
                           + "\",\"_rating\":\"" + dt.Rows[i]["指数"].ToString().Trim()
                           + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["头像路径"].ToString().Trim())
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
                logger.WriteLogFile("GetListByMovie(string type, string gender, int pagesize, int pageindex)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }
        /// <summary>
        /// 电影分享页面
        /// </summary>
        [HttpGet]
        public string GetListByMovie_Share(string type, string gender, int pagesize, int pageindex, int length)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListByMovie");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        //截取前两部作品
                        string _playname = string.Empty;//
                        string[] _temp = dt.Rows[i]["电影名"].ToString().Split('》');
                        if (_temp.Length == 1)
                        {
                            _playname = "";
                        }
                        else if (_temp.Length == 2)
                        {
                            _playname += dt.Rows[i]["电影名"].ToString();
                        }
                        else
                        {
                            for (int m = 0; m < _temp.Length; m++)
                            {
                                if (m == 0 || m == 1)
                                {
                                    _playname += _temp[m] + '》';
                                }
                            }
                        }
                        builder.Append("<li>");
                        builder.Append("<div class=\"item-inner\">");
                        builder.Append("<div class=\"item-media\">");
                        builder.AppendFormat("<div class=\"media-img\"><img src=\"{0}\"></div>", dt.Rows[i]["头像路径"].ToString().Trim());
                        builder.AppendFormat("<div class=\"rankTxt\"><span>{0}</span></div>", length + i + 1);
                        builder.Append("</div>");
                        builder.Append("<div class=\"item-title-row\">");
                        builder.Append("<div class=\"item-title\">");
                        builder.AppendFormat("<span>{0}</span>", dt.Rows[i]["姓名"].ToString().Trim());
                        builder.AppendFormat("<div class=\"item-after\">{0}</div>", dt.Rows[i]["指数"].ToString().Trim());
                        builder.Append("</div>");
                        builder.AppendFormat("<div class=\"item-subtitle\">{0}</div>", _playname);
                        builder.Append("</div>");
                        builder.Append("</div>");
                        builder.Append("</li>");
                    }
                }
                return builder.ToString();
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetListByMovie_Share()", ex.Message.ToString());
                return builder.ToString();
            }
        }

        /// <summary>
        /// 搜索--显示热门明星
        /// </summary>
        /// <param name="pagesize">显示的明星个数</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetListByHot(int pagesize)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListByHot");
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString()
                           + "\",\"_CName\":\"" + dt.Rows[i]["CName"].ToString()
                           + "\",\"_idx\":\"" + dt.Rows[i]["idx"].ToString()
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
                logger.WriteLogFile("GetListByHot", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 搜索结果页
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="pagesize">显示条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetListBySearch(string userid, string name, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListBySearch");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@name", DbType.String, name);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        //截取前两部作品
                        string _playname = string.Empty;//
                        string[] _temp = dt.Rows[i]["work"].ToString().Split('》');
                        if (_temp.Length == 1)
                        {
                            _playname = "";
                        }
                        else if (_temp.Length == 2)
                        {
                            _playname += dt.Rows[i]["work"].ToString();
                        }
                        else
                        {
                            for (int m = 0; m < _temp.Length; m++)
                            {
                                if (m == 0 || m == 1)
                                {
                                    _playname += _temp[m] + '》';
                                }
                            }
                        }
                        str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                           + "\",\"_CName\":\"" + dt.Rows[i]["CName"].ToString().Trim()
                           + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["Img_Path"].ToString().Trim())
                           + "\",\"_work\":\"" + _playname
                           + "\",\"_flag\":\"" + dt.Rows[i]["flag"].ToString().Trim()
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
                logger.WriteLogFile("GetListBySearch", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 保存榜单的查询历史
        /// </summary>
        /// <param name="userid">登录用户ID</param>
        /// <param name="personid"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SaveSearchHistory(string userid, string personname)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_save_ListSearch");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@personname", DbType.String, personname);
                DataTable dt = db.ExecuteDataTable(cmd);
                flag = true;
                code = 200;
                Msg = "保存成功";
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("SaveSearchHistory", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 获取搜索历史
        /// </summary>
        /// <param name="userid">登录用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetSearchHistory(string userid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetListBySearchHistory");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        str += "{\"_personname\":\"" + dt.Rows[i]["personname"].ToString().Trim()
                           + "\",\"_userid\":\"" + dt.Rows[i]["userid"].ToString().Trim()
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
                logger.WriteLogFile("GetListBySearch(int pagesize)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 删除榜单的历史查询数据
        /// </summary>
        /// <param name="userid">登录用户ID</param>
        /// <param name="personname">数据</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteSearchHistory(string userid, string personname)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_delete_ListSearch");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@personname", DbType.String, personname);
                DataTable dt = db.ExecuteDataTable(cmd);
                flag = true;
                code = 200;
                Msg = "删除成功";
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("SaveSearchHistory(string userid, string personid)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }
    }
}