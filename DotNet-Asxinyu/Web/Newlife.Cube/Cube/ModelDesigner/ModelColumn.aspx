<%@ Page Title="模型列管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master"
    AutoEventWireup="true" CodeFile="ModelColumn.aspx.cs" Inherits="Cube_ModelColumn" %>

<%@ Register TagPrefix="Custom" TagName="Tag" Src="Tag.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <Custom:Tag ID="tag" runat="server" />
    <div class="toolbar">
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="508px" BoxWidth="440px" Url="ModelColumnForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif" EnableViewState="false"><b>添加模型列</b></XCL:LinkBox>
        关键字：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查询" />
    </div>
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="ods" AllowPaging="True" AllowSorting="True" CssClass="m_table"
        PageSize="20" CellPadding="0" GridLines="None" EnableModelValidation="True" EnableViewState="false"
        OnRowCommand="gv_RowCommand">
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
            <asp:BoundField DataField="ModelTableName" HeaderText="模型表" SortExpression="ModelTableID" />
            <asp:BoundField DataField="Description" HeaderText="注释" SortExpression="Description" />
            <asp:BoundField DataField="Name" HeaderText="名称" SortExpression="Name" />
            <asp:BoundField DataField="Alias" HeaderText="别名" SortExpression="Alias" />
            <asp:BoundField DataField="DataType" HeaderText="数据类型" SortExpression="DataType" />
            <asp:BoundField DataField="RawType" HeaderText="原始类型" SortExpression="RawType" />
            <asp:BoundField DataField="Control" HeaderText="控件类型" SortExpression="ControlType">
                <ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="Blue" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="标识" SortExpression="Identity">
                <ItemTemplate>
                    <asp:Label ID="Identity1" runat="server" Text="√" Visible='<%# Eval("Identity") %>'
                        Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="Identity2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("Identity") %>'
                        Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="主键" SortExpression="PrimaryKey">
                <ItemTemplate>
                    <asp:Label ID="PrimaryKey1" runat="server" Text="√" Visible='<%# Eval("PrimaryKey") %>'
                        Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="PrimaryKey2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("PrimaryKey") %>'
                        Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="Length" HeaderText="长度" SortExpression="Length" DataFormatString="{0:n0}">
                <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
            </asp:BoundField>
            <asp:BoundField DataField="NumOfByte" HeaderText="字节数" SortExpression="NumOfByte"
                DataFormatString="{0:n0}">
                <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
            </asp:BoundField>
            <asp:BoundField DataField="Precision" HeaderText="精度" SortExpression="Precision"
                DataFormatString="{0:n0}">
                <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
            </asp:BoundField>
            <asp:BoundField DataField="Scale" HeaderText="位数" SortExpression="Scale" DataFormatString="{0:n0}">
                <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="允许空" SortExpression="Nullable">
                <ItemTemplate>
                    <asp:Label ID="Nullable1" runat="server" Text="√" Visible='<%# Eval("Nullable") %>'
                        Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="Nullable2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("Nullable") %>'
                        Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unicode" SortExpression="IsUnicode">
                <ItemTemplate>
                    <asp:Label ID="IsUnicode1" runat="server" Text="√" Visible='<%# Eval("IsUnicode") %>'
                        Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                    <asp:Label ID="IsUnicode2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("IsUnicode") %>'
                        Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="Selects" HeaderText="选项" SortExpression="Selects" />
            <asp:BoundField DataField="Default" HeaderText="默认值" SortExpression="Default" />
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
            <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ModelColumnForm.aspx?ID={0}"
                Height="508px" Text="编辑" Width="440px" Title="编辑模型列">
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
        SelectMethod="Search" SortParameterName="orderClause" EnableViewState="false">
        <SelectParameters>
            <asp:QueryStringParameter Name="tableid" QueryStringField="ModelTableID" Type="Int32" />
            <asp:ControlParameter ControlID="txtKey" Name="key" PropertyName="Text" Type="String" />
            <asp:Parameter Name="orderClause" Type="String" DefaultValue="Sort" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>
