using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using UserRoleBLL = ADT.XingZhi.BLL.S.RoleUser;

namespace ADT.XingZhi.FineManage.S.R
{
    public partial class AddUser : BasePage
    {
        private int roleId = RequestHelper.GetRequestInt("roleId", 0);
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SR,";
            base.OnPreLoad(e);
            //新增权限
            if (!VerifyPurview(",SR-ADDUSER,"))
            {
                btnSaveClose.Enabled = false;
            }
        }
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                BindGrid();
            }
        }
        private void BindGrid()
        {
            if (roleId > 0)
            {
                try
                {
                    StringBuilder condition = new StringBuilder("WHERE U_DISABLED=0");  //去除用户为系统管理员
                    condition.AppendFormat(" AND (SELECT COUNT(*) AS num FROM [S_ROLE_USER] b WHERE b.U_ID=a.U_ID AND R_ID={0})=0", roleId);
                    string name = StringHelper.ClearSqlStringExSpace(ttbSearchUser.Text.Trim());
                    if (name.Length > 0)
                    {
                        condition.AppendFormat(" AND (U_NAME like'%{0}%' OR U_REALNAME like'%{0}%')", name);
                    }
                    int recordCount = 0;
                    using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "U_ID,U_NAME,U_REALNAME,U_EMAIL,U_MOBILE", "[S_USER] a", condition.ToString(), "ORDER BY U_ID ASC", Grid1.PageIndex + 1, Grid1.PageSize, out recordCount))
                    {
                        Grid1.RecordCount = recordCount;
                        Grid1.DataSource = dt;
                        Grid1.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("S.R.AddUser.BindGrid():Exception", ex);
                    Alert.ShowInParent("系统错误。");
                }
                // 重新绑定表格数据之后，更新选中行
                FineUIGridCommon.UpdateSelectedRowIndexArray(hfSelectedIDS, Grid1);
            }
            else
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
            }
        }

        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (!VerifyPurview(",SR-ADDUSER,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            if (roleId > 0)
            {
                SyncSelectedRowIndexArrayToHiddenField();
                List<string> ids = FineUIGridCommon.GetSelectedIDsFromHiddenField(hfSelectedIDS);
                if (ids != null && ids.Count > 0)
                {
                    int result = 0;
                    using (DataTable dt = new DataTable())
                    {
                        dt.Columns.Add("roleid", typeof(int));
                        dt.Columns.Add("userid", typeof(int));
                        foreach (string userid in ids)
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = roleId;
                            dr[1] = userid;
                            dt.Rows.Add(dr);
                        }
                        result = new UserRoleBLL().BatchSave(dt);
                    }
                    if (result > 0)
                    {
                        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
                    }
                    else
                    {
                        Alert.ShowInParent("添加角色用户失败！");
                    }
                }
                else
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
                }
            }
            else
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
            }
        }

        private void SyncSelectedRowIndexArrayToHiddenField()
        {
            // 重新绑定表格数据之前，将当前表格页选中行的数据同步到隐藏字段中
            FineUIGridCommon.SyncSelectedRowIndexArrayToHiddenField(hfSelectedIDS, Grid1);
        }


        protected void ttbSearchUser_Trigger2Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();
            ttbSearchUser.ShowTrigger1 = true;
            BindGrid();
        }

        protected void ttbSearchUser_Trigger1Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();
            ttbSearchUser.Text = String.Empty;
            ttbSearchUser.ShowTrigger1 = false;
            BindGrid();
        }
        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void ddlGridPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();
            Grid1.PageSize = Convert.ToInt32(ddlGridPageSize.SelectedValue);
            BindGrid();
        }
        #endregion
    }
}
