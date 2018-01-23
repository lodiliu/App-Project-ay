using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Encrypt;
using FineUI;
using System;
using UserBLL = ADT.XingZhi.BLL.S.User;

namespace ADT.XingZhi.FineManage.S.U
{
    public partial class ModifyPwd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbName.Text = currentUser.Name;
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = "W0102";
            base.OnPreLoad(e);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string oldPwd = MD5Encrypt.GetPass(txtOldPwd.Text.Trim(), currentUser.Encrypt);
            if (oldPwd == currentUser.Pwd)
            {
                string encrypt = RandomHelper.CreateRandomStr(6);
                string newPwd = MD5Encrypt.GetPass(txtNewPwdT.Text.Trim(), encrypt);
                int result = new UserBLL().ModifyPwd(currentUser.Id, newPwd, encrypt);
                txtOldPwd.Text = String.Empty;
                txtNewPwd.Text = String.Empty;
                txtNewPwdT.Text = String.Empty;
                if (result > 0)
                {
                    cookie.ClearCookie();
                    Alert.ShowInParent("修改密码成功，请重新登录", String.Empty, "top.location.href='/default.aspx'");
                }
                else
                {
                    Alert.ShowInTop("修改密码失败");
                }
            }
            else
            {
                Alert.ShowInTop("输入的旧密码错误");
            }
        }
    }
}