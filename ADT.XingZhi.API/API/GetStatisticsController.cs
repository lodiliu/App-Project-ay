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
    public class GetStatisticsController : ApiController
    {
        AES aes = new AES();
        DbHelper db = new DbHelper();
        LogClass logger = new LogClass();

        /// <summary>
        /// 新增点击的页面次数+1
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage AddStatistics(string pageid, string userid, string personid)
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            try
            {
                userid = userid == null ? "" : userid;
                personid = personid == null ? "" : personid;
                DbCommand cmd = db.GetStoredProcCommond("user_save_AddStatistics");
                db.AddInParameter(cmd, "@pageid", DbType.String, pageid);
                db.AddInParameter(cmd, "@userid", DbType.String, userid);
                db.AddInParameter(cmd, "@personid", DbType.String, personid);
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
                logger.WriteLogFile("AddStatistics(string userid)", ex.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                String decryptStr = aes.Encrypt(returnString);
                String ret = "{\"data\":\"" + decryptStr + "\"}";
                return ToJson.toJson(ret.ToString());
            }
        }

    }
}