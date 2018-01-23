<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowMessage.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.ShowMessage" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" runat="server" BodyPadding="10px" ShowBorder="false" ShowHeader="false"
            Layout="VBox" BoxConfigAlign="Stretch" AutoScroll="true">
            <Items>
                <f:GroupPanel ID="GroupPanel1" Layout="Anchor" Title="推送信息" runat="server">
                    <Items>
                        <f:Form BodyPadding="10px" ID="Form2" EnableCollapse="true" runat="server" ShowHeader="false"
                            ShowBorder="false">
                            <Rows>
                                <f:FormRow>
                                    <Items>
                                        <f:Label ID="labtitle" runat="server" Label="标题名称">
                                        </f:Label>
                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                    </Items>
                </f:GroupPanel>
                <f:GroupPanel ID="GroupPanel2" Margin="10px 0 0 0" Layout="Anchor" Title="详情" runat="server">
                    <Items>
                        <f:Form BodyPadding="10px" ID="Form3" EnableCollapse="true" runat="server" ShowHeader="false"
                            ShowBorder="false">
                            <Rows>
                                <f:FormRow>
                                    <Items>
                                        <f:Label ID="labcontext" runat="server" Label="">
                                        </f:Label>

                                    </Items>
                                </f:FormRow>
                            </Rows>
                        </f:Form>
                    </Items>
                </f:GroupPanel>
            </Items>
        </f:Panel>
    </form>
</body>
</html>

