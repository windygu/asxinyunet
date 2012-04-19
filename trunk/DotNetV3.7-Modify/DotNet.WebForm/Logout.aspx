<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogOut.aspx.cs" Inherits="LogOut" %>
<%@ Import Namespace="DotNet.Utilities" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%= BaseSystemInfo.SoftFullName%> - 退出</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="txtReturnURL" Value="LogOn.aspx" runat="server" />
    </form>
</body>
</html>
