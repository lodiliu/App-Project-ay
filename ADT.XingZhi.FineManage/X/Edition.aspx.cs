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
    public partial class Edition : System.Web.UI.Page
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

        /// <summary>
        /// 绑定最后一条数据
        /// </summary>
        public void BindData()
        {
            try
            {
                StringBuilder condition = new StringBuilder("");
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "top 1 *", "[MS_Edition]", condition.ToString(), "ORDER BY createdtime desc"))
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.txtNumber.Text = dt.Rows[0]["version"].ToString();
                        this.txtEdition.Text = dt.Rows[0]["edition"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("X.MessageList.BindData():Exception", ex);
                Alert.ShowInParent("系统错误。");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int flag = operate.InsertEdition(this.txtNumber.Text, this.txtEdition.Text);
            if (flag >= 1)
            {
                Alert.ShowInParent("保存成功");
            }
            else
            {
                Alert.ShowInParent("保存失败");
            }
        }
    }
}