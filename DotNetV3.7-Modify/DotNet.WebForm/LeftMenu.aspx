<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.aspx.cs" Inherits="LeftMenu" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />    
    <title>工作流程审批系统 - 左侧菜单</title>  
    <style type="text/css">
    .tdLeftMenu
    {
        vertical-align:top;
        height:auto!important;
    }
    .tdSelectBar 
    {
        height:auto!important; 
    }
    .contentcss td
    {
        border-width:0!important;  
        vertical-align:top!important;  
        height:100%;    
        min-height:140px; 
        margin:0;
        padding:0;     
    }
    .iecontentcsstd
    {
      height:150px!important;
    }
    html,body
    {
        height:100%;
        overflow:auto;
    } 
    body form,body form table
    {
        margin:0;
        padding:0;        
    } 
    tr.tdSelectBar,tr.tdSelectBar td
    {
      height:22px!important; 
      table-layout:fixed;
      overflow:hidden;
      margin:0;
      padding:0;
     }
    
    </style>     
</head>
<body  style="margin: 0 0 0 0;">
    <form id="form1" runat="server">
    <asp:Table ID="tblMenu" runat="server">
    </asp:Table>
    </form>
    <script type="text/javascript">
        $(function () {
            if ($.browser.msie) {
                $("tr.tdSelectBar").bind("click", SetTd);
            }
            SetTd();

        });        
        function SetTd() {
            if ($.browser.msie) {
                if ($("tr.contentcss:visible td").height() < 150)
                    $(".contentcss:visible  td").addClass("iecontentcsstd");
            }
            else
                $("tr.contentcss:visible td").height($("tr.contentcss:visible").height());
        }
    </script>
</body>
</html>
