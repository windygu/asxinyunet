<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HtmlBillEdit.aspx.cs"
    Inherits="HtmlBillEdit" %>

<%@ Register Src="../../Common/Attachment/Attachment.ascx" TagName="Attachment" TagPrefix="Attachment" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<html>
<head id="Head1" runat="server">
    <title>编辑模板单据</title>
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
                    <b>审核流程-提交单据</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <table id="table_taskallot" class="table" width="100%" height="100%" border="0" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td class="td-title">
                                <font color="red">*</font> 单据标题：
                            </td>
                            <td colspan="3" class="td-content" style="padding-top: 3">
                                <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" Width="100%" CssClass="ColorBlur"
                                    onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                                单据内容：
                            </td>
                            <td colspan="3" class="td-content" style="padding-top: 3">
                                <CE:Editor ID="txtContent" runat="server" Width="100%" Height="100%" AutoConfigure="Simple"
                                    UseHTMLEntities="False">
                                </CE:Editor>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                审核流程：
                            </td>
                            <td class="td-content" colspan="3">
                                <asp:Label ID="lblWorkFlowActivity" runat="server" Text="未设置审核流程的请及时与管理员联系。"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                附件：
                            </td>
                            <td class="td-content" style="padding-top: 3" colspan="5">
                                <asp:FileUpload ID="Attachment01" EnableViewState="true" runat="server" Width="350px" /><br>
                                <asp:FileUpload ID="Attachment02" EnableViewState="true" runat="server" Width="350px" />
                                <Attachment:Attachment ID="AttachmentHtmlBill" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px; margin: auto auto auto auto">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="保存(S)" AccessKey="S"
                    TabIndex="1" OnClick="btnSave_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnSaveAndSend" runat="server" CssClass="ButtonLarge" Text="保存并提交(C)"
                    AccessKey="C" TabIndex="2" OnClick="btnSaveAndSend_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLargem.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLarge.gif)';" />
                &nbsp;<asp:Button ID="btnReturn" runat="server" CssClass="Button" Text="返回" AccessKey="R"
                    TabIndex="3" OnClick="btnReturn_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtTemplateId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    </form>
</body>
</html>
