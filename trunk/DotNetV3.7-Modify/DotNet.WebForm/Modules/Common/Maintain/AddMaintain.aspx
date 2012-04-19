<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMaintain.aspx.cs" Inherits="AddMaintain" %>

<html>
<head>
    <title>提交申请</title>
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
    <!--报修单提交的客户端jQuery.Validate验证 -->
    <script src='<%= Page.ResolveClientUrl("~/JavaScript/jquery-1.4.2.min.js") %>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/JavaScript/jquery.validate1.js") %>' type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/JavaScript/jquery.validate.message_cn.js") %>'
        type="text/javascript"></script>
    <script src='<%= Page.ResolveClientUrl("~/JavaScript/jquery.validate.vaidationgroup.js") %>'
        type="text/javascript"></script>
    <style type="text/css">
        /************jQuery.Validate插件样式开始********************/label.error
        {
            background: url(images/error.png) no-repeat 0px 0px;
            color: Red;
            padding-left: 20px;
        }
        input.error
        {
            border: dashed 1px red;
        }
        /************jQuery.Validate插件样式结束********************/</style>
    <script type="text/javascript">
        var opts = null;
        var isValidationGroup = false;
    </script>
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
                    <b>提交申请</b><span>
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
                        <td id="BugCategory" height="25" align="right" nowrap="nowrap" class="td-title">
                            故障类别：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:DropDownList ID="cmbBugCategory" Width="100%" TabIndex="1" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td height="25" align="right" nowrap="nowrap" class="td-title">
                            申报时间：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblReportingTime" runat="server" Text="申报时间"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="IP" height="25" align="right" nowrap="nowrap" class="td-title">
                            IP地址：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3">
                            <asp:TextBox ID="txtIP" runat="server" EnableTheming="True" MaxLength="50" TabIndex="1"
                                CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
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
                        <td id="MalfunctionCause" height="25" align="right" nowrap="nowrap" class="td-title">
                            故障原因：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3; color: #FF0000;">
                            <asp:TextBox ID="txtMalfunctionCause" runat="server" EnableTheming="True" MaxLength="50"
                                TabIndex="1" CssClass="ColorBlur required" onBlur="this.className='ColorBlur required';" onfocus="this.className='ColorFocus required';"
                                Width="85%" CausesValidation="True"></asp:TextBox>
                            &nbsp;*
                        </td>
                    </tr>
                    <tr>
                        <td id="Description" height="25" align="right" nowrap="nowrap" class="td-title">
                            问题描述 <span style="color: #FF0000">*</span>：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3">
                            <asp:TextBox ID="txtDescription" runat="server" EnableTheming="True" MaxLength="800"
                                TabIndex="1" CssClass="ColorBlur required" onBlur="this.className='ColorBlur required';" onfocus="this.className='ColorFocus required';"
                                Rows="10" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" valign="middle" class="td-content">
                            <em class="infogray" id="delever"></em><em class="info" id="validateTip" runat="server">
                            </em>&nbsp;&nbsp;<em class="info" id="validateTip2"></em><em class="info" id="validateid"></em><br>
                            <asp:Button ID="btnDraft" runat="server" CssClass="ButtonLarge" Text="保存为草稿(D)" AccessKey="S"
                                TabIndex="2" OnClick="btnDraft_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLargem.gif)';"
                                onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLarge.gif)';" />
                            &nbsp;<asp:Button ID="btnSend" runat="server" CssClass="ButtonLarge" Text="直接提交(S)"
                                AccessKey="S" TabIndex="1" OnClick="btnSend_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLargem.gif)';"
                                onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLarge.gif)';" />
                            &nbsp;<asp:Button ID="btnWorkFlowSend" runat="server" CssClass="ButtonLarge" Text="流程化提交(W)"
                                AccessKey="S" TabIndex="1" OnClick="btnWorkFlowSend_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLargem.gif)';"
                                onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLarge.gif)';" />
                            &nbsp;<asp:Button ID="btnReset" runat="server" CssClass="Button cancel" Text="重置(R)" AccessKey="R"
                                TabIndex="3" OnClick="btnReset_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                                onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                            <br>
                            <br>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
    <!--endprint-->
        <script type="text/javascript">
            jQuery(document).ready(function () {
                jQuery.validator.addMethod("telphoneValid", function (value, element) {
                    var tel = /^(130|131|132|133|134|135|136|137|138|139|150|153|157|158|159|180|187|188|189)\d{8}$/;
                    return tel.test(value) || this.optional(element);
                }, "请输入正确的手机号码");
                jQuery.validator.addMethod("zipCodeValid", function (value, element) {
                    var tel = /^\d{6}$/;
                    return tel.test(value) || this.optional(element);
                }, "请输入正确的邮编");
                jQuery.validator.addMethod("phoneValid", function (value, element) {
                    var tel = /^((\(0\d{2}\)[- ]?\d{8})|(0\d{2}[- ]?\d{8})|(\(0\d{3}\)[- ]?\d{8})|(0\d{3}[- ]?\d{8}))?$/;
                    return tel.test(value) || this.optional(element);
                }, "请输入正确的电话号码");
                if (isValidationGroup) {
                    if (opts != undefined || opts != null) {
                        jQuery("#<%=form1.ClientID %>").validate(jQuery.extend(opts, { onsubmit: false }));
                    } else {
                        jQuery("#<%=form1.ClientID %>").validate({
                            onsubmit: false
                        });
                    }
                    InitValidationGroup();
                } else {
                    if (opts != undefined || opts != null) {
                        jQuery("#<%=form1.ClientID %>").validate(opts);
                    } else {
                        jQuery("#<%=form1.ClientID %>").validate();
                    }
                }
            });
    </script>
</body>
</html>
