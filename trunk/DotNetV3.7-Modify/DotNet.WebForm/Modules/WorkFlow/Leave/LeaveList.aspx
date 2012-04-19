<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveList.aspx.cs" Inherits="LeaveList" %>

<%@ Register Src="../../Common/ControlsNavigator/ControlsNavigator.ascx" TagName="Navigator"
    TagPrefix="ControlsNavigator" %>
<html>
<head>
    <title>请假单</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com"/>
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css" />
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
                    <b>请假单</b>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                查询内容 ：
				<asp:TextBox ID="txtSearch" runat="server" EnableTheming="True" MaxLength="20"
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
                        OnSorting="gridView_Sorting" OnRowDeleting="gridView_RowDeleting" OnRowCommand="gridView_ItemCommand">
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
                                    <asp:LinkButton ID="lkbShowDetail" runat="server" ToolTip="查看" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "id")%>'
                                        CommandName="ShowDetail" CausesValidation="true" Text="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Detail.gif&quot; alt=&quot;查看&quot; /&gt;">
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="编辑" ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;编辑&quot; /&gt;">
                                <HeaderStyle Font-Bold="False" Wrap="false" />
                                <ItemStyle Width="40px" VerticalAlign="Middle" HorizontalAlign="Center" Wrap="false" />
                            </asp:CommandField>
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; alt=&quot;删除&quot;/&gt;">
                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" Wrap="True" />
                                <HeaderStyle Width="40px" Font-Bold="False" />
                            </asp:CommandField>
							                            <asp:BoundField DataField="UserName" HeaderText="申请人姓名" HtmlEncode="False" SortExpression="UserName"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                            <asp:BoundField DataField="DepartmentName" HeaderText="部门名称" HtmlEncode="False" SortExpression="DepartmentName"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                            <asp:BoundField DataField="Code" HeaderText="单据编号" HtmlEncode="False" SortExpression="Code"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                            <asp:BoundField DataField="TransferOfPeople" HeaderText="工作交接人" HtmlEncode="False" SortExpression="TransferOfPeople"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                            <asp:BoundField DataField="Telephone" HeaderText="联系电话" HtmlEncode="False" SortExpression="Telephone"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                            <asp:BoundField DataField="Reason" HeaderText="请假原因" HtmlEncode="False" SortExpression="Reason"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                            <asp:BoundField DataField="Day" HeaderText="请假天数" HtmlEncode="False" SortExpression="Day"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                            <asp:BoundField DataField="ItemsLeaveCategory" HeaderText="请假类别" HtmlEncode="False" SortExpression="ItemsLeaveCategory"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                            <asp:BoundField DataField="StartTime" HeaderText="开始日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}" SortExpression="StartTime">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>

                            <asp:BoundField DataField="EndTime" HeaderText="结束日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}" SortExpression="EndTime">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>

                            <asp:BoundField DataField="TransferInstructions" HeaderText="工作交接说明" HtmlEncode="False" SortExpression="TransferInstructions"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                            <asp:BoundField DataField="Description" HeaderText="描述" HtmlEncode="False" SortExpression="Description"> 
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" /> 
                                    <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" /> 
                            </asp:BoundField>

                
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <ControlsNavigator:Navigator ID="myNavigator" runat="server" PageChange="myNavigator_PageChange"
                    OnPageChange="myNavigator_PageChange"></ControlsNavigator:Navigator>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <asp:Button ID="btnCheckAll" runat="server" CssClass="Button" Text="全选" TabIndex="1"
                    OnClientClick="return ButtonCheckAll('gridView_ctl01_CheckAll');" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnAdd" runat="server" CssClass="Button" Text="新增(A)" AccessKey="A"
                    TabIndex="2" OnClick="btnAdd_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnSend" runat="server" CssClass="Button" Text="提交审核" AccessKey="S"
                    TabIndex="3" OnClientClick="return CheckSelectAnyOne('你确定提交所选单据吗？');" OnClick="btnSend_Click"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="Button" Text="删除(D)" AccessKey="D"
                    TabIndex="4" OnClientClick="return CheckSelectAnyOne('你确定删除所选单据吗？');" OnClick="btnDelete_Click"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    </form>
    <!--endprint-->
</body>
</html>

