<%@ Page Title="系统设置表管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true" CodeFile="WebSettingForm.aspx.cs" Inherits="Common_WebSettingForm"%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">系统设置表</th>
        </tr>
        <tr>
            <td align="right">名称：</td>
            <td><asp:TextBox ID="frmName" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">值：</td>
            <td><asp:TextBox ID="frmValue" runat="server" TextMode="MultiLine" Width="300px" Height="80px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">类别：</td>
            <td><XCL:NumberBox ID="frmCategoryId" runat="server" Width="80px"></XCL:NumberBox></td>
        </tr>
<tr>
            <td align="right">编码类型：</td>
            <td><XCL:NumberBox ID="frmCodeType" runat="server" Width="80px"></XCL:NumberBox></td>
        </tr>
<tr>
            <td align="right">排序码：</td>
            <td><XCL:NumberBox ID="frmSort" runat="server" Width="80px"></XCL:NumberBox></td>
        </tr>
<tr>
            <td align="right">备注：</td>
            <td><asp:TextBox ID="frmRemark" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
    </table>
    <table border="0" align="Center" width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" CausesValidation="True" Text='保存' />
                &nbsp;<asp:Button ID="btnCopy" runat="server" CausesValidation="True" Text='另存为新系统设置表' />
                &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;" Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>