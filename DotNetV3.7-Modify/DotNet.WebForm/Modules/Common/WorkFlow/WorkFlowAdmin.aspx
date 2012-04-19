<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkFlowAdmin.aspx.cs" Inherits="WorkFlowAdmin" %>

<%@ Register Src="../ControlsNavigator/ControlsNavigator.ascx" TagName="Navigator"
    TagPrefix="ControlsNavigator" %>
<html>
<head>
    <title>审核流程管理</title>
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
                    <b>审核流程管理</b>
                </div>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" align="center">
                部门：<asp:DropDownList ID="cmbDepartment" Width="200px" TabIndex="2" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged">
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
                        DataKeyNames="Id" Width="100%" CellPadding="1" BorderColor="#CCCCCC" BorderWidth="1px"
                        BackColor="White" OnRowDataBound="gridView_RowDataBound" AllowSorting="True"
                        OnSorting="gridView_Sorting" OnRowCreated="gridView_RowCreated" OnRowCommand="gridView_ItemCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%# (this.gridView.PageSize * this.gridView.PageIndex) + this.gridView.Rows.Count + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                                <HeaderStyle Wrap="False" Font-Bold="False" />
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="UserName" HeaderText="用户名" HtmlEncode="False" SortExpression="UserName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="工号" DataField="Code" SortExpression="Code">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Realname" HeaderText="姓名" HtmlEncode="False" SortExpression="Realname">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="部门" DataField="DepartmentName" SortExpression="DepartmentName">
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
                            <asp:TemplateField HeaderText="管理">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbUserWorkFlow" runat="server" ToolTip="审批流程设置" CommandName="UserWorkFlow"
                                        CausesValidation="true" Text="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;流程设置&quot; /&gt;">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkbReplaceUser" runat="server" ToolTip="人员替换" CommandName="ReplaceUser"
                                        CausesValidation="true" Text="&lt;img border=0 src=&quot;../../../Themes/Default/Images/replace.png&quot; alt=&quot;人员替换&quot; /&gt;">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkbWorkFlowAuthorize" runat="server" ToolTip="委托设置" CommandName="WorkFlowAuthorize"
                                        CausesValidation="true" Text="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Role.gif&quot; alt=&quot;委托设置&quot; /&gt;">
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Width="90px" Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                        </Columns>
                       <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                        BackColor="#EFEFEF" Font-Size="12px" Height="25px"></HeaderStyle>
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <PagerSettings Visible="false" />
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
    </table>
    </form>
</body>
</html>
