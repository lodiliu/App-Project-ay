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

namespace ADT.XingZhi.API.API
{
    public class GetRoleController : ApiController
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();
        /// <summary>
        /// 根据传入的apiurl判断是否有权限
        /// </summary>
        /// <param name="apiurl"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetRoleByPage(string pagecode)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                pagecode = pagecode == null ? "" : pagecode;
                DbCommand cmd = db.GetStoredProcCommond("user_get_GetRoleByPage");
                db.AddInParameter(cmd, "@pagecode", DbType.String, pagecode);
                DataTable dt = db.ExecuteDataTable(cmd);
                Msg = dt.Rows[0][0].ToString();
                if (Msg == "无法找到该链接对应的页面")
                {
                    code = 219;
                }
                else if (Msg == "无权限")
                {
                    code = 220;
                }
                else
                {
                    code = 200;
                }
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
            catch (Exception ex)
            {
                logger.WriteLogFile("GetRoleByPage", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

    }
}