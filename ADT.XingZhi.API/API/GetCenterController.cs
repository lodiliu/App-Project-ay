using ADT.XingZhi.API.library;
using AtvSystemIntegration.Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
/*
 * create by :
 * create date:2015-01-07
 * note:个人中心模块全部功能页面
 */
namespace ADT.XingZhi.API.API
{
    public class GetCenterController : ApiController
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();
        public static string ApiPath = ConfigurationManager.AppSettings["ApiPath"].ToString();

        /// <summary>
        /// 个人中心-个人中心
        /// </summary>
        /// <param name="userid">登录用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByCenter(string userid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetCenterByCenter");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {

                    str += "{\"_USER_NAME\":\"" + dt.Rows[0]["USER_NAME"].ToString().Trim()
                         + "\",\"_User_Pic\":\"" + dt.Rows[0]["User_Pic"].ToString().Trim()
                         + "\",\"_User_Email\":\"" + dt.Rows[0]["User_Email"].ToString().Trim()
                         + "\",\"_User_Position\":\"" + dt.Rows[0]["User_Position"].ToString().Trim()
                         + "\",\"_User_ID\":\"" + dt.Rows[0]["User_ID"].ToString().Trim()
                         + "\"}";

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
                logger.WriteLogFile("GetCenterByCenter(string userid)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SendCode(string userid, string email)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                Random rd = new Random();
                string num = rd.Next(100000, 1000000).ToString();//生成6位随机数

                DbCommand cmd = db.GetStoredProcCommond("user_update_UserCode");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@useremail", DbType.String, email);
                db.AddInParameter(cmd, "@ramcode", DbType.String, num);
                DataTable dt = db.ExecuteDataTable(cmd);
                Msg = dt.Rows[0][0].ToString();
                if (Msg == "操作成功")
                {

                    #region 发送邮件
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.163.com");
                    //发送地址
                    string strFrom = ConfigurationManager.AppSettings["EmailAddress"].ToString();
                    string strFromName = ConfigurationManager.AppSettings["EmailName"].ToString();
                    //构造一个发件人地址对象
                    MailAddress from = new MailAddress(strFrom, strFromName, Encoding.UTF8);
                    //构造一个收件人地址对象
                    MailAddress to = new MailAddress(email, "", Encoding.UTF8);
                    //构造一个Email的Message对象
                    MailMessage message = new MailMessage(from, to);
                    //添加邮件主题和内容
                    message.Subject = ConfigurationManager.AppSettings["EmailSubject"].ToString();
                    message.SubjectEncoding = Encoding.UTF8;

                    message.Body = "验证码为:" + num;
                    message.BodyEncoding = Encoding.UTF8;
                    //设置邮件的信息
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.IsBodyHtml = false;
                    client.EnableSsl = false;
                    //设置用户名和密码。
                    client.UseDefaultCredentials = false;
                    string username = ConfigurationManager.AppSettings["EmailUserName"].ToString();
                    string passwd = ConfigurationManager.AppSettings["EmailPassword"].ToString();
                    //用户登陆信息
                    NetworkCredential myCredentials = new NetworkCredential(username, passwd);
                    client.Credentials = myCredentials;
                    //发送邮件
                    client.Send(message);
                    #endregion

                    flag = true;
                    code = 200;
                }
                else
                {
                    flag = true;
                    code = 204;
                }
                string str = "";
                str += "{\"_rancode\":\"" + num.ToString() + "\"}";
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + str + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("SendCode(string email)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 修改邮箱
        /// </summary>
        /// <param name="userid">登录用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByChangeEmail(string userid, string newemail, string usercode)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetCenterByChangeEmail");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@newemail", DbType.String, newemail);
                db.AddInParameter(cmd, "@usercode", DbType.String, usercode);
                DataTable dt = db.ExecuteDataTable(cmd);

                flag = true;
                code = 200;
                Msg = dt.Rows[0][0].ToString();
                if (Msg == "邮箱已存在")
                {
                    code = 204;
                }
                else if (Msg == "验证码错误")
                {
                    code = 216;
                }
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetCenterByChangeEmail(string userid, string newemail)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userid">登录用户ID</param>
        /// <param name="oldpassword">旧密码</param>
        /// <param name="newpassword">新密码</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByChangePWD(string userid, string oldpassword, string newpassword)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                string MDoldpassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldpassword, "MD5");
                string MDnewpassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpassword, "MD5");
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetCenterByChangePWD");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@oldpassword", DbType.String, MDoldpassword);
                db.AddInParameter(cmd, "@newpassword", DbType.String, MDnewpassword);
                DataTable dt = db.ExecuteDataTable(cmd);
                Msg = dt.Rows[0][0].ToString();
                if (Msg == "密码错误")
                {
                    code = 218;
                }
                else if (Msg == "修改成功")
                {
                    code = 200;
                }
                flag = true;
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetCenterByChangePWD(string userid, string password)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }


        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByAboutUS()
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetCenterByAboutUS");
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    str += "{\"_introduction\":\"" + dt.Rows[0]["introduction"].ToString().Trim()
                        + "\",\"_phone\":\"" + dt.Rows[0]["phone"].ToString().Trim()
                        + "\",\"_address\":\"" + dt.Rows[0]["address"].ToString().Trim()
                        + "\"}";
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
                logger.WriteLogFile("GetCenterByAboutUS()", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 用户反馈
        /// </summary>
        /// <param name="userid">登录用户ID</param>
        /// <param name="opinion">意见（500字）</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterBySaveOpinion(string userid, string opinion)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetCenterBySaveOpinion");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@opinion", DbType.String, opinion);
                db.ExecuteNonQuery(cmd);
                flag = true;
                code = 200;
                Msg = "新增成功";
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetCenterBySaveOpinion(string userid, string opinion)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 版本介绍
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByEdition()
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetCenterByEdition");
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    str += "{\"_introduction\":\"" + dt.Rows[0]["edition"].ToString().Trim()
                        + "\",\"_id\":\"" + dt.Rows[0]["version"].ToString().Trim() + "\"}";
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
                logger.WriteLogFile("GetCenterByEdition()", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 获取推送消息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="pagesize">条数</param>
        /// <param name="pageindex">页码</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByMessage(string userid, int pagesize, int pageindex)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetCenterByMessage");
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
                        str += "{\"_ID\":\"" + dt.Rows[i]["ID"].ToString().Trim()
                           + "\",\"_Title\":\"" + dt.Rows[i]["Title"].ToString().Trim()
                           + "\",\"_Context\":\"" + dt.Rows[i]["Context"].ToString().Trim()
                           + "\",\"_Readed\":\"" + dt.Rows[i]["Readed"].ToString().Trim()
                           + "\",\"_DeleteFlag\":\"" + dt.Rows[i]["DeleteFlag"].ToString().Trim()
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
                logger.WriteLogFile("GetCenterByMessage()", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 用户是否有未读消息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByHasRead(string userid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetCenterByHasRead");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";

                str += "{\"_total\":\"" + dt.Rows[0]["total"].ToString().Trim() + "\"}";
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
                logger.WriteLogFile("GetCenterByMessage()", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 更新用户消息是否已读状态
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="id">消息id</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByUpdateReaded(string userid, int id)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_update_Readed");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@id", DbType.String, @id);
                db.ExecuteNonQuery(cmd);
                flag = true;
                code = 200;
                Msg = "获取成功";

                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetCenterByMessage()", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 获取职位
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByPosition()
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetGeneral");
                db.AddInParameter(cmd, "@KeyType", DbType.String, "Position");
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {
                    for (int i = 0; i < len; i++)
                    {
                        str += "{\"_Key_Code\":\"" + dt.Rows[i]["Key_Code"].ToString().Trim()
                               + "\",\"_Key_Name\":\"" + dt.Rows[i]["Key_Name"].ToString().Trim()
                               + "\",\"_sort\":\"" + dt.Rows[i]["sort"].ToString().Trim()
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
                logger.WriteLogFile("GetCenterByPosition(string userid)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 修改用户的职位
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="pid">职位ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByUpdatePosition(string userid, string pid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_update_UserPosition");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@pid", DbType.String, pid);
                db.ExecuteNonQuery(cmd);
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
                logger.WriteLogFile("GetCenterByUpdatePosition()", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 获取消息ID详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByMessageID(int id)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetCenterByMessageID");
                db.AddInParameter(cmd, "@id", DbType.Int64, id);
                DataTable dt = db.ExecuteDataTable(cmd);
                int len = dt.Rows.Count;
                string str = "";
                if (len > 0)
                {

                    str += "{\"_ID\":\"" + dt.Rows[0]["ID"].ToString().Trim()
                           + "\",\"_Title\":\"" + dt.Rows[0]["Title"].ToString().Trim()
                           + "\",\"_Context\":\"" + dt.Rows[0]["Context"].ToString().Trim()
                           + "\"}";
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
                logger.WriteLogFile("GetCenterByMessageID", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 清空个人消息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCenterByClearMessage(string userid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                DbCommand cmd = db.GetStoredProcCommond("user_delete_UserMessage");
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.ExecuteNonQuery(cmd);
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
                logger.WriteLogFile("GetCenterByClearMessage()", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

    }
}