using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using System;
using System.Data;
using System.Text;
using System.Web;
using UserBLL = ADT.XingZhi.BLL.S.User;
using UserModel = ADT.XingZhi.Models.S.User;
using ADT.CMS.Utility.Encrypt;

namespace ADT.XingZhi.FineManage.S.U
{
    public partial class Edit : BasePage
    { 
        private int id = RequestHelper.GetRequestInt("id", 0);
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
            if (!VerifyPurview(",SU-EDIT,"))
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "无权限操作此功能";
            }
        }
        #region InitUserRole
        private void InitUserRole()
        {
            if (id > 0)
            {
                StringBuilder sbValue = new StringBuilder();
                StringBuilder sbText = new StringBuilder();

                 //初始化角色复选框列表的选择项
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "b.R_ID,b.R_NAME", "[S_ROLE_USER] a JOIN [S_ROLE] b ON a.R_ID=b.R_ID", "WHERE U_ID=" + id, "ORDER BY a.R_ID ASC"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow role in dt.Rows)
                        {
                            sbValue.AppendFormat("{0},", role["R_ID"]);
                            sbText.AppendFormat("{0}，", role["R_NAME"]);
                        }

                        string roleValues = sbValue.ToString().TrimEnd(',');
                        string roleTexts = sbText.ToString().TrimEnd('，');

                        tbSelectedRole.Text = roleTexts;
                        hfSelectedRole.Text = roleValues;
                    }
                }
            }
            string selectRoleURL = String.Format("SelectRole.aspx?ids=<script>{0}</script>", hfSelectedRole.GetValueReference());
            tbSelectedRole.OnClientTriggerClick = Window2.GetSaveStateReference(hfSelectedRole.ClientID, tbSelectedRole.ClientID)
                    + Window2.GetShowReference(selectRoleURL, "选择用户所属的角色");
        }
        #endregion
        private void LoadInfo()
        {
            InitUserRole();
            if (id > 0)
            {
                //用户为系统管理员则不允许修改，修改密码从修改密码地址进入修改
                if (id == 1) { ShowMassage.Html("不允许修改该用户资"); Response.End(); }
                UserModel model = new UserBLL().GetModelById(id);
                if (model != null)
                {
                    txtUName.Text = HttpUtility.HtmlDecode(model.Name);
                    txtVerityName.Text = HttpUtility.HtmlDecode(model.RealName); 
                    txtEmail.Text = HttpUtility.HtmlDecode(model.Email);
                    txtMobile.Text = HttpUtility.HtmlDecode(model.Mobile);
                    txtTel.Text = HttpUtility.HtmlDecode(model.Tel);
                    chkDisabled.Checked = model.Disabled;
                    txtUName.Enabled = false;
                    txtPwd.Required = false;
                    txtPwd.ShowRedStar = false;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //保存权限
            if (!VerifyPurview(",SU-EDIT,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            string strErr = String.Empty;
            int num = 1;
            if (id <= 0)
            {
                strErr += num + "、参数错误 <br />";
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
            UserModel model = new UserModel();
            model.Id = id;
            string pwd = HttpUtility.HtmlEncode(txtPwd.Text.Trim());
            if (pwd.Length > 0)
            {
                model.Encrypt = RandomHelper.CreateRandomStr(6);
                model.Pwd = MD5Encrypt.GetPass(pwd, model.Encrypt);
            }
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
                #endregion
                result = bll.Modify(model, roleDT);
            }
            if (result > 0)
            {
                Alert.ShowInParent("保存成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.ShowInParent("保存失败");
            }
        }
    }
}
