<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmitBill.aspx.cs" Inherits="SubmitBill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>提交单据</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=blue"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/ticStyle.css">
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
    <script>
        (function (config) {
            config['fixed'] = true;
            config['resize'] = false;
            config['width'] = '600px';
            config['height'] = '450px';
            config['title'] = "选择";
        })(art.dialog.defaults);

        // 弹出窗口选用户
        function SelectUser(ucCode, lblRealName, lblOrganizeName) {
            // 传递空间名称
            art.dialog.data('ucHiddenCode', ucCode);
            art.dialog.data('ucRealName', lblRealName);
            art.dialog.data('ucDepartmentName', lblOrganizeName);
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
<body style="margin-top: 10px">
    <form id="form1" runat="server">
    <table align="center" leftmargin="0" topmargin="0">
        <tr align="center">
            <td align="center" valign="middle">
                <table runat="server" id="tbUser" visible="false" cellspacing="0" cellpadding="3"
                    border="1" style="height: 100%; width: 100%; text-align: center; font-size: 12px;">
                    <tr class="tr-header">
                        <td align="center">
                            No
                        </td>
                        <td align="center">
                            审核人
                        </td>
                        <td align="center">
                            工号
                        </td>
                        <td align="center">
                            选择
                        </td>
                        <td align="center">
                            审核部门
                        </td>
                        <td>
                            审核角色
                        </td>
                    </tr>
                    <tr runat="server" id="rowStep01" visible="false" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled01" Text="1" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName01" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode01" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser01" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode01', 'lblRealName01', 'lblOrganize01')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
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
                    </tr>
                    <tr runat="server" id="rowStep02" visible="false" class="tr-toggle" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color=this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled02" Text="2" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName02" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode02" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser02" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode02', 'lblRealName02', 'lblOrganize02')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
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
                    </tr>
                    <tr runat="server" id="rowStep03" visible="false" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled03" Text="3" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName03" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode03" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser03" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode03', 'lblRealName03', 'lblOrganize03')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
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
                    </tr>
                    <tr runat="server" id="rowStep04" visible="false" class="tr-toggle" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color=this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled04" Text="4" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName04" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode04" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser04" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode04', 'lblRealName04', 'lblOrganize04')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
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
                    </tr>
                    <tr runat="server" id="rowStep05" visible="false" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled05" Text="5" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName05" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode05" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser05" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode05', 'lblRealName05', 'lblOrganize05')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
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
                    </tr>
                    <tr runat="server" id="rowStep06" visible="false" class="tr-toggle" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color=this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled06" Text="6" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName06" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode06" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser06" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode06', 'lblRealName06', 'lblOrganize06')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
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
                    </tr>
                    <tr runat="server" id="rowStep07" visible="false" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled07" Text="7" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName07" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode07" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser07" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode07', 'lblRealName07', 'lblOrganize07')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
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
                    </tr>
                    <tr runat="server" id="rowStep08" visible="false" class="tr-toggle" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color=this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled08" Text="8" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName08" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode08" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser08" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode08', 'lblRealName08', 'lblOrganize08')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
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
                    </tr>
                    <tr runat="server" id="rowStep09" visible="false" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color =this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled09" Text="9" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName09" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode09" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser09" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode09', 'lblRealName09', 'lblOrganize09')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize09" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize09" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize09', 'lblOrganize09')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole09" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole09" runat="server" />
                            <a href="javascript:SelectRole('txtRole09', 'lblRole09')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                    </tr>
                    <tr runat="server" id="rowStep10" visible="false" class="tr-toggle" onmouseout="this.style.backgroundColor = color;"
                        onmouseover="color=this.style.backgroundColor;this.style.backgroundColor='LemonChiffon';">
                        <td>
                            <asp:CheckBox ID="chkEnabled10" Text="10" ToolTip="取消选中状态，表示不走该审核者的审批步骤" Checked="true"
                                Enabled="false" runat="server" />
                        </td>
                        <td>
                            <asp:Label ID="lblRealName10" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserCode10" MaxLength="10" runat="server" Enabled="false" Width="80px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:HyperLink ID="hlkSelectUser10" Text="选择审核人" ToolTip="选择审核人" NavigateUrl="javascript:SelectUser('txtUserCode10', 'lblRealName10', 'lblOrganize10')"
                                ImageUrl="../../../themes/default/images/useradd.png" runat="server"></asp:HyperLink>
                        </td>
                        <td>
                            <asp:Label ID="lblOrganize10" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtOrganize10" runat="server" />
                            <a href="javascript:SelectOrganize('txtOrganize10', 'lblOrganize10')">
                                <img src="../../../themes/default/images/Tree.jpg" title="选择部门" /></a>
                        </td>
                        <td>
                            <asp:Label ID="lblRole10" runat="server"></asp:Label>
                            <asp:HiddenField ID="txtRole10" runat="server" />
                            <a href="javascript:SelectRole('txtRole10', 'lblRole10')">
                                <img src="../../../themes/default/images/Role.gif" title="选择角色" /></a>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="left" style="text-align: center">
                <asp:Button ID="btnAutoStatr" runat="server" Visible="false" Text="提交单据(S)" AccessKey="S"
                    TabIndex="1" UseSubmitBehavior="false" OnClientClick="this.value='正在提交';this.disabled=true;"
                    OnClick="btnAutoStatr_Click" Height="60px" Width="180px" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtObjectId" runat="server" />
    <asp:HiddenField ID="txtObjectFullName" runat="server" />
    <asp:HiddenField ID="txtCategoryCode" runat="server" />
    <asp:HiddenField ID="txtCategoryFullName" runat="server" />
    <asp:HiddenField ID="txtWorkFlowCode" runat="server" />
    <asp:HiddenField ID="txtUserId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    </form>
</body>
</html>
