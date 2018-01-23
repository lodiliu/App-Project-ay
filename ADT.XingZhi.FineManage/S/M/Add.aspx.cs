using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility.Db;
using FineUI;
using System;
using System.Data;
using System.Web;
using ModBLL = ADT.XingZhi.BLL.S.Menu;
using ModModel = ADT.XingZhi.Models.S.Menu;

namespace ADT.XingZhi.FineManage.S.M
{
    public partial class Add : BasePage
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "M_ID,M_NAME,M_LEVEL", "[S_MENU]", "WHERE M_DISABLED=0", "ORDER BY M_ORDERPATH ASC"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ddlParentId.DataSource = dt;
                        ddlParentId.DataTextField = "M_NAME";
                        ddlParentId.DataValueField = "M_ID";
                        ddlParentId.DataSimulateTreeLevelField = "M_LEVEL";
                        ddlParentId.DataBind();
                    }
                }
                ddlParentId.Items.Insert(0, new FineUI.ListItem("≡ 作为一级菜单 ≡", "0", true));
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SM,";
            base.OnPreLoad(e);
            //新增权限
            if (!VerifyPurview(",SM-ADD,"))
            {
                btnSave.Enabled = btnSave2.Enabled = false;
                btnSave.ToolTip = btnSave2.ToolTip = "无权限操作此功能";
            }
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
            //新增权限
            if (!VerifyPurview(",SM-ADD,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            string strErr = String.Empty;
            int num = 1, parentId = 0;
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
            model.Name = name;
            model.ParentId = parentId;
            model.Code = code;
            model.Disabled = chkDisabled.Checked;
            model.Link = HttpUtility.HtmlEncode(txtLinkUrl.Text.Trim());
            model.Icon = HttpUtility.HtmlEncode(txtIcon.Text.Trim());
            int result = new ModBLL().Add(model);
            if (result > 0)
            {
                if (isClose)
                {
                    Alert.ShowInParent("保存成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
                }
                else
                {
                    Alert.ShowInParent("保存成功！");
                    PageContext.Refresh();
                }
            }
            else if (result == -10000)
            {
                Alert.ShowInParent("同级菜单已存在该名称数据");
            }
            else
            {
                Alert.ShowInParent("保存失败");
            }
        }
    }
}
