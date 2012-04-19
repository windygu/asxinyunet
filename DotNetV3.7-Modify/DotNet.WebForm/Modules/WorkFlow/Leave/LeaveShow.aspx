<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveShow.aspx.cs" Inherits="LeaveShow" %>
<%@ Register Src="../../Common/Attachment/Attachment.ascx" TagName="Attachment" TagPrefix="Attachment" %>
<html>
<head>
    <title>请假单</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com"/>
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
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
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server" onkeydown="EnterToTab()">
    <table width="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>请假单</b><span>
                        <img id="img" src="../../../Themes/Default/Images/close.gif" alt="隐藏" onmouseover="this.style.cursor='hand'"
                            onclick="displayTable()" /></span>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top">
                <table id="table" class="table" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                                                <tr>
                            <td id='UserName' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                申请人：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblUserName' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='DepartmentName' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                部门：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblDepartmentName' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='Code' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                单据编号：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblCode' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='TransferOfPeople' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                工作交接人：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblTransferOfPeople' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='Telephone' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                联系电话：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblTelephone' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='Reason' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                请假原因：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblReason' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='Day' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                请假天数：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblDay' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='ItemsLeaveCategory' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                请假类别：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblItemsLeaveCategory' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='StartTime' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                开始日期：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblStartTime' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='EndTime' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                结束日期：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblEndTime' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='TransferInstructions' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                工作交接说明：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblTransferInstructions' runat='server'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id='Description' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                                描述：
                            </td>
                            <td class='td-content' style='width: 200px' style='padding-top: 3'>
                                <asp:Label ID='lblDescription' runat='server'></asp:Label>
                            </td>
                        </tr>

                    </tr>
                    <tr>
                        <td colspan="2" align="center" valign="middle" class="td-content">
                            <br />
                            <asp:Button ID="btnReturn" runat="server" CssClass="Button" Visible="false" Text="返回(R)" AccessKey="R"
                                TabIndex="3" OnClick="btnReturn_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                                onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                            <br />
							<br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtReturnURL" runat="server"/>
    <asp:HiddenField ID="txtId" runat="server" />
    </form>
    <!--endprint-->
</body>
</html>

