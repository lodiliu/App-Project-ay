<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ADT.XingZhi.FineManage.S.M.Manage" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>系统菜单管理</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="0" ShowBorder="false" ShowHeader="false"
        Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Grid ID="Grid1" BoxFlex="1" ShowBorder="false" ShowHeader="false" runat="server"
                DataKeyNames="M_ID,M_NAME" EmptyText="没有符合条件的数据" OnRowCommand="Grid1_RowCommand">
                <Toolbars>
                    <f:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <f:Button ID="btnAdd" Text="新增" runat="server">
                            </f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Columns>
                    <f:RowNumberField Width="40px" />
                    <f:BoundField DataField="M_NAME" DataSimulateTreeLevelField="M_LEVEL" ExpandUnusedSpace="true"
                        HeaderText="菜单名称" />
                    <f:CheckBoxField ColumnID="cbfUDISABLED" CommandName="UDISABLED" Width="80px" DataField="M_DISABLED"
                    HeaderText="是否禁用" TextAlign="Center" RenderAsStaticField="false" AutoPostBack="true" />
                    <f:WindowField TextAlign="Center" Width="60px" WindowID="Window1" Icon="Pencil" DataIFrameUrlFields="M_ID"
                        DataIFrameUrlFormatString="Edit.aspx?id={0}" HeaderText="编辑" Title="编辑菜单信息" />
                    <f:WindowField TextAlign="Center" Width="120px" WindowID="Window1" HeaderText="设置权限项"
                        DataIFrameUrlFields="M_ID,M_CODE" Icon="Cog" DataIFrameUrlFormatString="PCManage.aspx?id={0}&code={1}"
                        Title="设置菜单权限项" />
                    <f:LinkButtonField CommandName="MoveUp" TextAlign="Center" Width="60px" Icon="ArrowUp"
                        HeaderText="上移" />
                    <f:LinkButtonField CommandName="MoveDown" TextAlign="Center" Width="60px" Icon="ArrowDown"
                        HeaderText="下移" />
                </Columns>
            </f:Grid>
        </Items>
    </f:Panel>
    <f:Window ID="Window1" EnableIFrame="true" IFrameUrl="about:blank" EnableMaximize="true"
        Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close" IsModal="true"
        Width="800px" Height="400px" Hidden="true">
    </f:Window>
    </form>
</body>
</html>
