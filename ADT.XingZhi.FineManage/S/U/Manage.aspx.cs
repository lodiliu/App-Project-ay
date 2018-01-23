using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using System;
using System.Data;
using System.Text;
using UserBLL = ADT.XingZhi.BLL.S.User;

namespace ADT.XingZhi.FineManage.S.U
{
    public partial class Manage : BasePage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = Window1.GetShowReference("Add.aspx", "新增系统用户") + "return false;";
                BindData();
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SU,";
            base.OnPreLoad(e);
            //新增权限
            if (!VerifyPurview(",SU-ADD,"))
            {
                btnAdd.Enabled = false;
                btnAdd.ToolTip = "无权限操作此功能";
            }
            //查看权限
            if (!VerifyPurview(",SU-VIEW,"))
            {
                Grid1.Columns[9].Hidden = true;
            }
            //编辑权限
            if (!VerifyPurview(",SU-EDIT,"))
            {
                Grid1.Columns[3].Enabled = false;
                Grid1.Columns[10].Hidden = true;
            }
        }
        private void BindData()
        {
            try
            {
                StringBuilder condition = new StringBuilder("WHERE 1=1");  //去除用户为系统管理员
                string name = StringHelper.ClearSqlStringExSpace(ttbSearchUser.Text.Trim());
                if (name.Length > 0)
                {
                    condition.AppendFormat(" AND (U_NAME like'%{0}%' OR U_REALNAME like'%{0}%')", name);
                }
                string orderExp = "ORDER BY " + Grid1.SortField + " " + Grid1.SortDirection;
                int recordCount = 0;
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "U_ID,U_NAME,U_REALNAME,U_DISABLED,U_EMAIL,U_MOBILE,U_TEL,U_PREVLOGINTIME,U_PREVLOGINIP", "[S_USER]", condition.ToString(), orderExp, Grid1.PageIndex + 1, Grid1.PageSize, out recordCount))
                {
                    Grid1.RecordCount = recordCount;
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Error("S.U.Manage.BindData():Exception", ex);
                Alert.ShowInParent("系统错误。");
            }
        }
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "UDISABLED")
            {
                //上架操作权限
                if (!VerifyPurview(",SU-EDIT,"))
                {
                    Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                    return;
                }
                CheckBoxField checkField = (CheckBoxField)Grid1.FindColumn(e.ColumnIndex);
                bool checkState = checkField.GetCheckedState(e.RowIndex);
                int result = new UserBLL().SetDisabled(Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0]), checkState);
                string tipText = checkState ? "禁用" : "启用";
                if (result > 0)
                {
                    Alert.ShowInParent(tipText + "成功！");
                    BindData();
                }
                else
                {
                    Alert.ShowInParent(tipText + "失败！");
                }
            }
        }
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            Grid1.PageIndex = 0;
            BindData();
        }
        protected void Grid1_Sort(object sender, FineUI.GridSortEventArgs e)
        {
            Grid1.SortDirection = e.SortDirection;
            Grid1.SortField = e.SortField;
            BindData();
        }
        protected void ttbSearchUser_Trigger2Click(object sender, EventArgs e)
        {
            ttbSearchUser.ShowTrigger1 = true;
            Grid1.PageIndex = 0;
            BindData();
        }
        protected void ttbSearchUser_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearchUser.Text = String.Empty;
            ttbSearchUser.ShowTrigger1 = false;
            Grid1.PageIndex = 0;
            BindData();
        }
        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindData();
        }
    }
}
