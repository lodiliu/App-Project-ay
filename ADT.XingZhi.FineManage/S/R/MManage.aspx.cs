using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using System;
using System.Data;
using System.Linq;
using AspNet = System.Web.UI.WebControls;
using PermBLL = ADT.XingZhi.BLL.S.RoleMenuPurviewCode;

namespace ADT.XingZhi.FineManage.S.R
{
    public partial class MManage : BasePage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 
        private DataTable purviewCodeData = null;
        private int roleId = RequestHelper.GetRequestInt("id");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid2();
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SR,";
            base.OnPreLoad(e);
            //选择权限
            if (!VerifyPurview(",SR-CHECKMENU,"))
            {
                btnChangeCheckBox.Enabled = false;
                btnChangeCheckBox.ToolTip = "无权限操作此功能";
            }
            //更新权限
            if (!VerifyPurview(",SR-UPDATEMENU,"))
            {
                btnGroupUpdate.Enabled = false;
                btnGroupUpdate.ToolTip = "无权限操作此功能";
            }
        }
        private void BindGrid2()
        {
            try
            {  
                if (roleId > 0)
                {
                    using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "M_ID,M_NAME,M_CODE,M_LEVEL", "[S_MENU]", "WHERE M_DISABLED=0", "ORDER BY M_ORDERPATH ASC"))
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            purviewCodeData = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "MPC_NAME,MPC_CODE,M_ID", "S_MENU_PURVIEWCODE", "WHERE MPC_DISABLED=0", "ORDER BY MPC_ID ASC");
                            Grid2.DataSource = dt;
                            Grid2.DataBind();
                            InitPermission();
                        }
                    }
                }
                else
                {
                    Alert.ShowInParent("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                }
            }
            catch (Exception ex)
            {
                logger.Error("S.R.MManage.BindGrid2():Exception", ex);
                Alert.ShowInParent("系统错误。");
            }
        }

        #region Grid2 Events

        protected void Grid2_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            AspNet.CheckBoxList cblPurviewCodes = (AspNet.CheckBoxList)Grid2.Rows[e.RowIndex].FindControl("cblPurviewCodes");
            string mId = Grid2.DataKeys[e.RowIndex][0].ToString();
            cblPurviewCodes.Items.Add(new AspNet.ListItem("浏览", Grid2.DataKeys[e.RowIndex][1].ToString()));
            if (purviewCodeData != null && purviewCodeData.Rows.Count > 0)
            {
                DataRow[] drItem = purviewCodeData.Select("M_ID=" + mId);
                foreach (DataRow dr in drItem)
                {
                    cblPurviewCodes.Items.Add(new AspNet.ListItem(dr["MPC_NAME"].ToString(), dr["MPC_CODE"].ToString()));
                }
            }
        }

        protected void btnGroupUpdate_Click(object sender, EventArgs e)
        {
            //更新权限
            if (!VerifyPurview(",SR-UPDATEMENU,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            if (roleId > 0)
            {
                using (DataTable dt = new DataTable())
                {
                    dt.Columns.Add("r_id", typeof(int));
                    dt.Columns.Add("mpc_code", typeof(string));
                    foreach (GridRow row in Grid2.Rows)
                    {
                        AspNet.CheckBoxList cblPurviewCodes = (AspNet.CheckBoxList)Grid2.Rows[row.RowIndex].FindControl("cblPurviewCodes");
                        foreach (AspNet.ListItem item in cblPurviewCodes.Items)
                        {
                            if (item.Selected)
                            {
                                DataRow dr = dt.NewRow();
                                dr[0] = roleId;
                                dr[1] = item.Value;
                                dt.Rows.Add(dr);
                            }
                        }
                    }
                    int result = new PermBLL().BatchSave(dt, roleId);
                    if (result > 0)
                    {
                        Alert.ShowInParent("更新角色权限成功！", String.Empty, ActiveWindow.GetHideReference());
                    }
                    else
                    {
                        Alert.ShowInParent("更新角色权限失败");
                    }
                }
            }
        }
        protected void mbtnSelectAll_Click(object sender, EventArgs e)
        {
            MenuButton mbtn = sender as MenuButton;
            if (mbtn == mbtnSelectAll)
            {
                SelectAll(true);
            }
            else if (mbtn == mbtnSelectSelectedRow)
            {
                SelectAllSelected(true);
            }
        }
        protected void mbtnUnSelectAll_Click(object sender, EventArgs e)
        {
            MenuButton mbtn = sender as MenuButton;
            if (mbtn == mbtnUnSelectAll)
            {
                UnSelectAll();
            }
            else if (mbtn == mbtnUnSelectSelectedRow)
            {
                UnSelectAllSelected();
            }
        }
        protected void mbtnCancelSelectAll_Click(object sender, EventArgs e)
        {
            MenuButton mbtn = sender as MenuButton;
            if (mbtn == mbtnCancelSelectAll)
            {
                SelectAll(false);
            }
            else if (mbtn == mbtnCancelSelectSelectedRow)
            {
                SelectAllSelected(false);
            }
        }
        #region 设置复选框的状态
        /// <summary>
        /// 修改选中行复选框的状态
        /// </summary>
        /// <param name="selected"></param>
        private void SelectAllSelected(bool selected)
        {
            int[] selectedIndexs = Grid2.SelectedRowIndexArray;
            for (int i = 0; i < selectedIndexs.Length; i++)
            {
                SelectAllInRowIndex(selectedIndexs[i], selected);
            }
            Grid2.UpdateTemplateFields();
        }
        /// <summary>
        /// 修改全部复选框的状态
        /// </summary>
        /// <param name="selected"></param>
        private void SelectAll(bool selected)
        {
            for (int i = 0; i < Grid2.Rows.Count; i++)
            {
                SelectAllInRowIndex(i, selected);
            }
            Grid2.UpdateTemplateFields();
        }

        /// <summary>
        /// 修改某行复选框的状态
        /// </summary>
        private void SelectAllInRowIndex(int rowIndex, bool selected)
        {
            AspNet.CheckBoxList cblPurviewCodes = (AspNet.CheckBoxList)Grid2.Rows[rowIndex].FindControl("cblPurviewCodes");
            foreach (AspNet.ListItem item in cblPurviewCodes.Items)
            {
                item.Selected = selected;
            }
        }
        #endregion
        #region 反选复选框状态
        /// <summary>
        /// 反选选中行复选框的状态
        /// </summary>
        /// <param name="selected"></param>
        private void UnSelectAllSelected()
        {
            int[] selectedIndexs = Grid2.SelectedRowIndexArray;
            for (int i = 0; i < selectedIndexs.Length; i++)
            {
                UnSelectAllInRowIndex(selectedIndexs[i]);
            }
            Grid2.UpdateTemplateFields();
        }
        /// <summary>
        /// 反选全部复选框的状态
        /// </summary>
        /// <param name="selected"></param>
        private void UnSelectAll()
        {
            for (int i = 0; i < Grid2.Rows.Count; i++)
            {
                UnSelectAllInRowIndex(i);
            }
            Grid2.UpdateTemplateFields();
        }
        /// <summary>
        /// 反选某行复选框的状态
        /// </summary>
        private void UnSelectAllInRowIndex(int rowIndex)
        {
            AspNet.CheckBoxList cblPurviewCodes = (AspNet.CheckBoxList)Grid2.Rows[rowIndex].FindControl("cblPurviewCodes");
            foreach (AspNet.ListItem item in cblPurviewCodes.Items)
            {
                item.Selected = !item.Selected;
            }
        }
        #endregion
        /// <summary>
        /// 根据选中的角色初始化具有的权限选项为选中状态
        /// </summary>
        private void InitPermission()
        {
            if (roleId > 0)
            {
                using (DataTable dt = new PermBLL().GetPurviewCodeListByRoleId(roleId))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        var query = dt.AsEnumerable();
                        foreach (GridRow row in Grid2.Rows)
                        {
                            AspNet.CheckBoxList cblPurviewCodes = (AspNet.CheckBoxList)Grid2.Rows[row.RowIndex].FindControl("cblPurviewCodes");
                            foreach (AspNet.ListItem item in cblPurviewCodes.Items)
                            {
                                item.Selected = query.Where(dr => dr.Field<string>("MPC_CODE") == item.Value).Count() > 0;
                            }
                        }
                        Grid2.UpdateTemplateFields();
                    }
                    else
                    {
                        SelectAll(false);
                    }
                }
            }
        }

        #endregion
    }
}
