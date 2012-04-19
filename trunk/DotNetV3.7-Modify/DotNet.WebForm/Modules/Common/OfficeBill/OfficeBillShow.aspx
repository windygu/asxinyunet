<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfficeBillShow.aspx.cs" Inherits="OfficeBillShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <% 
            // 获取服务器的地址
            string FileURL = this.Session["FileURL"].ToString();
        %>
        <script id="clientEventHandlersJS" language="javascript">
<!--
    function WebOffice1_NotifyCtrlReady() {
        // LoadOriginalFile接口装载文件,
        // 如果是编辑已有文件，则文件路径传给LoadOriginalFile的第一个参数
        document.all.WebOffice1.LoadOriginalFile("<%=FileURL %>", "xls");

        <% if (!this.AllowPrint)
            {
        %>

        // 屏蔽标准工具栏的前几个按钮
        document.all.WebOffice1.SetToolBarButton2("Standard", 1, 1);
        document.all.WebOffice1.SetToolBarButton2("Standard", 2, 1);
        document.all.WebOffice1.SetToolBarButton2("Standard", 3, 1);
        document.all.WebOffice1.SetToolBarButton2("Standard", 6, 1);

        // 屏蔽文件菜单项
        // document.all.WebOffice1.SetToolBarButton2("Worksheet Menu Bar", 1, 1);
        document.all.WebOffice1.ShowToolBar(0);
        document.all.WebOffice1.SetToolBarButton2("Menu Bar", 1, 8);

        <%
            }
        %>


        // document.all.WebOffice1.SetToolBarButton2("Standard", 1, 8);
        // document.all.WebOffice1.SetToolBarButton2("Formatting", 1, 8);
    }
//-->
        </script>
        <!-- --------------------===  Weboffice初始化完成事件--------------------- -->
        <script language="javascript" for="WebOffice1" event="NotifyCtrlReady">
<!--
 WebOffice1_NotifyCtrlReady() // 在装载完Weboffice(执行<object>...</object>)控件后自动执行WebOffice1_NotifyCtrlReady方法
//-->
        </script>
        <script language="javascript" type="text/javascript">
            // ---------------------== 关闭页面时调用此函数，关闭文档--------------------- //
            function window_onunload() {
                document.all.WebOffice1.Close();
            }
        </script>
        <!-- -----------------------------== 装载weboffice控件 ==----------------------------------->
        <script src="../../../JavaScript/LoadWebOffice.js"></script>
        <!-- --------------------------------==  结束装载控件 ==------------------------------------->
        <asp:HiddenField ID="txtObjectId" runat="server" />
        <asp:HiddenField ID="txtCurrentId" runat="server" />
    </div>
    </form>
</body>
</html>
