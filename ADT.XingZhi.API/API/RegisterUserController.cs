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
 * note:用户注册
 */
namespace ADT.XingZhi.API.API
{
    public class RegisterUserController : ApiController
    {
        AES aes = new AES();
        //查询该用户
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="email">邮箱</param>
        /// <param name="rancode">邮箱验证码</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Register(string username, string password, string email, string rancode)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                string newpassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
                DbCommand cmd = db.GetStoredProcCommond("user_register_User");
                db.AddInParameter(cmd, "@username", DbType.String, username);
                db.AddInParameter(cmd, "@password", DbType.String, newpassword);
                db.AddInParameter(cmd, "@email", DbType.String, email);
                db.AddInParameter(cmd, "@rancode", DbType.String, rancode);
                DataTable dt = db.ExecuteDataTable(cmd);
                flag = true;
                Msg = dt.Rows[0][0].ToString();
                string str = "";
                if (dt.Rows[0][0].ToString() == "用户邮箱已存在")
                {
                    code = 204;
                }
                else if (dt.Rows[0][0].ToString() == "用户名已存在")
                {
                    code = 210;
                }
                else if (dt.Rows[0][0].ToString() == "用户名、邮箱已存在")
                {
                    code = 215;
                }
                else if (dt.Rows[0][0].ToString() == "验证码错误")
                {
                    code = 216;
                }
                else if (dt.Rows[0][0].ToString() == "注册成功")
                {
                    code = 200;
                    str += "{\"_userid\":\"" + dt.Rows[0]["newid"].ToString()
                          + "\"}";
                }
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + str + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("Register(string username, string password, string email)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

        /// <summary>
        /// 注册的时候，通过邮箱发送验证码--暂时未启用
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

                DbCommand cmd = db.GetStoredProcCommond("user_insert_UserCode");
                db.AddInParameter(cmd, "@email", DbType.String, email);
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

    }
}