<%@ Page Title="表单数据" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true"
    CodeFile="ModelTemplate.aspx.cs" Inherits="Model_CustomForm_ModelTemplate" ValidateRequest="false" %>

<%@ Register TagPrefix="Custom" TagName="Tag" Src="Tag.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="Server">
    <Custom:Tag ID="tag" runat="server" />
    <div class="toolbar">
        <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
    </div>
    <asp:TextBox ID="txtContent" runat="server" Height="500px" TextMode="MultiLine" Width="800px"
        EnableViewState="false"></asp:TextBox>
</asp:Content>
