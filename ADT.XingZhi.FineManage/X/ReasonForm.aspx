<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReasonForm.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.ReasonForm" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
    <link href="../res/css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Form Width="760px" BodyPadding="5px" ID="Form2" EnableCollapse="true"
            Title="表单" LabelWidth="120px" LabelAlign="Top" runat="server" ShowHeader="false" ColumnWidth="100%" ShowBorder="false">
            <Toolbars>
                <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Center" Position="Bottom">
                    <Items>
                        <f:Button ID="Button1" runat="server" ValidateForms="Form2" ValidateTarget="Top"
                            Text="提交" OnClick="Button1_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Form>
    </form>
</body>
</html>
