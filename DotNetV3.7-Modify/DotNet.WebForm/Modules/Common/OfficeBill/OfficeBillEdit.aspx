<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfficeBillEdit.aspx.cs"
    Inherits="OfficeBillEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑模板单据</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
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
    <% 
        //获取服务器的地址
        string PostURL = this.Session["PostURL"].ToString();
        // 获取服务器的地址
        string FileURL = this.Session["FileURL"].ToString();
    %>
    <script id="clientEventHandlersJS" language="javascript">
<!--
        function WebOffice1_NotifyCtrlReady() {
            // LoadOriginalFile接口装载文件,
            // 如果是编辑已有文件，则文件路径传给LoadOriginalFile的第一个参数
            document.all.WebOffice1.LoadOriginalFile("<%=FileURL %>", "xls");

            // 屏蔽标准工具栏的前几个按钮
            document.all.WebOffice1.SetToolBarButton2("Standard", 1, 1);
            document.all.WebOffice1.SetToolBarButton2("Standard", 2, 1);
            document.all.WebOffice1.SetToolBarButton2("Standard", 3, 1);
            document.all.WebOffice1.SetToolBarButton2("Standard", 6, 1);

            // 屏蔽文件菜单项
            // document.all.WebOffice1.SetToolBarButton2("Worksheet Menu Bar", 1, 1);
            document.all.WebOffice1.ShowToolBar(0);
            document.all.WebOffice1.SetToolBarButton2("Menu Bar", 1, 8);
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
    <script language="javascript" type="text/javascript">
            // ---------------------== 关闭页面时调用此函数，关闭文档--------------------- //
        function return_Submit() {
            window.close();
            window.open("SubmitBill.aspx?ObjectId=<%=this.UserBillId%>");
        }
    </script>

    <script language="javascript" type="text/javascript">
    // -----------------------------== 保存文档 ==------------------------------------ //
    function SaveDoc(submit) {
	 if(myform.txtTitle.value ==""){
		alert("模板标题")
		myform.txtTitle.focus();
		return false;
	 }

	//恢复被屏蔽的菜单项和快捷键
    document.all.WebOffice1.SetToolBarButton2("Standard",1,3);
    document.all.WebOffice1.SetToolBarButton2("Standard",2,3);
    document.all.WebOffice1.SetToolBarButton2("Standard",3,3);
    document.all.WebOffice1.SetToolBarButton2("Standard",6,3);           
        //恢复文件菜单项
        document.all.WebOffice1.SetToolBarButton2("Worksheet Menu Bar",1,4);         
//初始化Http引擎
	document.all.WebOffice1.HttpInit();			
//添加相应的Post元素

	if ("<%=this.UserBillId%>" != "")
    {          
	    document.all.WebOffice1.SetTrackRevisions(0);
	    document.all.WebOffice1.ShowRevisions(0);
	    document.all.WebOffice1.HttpAddPostString("ID","<%=this.UserBillId%>");
	}
	document.all.WebOffice1.HttpAddPostString("DocTitle", escape(myform.txtTitle.value));
    document.all.WebOffice1.HttpAddPostString("DocTemplateId", escape(myform.txtTemplateId.value));
    document.all.WebOffice1.HttpAddPostString("DocType", "xls");
    // document.all.WebOffice1.HttpAddPostString("DocSubmit", submit);
	// 把当前文档添加到Post元素列表中，文件的标识符䶿DocContent
	document.all.WebOffice1.HttpAddPostCurrFile("DocContent","");		
	var vtRet;
    // HttpPost执行上传的动仿WebOffice支持Http的直接上传，在upload.aspx的页面中,解析Post过去的数据
    // 拆分出Post元素和文件数据，可以有选择性的保存到数据库中，或保存在服务器的文件中⾿
	// HttpPost的返回值，根据upload.aspx中的设置，返回upload.aspx中Response.Write回来的数据

	vtRet = document.all.WebOffice1.HttpPost("<%=PostURL %>/UserOfficeUpload.aspx");

 	    // alert(vtRet);
 	    if("succeed" == vtRet){
            if(window.opener && !window.opener.closed){
                window.opener.location.href=window.opener.location.href;
            }
            // alert("文件上传成功。");
            if (submit == false)
            {
                // document.all.WebOffice1.Close();
                window.opener = null;
                window.open('','_self');
                window.close();
            }
            else
            {
                // 这里其实想跳转到提交页面
                // alert("执行跳转");
                return_Submit();
            }
	    }
        else
        {
		    // alert(vtRet);
		    // alert("文件上传失败。");
	    }
    }
    </script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="myform" method="post" runat="server">
    <table width="100%" height="100%" cellspacing="2">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>审核流程-提交单据</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <table id="table_taskallot" class="table" width="100%" height="100%" border="0" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td class="td-title">
                            <font color="red">*</font> 单据标题：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3">
                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" Width="100%" CssClass="ColorBlur"
                                onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="100%" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                            单据内容：
                        </td>
                        <td colspan="3" class="td-content" style="padding-top: 3" valign="top">
                            <!-- -----------------------------== 装载weboffice控件 ==----------------------------------->
                            <script src="../../../JavaScript/LoadWebOffice.js"></script>
                            <!-- --------------------------------==  结束装载控件 ==------------------------------------->
                        </td>
                    </tr>
                    <tr>
                        <td class="td-title">
                            审核流程：
                        </td>
                        <td class="td-content" colspan="3">
                            <asp:Label ID="lblWorkFlowActivity" runat="server" Text="未设置审核流程的请及时与管理员联系。"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px; margin: auto auto auto auto">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="保存(S)" AccessKey="S"
                    TabIndex="3" OnClientClick="return SaveDoc(false);" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                <asp:Button ID="btnSaveAndSend" runat="server" CssClass="Button" Text="保存并提交(C)" AccessKey="C"
                    TabIndex="3" OnClientClick="return SaveDoc(true);" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLargem.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLarge.gif)';" />
                <asp:Button ID="btnReturn" runat="server" CssClass="Button" Text="返回" AccessKey="R"
                    TabIndex="3" OnClick="btnReturn_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtTemplateId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    </form>
</body>
</html>
