<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkFlowSuperAudit.aspx.cs"
    Inherits="WorkFlowSuperAudit" %>

<html>
<head>
    <title>越级审核</title>
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
                    <b>越级审核</b>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                单据：<asp:DropDownList ID="cmbCategory" Width="200px" TabIndex="1" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="cmbCategory_SelectedIndexChanged">
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
                    <asp:GridView ID="grdWorkFlowCurrent" runat="server" Width="100%" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" DataKeyNames="Id"
                        OnRowDeleting="grdWorkFlowCurrent_DeleteCommand" OnRowDataBound="grdWorkFlowCurrent_ItemDataBound"
                        OnRowEditing="grdWorkFlowCurrent_EditCommand" OnRowCommand="grdWorkFlowCurrent_ItemCommand">
                        <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                            BackColor="#EFEFEF" Font-Size="12px" Height="25px"></HeaderStyle>
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <SelectedRowStyle ForeColor="Blue" />
                        <Columns>
                            <asp:TemplateField HeaderText="No" InsertVisible="False">
                                <HeaderStyle Font-Bold="False" Height="22px" Wrap="false" />
                                <ItemStyle Width="40px" HorizontalAlign="Center" Height="22px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNo" runat="server" Text='<%# this.grdWorkFlowCurrent.PageIndex * this.grdWorkFlowCurrent.PageSize + this.grdWorkFlowCurrent.Rows.Count + 1%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckAll" runat="server" onClick="CheckAll(this.id);" ToolTip="全选" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" onClick="CheckItem('grdWorkFlowCurrent_ctl01_CheckAll');"
                                        runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="CreateBy" HeaderText="申请人" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CategoryFullName" HeaderText="分类" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ObjectFullName" HeaderText="名称" HtmlEncode="False" SortExpression="ObjectFullName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuditDate" HeaderText="审核日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}"
                                SortExpression="AuditDate">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuditUserRealName" HeaderText="审核人" HtmlEncode="False"
                                SortExpression="AuditUserRealName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuditStatus" HeaderText="审核状态" HtmlEncode="False" SortExpression="AuditStatus">
                                <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle Wrap="False" Width="80px" CssClass="leftBlank rightBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AuditIdea" HeaderText="批示" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ToDepartmentName" HeaderText="待审部门" HtmlEncode="False"
                                SortExpression="ToDepartmentName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ToUserRealName" HeaderText="待审人" HtmlEncode="False" SortExpression="ToUserRealName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;编辑&quot; /&gt;"
                                HeaderText="查看" UpdateText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Save.gif&quot; alt=&quot;更新&quot; /&gt;"
                                ShowCancelButton="true" CancelText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Cancel.gif&quot; alt=&quot;取消&quot; /&gt;">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="60px" />
                            </asp:CommandField>
                            <asp:CommandField HeaderText="废弃" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; ToolTip=&quot;删除&quot;/&gt;">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="40px" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px">
                <asp:Button ID="btnCheckAll" runat="server" CssClass="Button" Text="全选(A)" TabIndex="1"
                    OnClientClick="return ButtonCheckAll('grdWorkFlowCurrent_ctl01_CheckAll');" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnAuditPass" runat="server" CssClass="Button" Text="通过(P)" AccessKey="A"
                    TabIndex="2" OnClientClick="return CheckSelectAnyOne('你确定审核通过所选单据吗？');" OnClick="btnAuditPass_Click"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnAuditReject" runat="server" CssClass="Button" Text="退回(B)" AccessKey="D"
                    TabIndex="3" OnClientClick="return CheckSelectAnyOne('你确定退回所选单据吗？');" OnClick="btnAuditReject_Click"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnAuditQuash" runat="server" CssClass="Button" Text="废弃(D)" AccessKey="D"
                    TabIndex="3" OnClientClick="return CheckSelectAnyOne('你确定废弃所选单据吗？');" OnClick="btnAuditQuash_Click"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    </form>
    <!--endprint-->
</body>
</html>
