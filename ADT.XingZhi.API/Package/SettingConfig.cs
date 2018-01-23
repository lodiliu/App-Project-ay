using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ADT.XingZhi.API.Package
{
    public class SettingConfig
    {
        /// <summary>
        /// 图片地址
        /// </summary>
        public static string Url = ConfigurationManager.AppSettings["url"];
        public static string ImgUrl = ConfigurationManager.AppSettings["imgurl"];
        public static string MaxSize = ConfigurationManager.AppSettings["maxsize"];

        public static string MyImgUrl = ConfigurationManager.AppSettings["myimgurl"];
        public static string CodeUrl = ConfigurationManager.AppSettings["codeurl"];
        public static string ExlUrl = ConfigurationManager.AppSettings["exlurl"];

        /// <summary>
        /// 允许上传的图片类型
        /// </summary>
        public static string FileTypes = ConfigurationManager.AppSettings["fileTypes"];


        /// <summary>
        /// 
        /// </summary>
        public static string JApp_Key = ConfigurationManager.AppSettings["JApp_Key"];
        public static string JMaster_Secret = ConfigurationManager.AppSettings["JMaster_Secret"];
    }
}