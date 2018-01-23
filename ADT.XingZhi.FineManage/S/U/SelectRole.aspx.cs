using System;
using System.Data;
using System.Text;
using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;

namespace ADT.XingZhi.FineManage.S.U
{
    public partial class SelectRole : BasePage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                LoadData();
            }
        }

        private void LoadData()
        {
            string ids = RequestHelper.GetRequestString("ids");
            // 绑定角色复选框列表
            BindRole();
            if (ids.Length > 0)
            {
                // 初始化角色复选框列表的选择项
                cblRole.SelectedValueArray = ids.Split(',');
            }
        }

        private void BindRole()
        {
            try
            {
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "R_ID,R_NAME", "[S_ROLE]", String.Empty, "ORDER BY R_ORDERID ASC")) //去除系统管理员
                {
                    cblRole.DataTextField = "R_NAME";
                    cblRole.DataValueField = "R_ID";
                    cblRole.DataSource = dt;
                    cblRole.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Error("S.U.SelectRole.BindRole():Exception", ex);
                Alert.ShowInParent("系统错误。");
            }
        }

        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
                StringBuilder sbValue = new StringBuilder();
                StringBuilder sbText = new StringBuilder();
                foreach (CheckItem item in cblRole.SelectedItemArray)
                {
                    sbValue.AppendFormat("{0},", item.Value);
                    sbText.AppendFormat("{0}，", item.Text);
                }
                string roleValues = sbValue.ToString().TrimEnd(',');
                string roleTexts = sbText.ToString().TrimEnd('，');

                PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(roleValues, roleTexts)
                    + ActiveWindow.GetHideReference());
        }

        #endregion

    }
}
