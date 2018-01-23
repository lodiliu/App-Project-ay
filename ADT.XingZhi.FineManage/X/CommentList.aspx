<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentList.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.CommentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发布列表</title>
    <link href="../res/css/common.css" rel="stylesheet" type="text/css" />
    <style>
        .x-grid-row .x-grid-cell-inner {
            white-space: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Grid1" runat="server" />

        <f:Grid ID="Grid1" BoxFlex="1" PageSize="20" ShowBorder="false" ShowHeader="false"
            AllowPaging="true" runat="server" DataKeyNames="Id" OnPageIndexChange="Grid1_PageIndexChange"
            IsDatabasePaging="true" AllowSorting="true" SortDirection="ASC" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"
            SortField="a_id" EmptyText="没有符合条件的数据" EnableCollapse="true">
            <Columns>
                <f:BoundField Width="1px" TextAlign="Center" DataField="ID" HeaderText="序号" />
                <f:BoundField Width="10px" TextAlign="Center" DataField="Title_ID" HeaderText="标题ID" Hidden="true" />
                <f:BoundField ExpandUnusedSpace="true" Width="200px" HtmlEncode="false" TextAlign="left" DataField="comment" HeaderText="评论" />
                <f:BoundField Width="200px" TextAlign="Center" DataField="username" HeaderText="用户" />
                <f:BoundField Width="200px" TextAlign="Center" DataField="createdtime" HeaderText="发布时间" />
                <f:LinkButtonField CommandName="Delete" ConfirmText="消息将会被删除，确定删除？" ConfirmIcon="Question"
                    ConfirmTitle="提示" TextAlign="Center" Width="60px" HeaderText="删除" Icon="Delete" />
            </Columns>
            <PageItems>
                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                </f:ToolbarSeparator>
                <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数：">
                </f:ToolbarText>
                <f:DropDownList runat="server" ID="ddlPageSize" Width="80px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                    <f:ListItem Text="20" Value="20" />
                    <f:ListItem Text="40" Value="40" />
                    <f:ListItem Text="60" Value="60" />
                    <f:ListItem Text="80" Value="80" />
                </f:DropDownList>
            </PageItems>
        </f:Grid>
        <f:Window ID="Window1" EnableIFrame="true" IFrameUrl="about:blank" EnableMaximize="true"
            Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close" IsModal="true"
            Width="800px" Height="600px" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
