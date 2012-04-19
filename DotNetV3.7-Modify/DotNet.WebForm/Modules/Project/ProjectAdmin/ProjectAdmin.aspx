<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectAdmin.aspx.cs" Inherits="ProjectAdmin" %>

<%@ Register Src="../../Common/ControlsNavigator/ControlsNavigator.ascx" TagName="Navigator"
    TagPrefix="ControlsNavigator" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
    <title>工作流程审批系统 - 项目跟进</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <style>
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
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server">
    <table style="width: 100%; height: 100%">
        <tr>
            <td colspan="2">
                <div class="breadcrumbHeader">
                    <b>工作流程审批系统 - 项目跟进</b>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                查询内容 ：<asp:TextBox ID="txtSearch" runat="server" EnableTheming="True" MaxLength="20"
                    TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="查询(Q)" CssClass="Button" TabIndex="2"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';"
                    Height="22px" OnClick="btnSearch_Click" AccessKey="Q" />
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <asp:GridView ID="gridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="Id" Width="100%" CellPadding="1" BorderColor="#CCCCCC" BorderWidth="1px"
                        BackColor="White" OnRowDataBound="gridView_RowDataBound" OnRowDeleting="gridView_RowDeleting"
                        AllowSorting="True" OnSorting="gridView_Sorting" OnRowCreated="gridView_RowCreated"
                        OnRowCommand="gridView_ItemCommand" OnRowEditing="gridView_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="No" InsertVisible="False">
                                <HeaderStyle Font-Bold="False" Height="22px" Wrap="false" />
                                <ItemStyle Width="40px" HorizontalAlign="Center" Height="22px" />
                                <FooterStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNo" runat="server" Text='<%# this.gridView.PageIndex * this.gridView.PageSize + this.gridView.Rows.Count + 1%>' />
                                </ItemTemplate>
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
                            <asp:BoundField DataField="LiXiangRiQi" HeaderText="立项日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}"
                                SortExpression="LiXiangRiQi">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="客户名称" SortExpression="KeHuMingCheng">
                                <ItemTemplate>
                                    <a href="ProjectInfo.aspx?Id=<%# DataBinder.Eval(Container, "DataItem.Id").ToString()%>">
                                        <%# DataBinder.Eval(Container, "DataItem.KeHuMingCheng").ToString()%></a>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="客户资料" SortExpression="KeHuZiLiao">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.KeHuZiLiao").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Width="60px" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="确认图纸" SortExpression="QuRenTuZhi">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.QuRenTuZhi").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Width="60px" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="确认结果" SortExpression="QuRenJieGuo">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.QuRenJieGuo").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Width="60px" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="顺序">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbSetTop" runat="server" ToolTip="置顶" CommandName="SetTop" CausesValidation="true"
                                        Text="▲">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkbSetUp" runat="server" ToolTip="上移" CommandName="SetUp" CausesValidation="true"
                                        Text="△">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkbSetDown" runat="server" ToolTip="下移" CommandName="SetDown"
                                        CausesValidation="true" Text="▽">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkbSetBottom" runat="server" ToolTip="置底" CommandName="SetBottom"
                                        CausesValidation="true" Text="▼">
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ModifiedBy" HeaderText="录入" HtmlEncode="False" SortExpression="ModifiedBy">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" Width="80px" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            <asp:CommandField HeaderText="编辑" ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;编辑&quot; /&gt;">
                                <HeaderStyle Font-Bold="False" Wrap="false" />
                                <ItemStyle Width="40px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                            </asp:CommandField>
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; alt=&quot;删除&quot;/&gt;">
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                <HeaderStyle Width="40px" Font-Bold="False" />
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
            <td>
                <ControlsNavigator:Navigator ID="myNavigator" runat="server" PageChange="myNavigator_PageChange">
                </ControlsNavigator:Navigator>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px; margin: auto auto auto auto">
                <asp:Button ID="btnAdd" runat="server" CssClass="Button" Text="录入项目" AccessKey="N"
                    TabIndex="3" OnClick="btnAdd_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnDelete" runat="server" Text="删除(D)" OnClick="btnDelete_Click"
                    CssClass="Button" TabIndex="7" AccessKey="D" OnClientClick="return CheckSelectAnyOne('你确认删除所选项吗？');"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
