<%@ Page Title="表单预览" Language="C#" MasterPageFile="~/Admin/ManagerPage.master" AutoEventWireup="true"
    CodeFile="Preview.aspx.cs" Inherits="Model_CustomForm_Preview" %>

<%@ Register TagPrefix="Custom" TagName="Tag" Src="Tag.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="Server">
    <Custom:Tag ID="tag" runat="server" />
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>
