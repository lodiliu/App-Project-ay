using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using System;
using System.Data;
using System.Text;
using System.Web;
using LogBLL = ADT.XingZhi.BLL.S.Log;
using UserBLL = ADT.XingZhi.BLL.S.User;
using UserModel = ADT.XingZhi.Models.S.User;
using ADT.CMS.Utility.Encrypt;

namespace ADT.XingZhi.FineManage
{
    public partial class _Default : System.Web.UI.Page
    {
        private LogBLL logBLL = new LogBLL();
        private UserBLL bll = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = RequestHelper.GetRequestString("action");
                if (action == "login")
                {
                    LoadLogin();
                } 
                else
                {
                    LoadData();
                }
            }
        }
        private void LoadData()
        {
            // 如果用户已经登录，则重定向到管理首页
            RABCCookie cookie = new RABCCookie();
            if (cookie.UserName.Length > 0)
            { 
                UserModel model = bll.GetModelByUserName(cookie.UserName);
                if (model != null && model.Disabled==false)
                {
                    bll.UpdateByLogin(model.Id, RequestHelper.GetIP());
                    //登录成功，保存至cookie
                    DateTime time = DateTime.Now;
                    cookie.AddUserNameCookie(model.Name, time, 0);
                    cookie.AddPurviewCodeCookie(bll.GetPurviewCodesByUserId(model.Id), time, 0);
                    logBLL.AddLog("登录", Request.RawUrl, Request.HttpMethod, "Session登录系统；结果：成功", model.Id, model.Name); 
                    //跳转至首页
                    Response.Write(ShowMassage.Html("登录成功", "index.aspx"));
                    Response.End();
                }
            }
        }
        #region Events

        private void LoadLogin()
        {
            string userName = HttpUtility.HtmlEncode(RequestHelper.GetRequestString("username"));
            string password = HttpUtility.HtmlEncode(RequestHelper.GetRequestString("userpwd"));
            //请填写完整
            if (userName.Length == 0 || password.Length == 0)
            {
                Response.Write(ShowMassage.Html("请填写完整", "default.aspx"));  
            }
            else
            {
                UserModel model = bll.GetModelByUserName(userName);
                if (model == null)
                {
                    logBLL.AddLog("登录", Request.RawUrl, Request.HttpMethod, "登录系统；结果：失败（用户名不存在）", 0, userName); 
                    Response.Write(ShowMassage.Html("用户名不存在", "default.aspx")); 
                }
                else
                {
                    if (model.Pwd == MD5Encrypt.GetPass(password, model.Encrypt))
                    {
                        if (model.Disabled == false)
                        {
                            bll.UpdateByLogin(model.Id, RequestHelper.GetIP());
                            //登录成功，保存至cookie
                            RABCCookie cookie = new RABCCookie();
                            DateTime time = DateTime.Now;
                            cookie.AddUserNameCookie(model.Name, time, 0);
                            cookie.AddPurviewCodeCookie(bll.GetPurviewCodesByUserId(model.Id), time, 0);
                            logBLL.AddLog("登录", Request.RawUrl, Request.HttpMethod, "登录系统；结果：成功", model.Id, model.Name); 
                            //跳转至首页
                            Response.Write(ShowMassage.Html("登录成功", "index.aspx"));
                        }
                        else
                        {
                            logBLL.AddLog("登录", Request.RawUrl, Request.HttpMethod, "登录系统；结果：失败（该用户状态为禁止登录）", model.Id, model.Name); 
                            Response.Write(ShowMassage.Html("该用户已经被禁止登录", "default.aspx"));
                        }
                    }
                    else
                    {
                        logBLL.AddLog("登录", Request.RawUrl, Request.HttpMethod, "登录系统；结果：失败（密码错误）", model.Id, model.Name); 
                        Response.Write(ShowMassage.Html("密码错误", "default.aspx"));
                    }
                }
            }
            Response.End();
        }
        #endregion
    }
}