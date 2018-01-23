using ADT.CMS.Utility;
using ADT.XingZhi.FineManage.Lib;
using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADT.XingZhi.FineManage.X
{
    public partial class ShowMessage : System.Web.UI.Page
    {
        Operate operate = new Operate();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        private void LoadInfo()
        {
            int id = RequestHelper.GetRequestInt("id", 0);
            if (id > 0)
            {
                DataTable dt = operate.GetMessageByID(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    labtitle.Text = HttpUtility.HtmlDecode(dt.Rows[0]["title"].ToString());
                    labcontext.Text = HttpUtility.HtmlDecode(dt.Rows[0]["context"].ToString());
                }
                else
                {
                    Alert.ShowInParent("读取数据失败！", String.Empty, ActiveWindow.GetHideReference());
                }
            }
            else
            {
                Alert.ShowInParent("参数错误！", String.Empty, ActiveWindow.GetHideReference());
            }
        }
    }
}