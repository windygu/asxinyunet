<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HtmlBillShow.aspx.cs" Inherits="HtmlBillShow" %>

<%@ Register Src="../../Common/Attachment/Attachment.ascx" TagName="Attachment" TagPrefix="Attachment" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table id="table_taskallot" class="table" width="100%" height="100%" border="0" cellpadding="0"
        cellspacing="0">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblUserBill" runat="server" Text="用户单据内容"></asp:Label>
            </td>
        </tr>
        <tr runat="server" id="trAttachment">
            <td class="td-title" width="100px">
                附件：
            </td>
            <td class="td-content">
                <Attachment:Attachment ID="AttachmentHtmlBill" runat="server" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtObjectId" runat="server" />
    <asp:HiddenField ID="txtCurrentId" runat="server" />
    </form>
</body>
</html>
