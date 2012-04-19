<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="UserEdit" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css" />
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language='javascript' src='../../../JavaScript/Default.js'></script>
    <script language="javascript" src="JavaScript/UserInfo.js" type="text/javascript"></script>
    <title>用户编辑</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com" />
    <style type="text/css">
        .text
        {
            text-align: center;
            color: #000;
        }
    </style>
</head>
<body onload="document.onkeydown = EnterToTab;">
    <form id="form1" method="post" runat="server">
    <table border="0" width="100%" style="border-width: 0px; width: 100%; margin-top: 2px;">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>个人信息-用户编辑</b>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <img src="../../../Themes/Blue/Images/normal/icon_news_floder_3.gif" border="0" align="middle" />
                用户编辑
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
                <asp:TextBox ID="txtUserName" runat="server" TabIndex="1"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table style="border-left-width: 1px; border-left-color: #94bbd1; border-left-style: solid;"
        width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                真实姓名：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtRealname" runat="server" TabIndex="2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                默认角色：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:DropDownList ID="ddlUserRole" TabIndex="3" Width="163px" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                Email：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="text2"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                手机：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtMobile" runat="server" CssClass="text" MaxLength="12"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                QQ：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtQQ" runat="server" CssClass="text" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                生日：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtBirthday" runat="server" CssClass="text" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                性别：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:RadioButtonList ID="rdblGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="男" Selected="True">男</asp:ListItem>
                    <asp:ListItem Value="女">女</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                地址：
                <td class="td-content" style="padding-top: 3">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="text2" MaxLength="100"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                邮政编码：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtPostCode" runat="server" CssClass="text" MaxLength="6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                电话：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtPhone" runat="server" CssClass="text" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                传真：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:TextBox ID="txtFax" runat="server" CssClass="text" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:CheckBox ID="cnkSelect" TabIndex="4" runat="server" />有效
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
                <asp:LinkButton ID="btnConfirm" runat="server" ToolTip="保存" OnClick="btnSave_Click"
                    TabIndex="5"><span style="background-image: url('../../../Themes/Default/Images/Button.gif');width:79px;height:22px;padding:0px;line-height:22px;">保存</span></asp:LinkButton>
                <asp:LinkButton ID="btnReturn" runat="server" ToolTip="返回" TabIndex="6" OnClick="btnReturn_Click"><span style="background-image: url('../../../Themes/Default/Images/Button.gif');width:79px;height:22px;padding:0px;line-height:22px;">返回</span></asp:LinkButton>
                <asp:Label ID="lblPrompt" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtReturnURL" runat="server" Value="UserAdmin.aspx" />
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtUserAddressID" runat="server" />
    </form>
</body>
</html>
