<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edition.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.Edition" ValidateRequest="false" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增推送消息</title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Form3" runat="server" />
        <f:Form ID="Form3" BodyPadding="10px" LabelWidth="160px" runat="server" ShowHeader="false" ShowBorder="false" AutoScroll="true">
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" ID="txtNumber" Label="版本号" ShowRedStar="true" Required="true" CssStyle="margin-right:200px"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:HtmlEditor runat="server" ShowRedStar="true" Label="介绍" ID="txtEdition" CssStyle="margin-right:200px"></f:HtmlEditor>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Button ID="btnSubmit" Type="Submit" Text="提交" runat="server" ValidateForms="Form3" OnClick="btnSubmit_Click"></f:Button>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
