using ADT.XingZhi.API.library;
using ADT.XingZhi.API.Package;
using ADT.XingZhi.FineManage.Lib;
using ADT.XingZhi.FineManage.Package;// .S.C.AttachmentConfig;
using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADT.XingZhi.FineManage.X
{
    public partial class AddMessage : BasePage
    {
        Operate operate = new Operate();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 提交 消息推送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int flag = operate.InsertMessage(this.txtMessageTitle.Text, this.txtMessage.Text, currentUser.Name);
            if (flag > 0)
            {
                Dictionary<string, object> extra = new Dictionary<string, object>();
                extra.Add("mid", flag);
                //极光推送消息
                var obj = JPush.SendPushJiGuang(this.txtMessageTitle.Text, this.txtMessage.Text, 0, extra, null);
                if (obj != null)
                {
                    this.txtMessageTitle.Text = "";
                    this.txtMessage.Text = "";
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                    Alert.ShowInParent("推送成功");
                }
                else
                    Alert.ShowInParent("推送失败");
            }
            else
            {
                Alert.ShowInParent("保存失败");
            }
        }
    }
}