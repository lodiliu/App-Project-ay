using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ADT.XingZhi.API.library
{
    public class Common
    {
        /// <summary>
        /// 根据图片路径获取图片的宽高
        /// </summary>
        /// <param name="url">图片地址</param>
        /// <returns></returns>
        public string GetWidthAndHeight(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            Stream s = request.GetResponse().GetResponseStream();

            byte[] b = new byte[74373];
            MemoryStream mes_keleyi_com = new MemoryStream(b);
            s.Read(b, 0, 74373);
            s.Close();
            Image image = Image.FromStream(mes_keleyi_com);
            string Height = image.Height.ToString();
            string Width = image.Width.ToString();
            Height = Height == "" ? "0" : Height;
            Width = Width == "" ? "0" : Width;
            return Width + "-" + Height;
        }
    }
}