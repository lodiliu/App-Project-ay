using System.IO;
using System.Text;
using System.Web;
using ADT.CMS.Utility;

namespace ADT.XingZhi.FineManage.Package
{
    public class DownLoadFile
    {
        /// <summary>
        /// 将指定的文件直接写入HTTP响应输出流
        /// </summary>
        /// <param name="file">文件</param>
        public static void WriteFile(string file)
        {
            string f = file.Substring(file.IndexOf("/"));
            string path = HttpContext.Current.Server.MapPath(RequestHelper.GetBaseURI() + file);
            if (File.Exists(path))
            {
                try
                {
                    string sName = file.Substring(file.LastIndexOf('/') + 1).Replace(" ", "");
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ClearHeaders();
                    HttpContext.Current.Response.Charset = "GB2312";
                    HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;//注意编码
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    if (HttpContext.Current.Request.UserAgent.Contains("MSIE") || HttpContext.Current.Request.UserAgent.Contains("msie"))
                    {
                        sName = HttpContext.Current.Server.UrlEncode(sName);
                    }
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + sName);
                    HttpContext.Current.Response.WriteFile(path);
                    HttpContext.Current.Response.Flush();
                    //HttpContext.Current.Response.Close();
                }
                catch
                {
                    PageScriptHelper.ResponseScript("alert(\"下载时遇到错误！\");");
                }
                finally
                {
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            else
            {
                PageScriptHelper.ResponseScript("alert(\"无法提供下载资源！\");");
            }
        }

        /// <summary>
        /// 将一个二进制字符串写入HTTP输出流
        /// </summary>
        /// <param name="file">文件</param>
        public static void BinaryWrite(string file)
        {
            string f = file.Substring(file.IndexOf("/"));
            string path = HttpContext.Current.Server.MapPath(RequestHelper.GetBaseURI() + file);
            if (File.Exists(path))
            {
                try
                {
                    string sName = file.Substring(file.LastIndexOf('/') + 1).Replace(" ", "");
                    FileStream fs = new FileStream(path, FileMode.Open);
                    long size = fs.Length;
                    byte[] buffer = new byte[size];
                    fs.Read(buffer, 0, (int)size);
                    fs.Close();
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    if (HttpContext.Current.Request.UserAgent.Contains("MSIE") || HttpContext.Current.Request.UserAgent.Contains("msie"))
                    {
                        sName = HttpContext.Current.Server.UrlEncode(sName);
                    }
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + sName);
                    HttpContext.Current.Response.BinaryWrite(buffer);
                    HttpContext.Current.Response.Flush();
                    //HttpContext.Current.Response.Close();
                }
                catch
                {
                    PageScriptHelper.ResponseScript("alert(\"下载时遇到错误！\");");
                }
                finally
                {
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            else
            {
                PageScriptHelper.ResponseScript("alert(\"无法提供下载资源！\");");
            }
        }
    }
}
