<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Tag.ascx.cs" Inherits="Cube_CustomForm_Tag" %>
<link href="images/tab.css" rel="stylesheet" type="text/css" />
<div style="float: left; font-size: 12pt;">
    &nbsp;表单：<asp:Label ID="lbName" runat="server" Font-Bold="True" 
        ForeColor="Red"></asp:Label>&nbsp;</div>
<div class="tag">
    <asp:Repeater ID="Tag" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li<%# ""+Eval("Key")==Selected?" class=\"current\"":" onclick=\"location.href='"+Eval("Value")+"';\"" %>>
                <span class="icon"></span>
                <%# Eval("Key") %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul></FooterTemplate>
    </asp:Repeater>
</div>
<script type="text/javascript" src="images/tab.js"></script>
