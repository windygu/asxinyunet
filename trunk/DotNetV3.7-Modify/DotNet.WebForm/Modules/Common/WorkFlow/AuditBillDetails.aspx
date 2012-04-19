<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditBillDetails.aspx.cs"
    Inherits="UserBillDetails" %>

<%@ Register Src="AuditList.ascx" TagName="AuditList" TagPrefix="AuditList" %>
<html>
<head runat="server">
    <title runat="server">单据内容</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <style>
        .Button
        {
            background-image: url(../../../Themes/Default/Images/Button.gif);
        }
    </style>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <table width="100%" height="100%">
        <tr height="100%" width="100%">
            <td colspan="3" valign="top">
                <%= this.IframeUrl%>
            </td>
        </tr>
        <tr>
            <td width="60%">
                <div class="breadcrumbHeader">
                    <b>审核单据</b><span>
                        <img id="imgAudit" src="../../../Themes/Default/Images/close.gif" alt="隐藏" onmouseover="this.style.cursor='hand'"
                            onclick="displayTable('imgAudit', 'spanAudit')" /></span>
                </div>
            </td>
            <td width="40%">
                <div class="breadcrumbHeader">
                    <b>审核意见</b><span>
                        <img id="imgWorkFlowAuditRecord" src="../../../Themes/Default/Images/close.gif" alt="隐藏"
                            onmouseover="this.style.cursor='hand'" onclick="displayTable('imgWorkFlowAuditRecord', 'tabWorkFlowAuditRecord')" /></span>
                </div>
            </td>
            <!--
            <td width="25%">
                <div class="breadcrumbHeader">
                    <b>评论</b><span>
                        <img id="imgComment" src="../../../Themes/Default/Images/close.gif" alt="隐藏" onmouseover="this.style.cursor='hand'"
                            onclick="displayTable('imgComment', 'tableComment')" /></span>
                </div>
            </td>
            -->
        </tr>
        <tr>
            <td valign="top">
                <asp:UpdatePanel ID="upUserSelect" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDepartment" runat="server" Visible="false" Text="审核后发给部门："></asp:Label>
                        <asp:DropDownList ID="cmbDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged"
                            Visible="false" Width="150px">
                        </asp:DropDownList>
                        <asp:Label ID="lblUser" runat="server" Text="审核人：" Visible="false"></asp:Label>
                        <asp:DropDownList ID="cmbUser" runat="server" Visible="false" Width="100px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <span id="spanAudit">
                    <asp:TextBox ID="txtAuditIdea" runat="server" Width="100%" MaxLength="200" TextMode="MultiLine"></asp:TextBox><br />
                    <asp:Button ID="btnAuditPass" runat="server" CssClass="Button" Text="通过(P)" AccessKey="P"
                        TabIndex="2" OnClick="btnAuditPass_Click" UseSubmitBehavior="false" OnClientClick="this.value='正在提交';this.disabled=true;"
                        onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    <asp:Button ID="btnAuditReject" runat="server" CssClass="Button" Text="退回(B)" AccessKey="B"
                        TabIndex="3" OnClientClick="return confirm('你确认退回给申请单据者？');" OnClick="btnAuditReject_Click"
                        onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    <asp:Button ID="btnAuditQuash" runat="server" CssClass="Button" Text="废弃(D)" AccessKey="D"
                        TabIndex="4" OnClientClick="return confirm('你确认废弃单据吗？');" OnClick="btnAuditQuash_Click"
                        onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    &nbsp;<asp:Label ID="lblBackTo" runat="server" Text="退回："></asp:Label>
                    <asp:DropDownList ID="cmbBackTo" Width="120px" TabIndex="5" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btnAuditBack" runat="server" CssClass="Button" Text="确认退回" AccessKey="R"
                        TabIndex="6" OnClientClick="return confirm('你确认退回单据吗？');" OnClick="btnAuditBack_Click"
                        onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    <asp:Button ID="btnEdit" runat="server" CssClass="Button" Text="编辑(E)" ToolTip="编辑单据"
                        AccessKey="E" TabIndex="7" OnClick="btnEdit_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    <asp:Button ID="btnAttachment" runat="server" CssClass="Button" Text="附件(A)" ToolTip="编辑单据中的附件"
                        AccessKey="A" TabIndex="8" OnClick="btnAttachment_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                </span>
            </td>
            <td valign="top">
                <table id="tabWorkFlowAuditRecord" class="table" width="100%" border="0" cellpadding="0"
                    cellspacing="0">
                    <tr valign="top">
                        <td valign="top">
                            <AuditList:AuditList ID="ucAuditList" AutoFill="true" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="top">
                <table id="tableWorkFlowActivity" class="table" width="100%" border="0" cellpadding="0"
                    cellspacing="0" style="display: none">
                    <tr valign="top">
                        <td valign="top">
                            <asp:Label ID="lblWorkFlowActivity" runat="server" Text="审核流程"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtCurrentId" runat="server" Value="" />
    <asp:HiddenField ID="txtObjectId" runat="server" Value="" />
    </form>
    <!--endprint-->
</body>
</html>
