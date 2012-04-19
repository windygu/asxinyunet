<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowMaintain.aspx.cs" Inherits="ShowMaintain" %>

<html>
<head>
    <title>申请内容</title>
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
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server" onkeydown="EnterToTab()">
    <table width="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>申请内容</b><span>
                        <img id="img" src="../../../Themes/Default/Images/close.gif" alt="隐藏" onmouseover="this.style.cursor='hand'"
                            onclick="displayTable()" /></span>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top">
                <table id="table" class="table" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="RealName" height="25" style="width: 150px" align="right" nowrap="nowrap"
                            class="td-title">
                            申报人：
                        </td>
                        <td class="td-content" style="width: 200px" style="padding-top: 3">
                            <asp:Label ID="lblRealName" runat="server" Text="姓名"></asp:Label>
                        </td>
                        <td id="UserCode" height="25" align="right" nowrap="nowrap" style="width: 150px"
                            class="td-title">
                            工号：
                        </td>
                        <td class="td-content" style="width: 200px" style="padding-top: 3">
                            <asp:Label ID="lblUserCode" runat="server" Text="工号"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="Telephone" height="25" align="right" nowrap="nowrap" class="td-title">
                            联系电话：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblTelephone" runat="server" Text="工号"></asp:Label>
                        </td>
                        <td id="DepartmentName" height="25" align="right" nowrap="nowrap" class="td-title">
                            部门：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblDepartmentName" runat="server" Text="部门"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="OfficeLocation" height="25" align="right" nowrap="nowrap" class="td-title">
                            办公地点：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblOfficeLocation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="BugCategory" height="25" align="right" nowrap="nowrap" class="td-title">
                            故障类别：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblBugCategory" runat="server"></asp:Label>
                        </td>
                        <td height="25" align="right" nowrap="nowrap" class="td-title">
                            申报时间：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblReportingTime" runat="server" Text="申报时间"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="ComputerUserName" height="25" align="right" nowrap="nowrap" class="td-title">
                            电脑用户名：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblComputerUserName" runat="server"></asp:Label>
                        </td>
                        <td id="CompterPassword" height="25" align="right" nowrap="nowrap" class="td-title">
                            电脑密码：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblComputerPassword" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="MalfunctionCause" height="25" align="right" nowrap="nowrap" class="td-title">
                            故障原因：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblMalfunctionCause" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="Description" height="25" align="right" nowrap="nowrap" class="td-title">
                            问题描述：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" valign="middle" class="td-content">
                            <br />
                            <asp:Button ID="btnReturn" runat="server" CssClass="Button" Visible="false" Text="返回(R)" AccessKey="R"
                                TabIndex="3" OnClick="btnReturn_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                                onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                            <br>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtReturnURL" runat="server" Value="Submit.aspx" />
    <asp:HiddenField ID="txtId" runat="server" />
    </form>
    <!--endprint-->
</body>
</html>
