<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserShareBill.aspx.cs" Inherits="UserShareBill" %>

<%@ Register Src="../ControlsNavigator/ControlsNavigator.ascx" TagName="Navigator"
    TagPrefix="ControlsNavigator" %>
<html>
<head id="Head1" runat="server">
    <title>共享单据</title>
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
    <table width="100%" height="100%">
        <tr>
            <td colspan="2">
                <div class="breadcrumbHeader">
                    <b>共享单据</b>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                单据：<asp:DropDownList ID="cmbBill" Width="200px" TabIndex="1" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="cmbBill_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;&nbsp; 查询内容 ：<asp:TextBox ID="txtSearch" runat="server" EnableTheming="True"
                    MaxLength="20" TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                    onfocus="this.className='ColorFocus';"></asp:TextBox>
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
                        BackColor="White" OnRowDataBound="gridView_RowDataBound" AllowSorting="True"
                        OnSorting="gridView_Sorting" OnRowCreated="gridView_RowCreated" OnRowCommand="gridView_ItemCommand"
                        OnRowEditing="gridView_RowEditing">
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
                            <asp:CommandField HeaderText="查看" ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;查看&quot; /&gt;">
                                <HeaderStyle Font-Bold="False" Wrap="false" />
                                <ItemStyle Width="40px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="标记" SortExpression="Worked">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.Worked").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Width="40px" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CategoryFullName" HeaderText="分类" HtmlEncode="False" SortExpression="CategoryFullName">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ObjectFullName" HeaderText="名称" HtmlEncode="False" SortExpression="ObjectFullName">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreateBy" HeaderText="发起人" HtmlEncode="False" SortExpression="CreateBy">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuditUserRealName" HeaderText="审核人" HtmlEncode="False"
                                SortExpression="AuditUserRealName">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuditDate" HeaderText="审核日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}"
                                SortExpression="AuditDate">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuditIdea" HeaderText="批示" HtmlEncode="False" SortExpression="AuditIdea">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ToDepartmentName" HeaderText="待审部门" HtmlEncode="False"
                                SortExpression="ToDepartmentName">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ToUserRealName" HeaderText="待审人" HtmlEncode="False" SortExpression="ToUserRealName">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuditStatus" HeaderText="审核状态" HtmlEncode="False">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" Width="80px" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            
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
            <td>
                <ControlsNavigator:Navigator ID="myNavigator" runat="server" PageChange="myNavigator_PageChange">
                </ControlsNavigator:Navigator>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px">
                <asp:Button ID="btnCheckAll" runat="server" CssClass="Button" Text="全选(A)" TabIndex="1"
                    OnClientClick="return ButtonCheckAll('grdWorkFlowCurrent_ctl01_CheckAll');" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnSetWorked" runat="server" CssClass="Button" Text="设置标记" AccessKey="D"
                    TabIndex="2" OnClick="btnSetWorked_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnUnWorked" runat="server" CssClass="Button" Text="取消标志" AccessKey="D"
                    TabIndex="3" OnClick="btnUnWorked_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
