<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Save.aspx.cs" Inherits="ADT.XingZhi.FineManage.S.R.Save" %>

<!DOCTYPE html >

<html>
<head runat="server">
    <title>添加/编辑角色信息</title> 
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Form2" runat="server" />
    <f:Form BodyPadding="10px" ID="Form2" EnableCollapse="true" runat="server" ShowHeader="false"
        ShowBorder="false">
        <Toolbars>
            <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Center" Position="Bottom">
                <Items> 
                    <f:Button ID="btnSave" Text="保存并关闭" ValidateForms="Form2" runat="server" OnClick="btnSave_Click" ValidateMessageBox="false">
                    </f:Button>
                    <f:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                    </f:ToolbarSeparator>
                    <f:Button ID="btnSave2" Text="保存并继续" ValidateForms="Form2" runat="server" OnClick="btnSave2_Click" ValidateMessageBox="false">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Rows>
            <f:FormRow ColumnWidths="50% 50%">
                <Items>
                    <f:TextBox ID="txtName" Label="角色名称" Required="true" ShowRedStar="true" runat="server">
                    </f:TextBox>
                    <f:NumberBox ID="txtOrderId" Label="排序" Required="true" ShowRedStar="true" DecimalPrecision="0"
                        runat="server">
                    </f:NumberBox>
                </Items>
            </f:FormRow>
            <f:FormRow>
                <Items>
                    <f:TextArea ID="txtDesc" Label="角色描述" runat="server" Height="100px">
                    </f:TextArea>
                </Items>
            </f:FormRow>
        </Rows>
    </f:Form>
    </form>
</body>
</html>

