
using ADT.XingZhi.API.library;
using ADT.XingZhi.API.Package;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ADT.XingZhi.API.API
{

    public class UploadFileController : ApiController
    {
        AES aes = new AES();
        LogClass logger = new LogClass();
        DbHelper db = new DbHelper();

        public static string ApiPath = ConfigurationManager.AppSettings["ApiPath"].ToString();

        /// <summary>
        /// 通过multipart/form-data方式上传头像
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> PostFile()
        {
            Boolean flag = false;
            string Msg = "方法异常";
            int code = 205;
            string endpath = string.Empty;
            // 是否请求包含multipart/form-data。
            if (!Request.Content.IsMimeMultipartContent())
            {
                logger.WriteLogFile("PostFile", "上传格式不是multipart/form-data");
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string path = SettingConfig.ImgUrl + DateTime.Now.ToString("yyyyMMdd") + "/";
            string root = AppDomain.CurrentDomain.BaseDirectory + path;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                StringBuilder sb = new StringBuilder(); // Holds the response body
                string userid = string.Empty;
                // 阅读表格数据并返回一个异步任务.
                await Request.Content.ReadAsMultipartAsync(provider);

                // 如何获取表单数据.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        sb.Append(string.Format("{0}: {1}\n", key, val));
                        userid = val.ToString();
                    }
                }

                // 如何上传文件到文件名.
                foreach (var file in provider.FileData)
                {
                    string orfilename = file.Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
                    FileInfo fileinfo = new FileInfo(file.LocalFileName);
                    //最大文件大小 
                    int maxSize = Convert.ToInt32(SettingConfig.MaxSize);
                    if (fileinfo.Length <= 0)
                    {
                        Msg = "请选择上传文件";
                        code = 207;
                    }
                    else if (fileinfo.Length > maxSize)
                    {
                        Msg = "上传文件大小超过限制";
                        code = 212;
                    }
                    else
                    {
                        string fileExt = orfilename.Substring(orfilename.LastIndexOf('.'));
                        //定义允许上传的文件扩展名 
                        String fileTypes = SettingConfig.FileTypes;
                        if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(fileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
                        {
                            Msg = "图片类型不正确";
                            code = 214;
                        }
                        else
                        {
                            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            fileinfo.CopyTo(Path.Combine(root, newFileName + fileExt), true);
                            endpath = ApiPath + SettingConfig.ImgUrl + DateTime.Now.ToString("yyyyMMdd") + "/" + newFileName + fileExt;//最终路径
                            DbCommand cmd = db.GetStoredProcCommond("user_update_UserPic");
                            db.AddInParameter(cmd, "@userid", DbType.String, userid);
                            db.AddInParameter(cmd, "@userpic", DbType.String, endpath);
                            int a = db.ExecuteNonQuery(cmd);
                            flag = true;
                            Msg = "操作成功";
                            code = 200;
                        }
                    }
                    fileinfo.Delete();//删除原文件
                }
                string str = string.Empty;
                str = "{\"_User_Pic\":\"" + endpath + "\"}";
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[" + str.ToString() + "],\"Code\":" + code + "}";
                return ToJsonTran.ToJson(returnString.ToString());
            }
            catch (System.Exception e)
            {
                flag = true;
                Msg = "服务器无响应";
                code = 500;
                logger.WriteLogFile("PostFile", e.Message.ToString());
                String returnString = "{\"Success\":\"" + flag.ToString() + "\",\"Msg\":\"" + Msg.ToString() + "\", \"Data\":[],\"Code\":" + code + "}";
                return ToJsonTran.ToJson(returnString.ToString());
            }
        }

    }
}