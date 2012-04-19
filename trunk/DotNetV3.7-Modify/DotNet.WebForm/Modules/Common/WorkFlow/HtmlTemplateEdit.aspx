<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HtmlTemplateEdit.aspx.cs"
    Inherits="HtmlTemplateEdit" %>

<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<html>
<head id="Head1" runat="server">
    <title>编辑单据模板</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
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
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" method="post" runat="server">
    <table width="100%" height="100%" cellspacing="2">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>编辑单据模板</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top" colspan="2">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <table id="table_taskallot" class="table" width="100%" height="100%" border="0" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td class="td-title">
                                <font color="red">*</font> 模板标题：
                            </td>
                            <td class="td-content" colspan="5">
                                <asp:TextBox ID="txtTitle" runat="server" MaxLength="200" Width="100%" CssClass="ColorBlur"
                                    onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                <font color="red">*</font> 模板编号：
                            </td>
                            <td class="td-content" style="padding-top: 3" width="30%">
                                <asp:TextBox ID="txtCode" runat="server" MaxLength="100" Width="100%" CssClass="ColorBlur"
                                    onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                            </td>
                            <td class="td-title">
                                模板分类：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <asp:DropDownList ID="cmbCategory" Width="200px" TabIndex="1" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="td-title">
                                模板种类：
                            </td>
                            <td class="td-content" style="padding-top: 3" width="30%">
                                <asp:DropDownList ID="cmbSource" Width="200px" TabIndex="1" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                标准流程：
                            </td>
                            <td class="td-content" style="padding-top: 3" colspan="5">
                                <asp:TextBox ID="txtIntroduction" runat="server" MaxLength="400" Width="100%" CssClass="ColorBlur"
                                    onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title" height="100%">
                                模板内容：
                            </td>
                            <td class="td-content" style="padding-top: 3" colspan="5" valign="top">
                                <CE:Editor ID="txtContent" runat="server" Width="100%" Height="100%" AutoConfigure="Simple"
                                    UseHTMLEntities="False">
                                </CE:Editor>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px; margin: auto auto auto auto"
                colspan="6">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="保存(S)" AccessKey="S"
                    TabIndex="3" OnClick="btnSave_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnReturn" runat="server" CssClass="Button" Text="返回" AccessKey="R"
                    TabIndex="3" OnClick="btnReturn_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    </form>
</body>
</html>
