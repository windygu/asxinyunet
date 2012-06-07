<%@ Page Title="静态生成" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true"
    CodeFile="StaticRenderForm.aspx.cs" Inherits="Cube_ModelManage_StaticRenderForm" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">
                生产模型
                <asp:Label ID="frmName" runat="server" />
            </th>
        </tr>
        <tr>
            <td align="right">
                模型表：
            </td>
            <td>
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                    DataSourceID="ods" AllowPaging="True" AllowSorting="True" CssClass="m_table"
                    PageSize="20" CellPadding="0" GridLines="None" EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cb" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="20px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="名称" SortExpression="Name" />
                        <asp:BoundField DataField="TableName" HeaderText="表名" SortExpression="TableName" />
                        <asp:BoundField DataField="Description" HeaderText="注释" SortExpression="Description" />
                        <asp:TemplateField HeaderText="视图" SortExpression="IsView">
                            <ItemTemplate>
                                <asp:Label ID="IsView1" runat="server" Text="√" Visible='<%# Eval("IsView") %>' Font-Bold="True"
                                    Font-Size="14pt" ForeColor="Green"></asp:Label>
                                <asp:Label ID="IsView2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("IsView") %>'
                                    Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        没有符合条件的数据！
                    </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource ID="ods" runat="server" EnablePaging="True" SelectCountMethod="SearchCount"
                    SelectMethod="Search" SortParameterName="orderClause" DataObjectTypeName="NewLife.Cube.Entities.ModelTable"
                    TypeName="NewLife.Cube.Entities.ModelTable">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="modelid" QueryStringField="ID" Type="Int32" />
                        <asp:Parameter Name="key" Type="String" />
                        <asp:Parameter Name="orderClause" Type="String" />
                        <asp:Parameter Name="startRowIndex" Type="Int32" />
                        <asp:Parameter Name="maximumRows" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <XCL:GridViewExtender ID="gvExt" runat="server">
                </XCL:GridViewExtender>
            </td>
        </tr>
        <tr>
            <td align="right">
                模版：
            </td>
            <td>
                <asp:DropDownList ID="cfgTemplateName" runat="server">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="btnReleaseEmbedTemplates" runat="server" Text="释放内置模版" 
                    onclick="btnReleaseEmbedTemplates_Click" />
                &nbsp;<asp:CheckBox ID="cfgDebug" runat="server" Text="调试" />
            </td>
        </tr>
        <tr>
            <td align="right">
                配置：
            </td>
            <td>
                命名空间：<asp:TextBox ID="cfgNameSpace" runat="server" />&nbsp; 连接名：<asp:TextBox ID="cfgEntityConnName"
                    runat="server" Width="80px" /><br />
                实体基类：<asp:TextBox ID="cfgBaseClass" runat="server" />&nbsp;
                <asp:CheckBox ID="cfgRenderGenEntity" runat="server" Text="生成泛型实体类" /><br />
                输出目录：<asp:TextBox ID="cfgOutputPath" runat="server" />&nbsp;相对于站点根目录。<br />
                <asp:CheckBox ID="cfgUseHeadTemplate" runat="server" Text="使用.cs文件头部模版" /><br />
                <asp:TextBox ID="cfgHeadTemplate" runat="server" Height="107px" TextMode="MultiLine"
                    Width="388px" /><br />
            </td>
        </tr>
    </table>
    <table border="0" align="Center" width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnRender" runat="server" CausesValidation="True" Text='生成' OnClick="btnRender_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
