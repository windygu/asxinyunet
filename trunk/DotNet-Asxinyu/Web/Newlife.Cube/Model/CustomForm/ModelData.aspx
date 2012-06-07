<%@ Page Title="表单数据" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true"
    CodeFile="ModelData.aspx.cs" Inherits="Model_CustomForm_ModelData" %>

<%@ Register TagPrefix="Custom" TagName="Tag" Src="Tag.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="Server">
    <Custom:Tag ID="tag" runat="server" />
    <div class="toolbar">
        关键字：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查询" />
    </div>
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        AllowPaging="True" AllowSorting="True" CssClass="m_table"
        PageSize="20" CellPadding="0" GridLines="None" 
        EnableModelValidation="True" EnableViewState="False" 
        onrowdeleting="gv_RowDeleting">
        <Columns>
            <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="ModelDataForm.aspx?ID={0}"
                Height="400px" Text="编辑" Width="500px" Title="编辑表单数据">
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
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>
