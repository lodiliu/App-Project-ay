<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MManage.aspx.cs"
    Inherits="ADT.XingZhi.FineManage.S.R.MManage" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>角色菜单权限管理</title>
    <style type="text/css">
        .x-grid-tpl .others input {
            vertical-align: middle;
        } 
        .x-grid-tpl .others label {
            margin-left: 5px;
            margin-right: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Grid2" runat="server" />
        <f:Grid ID="Grid2" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
            EnableCheckBoxSelect="false" EmptyText="没有符合条件的数据" DataKeyNames="M_ID,M_CODE" OnRowDataBound="Grid2_RowDataBound"
            AllowPaging="false">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnChangeCheckBox" EnablePostBack="false" runat="server" Icon="Wrench" Text="改变复选框的状态">
                            <Menu ID="Menu1" runat="server">
                                <f:MenuButton ID="mbtnSelect" EnablePostBack="false" runat="server" Text="全选复选框">
                                    <Menu ID="Menu2" runat="server">
                                        <f:MenuButton ID="mbtnSelectAll" EnablePostBack="false" runat="server" Text="全部">
                                        </f:MenuButton>
                                        <f:MenuButton ID="mbtnSelectSelectedRow" EnablePostBack="false" runat="server" Text="选中的行">
                                        </f:MenuButton>
                                    </Menu>
                                </f:MenuButton>
                                <f:MenuButton ID="mbtnUnSelect" EnablePostBack="false" runat="server" Text="反选复选框">
                                    <Menu ID="Menu3" runat="server">
                                        <f:MenuButton ID="mbtnUnSelectAll" EnablePostBack="false" runat="server" Text="全部">
                                        </f:MenuButton>
                                        <f:MenuButton ID="mbtnUnSelectSelectedRow" EnablePostBack="false" runat="server"
                                            Text="选中的行">
                                        </f:MenuButton>
                                    </Menu>
                                </f:MenuButton>
                                <f:MenuButton ID="mbtnCancelSelect" EnablePostBack="false" runat="server" Text="取消复选框">
                                    <Menu ID="Menu4" runat="server">
                                        <f:MenuButton ID="mbtnCancelSelectAll" EnablePostBack="false" runat="server" Text="全部">
                                        </f:MenuButton>
                                        <f:MenuButton ID="mbtnCancelSelectSelectedRow" EnablePostBack="false" runat="server"
                                            Text="选中的行">
                                        </f:MenuButton>
                                    </Menu>
                                </f:MenuButton>
                            </Menu>
                        </f:Button>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </f:ToolbarSeparator>
                        <f:Button ID="btnGroupUpdate" runat="server" Text="更新当前角色的菜单权限" Icon="Cog" OnClick="btnGroupUpdate_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:RowNumberField HeaderText="#" />
                <f:BoundField DataField="M_NAME" HeaderText="菜单名称" DataSimulateTreeLevelField="M_LEVEL"
                    Width="200px" />
                <f:TemplateField ExpandUnusedSpace="true" HeaderText="权限">
                    <ItemTemplate>
                        <asp:CheckBoxList ID="cblPurviewCodes" CssClass="others" RepeatLayout="Flow" RepeatDirection="Horizontal"
                            runat="server">
                        </asp:CheckBoxList>
                    </ItemTemplate>
                </f:TemplateField>
            </Columns>
        </f:Grid>
        <f:Menu ID="Menu5" runat="server">
            <f:MenuButton ID="btnSelectRows" EnablePostBack="false" runat="server" Text="全选该行权限">
            </f:MenuButton>
            <f:MenuButton ID="btnUnselectRows" EnablePostBack="false" runat="server" Text="取消该行权限">
            </f:MenuButton>
        </f:Menu>
    </form>
    <script src="/res/editor/third-party/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var gridID = '<%= Grid2.ClientID %>';
        var btnSelectAll = '<% =mbtnSelectAll.ClientID %>';
        var btnSelectSelectedRow = '<% =mbtnSelectSelectedRow.ClientID %>';
        var btnUnSelectAll = '<% =mbtnUnSelectAll.ClientID %>';
        var btnUnSelectSelectedRow = '<% =mbtnUnSelectSelectedRow.ClientID %>';
        var btnCancelSelectAll = '<% =mbtnCancelSelectAll.ClientID %>';
        var btnCancelSelectSelectedRow = '<% =mbtnCancelSelectSelectedRow.ClientID %>';
        var menu5 = '<%= Menu5.ClientID %>';
        var selectRowsID = '<%= btnSelectRows.ClientID %>';
        var unselectRowsID = '<%= btnUnselectRows.ClientID %>';

        F.ready(function () {
            F(gridID).on('beforeitemcontextmenu', function (view, record, item, index, event) {
                F(menu5).showAt(event.getXY());
                event.stopEvent();
            });
            F(btnSelectAll).on('click', function () {
                $('input[type=checkbox]').prop("checked", "checked");
            });
            F(btnSelectSelectedRow).on('click', function () {
                $('.x-grid-row-selected input[type=checkbox]').prop("checked", "checked");
            });
            F(btnUnSelectAll).on('click', function () {
                $('input[type=checkbox]').each(function () {
                    $(this).prop("checked", !($(this).prop("checked")));
                });
            });
            F(btnUnSelectSelectedRow).on('click', function () {
                $('.x-grid-row-selected input[type=checkbox]').each(function () {
                    $(this).prop("checked", !($(this).prop("checked")));
                });
            });
            F(btnCancelSelectAll).on('click', function () {
                $('input[type=checkbox]').prop("checked", "");
            });
            F(btnCancelSelectSelectedRow).on('click', function () {
                $('.x-grid-row-selected input[type=checkbox]').prop("checked", "");
            });
            F(selectRowsID).on('click', function () {
                $('.x-grid-row-selected input[type=checkbox]').prop("checked", "checked");
            });
            F(unselectRowsID).on('click', function () {
                $('.x-grid-row-selected input[type=checkbox]').prop("checked", "");
            });
        });
    </script>
</body>
</html>
