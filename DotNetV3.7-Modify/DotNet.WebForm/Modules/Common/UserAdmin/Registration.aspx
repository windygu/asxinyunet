<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css" />
    <script type="text/javascript" language='javascript' src='../../../JavaScript/Default.js'></script>
    <script language="javascript" src="JavaScript/UserInfo.js" type="text/javascript"></script>
    <title>用户注册</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="lbq222@Hotmail.com" />
</head>
<body onload="document.onkeydown = EnterToTab;" topmargin="0" bottommargin="0" leftmargin="0"
    rightmargin="0" style="overflow: hidden;">
    <form id="form1" method="post" runat="server">
    <table width="100%" style="margin-top: 1px">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>用户注册</b>
                </div>
            </td>
        </tr>
    </table>
    <table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
        cellspacing="0">
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                <font color="red">*</font> 用户名：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtUserName" runat="server" TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                    onfocus="this.className='ColorFocus';"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table style="border-left-width: 1px; border-left-color: #94bbd1; border-left-style: solid;"
        width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                密码：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtPassword" runat="server" TabIndex="2" Width="165px" TextMode="Password"
                    CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                确认密码：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtConfirmPassword" runat="server" TabIndex="3" Width="165px" TextMode="Password"
                    CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                真实姓名：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtRealName" runat="server" TabIndex="4" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                    onfocus="this.className='ColorFocus';"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                默认角色：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:DropDownList ID="cmbRole" TabIndex="5" Width="165px" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                E-mail：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtEmail" runat="server" TabIndex="6" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                    onfocus="this.className='ColorFocus';"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                备注：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtDescription" runat="server" MaxLength="800" TabIndex="7" TextMode="MultiLine"
                    CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <table class="ydMenuCss" align="center" width="100%">
        <tr>
            <td align="center">
                <asp:LinkButton ID="btnConfirm" runat="server" ToolTip="保存" OnClick="btnRegister_Click"
                    TabIndex="8"><span style="background-image: url('../../../Themes/Default/Images/Button.gif');width:79px;height:22px;padding:0px;line-height:22px;">保存</span></asp:LinkButton>
                <asp:LinkButton ID="btnReturn" runat="server" ToolTip="返回" TabIndex="6" OnClick="btnReturn_Click"><span style="background-image: url('../../../Themes/Default/Images/Button.gif');width:79px;height:22px;padding:0px;line-height:22px;">返回</span></asp:LinkButton>
                <asp:Label ID="lblPrompt" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtReturnURL" runat="server" Value="UserAdmin.aspx" />
    </form>
</body>
</html>
