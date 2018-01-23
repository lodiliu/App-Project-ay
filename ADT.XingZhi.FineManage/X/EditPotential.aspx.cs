using ADT.CMS.Utility;
using ADT.XingZhi.FineManage.Lib;
using ADT.XingZhi.Models.X;
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
    public partial class EditPotential : System.Web.UI.Page
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
        /// 加载数据
        /// </summary>
        private void LoadInfo()
        {
            int id = RequestHelper.GetRequestInt("id", 0);
            if (id > 0)
            {
                DataTable dt = operate.GetPotentialByID(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.txtPersonid.Text = HttpUtility.HtmlDecode(dt.Rows[0]["PersonID"].ToString());
                    this.txtPerson.Text = HttpUtility.HtmlDecode(dt.Rows[0]["PersonName"].ToString());
                    this.txtWorkName.Text = HttpUtility.HtmlDecode(dt.Rows[0]["WorkName"].ToString());
                    this.ddlWorkType.SelectedValue = HttpUtility.HtmlDecode(dt.Rows[0]["WorkType"].ToString());
                    this.txtDy.Text = HttpUtility.HtmlDecode(dt.Rows[0]["dy"].ToString());

                    this.txtZy.Text = HttpUtility.HtmlDecode(dt.Rows[0]["zy"].ToString());
                    this.txtWorkInfo.Text = HttpUtility.HtmlDecode(dt.Rows[0]["WorkInfo"].ToString());
                    this.txtRelease.Text = HttpUtility.HtmlDecode(dt.Rows[0]["Release"].ToString());
                    this.imgPhoto.ImageUrl = HttpUtility.HtmlDecode(dt.Rows[0]["ImgPath"].ToString());
                }
                else
                {
                    Alert.ShowInParent("读取数据失败！", String.Empty, ActiveWindow.GetHideReference());
                }
            }
        }

        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            filePhoto.Reset();

            Potential p = new Potential();
            p._PersonID = this.txtPersonid.Text;
            p._PersonName = this.txtPerson.Text;
            p._WorkName = this.txtWorkName.Text;
            p._WorkType = this.ddlWorkType.SelectedValue;
            p._dy = this.txtDy.Text;

            p._zy = this.txtZy.Text;
            p._WorkInfo = this.txtWorkInfo.Text;
            p._Release = this.txtRelease.Text;
            p._ImgPath = this.imgPhoto.ImageUrl;
            p._CreatedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            int flag = 0;
            int id = RequestHelper.GetRequestInt("id", 0);
            if (id > 0)
            {
                flag = operate.UpdatePotentialByID(p, id);
            }
            else
            {
                flag = operate.InsertPotential(p);
            }
            if (flag > 0)
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
        /// 照片选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void filePhoto_FileSelected(object sender, EventArgs e)
        {
            if (filePhoto.HasFile)
            {
                Int64 maxsize = Convert.ToInt64(ConfigurationManager.AppSettings["maxSize"].ToString());
                if (filePhoto.PostedFile.ContentLength > maxsize)
                {
                    Alert.ShowInParent("图片过大,请重新选择");
                    filePhoto.Reset();
                    imgPhoto.ImageUrl = "~/uploadworkphoto/blank.png";
                }
                else
                {
                    string fileName = filePhoto.ShortFileName;
                    string filetype = fileName.Split('.')[1].ToString().ToLower();
                    if (filetype != "jpeg" && filetype != "pjpeg" && filetype != "png" && filetype != "jpg")
                    {
                        Alert.Show("无效的文件类型！");
                        return;
                    }

                    fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                    fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                    string path = ConfigurationManager.AppSettings["workphoto"].ToString();
                    string root = AppDomain.CurrentDomain.BaseDirectory + path;
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    filePhoto.SaveAs(Server.MapPath("~/" + path + fileName));

                    imgPhoto.ImageUrl = "~/" + path + fileName;

                    // 清空文件上传组件
                    filePhoto.Reset();
                }
            }
        }

        /// <summary>
        /// 选择演员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChoose_Click(object sender, EventArgs e)
        {
            PageContext.RegisterStartupScript(Window1.GetSaveStateReference(txtPerson.ClientID, txtPersonid.ClientID)
        + Window1.GetShowReference("PersonList.aspx", "选择演员"));
        }
    }
}