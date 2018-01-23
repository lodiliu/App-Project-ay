<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRecommend.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.EditRecommend" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Panel ID="Panel6" runat="server" BodyPadding="5px" EnableCollapse="true"
            ShowBorder="True" ShowHeader="false" Width="1180px" Height="80px" Title=""
            Layout="Fit">
            <Items>
                <f:Form ID="Form5" ShowBorder="False" BodyPadding="5px" AnchorValue="100%"
                    ShowHeader="False" runat="server">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar2" runat="server" ToolbarAlign="Center" Position="Top">
                            <Items>
                                <f:Button runat="server" Type="Submit" ID="btnInput" Text="确定并填写推荐理由" ValidateForms="Form5"></f:Button>
                                <f:Button runat="server" Type="Submit" ID="btnSure" Text="直接提交" OnClick="btnSure_Click" ValidateForms="Form5"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Rows>
                        <f:FormRow ColumnWidths="36% 64%">
                            <Items>
                                <f:TextBox ID="txtTypeName" Label="类型名称" runat="server" MaxLength="20" ShowRedStar="true" Required="true"
                                    OnTextChanged="txtTypeName_TextChanged" CssStyle="margin-right:100px;" AutoPostBack="true">
                                </f:TextBox>
                                <f:CheckBox runat="server" Checked="true" ID="chkFlag" Label="是否启用" ShowRedStar="true" AutoPostBack="false" Text=""></f:CheckBox>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
        </f:Panel>
        <f:Panel ID="Panel7" runat="server" BodyPadding="5px" EnableCollapse="true"
            ShowBorder="false" ShowHeader="false" Width="300px" Height="620px" Title=""
            Layout="Fit" CssStyle="float:left;">
            <Items>
                <f:Grid runat="server" ID="GridChoose" BoxFlex="1" PageSize="20" ShowBorder="true" ShowHeader="false" Width="200px" OnRowCommand="GridChoose_RowCommand"
                    EnableCollapse="true" SortField="personname" AutoScroll="true">
                    <Columns>
                        <f:BoundField Width="10px" TextAlign="Center" DataField="personid" HeaderText="演员ID" Hidden="true" />
                        <f:BoundField ExpandUnusedSpace="true" Width="100px" TextAlign="Center" DataField="personname" HeaderText="名称" />
                        <f:LinkButtonField CommandName="Delete" TextAlign="Center" HeaderText="删除" Width="40px" Icon="Delete" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Panel ID="Panel8" runat="server" BodyPadding="5px" EnableCollapse="true"
            ShowBorder="false" ShowHeader="false" Width="800px" Title=""
            Layout="Fit" CssStyle="float:right;" Height="620px">
            <Items>
                <f:Grid ID="Grid1" runat="server" BoxFlex="1" PageSize="20" ShowBorder="true" ShowHeader="false"
                    AllowPaging="true" OnPageIndexChange="Grid1_PageIndexChange"
                    IsDatabasePaging="true" AllowSorting="true" SortDirection="ASC" OnSort="Grid1_Sort"
                    SortField="a_id" EmptyText="没有符合条件的数据" EnableCollapse="true"
                    DataKeyNames="personid,ID,CName" EnableMultiSelect="true" EnableRowSelectEvent="false"
                    ClearSelectedRowsAfterPaging="false" EnableCheckBoxSelect="true" CheckBoxSelectOnly="true" AutoScroll="true">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <f:TwinTriggerBox Width="400px" ID="ttbSearchUser" runat="server" ShowLabel="false"
                                    EmptyText="在名称中搜索" Trigger1Icon="Clear" Trigger2Icon="Search" ShowTrigger1="false"
                                    OnTrigger2Click="ttbSearchUser_Trigger2Click" OnTrigger1Click="ttbSearchUser_Trigger1Click">
                                </f:TwinTriggerBox>
                                <f:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="确定选择"></f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:BoundField Width="50px" TextAlign="Center" DataField="ID" HeaderText="序号" />
                        <f:BoundField Width="200px" TextAlign="Center" DataField="personid" HeaderText="演员ID" Hidden="true" />
                        <f:BoundField Width="200px" TextAlign="Center" DataField="CName" HeaderText="名称" />
                        <f:BoundField Width="200px" TextAlign="Center" DataField="School" HeaderText="毕业学校" />
                        <f:BoundField ExpandUnusedSpace="true" Width="200px" TextAlign="Center" DataField="Company" HeaderText="经济公司" />
                    </Columns>
                    <PageItems>
                        <f:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </f:ToolbarSeparator>
                        <f:ToolbarText ID="ToolbarText1" runat="server" Text="每页记录数：">
                        </f:ToolbarText>
                        <f:DropDownList runat="server" ID="ddlPageSize" Width="80px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <f:ListItem Text="20" Value="20" />
                            <f:ListItem Text="40" Value="40" />
                            <f:ListItem Text="60" Value="60" />
                            <f:ListItem Text="80" Value="80" />
                        </f:DropDownList>
                    </PageItems>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:HiddenField ID="hides" runat="server" Hidden="true" />
        <f:HiddenField ID="hidename" runat="server" Hidden="true" />
        <f:Window ID="Window1" EnableIFrame="true" IFrameUrl="about:blank" EnableMaximize="true"
            Target="Top" EnableResize="true" runat="server" IsModal="true" EnableDrag="false"
            Width="800px" Height="700px" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
