<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogOn.aspx.cs" Inherits="LogOn" %>
<%@ Import Namespace="DotNet.Utilities" %>

<!-- Put IE into quirks mode -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%--加上服务器标记，不然主题样式从后台应用不进来--%>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title><%= BaseSystemInfo.SoftFullName%></title>
    <link href="Themes/Default/layout.css" type="text/css" rel="stylesheet" />
    <!--为了登录方便暂时屏蔽 <script src="JavaScript/logOnValidate.js" type="text/javascript"></script>-->
    <style type="text/css">
        html, body
        {
            height: 100%;
            width: 100%;
            overflow: hidden;
            margin: 0;
            padding: 0;
        }
    </style>
</head>
<body class="enter">
    <table style="height: 100%; width: 100%">
        <tr>
            <td valign="middle" align="center">
                <form id="from1" runat="server">
                <div style="width: 1000px;">
                    <div class="entermain">
                        <div class="enterheader">
                        </div>
                        <div class="entercenter">
                            <div class="enteright">
                                <p class="aimienter">
                                    欢迎使用<em class="aimicons"></em><a href="#"><%= BaseSystemInfo.SoftFullName%></a>帐号登录</p>
                                <table>
                                    <tr>
                                        <th>
                                        </th>
                                        <td>
                                            <em class="infogray" id="delever"></em><em class="info" id="logOnTip" runat="server">
                                            </em>&nbsp;&nbsp;<em class="info" id="passwordTip"></em><em class="info" id="validateid"></em>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            用户名：
                                        </th>
                                        <td>
                                            <input type="text" class="enterinputext" id="txtUserName" name="username" maxlength="256"
                                                value="" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            密码：
                                        </th>
                                        <td>
                                            <input type="password" class="enterinputext" id="txtPassword" name="password" maxlength="32"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                        </th>
                                        <td class="logOnclause">
                                            <asp:CheckBox type="checkbox" ID="chkPersistCookie" runat="server" Checked="true" />
                                            <em>自动登录</em><asp:Button ID="btnLogOn" CssClass="enterbutton" runat="server" Text=""
                                                OnClick="btnLogOn_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                        </th>
                                        <td>
                                            <p class="enterfoot">
                                                <a href="pws.aspx">忘记密码</a>&nbsp;|&nbsp;<a href="register.aspx">注册</a></p>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="enterfooter">
                        <div class="entercopyrights">
                            <ul>
                                <!--
                                <li><a href="about.aspx" target="_blank">关于本系统</a></li>
                                <li><a href="help.aspx" target="_blank">帮助中心</a></li>
                                <li><a href="service.aspx" target="_blank">服务条款</a></li>
                                -->
                            </ul>
                            <p>Copyright @ 2003 - 2012 Hairihan TECH, Ltd . All Rights Reserved</p>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="txtReturnURL" Value="Default.aspx" runat="server" />
                </form>
            </td>
        </tr>
    </table>
</body>
</html>
