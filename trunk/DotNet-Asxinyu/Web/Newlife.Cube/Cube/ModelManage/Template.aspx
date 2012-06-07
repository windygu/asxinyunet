<%@ Page Title="模版管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true" CodeFile="Template.aspx.cs" Inherits="Cube_ModelManage_Template" %>

<%@ Register TagPrefix="Custom" TagName="Tag" Src="Tag.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="C" Runat="Server">
    <Custom:Tag ID="tag" runat="server" />
    <div class="toolbar">
        模版名：<asp:TextBox ID="txtName" runat="server" ToolTip="请填写模版名！"></asp:TextBox>
        <asp:Button ID="btnCreate" runat="server" Text="新建模版" 
            onclick="btnCreate_Click" />
    </div>
</asp:Content>

