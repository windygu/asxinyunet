<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserCode.aspx.cs" Inherits="UserCode" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <title>用户工号查询</title>
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/TICStyle.css">
    <style>
    .td-title{ text-align:center}
    </style>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <table  style="width:100%; height:100%; margin-top: 1px;">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>用户工号查询</b>
                </div>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" align="center">部门：<asp:DropDownList ID="cmbDepartment" Width="200px" TabIndex="2" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;&nbsp;查询内容：<asp:TextBox ID="txtSearch" runat="server" Width="150px" EnableTheming="True"
                    TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                    MaxLength="20"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询(Q)" CssClass="button" OnClick="btnSearch_Click"
                    TabIndex="2" AccessKey="Q" />
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top" >
                <div style="overflow: auto; width: 100%; height:100%;">
                    <asp:Repeater ID="rpUserCode" runat="server" 
                        onitemdatabound="rpUserCode_ItemDataBound">
                        <HeaderTemplate>
                              <table class="table" cellpadding="1">
                                  <tr class="tr-header">
                                        <td width="40" class="td-title">序号</td>
                                        <td width="80" class="td-title">工号</td>
                                        <td width="80" class="td-title">姓名</td>
                                        <td width="40" class="td-title">序号</td>
                                        <td width="80" class="td-title">工号</td>
                                        <td width="80" class="td-title">姓名</td>
                                        <td width="40" class="td-title">序号</td>
                                        <td width="80" class="td-title">工号</td>
                                        <td width="80" class="td-title">姓名</td>
                                        <td width="40" class="td-title">序号</td>
                                        <td width="80" class="td-title">工号</td>
                                        <td width="80" class="td-title">姓名</td>
                                        <td width="40" class="td-title">序号</td>
                                        <td width="80" class="td-title">工号</td>
                                        <td width="80" class="td-title">姓名</td>
                                        <td width="40" class="td-title">序号</td>
                                        <td width="80" class="td-title">工号</td>
                                        <td width="80" class="td-title">姓名</td>
                                  </tr>
                                  <tr class="tr-content">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <td  class="td-title"><%# Container.ItemIndex + 1 %></td>
                            <td class="td-content"><%# DataBinder.Eval(Container.DataItem, "Code") %></td>
                            <td class="td-content"><%# DataBinder.Eval(Container.DataItem, "RealName") %></td>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <td class="td-title"><%# Container.ItemIndex + 1 %></td>
                            <td class="td-content"><%# DataBinder.Eval(Container.DataItem, "Code") %></td>
                            <td class="td-content"><%# DataBinder.Eval(Container.DataItem, "RealName") %></td>
                        </AlternatingItemTemplate>
                        <FooterTemplate></tr></table></FooterTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
