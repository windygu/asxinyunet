<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditMaintain.aspx.cs" Inherits="EditMaintain" %>

<html>
<head>
    <title>编辑申请</title>
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
    </style>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server" onkeydown="EnterToTab()">
    <table width="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>编辑申请</b><span>
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
                            编号：
                        </td>
                        <td class="td-content" style="width: 200px" style="padding-top: 3">
                            <asp:Label ID="lblUserCode" runat="server" Text="编号"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="Telephone" height="25" align="right" nowrap="nowrap" class="td-title">
                            联系电话：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:TextBox ID="txtTelephone" runat="server" EnableTheming="True" MaxLength="50"
                                TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                Width="100%"></asp:TextBox>
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
                            <asp:TextBox ID="txtOfficeLocation" runat="server" EnableTheming="True" MaxLength="200"
                                TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" nowrap="nowrap" class="td-title">
                            申报时间：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblReportingTime" runat="server" Text="申报时间"></asp:Label>
                        </td>
                        <td id="ServiceState" height="25" align="right" nowrap="nowrap" class="td-title">
                            服务状态：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblServiceState" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="BugCategory" height="25" align="right" nowrap="nowrap" class="td-title">
                            故障类别：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:DropDownList ID="cmbBugCategory" Width="100%" TabIndex="1" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td id="BugLevel" height="25" align="right" nowrap="nowrap" class="td-title">
                            故障等级：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:DropDownList ID="cmbBugLevel" Width="100%" TabIndex="1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td id="MalfunctionCause" height="25" align="right" nowrap="nowrap" class="td-title">
                            故障原因：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:TextBox ID="txtMalfunctionCause" runat="server" EnableTheming="True" MaxLength="50"
                                TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                Width="100%"></asp:TextBox>
                        </td>
                        <td height="25" align="right" nowrap="nowrap" class="td-title">
                            处理耗时：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblProcessTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="IP" height="25" align="right" nowrap="nowrap" class="td-title">
                            IP地址：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3">
                            <asp:TextBox ID="txtIP" runat="server" EnableTheming="True" MaxLength="50"
                                TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td id="ComputerUserName" height="25" align="right" nowrap="nowrap" class="td-title">
                            电脑用户名：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:TextBox ID="txtComputerUserName" runat="server" EnableTheming="True" MaxLength="50"
                                TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                Width="100%"></asp:TextBox>
                        </td>
                        <td id="CompterPassword" height="25" align="right" nowrap="nowrap" class="td-title">
                            电脑密码：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:TextBox ID="txtComputerPassword" runat="server" EnableTheming="True" MaxLength="50"
                                TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td id="Description" height="25" align="right" nowrap="nowrap" class="td-title">
                            问题描述：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3">
                            <asp:TextBox ID="txtDescription" runat="server" EnableTheming="True" MaxLength="800"
                                TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                Rows="10" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" valign="middle" class="td-content">
                            <br>
                            <asp:Button ID="btnUpdate" runat="server" CssClass="Button" Text="更新" AccessKey="S"
                                TabIndex="3" OnClick="btnUpdate_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                                onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <!--endprint-->
</body>
</html>
