<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>
<!-- Put IE into quirks mode -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>工作流程审批系统 - 注册向导一</title>
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
                <span class="logo"></span>
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
                    <img src="Themes/Default/Images/zc4_06.png" />
                    <span></span>
                </h1>
                <form id="Form1" method="post" runat="server">
                <table>
                    <tr>
                        <th>
                            电子邮箱：
                        </th>
                        <td>
                            <input type="text" class="inputext" name="email" id="txtEmail" maxlength="256" value=""
                                runat="server" onblur="emailBlur(this);" onmousedown="emailFocus();" />
                            <input id="Hidden1" type="hidden" value="" name="regsource" runat="server" />
                            <input id="Hidden2" type="hidden" value="" name="inviter" runat="server" />
                            <em class="info" id="regemailTip"></em><span class="logOninfo" style="font-weight: 700">
                                请您务必填写真实有效的邮箱地址，以便接收激活邮件！</span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            用户名：
                        </th>
                        <td>
                            <input type="text" class="inputext" name="username" id="txtUserName" maxlength="32"
                                value="" runat="server" onblur="usernameBlur();" onmousedown="usernameFocus();" />
                            <em class="info" id="usernameTip"></em><span class="logOninfo">你喜爱的称呼，中英文都行</span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            密码：
                        </th>
                        <td>
                            <input type="password" class="inputext" name="password" id="txtPwd" maxlength="32"
                                runat="server" onblur="pwdBlur(this);" onmousedown="pwdFocus();" />
                            <em class="info" id="passwordTip"></em><span class="logOninfo">密码 6-32位</span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            重复密码：
                        </th>
                        <td>
                            <input type="password" class="inputext" name="repassword" id="txtPwd2" maxlength="32"
                                runat="server" onblur="pwd2Blur(this);" onmousedown="pwd2Focus();" />
                            <em class="info" id="password2Tip"></em><span class="logOninfo">重复密码6-32位</span>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            输入验证码：
                        </th>
                        <td>
                            <input type="text" class="inputextmin" name="vercode" id="txtCaptcha" maxlength="4"
                                onblur="captchaBlur();" onmousedown="captchaBlur();" runat="server" />
                            <img  width="77px" height="22px" src="ValidateHelper.aspx" alt="图片看不清？点击重新得到验证码" id="captchaimg" style="cursor: hand;" /><a
                                href="javascript:reloadcaptcha();" class="code">看不清</a> &nbsp;&nbsp;&nbsp;&nbsp;<em
                                    class="info" id="captchaTip"></em>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        </th>
                        <td class="logOnclause">
                            <input type="checkbox" name="agreed" id="s1" />
                            <em>我已经阅读并同意</em>《<a href="service.aspx" target="_blank">服务条款</a>》
                        </td>
                    </tr>
                    <tr>
                        <th>
                        </th>
                        <td>
                            <asp:Button ID="btnRegister" CssClass="logOnbutton" runat="server" Text="" ToolTip="注册电子商务平台账号"
                                OnClick="btnRegister_Click" OnClientClick="return validate();" />
                        </td>
                    </tr>
                </table>
                <input id="Hidden3" type="hidden" name="struts.token.name" value="struts.token" runat="server" />
                <input id="Hidden4" type="hidden" name="struts.token" value="3F05FD4NT1BIV6S3Q2I175HVH5KWSA95"
                    runat="server" />
                </form>
                <p class="rightinfo">
                    <span onclick="window.open('logOn.aspx',target='_top');">已注册请登录</span> 通过电子商务平台您可以便捷地了解香烟信息，还可以得到我们让您满意的服务。
                </p>
            </div>
        </div>
    </div>
    <div class="foot">
        <div class="entercopyright">
            <ul>
                <li><a href="about.aspx" target="_blank">关于电子商务平台</a></li>
                <li><a href="help.aspx" target="_blank">帮助中心</a></li>
                <li><a href="service.aspx" target="_blank">服务条款</a></li>
                <li class="last"><a href="#" target="_blank">论坛</a></li>
            </ul>
            <p>
                Copyright @ 2008 - 2009 Shoppings All Rights Reserved</p>
        </div>
    </div>

    <script type="text/javascript">
        function reloadcaptcha() {
            document.getElementById("captchaimg").src = "ValidateHelper.aspx?next" + new Date();
        }
    </script>

</body>
</html>
