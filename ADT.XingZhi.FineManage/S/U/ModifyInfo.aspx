<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyInfo.aspx.cs" Inherits="ADT.XingZhi.FineManage.S.U.ModifyInfo" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修改档案</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Form2" runat="server" />
        <f:Form BodyPadding="10px" ID="Form2" runat="server" ShowHeader="false" ShowBorder="false">
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:Label ID="lbName" runat="server" Label="用户名"></f:Label>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Label ID="lbPT" runat="server" Label="上次登录时间">
                        </f:Label>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Label ID="lbPIP" runat="server" Label="上次登录IP">
                        </f:Label>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtVerityName" Label="真实姓名" Required="true" ShowRedStar="true" runat="server">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtEmail" Label="电子邮箱" runat="server" RegexPattern="EMAIL">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtMobile" Label="手机号码" EmptyText="用逗号分隔多值" runat="server">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtTel" Label="座机号码" EmptyText="用逗号分隔多值" runat="server">
                        </f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Button ID="btnSave" Text="提交" CssStyle="margin-left:200px;" runat="server" OnClick="btnSave_Click" ValidateForms="Form2" ValidateMessageBox="false">
                        </f:Button>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
