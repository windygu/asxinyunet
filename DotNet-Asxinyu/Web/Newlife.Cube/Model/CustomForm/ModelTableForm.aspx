<%@ Page Title="表单管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true"
    CodeFile="ModelTableForm.aspx.cs" Inherits="Cube_CustomForm_ModelTableForm" %>

<%@ Register TagPrefix="Custom" TagName="Tag" Src="Tag.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <Custom:Tag ID="tag" runat="server" />
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" width="400">
        <tr>
            <th colspan="2">
                [<asp:Label ID="frmDataModelName" runat="server"></asp:Label>] - 表单
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
    <table border="0" width="400">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" CausesValidation="True" Text='保存' />
                &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;"
                    Text="返回" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRenderTempate" runat="server" CausesValidation="True" 
                    Text='重新生成模版' onclick="btnRenderTempate_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
