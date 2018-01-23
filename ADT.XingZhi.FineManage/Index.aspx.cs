using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using System;
using System.Data;
using System.Text;

namespace ADT.XingZhi.FineManage
{
    public partial class Index : BasePage
    {
        protected StringBuilder menu = new StringBuilder();
        protected string userName = String.Empty;
        protected string ip = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = RequestHelper.GetRequestString("action");
            if (action == "logout")
            {
                if (cookie.UserName.Length > 0)
                {
                    cookie.ClearCookie();
                }
                AddLog("退出", "用户安全退出系统"); 
                Response.Write(ShowMassage.Html("安全退出成功", "default.aspx"));
                Response.End();
            }
            else
            {
                userName = currentUser.Name;
                ip = RequestHelper.GetIP();
                LoadFirstMenu();
            }
        }
        private void LoadFirstMenu()
        {
            using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "M_ID,M_NAME,M_CODE", "[S_MENU]", "where M_PARENTID=0 AND M_DISABLED=0", "ORDER BY M_ORDERID ASC"))
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    int index = 0;
                    for (int i = 0, count = dt.Rows.Count; i < count; i++)
                    {
                        if (VerifyPurview("," + dt.Rows[i]["M_CODE"] + ","))
                        {
                            if (index == 0)
                            {
                                Region2.IFrameUrl = "/leftmenu.aspx?menu=" + dt.Rows[i]["M_ID"];
                                menu.AppendFormat("<li class=\"on top_menu menu-{0}\"><a href=\"javascript:;\">{1}</a></li>", dt.Rows[i]["M_ID"], dt.Rows[i]["M_NAME"]);
                            }
                            else
                            {
                                menu.AppendFormat("<li class=\"top_menu menu-{0}\"><a href=\"javascript:;\">{1}</a></li>", dt.Rows[i]["M_ID"], dt.Rows[i]["M_NAME"]);
                            }
                            index++;
                        }
                    }
                } 
            }
        }
    }
}