<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcessingMaintain.aspx.cs"
    Inherits="ProcessingMaintain" %>

<%@ Register Src="../ControlsNavigator/ControlsNavigator.ascx" TagName="Navigator"
    TagPrefix="ControlsNavigator" %>
<html>
<head>
    <title>处理中</title>
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
    </style>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server">
    <table width="100%" height="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>处理中</b>
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
                    <asp:GridView ID="gridView" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CCCCCC" AllowSorting="True" BorderWidth="1px"
                        CellPadding="3" DataKeyNames="Id" OnRowDataBound="gridView_ItemDataBound" OnRowEditing="gridView_EditCommand"
                        OnSorting="gridView_Sorting" OnRowCommand="gridView_RowCommand">
                        <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                            BackColor="#EFEFEF" Font-Size="12px" Height="25px"></HeaderStyle>
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <PagerSettings Visible="False" />
                        <Columns>
                            <asp:TemplateField HeaderText="No" InsertVisible="False">
                                <HeaderStyle Font-Bold="False" Height="22px" Wrap="false" />
                                <ItemStyle Width="40px" HorizontalAlign="Center" Height="22px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNo" runat="server" Text='<%# this.gridView.PageIndex * this.gridView.PageSize + this.gridView.Rows.Count + 1%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckAll" runat="server" onClick="CheckAll(this.id);" ToolTip="全选" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" onClick="CheckItem('gridView_ctl01_CheckAll');" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="查看">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbShowDetails" runat="server" ToolTip="查看" CommandName="ShowDetails"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id")%>' CausesValidation="true"
                                        Text="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Detail.gif&quot; alt=&quot;查看&quot; /&gt;">
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;编辑&quot; /&gt;"
                                HeaderText="编辑" UpdateText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Save.gif&quot; alt=&quot;更新&quot; /&gt;"
                                ShowCancelButton="true" CancelText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Cancel.gif&quot; alt=&quot;取消&quot; /&gt;">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="40px" />
                            </asp:CommandField>
                            <asp:BoundField DataField="ReportingTime" HeaderText="申报日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}"
                                SortExpression="ReportingTime">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Code" HeaderText="编号" HtmlEncode="False" SortExpression="Code">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Description" HeaderText="问题描述" HtmlEncode="False" SortExpression="Description">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="申报" SortExpression="CreateBy">
                                <ItemTemplate>
                                      姓名：<%# DataBinder.Eval(Container.DataItem, "CreateBy")%><br>
                                      IP：<%# DataBinder.Eval(Container.DataItem, "IP")%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="申报部门" SortExpression="DepartmentName">
                                <ItemTemplate>
                                      部门：<%# DataBinder.Eval(Container.DataItem, "DepartmentName")%><br>
                                      电话：<%# DataBinder.Eval(Container.DataItem, "Telephone")%><br>
                                      地点：<%# DataBinder.Eval(Container.DataItem, "OfficeLocation")%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="受理">
                                <ItemTemplate>
                                      类别：<%# DataBinder.Eval(Container.DataItem, "BugCategory")%><br>
                                      等级：<%# DataBinder.Eval(Container.DataItem, "BugLevel")%><br>
                                      受理：<%# DataBinder.Eval(Container.DataItem, "ProcessorName")%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:TemplateField>
                        </Columns>
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
            <td align="center" valign="middle" style="height: 20px">
                <asp:Button ID="btnCheckAll" runat="server" CssClass="Button" Text="全选(A)" TabIndex="1"
                    OnClientClick="return ButtonCheckAll('gridView_ctl01_CheckAll');" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnSetDraft" runat="server" CssClass="Button" Text="撤销(C)"
                    AccessKey="D" TabIndex="3" OnClientClick="return CheckSelectAnyOne('你确定撤销所选单据吗？');"
                    OnClick="btnSetDraft_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnSetProcessed" runat="server" CssClass="Button" Text="已处理(S)"
                    AccessKey="D" TabIndex="3" OnClientClick="return CheckSelectAnyOne('你确定将所选单据设置为已处理状态吗？');"
                    OnClick="btnSetProcessed_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    </form>
    <!--endprint-->
</body>
</html>
