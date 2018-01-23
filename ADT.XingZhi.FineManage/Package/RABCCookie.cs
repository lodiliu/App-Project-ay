using System;
using System.Configuration;
using System.Web;
using ADT.CMS.Utility.Encrypt; 

namespace ADT.XingZhi.FineManage.Package
{
    public class RABCCookie
    {
        /// <summary>
        /// 添加登录用户名cookie
        /// </summary>
        /// <param name="userName">登录用户名</param>
        /// <param name="LoginTime">登录时间</param>
        /// <param name="day">保留天数</param>
        public void AddUserNameCookie(string userName, DateTime LoginTime, int day)
        {
            if (HttpContext.Current.Request.Browser.Cookies)
            {
                HttpCookie cookie = new HttpCookie("ADT.SportsRegistrationUN", DESEncrypt.Encrypt(userName));
                cookie.HttpOnly = true;
                if (day > 0)
                {
                    cookie.Expires = LoginTime.AddDays(day);
                }
                if (ConfigurationManager.AppSettings["domain"] != null)
                {
                    cookie.Domain = ConfigurationManager.AppSettings["domain"];
                }
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        /// <summary>
        /// 添加权限项Cookie
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="LoginTime">登录时间</param>
        /// <param name="day">保留天数</param>
        public void AddPurviewCodeCookie(string value, DateTime LoginTime, int day)
        {
            if (HttpContext.Current.Request.Browser.Cookies)
            {
                HttpCookie cookie = new HttpCookie("ADT.SportsRegistrationPC", DESEncrypt.Encrypt(value));
                cookie.HttpOnly = true;
                if (day > 0)
                {
                    cookie.Expires = LoginTime.AddDays(day);
                }
                if (ConfigurationManager.AppSettings["domain"] != null)
                {
                    cookie.Domain = ConfigurationManager.AppSettings["domain"];
                }
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        } 
        /// <summary>
        /// 清空Cookie
        /// </summary>
        public void ClearCookie()
        {
            if (HttpContext.Current.Request.Cookies["ADT.SportsRegistrationUN"] != null)
            {
                HttpCookie cookie = new HttpCookie("ADT.SportsRegistrationUN");
                if (ConfigurationManager.AppSettings["domain"] != null)
                    cookie.Domain = ConfigurationManager.AppSettings["domain"];
                cookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.AppendCookie(cookie);
            }
            if (HttpContext.Current.Request.Cookies["ADT.SportsRegistrationPC"] != null)
            {
                HttpCookie cookie = new HttpCookie("ADT.SportsRegistrationPC");
                if (ConfigurationManager.AppSettings["domain"] != null)
                    cookie.Domain = ConfigurationManager.AppSettings["domain"];
                cookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.AppendCookie(cookie);
            } 
        }
        /// <summary>
        /// 移除客户端的Cookie
        /// </summary>
        /// <param name="sCookieName">CookieName名子</param>
        public void ClearCookie(string strCookieName)
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
        /// <summary>
        /// 获取登录用户名COOKIE信息
        /// </summary>
        public string UserName
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["ADT.SportsRegistrationUN"] != null && HttpContext.Current.Request.Cookies["ADT.SportsRegistrationUN"].Value.Length > 0)
                {
                    return DESEncrypt.Decrypt(HttpContext.Current.Request.Cookies["ADT.SportsRegistrationUN"].Value);
                }
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取权限项
        /// </summary>
        public string PurviewCodes
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["ADT.SportsRegistrationPC"] != null && HttpContext.Current.Request.Cookies["ADT.SportsRegistrationPC"].Value.Length > 0)
                {
                    return DESEncrypt.Decrypt(HttpContext.Current.Request.Cookies["ADT.SportsRegistrationPC"].Value);
                }
                return string.Empty;
            }
        } 
    }
}
