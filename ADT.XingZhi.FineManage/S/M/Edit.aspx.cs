using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using System;
using System.Data;
using System.Web;
using ModBLL = ADT.XingZhi.BLL.S.Menu;
using ModModel = ADT.XingZhi.Models.S.Menu; 

namespace ADT.XingZhi.FineManage.S.M
{
    public partial class Edit : BasePage
    { 
        private int id = RequestHelper.GetRequestInt("id", 0);
        protected string pic = String.Empty, guid = String.Empty; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "M_ID,M_NAME,M_LEVEL", "[S_MENU]", "WHERE CHARINDEX ('," + id + ",',M_PATH)=0 AND M_DISABLED=0", "ORDER BY M_ORDERPATH ASC"))  //去除当前编辑的和所属它的子菜单
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ddlParentId.DataSource = dt;
                        ddlParentId.DataTextField = "M_NAME";
                        ddlParentId.DataValueField = "M_ID";
                        ddlParentId.DataSimulateTreeLevelField = "M_LEVE";
                        ddlParentId.DataBind();
                    }
                }
                ddlParentId.Items.Insert(0, new FineUI.ListItem("≡ 作为一级菜单 ≡", "0", true));
                LoadInfo();
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SM,";
            base.OnPreLoad(e);
            //保存权限
            if (!VerifyPurview(",SM-EDIT,"))
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "无权限操作此功能";
            }
        }
        private void LoadInfo()
        {
            if (id > 0)
            {
                ModModel model = new ModBLL().GetModelById(id);
                if (model != null)
                {
                    txtName.Text = HttpUtility.HtmlDecode(model.Name);
                    txtLinkUrl.Text = HttpUtility.HtmlDecode(model.Link);
                    txtCode.Text = HttpUtility.HtmlDecode(model.Code);
                    chkDisabled.Checked = model.Disabled;
                    ddlParentId.SelectedValue = model.ParentId.ToString();
                    txtIcon.Text = HttpUtility.HtmlDecode(model.Icon);
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
            if (!VerifyPurview(",SM-EDIT,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            string strErr = String.Empty;
            int num = 1, parentId = 0;
            if (id <= 0)
            {
                strErr += num + "、参数错误 <br />";
                num++;
            }
            string name = HttpUtility.HtmlEncode(txtName.Text.Trim());
            if (name.Length == 0)
            {
                strErr += num + "、请输入菜单名称 <br />";
                num++;
            }
            string code = HttpUtility.HtmlEncode(txtCode.Text.Trim());
            if (code.Length == 0)
            {
                strErr += num + "、请输入菜单权益编码 <br />";
                num++;
            }
            if (!Int32.TryParse(ddlParentId.SelectedValue, out parentId) || parentId < 0)
            {
                strErr += num + "、请选择所属菜单 <br />";
            }
            if (strErr.Length > 0)
            {
                Alert.ShowInParent(strErr);
                return;
            }
            ModModel model = new ModModel();
            model.Id = id;
            model.Name = name;
            model.ParentId = parentId;
            model.Code = code;
            model.Disabled = chkDisabled.Checked;
            model.Link = HttpUtility.HtmlEncode(txtLinkUrl.Text.Trim());
            model.Icon = HttpUtility.HtmlEncode(txtIcon.Text.Trim());
            int result = new ModBLL().Modify(model);
            if (result > 0)
            {
                Alert.ShowInParent("修改成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else if (result == -10000)
            {
                Alert.ShowInParent("同级菜单已存在该名称数据");
            }
            else
            {
                Alert.ShowInParent("修改数据失败");
            }
        }
    }
}
