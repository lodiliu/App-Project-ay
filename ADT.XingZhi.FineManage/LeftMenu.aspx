<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.aspx.cs" Inherits="ADT.XingZhi.FineManage.LeftMenu" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="leftTree" runat="server" />
    <f:Tree runat="server" ShowBorder="false" ShowHeader="false" EnableArrows="true" ID="leftTree" AutoScroll="true">
    </f:Tree>
    </form> 
</body>
</html>
