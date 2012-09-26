<%@ Page Title="消息管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Common_Messages" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="toolbar">
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="301px" BoxWidth="440px" Url="MessagesForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif" EnableViewState="false"><b>添加消息</b></XCL:LinkBox>
        关键字：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查询" />
    </div>
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="ods" AllowPaging="True" AllowSorting="True" CssClass="m_table" PageSize="20" CellPadding="0" GridLines="None" EnableModelValidation="True" EnableViewState="false">
        <Columns>
            <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="20px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>--%>
            <asp:BoundField DataField="Id" HeaderText="编号" SortExpression="Id" InsertVisible="False" ReadOnly="True" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="Ikey" />
            </asp:BoundField>
            <asp:BoundField DataField="FullName" HeaderText="姓名" SortExpression="FullName" />
            <asp:BoundField DataField="Email" HeaderText="邮箱" SortExpression="Email" />
            <%--<asp:BoundField DataField="CategoryId" HeaderText="问题类别" SortExpression="CategoryId" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="key" />
            </asp:BoundField>--%>
            <asp:BoundField DataField="CategoryName" HeaderText="问题类别" SortExpression="CategoryId" />
            <asp:BoundField DataField="Remark" HeaderText="备注" SortExpression="Remark" />
            <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="MessagesForm.aspx?Id={0}" Height="301px" Text="编辑" Width="440px" Title="编辑消息">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
            </XCL:LinkBoxField>
            <asp:TemplateField ShowHeader="False" HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick='return confirm("确定删除吗？")' Text="删除"></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            没有符合条件的数据！
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ods" runat="server" EnablePaging="True" SelectCountMethod="SearchCount" SelectMethod="Search" SortParameterName="orderClause" EnableViewState="false">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtKey" Name="key" PropertyName="Text" Type="String" />
            <asp:Parameter Name="orderClause" Type="String" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>