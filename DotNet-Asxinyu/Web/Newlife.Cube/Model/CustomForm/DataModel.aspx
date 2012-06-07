<%@ Page Title="类别管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true"
    CodeFile="DataModel.aspx.cs" Inherits="Cube_CustomForm_DataModel" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="toolbar">
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="200px" BoxWidth="440px" Url="DataModelForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif"><b>添加类别</b></XCL:LinkBox>
        关键字：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查询" />
    </div>
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="ods" AllowPaging="True" AllowSorting="True" CssClass="m_table"
        PageSize="20" CellPadding="0" GridLines="None" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" InsertVisible="False"
                ReadOnly="True">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="key" />
            </asp:BoundField>
            <asp:BoundField DataField="DisplayName" HeaderText="名称" SortExpression="Name" >
            <ItemStyle Font-Bold="True" Font-Size="16pt" />
            </asp:BoundField>
            <asp:BoundField DataField="TablesCount" HeaderText="表单数" DataFormatString="{0:n0}">
                <ItemStyle HorizontalAlign="Right" Font-Bold="true" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ModelTable.aspx?DataModelID={0}"
                HeaderText="管理表单" Text="管理表单" >
            <ItemStyle BackColor="#CCFF99" Font-Bold="True" Font-Size="16pt" 
                ForeColor="Red" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="CreateTime" HeaderText="创建时间" SortExpression="CreateTime"
                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="LastModify" HeaderText="最后修改" SortExpression="LastModify"
                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>
            <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="DataModelForm.aspx?ID={0}"
                Height="200px" Text="编辑" Width="440px" Title="编辑类别">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
            </XCL:LinkBoxField>
            <asp:TemplateField ShowHeader="False" HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete"
                        OnClientClick='return confirm("删除类别将同时删除该类之下所有表单！\n确定删除吗？")' Text="删除"></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            没有符合条件的数据！
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ods" runat="server" EnablePaging="True" SelectCountMethod="SearchCount"
        SelectMethod="Search" SortParameterName="orderClause" DeleteMethod="Delete">
        <SelectParameters>
            <asp:Parameter Name="isEnable" Type="Boolean" DefaultValue="true" />
            <asp:Parameter Name="isStatic" Type="Boolean" DefaultValue="false" />
            <asp:ControlParameter ControlID="txtKey" Name="key" PropertyName="Text" Type="String" />
            <asp:Parameter Name="orderClause" Type="String" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>
