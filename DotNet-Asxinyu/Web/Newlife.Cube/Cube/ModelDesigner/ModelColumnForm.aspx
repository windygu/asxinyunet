<%@ Page Title="模型列管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master"
    AutoEventWireup="true" CodeFile="ModelColumnForm.aspx.cs" Inherits="Cube_ModelColumnForm" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">
                [<asp:Label ID="frmModelTableName" runat="server"></asp:Label>] - 模型列
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
                别名：
            </td>
            <td>
                <asp:TextBox ID="frmAlias" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                数据类型：
            </td>
            <td>
                <asp:TextBox ID="frmDataType" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                原始类型：
            </td>
            <td>
                <asp:TextBox ID="frmRawType" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                控件类型：
            </td>
            <td>
                <XCL:DropDownList ID="frmControl" runat="server" DataTextField="Value" DataValueField="Key">
                </XCL:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                标识：
            </td>
            <td>
                <asp:CheckBox ID="frmIdentity" runat="server" Text="标识" />
            </td>
        </tr>
        <tr>
            <td align="right">
                主键：
            </td>
            <td>
                <asp:CheckBox ID="frmPrimaryKey" runat="server" Text="主键" />
            </td>
        </tr>
        <tr>
            <td align="right">
                长度：
            </td>
            <td>
                <XCL:NumberBox ID="frmLength" runat="server" Width="80px"></XCL:NumberBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                字节数：
            </td>
            <td>
                <XCL:NumberBox ID="frmNumOfByte" runat="server" Width="80px"></XCL:NumberBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                精度：
            </td>
            <td>
                <XCL:NumberBox ID="frmPrecision" runat="server" Width="80px"></XCL:NumberBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                位数：
            </td>
            <td>
                <XCL:NumberBox ID="frmScale" runat="server" Width="80px"></XCL:NumberBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                允许空：
            </td>
            <td>
                <asp:CheckBox ID="frmNullable" runat="server" Text="允许空" />
            </td>
        </tr>
        <tr>
            <td align="right">
                Unicode：
            </td>
            <td>
                <asp:CheckBox ID="frmIsUnicode" runat="server" Text="Unicode" />
            </td>
        </tr>
        <tr>
            <td align="right">
                选项：
            </td>
            <td>
                <asp:TextBox ID="frmSelects" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                默认值：
            </td>
            <td>
                <asp:TextBox ID="frmDefault" runat="server" Width="150px"></asp:TextBox>
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
                &nbsp;<asp:Button ID="btnCopy" runat="server" CausesValidation="True" Text='另存为新模型列' />
                &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;"
                    Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>
