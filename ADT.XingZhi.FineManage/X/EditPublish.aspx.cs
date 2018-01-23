using ADT.CMS.Utility;
using ADT.XingZhi.FineManage.Lib;
using ADT.XingZhi.FineManage.Package;
using FineUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADT.XingZhi.FineManage.X
{
    public partial class EditPublish : BasePage
    {
        Operate operate = new Operate();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInfo();
            }
        }

        /// <summary>
        /// 修改页面加载数据
        /// </summary>
        private void LoadInfo()
        {
            int id = RequestHelper.GetRequestInt("id", 0);
            if (id > 0)
            {
                DataTable dt = operate.GetPublishByID(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.txtTitle.Text = HttpUtility.HtmlDecode(dt.Rows[0]["Title_Name"].ToString());
                    this.ddlTtype.SelectedValue = HttpUtility.HtmlDecode(dt.Rows[0]["Title_Type"].ToString());
                    this.ddlCtype.SelectedValue = HttpUtility.HtmlDecode(dt.Rows[0]["Comment_Type"].ToString());
                    this.chkFlag.Checked = Convert.ToBoolean(HttpUtility.HtmlDecode(dt.Rows[0]["Flag"].ToString()));
                    this.htmlContent.Text = HttpUtility.HtmlDecode(dt.Rows[0]["Content"].ToString());
                    this.imgPhotoFM.ImageUrl = HttpUtility.HtmlDecode(dt.Rows[0]["CoverImg_Path"].ToString());
                    this.imgPhotoNR.ImageUrl = HttpUtility.HtmlDecode(dt.Rows[0]["Img_Path"].ToString());
                    ddlTtype_SelectedIndexChanged(null, null);
                }
                else
                {
                    Alert.ShowInParent("读取数据失败！", String.Empty, ActiveWindow.GetHideReference());
                }
            }
        }

        /// <summary>
        /// 照片选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void filePhotoFM_FileSelected(object sender, EventArgs e)
        {
            if (filePhotoFM.HasFile)
            {
                Int64 maxsize = Convert.ToInt64(ConfigurationManager.AppSettings["maxSize"].ToString());
                if (filePhotoFM.PostedFile.ContentLength > maxsize)
                {
                    Alert.ShowInParent("图片过大,请重新选择");
                    filePhotoFM.Reset();
                    imgPhotoFM.ImageUrl = "~/uploadworkphoto/blank.png";
                }
                else
                {
                    string fileName = filePhotoFM.ShortFileName;
                    string filetype = fileName.Split('.')[1].ToString().ToLower();
                    if (filetype != "jpeg" && filetype != "pjpeg" && filetype != "png" && filetype != "jpg")
                    {
                        Alert.Show("无效的文件类型！");
                        return;
                    }

                    fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                    fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                    string path = ConfigurationManager.AppSettings["publishphoto"].ToString();
                    string root = AppDomain.CurrentDomain.BaseDirectory + path;
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    filePhotoFM.SaveAs(Server.MapPath("~/" + path + fileName));

                    imgPhotoFM.ImageUrl = "~/" + path + fileName;

                    // 清空文件上传组件
                    filePhotoFM.Reset();
                }
            }
        }

        protected void filePhotoNR_FileSelected(object sender, EventArgs e)
        {
            if (filePhotoNR.HasFile)
            {
                Int64 maxsize = Convert.ToInt64(ConfigurationManager.AppSettings["maxSize"].ToString());
                if (filePhotoNR.PostedFile.ContentLength > maxsize)
                {
                    Alert.ShowInParent("图片过大,请重新选择");
                    filePhotoNR.Reset();
                    imgPhotoNR.ImageUrl = "~/uploadworkphoto/blank.png";
                }
                else
                {
                    string fileName = filePhotoNR.ShortFileName;
                    string filetype = fileName.Split('.')[1].ToString().ToLower();
                    if (filetype != "jpeg" && filetype != "pjpeg" && filetype != "png" && filetype != "jpg")
                    {
                        Alert.Show("无效的文件类型！");
                        return;
                    }

                    fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                    fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                    string path = ConfigurationManager.AppSettings["publishphoto"].ToString();
                    string root = AppDomain.CurrentDomain.BaseDirectory + path;
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    filePhotoNR.SaveAs(Server.MapPath("~/" + path + fileName));

                    imgPhotoNR.ImageUrl = "~/" + path + fileName;

                    // 清空文件上传组件
                    filePhotoNR.Reset();
                }
            }
        }

        //提交事件
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (this.imgPhotoFM.ImageUrl == "~/uploadworkphoto/blank.png")
            {
                Alert.ShowInParent("请上传封面图片");
                return;
            }
            if (this.imgPhotoNR.ImageUrl == "~/uploadworkphoto/blank.png")
            {
                Alert.ShowInParent("请上传内容图片");
                return;
            }

            int flag = 0;
            int id = RequestHelper.GetRequestInt("id", 0);
            if (id > 0)
            {
                flag = operate.UpdatePublish(id, txtTitle.Text, ddlTtype.SelectedValue, ddlCtype.SelectedValue, chkFlag.Checked, htmlContent.Text, imgPhotoFM.ImageUrl, imgPhotoNR.ImageUrl);
            }
            else
            {
                flag = operate.InsertPublish(txtTitle.Text, ddlTtype.SelectedValue, ddlCtype.SelectedValue, chkFlag.Checked, htmlContent.Text, imgPhotoFM.ImageUrl, imgPhotoNR.ImageUrl);
            }
            if (flag >= 1)
            {
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                Alert.ShowInParent("保存成功");
            }
            else
            {
                Alert.ShowInParent("保存失败");
            }
        }

        /// <summary>
        /// 发布类别选择修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlTtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ddlTtype.SelectedValue;
            if (value == "演员")
            {
                ddlCtype.Items[1].EnableSelect = false;//组讯 禁用
            }
            else if (value == "电视剧")
            {
                ddlCtype.Items[1].EnableSelect = true;
            }
        }

    }
}