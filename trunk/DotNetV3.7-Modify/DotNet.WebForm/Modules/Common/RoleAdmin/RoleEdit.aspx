<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleEdit.aspx.cs" Inherits="RoleEdit" %>

<html>
<head>
    <title>编辑角色</title>
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <script language="javascript" src="JavaScript/UserInfo.js" type="text/javascript"></script>
    <base target="_self" />
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <style>
        .Button
        {
            background-image: url(../../../Themes/Default/Images/Button.gif);
        }
    </style>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server" onkeydown="EnterToTab()">
    <table width="100%" height="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>编辑角色</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                                <font color="red">*</font> 编号：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <asp:TextBox ID="txtCode" runat="server" dataType="Limit" min="1" max="50" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" align="right" nowrap="nowrap" class="td-title">
                                <font color="red">*</font> 名称：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <asp:TextBox ID="txtRealname" runat="server" dataType="Limit" min="1" max="50" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" align="right" nowrap="nowrap" class="td-title">
                                备注：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <asp:TextBox ID="txtDescription" runat="server" dataType="Limit" min="1" max="200"
                                    Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px">
                <asp:Button ID="btnSave" runat="server" Text="保存&amp;返回" OnClick="btnSave_Click"
                    CssClass="Button" />
                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="Button" />
                <!--
                <input id="btnreturn" type="button" value="返 回" onclick="history.back();" class="Button" />
    -->
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" runat="server" Value="RoleAdmin.aspx" />
    </form>
    <!--endprint-->
</body>
</html>
