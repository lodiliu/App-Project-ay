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
 * create date:2015-12-30
 * note:用户登录
 */
namespace ADT.XingZhi.API.API
{
    public class LoginUserController : ApiController
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名/密码</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string username, string password)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                string newpassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
                DbCommand cmd = db.GetStoredProcCommond("user_login_User");
                db.AddInParameter(cmd, "@username", DbType.String, username);
                db.AddInParameter(cmd, "@password", DbType.String, newpassword);
                DataTable dt = db.ExecuteDataTable(cmd);
                string str = "";
                Msg = dt.Rows[0]["msg"].ToString();
                if (Msg == "登录成功")
                {
                    str = "{\"_User_Name\":\"" + username.ToString()
                           + "\",\"_User_ID\":\"" + dt.Rows[0]["userid"].ToString()
                           + "\"}";
                    flag = true;
                    code = 200;
                }
                else if (Msg == "用户未注册")
                {
                    flag = true;
                    code = 209;
                }
                else if (Msg == "用户名或密码错误")
                {
                    flag = true;
                    code = 217;
                }
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + str.ToString() + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("Get(string username, string password)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }


        /// <summary>
        /// 通过微信登录
        /// </summary>
        /// <param name="username">微信用户名</param>
        /// <param name="openid">微信OpenID</param>
        /// <param name="imgpath">头像地址</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage LoginByWX(string username, string openid, string imgpath)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_login_WxUser");
                db.AddInParameter(cmd, "@username", DbType.String, username);
                db.AddInParameter(cmd, "@openid", DbType.String, openid);
                db.AddInParameter(cmd, "@imgpath", DbType.String, imgpath);
                int a = db.ExecuteNonQuery(cmd);
                string str = "";
                str = "{\"_User_Name\":\"" + username.ToString()
                       + "\",\"_User_ID\":\"" + openid.ToString()
                       + "\",\"_path\":\"" + imgpath.ToString()
                       + "\"}";
                flag = true;
                code = 200;
                Msg = "登录成功";

                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + str.ToString() + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("LoginByWX(string username, string openid, string imgpath)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + "" + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }


    }
}