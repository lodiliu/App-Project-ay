using ADT.XingZhi.FineManage.Package;
using ADT.CMS.Utility;
using ADT.CMS.Utility.Db;
using System;
using System.Data;

namespace ADT.XingZhi.FineManage
{
    public partial class LeftMenu : System.Web.UI.Page
    {
        private RABCCookie cookie = null;
        private string code = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int mid = RequestHelper.GetQueryInt("menu", 0);
                if (mid > 0)
                {
                    cookie = new RABCCookie();
                    if (cookie == null)
                    {
                        return;
                    }
                    if (cookie.UserName.Length == 0)
                    {
                        return;
                    }
                    if (cookie.PurviewCodes.Length == 0)
                    {
                        return;
                    }
                    code = cookie.PurviewCodes;
                    using (DataTable dt = SqlPagerHelper.GetTableByCondition(DefaultConnection.ConnectionStringByDefaultDB, "M_ID,M_PARENTID,M_NAME,M_CODE,M_LINK,M_ICON", "[S_MENU]", "WHERE M_ID<>" + mid + " AND M_PATH like '%," + mid + ",%' AND M_DISABLED=0", "ORDER BY M_ORDERID ASC"))
                    {
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            var source = dt.AsEnumerable(); 
                            ResolveSubTree(source, null, mid);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 生成菜单树
        /// </summary> 
        /// <param name="source">数据元</param>
        /// <param name="pNode">父节点</param>
        /// <param name="pid">父IP</param>
        /// <param name="first">是否是第一组</param>
        private void ResolveSubTree(EnumerableRowCollection<DataRow> source, FineUI.TreeNode pNode, int pid)
        {
            var query = from menu in source
                        where menu.Field<int>("M_PARENTID") == pid && code.Contains("," + menu.Field<string>("M_CODE") + ",") == true
                        select new
                        {
                            name = menu.Field<String>("M_NAME"),
                            link = menu.Field<String>("M_LINK"),
                            icon = menu.Field<String>("M_ICON"),
                            id = menu.Field<int>("M_ID")
                        };
            foreach (var dr in query)
            {
                FineUI.TreeNode node = new FineUI.TreeNode();
                node.Text = dr.name;
                if (!string.IsNullOrEmpty(dr.icon))
                {
                    node.IconUrl = "/res/images/menuicon/" + dr.icon;
                }
                if (dr.link.Length > 0)
                {
                    node.Target = "mainframe";
                    node.Leaf = true;
                    node.NavigateUrl = dr.link;
                }
                else
                {
                    node.Expanded = true;
                }
                if (pNode == null)
                {
                    leftTree.Nodes.Add(node);
                }
                else
                {
                    pNode.Nodes.Add(node);
                }
                ResolveSubTree(source, node, dr.id);
            }
        }
    }
}