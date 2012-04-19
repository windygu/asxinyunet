<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganizeSelectDemo.aspx.cs" Inherits="OrganizeSelectDemo" ValidateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>选择部门</title>
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
            config['title'] = "选择组织机构";
        })(art.dialog.defaults);

        // 单选用户
        function PopSingleSelect() {
            // 传递空间名称
            art.dialog.data('lblOrganizeFullName', 'lblOrganizeFullName');
            art.dialog.data('txtOrganizeFullName', 'txtOrganizeFullName');
            art.dialog.data('hdOrganizeId', 'hdOrganizeId');
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('OrganizeSelect.aspx');
        }

        // 多选用户
        function PopMultiSelect() {
            // 传递空间名称
            art.dialog.data('lblOrganizeFullName', 'lblOrganizeFullNames');
            art.dialog.data('txtOrganizeFullName', 'txtOrganizeFullNames');
            art.dialog.data('hdOrganizeId', 'hdOrganizeIds');
            art.dialog.data('isMultiSelect', true);
            art.dialog.open('OrganizeSelect.aspx');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
       <table  class="autowh table">
        <tr>
            <td class="td-title">单选部门：</td><td class="td-content">
                <asp:Label ID="lblOrganizeFullName" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtOrganizeFullName" runat="server" Text=""></asp:TextBox>
                <asp:HiddenField ID="hdOrganizeId" runat="server" Value=""/>
             &nbsp;<img src="../../../themes/default/images/useradd.png" title="选择部门" /><a 
                                href="javascript:PopSingleSelect()">选择部门</a></td>
        </tr>
        <tr>
            <td class="td-title">多选部门：</td><td class="td-content">
                <asp:Label ID="lblOrganizeFullNames" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtOrganizeFullNames" runat="server" Text=""></asp:TextBox>
                <asp:HiddenField ID="hdOrganizeIds" runat="server" Value=""/>
             &nbsp;<img src="../../../themes/default/images/useradd.png" title="选择部门" /><a 
                                href="javascript:PopMultiSelect()">选择部门</a></td>
        </tr>
    </table>
    </form>
</body>
</html>