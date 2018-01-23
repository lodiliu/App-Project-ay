using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using System;
using System.Data;
using System.Text;
using UserRoleBLL = ADT.XingZhi.BLL.S.RoleUser;

namespace ADT.XingZhi.FineManage.SM.R
{
    public partial class UManage : BasePage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int roleId = RequestHelper.GetRequestInt("id");
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SR,";
            base.OnPreLoad(e);
            //新增权限
            if (!VerifyPurview(",SR-ADDUSER,"))
            {
                btnNew.Enabled = false;
                btnNew.ToolTip = "无权限操作此功能";
            }
            //删除权限
            if (!VerifyPurview(",SR-DELUSER,"))
            {
                btnDeleteSelected.Enabled = false;
                btnDeleteSelected.ToolTip = "无权限操作此功能";
                gridUser.Columns[6].Hidden = true;
            }
        }

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridUser.PageIndex = 0; 
            BindUser();
        }
        private void LoadData()
        {
            FineUIGridCommon.ResolveDeleteButtonForGrid(btnDeleteSelected, gridUser, "确定要从当前角色中移除选中的{0}项记录吗？");
            BindUser(); 
        }
        private void BindUser()
        {
            try
            {
                if (roleId > 0)
                {
                    StringBuilder condition = new StringBuilder();
                    condition.AppendFormat("WHERE R_ID={0}", roleId);
                    string name = StringHelper.ClearSqlStringExSpace(ttbSearchUser.Text.Trim());
                    if (name.Length > 0)
                    {
                        condition.AppendFormat(" AND (U_NAME like'%{0}%' OR U_REALNAME like'%{0}%')", name);
                    }
                    int recordCount = 0;
                    using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "a.U_ID,U_NAME,U_REALNAME,U_EMAIL,U_MOBILE,U_TEL", "[S_ROLE_USER] a JOIN [S_USER] b ON a.U_ID=b.U_ID", condition.ToString(), "ORDER BY a.U_ID DESC", gridUser.PageIndex + 1, gridUser.PageSize, out recordCount))
                    {
                        gridUser.RecordCount = recordCount;
                        gridUser.DataSource = dt;
                        gridUser.DataBind();
                    }
                }
                else
                {
                    Alert.ShowInParent("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                }
            }
            catch (Exception ex)
            {
                logger.Error("S.R.UManage.BindUser():Exception", ex);
                Alert.ShowInParent("系统错误。");
            }
        }
        #endregion

        #region gridUser Events

        protected void ttbSearchUser_Trigger2Click(object sender, EventArgs e)
        {
            ttbSearchUser.ShowTrigger1 = true;
            gridUser.PageIndex = 0;
            BindUser();
        }
        protected void ttbSearchUser_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearchUser.Text = String.Empty;
            ttbSearchUser.ShowTrigger1 = false;
            gridUser.PageIndex = 0;
            BindUser();
        }
        private void DeleteTip(int result)
        {
            if (result > 0)
            {
                Alert.ShowInParent("删除成功");
                BindUser();
            }
            else
            {
                Alert.ShowInParent("删除失败");
            }
        }
        protected void gridUser_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridUser.PageIndex = e.NewPageIndex;
            BindUser();
        }
        protected void ddlGridPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridUser.PageSize = Convert.ToInt32(ddlGridPageSize.SelectedValue);
            gridUser.PageIndex = 0;
            BindUser();
        }
        protected void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            //删除权限
            if (!VerifyPurview(",SR-DELUSER,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            if (roleId > 0)
            {
                DeleteTip(new UserRoleBLL().BatchDelete(roleId, FineUIGridCommon.GetSelectedDataKeyToIndex(gridUser, 0)));
            }
        }
        protected void gridUser_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //删除权限
                if (!VerifyPurview(",SR-DELUSER,"))
                {
                    Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                    return;
                }
                if (roleId > 0)
                {
                    DeleteTip(new UserRoleBLL().Delete(roleId, Convert.ToInt32(gridUser.DataKeys[e.RowIndex][0])));
                }
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            //新增权限
            if (!VerifyPurview(",SR-ADDUSER,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            if (roleId > 0)
            {
                PageContext.RegisterStartupScript(Window1.GetShowReference("AddUser.aspx?roleId=" + roleId, "新增用户到当前角色"));
            }
        }

        #endregion

        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindUser();
        }
    }
}