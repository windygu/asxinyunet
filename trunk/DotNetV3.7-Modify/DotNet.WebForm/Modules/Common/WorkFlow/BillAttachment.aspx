<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BillAttachment.aspx.cs" Inherits="BillAttachment" %>

<%@ Register Src="../Attachment/Attachment.ascx" TagName="Attachment" TagPrefix="Attachment" %>
<html>
<head id="Head1" runat="server">
    <title>编辑单据附件</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
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
            <td colspan="2">
                <div class="breadcrumbHeader">
                    <b>审核流程-编辑附件</b>
                </div>
            </td>
        </tr>
        <tr>
            <td class="td-title">
                附件：
            </td>
            <td class="td-content">
                <Attachment:Attachment ID="AttachmentHtmlBill" AllowDelete="true" AllowShowHeader="true"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td class="td-title">
                上传：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:FileUpload ID="Attachment01" EnableViewState="true" runat="server" Width="350px" /><br>
                <asp:FileUpload ID="Attachment02" EnableViewState="true" runat="server" Width="350px" /><br>
                <asp:FileUpload ID="Attachment03" EnableViewState="true" runat="server" Width="350px" /><br>
                <asp:FileUpload ID="Attachment04" EnableViewState="true" runat="server" Width="350px" /><br>
                <asp:FileUpload ID="Attachment05" EnableViewState="true" runat="server" Width="350px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" valign="middle" style="height: 20px; margin: auto auto auto auto">
                <asp:Button ID="btnSave" runat="server" CssClass="ButtonLarge" Text="上传附件(S)" AccessKey="S"
                    TabIndex="3" OnClick="btnSave_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLargem.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLarge.gif)';" />
                <asp:Button ID="btnReturn" runat="server" CssClass="Button" Text="返回(R)" AccessKey="R"
                    TabIndex="3" OnClick="btnReturn_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 100%">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    </form>
</body>
</html>
