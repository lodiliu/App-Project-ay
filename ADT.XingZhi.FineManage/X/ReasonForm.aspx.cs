using ADT.CMS.Utility;
using ADT.XingZhi.FineManage.Lib;
using ADT.XingZhi.FineManage.Package;
using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADT.XingZhi.FineManage.X
{
    public partial class ReasonForm : BasePage
    {

        Operate operate = new Operate();
        private static int len = 0;

        private static string IsAdd = string.Empty;
        private static string id = string.Empty;
        private static string name = string.Empty;
        private static string typename = string.Empty;
        private static string isenable = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // 动态创建控件
        // 注意：这段代码需要每次加载页面都执行，因此不能放在 if(!IsPostBack) 逻辑判断中
        protected void Page_Init(object sender, EventArgs e)
        {
            IsAdd = RequestHelper.GetRequestString("IsAdd", "");
            id = RequestHelper.GetRequestString("id", "");
            name = RequestHelper.GetRequestString("name", "");
            typename = RequestHelper.GetRequestString("typename", "");
            isenable = RequestHelper.GetRequestString("isenable", "");

            //非空判断
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(typename) || string.IsNullOrEmpty(isenable))
            {
                Alert.ShowInParent("请选择演员");
                return;
            }

            string[] strid = id.Split(',');
            string[] strname = name.Split(',');
            len = strname.Length;

            if (IsAdd.ToString() == "修改")
            {
                //获取理由
                DataTable dt = operate.GetRecommendByTypeNameEach(typename);
                // 创建一个 FormRow 控件并添加到 Form2
                for (int i = 0; i < len; i++)
                {
                    FormRow row = new FormRow();
                    row.ID = "rowUser" + i;
                    Form2.Rows.Add(row);
                    row.ColumnWidths = "50% 50%";

                    FineUI.TextBox tbxUser = new FineUI.TextBox();
                    FineUI.TextBox tbxWork = new FineUI.TextBox();
                    tbxUser.ID = "txtReason" + i;
                    tbxUser.Text = "";
                    tbxUser.Label = strname[i];
                    tbxUser.ShowLabel = true;
                    tbxUser.ShowRedStar = false;
                    tbxUser.Required = false;
                    tbxUser.MaxLength = 200;
                    tbxUser.EmptyText = "请输入推荐理由";

                    tbxWork.ID = "txtWork" + i;
                    tbxWork.Text = "";
                    tbxWork.Label = "作品";
                    tbxWork.ShowLabel = true;
                    tbxWork.ShowRedStar = false;
                    tbxWork.Required = false;
                    tbxWork.MaxLength = 30;
                    tbxWork.EmptyText = "请输入作品";
                    for (int m = 0; m < dt.Rows.Count; m++)
                    {
                        if (dt.Rows[m]["PersonID"].ToString() == strid[i])
                        {
                            tbxUser.Text = dt.Select(" PersonID='" + strid[i] + "' ")[0]["Reason"].ToString();
                            tbxWork.Text = dt.Select(" PersonID='" + strid[i] + "' ")[0]["Work"].ToString();
                        }
                    }

                    row.Items.Add(tbxUser);
                    row.Items.Add(tbxWork);

                }
            }
            else if (IsAdd.ToString() == "新增")
            {
                // 创建一个 FormRow 控件并添加到 Form2
                for (int i = 0; i < len; i++)
                {
                    FormRow row = new FormRow();
                    row.ID = "rowUser" + i;
                    Form2.Rows.Add(row);
                    row.ColumnWidths = "50% 50%";

                    FineUI.TextBox tbxUser = new FineUI.TextBox();
                    tbxUser.ID = "txtReason" + i;
                    tbxUser.Text = "";
                    tbxUser.Label = strname[i];
                    tbxUser.ShowLabel = true;
                    tbxUser.ShowRedStar = false;
                    tbxUser.Required = false;
                    tbxUser.MaxLength = 200;
                    tbxUser.EmptyText = "请输入推荐理由";
                    row.Items.Add(tbxUser);

                    FineUI.TextBox tbxWork = new FineUI.TextBox();
                    tbxWork.ID = "txtWork" + i;
                    tbxWork.Text = "";
                    tbxWork.Label = "作品";
                    tbxWork.ShowLabel = true;
                    tbxWork.ShowRedStar = false;
                    tbxWork.Required = false;
                    tbxWork.MaxLength = 30;
                    tbxWork.EmptyText = "请输入作品";
                    row.Items.Add(tbxWork);
                }
            }
        }

        //提交事件 
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string reasons = string.Empty;
                string works = string.Empty;
                for (int i = 0; i < len; i++)
                {
                    string rowid = "rowUser" + i;
                    string txtid = "txtReason" + i;
                    string workname = "txtWork" + i;

                    FormRow rowUser = Form2.FindControl(rowid) as FormRow;
                    FineUI.TextBox reason = rowUser.FindControl(txtid) as FineUI.TextBox;
                    FineUI.TextBox work = rowUser.FindControl(workname) as FineUI.TextBox;
                    //&符号拼接
                    reasons += reason.Text + "&";
                    works += work.Text + "&";
                }
                reasons = reasons.Substring(0, reasons.Length - 1);
                string flag = string.Empty;
                if (IsAdd.ToString() == "新增")
                {
                    flag = operate.InsertRecommend(typename, id, reasons, Convert.ToBoolean(isenable), works);
                }
                else if (IsAdd.ToString() == "修改")
                {
                    flag = operate.UpdateRecommend(typename, id, reasons, Convert.ToBoolean(isenable), works);
                }
                if (flag == "保存成功" || flag == "修改成功")
                {
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                    Alert.ShowInParent(flag);
                }
                else
                {
                    Alert.ShowInParent(flag);
                }
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message.ToString());
            }
        }
    }
}