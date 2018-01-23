<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMessage.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.AddMessage" %>

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
                        <f:TextBox ID="txtMessageTitle" Label="标题" EmptyText="推送消息标题(20字以内)" runat="server" Required="true" ShowRedStar="true" MaxLength="20"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextArea ID="txtMessage" Label="正文" EmptyText="消息正文(30字以内)" runat="server" Required="true" ShowRedStar="true" MaxLength="30"></f:TextArea>
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
