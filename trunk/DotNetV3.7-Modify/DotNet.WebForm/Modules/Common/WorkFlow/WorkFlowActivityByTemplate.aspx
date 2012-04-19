<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkFlowActivityByTemplate.aspx.cs"
    Inherits="WorkFlowActivityByTemplate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>审批流程详细步骤设置-按单据</title>
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/ticStyle.css">
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=blue"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
    <script>
        (function (config) {
            config['fixed'] = true;
            config['resize'] = false;
            config['width'] = '600px';
            config['height'] = '450px';
            config['title'] = "选择";
        })(art.dialog.defaults);

        // 弹出窗口选用户
        function SelectUser(hdUserCode, ucRealName, ucOrganizeName) {
            // 传递空间名称
            art.dialog.data('hdUserCode', hdUserCode);
            art.dialog.data('ucRealName', ucRealName);
            art.dialog.data('ucOrganizeName', ucOrganizeName);
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('../../../Modules/Common/User/UserSelect.aspx');
        }

        // 弹出窗口选角色
        function SelectRole(ucRoleId, lblRoleName) {
            // 传递空间名称
            art.dialog.data('hdRoleId', ucRoleId);
            art.dialog.data('lblRoleName', lblRoleName);
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('../../../Modules/Common/Role/RoleSelect.aspx');
        }

        // 弹出窗口选部门
        function SelectOrganize(ucOrganizeId, lblOrganizeName) {
            // 传递空间名称
            art.dialog.data('hdOrganizeId', ucOrganizeId);
            art.dialog.data('lblOrganizeFullName', lblOrganizeName);
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('../../../Modules/Common/Organize/OrganizeSelect.aspx');
        }
    </script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0" style="overflow: hidden;">
    <form id="form1" method="post" runat="server">
    <table width="100%" style="height: 100%; margin-top: 1px;">
        <tr>
            <td colspan="2">
                <div class="breadcrumbHeader">
                    <b>审批流程信息</b><span>
                        <img id="img" src="../../../Themes/Default/Images/close.gif" alt="隐藏" onmouseover="this.style.cursor='hand'"
                            onclick="displayTable()" /></span>
                </div>
            </td>
        </tr>
        <tr>
            <td valign="top" width="60%">
                <table id="table" class="table" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                            名称：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblTitle" runat="server" Text="名称"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" nowrap="nowrap" class="td-title">
                            编号：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblCategoryCode" runat="server" Text="编号"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" rowspan="3">
                <asp:GridView ID="grdWorkFlow" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" DataKeyNames="Id"
                    OnRowEditing="grdWorkFlow_RowEditing" OnRowDataBound="grdWorkFlow_RowDataBound">
                    <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                        BackColor="#EFEFEF" Font-Size="12px" Height="25px"></HeaderStyle>
                    <AlternatingRowStyle BackColor="WhiteSmoke" />
                    <SelectedRowStyle ForeColor="Blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="No" InsertVisible="False">
                            <HeaderStyle Font-Bold="False" Height="22px" Wrap="false" />
                            <ItemStyle Width="40px" HorizontalAlign="Center" Height="22px" />
                            <ItemTemplate>
                                <asp:Label ID="lblNo" runat="server" Text='<%# this.grdWorkFlow.PageIndex * this.grdWorkFlow.PageSize + this.grdWorkFlow.Rows.Count + 1%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;设置流程&quot; /&gt;"
                            HeaderText="设置">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="40px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Title" HeaderText="单据" HtmlEncode="False">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="发布" SortExpression="Enabled">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container, "DataItem.Enabled").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="False" Width="40px" />
                            <ItemStyle HorizontalAlign="Center" Wrap="False" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>审批流程详细步骤设置:
                        <asp:Label ID="lblWorkFlow" runat="server" Text=""></asp:Label></b> <span>
                            <img id="img1" src="../../../Themes/Default/Images/close.gif" alt="隐藏" onmouseover="this.style.cursor='hand'"
                                onclick="displayTable('img1','grdWorkFlowActivity')" /></span>
                </div>
                <asp:GridView ID="grdWorkFlowActivity" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" DataKeyNames="ID"
                    OnRowDeleting="grdWorkFlowActivity_RowDeleting" OnRowCreated="grdWorkFlowActivity_RowCreated"
                    OnRowCommand="grdWorkFlowActivity_ItemCommand" OnRowDataBound="grdWorkFlowActivity_RowDataBound">
                    <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                        BackColor="#EFEFEF" Font-Size="12px" Height="25px"></HeaderStyle>
                    <AlternatingRowStyle BackColor="WhiteSmoke" />
                    <SelectedRowStyle ForeColor="Blue" />
                    <Columns>
                        <asp:TemplateField HeaderText="No" InsertVisible="False">
                            <HeaderStyle Font-Bold="False" Height="22px" Wrap="false" />
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblNo" runat="server" Text='<%# this.grdWorkFlowActivity.PageIndex * this.grdWorkFlowActivity.PageSize + this.grdWorkFlowActivity.Rows.Count + 1%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AuditUserRealname" HeaderText="姓名" HtmlEncode="False">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AuditUserCode" HeaderText="审核工号" HtmlEncode="False">
                            <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AuditDepartmentName" HeaderText="审核部门" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AuditRoleRealname" HeaderText="审核角色" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                            <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="打印">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container, "DataItem.AllowPrint").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Center" Wrap="False" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container, "DataItem.AllowEditDocuments").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Center" Wrap="False" Width="40px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="共享">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container, "DataItem.Enabled").ToString().Equals("0") ? Utilities.EnableState : Utilities.DisableState%>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Center" Wrap="False" Width="40px" />
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
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; ToolTip=&quot;删除&quot;/&gt;">
                            <HeaderStyle Font-Bold="False" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="40px" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
                <div class="breadcrumbHeader">
                    <b>添加流程步骤 (审核工号可输入Anyone表示是任何人)</b>
                </div>
                <table id="tbSetWorkFlow" cellspacing="0" cellpadding="3" border="1" style="height: 100%;
                    width: 100%; text-align: center; font-size: 12px;">
                    <tr class="tr-header">
                        <td width="40px">
                            No
                        </td>
                        <td>
                            姓名
                        </td>
                        <td>
                            审核工号
                        </td>
                        <td>
                            审核部门
                        </td>
                        <td>
                            审核角色
                        </td>
                        <td>
                            允许打印
                        </td>
                        <td>
                            允许修改
                        </td>
                        <td>
                            共享单据
                        </td>
                    </tr>
                    <tr onmouseout="this.style.backgroundColor = color;" onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            1
                        </td>
                        <td>
                            <asp:Label ID="lblRealName01" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode01" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                            <a href="javascript:SelectUser('txtUserCode01', 'lblRealName01', 'lblOrganize01')">
                                <img src="../../../themes/default/images/useradd.png" title="选择用户" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize01" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize01" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize01', 'lblOrganize01')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole01" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole01" runat="server" />
                            <a href="javascript:SelectRole('txtRole01', 'lblRole01')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowPrint01" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowEditDocuments01" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkShare01" runat="server" />
                        </td>
                    </tr>
                    <tr class="tr-toggle" onmouseout="this.style.backgroundColor = color;" onmouseover="color=this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            2
                        </td>
                        <td>
                            <asp:Label ID="lblRealName02" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode02" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                            <a href="javascript:SelectUser('txtUserCode02', 'lblRealName02', 'lblOrganize02')">
                                <img src="../../../themes/default/images/useradd.png" title="选择用户" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize02" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize02" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize02', 'lblOrganize02')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole02" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole02" runat="server" />
                            <a href="javascript:SelectRole('txtRole02', 'lblRole02')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowPrint02" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowEditDocuments02" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkShare02" runat="server" />
                        </td>
                    </tr>
                    <tr onmouseout="this.style.backgroundColor = color;" onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            3
                        </td>
                        <td>
                            <asp:Label ID="lblRealName03" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode03" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                            <a href="javascript:SelectUser('txtUserCode03', 'lblRealName03', 'lblOrganize03')">
                                <img src="../../../themes/default/images/useradd.png" title="添加用户" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize03" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize03" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize03', 'lblOrganize03')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole03" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole03" runat="server" />
                            <a href="javascript:SelectRole('txtRole03', 'lblRole03')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowPrint03" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowEditDocuments03" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkShare03" runat="server" />
                        </td>
                    </tr>
                    <tr class="tr-toggle" onmouseout="this.style.backgroundColor = color;" onmouseout="this.style.backgroundColor = color;#EFEFEF"
                        onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            4
                        </td>
                        <td>
                            <asp:Label ID="lblRealName04" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode04" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                            <a href="javascript:SelectUser('txtUserCode04', 'lblRealName04', 'lblOrganize04')">
                                <img src="../../../themes/default/images/useradd.png" title="选择用户" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize04" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize04" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize04', 'lblOrganize04')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole04" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole04" runat="server" />
                            <a href="javascript:SelectRole('txtRole04', 'lblRole04')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowPrint04" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowEditDocuments04" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkShare04" runat="server" />
                        </td>
                    </tr>
                    <tr onmouseout="this.style.backgroundColor = color;" onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            5
                        </td>
                        <td>
                            <asp:Label ID="lblRealName05" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode05" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                            <a href="javascript:SelectUser('txtUserCode05', 'lblRealName05', 'lblOrganize05')">
                                <img src="../../../themes/default/images/useradd.png" title="选择用户" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize05" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize05" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize05', 'lblOrganize05')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole05" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole05" runat="server" />
                            <a href="javascript:SelectRole('txtRole05', 'lblRole05')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowPrint05" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowEditDocuments05" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkShare05" runat="server" />
                        </td>
                    </tr>
                    <tr class="tr-toggle" onmouseout="this.style.backgroundColor = color;" onmouseout="this.style.backgroundColor = color;#EFEFEF"
                        onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            6
                        </td>
                        <td>
                            <asp:Label ID="lblRealName06" runat="server"></asp:Label>
                            &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode06" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                            <a href="javascript:SelectUser('txtUserCode06', 'lblRealName06', 'lblOrganize06')">
                                <img src="../../../themes/default/images/useradd.png" title="选择用户" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize06" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize06" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize06', 'lblOrganize06')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole06" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole06" runat="server" />
                            <a href="javascript:SelectRole('txtRole06', 'lblRole06')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowPrint06" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowEditDocuments06" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkShare06" runat="server" />
                        </td>
                    </tr>
                    <tr onmouseout="this.style.backgroundColor = color;" onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            7
                        </td>
                        <td>
                            <asp:Label ID="lblRealName07" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode07" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                            <a href="javascript:SelectUser('txtUserCode07', 'lblRealName07', 'lblOrganize07')">
                                <img src="../../../themes/default/images/useradd.png" title="选择用户" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize07" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize07" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize07', 'lblOrganize07')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole07" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole07" runat="server" />
                            <a href="javascript:SelectRole('txtRole07', 'lblRole07')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowPrint07" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowEditDocuments07" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkShare07" runat="server" />
                        </td>
                    </tr>
                    <tr class="tr-toggle" onmouseout="this.style.backgroundColor = color;" onmouseout="this.style.backgroundColor = color;#EFEFEF"
                        onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            8
                        </td>
                        <td>
                            <asp:Label ID="lblRealName08" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode08" MaxLength="10" Width="80px" runat="server"></asp:TextBox>
                            <a href="javascript:SelectUser('txtUserCode08', 'lblRealName08', 'lblOrganize08')">
                                <img src="../../../themes/default/images/useradd.png" title="选择用户" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize08" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize08" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize08', 'lblOrganize08')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole08" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole08" runat="server" />
                            <a href="javascript:SelectRole('txtRole08', 'lblRole08')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowPrint08" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllowEditDocuments08" runat="server" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkShare08" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="9">
                            <asp:ImageButton ID="ibtnCopy" runat="server" ImageUrl="~/Themes/Default/Images/Copy.jpg"
                                OnClick="ibtnCopy_Click" ToolTip="复制审批流程" Width="20px" />
                            &nbsp;<asp:ImageButton ID="ibtnPast" runat="server" ImageUrl="~/Themes/Default/Images/Past.png"
                                OnClick="ibtnPast_Click" ToolTip="粘贴审批流程" Width="20px" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnAdd" runat="server" Text="添加到流程" OnClick="btnAdd_Click" class="buttonlarge" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    </form>
</body>
</html>
