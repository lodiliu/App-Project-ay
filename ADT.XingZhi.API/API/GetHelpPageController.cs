using ADT.XingZhi.API.library;
using AtvSystemIntegration.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADT.XingZhi.API.API
{
    public class GetHelpPageController : ApiController
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();

        /// <summary>
        /// 获取帮助页面
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetHelp(string type)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetHelpPage");
                db.AddInParameter(cmd, "@type", DbType.String, type);
                DataTable dt = db.ExecuteDataTable(cmd);
                string str = "";
                if (dt.Rows.Count == 0)
                {
                    flag = true;
                    code = 202;
                    Msg = "没有查询到数据";
                }
                else
                {
                    flag = true;
                    code = 200;
                    Msg = "获取成功";
                    str += "{\"_HelpInfo\":\"" + dt.Rows[0]["HelpInfo"].ToString().Trim() + "\"}";
                }
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + str + "],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetHelp", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }


    }
}