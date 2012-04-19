<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AuditList.ascx.cs" Inherits="AuditList" %>
<asp:GridView ID="grdAudit" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    CellPadding="1" Width="100%" BorderColor="#CCCCCC" BorderWidth="1px" BackColor="White"
    OnRowDataBound="grdAudit_RowDataBound" AllowSorting="True">
    <Columns>
        <asp:BoundField DataField="AuditUserRealname" HtmlEncode="False" HeaderText="审核">
            <HeaderStyle Font-Bold="False" Wrap="False" Width="100px" />
            <ItemStyle CssClass="leftBlank" Wrap="False" />
        </asp:BoundField>
        <asp:BoundField DataField="AuditIdea" HeaderText="意见">
            <HeaderStyle Font-Bold="False" Wrap="False" />
            <ItemStyle CssClass="leftBlank" />
        </asp:BoundField>
    </Columns>
    <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
        BackColor="#EFEFEF" Font-Size="12px"></HeaderStyle>
    <AlternatingRowStyle BackColor="WhiteSmoke" />
    <PagerSettings Visible="False" />
</asp:GridView>
<asp:HiddenField ID="txtCurrentFlowId" runat="server" />

<!--
        <asp:BoundField DataField="AuditStatus" HeaderText="状态" HtmlEncode="False" SortExpression="AuditStatus">
            <HeaderStyle HorizontalAlign="Center" Font-Bold="False" Wrap="False" Width="40px" />
            <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
        </asp:BoundField>
        <asp:BoundField DataField="SendDate" HeaderText="日期" HtmlEncode="False" DataFormatString="{0:MM-dd HH:mm}">
            <HeaderStyle Font-Bold="False" Wrap="False" Width="70px" />
            <ItemStyle HorizontalAlign="Center" Wrap="False" />
        </asp:BoundField>
-->