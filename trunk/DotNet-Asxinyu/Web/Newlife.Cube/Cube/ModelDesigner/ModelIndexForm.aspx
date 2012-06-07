<%@ Page Title="模型索引管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master"
    AutoEventWireup="true" CodeFile="ModelIndexForm.aspx.cs" Inherits="Cube_ModelIndexForm" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">
                [<asp:Label ID="frmModelTableName" runat="server"></asp:Label>] - 模型索引
            </th>
        </tr>
        <%--<tr>
            <td align="right">
                模型表：
            </td>
            <td>
                <XCL:NumberBox ID="frmModelTableID" runat="server" Width="80px"></XCL:NumberBox>
            </td>
        </tr>--%>
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
                数据列：
            </td>
            <td>
                <asp:TextBox ID="frmColumns" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                唯一：
            </td>
            <td>
                <asp:CheckBox ID="frmUnique" runat="server" Text="唯一" />
            </td>
        </tr>
        <tr>
            <td align="right">
                是否主键：
            </td>
            <td>
                <asp:CheckBox ID="frmPrimaryKey" runat="server" Text="是否主键" />
            </td>
        </tr>
        <tr>
            <td align="right">
                是否计算产生：
            </td>
            <td>
                <asp:CheckBox ID="frmComputed" runat="server" Text="是否计算产生" />
            </td>
        </tr>
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
