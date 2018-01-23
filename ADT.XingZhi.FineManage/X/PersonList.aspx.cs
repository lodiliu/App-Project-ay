using ADT.CMS.Utility.Db;
using ADT.XingZhi.FineManage.Lib;
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
    public partial class PersonList : System.Web.UI.Page
    {
        Operate operate = new Operate();
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        //页面数据加载
        private void BindData()
        {
            try
            {
                StringBuilder condition = new StringBuilder();
                if (string.IsNullOrEmpty(this.ttbSearchUser.Text))
                {
                    condition.Append("");
                }
                else
                {
                    condition.Append(" where CName like'%" + this.ttbSearchUser.Text + "%' ");
                }
                int recordCount = 0;
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "*", "[view_person]", condition.ToString(), "ORDER BY ID asc", Grid1.PageIndex + 1, Grid1.PageSize, out recordCount))
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

        protected void btnChoose_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            int index = Grid1.SelectedRowIndex;
            if (index < 0)
            {
                Alert.ShowInParent("请选择演员");
                return;
            }
            string personid = Grid1.DataKeys[index][0].ToString();
            string personname = Grid1.DataKeys[index][1].ToString();
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(personname, personid) + ActiveWindow.GetHideReference());
        }
    }
}