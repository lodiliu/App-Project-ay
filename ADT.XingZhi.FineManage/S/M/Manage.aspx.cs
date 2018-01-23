using System;
using System.Data;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using ADT.XingZhi.FineManage.Package;
using ModBLL = ADT.XingZhi.BLL.S.Menu;

namespace ADT.XingZhi.FineManage.S.M
{
    public partial class Manage : BasePage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = Window1.GetShowReference("Add.aspx", "新增菜单信息") + "return false;";
                BindData();
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SM,";
            base.OnPreLoad(e);
            //新增权限
            if (!VerifyPurview(",SM-ADD,"))
            {
                btnAdd.Enabled = false;
                btnAdd.ToolTip = "无权限操作此功能";
            }
            //编辑权限
            if (!VerifyPurview(",SM-EDIT,"))
            {
                Grid1.Columns[2].Enabled = false;
                Grid1.Columns[3].Hidden = true;
            }
            //设置权限项
            if (!VerifyPurview(",SM-SET,"))
            {
                Grid1.Columns[4].Hidden = true;
            }
            //排序权限
            if (!VerifyPurview(",SM-SORT,"))
            {
                Grid1.Columns[5].Hidden = true;
                Grid1.Columns[6].Hidden = true;
            }
        }
        private void BindData()
        {
            try
            {
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "M_ID,M_NAME,M_LEVEL,M_CODE,M_DISABLED", "[S_MENU]", String.Empty, "ORDER BY M_ORDERPATH ASC"))
                {
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                } 
            }
            catch (Exception ex)
            {
                logger.Error("S.M.Manage.BindData():Exception", ex);
                Alert.ShowInParent("系统错误。");
            }
        }
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "UDISABLED")
            {
                //编辑权限
                if (!VerifyPurview(",SM-EDIT,"))
                {
                    Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                    return;
                }
                CheckBoxField checkField = (CheckBoxField)Grid1.FindColumn(e.ColumnIndex);
                bool checkState = checkField.GetCheckedState(e.RowIndex);
                int result = new ModBLL().SetDisabled(Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0]), checkState);
                string tipText = (checkState ? "禁用" : "启用");
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
            else if (e.CommandName == "MoveUp")
            {
                //排序权限
                if (!VerifyPurview(",SM-SORT,"))
                {
                    Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                    return;
                }
                if (new ModBLL().ChangeSort(Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0]), SortType.MoveUp) > 0)
                {
                    BindData();
                }
            }
            else if (e.CommandName == "MoveDown")
            {
                //排序权限
                if (!VerifyPurview(",SM-SORT,"))
                {
                    Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                    return;
                }
                if (new ModBLL().ChangeSort(Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0]), SortType.MoveDown) > 0)
                { 
                    BindData();
                }
            }
        }
        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindData();
        }
    }
}
