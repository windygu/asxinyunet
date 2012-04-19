<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowUserBill.aspx.cs" Inherits="ShowUserBill" %>

<%@ Register Src="AuditList.ascx" TagName="AuditList" TagPrefix="AuditList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>单据内容</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/ticStyle.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
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
<body style="margin-top: 10px">
    <form id="form1" runat="server">
    <table width="100%" leftmargin="0" topmargin="0">
        <tr>
            <td colspan="2" valign="top">
                <%
                    // 只能包含不可执行的文件
                    // Response.WriteFile("../Leave/LeaveAdd.aspx");
                    Server.Execute(this.IframeUrl);
                %>
                <asp:Literal ID="FrameLiteral" runat="server" />
            </td>
        </tr>
        <% if (!string.IsNullOrEmpty(this.CurrentId))
           { 
        %>
        <tr>
            <td colspan="2">
                <table border="0">
                    <tr>
                        <% if (!string.IsNullOrEmpty(this.UserSignatureDate1))
                           { 
                        %>
                        <td style="width: 100px; text-align: center">
                            <image width="100px" src="UserSignature.aspx?Id=<%= this.CurrentId%>&Signature=1"
                                border="0"></image>
                            <%= this.UserSignatureDate1%>
                        </td>
                        <%
                           } 
                        %>
                        <% if (!string.IsNullOrEmpty(this.UserSignatureDate2))
                           { 
                        %>
                        <td valign="middle" style="width: 20px; text-align: center">
                            -&gt;
                        </td>
                        <td style="width: 100px; text-align: center">
                            <image width="100px" src="UserSignature.aspx?Id=<%= this.CurrentId%>&Signature=2"
                                border="0"></image>
                            <%= this.UserSignatureDate2%>
                        </td>
                        <%
                           } 
                        %>
                        <% if (!string.IsNullOrEmpty(this.UserSignatureDate3))
                           { 
                        %>
                        <td valign="middle" style="width: 20px; text-align: center">
                            -&gt;
                        </td>
                        <td style="width: 100px; text-align: center">
                            <image width="100px" src="UserSignature.aspx?Id=<%= this.CurrentId%>&Signature=3"
                                border="0"></image>
                            <%= this.UserSignatureDate3%>
                        </td>
                        <%
                           } 
                        %>
                        <% if (!string.IsNullOrEmpty(this.UserSignatureDate4))
                           { 
                        %>
                        <td valign="middle" style="width: 20px; text-align: center">
                            -&gt;
                        </td>
                        <td style="width: 100px; text-align: center">
                            <image width="100px" src="UserSignature.aspx?Id=<%= this.CurrentId%>&Signature=4"
                                border="0"></image>
                            <%= this.UserSignatureDate4%>
                        </td>
                        <%
                           } 
                        %>
                        <% if (!string.IsNullOrEmpty(this.UserSignatureDate5))
                           { 
                        %>
                        <td valign="middle" style="width: 20px; text-align: center">
                            -&gt;
                        </td>
                        <td style="width: 100px; text-align: center">
                            <image width="100px" src="UserSignature.aspx?Id=<%= this.CurrentId%>&Signature=5"
                                border="0"></image>
                            <%= this.UserSignatureDate5%>
                        </td>
                        <%
                           } 
                        %>
                        <% if (!string.IsNullOrEmpty(this.UserSignatureDate6))
                           { 
                        %>
                        <td valign="middle" style="width: 20px; text-align: center">
                            -&gt;
                        </td>
                        <td style="width: 100px; text-align: center">
                            <image width="100px" src="UserSignature.aspx?Id=<%= this.CurrentId%>&Signature=6"
                                border="0"></image>
                            <%= this.UserSignatureDate6%>
                        </td>
                        <%
                           } 
                        %>
                        <% if (!string.IsNullOrEmpty(this.UserSignatureDate7))
                           { 
                        %>
                        <td valign="middle" style="width: 20px; text-align: center">
                            -&gt;
                        </td>
                        <td style="width: 100px; text-align: center">
                            <image width="100px" src="UserSignature.aspx?Id=<%= this.CurrentId%>&Signature=7"
                                border="0"></image>
                            <%= this.UserSignatureDate7%>
                        </td>
                        <%
                           } 
                        %>
                        <% if (!string.IsNullOrEmpty(this.UserSignatureDate8))
                           { 
                        %>
                        <td valign="middle" style="width: 20px; text-align: center">
                            -&gt;
                        </td>
                        <td style="width: 100px; text-align: center">
                            <image width="100px" src="UserSignature.aspx?Id=<%= this.CurrentId%>&Signature=8"
                                border="0"></image>
                            <%= this.UserSignatureDate8%>
                        </td>
                        <%
                           } 
                        %>
                    </tr>
                </table>
            </td>
        </tr>
        <%
           } 
        %>
        <% if (this.ShowAuditList)
           {
        %>
        <tr>
            <td valign="top" colspan="2" align="center">
                <AuditList:AuditList ID="ucAuditList" AutoFill="false" runat="server" />
            </td>
        </tr>
        <%
           }
        %>
    </table>
    <asp:HiddenField ID="txtObjectId" runat="server" />
    <asp:HiddenField ID="txtCurrentId" runat="server" />
    <asp:HiddenField ID="txtCategoryCode" runat="server" />
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    <asp:HiddenField ID="txtUserId" runat="server" />
    </form>
</body>
</html>
