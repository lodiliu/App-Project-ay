using System;
using System.Data;
using System.Web;
using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using PCBLL = ADT.XingZhi.BLL.S.MenuPurviewCode;
using PCModel = ADT.XingZhi.Models.S.MenuPurviewCode;

namespace ADT.XingZhi.FineManage.SM.M
{
    public partial class PCManage : BasePage
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int mid = RequestHelper.GetRequestInt("id");
        private string mcode = RequestHelper.GetRequestString("code");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            ViewPurviewCode = ",SM,";
            base.OnPreLoad(e);
            //设置权益
            if (!VerifyPurview(",SM-SET,"))
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "无权益操作此功能";
                Grid1.Columns[3].Enabled = false;
                Grid1.Columns[5].Hidden = true;
            }
        }
        private void BindData()
        {
            txtID.Text = "0";
            txtCode.Text = String.Empty;
            txtName.Text = String.Empty;
            chkDisabled.Checked = false;
            try
            {
                int recordCount = 0;
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "MPC_ID,MPC_NAME,MPC_CODE,MPC_DISABLED,M_NAME,M_CODE", "[S_MENU_PURVIEWCODE] mpc JOIN [S_MENU] m ON m.M_ID=mpc.M_ID", "WHERE mpc.M_ID=" + mid, "ORDER BY MPC_ID ASC", Grid1.PageIndex + 1, Grid1.PageSize, out recordCount))
                {
                    Grid1.RecordCount = recordCount;
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                }
            }
            catch (Exception ex)
            {
                logger.Error("S.M.PCManage.BindData():Exception", ex);
                Alert.ShowInParent("系统错误。");
            }
        }
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "UDISABLED")
            {
                //编辑权限
                if (!VerifyPurview(",SM-SET,"))
                {
                    Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                    return;
                }
                CheckBoxField checkField = (CheckBoxField)Grid1.FindColumn(e.ColumnIndex);
                bool checkState = checkField.GetCheckedState(e.RowIndex);
                int result = new PCBLL().SetDisabled(Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0]), checkState);
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
            if (e.CommandName == "Edit")
            {
                txtID.Text = Grid1.DataKeys[e.RowIndex][0].ToString();
                txtName.Text = HttpUtility.HtmlDecode(Grid1.DataKeys[e.RowIndex][1].ToString());
                txtCode.Text = HttpUtility.HtmlDecode(Grid1.DataKeys[e.RowIndex][2].ToString()).Split('-')[1];
                chkDisabled.Checked = Convert.ToBoolean(Grid1.DataKeys[e.RowIndex][3].ToString());
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //设置权益
            if (!VerifyPurview(",SM-SET,"))
            {
                Alert.ShowInParent(CHECK_POWER_FAIL_ACTION_MESSAGE);
                return;
            }
            if (mid <= 0 || mcode.Length == 0)
            {
                Alert.ShowInParent("参数错误");
                return;
            }
            string strErr = String.Empty;
            int num = 1;
            string name = HttpUtility.HtmlEncode(txtName.Text.Trim());
            if (name.Length == 0)
            {
                strErr += num + "、权益名称不能为空 <br />";
                num++;
            }
            string code = HttpUtility.HtmlEncode(txtCode.Text.Trim());
            if (code.Length == 0)
            {
                strErr += num + "、权益编码不能为空 <br />";
            }
            if (strErr.Length > 0)
            {
                Alert.ShowInParent(strErr);
                return;
            }
            PCModel model = new PCModel();
            model.Id = Convert.ToInt32(txtID.Text);
            model.Name = name;
            model.Code = mcode + "-" + code;
            model.MenuId = mid;
            model.Disabled = chkDisabled.Checked;
            string tipTitle = model.Id == 0 ? "添加" : "修改";
            int result = new PCBLL().Save(model);
            if (result > 0)
            {
                BindData();
            }
            else if (result == -10000)
            {
                Alert.ShowInParent("存在相同的权益编码");
            }
            else
            {
                Alert.ShowInParent(tipTitle + "数据失败");
            }
        }
    }
}
