using System;
using System.Data;
using ADT.CMS.Utility.Encrypt;
using FineUI;
using System.Text;
using ADT.CMS.Utility.Db;

namespace ADT.XingZhi.FineManage.Package
{
    public class ShowCommon
    {
        /// <summary>
        /// 显示上传的文件前置小图标
        /// </summary>
        /// <param name="extension">小写扩展名</param>
        /// <returns></returns>
        public static String ShowAttachmentIcon(string extension)
        {
            switch (extension)
            {
                case "gif":
                    return "/images/file_icon/gif.gif";
                case "jpg":
                case "jpeg":
                    return "/images/file_icon/jpg.gif";
                case "png":
                    return "/images/file_icon/png.gif";
                case "doc":
                    return "/images/file_icon/doc.gif";
                case "docx":
                    return "/images/file_icon/docx.gif";
                case "xls":
                    return "/images/file_icon/xls.gif";
                case "xlsx":
                    return "/images/file_icon/xlsx.gif";
                case "wps":
                    return "/images/file_icon/wps.gif";
                case "pdf":
                    return "/images/file_icon/pdf.gif";
                case "txt":
                    return "/images/file_icon/txt.gif";
                case "rar":
                case "zip":
                    return "/images/file_icon/rar.gif";
                default:
                    return "/images/file_icon/attach.png";
            }
        }
        /// <summary>
        /// 显示内容审核状态
        /// </summary>
        /// <param name="status">审核状态</param>
        /// <returns></returns>
        public static String ShowContentStatus(int status)
        {
            switch (status)
            {
                case -99:
                    return "草稿";
                case -1:
                    return "初审退稿";
                case -2:
                    return "二审退稿";
                case -3:
                    return "三审退稿";
                case -4:
                    return "终审退稿";
                case 0:
                    return "待审核";
                case 1:
                    return "初审通过，等待二审";
                case 2:
                    return "二审通过，等待三审";
                case 3:
                    return "三审通过，等待终审";
                case 4:
                    return "终审通过";
                default:
                    return String.Empty;
            }
        }
        /// <summary>
        /// 获取标记文本
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static String ShowContenFlag(string flag)
        {
            if (!string.IsNullOrEmpty(flag))
            {
                StringBuilder html = new StringBuilder("[<span class=\"red\">");
                if (flag.Contains("h"))
                {
                    html.Append("头条 ");
                }
                if (flag.Contains("r"))
                {
                    html.Append("推荐 ");
                }
                if (flag.Contains("f"))
                {
                    html.Append("幻灯 ");
                }
                if (flag.Contains("s"))
                {
                    html.Append("滚动 ");
                }
                if (flag.Contains("p"))
                {
                    html.Append("图片 ");
                }
                html.Length--;
                html.Append("</span>]");
                return html.ToString();
            }
            return String.Empty;
        }
        /// <summary>
        /// 区县名称格式化
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static String ShowDistrictName(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                return "<span class=\"blue\">[" + name + "]</span>";
            }
            return String.Empty;
        }
    }
}