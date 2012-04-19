<%@ Import Namespace="DotNet.Utilities" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommonTop.ascx.cs" Inherits="CommonTop" %>
<style type="text/css">
<!--
.menuclass {
	color: #5c6d71;
}

.menuover {
	color: #ffffff;
	background-color:#007ac7;
}
.menuover a {
	color: #ffffff;
}
.menuover a:hover
{
	color: #ffffff;	 
}
.menuclick{
	color: #ffffff;
	background-color:#007ac7;
	font-weight: bold;
}
.menuclick a {
	color: #ffffff;
	background-color:#007ac7;
}
-->
</style>
<div id="bannel1" style="border: 0 0 0; text-align: center;" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="1" bgcolor="#FFFFFF">
            </td>
        </tr>
        <tr>
            <td height="24" align="center" bgcolor="#747a7d">
                <table width="98%" border="0" cellpadding="0" cellspacing="0" id="menu-list">
                    <tr>
                        <td align="left">
                            <asp:Label ID="dateInfo" runat="server" Text="" Style="color: #fff000; font-weight: bold;"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblLogOnInfo" runat="server"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:HyperLink ID="HyperLink2" runat="server" Target="_top" NavigateUrl="Default.aspx">返回首页</asp:HyperLink>
                            <asp:HyperLink ID="hypMyInfo" runat="server" Target="fraContent" NavigateUrl="Modules/Common/UserAdmin/UserInfo.aspx">我的信息</asp:HyperLink>
                            <%
                                var url = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + "/Work.aspx";
                            %>
                            <a href="Javascript:window.external.addFavorite('<%= url %>','<%= BaseSystemInfo.SoftFullName%>')">加入收藏</a>
                            <a href="#" onclick="this.style.behavior='url(#default#homepage)'; this.setHomePage('<%= url %>');event.returnValue=false;">
                                设为首页</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="1" bgcolor="#FFFFFF">
            </td>
        </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td background="Themes/Blue/Images/Home/bg_top.jpg">
                <table width="1002" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td background="Themes/Blue/Images/Home/top-d.jpg">
                            <script type="text/javascript">                                InsertFlash("Themes/Blue/Images/Home/top.swf", 1002, "<%=FlashHeight %>", "top");</script>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td background="Themes/Blue/Images/Home/line_top.jpg" height="13">
            </td>
        </tr>
    </table>
</div>
<div id="bannel3" style="border: 0 0 0; text-align: center;" runat="server">
    <table background="Themes/Blue/Images/Home/bg_menu.jpg" width="100%" border="0" align="center"
        cellpadding="0" cellspacing="0">
        <tr>
            <td width="15" height="20" nowrap>
            </td>
            <td>
                <asp:Literal runat="server" ID="Module_Title"></asp:Literal>
            </td>
        </tr>
    </table>
</div>
<script language="javascript">
    // 鼠标移入时
    function img_mouseover(obj) {
        var objsrc = obj.src;
        obj.src = obj.src.replace("_01", "_02");
    }

    //鼠标移出时
    function img_mouseout(obj) {
        var objsrc = obj.src;
        obj.src = obj.src.replace("_02", "_01");
    }

    //全局变量
    var oldMenuClassName = null;
    //选中事件
    function changeMenu(obj) {
        oldMenuClassName = obj.className;
        obj.className = "menuover";
    }

    //选中事件
    function OutMenu(obj) {
        obj.className = oldMenuClassName;
    }
</script>
