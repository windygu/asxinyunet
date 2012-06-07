<%@ Page Title="模型表管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master"
    AutoEventWireup="true" CodeFile="ModelTableForm.aspx.cs" Inherits="Cube_ModelTableForm" %>

<%@ Register TagPrefix="Custom" TagName="Tag" Src="Tag.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <Custom:Tag ID="tag" runat="server" />
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">
                [<asp:Label ID="frmDataModelName" runat="server"></asp:Label>] - 模型表
            </th>
        </tr>
        <%--<tr>
            <td align="right">
                数据模型：
            </td>
            <td>
                <XCL:NumberBox ID="frmDataModelID" runat="server" Width="80px"></XCL:NumberBox>
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
                表名：
            </td>
            <td>
                <asp:TextBox ID="frmTableName" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                所有者：
            </td>
            <td>
                <asp:TextBox ID="frmOwner" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                数据库类型：
            </td>
            <td>
                <XCL:DropDownList ID="frmDbType" runat="server">
                </XCL:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                视图：
            </td>
            <td>
                <asp:CheckBox ID="frmIsView" runat="server" Text="视图" />
            </td>
        </tr>
        <tr>
            <td align="right">
                注释：
            </td>
            <td>
                <asp:TextBox ID="frmDescription" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                模版：
            </td>
            <td>
                <asp:TextBox ID="frmTemplatePath" runat="server" Width="300px"></asp:TextBox>
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
                排序：
            </td>
            <td>
                <XCL:NumberBox ID="frmSort" runat="server" Width="80px"></XCL:NumberBox>
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
