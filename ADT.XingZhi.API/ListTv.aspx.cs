using ADT.CMS.Utility;
using ADT.XingZhi.API.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADT.XingZhi.API
{
    public partial class ListTv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //加载数据
        public string LoadInfo()
        {
            string type = RequestHelper.GetRequestString("type", "");
            string gender = RequestHelper.GetRequestString("gender", "");
            int pagesize = RequestHelper.GetRequestInt("pagesize", 10);
            int pageindex = RequestHelper.GetRequestInt("pageindex", 1);

            GetListController get = new GetListController();
            var responseJson = get.GetListByTV_Share(type, gender, pagesize, pageindex, 0);
            return responseJson.ToString();
        }
    }
}