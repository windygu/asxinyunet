<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditNews.aspx.cs" Inherits="EditNews" %>

<%@ Register Src="../Attachment/Attachment.ascx" TagName="Attachment" TagPrefix="Attachment" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<html>
<head id="Head1" runat="server">
    <title>编辑新闻</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa@Hotmail.com">
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <style>
        .Button
        {
            background-image: url(../../../Themes/Default/Images/Button.gif);
        }
        .ButtonLarge
        {
            background-image: url(../../../Themes/Default/Images/ButtonLarge.gif);
        }
    </style>
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" method="post" runat="server">
    <table width="100%" height="100%" cellspacing="2">
        <tr>
            <td colspan="2">
                <div class="breadcrumbHeader">
                    <b>公共信息-编辑新闻</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top" colspan="2">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td class="td-title">
                                <font color="red">*</font> 标题：
                            </td>
                            <td class="td-content">
                                <asp:TextBox ID="txtTitle" runat="server" MaxLength="200" Width="100%" CssClass="ColorBlur"
                                    onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="15" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                                <font color="red">*</font> 分类：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <asp:DropDownList ID="cmbNewsFolder" runat="server" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                新闻图片：
                            </td>
                            <td class="td-content">
                                <asp:FileUpload ID="FileUpload1" EnableViewState="true" runat="server" Width="350px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title" align="" valign="top" width="85px">
                                简介：
                            </td>
                            <td class="td-content" colspan="7">
                                <asp:TextBox ID="txtIntroduction" runat="server" Width="100%" TabIndex="17" MaxLength="200"
                                    CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                    Rows="3" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="300px" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                                内容：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <CE:Editor ID="txtContent" runat="server" Width="100%" Height="100%" AutoConfigure="Simple"
                                    UseHTMLEntities="False">
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                显示设置：
                            </td>
                            <td class="td-content">
                                <asp:CheckBox ID="chkHomPage" runat="server" Text="置首页" />
                                <asp:CheckBox ID="chkSubPage" runat="server" Text="置二级页" />
                            </td>
                        </tr>
                        <tr style="height: 75px">
                            <td class="td-title">
                                附件：
                            </td>
                            <td class="td-content">
                                <asp:FileUpload ID="fuAttachment01" EnableViewState="true" runat="server" Width="350px" /><br>
                                <asp:FileUpload ID="fuAttachment02" EnableViewState="true" runat="server" Width="350px" /><br>
                                <asp:FileUpload ID="fuAttachment03" EnableViewState="true" runat="server" Width="350px" />
                                <Attachment:Attachment ID="Attachment" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px; margin: auto auto auto auto"
                colspan="2">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="保存" AccessKey="S"
                    TabIndex="3" OnClick="btnSave_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnReturn" runat="server" CssClass="Button" Text="返回" AccessKey="R"
                    TabIndex="3" OnClick="btnReturn_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtFolderId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    </form>
</body>
</html>
