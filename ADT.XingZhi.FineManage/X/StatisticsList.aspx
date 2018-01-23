<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatisticsList.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.StatisticsList" %>

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
            AllowPaging="true" runat="server" DataKeyNames="ID" OnPageIndexChange="Grid1_PageIndexChange"
            IsDatabasePaging="true" AllowSorting="true" SortDirection="ASC" OnSort="Grid1_Sort"
            SortField="a_id" EmptyText="没有符合条件的数据">
            <Columns>
                <%--<f:RowNumberField HeaderText="#" />--%>
                <f:BoundField Width="100px" TextAlign="Center" DataField="ID" HeaderText="序号" />
                <f:BoundField Width="150px" TextAlign="Center" DataField="Key_Code" HeaderText="页面ID" Hidden="true" />
                <f:BoundField ExpandUnusedSpace="true" Width="150px" TextAlign="Center" DataField="Key_Name" HeaderText="页面" />
                <f:BoundField Width="250px" TextAlign="Center" DataField="counts" HeaderText="次数" />
                <f:WindowField TextAlign="Center" HeaderText="详情" Title="查看详情" WindowID="Window1"
                    DataIFrameUrlFields="Key_Code" DataIFrameUrlFormatString="Statistics.aspx?id={0}"
                    Width="160px" Icon="UserGo" />
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
            Target="Top" EnableResize="false" runat="server" OnClose="Window1_Close" IsModal="true" EnableDrag="false"
            Width="800px" Height="615px" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
