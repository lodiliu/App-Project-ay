using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using FineUI;
using System;
using System.Web;
using RoleBLL = ADT.XingZhi.BLL.S.Role;
using RoleModel = ADT.XingZhi.Models.S.Role;

namespace ADT.XingZhi.FineManage.S.R
{
    public partial class Save : BasePage
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
            ViewPurviewCode = ",SR,";
            base.OnPreLoad(e);
            //保存权限
            if (!VerifyPurview(",SR-SAVE,"))
            {
                btnSave.Enabled = btnSave2.Enabled = false;
                btnSave.ToolTip = btnSave2.ToolTip = "无权限操作此功能";
            }
        }
        private void LoadInfo()
        { 
            if (id > 0)
            {
                btnSave2.Visible = false;
                RoleModel model = new RoleBLL().GetModelById(id);
                if (model != null)
                {
                    txtName.Text = HttpUtility.HtmlDecode(model.Name);
                    txtOrderId.Text = model.OrderId.ToString();
                    txtDesc.Text = HttpUtility.HtmlDecode(model.Desc); 
                }
                else
                {
                    Alert.ShowInParent("读取数据失败！", String.Empty, ActiveWindow.GetHideReference());
                }
            }
            else
            {
                txtOrderId.Text = new RoleBLL().GetMaxOrderId().ToString();
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
            //保存权限
            if (!VerifyPurview(",SR-SAVE,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            string strErr = String.Empty;
            int num = 1;
            if (id < 0)
            {
                strErr += num + "、参数错误 <br />";
                num++;
            }
            string name = HttpUtility.HtmlEncode(txtName.Text.Trim());
            if (name.Length == 0)
            {
                strErr += num + "、角色名称不能为空 <br />";
            }
            if (strErr.Length > 0)
            {
                Alert.ShowInParent(strErr);
                return;
            }
            RoleModel model = new RoleModel();
            model.Id = id;
            model.Name = name;
            int orderId = 0;
            Int32.TryParse(txtOrderId.Text.Trim(), out orderId);
            model.OrderId = orderId;
            model.Desc = HttpUtility.HtmlEncode(txtDesc.Text.Trim());
            string tipTitle = model.Id == 0 ? "添加" : "修改";
            int result = new RoleBLL().Save(model);
            if (result > 0)
            {
                if (isClose)
                {
                    Alert.ShowInParent(tipTitle + "数据成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
                }
                else
                {
                    Alert.ShowInParent(tipTitle + "数据成功！");
                    PageContext.Refresh();
                }
            }
            else if (result == -10000)
            {
                Alert.ShowInParent("已存在该名称数据");
            }
            else
            {
                Alert.ShowInParent(tipTitle + "数据失败");
            }
        }
    }
}
