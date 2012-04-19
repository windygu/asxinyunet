<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaveEdit.aspx.cs" Inherits="LeaveEdit" %>
<%@ Import Namespace="DotNet.Utilities" %>
<%@ Register Src="../../Common/Attachment/Attachment.ascx" TagName="Attachment" TagPrefix="Attachment" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>请假单</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com"/>
    <base target="_self" />
    <script language="javascript" src="../../../JavaScript/Default.js"></script>
	<script language="javascript" type="text/javascript" src="../../../JavaScript/My97DatePicker/WdatePicker.js" defer="defer"></script>
	<link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css"/>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css"/>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css"/>
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
	    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=blue"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
    <script>
        (function (config) {
            config['fixed'] = true;
            config['resize'] = false;
            config['width'] = '600px';
            config['height'] = '450px';
            config['title'] = "选择";
        })(art.dialog.defaults);

        // 弹出窗口选用户
        function SelectUser(hdUserId, lblRealName, hdOrganizeId, lblOrganizeName) {
            // 传递空间名称
            art.dialog.data('hdUserId', hdUserId);
            art.dialog.data('ucRealName', lblRealName);
            art.dialog.data('hdOrganizeId', hdOrganizeId);
            art.dialog.data('ucOrganizeName', lblOrganizeName);
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('../../../Modules/Common/User/UserSelect.aspx');
        }

        // 弹出窗口选角色
        function SelectRole(ucRoleId, lblRoleName) {
            // 传递空间名称
            art.dialog.data('hdRoleId', ucRoleId);
            art.dialog.data('lblRoleName', lblRoleName);
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('../../../Modules/Common/Role/RoleSelect.aspx');
        }

        // 弹出窗口选部门
        function SelectOrganize(ucOrganizeId, lblOrganizeName) {
            // 传递空间名称
            art.dialog.data('hdOrganizeId', ucOrganizeId);
            art.dialog.data('lblOrganizeFullName', lblOrganizeName);
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('../../../Modules/Common/Organize/OrganizeSelect.aspx');
        }

		function Validate() {
			
            if(IsEmpty(document.getElementById("txtDay").value))
            {
                alert("请假天数,不能为空。");
                document.getElementById("txtDay").focus();
                return false;
            }

            if(!IsNumber(document.getElementById("txtDay").value))
            {
                alert("请假天数,格式不正确，应为整数。");
                document.getElementById("txtDay").focus();
                return false;
            }

			return true;
        } 
    </script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server" onkeydown="EnterToTab()">
    <table width="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>请假单</b>
					<span>
						<img id="img" src="../../../Themes/Default/Images/close.gif" alt="隐藏" onmouseover="this.style.cursor='hand'"
							onclick="displayTable()" />
					</span>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top">
                <table id="table" class="table" border="0" cellpadding="0" cellspacing="0">
					<tr>
                        <td id='UserName' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                            申请人：
                        </td> 
                        <td class='td-content' style='padding-top: 3'> 
                            <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdUserId" runat="server"/>
                            <asp:HiddenField ID="hdOrganizeId" runat="server"/>
                            &nbsp;
                            <a href="javascript:SelectUser('hdUserId', 'lblUserName', 'hdOrganizeId','lblOrganizeName')">
                                <img src="../../../themes/default/images/useradd.png" title="选择申请人"/>申请人
                            </a>
                        </td> 
                    </tr>
                    <tr>
                        <td height='25' align='right' nowrap='nowrap' class='td-title'>
                            部门：
                        </td> 
                        <td class='td-content' style='width: 200px' style='padding-top: 3'>
                            <asp:Label ID="lblOrganizeName" runat="server" Text=""></asp:Label>
                        </td> 
                    </tr>
                    <tr>
                        <td id='TransferOfPeople' height='25' align='right' nowrap='nowrap' class='td-title'>
                            工作交接人：
                        </td> 
                        <td class='td-content' nowrap='false' style='padding-top: 3'> 
                            <asp:TextBox ID="txtTransferOfPeople" runat="server" MaxLength="50" EnableTheming="True" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"  Width="95%" Text=""></asp:TextBox>
                        </td> 
                    </tr>

                    <tr>
                        <td id='Telephone' height='25' align='right' nowrap='nowrap' class='td-title'>
                            联系电话：
                        </td> 
                        <td class='td-content' nowrap='false' style='padding-top: 3'> 
                            <asp:TextBox ID="txtTelephone" runat="server" MaxLength="50" EnableTheming="True" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"  Width="95%" Text=""></asp:TextBox>
                        </td> 
                    </tr>

                    <tr>
                        <td id='Reason' height='25' align='right' nowrap='nowrap' class='td-title'>
                            请假原因：
                        </td> 
                        <td class='td-content' nowrap='false' style='padding-top: 3'> 
                            <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="3" MaxLength="200" EnableTheming="True" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"  Width="95%" Text=""></asp:TextBox>
                        </td> 
                    </tr>

                    <tr>
                        <td id='Day' height='25' align='right' nowrap='nowrap' class='td-title'>
                            请假天数：
                        </td> 
                        <td class='td-content' nowrap='false' style='padding-top: 3'> 
                            <asp:TextBox ID="txtDay" runat="server"  EnableTheming="True" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';" onkeypress="event.returnValue=CheckInputIsInt(event.keyCode,this)" Width="95%" Text=""></asp:TextBox><font color='red'>*</font>
                        </td> 
                    </tr>

                    <tr>
                        <td id="ddlItemsLeaveCategory" height="25" align="right" nowrap="nowrap" class="td-title"> 
                            请假类别：
                        </td> 
                        <td class="td-content" style="padding-top: 3"> 
                            <asp:DropDownList ID="cmbItemsLeaveCategory" runat="server" Width="100%"> 
                            </asp:DropDownList> 
                        </td> 
                    </tr>
                    <tr>
                        <td id='StartTime' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                            开始日期：
                        </td> 
                        <td class='td-content' nowrap='false' style='width: 200px;padding-top: 3'> 
                            <asp:TextBox ID="txtStartTime" runat="server" MaxLength="10" Text="<%# DateTime.Now.ToString(BaseSystemInfo.DateFormat)%>" Width="150px" class="Wdate" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',isShowClear:true,readOnly:true})"></asp:TextBox>
                        </td> 
                    </tr>

                    <tr>
                        <td id='EndTime' height='25' style='width: 150px' align='right' nowrap='nowrap' class='td-title'>
                            结束日期：
                        </td> 
                        <td class='td-content' nowrap='false' style='width: 200px;padding-top: 3'> 
                            <asp:TextBox ID="txtEndTime" runat="server" MaxLength="10" Text="" Width="150px" class="Wdate" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',isShowClear:true,readOnly:true})"></asp:TextBox>
                        </td> 
                    </tr>

                    <tr>
                        <td id='TransferInstructions' height='25' align='right' nowrap='nowrap' class='td-title'>
                            工作交接说明：
                        </td> 
                        <td class='td-content' nowrap='false' style='padding-top: 3'> 
                            <asp:TextBox ID="txtTransferInstructions" runat="server" TextMode="MultiLine" Rows="5" MaxLength="800" EnableTheming="True" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"  Width="95%" Text=""></asp:TextBox>
                        </td> 
                    </tr>

                    <tr>
                        <td id='Description' height='25' align='right' nowrap='nowrap' class='td-title'>
                            描述：
                        </td> 
                        <td class='td-content' nowrap='false' style='padding-top: 3'> 
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" MaxLength="200" EnableTheming="True" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"  Width="95%" Text=""></asp:TextBox>
                        </td> 
                    </tr>


                    <tr>
                        <td colspan="2" align="center" valign="middle" class="td-content">
                            <br />
                            <asp:Button ID="btnAdd" runat="server" CssClass="Button" Text="保存" AccessKey="S"
								TabIndex="1" OnClick="btnAdd_Click" OnClientClick="return Validate();" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
								onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';"
								Visible="False" />
							&nbsp;<asp:Button ID="btnUpdate" runat="server" CssClass="Button" Text="更新" AccessKey="U"
								TabIndex="2" OnClick="btnUpdate_Click" OnClientClick="return Validate();" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
								onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
							&nbsp;<asp:Button ID="btnSend" runat="server" Visible="false" CssClass="Button" Text="提交审核" AccessKey="U"
								TabIndex="3" OnClick="btnSend_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
								onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
							<br />
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtReturnURL" runat="server" />
    <asp:HiddenField ID="txtId" runat="server" />
    </form>
    <!--endprint-->
</body>
</html>

