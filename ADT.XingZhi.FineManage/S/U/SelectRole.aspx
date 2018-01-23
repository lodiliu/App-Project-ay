<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectRole.aspx.cs"
    Inherits="ADT.XingZhi.FineManage.S.U.SelectRole" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>用户选择角色</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="SimpleForm1" runat="server" />
    <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false" runat="server" BodyPadding="10px"
        Title="SimpleForm" AutoScroll="true">
        <Toolbars>
            <f:Toolbar ID="Toolbar1" runat="server">
                <Items> 
                    <f:Button ID="btnSaveClose" OnClick="btnSaveClose_Click"
                        runat="server" Text="确定选择">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Rows>
            <f:FormRow ID="FormRow1" runat="server">
                <Items>
                    <f:CheckBoxList ID="cblRole" ColumnNumber="1" runat="server">
                    </f:CheckBoxList>
                </Items>
            </f:FormRow>
        </Rows>
    </f:Form>
    </form>
</body>
</html>
