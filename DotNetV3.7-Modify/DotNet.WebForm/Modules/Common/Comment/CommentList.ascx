<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentList.ascx.cs" Inherits="CommentList" %>
<asp:GridView ID="grdComment" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    DataKeyNames="ID" Width="100%" CellPadding="1" BorderColor="#CCCCCC" BorderWidth="1px"
    BackColor="White" OnRowDeleting="grdComment_RowDeleting" OnRowDataBound="grdComment_RowDataBound"
    AllowSorting="True">
    <Columns>
        <asp:TemplateField HeaderText="No">
            <ItemTemplate>
                <%# (this.grdComment.PageSize * this.grdComment.PageIndex) + this.grdComment.Rows.Count + 1%>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False" />
            <HeaderStyle Wrap="False" Font-Bold="False" />
        </asp:TemplateField>
        <asp:BoundField DataField="CreateBy" HtmlEncode="False" HeaderText="评论者">
            <HeaderStyle Font-Bold="False" />
            <ItemStyle CssClass="leftBlank" Width="75px" Wrap="False" />
        </asp:BoundField>
        <asp:BoundField DataField="Contents" HeaderText="内容">
            <HeaderStyle Font-Bold="False" />
            <ItemStyle CssClass="leftBlank" />
        </asp:BoundField>
        <asp:BoundField DataField="CreateOn" HeaderText="日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
            <HeaderStyle Font-Bold="False" />
            <ItemStyle HorizontalAlign="Center" Width="150px" Wrap="False" />
        </asp:BoundField>
        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; ToolTip=&quot;删除&quot;/&gt;">
            <ItemStyle Width="40px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
            <HeaderStyle Font-Bold="False" />
        </asp:CommandField>
    </Columns>
    <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
        BackColor="#EFEFEF" Font-Size="12px"></HeaderStyle>
    <AlternatingRowStyle BackColor="WhiteSmoke" />
    <PagerSettings Visible="False" />
</asp:GridView>
<asp:HiddenField ID="txtCategoryCode" runat="server" />
<asp:HiddenField ID="txtObjectId" runat="server" />