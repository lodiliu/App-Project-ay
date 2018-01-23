using System;
using System.Data;
using System.Text;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using ADT.XingZhi.FineManage.Package;
using RoleBLL = ADT.XingZhi.BLL.S.Role;

namespace ADT.XingZhi.FineManage.S.R
{
    public partial class Manage : BasePage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = Window1.GetShowReference("Save.aspx", "新增角色") + "return false;";
                BindData();
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SR,";
            base.OnPreLoad(e);
            //保存权限
            if (!VerifyPurview(",SR-SAVE,"))
            {
                btnAdd.Enabled = btnOrder.Enabled = false;
                btnAdd.ToolTip = btnOrder.ToolTip = "无权限操作此功能";
                Grid1.Columns[4].Hidden = true;
            }
            //删除权限
            if (!VerifyPurview(",SR-DEL,"))
            {
                Grid1.Columns[5].Hidden = true;
            }
        }
        private void BindData()
        {
            try
            {
                StringBuilder condition = new StringBuilder("WHERE 1=1");
                string key = StringHelper.ClearSqlStringExSpace(ttbSearchKey.Text.Trim());
                if (key.Length > 0)
                {
                    condition.AppendFormat(" AND [R_NAME] like '%{0}%'", key);
                }
                int recordCount = 0;
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "*", "[S_ROLE]", condition.ToString(), "ORDER BY R_ORDERID ASC", Grid1.PageIndex + 1, Grid1.PageSize, out recordCount))
                {
                    Grid1.RecordCount = recordCount;
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                } 
            }
            catch (Exception ex)
            {
                logger.Error("S.R.Manage.BindData():Exception", ex);
                Alert.ShowInParent("系统错误。");
            }
        }
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //删除权限
                if (!VerifyPurview(",SR-DEL,"))
                {
                    Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                    return;
                }
                int result = new RoleBLL().DeleteById(Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0]));
                if (result > 0)
                {
                    Alert.ShowInParent("删除成功");
                    BindData();
                }
                else
                {
                    Alert.ShowInParent("删除失败");
                }
            } 
        }
        protected void ttbSearchKey_Trigger2Click(object sender, EventArgs e)
        {
            ttbSearchKey.ShowTrigger1 = true;
            Grid1.PageIndex = 0;
            BindData();
        }

        protected void ttbSearchKey_Trigger1Click(object sender, EventArgs e)
        {
            ttbSearchKey.Text = String.Empty;
            ttbSearchKey.ShowTrigger1 = false;
            Grid1.PageIndex = 0;
            BindData();
        }
        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindData();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("oriderid", typeof(int));
                for (int i = 0, count = Grid1.Rows.Count; i < count; i++)
                { 
                    GridRow row = Grid1.Rows[i];
                    System.Web.UI.WebControls.TextBox tbOrder = (System.Web.UI.WebControls.TextBox)row.FindControl("tbOrder");
                    int orderid = 0;
                    Int32.TryParse(tbOrder.Text, out orderid);
                    DataRow dr = dt.NewRow();
                    dr[0] = Convert.ToInt32(Grid1.DataKeys[i][0]);
                    dr[1] = orderid;
                    dt.Rows.Add(dr);
                }
                new RoleBLL().UpdateOrderId(dt);
                BindData();
            }
        }
    }
}
