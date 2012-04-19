<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAdmin.aspx.cs" Inherits="UserAdmin" %>

<%@ Register Src="../../Common/ControlsNavigator/ControlsNavigator.ascx" TagName="Navigator"
    TagPrefix="ControlsNavigator" %>
<html>
<head>
    <title>用户管理</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .Button
        {
            background-image: url(../../../Themes/Default/Images/Button.gif);
        }
        .ButtonLarge
        {
            background-image: url(../../../Themes/Default/Images/ButtonLarge.gif);
        }
    </style>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0" style="overflow: hidden;">
    <form id="form1" method="post" runat="server">
    <table width="100%" style="height: 100%; margin-top: 1px;">
        <tr>
            <td colspan="2">
                <div class="breadcrumbHeader">
                    <b>用户管理</b>
                </div>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" align="center">
                角色：<asp:DropDownList ID="cmbRole" Width="125px" TabIndex="2" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="cmbRole_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;&nbsp;查询内容：<asp:TextBox ID="txtSearch" runat="server" Width="120px" EnableTheming="True"
                    TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                    MaxLength="20"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询(Q)" CssClass="button" OnClick="btnSearch_Click"
                    TabIndex="2" AccessKey="Q" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
            <td nowrap="nowrap" align="right">
                <asp:CheckBox runat="server" ID="ckbEnabled" Checked="true" />
                只显示有效的 &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top" colspan="2">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <asp:GridView ID="gridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="ID" Width="100%" CellPadding="1" BorderColor="#CCCCCC" BorderWidth="1px"
                        BackColor="White" OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting"
                        AllowSorting="True" OnSorting="gridView_Sorting" OnRowEditing="gridView_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%# (this.gridView.PageSize * this.gridView.PageIndex) + this.gridView.Rows.Count + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                                <HeaderStyle Wrap="False" Font-Bold="False" />
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" onClick="CheckAll(this.id);" runat="server" ToolTip="全选" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" onClick="CheckItem('gridView_ctl01_chkAll');" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserFrom" HeaderText="来源" HtmlEncode="False" SortExpression="UserFrom">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UserName" HeaderText="用户名" HtmlEncode="False" SortExpression="UserName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Realname" HeaderText="姓名" HtmlEncode="False" SortExpression="Realname">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="默认角色" DataField="RoleName" SortExpression="RoleName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="有效" SortExpression="Enabled">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.Enabled").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" Width="40px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="备注" DataField="Description" SortExpression="Description">
                                <ItemStyle CssClass="leftBlank" />
                                <HeaderStyle Font-Bold="False" />
                            </asp:BoundField>
                            <asp:CommandField HeaderText="编辑" ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;编辑&quot; /&gt;">
                                <HeaderStyle Font-Bold="False" Wrap="false" />
                                <ItemStyle Width="40px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                            </asp:CommandField>
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; alt=&quot;删除&quot;/&gt;">
                                <ItemStyle Width="40px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                <HeaderStyle Font-Bold="False" />
                            </asp:CommandField>
                        </Columns>
                        <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                            BackColor="#EFEFEF" Font-Size="12px"></HeaderStyle>
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <ControlsNavigator:Navigator ID="myNavigator" runat="server" PageChange="myNavigator_PageChange">
                </ControlsNavigator:Navigator>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px; margin: auto auto auto auto"
                colspan="2">
                <asp:Button ID="btnCheckAll" runat="server" CssClass="Button" Text="全选(A)" ToolTip="全选"
                    OnClientClick="return ButtonCheckAll('gridView_ctl01_chkAll');" AccessKey="A"
                    TabIndex="3" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnRegistration" runat="server" CssClass="Button" Text="注册用户" ToolTip="注册用户"
                    TabIndex="3" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';"
                    OnClick="btnRegistration_Click" />
                <asp:Button ID="btnSetPassword" runat="server" CssClass="Button" Text="密码(C)" ToolTip="密码"
                    OnClientClick="return CheckSelectAnyOne('你确认为所选项设置密码吗？');" AccessKey="C" TabIndex="4"
                    OnClick="btnSetPassword_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnPass" runat="server" CssClass="Button" Text="解锁(J)" TabIndex="5"
                    ToolTip="解锁" OnClientClick="return CheckSelectAnyOne('你确认解锁所选项吗？');" AccessKey="J"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';"
                    OnClick="btnPass_Click" />
                <asp:Button ID="btnLock" runat="server" CssClass="Button" TabIndex="6" ToolTip="锁定"
                    Text="锁定(S)" AccessKey="S" OnClick="btnLock_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';"
                    OnClientClick="return CheckSelectAnyOne('你确认锁定所选项吗？');" />
                <asp:Button ID="btnDelete" runat="server" Text="删除(D)" OnClick="btnDelete_Click"
                    TabIndex="7" ToolTip="删除" CssClass="Button" AccessKey="D" OnClientClick="return CheckSelectAnyOne('你确认删除所选项吗？');"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
