<%@ Page Title="导入模型" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true"
    CodeFile="ImportDataModel.aspx.cs" Inherits="Cube_ImportDataModel" %>

<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="Server">
    Xml格式导入：<asp:FileUpload ID="FileUpload1" runat="server" />&nbsp;<asp:Button ID="btnXmlImport"
        runat="server" Text="导入" OnClick="btnXmlImport_Click" />
    <br />
    Zip格式导入：<asp:FileUpload ID="FileUpload2" runat="server" />&nbsp;<asp:Button ID="btnZipImport"
        runat="server" Text="导入" OnClick="btnZipImport_Click" />
    <br />
    <br />
    数据库：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    连接字符串：<asp:TextBox ID="txtConnStr" runat="server" ToolTip="连接字符串不能为空！" Width="551px"></asp:TextBox>
    <br />
    数据库类型：<asp:TextBox ID="txtProvider" runat="server" ToolTip="数据库类型不能为空！"></asp:TextBox>
    <br />
    模型名称：<asp:TextBox ID="txtModelName" runat="server" ToolTip="模型名称不能为空！"></asp:TextBox>
    <br />
    <asp:Button ID="btnDbImport" runat="server" Text="导入" OnClick="btnDbImport_Click" />
    <br />
    <br />
    <asp:Button ID="btnImportEntity" runat="server" Text="导入所有实体类模型" 
        onclick="btnImportEntity_Click" />
</asp:Content>
