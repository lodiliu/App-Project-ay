<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ADT.XingZhi.FineManage.S.R.Manage" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>角色管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Grid1" runat="server" />
        <f:Grid ID="Grid1" BoxFlex="1" ShowBorder="false" ShowHeader="false"
            AllowPaging="false" runat="server" DataKeyNames="R_ID,R_NAME"
            EmptyText="没有符合条件的数据" IsDatabasePaging="false" OnRowCommand="Grid1_RowCommand">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button runat="server" ID="btnOrder" Text="排序设置" OnClick="btnOrder_Click">
                        </f:Button>
                        <f:Button ID="btnAdd" Text="新增" runat="server">
                        </f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
                        <f:TwinTriggerBox Width="400px" ID="ttbSearchKey" runat="server" ShowLabel="false"
                            EmptyText="在角色名称中搜索" Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false"
                            OnTrigger2Click="ttbSearchKey_Trigger2Click" OnTrigger1Click="ttbSearchKey_Trigger1Click">
                        </f:TwinTriggerBox>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField HeaderText="#" />
                <f:TemplateField HeaderText="排序" Width="100px" TextAlign="Center">
                    <ItemTemplate>
                        <asp:TextBox ID="tbOrder" runat="server" Width="80px" TabIndex='<%# Container.DataItemIndex + 10 %>'
                            Text='<%# Eval("R_ORDERID") %>'></asp:TextBox>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField DataField="R_NAME" Width="200px" HeaderText="角色名称" />
                <f:BoundField DataField="R_DESC" ExpandUnusedSpace="true" HeaderText="角色描述" />
                <f:WindowField TextAlign="Center" Width="120px" WindowID="Window1" HeaderText="权限设置"
                    Icon="Cog" DataIFrameUrlFields="R_ID" DataIFrameUrlFormatString="MManage.aspx?id={0}"
                    DataWindowTitleField="R_NAME" DataWindowTitleFormatString="设置《{0}》权限" />
                <f:WindowField TextAlign="Center" Width="120px" WindowID="Window1" HeaderText="成员管理"
                    Icon="Group" DataIFrameUrlFields="R_ID" DataIFrameUrlFormatString="UManage.aspx?id={0}"
                    Title="成员管理" />
                <f:WindowField TextAlign="Center" Width="60px" WindowID="Window1" HeaderText="编辑"
                    Icon="Pencil" DataIFrameUrlFields="R_ID" DataIFrameUrlFormatString="Save.aspx?id={0}"
                    Title="编辑角色信息" />
                <f:LinkButtonField CommandName="Delete" ConfirmText="角色信息以及相关信息将会被删除，确定删除？" ConfirmIcon="Question"
                    ConfirmTitle="提示" TextAlign="Center" Width="60px" HeaderText="删除" Icon="Delete" />
            </Columns>
        </f:Grid>
        <f:Window ID="Window1" EnableIFrame="true" IFrameUrl="about:blank" EnableMaximize="true"
            Target="Top" EnableResize="true" runat="server" OnClose="Window1_Close" IsModal="true"
            Width="1000px" Height="600px" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
