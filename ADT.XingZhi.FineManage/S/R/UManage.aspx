<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UManage.aspx.cs" Inherits="ADT.XingZhi.FineManage.SM.R.UManage" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>角色用户</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="gridUser" runat="server" />
        <f:Grid ID="gridUser" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
            EnableCheckBoxSelect="true" DataKeyNames="U_ID" PageSize="20" AllowPaging="true"
            IsDatabasePaging="true" OnRowCommand="gridUser_RowCommand" OnPageIndexChange="gridUser_PageIndexChange">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnDeleteSelected" runat="server" Text="从当前角色中移除选中的用户" OnClick="btnDeleteSelected_Click">
                        </f:Button>
                        <f:Button ID="btnNew" runat="server" EnablePostBack="true" OnClick="btnNew_Click"
                            Text="新增用户到当前角色">
                        </f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
                        <f:TwinTriggerBox Width="300px" ID="ttbSearchUser" runat="server" ShowLabel="false"
                            EmptyText="在姓名或用户名中搜索" Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false"
                            OnTrigger2Click="ttbSearchUser_Trigger2Click" OnTrigger1Click="ttbSearchUser_Trigger1Click">
                        </f:TwinTriggerBox>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField HeaderText="#" />
                <f:BoundField DataField="U_NAME" ExpandUnusedSpace="true" HeaderText="用户名" />
                <f:BoundField DataField="U_REALNAME" Width="100px" HeaderText="真实姓名" /> 
                <f:BoundField DataField="U_EMAIL" Width="150px" HeaderText="电子邮箱" />
                <f:BoundField DataField="U_MOBILE" Width="120px" HeaderText="手机号码" />
                <f:BoundField DataField="U_TEL" Width="120px" HeaderText="座机号码" />
                <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" ToolTip="从当前角色中移除此用户"
                    ConfirmText="确定从当前角色中移除此用户？" ConfirmTarget="Top" CommandName="Delete" Width="50px"
                    HeaderText="移除" Icon="UserDelete" />
            </Columns>
            <PageItems>
                <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                </f:ToolbarSeparator>
                <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数：">
                </f:ToolbarText>
                <f:DropDownList ID="ddlGridPageSize" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="ddlGridPageSize_SelectedIndexChanged"
                    runat="server">
                    <f:ListItem Text="20" Value="20" />
                    <f:ListItem Text="40" Value="40" />
                    <f:ListItem Text="60" Value="60" />
                    <f:ListItem Text="80" Value="80" />
                </f:DropDownList>
            </PageItems>
        </f:Grid>
        <f:Window ID="Window1" CloseAction="Hide" runat="server" IsModal="true" Hidden="true"
            Target="Top" EnableResize="true" EnableMaximize="true" EnableIFrame="true" IFrameUrl="about:blank"
            Width="800px" Height="600px" OnClose="Window1_Close">
        </f:Window>
    </form>
</body>
</html>
