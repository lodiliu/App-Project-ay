<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageList.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.MessageList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Grid1" runat="server" />

        <f:Grid ID="Grid1" BoxFlex="1" PageSize="20" ShowBorder="false" ShowHeader="false"
            AllowPaging="true" runat="server" DataKeyNames="Id" OnPageIndexChange="Grid1_PageIndexChange"
            IsDatabasePaging="true" AllowSorting="true" SortDirection="ASC" OnSort="Grid1_Sort" OnRowCommand="Grid1_RowCommand"
            SortField="a_id" EmptyText="没有符合条件的数据">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button runat="server" Text="新增" ID="btnAdd"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <%--<f:RowNumberField HeaderText="#" />--%>
                <f:BoundField Width="200px" TextAlign="Center" DataField="ID" HeaderText="序号" />
                <f:BoundField Width="200px" TextAlign="Center" DataField="title" HeaderText="标题名称" />
                <f:BoundField ExpandUnusedSpace="true" Width="150px" TextAlign="Center" DataField="context" HeaderText="内容" />
                <f:WindowField TextAlign="Center" HeaderText="查看" Title="查看详情" WindowID="Window1"
                    DataIFrameUrlFields="Id" DataIFrameUrlFormatString="ShowMessage.aspx?id={0}"
                    Width="60px" Icon="UserGo" />
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
        <f:Window ID="Window1" EnableIFrame="true" IFrameUrl="about:blank" EnableMaximize="false"
            Target="Top" EnableResize="false" runat="server" OnClose="Window1_Close" IsModal="true"
            Width="800px" Height="500px" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
