using ADT.CMS.Utility.Db;
using ADT.XingZhi.FineManage.Lib;
using ADT.XingZhi.FineManage.Package;
using ADT.XingZhi.Models.X;
using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADT.XingZhi.FineManage.X
{
    public partial class PotentialList : BasePage
    {
        Operate operate = new Operate();
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = Window1.GetShowReference("EditPotential.aspx", "新增");
                BindData();
            }
        }

        //页面数据加载
        private void BindData()
        {
            try
            {
                StringBuilder condition = new StringBuilder("");

                int recordCount = 0;
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "*", "[view_Potential]", condition.ToString(), "ORDER BY ID desc", Grid1.PageIndex + 1, Grid1.PageSize, out recordCount))
                {
                    Grid1.RecordCount = recordCount;
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Error("X.MessageList.BindData():Exception", ex);
                Alert.ShowInParent("系统错误。");
            }
        }

        //行事件
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt32(Grid1.Rows[e.RowIndex].Values[0]);
                int flag = operate.DeletePotentialByID(id);
                if (flag >= 1)
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

        //关闭弹弹出框
        protected void Window1_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindData();
        }

        #region 固定的列表功能
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
        #endregion
    }
}