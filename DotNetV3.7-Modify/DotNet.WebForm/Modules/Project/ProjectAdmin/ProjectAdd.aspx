<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectAdd.aspx.cs" Inherits="ProjectAdd" %>

<html>
<head id="Head1" runat="server">
    <title>工作流程审批系统 - 录入项目</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
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
    <form id="form1" method="post" runat="server" enctype="multipart/form-data">
    <table width="100%" height="100%" cellspacing="2">
        <tr>
            <td colspan="2">
                <div class="breadcrumbHeader">
                    <b>工作流程审批系统 - 录入项目</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top" colspan="2">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <table id="table_taskallot" class="table" width="100%" border="0" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td align="right">
                                <font color="red">*</font> 立项日期：
                            </td>
                            <td>
                                <asp:TextBox ID="txtLiXiangRiQi" runat="server" MaxLength="4" class="Wdate" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',isShowClear:false,readOnly:true})"
                                    Width="204px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                试产总结：
                            </td>
                            <td class="td-content">
                                <asp:FileUpload ID="FileUpload2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td height="15" align="right" nowrap="nowrap">
                                <font color="red">*</font> 客户名称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeHuMingCheng" runat="server" MaxLength="100" Width="83%" CssClass="ColorBlur"
                                    onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                问题：
                            </td>
                            <td class="td-content" style="padding-top: 3">
                                <asp:FileUpload ID="FileUpload3" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                客户项目名称：
                            </td>
                            <td class="style5">
                                <asp:TextBox ID="txtKeHuXiangMuMingCheng" runat="server" MaxLength="100" Width="83%"
                                    CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                处理方案：
                            </td>
                            <td class="td-content">
                                <asp:FileUpload ID="FileUpload4" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                客户资料：
                            </td>
                            <td>
                                <asp:FileUpload ID="fuKeHuZiLiao" EnableViewState="true" runat="server" Width="217px" />
                            </td>
                            <td style="padding-top: 3">
                                &nbsp;
                            </td>
                            <td align="right">
                                状态、处理结果：
                            </td>
                            <td class="td-content">
                                <asp:FileUpload ID="FileUpload5" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                确认图纸：
                            </td>
                            <td>
                                <asp:FileUpload ID="fuQuRenTuZhi" EnableViewState="true" runat="server" Width="222px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                PET测试报告：
                            </td>
                            <td class="td-content">
                                <asp:FileUpload ID="FileUpload6" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                确认结果：
                            </td>
                            <td>
                                <asp:FileUpload ID="fuQuRenJieGuo" EnableViewState="true" runat="server" Width="215px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                PET测试结果：
                            </td>
                            <td class="td-content">
                                <asp:RadioButton ID="rbPETCheShiJieGuoOK" runat="server" Text="OK" GroupName="PETCheShiJieGuo" />
                                <asp:RadioButton ID="rbPETCheShiJieGuoNG" runat="server" Text="NG" GroupName="PETCheShiJieGuo" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                型号：
                            </td>
                            <td class="style6">
                                <asp:TextBox ID="txtXingHao" runat="server" Width="87%" TabIndex="7" MaxLength="800"
                                    CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                    Rows="3" Height="21px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                TG测试报告：
                            </td>
                            <td>
                                <asp:FileUpload ID="FileUpload7" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                开改模日期：
                            </td>
                            <td>
                                <asp:TextBox ID="txtKaiGaiMoRiQi" runat="server" MaxLength="4" class="Wdate" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',isShowClear:false,readOnly:true})"
                                    Width="200px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                TG测试结果：
                            </td>
                            <td>
                                <asp:RadioButton ID="RadioButton3" runat="server" Checked="True" Text="OK" />
                                <asp:RadioButton ID="RadioButton4" runat="server" Text="NG" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                出样日期：
                            </td>
                            <td class="style5">
                                <asp:TextBox ID="txtChuYangRiQi" runat="server" MaxLength="4" class="Wdate" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',isShowClear:false,readOnly:true})"
                                    Width="202px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                FPC测试报告：
                            </td>
                            <td class="td-content">
                                <asp:FileUpload ID="FileUpload8" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                报价编号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtXingHao0" runat="server" Width="87%" TabIndex="7" MaxLength="800"
                                    CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                                    Rows="3" Height="21px"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                FPC测试结果：
                            </td>
                            <td class="td-content">
                                <asp:RadioButton ID="RadioButton5" runat="server" Checked="True" Text="OK" />
                                <asp:RadioButton ID="RadioButton6" runat="server" Text="NG" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                投料编号：
                            </td>
                            <td class="style5">
                                &nbsp;
                            </td>
                            <td class="style8">
                                &nbsp;
                            </td>
                            <td align="right">
                                测试报告：
                            </td>
                            <td class="td-content">
                                <asp:FileUpload ID="FileUpload9" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                样品编号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtKeHuXiangMuMingCheng0" runat="server" MaxLength="100" Width="83%"
                                    CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                测试结果：
                            </td>
                            <td class="td-content">
                                <asp:RadioButton ID="RadioButton7" runat="server" Checked="True" Text="OK" />
                                <asp:RadioButton ID="RadioButton8" runat="server" Text="NG" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                试产过程问题：
                            </td>
                            <td class="style5">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                问题分析验证：
                            </td>
                            <td class="td-content">
                                <asp:FileUpload ID="FileUpload10" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style15">
                                &nbsp;
                            </td>
                            <td class="style5">
                                &nbsp;
                            </td>
                            <td class="style8">
                                &nbsp;
                            </td>
                            <td class="style14">
                                &nbsp;
                            </td>
                            <td class="td-content">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px; margin: auto auto auto auto"
                colspan="2">
                <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="保存(S)" AccessKey="S"
                    TabIndex="3" OnClick="btnSave_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';"
                    Style="background-image: url('../../../Themes/Default/Images/Button.gif'); width: 79px;
                    height: 22px" />
                <asp:Button ID="btnReturn" runat="server" Text="返回(R)" OnClick="btnReturn_Click"
                    CssClass="Button" TabIndex="7" AccessKey="R" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    Style="background-image: url('../../../Themes/Default/Images/Button.gif'); width: 79px;
                    height: 22px" onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    <asp:HiddenField ID="txtReturnURL" Value="ProjectAdmin.aspx" runat="server" />
    </form>
</body>
</html>
