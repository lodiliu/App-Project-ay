<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ADT.XingZhi.FineManage.S.M.Edit" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>编辑菜单信息</title> 
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Form2" runat="server" />
        <f:Form BodyPadding="10px" ID="Form2" EnableCollapse="true" runat="server" ShowHeader="false"
            ShowBorder="false">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Center" Position="Bottom">
                    <Items>
                        <f:Button ID="btnSave" Text="保存并关闭" ValidateForms="Form2" runat="server" OnClick="btnSave_Click" ValidateMessageBox="false">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtName" Label="菜单名称" Required="true" ShowRedStar="true" runat="server">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DropDownList ID="ddlParentId" runat="server" Label="所属菜单" Required="True" ShowRedStar="True"
                            AutoPostBack="false" EnableSimulateTree="True" EnableAjax="false">
                        </f:DropDownList>
                    </Items>
                </f:FormRow>
                <f:FormRow ColumnWidths="50% 50%">
                    <Items>
                        <f:TextBox ID="txtCode" Label="权益编码" MaxLength="10" Required="true" ShowRedStar="true" runat="server" Regex="^[0-9a-zA-Z]+$" RegexMessage="只能由26个英文字母或数字组成的字符串"></f:TextBox>
                        <f:CheckBox ID="chkDisabled" Label="是否禁用" runat="server">
                        </f:CheckBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtLinkUrl" Label="菜单链接" runat="server">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtIcon" Label="前置图标" MaxLength="20" runat="server" EmptyText="只需要写名称即可，如：default.png"></f:TextBox>
                        <f:Label ID="lb01" runat="server" Text="请先将图标存放在/res/Images/MenuIcon/目录下"></f:Label>
                    </Items>
                </f:FormRow> 
            </Rows>
        </f:Form>
    </form> 
</body>
</html>
