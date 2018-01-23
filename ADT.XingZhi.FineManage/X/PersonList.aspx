<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonList.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.PersonList" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>演员列表</title>

</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Grid1" runat="server" />
        <f:Grid ID="Grid1" BoxFlex="1" PageSize="20" ShowBorder="false" ShowHeader="false"
            AllowPaging="true" runat="server" DataKeyNames="personid,CName" OnPageIndexChange="Grid1_PageIndexChange"
            IsDatabasePaging="true" AllowSorting="true" SortDirection="ASC" OnSort="Grid1_Sort"
            SortField="a_id" EmptyText="没有符合条件的数据" EnableMultiSelect="false" EnableCollapse="true" EnableCheckBoxSelect="true">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:TwinTriggerBox Width="400px" ID="ttbSearchUser" runat="server" ShowLabel="false"
                            EmptyText="在名称中搜索" Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false"
                            OnTrigger2Click="ttbSearchUser_Trigger2Click" OnTrigger1Click="ttbSearchUser_Trigger1Click">
                        </f:TwinTriggerBox>
                        <f:Button ID="btnChoose" Text="选择" CssClass="marginr" runat="server" OnClick="btnChoose_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="50px" TextAlign="Center" DataField="ID" HeaderText="序号" />
                <f:BoundField Width="200px" TextAlign="Center" DataField="personid" HeaderText="演员ID" Hidden="true" />
                <f:BoundField Width="200px" TextAlign="Center" DataField="CName" HeaderText="名称" />
                <f:BoundField Width="200px" TextAlign="Center" DataField="School" HeaderText="毕业学校" />
                <f:BoundField ExpandUnusedSpace="true" Width="200px" TextAlign="Center" DataField="Company" HeaderText="经济公司" />
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
    </form>
</body>
</html>
