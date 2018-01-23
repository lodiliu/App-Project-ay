<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecommendList.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.RecommendList" %>

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
                        <f:Button ID="btnAdd" Text="新增" runat="server">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:BoundField Width="100px" TextAlign="Center" DataField="ID" HeaderText="序号" />
                <f:BoundField Width="200px" TextAlign="Center" DataField="TypeName" HeaderText="类别" />
                <f:BoundField ExpandUnusedSpace="true" Width="200px" TextAlign="Center" DataField="PersonName" HeaderText="演员名称" />
                <f:CheckBoxField ColumnID="CheckBoxField1" Width="80px" RenderAsStaticField="true"
                    DataField="Flag" HeaderText="是否启用" />
                <f:WindowField TextAlign="Center" HeaderText="修改" Title="修改" WindowID="Window1"
                    DataIFrameUrlFields="TypeName" DataIFrameUrlFormatString="EditRecommend.aspx?id={0}"
                    Width="100px" Icon="UserGo" />
                <f:CheckBoxField ColumnID="CheckBoxField2" Width="80px" RenderAsStaticField="false"
                    AutoPostBack="true" CommandName="CheckBox1" TextAlign="Center" DataField="Flag" HeaderText="启用" />
                <f:LinkButtonField CommandName="Delete" ConfirmText="将会被删除，确定删除？" ConfirmIcon="Question"
                    ConfirmTitle="提示" TextAlign="Center" HeaderText="删除" Width="100px" Icon="Delete" />
                <f:LinkButtonField CommandName="MoveUp" TextAlign="Center" Width="60px" Icon="ArrowUp"
                    HeaderText="上移" />
                <f:LinkButtonField CommandName="MoveDown" TextAlign="Center" Width="60px" Icon="ArrowDown"
                    HeaderText="下移" />
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
            Width="1200px" Height="750px" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
