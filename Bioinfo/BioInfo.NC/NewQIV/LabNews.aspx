<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabNews.aspx.cs" Inherits="WebUI.LabNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link rel="stylesheet" rev="stylesheet" href="css/basic.css" type="text/css" />
    <title>Lab News</title>
</head>
<body style="background-color:#8c8c8c">
    <form id="form1" runat="server">
    <div>
        <table align="center" border="0" cellpadding="0" cellspacing="0" 
            style="display: inline-table; background-color:#FFFFFF;" width="1024">
<!-- fwtable fwsrc="news.png" fwpage="页面 1" fwbase="news.jpg" fwstyle="Dreamweaver" fwdocid = "394241400" fwnested="0" -->
            <tr>
                <td>
                    <img alt="" border="0" height="1" src="images/spacer.gif" 
                        width="63" /></td>
                <td>
                    <img alt="" border="0" height="1" src="images/spacer.gif" 
                        width="198" /></td>
                <td>
                    <img alt="" border="0" height="1" src="images/spacer.gif" 
                        width="19" /></td>
                <td>
                    <img alt="" border="0" height="1" src="images/spacer.gif" 
                        width="10" /></td>
                <td>
                    <img alt="" border="0" height="1" src="images/spacer.gif" 
                        width="426" /></td>
                <td>
                    <img alt="" border="0" height="1" src="images/spacer.gif" 
                        width="195" /></td>
                <td>
                    <img alt="" border="0" height="1" src="images/spacer.gif" 
                        width="113" /></td>
                <td>
                    <img alt="" border="0" height="1" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td colspan="7">
                    <img id="index_r1_c1" alt="" border="0" height="178" name="index_r1_c1" 
                        src="images/index_r1_c1.jpg" usemap="#index_r1_c1Map" 
                        width="1024" /></td>
                <td>
                    <img alt="" border="0" height="182" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <img id="news_r2_c1" alt="" border="0" height="70" name="news_r2_c1" 
                        src="images/news_r2_c1.jpg" width="261" /></td>
                <td colspan="5">
                    <img id="news_r2_c3" alt="" border="0" height="70" name="news_r2_c3" 
                        src="images/news_r2_c3.jpg" width="763" /></td>
                <td>
                    <img alt="" border="0" height="70" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td colspan="2" rowspan="7" valign="top" style="height:57px">
                    <a href="LabNews.aspx">
                    <img id="news_r3_c1" alt="" border="0" height="57" name="news_r3_c1" 
                        src="images/news_r3_c1.jpg" width="261" /></a><a href="ResearchNews.aspx"><br />
                    <img id="news_r6_c1" alt="" border="0" height="51" name="news_r6_c1" 
                        src="images/news_r6_c1.jpg" width="261" /></a><a href="ResultNews.aspx"><br />
                    <img id="news_r7_c1" alt="" border="0" height="58" name="news_r7_c1" 
                        src="images/news_r7_c1.jpg" width="261" /></a></td>
                <td colspan="5" rowspan="7" valign="top" style="padding-top:15px;" id="articleList">
                <asp:Literal ID="ArticalList" runat="server" OnLoad="ArticalList_Load"></asp:Literal>                </td>
                <td>
                    <img alt="" border="0" height="22" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td>
                    <img alt="" border="0" height="11" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td>
                    <img alt="" border="0" height="24" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td>
                    <img alt="" border="0" height="51" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td>
                    <img alt="" border="0" height="58" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td>
                    <img alt="" border="0" height="467" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td>
                    <img alt="" border="0" height="19" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td colspan="5">
                    <img id="news_r10_c1" alt="" border="0" height="68" name="news_r10_c1" 
                        src="images/news_r10_c1.jpg" width="716" /></td>
                <td colspan="2">
                    <img id="news_r10_c6" alt="" border="0" height="68" name="news_r10_c6" 
                        src="images/news_r10_c6.jpg" width="308" /></td>
                <td>
                    <img alt="" border="0" height="68" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
            <tr>
                <td>
                    <img id="news_r11_c1" alt="" border="0" height="74" name="news_r11_c1" 
                        src="images/news_r11_c1.jpg" width="63" /></td>
                <td colspan="6">
                    <img id="news_r11_c2" alt="" border="0" height="74" name="news_r11_c2" 
                        src="images/news_r11_c2.jpg" width="961" /></td>
                <td>
                    <img alt="" border="0" height="74" src="images/spacer.gif" 
                        width="1" /></td>
            </tr>
        </table>
    </div>
<map name="index_r1_c1Map" id="index_r1_c1Map">
  <area shape="rect" coords="903,103,982,140" href="AboutUs.aspx" />
  <area shape="rect" coords="796,103,875,140" href="http://www.ncu.edu.cn" />
  <area shape="rect" coords="697,104,776,141" href="members.aspx" />
  <area shape="rect" coords="596,102,675,139" href="Services.aspx" />
<area shape="rect" coords="493,102,572,139" href="LabNews.aspx" /><area shape="rect" coords="397,103,476,140" href="default.aspx" /></map>
    </form>
</body>
</html>
