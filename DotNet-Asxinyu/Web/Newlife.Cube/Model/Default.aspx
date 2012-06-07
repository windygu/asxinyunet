<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Model_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>模型中心</title>
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">
        <%--// 控制顶级左菜单，改为这里的左菜单--%>
        var leftmenu=window.top.document.getElementById('leftiframe');
        var lefturl='<%= ResolveUrl("Frame/Left.aspx") %>?r='+Math.random()+'&'+leftmenu.contentWindow.location.search.substring(1);
        if (leftmenu.src!=lefturl) leftmenu.src=lefturl;
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
