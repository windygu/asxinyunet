<%@ Page Title="数据模型管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master"
    AutoEventWireup="true" CodeFile="DataModelForm.aspx.cs" Inherits="Cube_DataModelForm" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">
                数据模型
            </th>
        </tr>
        <tr>
            <td align="right">
                名称：
            </td>
            <td>
                <asp:TextBox ID="frmName" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                是否静态：
            </td>
            <td>
                <asp:CheckBox ID="frmIsStatic" runat="server" Text="是否静态" />
            </td>
        </tr>
        <tr>
            <td align="right">
                是否启用：
            </td>
            <td>
                <asp:CheckBox ID="frmIsEnable" runat="server" Text="是否启用" />
            </td>
        </tr>
        <tr>
            <td align="right">
                连接名：
            </td>
            <td>
                <asp:TextBox ID="frmConnName" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                命名空间：
            </td>
            <td>
                <asp:TextBox ID="frmNameSpace" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                表名前缀：
            </td>
            <td>
                <asp:TextBox ID="frmTablePrefix" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                描述：
            </td>
            <td>
                <asp:TextBox ID="frmDescription" runat="server" TextMode="MultiLine" Width="300px"
                    Height="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                模版路径：
            </td>
            <td>
                <asp:TextBox ID="frmTemplatePath" runat="server" Width="300px"></asp:TextBox>
                <br />
                当前模版：<%= Entity.TemplatePathEx%>
                &nbsp;<asp:Button ID="btnCopy" runat="server" Text='复制' ToolTip="复制一份上级模版作为当前模版！"
                    OnClick="btnCopy_Click" />
                <%--<br />
                &nbsp;<asp:Button ID="btnExport" runat="server" Text='导出到文件' ToolTip="把数据库模版导出到模版文件目录，方便编辑！"
                    OnClick="btnExport_Click" />
                &nbsp;<asp:Button ID="btnImport" runat="server" Text='从文件导入' ToolTip="从模版文件目录导入模版到数据库中！"
                    OnClick="btnImport_Click" />--%>
            </td>
        </tr>
        <tr>
            <td align="right">
                样式：
            </td>
            <td>
                <asp:TextBox ID="frmStylePath" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <%--<tr>
            <td align="right">
                生成配置：
            </td>
            <td>
                <asp:TextBox ID="frmRenderConfig" runat="server" TextMode="MultiLine" Width="300px"
                    Height="80px"></asp:TextBox>
            </td>
        </tr>--%>
    </table>
    <table border="0" align="Center" width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" CausesValidation="True" Text='保存' />
                &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;"
                    Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>
