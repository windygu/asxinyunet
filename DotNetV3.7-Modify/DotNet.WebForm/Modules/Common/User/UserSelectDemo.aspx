<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSelectDemo.aspx.cs" Inherits="UserSelectDemo"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送信息</title>
    <meta name="Coding" content="浙江物联电子商务有限公司" />
    <meta name="Author" content="yuds" />
    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=blue"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
    <script type="text/javascript">
        (function (config) {
            config['fixed'] = true;
            config['resize'] = false;
            config['width'] = '600px';
            config['height'] = '450px';
            config['title'] = "人员选择";
        })(art.dialog.defaults);

        // 单选用户
        function PopSingleUserSelect() {
            // 传递控件名称
            art.dialog.data('ucHiddenUserId', 'hdSingleUserId');
            art.dialog.data('ucHiddenRealName', 'hdSingleRealName');
            art.dialog.data('ucRealName', 'lblSingleRealname');
            // art.dialog.data('ucRealName', 'txtUserName');
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('UserSelect.aspx');
        }

        // 多选用户
        function PopMultiUserSelect() {
            // 传递控件名称
            art.dialog.data('ucHiddenUserId', 'hdMultiUserId');
            art.dialog.data('ucHiddenRealName', 'hdMultiRealName');
            art.dialog.data('ucRealName', 'lblMultiRealname');
            art.dialog.data('isMultiSelect', true);
            art.dialog.open('UserSelect.aspx');
        }

        function ClearUser() {
            document.getElementById("lblSingleRealname").innerText = "";
            document.getElementById("hdSingleUserId").value = "";
            document.getElementById("hdSingleRealName").value = "";
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table class="autowh table">
        <tr>
            <td class="td-title">
                用户：
            </td>
            <td class="td-content">
                <asp:Label ID="lblSingleRealname" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hdSingleUserId" runat="server" Value="" />
                <asp:HiddenField ID="hdSingleRealName" runat="server" Value="" />
                &nbsp;<img src="../../../themes/default/images/useradd.png" title="选择用户" /><a href="javascript:PopSingleUserSelect()">选择用户</a>&nbsp;&nbsp;<a
                    href="javascript:ClearUser();">清除用户</a>
            </td>
        </tr>
        <tr>
            <td class="td-title">
                多选用户：
            </td>
            <td class="td-content">
                <asp:Label ID="lblMultiRealname" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hdMultiUserId" runat="server" Value="" />
                <asp:HiddenField ID="hdMultiRealName" runat="server" Value="" />
                &nbsp;<img src="../../../themes/default/images/useradd.png" title="选择被替换用户" /><a
                    href="javascript:PopMultiUserSelect()">选择接收者</a>
            </td>
        </tr>
    </table>
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </form>
</body>
</html>
