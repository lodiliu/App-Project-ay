<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ADT.XingZhi.FineManage.S.U.Edit" ValidateRequest="false" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>编辑用户信息</title>
    <link href="/res/css/resetext.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .x-form-text{padding:4px 6px 0 !important;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="10px" ShowBorder="false" ShowHeader="false"
        Layout="VBox" BoxConfigAlign="Stretch" AutoScroll="true">
        <Toolbars>
            <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Center" Position="Bottom">
                <Items>
                    <f:Button ID="btnSave" Text="确定修改" ValidateForms="Form2,Form3" runat="server"
                        OnClick="btnSave_Click" ValidateMessageBox="false">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="账号信息" runat="server">
                <Items>
                    <f:Form BodyPadding="10px" ID="Form2" EnableCollapse="true" runat="server" ShowHeader="false"
                        ShowBorder="false">
                        <Rows>
                            <f:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <f:TextBox ID="txtUName" Label="用户名" Required="true" ShowRedStar="true" runat="server"
                                        Regex="^[a-zA-Z0-9_\u4E00-\u9FA5\uF900-\uFA2D]+$" RegexMessage="账号只能由中文名、数字、26个英文字母或者下划线组成的字符串">
                                    </f:TextBox>
                                    <f:CheckBox ID="chkDisabled" Label="是否禁用" runat="server" Checked="true">
                                    </f:CheckBox>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="50% 50%">
                                <Items> 
                                    <f:TextBox ID="txtPwd" Label="初始口令" MaxLength="20" MinLength="6" Regex="^[A-Za-z0-9_!#$%^&*.~]{6,20}$" RegexMessage="密码只能由数字、26个英文字母、下划线或者特殊字符(!#$%^&*.~)组成的字符串" Required="true" ShowRedStar="true" runat="server">
                                    </f:TextBox>
                                    <f:Label ID="Label3" Text="注：初始口令可以在后台->系统基本配置->系统参数设置->初始口令设置" runat="server">
                                    </f:Label>
                                </Items>
                            </f:FormRow>
                            <f:FormRow>
                                <Items>
                                    <f:TriggerBox ID="tbSelectedRole" EnableEdit="false" EnablePostBack="false" TriggerIcon="Search"
                                        Label="分配系统角色" runat="server">
                                    </f:TriggerBox>
                                </Items>
                            </f:FormRow>
                        </Rows>
                    </f:Form>
                </Items>
            </f:GroupPanel>
            <f:GroupPanel ID="GroupPanel2" Margin="10px 0 0 0" Layout="Anchor" Title="个人信息" runat="server">
                <Items>
                    <f:Form BodyPadding="10px" ID="Form3" EnableCollapse="true" runat="server" ShowHeader="false"
                        ShowBorder="false">
                        <Rows>
                            <f:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <f:TextBox ID="txtVerityName" Label="真实姓名" Required="true" ShowRedStar="true" runat="server">
                                    </f:TextBox> 
                                    <f:TextBox ID="txtEmail" Label="电子邮箱" runat="server" RegexPattern="EMAIL">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow> 
                            <f:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <f:TextBox ID="txtMobile" Label="手机号码" EmptyText="用逗号分隔多值" runat="server">
                                    </f:TextBox>
                                    <f:TextBox ID="txtTel" Label="座机号码" EmptyText="用逗号分隔多值" runat="server">
                                    </f:TextBox>
                                </Items>
                            </f:FormRow>
                        </Rows>
                    </f:Form>
                </Items>
            </f:GroupPanel>
        </Items>
    </f:Panel>
    <f:HiddenField ID="hfSelectedRole" runat="server">
    </f:HiddenField>
    <f:Window ID="Window2" EnableIFrame="true" runat="server" EnableMaximize="true" EnableResize="true"
        Target="Top" IsModal="True" Width="260px" Height="500px" Hidden="true">
    </f:Window>
    </form>
</body>
</html>
