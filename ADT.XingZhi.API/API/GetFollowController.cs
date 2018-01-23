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
 * create date:2016-01-05
 * note:获取关注人+保存关注
 */
namespace ADT.XingZhi.API.API
{
    public class GetFollowController : ApiController
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();

        /// <summary>
        /// 根据传入的用户ID获取该用户的关注人员
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFollowByUserid(string userid, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFollowByUserid");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
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
                        string[] _temp = dt.Rows[i]["playname"].ToString().Split('》');
                        if (_temp.Length == 1)
                        {
                            _playname = "";
                        }
                        else if (_temp.Length == 2)
                        {
                            _playname += dt.Rows[i]["playname"].ToString();
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
                        str += "{\"_userid\":\"" + dt.Rows[i]["UserID"].ToString().Trim()
                            + "\",\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                            + "\",\"_personname\":\"" + dt.Rows[i]["personname"].ToString().Trim()
                            + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["Img_Path"].ToString().Trim())
                            + "\",\"_playname\":\"" + _playname
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
                logger.WriteLogFile("GetFollowByUserid(string userid)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 保存关注人
        /// </summary>
        /// <param name="userid">登录人ID</param>
        /// <param name="follows">明星ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SaveFollows(string userid, string follows)
        {
            Boolean flag = false;
            string Msg = "保存失败";
            int code = 211;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_save_Follows");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@follows", DbType.String, follows);
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
                logger.WriteLogFile("SaveFollows", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="userid">登录人ID</param>
        /// <param name="follows">明星ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteFollows(string userid, string follows)
        {
            Boolean flag = false;
            string Msg = "取消关注失败";
            int code = 213;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_delete_Follows");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@follows", DbType.String, follows);
                DataTable dt = db.ExecuteDataTable(cmd);
                flag = true;
                code = 200;
                Msg = "取消关注成功";
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("DeleteFollows", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 获取最新关注的两人的对比
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetFollowByCompare(string userid, string leftpersonid, string rightpersonid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                leftpersonid = leftpersonid == null ? "" : leftpersonid;
                rightpersonid = rightpersonid == null ? "" : rightpersonid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFollowByCompare");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@leftpersonid", DbType.String, leftpersonid);
                db.AddInParameter(cmd, "@rightpersonid", DbType.String, rightpersonid);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    str += "{\"_total\":\"" + len
                          + "\",\"_area\":[";
                    for (int i = 0; i < len; i++)
                    {
                        str += "{\"_userid\":\"" + dt.Rows[i]["UserID"].ToString().Trim()
                           + "\",\"_personid\":\"" + dt.Rows[i]["Personid"].ToString().Trim()
                           + "\",\"_personname\":\"" + dt.Rows[i]["PersonName"].ToString().Trim()
                           + "\",\"_RMD\":\"" + dt.Rows[i]["媒体曝光"].ToString().Trim()
                           + "\",\"_rating\":\"" + dt.Rows[i]["人气"].ToString().Trim()
                           + "\",\"_RMOVIE\":\"" + dt.Rows[i]["电影"].ToString().Trim()
                           + "\",\"_RTV\":\"" + dt.Rows[i]["传统媒体"].ToString().Trim()
                           + "\",\"_RF\":\"" + dt.Rows[i]["网络视频指数"].ToString().Trim()
                           + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["Img_Path"].ToString().Trim())
                           + "\"},";
                    }
                    str = str.Substring(0, str.Length - 1);
                    str += "]}";
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
                logger.WriteLogFile("GetFollowByCompare", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 获取推荐关注
        /// </summary>
        [HttpGet]
        public HttpResponseMessage GetFollowByBatch(string userid, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetFollowByBatch");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
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
                           + "\",\"_personname\":\"" + dt.Rows[i]["CName"].ToString().Trim()
                           + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["Img_Path"].ToString().Trim())
                            + "\",\"_rating\":\"" + dt.Rows[i]["rating"].ToString().Trim()
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
                logger.WriteLogFile("GetFollowByBatch", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }


    }
}