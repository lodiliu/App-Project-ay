using ADT.XingZhi.FineManage.Package;
using FineUI;
using System;
using System.Web;
using UserBLL = ADT.XingZhi.BLL.S.User;

namespace ADT.XingZhi.FineManage.S.U
{
    public partial class ModifyInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbName.Text = currentUser.Name;
                txtVerityName.Text = HttpUtility.HtmlDecode(currentUser.RealName);
                txtEmail.Text = HttpUtility.HtmlDecode(currentUser.Email);
                txtMobile.Text = HttpUtility.HtmlDecode(currentUser.Mobile);
                txtTel.Text = HttpUtility.HtmlDecode(currentUser.Tel);
                lbPT.Text = currentUser.PrevLoginTime.HasValue ? currentUser.PrevLoginTime.Value.ToString() : "";
                lbPIP.Text = HttpUtility.HtmlDecode(currentUser.PrevLoginIP);
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = "W0101";
            base.OnPreLoad(e);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string vName = HttpUtility.HtmlEncode(txtVerityName.Text.Trim());
            if (vName.Length == 0)
            {
                Alert.ShowInParent("真实姓名不能为空");
                return;
            }
            currentUser.RealName = vName;
            currentUser.Email = HttpUtility.HtmlEncode(txtEmail.Text.Trim());
            currentUser.Mobile = HttpUtility.HtmlEncode(txtMobile.Text.Trim());
            currentUser.Tel = HttpUtility.HtmlEncode(txtTel.Text.Trim());
            if (new UserBLL().ModifyInfo(currentUser) > 0)
            {
                Alert.ShowInParent("保存成功！");
            }
            else
            {
                Alert.ShowInParent("保存失败");
            }
        }
    }
}