<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PCManage.aspx.cs"
    Inherits="ADT.XingZhi.FineManage.SM.M.PCManage" %>

<!DOCTYPE html >
<html>
<head runat="server">
    <title>系统菜单权益项列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
    <f:Panel ID="Panel1" runat="server" BodyPadding="3px" ShowBorder="false" ShowHeader="false"
        Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <f:Form BodyPadding="10px" ID="Form2" runat="server" ShowBorder="False" ShowHeader="false">
                <Rows>
                    <f:FormRow ColumnWidths="30% 5% 30% 20% 15%">
                        <Items>
                            <f:TextBox ID="txtName" runat="server" Label="权益名称" LabelWidth="80px">
                            </f:TextBox>
                            <f:TextBox ID="txtID" runat="server" Hidden="true">
                            </f:TextBox>
                            <f:TextBox ID="txtCode" runat="server" MaxLength="10" Label="权益编码" LabelWidth="80px">
                            </f:TextBox>
                            <f:CheckBox ID="chkDisabled" Label="是否禁用" LabelWidth="80px" runat="server">
                            </f:CheckBox>
                            <f:Button ID="btnSave" Text="保存" runat="server" OnClick="btnSave_Click" ValidateForms="Form2"
                                ValidateMessageBox="false">
                            </f:Button>
                        </Items>
                    </f:FormRow>
                </Rows>
            </f:Form>
            <f:Grid ID="Grid1" BoxFlex="1" Title="权益信息" ShowBorder="false" ShowHeader="false"
                runat="server" DataKeyNames="MPC_ID,MPC_NAME,MPC_CODE,MPC_DISABLED" EmptyText="没有符合条件的数据" OnRowCommand="Grid1_RowCommand">
                <Columns>
                    <f:RowNumberField HeaderText="#" />
                    <f:BoundField DataField="MPC_NAME" ExpandUnusedSpace="true" HeaderText="权益名称" />
                    <f:BoundField DataField="MPC_CODE" Width="150px" HeaderText="权益编码" />
                    <f:CheckBoxField ColumnID="cbfUDISABLED" CommandName="UDISABLED" Width="80px" DataField="MPC_DISABLED"
                    HeaderText="是否禁用" TextAlign="Center" RenderAsStaticField="false" AutoPostBack="true" />
                    <f:BoundField DataField="M_NAME" Width="150px" HeaderText="所属菜单" />
                    <f:LinkButtonField CommandName="Edit" TextAlign="Center" Width="60px" Text="编辑" />
                </Columns>
            </f:Grid>
        </Items>
    </f:Panel>
    </form>
</body>
</html>
