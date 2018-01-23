<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.Statistics" %>

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
                <f:RowNumberField Width="50px" TextAlign="center" HeaderText="#" />
                <f:BoundField ExpandUnusedSpace="true" Width="150px" TextAlign="Center" DataField="Key_Name" HeaderText="页面" />
                <f:BoundField Width="150px" TextAlign="Center" DataField="User_Name" HeaderText="用户" />
                <f:BoundField Width="150px" TextAlign="Center" DataField="CName" HeaderText="演员" />
                <f:BoundField Width="250px" TextAlign="Center" DataField="createdtime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="访问时间" />
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
