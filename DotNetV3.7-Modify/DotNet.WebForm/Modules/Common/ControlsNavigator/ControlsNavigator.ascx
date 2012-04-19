<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlsNavigator.ascx.cs" Inherits="ControlsNavigator" %>
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td valign="middle" align="right">
            当前<asp:Label ID="lblPageIndex" runat="server" ForeColor="blue">0</asp:Label>/<asp:Label
                ID="lblPageCount" runat="server" ForeColor="blue">0</asp:Label>页 共<asp:Label ID="lblRowCount"
                    runat="server" ForeColor="blue">0</asp:Label>条记录 &nbsp;
            <asp:LinkButton ID="lbtnFirst" runat="server" OnClick="lbtnFirst_Click">首页</asp:LinkButton>
            |&nbsp;<asp:LinkButton ID="lbtnPrevious" runat="server" OnClick="lbtnPrevious_Click">上页</asp:LinkButton>
            |&nbsp;<asp:LinkButton ID="lbtnNext" runat="server" OnClick="lbtnNext_Click">下页</asp:LinkButton>
            |&nbsp;<asp:LinkButton ID="lbtnLast" runat="server" OnClick="lbtnLast_Click">尾页</asp:LinkButton>
            &nbsp;
            <asp:DropDownList ID="cmbPerPage" runat="server" Width="60px" AutoPostBack="True"
                OnSelectedIndexChanged="cmbPerPage_SelectedIndexChanged">
                <asp:ListItem Value="10">10</asp:ListItem>
                <asp:ListItem Value="11">11</asp:ListItem>
                <asp:ListItem Value="12">12</asp:ListItem>
                <asp:ListItem Value="13">13</asp:ListItem>
                <asp:ListItem Value="14">14</asp:ListItem>
                <asp:ListItem Value="15">15</asp:ListItem>
                <asp:ListItem Value="16">16</asp:ListItem>
                <asp:ListItem Value="17" Selected="True">17</asp:ListItem>
                <asp:ListItem Value="18">18</asp:ListItem>
                <asp:ListItem Value="19">19</asp:ListItem>
                <asp:ListItem Value="20">20</asp:ListItem>
                <asp:ListItem Value="21">21</asp:ListItem>
                <asp:ListItem Value="22">22</asp:ListItem>
                <asp:ListItem Value="23">23</asp:ListItem>
                <asp:ListItem Value="24">24</asp:ListItem>
                <asp:ListItem Value="25">25</asp:ListItem>
                <asp:ListItem Value="26">26</asp:ListItem>
                <asp:ListItem Value="27">27</asp:ListItem>
                <asp:ListItem Value="28">28</asp:ListItem>
                <asp:ListItem Value="29">29</asp:ListItem>
                <asp:ListItem Value="30">30</asp:ListItem>
                <asp:ListItem Value="50">50</asp:ListItem>
                <asp:ListItem Value="100">100</asp:ListItem>
                <asp:ListItem Value="200">200</asp:ListItem>
                <asp:ListItem Value="500">500</asp:ListItem>
                <asp:ListItem Value="1000">1000</asp:ListItem>
            </asp:DropDownList>
            条/每页&nbsp;转到第&nbsp;<asp:DropDownList ID="cmbGoPage" runat="server" Width="60px" AutoPostBack="True"
                OnSelectedIndexChanged="cmbGoPage_SelectedIndexChanged">
            </asp:DropDownList>
            页&nbsp;
        </td>
    </tr>
</table>
<asp:HiddenField ID="txtPageCount" runat="server" Value="0"/>
<asp:HiddenField ID="txtRowCount" runat="server" Value="0"/>
<asp:HiddenField ID="txtPageIndex" runat="server" Value="0"/>
<asp:HiddenField ID="txtAllowPaging" runat="server" Value="False"/>