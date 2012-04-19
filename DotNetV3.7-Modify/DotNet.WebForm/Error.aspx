<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>
<%@ Import Namespace="DotNet.Utilities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%= BaseSystemInfo.SoftFullName%>一 错误处理页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <style type="text/css">
        body
        {
            font-size: 13px;
            background: #eee;
            color: #000;
            padding: 32px;
        }
        div#content
        {
            background: #fff;
            padding: 20px;
            border: 1px solid #bbb;
        }
        h1
        {
            padding-right: 0px;
            padding-left: 0px;
            padding-top: 0px;
            padding-bottom: 10px;
            font-weight: bold;
            font-size: 120%;
            margin: 0px;
            color: #904;
        }
        h2
        {
            padding-right: 0px;
            padding-left: 0px;
            font-weight: bold;
            font-size: 105%;
            padding-bottom: 0px;
            margin: 0px 0px 8px;
            text-transform: uppercase;
            color: #999;
            padding-top: 0px;
            border-bottom: #ddd 1px solid;
            font-family: "trebuchet ms" , "" lucida grande "" , verdana, arial, sans-serif;
        }
        p
        {
            padding-right: 0px;
            padding-left: 0px;
            padding-bottom: 6px;
            margin: 0px;
            padding-top: 6px;
        }
        a:link
        {
            color: #002c99;
            text-decoration: none;
        }
        a:visited
        {
            color: #002c99;
            text-decoration: none;
        }
        a:hover
        {
            color: #cc0066;
            background-color: #f5f5f5;
            text-decoration: underline;
        }
        a
        {
            padding: 0px 5px;
        }
    </style>
</head>
<body style="width: 92%">
    <form id="form1" runat="server">
    <div id="content">
        <h1>
            抱歉！此功能正在建设中...<br />
            <br />
            电话：１３８５８１６３０１１
        </h1>
        <h2>
            Details</h2>
        <p>
            <asp:TextBox ID="txtErrorMsg" runat="server" TextMode="MultiLine" Height="120px" Width="100%"></asp:TextBox>
        </p>
        <table width="100%">
            <tr>
                <td>
                    <input type="checkbox" onclick="ShowStackInfo(this);" />
                    堆栈跟踪
                </td>
                <td align="right">
                    <a href="javascript:void(0);" onclick="history.back();">返回上页</a>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">返回首页</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <div style="display: none" id="stackInfo">
        <br />
        <table width="100%" bgcolor="#ffffcc">
            <tr>
                <td>
                    <pre>
<asp:Label ID="lblStackInfo" runat="server"></asp:Label>
               </pre>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

<script type="text/javascript">
    function ShowStackInfo(chk) {
        if (chk.checked)
            document.getElementById("stackInfo").style.display = "";
        else
            document.getElementById("stackInfo").style.display = "none";
    }
</script>

