<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPageRole.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.EditPageRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>潜力作品</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Form3" runat="server" />
        <f:Form ID="Form3" BodyPadding="10px" LabelWidth="160px" runat="server" ShowHeader="false" ShowBorder="false" AutoScroll="true">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Center" Position="Bottom">
                    <Items>
                        <f:Button ID="btnSubmit" Type="Submit" Text="保存并关闭" runat="server" ValidateForms="Form3" OnClick="btnSubmit_Click" ValidateMessageBox="false"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtPageCode" Label="页面代码" EmptyText="例如：01" runat="server" Required="true" ShowRedStar="true" MaxLength="200" CssStyle="margin-right:400px;"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtCodeName" Label="页面名称" EmptyText="例如：登录页面" runat="server" Required="true" ShowRedStar="true" MaxLength="200" CssStyle="margin-right:400px;"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:CheckBox runat="server" Checked="true" ID="chkFlag" Label="是否启用" AutoPostBack="false" Text=""></f:CheckBox>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
