<%@ Page Title="新闻信息表管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true" CodeFile="NewsForm.aspx.cs" Inherits="Common_NewsForm"%>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">新闻信息表</th>
        </tr>
        <tr>
            <td align="right">类别编号：</td>
            <td><XCL:NumberBox ID="frmCategoryId" runat="server" Width="80px"></XCL:NumberBox></td>
        </tr>
<tr>
            <td align="right">新闻标题：</td>
            <td><asp:TextBox ID="frmTitle" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">作者：</td>
            <td><asp:TextBox ID="frmAuthor" runat="server" Width="120px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">来源：</td>
            <td><asp:TextBox ID="frmOrigin" runat="server" Width="150px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">关键字：</td>
            <td><asp:TextBox ID="frmKeyWords" runat="server" Width="150px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">导读：</td>
            <td><asp:TextBox ID="frmReview" runat="server" TextMode="MultiLine" Width="300px" Height="80px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">内容：</td>
            <td><asp:TextBox ID="frmContent" runat="server" TextMode="MultiLine" Width="300px" Height="80px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">点击数：</td>
            <td><XCL:NumberBox ID="frmHits" runat="server" Width="80px"></XCL:NumberBox></td>
        </tr>
<tr>
            <td align="right">文章状态：</td>
            <td><asp:TextBox ID="frmStatus" runat="server" Width="110px"></asp:TextBox></td>
        </tr>
<tr>
            <td align="right">编码类别：</td>
            <td><XCL:NumberBox ID="frmCodeType" runat="server" Width="80px"></XCL:NumberBox></td>
        </tr>
<tr>
            <td align="right">添加时间：</td>
            <td><XCL:DateTimePicker ID="frmAddDateTime" runat="server"></XCL:DateTimePicker></td>
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
                &nbsp;<asp:Button ID="btnCopy" runat="server" CausesValidation="True" Text='另存为新新闻信息表' />
                &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;" Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>