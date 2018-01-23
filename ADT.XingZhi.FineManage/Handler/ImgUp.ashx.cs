using ADT.CMS.Utility;
using ADT.CMS.Utility.Encrypt;
using ADT.CMS.Utility.ReturnResult;
using ADT.CMS.Utility.Upload;
using System;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using AS = ADT.XingZhi.DAL.S.AttachmentSingleton;

namespace ADT.XingZhi.FineManage.Handler
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class ImgUp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ///上传密钥
            string key = RequestHelper.GetRequestString("key");
            ///栏目目录
            string nodeDir = RequestHelper.GetRequestString("nodedir");
            UploadImg(key, nodeDir);  
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="key">上传图片密钥</param>
        /// <param name="nodeDir">栏目目录</param>
        private void UploadImg(string key, string nodeDir)
        {
            MessagesDataModel r = new MessagesDataModel(false, "服务无响应");
            try
            {
                if (key == AS.Singleton.FileServerMD5Key)
                {
                    HttpPostedFile fup = HttpContext.Current.Request.Files[0];
                    if (fup != null)
                    {
                        Int64 fileSize = fup.ContentLength;
                        if (fileSize > AS.Singleton.UploadImgMaxSize * 1024)
                        {
                            r.Msg = "上传图片大小不能超过" + AS.Singleton.UploadImgMaxSize + "KB";
                        }
                        else
                        {
                            string extension = Path.GetExtension(fup.FileName).ToLowerInvariant();
                            if (AS.Singleton.UploadImgExt.Contains(extension.TrimStart('.')))
                            {
                                string truePath = String.Empty;
                                string newTruePath = String.Empty;
                                string year = DateTime.Now.ToString("yyyy");
                                string month = DateTime.Now.ToString("MM");
                                string day = DateTime.Now.ToString("dd");
                                string hour = DateTime.Now.ToString("HH");
                                string minute = DateTime.Now.ToString("mm");
                                string second = DateTime.Now.ToString("ss");
                                string fileName = AS.Singleton.FileNameRule.Replace("{$Random}", Guid.NewGuid().ToString()).Replace("{$Year}", year).Replace("{$Month}", month).Replace("{$Day}", day).Replace("{$Hour}", year).Replace("{$Minute}", minute).Replace("{$Second}", second).Replace("{$Origin}", Path.GetFileNameWithoutExtension(fup.FileName)) + extension;
                                string url = String.Empty;

                                if (AS.Singleton.EnabledUploadShare == "T")  //若设置为上传至共享目录，否则上传至当前服务目录中
                                {
                                    truePath = String.Format("{0}\\{1}\\", AS.Singleton.UploadDir, AS.Singleton.UploadFilePathRule.Replace("/", "\\").Replace("{$NodeDir}", nodeDir).Replace("{$Year}", year).Replace("{$Month}", month).Replace("{$Day}", day));
                                    IOHelper.CreateDir(truePath);//创建目录
                                    newTruePath = truePath + fileName;
                                    url = String.Format("{0}{1}/{2}", AS.Singleton.UploadUrl, AS.Singleton.UploadFilePathRule.Replace("{$NodeDir}", nodeDir).Replace("{$Year}", year).Replace("{$Month}", month).Replace("{$Day}", day), fileName);
                                }
                                else
                                {
                                  
                                    truePath = String.Format("{0}{1}/{2}", RequestHelper.GetBaseURI(), AS.Singleton.UploadDir, AS.Singleton.UploadFilePathRule.Replace("{$NodeDir}", nodeDir).Replace("{$Year}", year).Replace("{$Month}", month).Replace("{$Day}", day));
                                    truePath = HttpContext.Current.Server.MapPath(truePath);
                                    IOHelper.CreateDir(truePath);//创建目录
                                    newTruePath = Path.Combine(truePath, fileName);
                                    url = String.Format("{0}{1}/{2}/{3}", AS.Singleton.UploadUrl, AS.Singleton.UploadDir, AS.Singleton.UploadFilePathRule.Replace("{$NodeDir}", nodeDir).Replace("{$Year}", year).Replace("{$Month}", month).Replace("{$Day}", day), fileName);
                                }
                                fup.SaveAs(newTruePath);
                                r.Success = true;
                                r.Msg = "上传成功";
                                r.Data = new FileViewModel(DESEncrypt.Encrypt(url), url, null, null);//将图片URL加密成guid
                            }
                            else
                            {
                                r.Msg = "上传图片扩展名只允许为" + AS.Singleton.UploadImgExt;
                            }
                        }
                    }
                    else
                    {
                        r.Msg = "上传图片大小为0";
                    }
                }
                else
                {
                    r.Msg = "无上传图片权限";
                }
            }
            catch (UnauthorizedAccessException)
            {
                r.Msg = "文件系统权限不足";
            }
            catch (DirectoryNotFoundException)
            {
                r.Msg = "路径不存在";
            }
            catch (IOException)
            {
                r.Msg = "文件系统读取错误";
            }
            catch(Exception)
            {
                r.Msg = "上传出错";
            }
            finally
            {
                HttpContext.Current.Response.ContentType = "application/json";
                HttpContext.Current.Response.Write(new JavaScriptSerializer().Serialize(r));
                HttpContext.Current.Response.End();
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