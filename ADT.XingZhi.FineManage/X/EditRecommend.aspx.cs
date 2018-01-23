using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using ADT.XingZhi.FineManage.Lib;
using ADT.XingZhi.FineManage.Package;
using ADT.XingZhi.Models.X;
using FineUI;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ADT.XingZhi.FineManage.X
{
    public partial class EditRecommend : BasePage
    {
        private static string txtid;
        private static string txtname;
        private static string txttype;

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Operate operate = new Operate();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();//绑定全部演员
                LoadInfo();//
            }
        }

        //编辑状态加载数据
        private void LoadInfo()
        {
            string type = RequestHelper.GetRequestString("id", "");
            txttype = type;
            this.Panel7.Title = "新增";
            if (!string.IsNullOrEmpty(type))
            {
                this.Panel7.Title = "修改";
                DataTable dt = operate.GetRecommendByTypeName(type);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.txtTypeName.Readonly = true;
                    this.txtTypeName.Text = HttpUtility.HtmlDecode(dt.Rows[0]["TypeName"].ToString());
                    this.chkFlag.Checked = Convert.ToBoolean(dt.Rows[0]["Flag"]);

                    var id = HttpUtility.HtmlDecode(dt.Rows[0]["PersonID"].ToString()).Split(',');
                    var name = HttpUtility.HtmlDecode(dt.Rows[0]["PersonName"].ToString()).Split(',');
                    string newhides = "[";
                    string newhidename = "[";
                    for (int i = 0; i < id.Length; i++)
                    {
                        newhides += "\"" + id[i].ToString() + "\",";
                        newhidename += "\"" + name[i].ToString() + "\",";
                    }
                    newhides = newhides.Substring(0, newhides.Length - 1);
                    newhidename = newhidename.Substring(0, newhidename.Length - 1);
                    newhides += "]";
                    newhidename += "]";
                    hides.Text = newhides;
                    hidename.Text = newhidename;
                    FineUIGridCommon.UpdateSelectedRowIndexArray(hides, Grid1);
                    FineUIGridCommon.SyncSelectedRowIndexArrayToHiddenField(hides, hidename, Grid1);
                    //BindData();
                    LoadGridChoose();

                }
                else
                {
                    Alert.ShowInParent("读取数据失败！", String.Empty, ActiveWindow.GetHideReference());
                }
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
                using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "*", "[view_person]", condition.ToString(), "ORDER BY CName asc", Grid1.PageIndex + 1, Grid1.PageSize, out recordCount))
                {
                    Grid1.RecordCount = recordCount;
                    Grid1.DataSource = dt;
                    Grid1.DataBind();
                    FineUIGridCommon.UpdateSelectedRowIndexArray(hides, Grid1);
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
            FineUIGridCommon.SyncSelectedRowIndexArrayToHiddenField(hides, hidename, Grid1);
            Grid1.PageIndex = e.NewPageIndex;
            BindData();
        }
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            FineUIGridCommon.SyncSelectedRowIndexArrayToHiddenField(hides, hidename, Grid1);
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

        // 确认事件
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            FineUIGridCommon.SyncSelectedRowIndexArrayToHiddenField(hides, hidename, Grid1);
            LoadGridChoose();
        }

        // 加载已经选择的演员
        public void LoadGridChoose()
        {
            txtid = hides.Text.Replace("[", "").Replace("]", "").Replace("\"", "");
            txtname = hidename.Text.Replace("[", "").Replace("]", "").Replace("\"", "");
            //this.txaChoosePerson.Text = txtname;
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(txtid))
            {
                string[] strid = txtid.Split(',');
                string[] strname = txtname.Split(',');

                dt.Columns.Add("personid", typeof(string));
                dt.Columns.Add("personname", typeof(string));
                for (int i = 0; i < strid.Length; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["personid"] = strid[i];
                    dr["personname"] = strname[i];
                    dt.Rows.Add(dr);
                }
            }
            GridChoose.DataSource = dt;
            GridChoose.DataBind();

            btnInput.OnClientClick = Window1.GetShowReference("ReasonForm.aspx?typename=" + txttype + "&id=" + txtid + "&name=" + txtname + "&isenable=" + chkFlag.Checked.ToString() +
                "&IsAdd=" + this.Panel7.Title, this.Panel7.Title);
        }

        // 保存事件
        protected void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                //新增保存
                if (this.Panel7.Title == "新增")
                {
                    txtid = hides.Text.Replace("[", "").Replace("]", "").Replace("\"", "");
                    if (string.IsNullOrEmpty(txtid))
                    {
                        Alert.ShowInParent("请选择演员");
                        return;
                    }
                    string flag = operate.InsertRecommend(this.txtTypeName.Text, txtid, "", this.chkFlag.Checked,"");
                    if (flag == "保存成功")//刷新列表
                    {
                        PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                        Alert.ShowInParent(flag);
                    }
                    else
                    {
                        Alert.ShowInParent(flag);
                    }
                }
                //修改保存
                else if (this.Panel7.Title == "修改")
                {
                    txtid = hides.Text.Replace("[", "").Replace("]", "").Replace("\"", "");
                    if (string.IsNullOrEmpty(txtid))
                    {
                        Alert.ShowInParent("请选择演员");
                        return;
                    }
                    string flag = operate.UpdateRecommend(this.txtTypeName.Text, txtid, "", this.chkFlag.Checked,"");
                    if (flag == "修改成功")//刷新列表
                    {
                        PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                        Alert.ShowInParent(flag);
                    }
                    else
                    {
                        Alert.ShowInParent(flag);
                    }
                }
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message.ToString());
            }
        }

        // 行事件
        protected void GridChoose_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string keyid = GridChoose.Rows[e.RowIndex].Values[0].ToString();
                var id = hides.Text.Replace("[", "").Replace("]", "").Replace("\"", "").Split(',').ToList();
                var name = hidename.Text.Replace("[", "").Replace("]", "").Replace("\"", "").Split(',').ToList();
                for (int i = 0; i < id.Count; i++)
                {
                    if (id[i].ToString() == keyid)
                    {
                        id.RemoveAt(i);
                        name.RemoveAt(i);
                    }
                }
                if (hides.Text.Length > 10)//有选择人的数据
                {
                    if (id.Count > 0)
                    {
                        string newhides = "[";
                        string newhidename = "[";
                        for (int i = 0; i < id.Count; i++)
                        {
                            newhides += "\"" + id[i].ToString() + "\",";
                            newhidename += "\"" + name[i].ToString() + "\",";
                        }
                        newhides = newhides.Substring(0, newhides.Length - 1);
                        newhidename = newhidename.Substring(0, newhidename.Length - 1);
                        newhides += "]";
                        newhidename += "]";
                        hides.Text = newhides;
                        hidename.Text = newhidename;
                    }
                    else
                    {
                        hides.Text = "";
                        hidename.Text = "";
                    }
                }
                FineUIGridCommon.UpdateSelectedRowIndexArray(hides, Grid1);
                FineUIGridCommon.SyncSelectedRowIndexArrayToHiddenField(hides, hidename, Grid1);
                BindData();
                LoadGridChoose();
            }
        }

        //类型修改事件
        protected void txtTypeName_TextChanged(object sender, EventArgs e)
        {
            txttype = this.txtTypeName.Text;
            btnInput.OnClientClick = Window1.GetShowReference("ReasonForm.aspx?typename=" + txttype + "&id=" + txtid + "&name=" + txtname + "&isenable=" + chkFlag.Checked.ToString() +
                "&IsAdd=" + this.Panel7.Title, this.Panel7.Title);
        }

    }
}