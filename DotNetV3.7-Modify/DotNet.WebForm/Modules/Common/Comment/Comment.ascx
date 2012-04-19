<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Comment.ascx.cs" Inherits="Comment" %>
<table id="tableComment" class="ydMenuCss" align="center" width="100%">
    <tr>
        <td>
            <asp:TextBox ID="txtCommnet" runat="server" TextMode="MultiLine" Width="100%" ToolTip="请输入要回复的内容"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>            
            <asp:Button ID="btnConfirm" runat="server" CssClass="Button" Text="发表(S)" AccessKey="S"
                TabIndex="2" OnClick="btnConfirm_Click"
                onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
        </td>
    </tr>
</table>
<asp:HiddenField ID="txtCategoryCode" runat="server" />
<asp:HiddenField ID="txtObjectId" runat="server" />