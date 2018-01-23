using System;
using LogBLL = ADT.XingZhi.BLL.S.Log;

namespace ADT.XingZhi.FineManage.Package
{
    public class BasePage : System.Web.UI.Page
    {
        private LogBLL logBLL = new LogBLL();
        private static readonly string CHECK_POWER_FAIL_PAGE_MESSAGE = "您无权访问此页面！";  //无权限查看页面提示
        protected string CHECK_POWER_FAIL_ACTION_MESSAGE = "您无权进行此操作！"  //无操作权限提示
            , ViewPurviewCode = "0";  //页面查看权限编码
        protected ADT.XingZhi.Models.S.User currentUser = null;
        protected RABCCookie cookie = new RABCCookie();
        public BasePage()
        {
            this.Load += new EventHandler(BasePage_Load);
        }
        #region Method
        /// <summary>
        /// 验证权限是否存在
        /// </summary>
        /// <param name="purviewCode">权限编码</param>
        /// <returns></returns>
        protected bool VerifyPurview(string purviewCode)
        {
            return cookie.PurviewCodes.Contains(purviewCode);
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="action">动作</param>
        /// <param name="data">数据</param> 
        protected void AddLog(string action, string data)
        {
            logBLL.AddLog(action, Request.RawUrl, Request.HttpMethod, data, currentUser.Id, currentUser.Name);
        }
        #endregion
        #region Load
        public void BasePage_Load(Object sender, EventArgs e)
        {
            //Cookie为空，强行登录
            if (cookie.UserName.Length == 0)
            {
                Response.Write(ShowMassage.Html("请登录", "/default.aspx", true));
                Response.End();
            }
            if (cookie.PurviewCodes.Length == 0)
            {
                Response.Write(ShowMassage.Html("没有分配权限，请联系管理员", "/default.aspx", true));
                Response.End();
            }
            currentUser = new ADT.XingZhi.BLL.S.User().GetModelByUserName(cookie.UserName);
            if (currentUser == null)
            {
                Response.Write(ShowMassage.Html("请登录", "/default.aspx", true));
                Response.End();
            }
            if (currentUser.Disabled == true)  //该账户已被禁止登录，请重新登录
            {
                Response.Write(ShowMassage.Html("用户已被禁止登录，请联系管理员", "/default.aspx", true));
                Response.End();
            }
            if (ViewPurviewCode != "0" && !VerifyPurview(ViewPurviewCode))
            {
                //判断是否有查看页面权限
                if (!cookie.PurviewCodes.Contains(ViewPurviewCode))
                {
                    Response.Write(ShowMassage.Html(CHECK_POWER_FAIL_PAGE_MESSAGE));
                    Response.End(); 
                }
            }
        }
        #endregion
    }
}