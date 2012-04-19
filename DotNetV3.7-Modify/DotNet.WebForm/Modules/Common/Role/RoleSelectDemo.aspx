<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleSelectDemo.aspx.cs" Inherits="RoleSelectDemo" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送信息</title>
    <meta name="Coding" content="浙江物联电子商务有限公司" />
    <meta name="Author" content="yuds"/>
    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=blue"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript">
        (function (config) {
            config['fixed'] = true;
            config['resize'] = false;
            config['width'] = '600px';
            config['height'] = '450px';
            config['title'] = "选择角色";
        })(art.dialog.defaults);

        // 单选用户
        function PopSingleSelect() {
            // 传递控件名称
            art.dialog.data('lblRoleName', 'lblRoleName');
            art.dialog.data('txtRoleName', 'txtRoleName');
            art.dialog.data('hdRoleId', 'hdRoleId');
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('RoleSelect.aspx');
        }

        // 多选用户
        function PopMultiSelect() {
            // 传递控件名称
            art.dialog.data('lblRoleName', 'lblRoleNames');
            art.dialog.data('txtRoleName', 'txtRoleNames');
            art.dialog.data('hdRoleId', 'hdRoleIds');
            art.dialog.data('isMultiSelect', true);
            art.dialog.open('RoleSelect.aspx');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <table  class="autowh table">
        <tr>
            <td class="td-title">单选角色：</td><td class="td-content">
                <asp:Label ID="lblRoleName" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtRoleName" runat="server" Text=""></asp:TextBox>
                <asp:HiddenField ID="hdRoleId" runat="server" Value=""/>
             &nbsp;<img src="../../../themes/default/images/useradd.png" title="选择部门" /><a 
                                href="javascript:PopSingleSelect()">选择角色</a></td>
        </tr>
        <tr>
            <td class="td-title">多选角色：</td><td class="td-content">
                <asp:Label ID="lblRoleNames" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtRoleNames" runat="server" Text=""></asp:TextBox>
                <asp:HiddenField ID="hdRoleIds" runat="server" Value=""/>
             &nbsp;<img src="../../../themes/default/images/useradd.png" title="选择部门" /><a 
                                href="javascript:PopMultiSelect()">选择角色</a></td>
        </tr>
    </table>
    </form>
</body>
</html>