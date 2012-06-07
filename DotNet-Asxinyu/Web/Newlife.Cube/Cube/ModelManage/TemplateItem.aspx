<%@ Page Title="模版项管理" Language="C#" MasterPageFile="~/Admin/ManagerPage.master"
    AutoEventWireup="true" CodeFile="TemplateItem.aspx.cs" Inherits="Cube_ModelManage_TemplateItem" %>

<%@ Register TagPrefix="Custom" TagName="Tag" Src="Tag.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="Server">
    <Custom:Tag ID="tag" runat="server" />
    <div class="toolbar">
        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
        &nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="删除模版" onclick="btnDelete_Click" 
            onclientclick="return confirm('删除将不可恢复！\n确定删除？')" />
    </div>
    <asp:TextBox ID="txtContent" runat="server" Height="500px" TextMode="MultiLine" 
        Width="800px"></asp:TextBox>
</asp:Content>
