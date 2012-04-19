<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleUserAdmin.aspx.cs" Inherits="RoleUserAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>角色用户管理</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=blue"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <style>
        .Button
        {
            background-image: url(../../../Themes/Default/Images/Button.gif);
        }
    </style>
    <script type="text/javascript">
        (function (config) {
            config['fixed'] = true;
            config['resize'] = false;
            config['width'] = '600px';
            config['height'] = '450px';
            config['title'] = "添加用户";
        })(art.dialog.defaults);

        // 多选用户
        function PopMultiUserSelect() {
            // 传递控件名称
            art.dialog.data('ucHiddenUserId', 'txtUserIds');
            // art.dialog.data('ucHiddenUserId', 'hdMultiUserId');
            // art.dialog.data('ucHiddenRealName', 'hdMultiRealName');
            // art.dialog.data('ucRealName', 'lblMultiRealname');
            art.dialog.data('isMultiSelect', true);
            art.dialog.open('../User/UserSelect.aspx');
        }
    </script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0" style="width:100%;height:100%">
    <!--startprint-->
    <form id="form1" method="post" runat="server">
    <table width="100%" height="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>角色用户管理</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                                <font color="red">*</font> 编号：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <asp:Label ID="lblCode" runat="server" Text="lblCode"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" align="right" nowrap="nowrap" class="td-title">
                                <font color="red">*</font> 名称：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <asp:Label ID="lblRealname" runat="server" Text="lblRealname"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" align="right" nowrap="nowrap" class="td-title">
                                备注：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <asp:Label ID="lblDescription" runat="server" Text="lblDescription"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top" colspan="2">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <asp:GridView ID="gridView" runat="server" AllowPaging="False" AutoGenerateColumns="False"
                        DataKeyNames="ID" Width="100%" CellPadding="1" BorderColor="#CCCCCC" BorderWidth="1px"
                        BackColor="White">
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
                            <asp:BoundField DataField="UserName" HeaderText="用户名" HtmlEncode="False" SortExpression="UserName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Code" HeaderText="编号" HtmlEncode="False" SortExpression="Code">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Realname" HeaderText="姓名" HtmlEncode="False" SortExpression="Realname">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DepartmentName" HeaderText="部门" HtmlEncode="False" SortExpression="DepartmentName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Telephone" HeaderText="电话" HtmlEncode="False" SortExpression="Telephone">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Mobile" HeaderText="手机" HtmlEncode="False" SortExpression="Mobile">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email" HtmlEncode="False" SortExpression="Email">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="备注" DataField="Description" SortExpression="Description">
                                <ItemStyle CssClass="leftBlank" />
                                <HeaderStyle Font-Bold="False" />
                            </asp:BoundField>
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
            <td align="center" valign="middle" style="height: 20px">
                <br>
                <asp:Button ID="btnCheckAll" runat="server" CssClass="Button" Text="全选(A)" TabIndex="1"
                    OnClientClick="return ButtonCheckAll('gridView_ctl01_chkAll'); aler(hdMultiUserId.value)"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnAdd" runat="server" CssClass="Button" Text="添加(A)" AccessKey="A"
                    TabIndex="2" OnClientClick="javascript:PopMultiUserSelect(); return false;" OnClick="btnAdd_Click"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnRemove" runat="server" CssClass="Button" Text="移除(R)" AccessKey="D"
                    TabIndex="3" OnClientClick="return CheckSelectAnyOne('你确定移除所选数据行吗？');" OnClick="btnRemove_Click"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                &nbsp;<asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click"
                    CssClass="Button" />
                <br>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtReturnURL" runat="server"/>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:TextBox ID="txtUserIds" runat="server" AutoPostBack="True" OnTextChanged="txtUserIds_TextChanged"
        Width="0px"></asp:TextBox>
    </form>
    <!--endprint-->
</body>
</html>
