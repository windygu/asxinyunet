<%@ Page Title="数据模型管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master"
    AutoEventWireup="true" CodeFile="DataModel.aspx.cs" Inherits="Cube_DataModel" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="toolbar">
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="370px" BoxWidth="440px" Url="DataModelForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif"><b>添加数据模型</b></XCL:LinkBox>
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
            <asp:BoundField DataField="DisplayName" HeaderText="名称" SortExpression="Name" />
            <asp:TemplateField HeaderText="是否静态" SortExpression="IsStatic">
                <ItemTemplate>
                    <asp:Label ID="IsStatic1" runat="server" Text="√" Visible='<%# Eval("IsStatic") %>' Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="IsStatic2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("IsStatic") %>' Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="是否启用" SortExpression="IsEnable">
                <ItemTemplate>
                    <asp:Label ID="IsEnable1" runat="server" Text="√" Visible='<%# Eval("IsEnable") %>'
                        Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="IsEnable2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("IsEnable") %>'
                        Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="ConnName" HeaderText="连接名" SortExpression="ConnName" />
            <asp:BoundField DataField="NameSpace" HeaderText="命名空间" SortExpression="NameSpace" />
            <asp:BoundField DataField="TablePrefix" HeaderText="表名前缀" SortExpression="TablePrefix" />
            <asp:BoundField DataField="TemplatePath" HeaderText="模版" SortExpression="TemplatePath" />
            <asp:BoundField DataField="StylePath" HeaderText="样式" SortExpression="StylePath" />
            <asp:BoundField DataField="CreateTime" HeaderText="创建时间" SortExpression="CreateTime"
                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="LastModify" HeaderText="最后修改" SortExpression="LastModify"
                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="../ModelDesigner/ModelTable.aspx?DataModelID={0}"
                HeaderText="管理模型表" Text="管理模型表" />
            <asp:ButtonField CommandName="ExportXml" HeaderText="导出Xml" Text="导出Xml" />
            <asp:ButtonField CommandName="ExportZip" HeaderText="导出Zip" Text="导出Zip" />
            <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="DataModelForm.aspx?ID={0}"
                Height="370px" Text="编辑" Width="440px" Title="编辑数据模型">
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
            <asp:ControlParameter ControlID="txtKey" Name="key" PropertyName="Text" Type="String" />
            <asp:Parameter Name="orderClause" Type="String" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>
