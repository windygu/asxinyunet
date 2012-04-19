<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetPassword.aspx.cs" Inherits="SetPassword" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <script language='javascript' src='../../../JavaScript/Default.js' type="text/javascript"></script>
    <title>设置密码</title>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <table class="ydMenuCssParentTab" cellspacing="0" cellpadding="0" border="0" style="height: 25px;
        width: 100%; border-collapse: collapse;">
        <tr>
            <td colspan="2" style="height: 3px;">
            </td>
        </tr>
        <tr>
            <td class="ydMenuCssParentLefttd" style="white-space: nowrap;">
                用户管理 - 设置密码
            </td>
            <td align="right">
            </td>
        </tr>
    </table>
    <table border="0" width="100%">
        <tr>
            <td>
                <img src="../../../Themes/Blue/Images/normal/icon_news_floder_3.gif" border="0" align="absmiddle" />
                设置密码
            </td>
        </tr>
    </table>
    <table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
        cellspacing="0">
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                新密码：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="50" TextMode="Password"
                    TabIndex="2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                确认密码：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="50" TextMode="Password"
                    TabIndex="3"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <table class="ydMenuCss" align="center" width="100%">
        <tr>
            <td align="center">
                <asp:LinkButton ID="btnConfirm" runat="server" ToolTip="保存" OnClick="btnConfirm_Click"><span style="background-image: url('../../../Themes/Default/Images/Button.gif');width:79px;height:22px;padding:0px;line-height:22px;">保存</span></asp:LinkButton>
                <asp:LinkButton ID="btnReturn" runat="server" ToolTip="返回" TabIndex="6" OnClick="btnReturn_Click"><span style="background-image: url('../../../Themes/Default/Images/Button.gif');width:79px;height:22px;padding:0px;line-height:22px;">返回</span></asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    <asp:HiddenField ID="txtId" runat="server" />
    </form>
</body>
</html>
