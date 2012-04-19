<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkFlowReplaceUser.aspx.cs"
    Inherits="UserWorkFlowReplace" %>

<%@ Register Src="../../Common/ControlsNavigator/ControlsNavigator.ascx" TagName="Navigator"
    TagPrefix="ControlsNavigator" %>
<html>
<head>
    <title>流程替换用户</title>
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
                    <b>流程替换用户</b>
                </div>
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" align="center">
                部门：<asp:DropDownList ID="cmbDepartment" Width="200px" TabIndex="2" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged">
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
                        OnSorting="gridView_Sorting" OnRowEditing="gridView_RowEditing" OnRowDeleting="gridView_RowDeleting"
                        OnRowCreated="gridView_RowCreated">
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
                            <asp:BoundField HeaderText="待审核" DataField="WaitForAuditCount" SortExpression="WaitForAuditCount">
                                <ItemStyle CssClass="leftBlank" HorizontalAlign="Right" />
                                <HeaderStyle Font-Bold="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="单据" DataField="BillCount" SortExpression="BillCount">
                                <ItemStyle CssClass="leftBlank" HorizontalAlign="Right" />
                                <HeaderStyle Font-Bold="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="审核" DataField="WorkFlowStepCount" SortExpression="WorkFlowStepCount">
                                <ItemStyle CssClass="leftBlank" HorizontalAlign="Right" />
                                <HeaderStyle Font-Bold="False" />
                            </asp:BoundField>
                            <asp:CommandField HeaderText="替换" ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/replace.png&quot; alt=&quot;替换&quot; /&gt;">
                                <HeaderStyle Font-Bold="False" Wrap="false" />
                                <ItemStyle Width="80px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                            </asp:CommandField>
                            <asp:CommandField HeaderText="清除审核" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; ToolTip=&quot;清除审核&quot;/&gt;">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="60px" />
                            </asp:CommandField>
                        </Columns>
                        <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                            BackColor="#EFEFEF" Font-Size="12px" Height="25px"></HeaderStyle>
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
    </table>
    </form>
</body>
</html>
