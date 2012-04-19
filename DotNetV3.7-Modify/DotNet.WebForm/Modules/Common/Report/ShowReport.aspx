<%@ Import Namespace="System.Configuration" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowReport.aspx.cs" Inherits="ShowReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title runat="server">审批流程管理</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <script src="Report/CreateControl.js" language="javascript"></script>
    <script language="javascript" type="text/javascript">
		    // <!CDATA[

		    CreateReport("Report");

		    function window_onload() {
		        ReportViewer.Stop();
		        // ReportViewer.ShowToolbar = <% = this.AllowPrint.ToString().ToLower() %>;

                <%
                 if (! this.AllowPrint)
                    {
                 %>

		        ReportViewer.RemoveToolbarControl(2);
		        ReportViewer.RemoveToolbarControl(5);
		        ReportViewer.RemoveToolbarControl(6);
		        ReportViewer.RemoveToolbarControl(7);
		        ReportViewer.RemoveToolbarControl(50);
		        ReportViewer.RemoveToolbarControl(51);
		        ReportViewer.RemoveToolbarControl(52);
		        ReportViewer.RemoveToolbarControl(53);
		        ReportViewer.RemoveToolbarControl(54);
		        ReportViewer.RemoveToolbarControl(55);
		        ReportViewer.RemoveToolbarControl(56);
		        ReportViewer.RemoveToolbarControl(60);
		        ReportViewer.RemoveToolbarControl(61);

                 <%
                    }
                 %>

		        // 这个例子中为处理报表事件，所以在上面显式定义了 Report 对象，并在此与显示控件关联
		        ReportViewer.Report = Report.MyInterface;

		        //Report.LoadFromURL("Picture.grf");

		        // 最后更新显示
		        // ReportViewer.UpdateToolbar();
		        // 启动报表运行
		        ReportViewer.Start();
		    }

		    // ]]>
    </script>
    <script language="JavaScript" for="Report" event="Initialize()">
<!--
    <%= this.ReportParamters%>
	Report.ControlByName("PictureBox1").AsPictureBox.LoadFromFile("ReportData/Company.jpg");
    <%= this.ReportSignature%>    
-->
    </script>

    <SCRIPT LANGUAGE="JavaScript" FOR="Report" EVENT="GeneratePagesBegin()">
<!--
    // 隐藏选取列，让其在打印与导出时不输出
	// Report.ColumnByName("最低单价").Visible = false;
-->
</SCRIPT>

<SCRIPT LANGUAGE="JavaScript" FOR="Report" EVENT="GeneratePagesEnd()">
<!--
    // 恢复选取列显示，以便查询显示能此列显示出来
	// Report.ColumnByName("最低单价").Visible = true;
-->
</SCRIPT>


    <SCRIPT language="JavaScript" for="Report" event="PrintBegin()">
<!--
    <%= this.PrintBegin%>  
-->
</SCRIPT>

    <script language="JavaScript" for="Report" event="ProcessRecord()">
<!--
	//var PathFile = "Picture/" + Report.FieldByName("PictureFile").AsString + ".bmp";
	//Report.ControlByName("FilePictureBox").AsPictureBox.LoadFromFile(PathFile);
-->
    </script>
    <style type="text/css">
        html, body
        {
            margin: 0;
            height: 100%;
        }
    </style>
</head>
<body style="margin: 0" onload="return window_onload()">
    <script language="javascript">
        // 创建报表
        // CreatePrintViewer("Report/<%= this.CategoryCode%>.grf")
        CreatePrintViewer("Report/<%= this.CategoryCode%>.grf", "ReportData/xmlCustomer.aspx?CategoryCode=<%= this.CategoryCode%>&ObjectId=<%= this.ObjectId%>")
    </script>
</body>
</html>
