using System;
using System.Text;
using FineUI;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ADT.XingZhi.FineManage.Package
{
    public class FineUIGridCommon
    {
        /// <summary>
        /// 获取表格选中项DataKeys的第X个值，并转化为利用“，”分割成字符串
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="index">索引(从0开始）</param>
        /// <returns></returns>
        public static string GetSelectedDataKeyToIndex(Grid grid, Int32 index)
        {
            if (index < 0)
            {
                return String.Empty;
            }
            StringBuilder str = new StringBuilder();
            foreach (int row in grid.SelectedRowIndexArray)
            {
                str.Append(grid.DataKeys[row][index]);
                str.Append(",");
            }
            return str.ToString();
        }
        /// <summary>
        /// 为删除Grid中选中项的按钮添加提示信息
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="grid"></param>
        public static void ResolveDeleteButtonForGrid(FineUI.Button btn, Grid grid)
        {
            ResolveDeleteButtonForGrid(btn, grid, "确定要删除选中的{0}项记录吗？");
        }

        public static void ResolveDeleteButtonForGrid(FineUI.Button btn, Grid grid, string confirmTemplate)
        {
            ResolveDeleteButtonForGrid(btn, grid, "请至少应该选择一项记录！", confirmTemplate);
        }

        public static void ResolveDeleteButtonForGrid(FineUI.Button btn, Grid grid, string noSelectionMessage, string confirmTemplate)
        {
            // 点击删除按钮时，至少选中一项
            btn.OnClientClick = grid.GetNoSelectionAlertInParentReference(noSelectionMessage);
            btn.ConfirmText = String.Format(confirmTemplate, "&nbsp;<span class=\"highlight\"><script>" + grid.GetSelectedCountReference() + "</script></span>&nbsp;");
            btn.ConfirmTarget = Target.Top;
        }

        #region GetSelectedIDsFromHiddenField/SyncSelectedRowIndexArrayToHiddenField/UpdateSelectedRowIndexArray

        /// <summary>
        /// 从隐藏字段中获取选择的全部ID列表
        /// </summary>
        /// <param name="hfSelectedIDS"></param>
        /// <returns></returns>
        public static List<string> GetSelectedIDsFromHiddenField(FineUI.HiddenField hfSelectedIDS)
        {
            JArray idsArray = new JArray();

            string currentIDS = hfSelectedIDS.Text.Trim();
            if (!String.IsNullOrEmpty(currentIDS))
            {
                idsArray = JArray.Parse(currentIDS);
            }
            else
            {
                idsArray = new JArray();
            }
            return new List<string>(idsArray.ToObject<string[]>());
        }

        /// <summary>
        /// 将表格当前页面选中行对应的数据同步到隐藏字段中
        /// </summary>
        /// <param name="hfSelectedIDS"></param>
        /// <param name="Grid1"></param>
        public static void SyncSelectedRowIndexArrayToHiddenField(FineUI.HiddenField hfSelectedIDS, Grid Grid1)
        {
            if (Grid1 != null && Grid1.Rows.Count > 0)
            {
                List<string> ids = GetSelectedIDsFromHiddenField(hfSelectedIDS);

                List<int> selectedRows = new List<int>();
                if (Grid1.SelectedRowIndexArray != null && Grid1.SelectedRowIndexArray.Length > 0)
                {
                    selectedRows = new List<int>(Grid1.SelectedRowIndexArray);
                }

                if (Grid1.IsDatabasePaging)
                {
                    for (int i = 0, count = Math.Min(Grid1.PageSize, (Grid1.RecordCount - Grid1.PageIndex * Grid1.PageSize)); i < count; i++)
                    {
                        string id = Grid1.DataKeys[i][0].ToString();
                        if (selectedRows.Contains(i))
                        {
                            if (!ids.Contains(id))
                            {
                                ids.Add(id);
                            }
                        }
                        else
                        {
                            if (ids.Contains(id))
                            {
                                ids.Remove(id);
                            }
                        }
                    }
                }
                else
                {
                    int startPageIndex = Grid1.PageIndex * Grid1.PageSize;
                    for (int i = startPageIndex, count = Math.Min(startPageIndex + Grid1.PageSize, Grid1.RecordCount); i < count; i++)
                    {
                        string id = Grid1.DataKeys[i][0].ToString();
                        if (selectedRows.Contains(i - startPageIndex))
                        {
                            if (!ids.Contains(id))
                            {
                                ids.Add(id);
                            }
                        }
                        else
                        {
                            if (ids.Contains(id))
                            {
                                ids.Remove(id);
                            }
                        }
                    }
                }
                hfSelectedIDS.Text = new JArray(ids).ToString(Formatting.None);
            }
        }

        public static void SyncSelectedRowIndexArrayToHiddenField(FineUI.HiddenField hfSelectedIDS, FineUI.HiddenField hfSelectedName, Grid Grid1)
        {
            if (Grid1 != null && Grid1.Rows.Count > 0)
            {
                List<string> ids = GetSelectedIDsFromHiddenField(hfSelectedIDS);
                List<string> idname = GetSelectedIDsFromHiddenField(hfSelectedName);

                List<int> selectedRows = new List<int>();
                if (Grid1.SelectedRowIndexArray != null && Grid1.SelectedRowIndexArray.Length > 0)
                {
                    selectedRows = new List<int>(Grid1.SelectedRowIndexArray);
                }

                if (Grid1.IsDatabasePaging)
                {
                    for (int i = 0, count = Math.Min(Grid1.PageSize, (Grid1.RecordCount - Grid1.PageIndex * Grid1.PageSize)); i < count; i++)
                    {
                        string id = Grid1.DataKeys[i][0].ToString();
                        string name = Grid1.DataKeys[i][2].ToString();
                        if (selectedRows.Contains(i))
                        {
                            if (!ids.Contains(id))
                            {
                                ids.Add(id);
                                idname.Add(name);
                            }
                        }
                        else
                        {
                            if (ids.Contains(id))
                            {
                                ids.Remove(id);
                                idname.Remove(name);
                            }
                        }
                    }
                }
                else
                {
                    int startPageIndex = Grid1.PageIndex * Grid1.PageSize;
                    for (int i = startPageIndex, count = Math.Min(startPageIndex + Grid1.PageSize, Grid1.RecordCount); i < count; i++)
                    {
                        string id = Grid1.DataKeys[i][0].ToString();
                        string name = Grid1.DataKeys[i][2].ToString();
                        if (selectedRows.Contains(i - startPageIndex))
                        {
                            if (!ids.Contains(id))
                            {
                                ids.Add(id);
                                idname.Add(name);
                            }
                        }
                        else
                        {
                            if (ids.Contains(id))
                            {
                                ids.Remove(id);
                                idname.Remove(name);
                            }
                        }
                    }
                }
                hfSelectedIDS.Text = new JArray(ids).ToString(Formatting.None);
                hfSelectedName.Text = new JArray(idname).ToString(Formatting.None);
            }
        }

        /// <summary>
        /// 根据隐藏字段的数据更新表格当前页面的选中行
        /// </summary>
        /// <param name="hfSelectedIDS"></param>
        /// <param name="Grid1"></param>
        public static void UpdateSelectedRowIndexArray(FineUI.HiddenField hfSelectedIDS, Grid Grid1)
        {
            if (Grid1 != null && Grid1.Rows.Count > 0)
            {
                List<string> ids = GetSelectedIDsFromHiddenField(hfSelectedIDS);

                List<int> nextSelectedRowIndexArray = new List<int>();
                if (Grid1.IsDatabasePaging)
                {
                    for (int i = 0, count = Math.Min(Grid1.PageSize, (Grid1.RecordCount - Grid1.PageIndex * Grid1.PageSize)); i < count; i++)
                    {
                        string id = Grid1.DataKeys[i][0].ToString();
                        if (ids.Contains(id))
                        {
                            nextSelectedRowIndexArray.Add(i);
                        }
                    }
                }
                else
                {
                    int nextStartPageIndex = Grid1.PageIndex * Grid1.PageSize;
                    for (int i = nextStartPageIndex, count = Math.Min(nextStartPageIndex + Grid1.PageSize, Grid1.RecordCount); i < count; i++)
                    {
                        string id = Grid1.DataKeys[i][0].ToString();
                        if (ids.Contains(id))
                        {
                            nextSelectedRowIndexArray.Add(i - nextStartPageIndex);
                        }
                    }
                }
                Grid1.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
            }
        }
        #endregion
    }
}
