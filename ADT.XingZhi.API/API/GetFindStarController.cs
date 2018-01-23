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
using System.Web.Http;
/*
 * create by :
 * create date:2016-01-04
 * note:获取明星个人页面-个人+作品+潜力作品+人气+舆情+照片
 */
namespace ADT.XingZhi.API.API
{
    public class GetFindStarController : ApiController
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();
        public static string ManagerPath = ConfigurationManager.AppSettings["ManagerPath"].ToString();
        /// <summary>
        /// 个人
        /// </summary>
        /// <param name="personid">明星ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindStarByPersonid(string personid, string userid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindStarByPersonid");
                db.AddInParameter(cmd, "@personid", DbType.String, personid);
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                           + "\",\"_CName\":\"" + dt.Rows[i]["CName"].ToString().Trim()
                           + "\",\"_Gender\":\"" + dt.Rows[i]["Gender"].ToString().Trim()
                           + "\",\"_School\":\"" + dt.Rows[i]["School"].ToString().Trim()
                           + "\",\"_Company\":\"" + dt.Rows[i]["Company"].ToString().Trim()
                           + "\",\"_Height\":\"" + dt.Rows[i]["Height"].ToString().Trim()
                           + "\",\"_RMD\":\"" + dt.Rows[i]["媒体曝光"].ToString().Trim()
                           + "\",\"_rating\":\"" + dt.Rows[i]["人气"].ToString().Trim()
                           + "\",\"_RMOVIE\":\"" + dt.Rows[i]["电影"].ToString().Trim()
                           + "\",\"_RTV\":\"" + dt.Rows[i]["传统媒体"].ToString().Trim()
                           + "\",\"_RF\":\"" + dt.Rows[i]["网络视频指数"].ToString().Trim()
                           + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["Img_Path"].ToString().Trim())
                           + "\",\"_Birthday\":\"" + dt.Rows[i]["Birthday"].ToString().Trim().Trim()
                           + "\",\"_flag\":\"" + dt.Rows[i]["是否关注"].ToString().Trim()
                           + "\"}";
                    }
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
                logger.WriteLogFile("GetFindStarByPersonid(string personid, string userid)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 作品
        /// </summary>
        /// <param name="personid">明星ID</param>
        /// <param name="type">类型 all 全部作品 movie 电影作品 tv 电视作品</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindStarByWork(string personid, string type, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindStarByWork");
                db.AddInParameter(cmd, "@personid", DbType.String, personid);
                db.AddInParameter(cmd, "@type", DbType.String, type);
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
                           + "\",\"_CName\":\"" + dt.Rows[i]["CName"].ToString().Trim()
                           + "\",\"_Gender\":\"" + dt.Rows[i]["Gender"].ToString().Trim()
                           + "\",\"_rolerank\":\"" + dt.Rows[i]["rolerank"].ToString().Trim()
                           + "\",\"_workname\":\"" + dt.Rows[i]["workname"].ToString().Trim()
                           + "\",\"_onair\":\"" + dt.Rows[i]["onair"].ToString().Trim()
                           + "\",\"_gross\":\"" + dt.Rows[i]["gross"].ToString().Trim()
                           + "\",\"_dy\":\"" + dt.Rows[i]["dy"].ToString().Trim()
                           + "\",\"_zy\":\"" + dt.Rows[i]["zy"].ToString().Trim()
                           + "\",\"_worktype\":\"" + dt.Rows[i]["worktype"].ToString().Trim()
                           + "\",\"_type\":\"" + dt.Rows[i]["type"].ToString().Trim()
                           + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["Img_Path"].ToString().Trim())
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
                logger.WriteLogFile("GetFindStarByWork(string personid, string type, int pagesize, int pageindex)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 潜力作品
        /// </summary>
        /// <param name="personid">明星ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindStarByPotential(string personid, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindStarByPotential");
                db.AddInParameter(cmd, "@personid", DbType.String, personid);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {

                        string _path = dt.Rows[i]["ImgPath"].ToString();
                        if (!string.IsNullOrEmpty(_path))
                        {
                            if (_path.Substring(0, 1) == "~")
                                _path = _path.Replace("~", "");
                            _path = ManagerPath + System.Web.HttpUtility.UrlEncode(_path);
                        }
                        str += "{\"_personid\":\"" + dt.Rows[i]["PersonID"].ToString().Trim()
                           + "\",\"_CName\":\"" + dt.Rows[i]["PersonName"].ToString().Trim()
                           + "\",\"_workname\":\"" + dt.Rows[i]["WorkName"].ToString().Trim()
                           + "\",\"_type\":\"" + dt.Rows[i]["WorkType"].ToString().Trim()
                           + "\",\"_dy\":\"" + dt.Rows[i]["dy"].ToString().Trim()
                           + "\",\"_zy\":\"" + dt.Rows[i]["zy"].ToString().Trim()
                           + "\",\"_workinfo\":\"" + dt.Rows[i]["WorkInfo"].ToString().Trim()
                           + "\",\"_onair\":\"" + Convert.ToDateTime(dt.Rows[i]["Release"]).ToString("yyyy年M月")
                           + "\",\"_path\":\"" + _path
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
                logger.WriteLogFile("GetFindStarByPotential(string personid, int pagesize, int pageindex)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }


        /// <summary>
        /// 人气
        /// </summary>
        /// <param name="personid">明星ID</param>
        /// <param name="type">类型：90 近3月 180 近半年 360 近一年</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindStarByRenqi(string personid, int type)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindStarByRenqi");
                db.AddInParameter(cmd, "@personid", DbType.String, personid);
                db.AddInParameter(cmd, "@type", DbType.Int32, type);
                DataSet ds = db.ExecuteDataSet(cmd);

                DataTable dt = ds.Tables[0];//明星人气趋势
                int len = dt.Rows.Count;
                DataTable dt1 = ds.Tables[1];//明星新闻
                int len1 = dt1.Rows.Count;

                string str = "";
                string str1 = "";
                if (len <= 0 && len1 <= 0)
                {
                    flag = true;
                    code = 202;
                    Msg = "没有查询到数据";
                }
                else
                {
                    if (len > 0)
                    {
                        for (int i = 0; i < len; i++)
                        {
                            str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                               + "\",\"_firstofweek\":\"" + Convert.ToDateTime(dt.Rows[i]["firstofweek"]).ToString("M/dd")
                               + "\",\"_rating\":\"" + dt.Rows[i]["rating"].ToString().Trim()
                               + "\",\"_incrating\":\"" + dt.Rows[i]["incrating"].ToString().Trim()
                               + "\",\"_judge\":\"" + dt.Rows[i]["judge"].ToString().Trim()
                               + "\"},";
                        }
                        str = str.Substring(0, str.Length - 1);
                    }
                    if (len1 > 0)
                    {
                        for (int i = 0; i < len1; i++)
                        {
                            str1 += "{\"_lv\":\"" + dt1.Rows[i]["lv"].ToString().Trim()
                               + "\",\"_title\":\"" + dt1.Rows[i]["新闻题目"].ToString().Trim()
                               + "\",\"_publish_at\":\"" + Convert.ToDateTime(dt1.Rows[i]["发表时间"]).ToString("yyyy-MM-dd")
                               + "\",\"_url\":\"" + dt1.Rows[i]["链接"].ToString().Trim()
                               + "\",\"_month\":\"" + Convert.ToDateTime(dt1.Rows[i]["MONTH"]).ToString("yyyy年MM月")
                               + "\"},";
                        }
                        str1 = str1.Substring(0, str1.Length - 1);
                    }
                    flag = true;
                    code = 200;
                    Msg = "获取成功";
                }
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\",\"Data\":[" + str.ToString() + "],\"DataNews\":[" + str1.ToString() + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetFindStarByRenqi(string personid, int type)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 舆情
        /// </summary>
        /// <param name="personid">明星ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindStarByNews(string personid, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindStarByNews");
                db.AddInParameter(cmd, "@personid", DbType.String, personid);
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
                           + "\",\"_title\":\"" + dt.Rows[i]["title"].ToString().Trim()
                           + "\",\"_publish_at\":\"" + dt.Rows[i]["publish_at"].ToString().Trim()
                           + "\",\"_website\":\"" + dt.Rows[i]["website"].ToString().Trim()
                           + "\",\"_comment_count\":\"" + dt.Rows[i]["comment_count"].ToString().Trim()
                           + "\",\"_url\":\"" + dt.Rows[i]["url"].ToString().Trim()
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
                logger.WriteLogFile("GetFindStarByNews(string personid, int pagesize, int pageindex)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 照片
        /// </summary>
        /// <param name="personid">明星ID</param>
        /// <param name="pagesize">条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFindStarByPic(string personid, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            Common com = new Common();
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFindStarByPic");
                db.AddInParameter(cmd, "@personid", DbType.String, personid);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        string _url = dt.Rows[i]["url"].ToString().Trim();
                        string widthandheight = com.GetWidthAndHeight(_url);
                        string width = widthandheight.Split('-')[0];
                        string height = widthandheight.Split('-')[1];
                        str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                           + "\",\"_url\":\"" + System.Web.HttpUtility.UrlEncode(_url)
                           + "\",\"_width\":\"" + width
                           + "\",\"_height\":\"" + height
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
                logger.WriteLogFile("GetFindStarByPic(string personid, int pagesize, int pageindex)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

    }
}