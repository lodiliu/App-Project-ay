﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUS.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.AboutUS" ValidateRequest="false" %>

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
                <f:FormRow ColumnWidths="20% 40%">
                    <Items>
                        <f:TextBox ID="txtAddress" Label="地址" EmptyText="公司地址" runat="server" Required="true" ShowRedStar="true" MaxLength="200" CssStyle="margin-right:200px;"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtPhone" Label="电话" EmptyText="公司联系电话" runat="server" Required="true" ShowRedStar="true" MaxLength="50" CssStyle="margin-right:200px;"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:HtmlEditor runat="server" ID="txtMessage" Label="公司简介" ShowRedStar="true" CssStyle="margin-right:200px;"></f:HtmlEditor>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Button ID="btnSubmit" Type="Submit" Text="提交" runat="server" ValidateForms="Form3" OnClick="btnSubmit_Click" ValidateMessageBox="false"></f:Button>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>