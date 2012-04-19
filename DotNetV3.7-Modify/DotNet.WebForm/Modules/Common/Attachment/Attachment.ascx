<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Attachment.ascx.cs" Inherits="Attachment" %>
<asp:FileUpload ID="fupAttachment01" runat="server" EnableViewState="true" Width="350px" /><br>
<asp:FileUpload ID="fupAttachment02" runat="server" EnableViewState="true" Width="350px" />
<asp:FileUpload ID="fupAttachment03" runat="server" Visible="false" EnableViewState="true" Width="350px" />
<asp:FileUpload ID="fupAttachment04" runat="server" Visible="false" EnableViewState="true" Width="350px" />
<asp:GridView ID="grdAttachment" runat="server" AutoGenerateColumns="False" DataKeyNames="FileUrl"
    CellPadding="1" BorderColor="#CCCCCC" BorderWidth="1px" BackColor="White" OnRowDataBound="grdAttachment_RowDataBound"
    ShowHeader="False" OnRowDeleting="grdAttachment_RowDeleting">
    <Columns>
        <asp:TemplateField HeaderText="No">
            <ItemTemplate>
                <%# (this.grdAttachment.PageSize * this.grdAttachment.PageIndex) + this.grdAttachment.Rows.Count + 1%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False" />
            <HeaderStyle Wrap="False" Font-Bold="False" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="表格" SortExpression="Title">
            <ItemTemplate>
                &nbsp;<img src="../../../Themes/Default/Images/Download.gif" border="0">&nbsp;<asp:HyperLink
                    ID="hylFileUrl" NavigateUrl="<%# Eval(&quot;FileUrl&quot;,&quot;~/{0}&quot;) %>"
                    Target="_blank" Text='<%# DataBinder.Eval(Container.DataItem, "FileName") %>'
                    runat="server"></asp:HyperLink></a>
            </ItemTemplate>
            <ItemStyle Wrap="False" />
            <HeaderStyle Font-Bold="False" />
        </asp:TemplateField>
        <asp:BoundField DataField="CreationTime" HeaderText="上传日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}"
            SortExpression="CreationTime">
            <HeaderStyle Font-Bold="False" />
            <ItemStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
        </asp:BoundField>
        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; ToolTip=&quot;删除&quot;/&gt;">
            <ItemStyle Width="40px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
            <HeaderStyle Font-Bold="False" />
        </asp:CommandField>
    </Columns>
    <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
        BackColor="#EFEFEF" Font-Size="12px"></HeaderStyle>
</asp:GridView>
