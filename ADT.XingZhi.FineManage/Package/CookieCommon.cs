using System;
using System.Configuration;
using System.Web;
using ADT.CMS.Utility.Encrypt;

namespace ADT.XingZhi.FineManage.Package
{
    public class CookieCommon
    {
        /// <summary>
        /// 读取COOKIE (非加密）
        /// </summary>
        /// <param name="strCookieName">CookieName名字</param>
        public static string GetCookieNoEncrypt(string strCookieName)
        {
            HttpCookie ck = HttpContext.Current.Request.Cookies[strCookieName];
            if (ck == null)
            {
                return String.Empty;
            }
            return ck.Value;
        }
        /// <summary>
        /// 设置COOKIE (非加密）
        /// </summary>
        /// <param name="strCookieName">Cookie名字</param>
        /// <param name="strCookieValue">Cookie值</param>
        public static void SetCookieNoEncrypt(string strCookieName, string strCookieValue)
        {
            if (HttpContext.Current.Request.Browser.Cookies)
            {
                HttpCookie ck = HttpContext.Current.Request.Cookies[strCookieName];
                if (ck == null)
                {
                    ck = new HttpCookie(strCookieName, strCookieValue);
                }
                else
                {
                    ck.Value = strCookieValue;
                }
                if (ConfigurationManager.AppSettings["domain"] != null)
                {
                    ck.Domain = ConfigurationManager.AppSettings["domain"];
                }
                HttpContext.Current.Response.Cookies.Add(ck);
            }
        }
        /// <summary>
        /// 读取COOKIE
        /// </summary>
        /// <param name="strCookieName">CookieName名字</param>
        public static string GetCookie(string strCookieName)
        {
            HttpCookie ck = HttpContext.Current.Request.Cookies[strCookieName];
            if (ck == null)
            {
                return String.Empty;
            }
            return DESEncrypt.Decrypt(ck.Value);
        }

        /// <summary>
        /// 设置COOKIE
        /// </summary>
        /// <param name="strCookieName">Cookie名字</param>
        /// <param name="strCookieValue">Cookie值</param>
        public static void SetCookie(string strCookieName, string strCookieValue)
        {
            if (HttpContext.Current.Request.Browser.Cookies)
            {
                HttpCookie ck = HttpContext.Current.Request.Cookies[strCookieName];
                if (ck == null)
                {
                    ck = new HttpCookie(strCookieName, DESEncrypt.Encrypt(strCookieValue));
                }
                else
                {
                    ck.Value = DESEncrypt.Encrypt(strCookieValue);
                }
                if (ConfigurationManager.AppSettings["domain"] != null)
                {
                    ck.Domain = ConfigurationManager.AppSettings["domain"];
                }
                HttpContext.Current.Response.Cookies.Add(ck);
            }
        }

        /// <summary>
        /// 设置COOKIE
        /// </summary>
        /// <param name="strCookieName">Cookie名字</param>
        /// <param name="strCookieValue">Cookie值</param>
        /// <param name="saveDay">Cookie保存的天数</param>
        public static void SetCookie(string strCookieName, string strCookieValue, int saveDay)
        {
            if (HttpContext.Current.Request.Browser.Cookies)
            {
                HttpCookie ck = HttpContext.Current.Request.Cookies[strCookieName];
                if (ck == null)
                {
                    ck = new HttpCookie(strCookieName, DESEncrypt.Encrypt(strCookieValue));
                }
                else
                {
                    ck.Value = DESEncrypt.Encrypt(strCookieValue);
                }
                ck.Expires = DateTime.Now.AddDays(saveDay);
                if (ConfigurationManager.AppSettings["domain"] != null)
                {
                    ck.Domain = ConfigurationManager.AppSettings["domain"];
                }
                HttpContext.Current.Response.Cookies.Add(ck);
            }
        }

        /// <summary>
        /// 移除客户端的Cookie
        /// </summary>
        /// <param name="sCookieName">CookieName名子</param>
        public static void ClearCookie(string strCookieName)
        {
            if (HttpContext.Current.Request.Browser.Cookies)
            {
                HttpCookie ck = HttpContext.Current.Request.Cookies[strCookieName];
                if (ck != null)
                {
                    ck.Expires = DateTime.Now.AddYears(-1);
                    if (ConfigurationManager.AppSettings["domain"] != null)
                    {
                        ck.Domain = ConfigurationManager.AppSettings["domain"];
                    }
                    HttpContext.Current.Response.Cookies.Add(ck);
                }
            }
        }
    }
}
