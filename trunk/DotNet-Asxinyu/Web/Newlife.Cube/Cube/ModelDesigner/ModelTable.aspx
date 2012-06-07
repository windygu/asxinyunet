<%@ Page Title="模型表管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master"
    AutoEventWireup="true" CodeFile="ModelTable.aspx.cs" Inherits="Cube_ModelTable" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="toolbar">
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="292px" BoxWidth="440px" Url="ModelTableForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif"><b>添加模型表</b></XCL:LinkBox>
        关键字：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查询" />
    </div>
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="ods" AllowPaging="True" AllowSorting="True" CssClass="m_table"
        PageSize="20" CellPadding="0" GridLines="None" EnableModelValidation="True" OnRowCommand="gv_RowCommand">
        <Columns>
            <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="20px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>--%>
            <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" InsertVisible="False"
                ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="key" />
            </asp:BoundField>
            <asp:BoundField DataField="DataModelName" HeaderText="数据模型" SortExpression="DataModelID" />
            <asp:BoundField DataField="Name" HeaderText="名称" SortExpression="Name" />
            <asp:BoundField DataField="TableName" HeaderText="表名" SortExpression="TableName" />
            <asp:BoundField DataField="Owner" HeaderText="所有者" SortExpression="Owner" />
            <asp:BoundField DataField="DatabaseType" HeaderText="数据库类型" SortExpression="DbType" />
            <asp:TemplateField HeaderText="视图" SortExpression="IsView">
                <ItemTemplate>
                    <asp:Label ID="IsView1" runat="server" Text="√" Visible='<%# Eval("IsView") %>' Font-Bold="True"
                        Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="IsView2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("IsView") %>'
                        Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="Sort" HeaderText="排序" SortExpression="Sort" DataFormatString="{0:n0}">
                <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="升" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID") %>'
                        CommandName="Up" Text="↑" Font-Size="12pt" ForeColor="Red" Visible='<%# Container.DataItemIndex!=0 %>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Font-Size="12pt" ForeColor="Red" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="降" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ID") %>'
                        CommandName="Down" Text="↓" Font-Size="12pt" ForeColor="Green" Visible='<%# Container.DataItemIndex!=gvExt.RowCount-1 %>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Font-Size="12pt" ForeColor="Green" />
            </asp:TemplateField>
            <asp:BoundField DataField="TemplatePath" HeaderText="模版" SortExpression="TemplatePath" />
            <asp:BoundField DataField="StylePath" HeaderText="样式" SortExpression="StylePath" />
            <asp:BoundField DataField="Description" HeaderText="注释" SortExpression="Description" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ModelColumn.aspx?ModelTableID={0}"
                HeaderText="管理列" Text="管理列" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ModelIndex.aspx?ModelTableID={0}"
                HeaderText="管理索引" Text="管理索引" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ModelRelation.aspx?ModelTableID={0}"
                HeaderText="管理关系" Text="管理关系" />
            <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ModelTableForm.aspx?ID={0}"
                Height="292px" Text="编辑" Width="440px" Title="编辑模型表">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
            </XCL:LinkBoxField>
            <asp:TemplateField ShowHeader="False" HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                        OnClientClick='return confirm("确定删除吗？")' Text="删除"></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            没有符合条件的数据！
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ods" runat="server" EnablePaging="True" SelectCountMethod="SearchCount"
        SelectMethod="Search" SortParameterName="orderClause">
        <SelectParameters>
            <asp:QueryStringParameter Name="modelid" QueryStringField="DataModelID" Type="Int32" />
            <asp:ControlParameter ControlID="txtKey" Name="key" PropertyName="Text" Type="String" />
            <asp:Parameter Name="orderClause" Type="String" DefaultValue="Sort" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>
