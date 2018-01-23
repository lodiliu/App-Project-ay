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

namespace ADT.XingZhi.API.API
{
    public class GetChooseController : ApiController
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();

        /// <summary>
        /// 获取选角-推荐
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetChooseByRecommend()
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetChooseByRecommend");
                DataSet ds = db.ExecuteDataSet(cmd);
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                int len1 = dt1.Rows.Count;
                int len2 = dt2.Rows.Count;
                string str = "";
                if (len1 > 0)
                {
                    for (int i = 0; i < len1; i++)
                    {
                        str += "{\"_typename\":\"" + dt1.Rows[i]["TypeName"].ToString().Trim()
                             + "\",\"_total\":\"" + dt1.Rows[i]["total"].ToString().Trim()
                            + "\",\"_area\":[";
                        string str2 = "";
                        for (int j = 0; j < len2; j++)
                        {
                            if (dt2.Rows[j]["TypeName"].ToString() == dt1.Rows[i]["TypeName"].ToString())
                            {
                                str2 += "{\"_personid\":\"" + dt2.Rows[j]["PersonID"].ToString().Trim()
                                     + "\",\"_CName\":\"" + dt2.Rows[j]["PersonName"].ToString().Trim()
                                     + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt2.Rows[j]["Img_Path"].ToString().Trim())
                            + "\"},";
                            }
                        }
                        if (!string.IsNullOrEmpty(str2))
                        {
                            str2 = str2.Substring(0, str2.Length - 1);
                        }
                        str += str2 + "]},";
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
                logger.WriteLogFile("GetChooseByRecommend()", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 获取选角-推荐详情
        /// </summary>
        /// <param name="userid">用户ID（为空）</param>
        /// <param name="typename"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetChooseByTypename(string userid, string typename, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                typename = typename == null ? "" : typename;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetChooseByTypename");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@typename", DbType.String, typename);
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
                        str += "{\"_typename\":\"" + dt.Rows[i]["TypeName"].ToString().Trim()
                            + "\",\"_personid\":\"" + dt.Rows[i]["PersonID"].ToString().Trim()
                            + "\",\"_CName\":\"" + dt.Rows[i]["PersonName"].ToString().Trim()
                            + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt.Rows[i]["Img_Path"].ToString().Trim())
                            + "\",\"_playname\":\"" + _playname
                            + "\",\"_reason\":\"" + dt.Rows[i]["reason"].ToString().Trim()
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
                logger.WriteLogFile("GetChooseByTypename(string typename)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 根据查询条件查询数据
        /// </summary>
        /// <param name="startyear">起始年龄</param>
        /// <param name="endyear">结束</param>
        /// <param name="field">领域</param>
        /// <param name="lv">级别</param>
        /// <param name="gender">性别</param>
        /// <param name="country">国别</param>
        /// <param name="theme">主题</param>
        /// <param name="orderby">排序字段</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetChooseBySearch(int pagesize, int pageindex, int startyear, int endyear, string field, string lv, string gender, string country, string theme, string orderby)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                startyear = startyear >= 0 ? startyear : 0;
                endyear = endyear >= 0 ? endyear : 0;
                field = field == null ? "" : field;
                lv = lv == null ? "" : lv;
                gender = gender == null ? "" : gender;
                country = country == null ? "" : country;
                theme = theme == null ? "" : theme;
                orderby = orderby == null ? "" : orderby;

                DbCommand cmd = db.GetStoredProcCommond("user_get_GetChooseBySearch");
                db.AddInParameter(cmd, "@startyear", DbType.Int32, startyear);
                db.AddInParameter(cmd, "@endyear", DbType.Int32, endyear);
                db.AddInParameter(cmd, "@field", DbType.String, field);
                db.AddInParameter(cmd, "@lv", DbType.String, lv);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@country", DbType.String, country);
                db.AddInParameter(cmd, "@theme", DbType.String, theme);
                db.AddInParameter(cmd, "@pagesize", DbType.Int32, pagesize);
                db.AddInParameter(cmd, "@pageindex", DbType.Int32, pageindex);
                db.AddInParameter(cmd, "@orderby", DbType.String, orderby);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    str += "{\"_total\":\"" + dt.Rows[0]["total"].ToString().Trim()
                         + "\",\"_area\":[";
                    for (int i = 0; i < len; i++)
                    {
                        str += "{\"_personid\":\"" + dt.Rows[i]["personid"].ToString().Trim()
                            + "\",\"_CName\":\"" + dt.Rows[i]["PersonName"].ToString().Trim()
                            + "\",\"_Gender\":\"" + dt.Rows[i]["Gender"].ToString().Trim()
                            + "\",\"_Birthday\":\"" + dt.Rows[i]["Birthday"].ToString().Trim()
                            + "\",\"_rating\":\"" + dt.Rows[i]["rating"].ToString().Trim()
                            + "\",\"_index\":\"" + dt.Rows[i]["zhishu"].ToString().Trim()
                            + "\",\"_counts\":\"" + dt.Rows[i]["bushu"].ToString().Trim()
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
                logger.WriteLogFile("GetChooseBySearch", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 保存查询的历史
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="startyear">开始年龄</param>
        /// <param name="endyear">结束年龄</param>
        /// <param name="field">领域</param>
        /// <param name="lv">级别</param>
        /// <param name="gender">性别</param>
        /// <param name="country">国别</param>
        /// <param name="theme">主题</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SaveChooseBySearch(string userid, string title, int startyear, int endyear, string field, string lv, string gender, string country, string theme, string orderby)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                startyear = startyear >= 0 ? startyear : 0;
                endyear = endyear >= 0 ? endyear : 100;
                field = field == null ? "" : field;
                lv = lv == null ? "" : lv;
                gender = gender == null ? "" : gender;
                country = country == null ? "" : country;
                theme = theme == null ? "" : theme;
                orderby = orderby == null ? "zh" : orderby;
                DbCommand cmd = db.GetStoredProcCommond("user_save_ChooseBySearch");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@title", DbType.String, title);
                db.AddInParameter(cmd, "@startyear", DbType.Int32, startyear);
                db.AddInParameter(cmd, "@endyear", DbType.Int32, endyear);
                db.AddInParameter(cmd, "@field", DbType.String, field);
                db.AddInParameter(cmd, "@lv", DbType.String, lv);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@country", DbType.String, country);
                db.AddInParameter(cmd, "@theme", DbType.String, theme);
                db.AddInParameter(cmd, "@orderby", DbType.String, orderby);
                DataTable dt = db.ExecuteDataTable(cmd);
                Msg = dt.Rows[0][0].ToString();
                if (Msg == "标题已存在")
                {
                    flag = true;
                    code = 221;
                }
                else
                {
                    flag = true;
                    code = 200;
                }
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("SaveChooseBySearch", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 保存查询的历史
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="startyear">开始年龄</param>
        /// <param name="endyear">结束年龄</param>
        /// <param name="field">领域</param>
        /// <param name="lv">级别</param>
        /// <param name="gender">性别</param>
        /// <param name="country">国别</param>
        /// <param name="theme">主题</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage UpdateChooseBySearch(string userid, string title, int startyear, int endyear, string field, string lv, string gender, string country, string theme, string orderby)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                startyear = startyear >= 0 ? startyear : 0;
                endyear = endyear >= 0 ? endyear : 100;
                field = field == null ? "" : field;
                lv = lv == null ? "" : lv;
                gender = gender == null ? "" : gender;
                country = country == null ? "" : country;
                theme = theme == null ? "" : theme;

                DbCommand cmd = db.GetStoredProcCommond("user_update_ChooseBySearch");
                db.AddInParameter(cmd, "@title", DbType.String, title);
                db.AddInParameter(cmd, "@startyear", DbType.Int32, startyear);
                db.AddInParameter(cmd, "@endyear", DbType.Int32, endyear);
                db.AddInParameter(cmd, "@field", DbType.String, field);
                db.AddInParameter(cmd, "@lv", DbType.String, lv);
                db.AddInParameter(cmd, "@gender", DbType.String, gender);
                db.AddInParameter(cmd, "@country", DbType.String, country);
                db.AddInParameter(cmd, "@theme", DbType.String, theme);
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@orderby", DbType.String, orderby);
                DataTable dt = db.ExecuteDataTable(cmd);
                Msg = dt.Rows[0][0].ToString();
                flag = true;
                code = 200;
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("UpdateChooseBySearch", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 删除历史数据
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DeleteChooseByTitle(string title, string userid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_delete_ChooseByTitle");
                db.AddInParameter(cmd, "@title", DbType.String, title);
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                DataTable dt = db.ExecuteDataTable(cmd);
                Msg = dt.Rows[0][0].ToString();
                flag = true;
                code = 200;
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("DeleteChooseByTitle", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 获取推荐-我的条件初始页面
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetChooseByMyCondition(string userid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetChooseByMyCondition");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                DataSet ds = db.ExecuteDataSet(cmd);
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                int len1 = dt1.Rows.Count;
                int len2 = dt2.Rows.Count;
                string str = "";
                if (len1 > 0)
                {
                    for (int i = 0; i < len1; i++)
                    {
                        str += "{\"_typename\":\"" + dt1.Rows[i]["TypeName"].ToString().Trim()
                             + "\",\"_total\":\"" + dt1.Rows[i]["total"].ToString().Trim()
                            + "\",\"_area\":[";
                        string str2 = "";
                        for (int j = 0; j < len2; j++)
                        {
                            if (dt2.Rows[j]["TypeName"].ToString() == dt1.Rows[i]["TypeName"].ToString())
                            {
                                str2 += "{\"_personid\":\"" + dt2.Rows[j]["PersonID"].ToString().Trim()
                                    + "\",\"_CName\":\"" + dt2.Rows[j]["PersonName"].ToString().Trim()
                            + "\",\"_path\":\"" + System.Web.HttpUtility.UrlEncode(dt2.Rows[j]["Img_Path"].ToString().Trim())
                            + "\"},";
                            }
                        }
                        if (!string.IsNullOrEmpty(str2))
                        {
                            str2 = str2.Substring(0, str2.Length - 1);
                        }
                        str += str2 + "]},";
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
                logger.WriteLogFile("GetChooseByMyCondition", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 获取主演题材和地区
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetChooseByThemeAndArea()
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetChooseByThemeAndArea");
                DataSet ds = db.ExecuteDataSet(cmd);
                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];
                DataTable dt3 = ds.Tables[2];
                int lentv = dt1.Rows.Count;
                int lenmovie = dt2.Rows.Count;
                int lenarea = dt3.Rows.Count;
                string str = string.Empty;

                if (lentv <= 0 && lenmovie <= 0 && lenarea <= 0)
                {
                    flag = true;
                    code = 202;
                    Msg = "没有查询到数据";
                }
                else
                {
                    str += "{\"_typename\":\"" + "电视剧" + "\",\"_area\":[";
                    string str1 = "";
                    for (int i = 0; i < lentv; i++)
                    {
                        str1 += "{\"_theme\":\"" + dt1.Rows[i]["value"].ToString().Trim() + "\"},";
                    }
                    if (!string.IsNullOrEmpty(str1))
                    {
                        str1 = str1.Substring(0, str1.Length - 1);
                    }
                    str += str1 + "]},";
                    str += "{\"_typename\":\"" + "电影" + "\",\"_area\":[";
                    string str2 = "";
                    for (int i = 0; i < lenmovie; i++)
                    {
                        str2 += "{\"_theme\":\"" + dt2.Rows[i]["value"].ToString().Trim() + "\"},";
                    }
                    if (!string.IsNullOrEmpty(str2))
                    {
                        str2 = str2.Substring(0, str2.Length - 1);
                    }
                    str += str2 + "]},";
                    str += "{\"_typename\":\"" + "地区" + "\",\"_area\":[";
                    string str3 = "";
                    for (int i = 0; i < lenarea; i++)
                    {
                        str3 += "{\"_theme\":\"" + dt3.Rows[i]["value"].ToString().Trim() + "\"},";
                    }
                    if (!string.IsNullOrEmpty(str2))
                    {
                        str3 = str3.Substring(0, str3.Length - 1);
                    }
                    str += str3 + "]},";
                    str = str.Substring(0, str.Length - 1);
                    flag = true;
                    code = 200;
                    Msg = "获取成功";
                }

                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + str.ToString() + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetChooseByThemeAndArea()", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 根据传入的标题ID查询具体条件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetChooseByTitle(string userid, string title)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetChooseByTitle");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@title", DbType.String, title);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        str += "{\"_ID\":\"" + dt.Rows[i]["ID"].ToString().Trim()
                           + "\",\"_Title\":\"" + dt.Rows[i]["Title"].ToString().Trim()
                           + "\",\"_StartYear\":\"" + dt.Rows[i]["StartYear"].ToString().Trim()
                           + "\",\"_EndYear\":\"" + dt.Rows[i]["EndYear"].ToString().Trim()
                           + "\",\"_Field\":\"" + dt.Rows[i]["Field"].ToString().Trim()
                           + "\",\"_Lv\":\"" + dt.Rows[i]["Lv"].ToString().Trim()
                           + "\",\"_Gender\":\"" + dt.Rows[i]["Gender"].ToString().Trim()
                           + "\",\"_Country\":\"" + dt.Rows[i]["Country"].ToString().Trim()
                           + "\",\"_Theme\":\"" + dt.Rows[i]["Theme"].ToString().Trim()
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
                logger.WriteLogFile("GetChooseByTitle(string type, string gender, string orderby, int pagesize, int pageindex)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }
    }
}