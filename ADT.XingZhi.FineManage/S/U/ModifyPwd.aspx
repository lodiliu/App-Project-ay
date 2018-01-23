<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="ADT.XingZhi.FineManage.S.U.ModifyPwd" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>修改密码</title>
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
                    <f:TextBox ID="txtOldPwd" runat="server" TextMode="Password" MaxLength="20" MinLength="6" Regex="^[A-Za-z0-9_!#$%^&*.~]{6,20}$" RegexMessage="密码只能由数字、26个英文字母、下划线或者特殊字符(!#$%^&*.~)组成的字符串" Label="旧密码" ShowRedStar="true"
                        Required="true">
                    </f:TextBox>
                </Items>
            </f:FormRow>
            <f:FormRow>
                <Items>
                    <f:TextBox ID="txtNewPwd" runat="server" TextMode="Password" MaxLength="20" MinLength="6" Regex="^[A-Za-z0-9_!#$%^&*.~]{6,20}$" RegexMessage="密码只能由数字、26个英文字母、下划线或者特殊字符(!#$%^&*.~)组成的字符串" Label="新密码" ShowRedStar="true"
                        Required="true">
                    </f:TextBox>
                </Items>
            </f:FormRow>
            <f:FormRow>
                <Items>
                    <f:TextBox ID="txtNewPwdT" runat="server" TextMode="Password" MaxLength="20" MinLength="6" Regex="^[A-Za-z0-9_!#$%^&*.~]{6,20}$" RegexMessage="密码只能由数字、26个英文字母、下划线或者特殊字符(!#$%^&*.~)组成的字符串" Label="确认密码" ShowRedStar="true"
                        Required="true" CompareControl="txtNewPwd" CompareOperator="Equal" CompareMessage="两次输入的密码不一致">
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
