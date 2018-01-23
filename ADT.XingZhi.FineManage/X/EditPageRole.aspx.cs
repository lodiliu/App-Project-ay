using ADT.CMS.Utility;
using ADT.XingZhi.FineManage.Lib;
using ADT.XingZhi.FineManage.Package;
using ADT.XingZhi.Models.X;
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
    public partial class EditPageRole : BasePage
    {
        Operate operate = new Operate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadInfo()
        {
            int id = RequestHelper.GetRequestInt("id", 0);
            if (id > 0)
            {
                DataTable dt = operate.GetPageRoleByID(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.txtPageCode.Text = HttpUtility.HtmlDecode(dt.Rows[0]["PageCode"].ToString());
                    this.txtCodeName.Text = HttpUtility.HtmlDecode(dt.Rows[0]["CodeName"].ToString());
                    this.chkFlag.Checked = Convert.ToBoolean(dt.Rows[0]["Flag"].ToString());
                }
                else
                {
                    Alert.ShowInParent("读取数据失败！", String.Empty, ActiveWindow.GetHideReference());
                }
            }
        }

        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ADT.XingZhi.Models.X.PageRole p = new Models.X.PageRole();
            p._PageCode = this.txtPageCode.Text;
            p._CodeName = this.txtCodeName.Text;
            p._Flag = this.chkFlag.Checked.ToString();
            int flag = 0;
            int id = RequestHelper.GetRequestInt("id", 0);
            if (id > 0)
            {
                flag = operate.UpdatePageRole(p, id);
            }
            else
            {
                flag = operate.InsertPageRole(p);
            }
            if (flag == 1)
            {
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                Alert.ShowInParent("保存成功");
            }
            else if (flag == 100)
            {
                Alert.ShowInParent("页面代码已被占用，请重新输入");
            }
            else
            {
                Alert.ShowInParent("保存失败");
            }
        }

    }
}