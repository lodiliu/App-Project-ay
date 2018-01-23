using System;
using System.Data;
using System.Text;
using System.Web;
using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using FineUI;
using UserBLL = ADT.XingZhi.BLL.S.User;
using UserModel = ADT.XingZhi.Models.S.User;


namespace ADT.XingZhi.FineManage.SM.U
{
    public partial class ShowDetials : BasePage
    {
        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
                LoadInfo();
            }
        }
        protected override void OnPreLoad(EventArgs e)
        {
            //查看权限
            if (!VerifyPurview(",SU-VIEW,"))
            {
                Alert.ShowInParent("无查看权限！", String.Empty, ActiveWindow.GetHideReference());
            }
            base.OnPreLoad(e);
        }
        private void LoadInfo()
        {
            int id = RequestHelper.GetRequestInt("id", 0);
            if (id > 0)
            {
                UserModel model = new UserBLL().GetModelById(id);
                if (model != null)
                {
                    labName.Text = HttpUtility.HtmlDecode(model.Name);
                    labRealName.Text = HttpUtility.HtmlDecode(model.RealName);
                    labEmail.Text = HttpUtility.HtmlDecode(model.Email);
                    labMobile.Text = HttpUtility.HtmlDecode(model.Mobile);
                    labPhone.Text = HttpUtility.HtmlDecode(model.Tel);
                    imgShowStatus.Icon = model.Disabled ? Icon.Tick : Icon.BulletCross; 
                    StringBuilder sbText = new StringBuilder();
                    using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "R_NAME", "[S_ROLE_USER] a JOIN [S_ROLE] b ON b.R_ID=a.R_ID", "WHERE a.U_ID=" + id, "ORDER BY a.R_ID ASC"))
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            foreach (DataRow role in dt.Rows)
                            {
                                sbText.AppendFormat("{0}，", role["R_NAME"]);
                            }
                            labRole.Text = sbText.ToString().TrimEnd('，');
                        }
                    } 
                    labPT.Text = model.PrevLoginTime.HasValue ? model.PrevLoginTime.Value.ToString() : "";
                    labPIP.Text = HttpUtility.HtmlDecode(model.PrevLoginIP);
                    labLT.Text = model.LastLoginTime.HasValue ? model.LastLoginTime.Value.ToString() : "";
                    labLIP.Text = HttpUtility.HtmlDecode(model.LastLoginIP);
                    labLTS.Text = model.LoginTimes.ToString();
                    labCT.Text = model.CreateTime.Value.ToString();
                }
                else
                {
                    Alert.ShowInParent("读取数据失败！", String.Empty, ActiveWindow.GetHideReference());
                }
            }
            else
            {
                Alert.ShowInParent("参数错误！", String.Empty, ActiveWindow.GetHideReference());
            }
        }
        #endregion
    }
}