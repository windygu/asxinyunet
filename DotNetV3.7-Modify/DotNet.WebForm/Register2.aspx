<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register2.aspx.cs" Inherits="Register2" %>


<!-- Put IE into quirks mode -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />
    <title>工作流程审批系统 - 注册向导二</title>
    <link href="Themes/Default/layout.css" type="text/css" rel="stylesheet" />

    <script src="JavaScript/jquery.js" type="text/javascript"></script>

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
        <form id="dbknewregister" method="post" runat="server">
        <div class="wrapcontent">
            <div class="mainside">
                <h1>
                    <img src="Themes/Default/Images/zq3_03.png" /></h1>
                <div class="contentmain">
                    <div class="pheight">
                        <h2>
                            您的激活邮箱：</h2>
                        <h2 id="account" runat="server">
                        </h2>
                        <p>
                            <br />
                            <strong>请选择帐号激活方式：</strong><br />
                            <br />
                        </p>
                    </div>
                    <div class="pheight">
                        <div class="activation1">
                            <p>
                                <br />
                                <em class="titleicon"></em>
                                <h2>
                                    快速激活通道</h2>
                                <span>(推荐使用)</span><br />
                                <br />
                                <p>
                                    <a href="logOn.aspx" class="activation"></a>
                                </p>
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;通过直接登录您的注册邮箱<br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;激活 Shoppings
                                账号<br />
                            </p>
                        </div>
                        <div class="activation3">
                            <p>
                                <br />
                                <em class="titleicon"></em>
                                <h2>
                                    发送激活邮件</h2>
                                <br />
                                <br />
                                <p>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                        ID="lnkSendEmail" runat="server" OnClick="lnkSendEmail_Click" OnClientClick="this.disabled='disabled'">发送激活邮件>></asp:LinkButton></p>
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发送激活邮件到您的注册邮箱<br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;点击邮件中的的激活链接激活<br />
                                <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Shoppings帐号
                        </div>
                    </div>
                </div>
            </div>
            <div class="org">
                <img alt="" src="Themes/Default/Images/t_07.png" align="absmiddle" />&nbsp;&nbsp;重要提示：为了您能正确激活Shoppings帐号，请您务必使用常用邮箱作为Shoppings帐号。<br />
                <p>
                    如填写不正确，请点击“上一步”，重新填写注册信息。&nbsp;&nbsp;&nbsp;</p>
            </div>
            <br />
            <p style="text-align: right; padding-right: 244px;">
                <input type="button" class="logOnbutton_l" value="" onclick="javascript:location.href='register.aspx';" /></p>
        </div>
        <input type="hidden" value="" id="email" name="email" runat="server" />
        <input type="hidden" value="" id="username" name="username" runat="server" />
        <input type="hidden" value="" id="code" name="code" runat="server" />
        </form>
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
</body>
</html>
