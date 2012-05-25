<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JQueryStudy.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学习测试</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="scripts/jquery-1.4.1-vsdoc.js"></script>
</head>
<body>
    <div id="divMsg">Hello World!</div>
    <input id="btnShow" type="button" value="显示" />
    <input id="btnHide" type="button" value="隐藏" /><br />
    <input id="btnChange" type="button" value="修改内容为 Hello World, too!" />
    <script type="text/javascript">    
        $("#btnShow").bind("click", function (event) { $("#divMsg").show(); });
        $("#btnHide").bind("click", function (event) { $("#divMsg").hide(); });
        $("#btnChange").bind("click", function (event) { $("#divMsg").html("测试数据"); }); 
    </script>  
</body>

</html>