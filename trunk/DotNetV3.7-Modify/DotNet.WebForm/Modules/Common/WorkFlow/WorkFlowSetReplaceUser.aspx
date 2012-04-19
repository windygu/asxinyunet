<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkFlowSetReplaceUser.aspx.cs"
    Inherits="WorkFlowSetReplaceUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base target="_self" />
    <title>流程用户替换</title>
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/TICStyle.css">
    <script language="javascript" type="text/javascript" src="../../../JavaScript/My97DatePicker/WdatePicker.js"
        defer="defer"></script>
    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=blue"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
    <script>
        (function (config) {
            config['fixed'] = true;
            config['resize'] = false;
            config['width'] = '600px';
            config['height'] = '400px';
            config['title'] = "选择用户";
        })(art.dialog.defaults);

        // 选择用户
        function SelectUserForUser() {
            // 传递空间名称
            art.dialog.data('ucUserCode', 'lblCode');
            art.dialog.data('ucHiddenUserId', 'hdUserId');
            art.dialog.data('ucRealName', 'lblRealName');
            art.dialog.data('ucDepartmentName', 'lblDepartmentName');
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('../../../Modules/Common/User/UserSelect.aspx');
        }

        function SelectUser() {
            // 传递空间名称
            art.dialog.data('ucUserCode', 'lblToCode');
            art.dialog.data('ucHiddenUserId', 'hdToUserId');
            art.dialog.data('ucRealName', 'lblToRealName');
            art.dialog.data('ucDepartmentName', 'lblToDepartmentName');
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('../../../Modules/Common/User/UserSelect.aspx');
        }
    </script>
</head>
<body>
    <!--startprint-->
    <form id="form2" method="post" runat="server">
    <table width="100%" height="100%">
        <tr>
            <td valign="top">
                <div class="breadcrumbHeader">
                    <b>流程人员替换</b><span>
                        <img id="img" src="../../../Themes/Default/Images/close.gif" alt="隐藏" onmouseover="this.style.cursor='hand'"
                            onclick="displayTable()" /></span>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top">
                <table id="table" class="table" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <div class="tic_left">
                                <table class="table" width="100%" cellpadding="0" cellspacing="0">
                                    <caption class="table_caption">
                                        被替换用户信息
                                        <img src="../../../themes/default/images/useradd.png" title="选择被替换用户" /><a href="javascript:SelectUserForUser()">选择被替换用户</a>
                                    </caption>
                                    <tr>
                                        <td style="width: 150px" class="td-title">
                                            工号：
                                        </td>
                                        <td class="td-content">
                                            <asp:Label ID="lblCode" runat="server" Text=""></asp:Label>
                                            <asp:HiddenField ID="hdUserId" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-title">
                                            姓名：
                                        </td>
                                        <td class="td-content">
                                            <asp:Label ID="lblRealName" runat="server" Text="&nbsp;"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-title">
                                            部门：
                                        </td>
                                        <td class="td-content">
                                            <asp:Label ID="lblDepartmentName" runat="server" Text="&nbsp;"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="tic_center">
                                &nbsp;</div>
                            <div class="tic_right">
                                <table width="100%" class="table" cellpadding="0" cellspacing="0">
                                    <caption class="table_caption">
                                        用户信息
                                        <img src="../../../themes/default/images/useradd.png" title="选择用户" /><a href="javascript:SelectUser()">选择用户</a>
                                    </caption>
                                    <tr>
                                        <td style="width: 150px" class="td-title">
                                            工号：
                                        </td>
                                        <td class="td-content">
                                            <asp:Label ID="lblToCode" runat="server" Text=""></asp:Label>
                                            <asp:HiddenField ID="hdToUserId" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-title">
                                            姓名：
                                        </td>
                                        <td class="td-content">
                                            <asp:Label ID="lblToRealName" runat="server" Text="&nbsp;"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td-title">
                                            部门：
                                        </td>
                                        <td class="td-content">
                                            <asp:Label ID="lblToDepartmentName" runat="server" Text="&nbsp;"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="center">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="center">
                            <asp:Button ID="btnReplaceUser" runat="server" Text="替换人员" OnClick="btnReplaceUser_Click"
                                CssClass="buttonlarge" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtUserId" runat="server" Value="" />
    <asp:HiddenField ID="txtReturnUrl" runat="server" Value="" />
    <asp:HiddenField ID="txtAuthorizeUserId" runat="server" Value="" />
    </form>
    <!--endprint-->
</body>
</html>
