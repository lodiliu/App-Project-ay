<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPotential.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.EditPotential" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>潜力作品</title>
    <style>
        .photo {
            height: 80px;
            line-height: 80px;
            overflow: hidden;
        }

            .photo img {
                height: 80px;
                vertical-align: middle;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Form3" runat="server" />
        <f:Form ID="Form3" BodyPadding="10px" LabelWidth="160px" runat="server" ShowHeader="false" ShowBorder="false" AutoScroll="true">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" ToolbarAlign="Center" Position="Bottom">
                    <Items>
                        <f:Button ID="btnSubmit" Type="Submit" Text="保存并关闭" runat="server" ValidateForms="Form3" OnClick="btnSubmit_Click"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow ColumnWidths="50% 10% 20%">
                    <Items>
                        <f:TextBox runat="server" ID="txtPerson" Label="演员" Readonly="true" Required="true" ShowRedStar="true"></f:TextBox>
                        <f:TextBox runat="server" ID="txtPersonid" Label="" Readonly="true" Required="true" ShowRedStar="false" Hidden="true" ColumnWidth="1px;"></f:TextBox>
                        <f:Button ID="btnChoose" Text="查询" CssClass="marginr" runat="server" OnClick="btnChoose_Click" EnablePostBack="true">
                        </f:Button>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtWorkName" Label="作品名称" EmptyText="潜力作品名称" runat="server" Required="true" ShowRedStar="true" MaxLength="200"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DropDownList runat="server" ID="ddlWorkType" Label="作品类型" EmptyText="作品类型" Required="true" ShowRedStar="true" CssStyle="margin-right:390px;">
                            <f:ListItem Text="电影" Value="MOVIE" Selected="true" />
                            <f:ListItem Text="电视" Value="TV" />
                        </f:DropDownList>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtDy" Label="导演" EmptyText="导演" runat="server" Required="true" ShowRedStar="true" MaxLength="50"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtZy" Label="主演" EmptyText="主演" runat="server" Required="true" ShowRedStar="true" MaxLength="200"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:HtmlEditor runat="server" Label="作品介绍" ID="txtWorkInfo"></f:HtmlEditor>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DatePicker ID="txtRelease" runat="server" Required="true" Label="预计上映时间" DateFormatString="yyyy-MM-dd" EmptyText="预计上映时间"
                            ShowRedStar="True" CssStyle="margin-right:400px;">
                        </f:DatePicker>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Image ID="imgPhoto" CssClass="photo" ImageUrl="~/uploadworkphoto/blank.png" ShowEmptyLabel="true" runat="server">
                        </f:Image>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:FileUpload runat="server" Label="图片" ID="filePhoto" ShowRedStar="false" ShowEmptyLabel="true"
                            ButtonText="上传作品图片(建议3M内 尺寸300×400)" ButtonOnly="true" ButtonIcon="ImageAdd"
                            AutoPostBack="true" OnFileSelected="filePhoto_FileSelected">
                        </f:FileUpload>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
        <f:Window ID="Window1" EnableIFrame="true" IFrameUrl="about:blank" EnableMaximize="false"
            Target="Top" EnableResize="false" runat="server" IsModal="true"
            Width="800px" Height="600px" Hidden="true">
        </f:Window>
    </form>
</body>
</html>
