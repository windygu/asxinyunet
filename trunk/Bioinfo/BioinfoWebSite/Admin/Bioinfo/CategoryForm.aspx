<%@ Page Title="类别信息管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true" CodeFile="CategoryForm.aspx.cs" Inherits="Common_CategoryForm"%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">类别信息</th>
        </tr>
        <tr>
            <td align="right">父编号：</td>
            <td>
              <XCL:DropDownList ID="frmParentId" runat="server" DataTextField="Name" DataValueField="ParentId"
                    AppendDataBoundItems="True" Width="150px" >
                </XCL:DropDownList>         
            </td>
        </tr>
<tr>
            <td align="right">类名称：</td>
            <td><asp:TextBox ID="frmName" runat="server" Width="150px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">排序码：</td>
            <td><XCL:NumberBox ID="frmSort" runat="server" Width="80px"></XCL:NumberBox></td>
        </tr>
<tr>
            <td align="right">备注：</td>
            <td><asp:TextBox ID="frmDescription" runat="server" Width="150px"></asp:TextBox></td>
        </tr>
    </table>
    <table border="0" align="Center" width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" CausesValidation="True" Text='保存' />
                &nbsp;<asp:Button ID="btnCopy" runat="server" CausesValidation="True" Text='另存为新类别信息' />
                &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;" Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>