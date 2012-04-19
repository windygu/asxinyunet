<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserStatistics.aspx.cs" Inherits="UserStatistics" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <title>用户统计</title>
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
                用户统计
            </td>
            <td align="right">
            </td>
        </tr>
    </table>
    <table border="0" width="100%">
        <tr>
            <td>
                <img src="../../../Themes/Blue/Images/normal/icon_news_floder_3.gif" border="0" align="absmiddle" />
                用户登录情况统计
            </td>
        </tr>
    </table>
    <table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
        cellspacing="0">
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                统计日期：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblTongJiRiQi" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                在线用户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblZaiXian" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                今天登录用户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblJinTianDengLu" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                一周内登录用户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblYiZhouNeiDengLu" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                一个月内登录用户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblYiGeYueNeiDengLu" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                半年内登录用户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblBanNianNeiDengLu" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                一年内登录用户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblYiNianNeiDengLu" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br>
    <table border="0" width="100%">
        <tr>
            <td>
                <img src="../../../Themes/Blue/Images/normal/icon_news_floder_3.gif" border="0" align="absmiddle" />
                用户注册情况统计
            </td>
        </tr>
    </table>
    <table id="table1" class="table" width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                注册用户数：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblZhuCeYongHuShu" runat="server" Font-Bold="True" ForeColor="#CC3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                今天注册户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblJinTianZhuCe" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                一周内注册录户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblYiZhouNeiZhuCe" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                一个月内注册用户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblYiGeYueNeiZhuCe" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                半年内注册用户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblBanNianNeiZhuCe" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                一年内注册用户：
            </td>
            <td class="td-content" style="padding-top: 3">
                <asp:Label ID="lblYiNaiNeiZhuCe" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
