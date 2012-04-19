<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RoleInfo.ascx.cs" Inherits="RoleInfo" %>
<table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
    cellspacing="0">
    <tr>
        <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
            编号：
        </td>
        <td class="td-content" style="padding-top: 3">
            
            <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
            
        </td>
    </tr>
    <tr>
        <td height="25" align="right" nowrap="nowrap" class="td-title">
            名称：
        </td>
        <td class="td-content" style="padding-top: 3">
            <asp:Label ID="lblRealname" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td height="25" align="right" nowrap="nowrap" class="td-title">
            备注：
        </td>
        <td class="td-content" style="padding-top: 3">
            <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
</table>
