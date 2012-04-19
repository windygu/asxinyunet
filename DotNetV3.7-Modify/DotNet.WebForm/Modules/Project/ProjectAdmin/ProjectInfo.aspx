<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectInfo.aspx.cs" Inherits="ProjectInfo" %>
<%@ Register Src="../../Common/Attachment/Attachment.ascx" TagName="Attachment" TagPrefix="Attachment" %>
<html>
<head id="Head1" runat="server">
    <title>工作流程审批系统 - 项目浏览</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />

    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    
    <script language='javascript'>
        function showChangeLog() {
            var projectId = document.getElementById('txtId').value;
            openStdDlg("ChangeLog.aspx?Id=" + projectId, null, 650, 500);
            return false;
        }    
    </script>

    <script language="javascript" type="text/javascript" src="../../../JavaScript/My97DatePicker/WdatePicker.js"
        defer="defer"></script>

    <link type="text/css" rel="Stylesheet" href="../../../JavaScript/My97DatePicker/skin/WdatePicker.css" />
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
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" method="post" runat="server">
    <table width="100%" height="100%" cellspacing="2">
        <tr>
            <td colspan="2">
                <div class="breadcrumbHeader">
                    <b>工作流程审批系统 - 项目浏览</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top" colspan="2">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td align="right" style="width: 100px" class="td-title">
                                立项日期：
                            </td>
                            <td class="td-content">
                                <asp:Label ID="lblLiXiangRiQi" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="15" align="right" nowrap="nowrap" style="width: 100px" class="td-title">
                                客户名称：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                    <asp:Label ID="lblKeHuMingCheng" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                客户项目名称：
                            </td>
                            <td class="td-content">
                                    <asp:Label ID="lblKeHuXiangMuMingCheng" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                客户资料：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <Attachment:Attachment ID="AttachmentKeHuZiLiao" AllowDelete="false" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                确认图纸：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                            <Attachment:Attachment ID="AttachmentQuRenTuZhi" AllowDelete="false" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                确认结果：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <Attachment:Attachment ID="AttachmentQuRenJieGuo" AllowDelete="false" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right" style="width: 100px" class="td-title">
                                型号：
                            </td>
                            <td class="td-content">
                                <asp:Label ID="lblXingHao" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td valign="top" align="right" style="width: 100px" class="td-title">
                                PET测试结果：
                            </td>
                            <td class="td-content">
                                <asp:Label ID="lblPETCheShiJieGuo" runat="server" ></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px; margin: auto auto auto auto"
                colspan="2">
                <asp:Button ID="btnEdit" runat="server" CssClass="Button" Text="编辑(E)" AccessKey="S"
                    TabIndex="1" OnClick="btnEdit_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" style="background-image: url('../../../Themes/Default/Images/Button.gif');width:79px;height:22px" />
                
                <asp:Button ID="btnChangeLog" runat="server" Text="修改记录(L)"
                    CssClass="Button" TabIndex="2" AccessKey="L"  OnClientClick="return showChangeLog();"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';"  style="background-image: url('../../../Themes/Default/Images/Button.gif');width:79px;height:22px"/>
                
                <asp:Button ID="btnReturn" runat="server" Text="返回(R)" OnClick="btnReturn_Click"
                    CssClass="Button" TabIndex="3" AccessKey="R" 
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';"  style="background-image: url('../../../Themes/Default/Images/Button.gif');width:79px;height:22px"/>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" Value="ProjectAdmin.aspx" runat="server" />
    </form>
</body>
</html>
