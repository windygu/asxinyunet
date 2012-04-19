<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pws.aspx.cs" Inherits="pws" %>
<%@ Import Namespace="DotNet.Utilities" %>
<!-- Put IE into quirks mode -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title><%= BaseSystemInfo.SoftFullName%> - 忘记密码</title>
    <link href="Themes/Default/layout.css" type="text/css" rel="stylesheet" />
    <script src="JavaScript/jquery.js" type="text/javascript"></script>
    <script src="JavaScript/formValidator_min.js" type="text/javascript"></script>
    <script src="JavaScript/formValidatorRegex.js" type="text/javascript"></script>
    <script src="JavaScript/userValidate.js" type="text/javascript"></script>
</head>
<body>
    <div class="wrapmain">
        <div class="wrapheader">
            <div class="headbgleft">
            </div>
            <div id="dbkhead" class="head">
                <!--
                <span class="logo"></span>
                -->
                <div class="headtip">
                    <ul>
                        <li><a href="register.aspx">注册</a>| </li>
                        <li><a href="logOn.aspx">登录</a></li>
                    </ul>
                </div>
            </div>
            <!-- 提示消息 -->
            <div id="dbkmsgtip" class="clewinfo green" style="display: none">
            </div>
        </div>
        <div class="wrapcontent">
            <div class="mainside">
                <h1>
                    <em class="pwstitle"></em>
                </h1>
                <div class="contentmain">
                    <form id="generatepasswd" method="post" runat="server">
                    <table>
                        <tr>
                            <td colspan="2">
                                忘记密码了，请在下面输入您的登录电子邮件，我们会向您的邮箱发送一个重置密码的链接
                            </td>
                        </tr>
                        <tr>
                            <th>
                                电子邮件：
                            </th>
                            <td>
                                <input type="text" name="email" class="inputext" maxlength="256" value="" id="txtEmail"
                                    onblur="emailblur(this);" onmousedown="emailfocus();" runat="server" />
                                <em class="info" id="emailTip"></em>
                            </td>
                        </tr>
                        <tr>
                            <th>
                            </th>
                            <td>
                                <asp:Button ID="btnPwdReset" CssClass="pwsbutton" runat="server" Text="" 
                                    OnClientClick="return validate2()" onclick="btnPwdReset_Click" />
                            </td>
                        </tr>
                    </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div class="foot">
        <div class="entercopyright">
            <ul>
                <!--
                <li><a href="aboup.aspx" target="_blank">关于电子商务平台</a></li>
                <li><a href="help.aspx" target="_blank">帮助中心</a></li>
                <li><a href="service.aspx" target="_blank">服务条款</a></li>
                <li class="last"><a href="#" target="_blank">论坛</a></li>
                -->
            </ul>
            <p>Copyright @ 2003 - 2012 Hairihan TECH, Ltd . All Rights Reserved</p>
        </div>
    </div>
</body>
</html>
