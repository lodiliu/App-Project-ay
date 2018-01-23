<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="ADT.XingZhi.FineManage.S.R.AddUser" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>角色选择用户</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Grid1" runat="server" />
        <f:Grid ID="Grid1" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="true"
            EmptyText="没有符合条件的数据" DataKeyNames="U_ID" AllowPaging="true" IsDatabasePaging="true"
            PageSize="15" OnPageIndexChange="Grid1_PageIndexChange" ClearSelectedRowsAfterPaging="false">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnSaveClose" OnClick="btnSaveClose_Click" runat="server" Text="确定选择">
                        </f:Button>
                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>
                        <f:TwinTriggerBox ID="ttbSearchUser" Width="400px" runat="server" ShowLabel="false"
                            EmptyText="在姓名或用户名中搜索" Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false"
                            OnTrigger2Click="ttbSearchUser_Trigger2Click" OnTrigger1Click="ttbSearchUser_Trigger1Click">
                        </f:TwinTriggerBox>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField HeaderText="#" />
                <f:BoundField DataField="U_NAME" Width="200px" HeaderText="用户名" />
                <f:BoundField DataField="U_REALNAME" Width="100px" HeaderText="姓名" TextAlign="Center" />
                <f:BoundField DataField="U_EMAIL" ExpandUnusedSpace="true" HeaderText="电子邮箱" />
                <f:BoundField DataField="U_MOBILE" Width="140px" HeaderText="电话号码" TextAlign="Center" />
            </Columns>
            <PageItems>
                <f:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                </f:ToolbarSeparator>
                <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数：">
                </f:ToolbarText>
                <f:DropDownList ID="ddlGridPageSize" Width="80px" AutoPostBack="true" OnSelectedIndexChanged="ddlGridPageSize_SelectedIndexChanged"
                    runat="server">
                    <f:ListItem Text="15" Value="15" />
                    <f:ListItem Text="30" Value="30" />
                    <f:ListItem Text="45" Value="45" />
                    <f:ListItem Text="60" Value="60" />
                </f:DropDownList>
            </PageItems>
        </f:Grid>
        <f:HiddenField ID="hfSelectedIDS" runat="server">
        </f:HiddenField>
    </form>
</body>
</html>
