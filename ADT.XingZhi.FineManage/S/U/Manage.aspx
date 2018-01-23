<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ADT.XingZhi.FineManage.S.U.Manage" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>系统用户管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Grid1" runat="server" />
        <f:Grid ID="Grid1" BoxFlex="1" PageSize="20" ShowBorder="false" ShowHeader="false"
            AllowPaging="true" runat="server" DataKeyNames="U_ID" OnPageIndexChange="Grid1_PageIndexChange"
            IsDatabasePaging="true" AllowSorting="true" SortDirection="ASC" OnSort="Grid1_Sort"
            OnRowCommand="Grid1_RowCommand" SortField="U_ID" EmptyText="没有符合条件的数据">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnAdd" Text="新增" runat="server">
                        </f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
                        <f:TwinTriggerBox Width="400px" ID="ttbSearchUser" runat="server" ShowLabel="false"
                            EmptyText="在姓名或用户名中搜索" Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false"
                            OnTrigger2Click="ttbSearchUser_Trigger2Click" OnTrigger1Click="ttbSearchUser_Trigger1Click">
                        </f:TwinTriggerBox>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField HeaderText="#" />
                <f:BoundField ExpandUnusedSpace="true" DataField="U_NAME" SortField="U_NAME"
                    HeaderText="用户名" />
                <f:BoundField Width="100px" TextAlign="Center" DataField="U_REALNAME" SortField="U_REALNAME"
                    HeaderText="真实姓名" />
                <f:CheckBoxField ColumnID="cbfUDISABLED" CommandName="UDISABLED" Width="80px" DataField="U_DISABLED"
                    HeaderText="是否禁用" TextAlign="Center" RenderAsStaticField="false" AutoPostBack="true" />
                <f:BoundField Width="180px" DataField="U_EMAIL" HeaderText="电子邮箱" />
                <f:BoundField Width="140px" TextAlign="Center" DataField="U_MOBILE" HeaderText="手机号码" />
                <f:BoundField Width="140px" TextAlign="Center" DataField="U_TEL" HeaderText="座机号码" />
                <f:BoundField Width="150px" TextAlign="Center" DataField="U_PREVLOGINTIME" HeaderText="最近登录时间" />
                <f:BoundField Width="120px" TextAlign="Center" DataField="U_PREVLOGINIP" HeaderText="最近登录IP" />
                <f:WindowField TextAlign="Center" HeaderText="查看" Title="查看详情" WindowID="Window1"
                    DataIFrameUrlFields="U_ID" DataIFrameUrlFormatString="ShowDetials.aspx?id={0}"
                    Width="60px" Icon="UserGo" />
                <f:WindowField TextAlign="Center" Width="60px" WindowID="Window1" HeaderText="编辑"
                    DataIFrameUrlFields="U_ID" Icon="UserEdit" DataIFrameUrlFormatString="Edit.aspx?id={0}"
                    Title="编辑系统用户(不修改初始口令请保留空)" />
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
            Width="1000px" Height="500px" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
