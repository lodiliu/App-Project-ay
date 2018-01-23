<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDetials.aspx.cs" Inherits="ADT.XingZhi.FineManage.SM.U.ShowDetials" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>查看用户详细信息</title>
    <link href="/res/css/resetext.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="10px" ShowBorder="false" ShowHeader="false"
        Layout="VBox" BoxConfigAlign="Stretch" AutoScroll="true">
        <Toolbars>
            <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Center" Position="Bottom">
                <Items>
                    <f:Button ID="btnClose" runat="server" Text="关闭">
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
                                    <f:Label ID="labName" runat="server" Label="用户名">
                                    </f:Label>
                                    <f:Image ID="imgShowStatus" Label="是否禁用" runat="server">
                                    </f:Image>
                                </Items>
                            </f:FormRow>
                            <f:FormRow>
                                <Items>
                                    <f:Label ID="labRole" runat="server" Label="所属角色">
                                    </f:Label>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <f:Label ID="labPT" runat="server" Label="上次登录时间">
                                    </f:Label>
                                    <f:Label ID="labPIP" runat="server" Label="上次登录IP">
                                    </f:Label>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <f:Label ID="labLT" runat="server" Label="最近登录时间">
                                    </f:Label>
                                    <f:Label ID="labLIP" runat="server" Label="最近登录IP">
                                    </f:Label>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <f:Label ID="labLTS" runat="server" Label="登录总次数">
                                    </f:Label>
                                    <f:Label ID="labCT" runat="server" Label="创建时间">
                                    </f:Label>
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
                                    <f:Label ID="labRealName" runat="server" Label="真实姓名">
                                    </f:Label>
                                    <f:Label ID="labEmail" runat="server" Label="电子邮箱">
                                    </f:Label>
                                </Items>
                            </f:FormRow>
                            <f:FormRow ColumnWidths="50% 50%">
                                <Items>
                                    <f:Label ID="labMobile" runat="server" Label="手机号码">
                                    </f:Label>
                                    <f:Label ID="labPhone" runat="server" Label="座机号码">
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
