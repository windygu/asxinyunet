<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Loading.aspx.cs" Inherits="Loading" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">
    <title>Loading</title>
</head>
<body onload="redirectUrl()">
    <table width="100%" height="380" border="0" cellpadding="4" cellspacing="0">
        <tr>
            <td align="center" valign="middle">
                <%
                    string tip = "转入中，请稍候... ";	
                %>
                <%=tip%><img src="Images/loading.gif" width="58px" height="58px" align="absmiddle" />
            </td>
        </tr>
    </table>

    <script language="javascript" type="text/javascript">
        function redirectUrl(oToHide) {
            location.href = "<%=GetRedirectUrl()%>";
        }
    </script>

</body>
</html>