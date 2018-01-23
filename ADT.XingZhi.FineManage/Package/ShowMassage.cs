using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ADT.XingZhi.FineManage.Package
{
    public class ShowMassage
    {
        public static string Html(string msg, string urlForward = "", bool isTop = false, int ms = 1250)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"/>");
            sb.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=7\" />");
            sb.Append("<title>提示信息</title>");
            sb.Append("<style type=\"text/css\">");
            sb.Append("*{ padding:0; margin:0; font-size:12px}");
            sb.Append("a:link,a:visited{text-decoration:none;color:#0068a6}");
            sb.Append("a:hover,a:active{color:#ff6600;text-decoration: underline}");
            sb.Append(".showMsg{border: 1px solid #1e64c8; zoom:1; width:450px; height:172px;position:absolute;top:44%;left:50%;margin:-87px 0 0 -225px}");
            sb.Append(".showMsg h5{background-image: url(/res/images/msg_img/msg.png);background-repeat: no-repeat; color:#fff; padding-left:35px; height:25px; line-height:26px;*line-height:28px; overflow:hidden; font-size:14px; text-align:left}");
            sb.Append(".showMsg .content{ padding:46px 12px 10px 45px; font-size:14px; height:64px; text-align:left}");
            sb.Append(".showMsg .bottom{ background:#e4ecf7; margin: 0 1px 1px 1px;line-height:26px; *line-height:30px; height:26px; text-align:center}");
            sb.Append(".showMsg .ok,.showMsg .guery{background: url(/res/images/msg_img/msg_bg.png) no-repeat 0px -560px;}");
            sb.Append(".showMsg .guery{background-position: left -460px;}");
            sb.Append("</style>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<div class=\"showMsg\" style=\"text-align:center\">");
            sb.Append("<h5>提示信息</h5>");
            sb.AppendFormat("<div class=\"content guery\" style=\"display:inline-block;display:-moz-inline-stack;zoom:1;*display:inline;max-width:330px\">{0}</div>", msg);
            sb.Append("<div class=\"bottom\">");
            if (urlForward == "")
            {
                //直接提示就OK，不做任何跳转
            }
            else if (urlForward == "goback")
            {
                sb.Append("<a href=\"javascript:history.back();\" >[点这里返回上一页]</a>");
            }
            else
            {
                sb.AppendFormat("<a href=\"{0}\">如果您的浏览器没有自动跳转，请点击这里</a>", urlForward);
                sb.Append("<script type=\"text/javascript\">");
                if (isTop)
                {
                    sb.AppendFormat("setTimeout(\"top.location.href ='{0}';\", {1});", urlForward, ms);
                }
                else
                {
                    sb.AppendFormat("setTimeout(\"location.href ='{0}';\", {1});", urlForward, ms);
                }
                sb.Append("</script>");
            }
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("</body></html>");
            return sb.ToString();
        }
    }
}