<%@ Page Title="模型索引管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true" CodeFile="ModelIndex.aspx.cs" Inherits="Cube_ModelIndex" %>

<%@ Register TagPrefix="Custom" TagName="Tag" Src="Tag.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <Custom:Tag ID="tag" runat="server" />
    <div class="toolbar">
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="265px" BoxWidth="440px" Url="ModelIndexForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif"><b>添加模型索引</b></XCL:LinkBox>
        关键字：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查询" />
    </div>
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ods" AllowPaging="True" AllowSorting="True" CssClass="m_table" PageSize="20" CellPadding="0" GridLines="None" EnableModelValidation="True">
        <Columns>
            <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="20px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>--%>
            <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" InsertVisible="False" ReadOnly="True" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="key" />
            </asp:BoundField>
            <asp:BoundField DataField="ModelTableName" HeaderText="模型表" SortExpression="ModelTableID" />
            <asp:BoundField DataField="Name" HeaderText="名称" SortExpression="Name" />
            <asp:BoundField DataField="Columns" HeaderText="数据列" SortExpression="Columns" />
            <asp:TemplateField HeaderText="唯一" SortExpression="Unique">
                <ItemTemplate>
                    <asp:Label ID="Unique1" runat="server" Text="√" Visible='<%# Eval("Unique") %>' Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="Unique2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("Unique") %>' Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否主键" SortExpression="PrimaryKey">
                <ItemTemplate>
                    <asp:Label ID="PrimaryKey1" runat="server" Text="√" Visible='<%# Eval("PrimaryKey") %>' Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="PrimaryKey2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("PrimaryKey") %>' Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否计算产生" SortExpression="Computed">
                <ItemTemplate>
                    <asp:Label ID="Computed1" runat="server" Text="√" Visible='<%# Eval("Computed") %>' Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="Computed2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("Computed") %>' Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ModelIndexForm.aspx?ID={0}" Height="265px" Text="编辑" Width="440px" Title="编辑模型索引">
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
    <asp:ObjectDataSource ID="ods" runat="server" EnablePaging="True" SelectCountMethod="SearchCount" SelectMethod="Search" SortParameterName="orderClause">
        <SelectParameters>
            <asp:QueryStringParameter Name="tableid" QueryStringField="ModelTableID" Type="Int32" />
            <asp:ControlParameter ControlID="txtKey" Name="key" PropertyName="Text" Type="String" />
            <asp:Parameter Name="orderClause" Type="String" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>