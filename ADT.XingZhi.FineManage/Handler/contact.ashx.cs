using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Encrypt;
using ADT.CMS.Utility.ReturnResult;
using System.Data;

namespace ADT.XingZhi.FineManage.Handler
{
    /// <summary>
    /// contact 的摘要说明
    /// </summary>
    public class contact : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            MessagesModel r = new MessagesModel(false, "必须使用Post提交");
            try
            {
                if (context.Request.HttpMethod == "POST")  //限制只有POST提交才有效
                {
                    DataTable dt = new BLL.APP.Contact().GetTable(0);
                    if (dt != null&&dt.Rows.Count>0)
                    {
                        r.Success = true;
                        r.Msg = dt.Rows[0]["context"].ToString();
                    }
                    else
                    {
                        r.Success = false;
                        r.Msg = "内容不存在!";
                    }

                }
            }            
            catch (Exception)
            {
                r.Msg = "读取出错";
            }
            finally
            {
                context.Response.ContentType = "application/json";
                context.Response.Write(new JavaScriptSerializer().Serialize(r));
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}