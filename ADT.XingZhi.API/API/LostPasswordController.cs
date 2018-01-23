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
using System.Net.Mail;
using System.Text;
using System.Web.Http;
/*
 * create by :
 * create date:2016-01-04
 * note:忘记密码
 */
namespace ADT.XingZhi.API.API
{
    public class LostPasswordController : ApiController
    {
        AES aes = new AES();
        //查询该用户
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();

        /// <summary>
        /// 根据输入的邮箱发送验证码
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SendCode(string email)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                Random rd = new Random();
                string num = rd.Next(100000, 1000000).ToString();//生成6位随机数

                DbCommand cmd = db.GetStoredProcCommond("user_update_UserCode");
                db.AddInParameter(cmd, "@userid", DbType.String, "");
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
                    code = 222;
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
        /// 找回密码-修改密码
        /// </summary>
        /// <param name="userid">用户名称</param>
        /// <param name="usercode">验证码</param>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ChangePWD(string useremail, string usercode, string password)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                string newpassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
                DbCommand cmd = db.GetStoredProcCommond("user_change_Password");
                db.AddInParameter(cmd, "@useremail", DbType.String, useremail);
                db.AddInParameter(cmd, "@usercode", DbType.String, usercode);
                db.AddInParameter(cmd, "@password", DbType.String, newpassword);
                DataTable dt = db.ExecuteDataTable(cmd);
                Msg = dt.Rows[0][0].ToString();
                if (Msg == "验证码错误")
                {
                    code = 216;
                }
                else
                {
                    code = 200;
                }
                flag = true;
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("ChangePWD(string userid, string usercode, string password)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

    }
}