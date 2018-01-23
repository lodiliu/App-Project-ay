<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPublish.aspx.cs" Inherits="ADT.XingZhi.FineManage.X.EditPublish" ValidateRequest="false" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新增推送消息</title>
    <style>
        .photo {
            height: 80px;
            line-height: 80px;
            overflow: hidden;
        }

            .photo img {
                height: 50px;
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
                        <f:Button ID="btnSubmit" Type="Submit" Text="提交" runat="server" ValidateForms="Form3" OnClick="btnSubmit_Click" ValidateMessageBox="false"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Rows>
                <f:FormRow>
                    <Items>
                        <f:TextBox ID="txtTitle" Label="标题" EmptyText="推送消息标题(20字以内)" runat="server" Required="true" ShowRedStar="true" MaxLength="20"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DropDownList runat="server" ID="ddlTtype" Label="发布类别" EmptyText="请选择发布类型" OnSelectedIndexChanged="ddlTtype_SelectedIndexChanged" Required="true" ShowRedStar="true" CssStyle="margin-right:400px;" CompareOperator="NotEqual" CompareMessage="请选择发布类型" CompareValue="-1" AutoPostBack="true">
                            <f:ListItem Text="请选择发布类型" Value="-1" Selected="true" />
                            <f:ListItem Text="演员" Value="演员" />
                            <f:ListItem Text="电视剧" Value="电视剧" />
                        </f:DropDownList>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:DropDownList runat="server" ID="ddlCtype" Label="内容分类" EmptyText="请选择内容分类" Required="true" ShowRedStar="true" CssStyle="margin-right:400px;" CompareOperator="NotEqual" CompareMessage="请选择内容分类" CompareValue="-1">
                            <f:ListItem Text="请选择内容分类" Value="-1" Selected="true" />
                            <f:ListItem Text="组讯" Value="组讯" />
                            <f:ListItem Text="推广" Value="推广" />
                            <f:ListItem Text="观点" Value="观点" />
                        </f:DropDownList>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:CheckBox runat="server" Checked="true" ID="chkFlag" Label="是否启用" AutoPostBack="false" Text=""></f:CheckBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:HtmlEditor runat="server" Label="内容" ID="htmlContent" Height="150px" ShowRedStar="true"></f:HtmlEditor>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Image ID="imgPhotoFM" CssClass="photo" ImageUrl="~/uploadworkphoto/blank.png" ShowEmptyLabel="true" runat="server">
                        </f:Image>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:FileUpload runat="server" Label="封面图片" ID="filePhotoFM" ShowRedStar="false" ShowEmptyLabel="true"
                            ButtonText="上传封面图片(建议3M内 尺寸300×400)" ButtonOnly="true" ButtonIcon="ImageAdd"
                            AutoPostBack="true" OnFileSelected="filePhotoFM_FileSelected">
                        </f:FileUpload>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Image ID="imgPhotoNR" CssClass="photo" ImageUrl="~/uploadworkphoto/blank.png" ShowEmptyLabel="true" runat="server">
                        </f:Image>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:FileUpload runat="server" Label="内容图片" ID="filePhotoNR" ShowRedStar="false" ShowEmptyLabel="true"
                            ButtonText="上传内容图片(建议3M内 尺寸350×200)" ButtonOnly="true" ButtonIcon="ImageAdd"
                            AutoPostBack="true" OnFileSelected="filePhotoNR_FileSelected">
                        </f:FileUpload>
                    </Items>
                </f:FormRow>
            </Rows>
        </f:Form>
    </form>
</body>
</html>
