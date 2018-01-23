using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using FineUI;
using System;
using System.Data;
using System.Web;
using UserBLL = ADT.XingZhi.BLL.S.User;
using UserModel = ADT.XingZhi.Models.S.User;
using ADT.CMS.Utility.Encrypt;

namespace ADT.XingZhi.FineManage.S.U
{
    public partial class Add : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SU,";
            base.OnPreLoad(e);
            //编辑权限
            if (!VerifyPurview(",SU-ADD,"))
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "无权限操作此功能";
            }
        }
        #region InitUserRole
        private void InitUserRole()
        {
            string selectRoleURL = String.Format("SelectRole.aspx?ids=<script>{0}</script>", hfSelectedRole.GetValueReference());
            tbSelectedRole.OnClientTriggerClick = Window2.GetSaveStateReference(hfSelectedRole.ClientID, tbSelectedRole.ClientID)
                    + Window2.GetShowReference(selectRoleURL, "选择用户所属的角色");
        }
        #endregion
        private void LoadInfo()
        {
            InitUserRole();
            //加载初始口令
            txtPwd.Text = new BLL.S.Config().GetValuesByKeyAndGroupId("InitPwd", 2);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData(true);
        }
        protected void btnSave2_Click(object sender, EventArgs e)
        {
            SaveData(false);
        }
        private void SaveData(bool isClose)
        {
            //保存权限
            if (!VerifyPurview(",SU-ADD,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            string strErr = String.Empty;
            int num = 1;
            string uName = HttpUtility.HtmlEncode(txtUName.Text.Trim());
            if (uName.Length == 0)
            {
                strErr += num + "、用户名不能为空 <br />";
                num++;
            }
            string pwd = HttpUtility.HtmlEncode(txtPwd.Text.Trim());
            if (pwd.Length == 0)
            {
                strErr += num + "、密码不能为空 <br />";
                num++;
            }
            string vName = HttpUtility.HtmlEncode(txtVerityName.Text.Trim());
            if (vName.Length == 0)
            {
                strErr += num + "、真实姓名不能为空 <br />";
            }
            if (strErr.Length > 0)
            {
                Alert.ShowInParent(strErr);
                return;
            }
            string encrypt = RandomHelper.CreateRandomStr(6);
            UserModel model = new UserModel();
            model.Id = 0;
            model.Name = uName;
            model.Pwd = MD5Encrypt.GetPass(pwd, encrypt);
            model.Encrypt = encrypt;
            model.RealName = vName; 
            model.Email = HttpUtility.HtmlEncode(txtEmail.Text.Trim());
            model.Mobile = HttpUtility.HtmlEncode(txtMobile.Text.Trim());
            model.Tel = HttpUtility.HtmlEncode(txtTel.Text.Trim());
            model.Disabled = chkDisabled.Checked;
            int result = 0;
            UserBLL bll = new UserBLL();
            using (DataTable roleDT = new DataTable())
            {
                roleDT.Columns.Add("roleid", typeof(int));
                roleDT.Columns.Add("userid", typeof(int));
                #region 角色用户
                string userRole = hfSelectedRole.Text.Trim();
                if (userRole.Length > 0)
                {
                    string[] userRoleArr = userRole.Split(',');
                    foreach (string s in userRoleArr)
                    {
                        DataRow dr = roleDT.NewRow();
                        dr[0] = Convert.ToInt32(s);
                        dr[1] = model.Id;
                        roleDT.Rows.Add(dr);
                    }
                }
                result = bll.Add(model, roleDT);
                #endregion
            }
            if (result > 0)
            {
                Alert.ShowInParent("保存成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else if (result == -10000)
            {
                Alert.ShowInParent("存在相同用户名的数据");
            }
            else
            {
                Alert.ShowInParent("保存失败");
            }
        }
    }
}
