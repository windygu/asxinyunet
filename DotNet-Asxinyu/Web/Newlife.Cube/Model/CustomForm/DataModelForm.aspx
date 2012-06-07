<%@ Page Title="类别管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true"
    CodeFile="DataModelForm.aspx.cs" Inherits="Cube_CustomForm_DataModelForm" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">
                类别
            </th>
        </tr>
        <tr>
            <td align="right">
                英文名：
            </td>
            <td>
                <asp:TextBox ID="frmName" runat="server" Width="150px"></asp:TextBox>
                &nbsp;创建后不允许修改英文名！
            </td>
        </tr>
        <tr>
            <td align="right">
                中文名：
            </td>
            <td>
                <asp:TextBox ID="frmDescription" runat="server" Width="150px"></asp:TextBox>
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
