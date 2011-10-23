<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResultNews.aspx.cs" Inherits="WebUI.ResultNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" rev="stylesheet" href="css/basic.css" type="text/css" />
    <title>Result</title>
</head>
<body style="background-color:#8c8c8c">
    <form id="form1" runat="server">
    <div>
    
<table width="1024" border="0" align="center" cellpadding="0" cellspacing="0" style="display: inline-table; background-color:#FFFFFF;">
<!-- fwtable fwsrc="news.png" fwpage="页面 1" fwbase="news.jpg" fwstyle="Dreamweaver" fwdocid = "394241400" fwnested="0" -->
  <tr>
   <td><img src="images/spacer.gif" width="63" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="198" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="19" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="10" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="426" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="195" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="113" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="1" border="0" alt="" /></td>
  </tr>

  <tr>
   <td colspan="7"><img src="images/index_r1_c1.jpg" alt="" name="index_r1_c1" width="1024" height="178" border="0" usemap="#index_r1_c1Map" id="index_r1_c1" /></td>
   <td><img src="images/spacer.gif" width="1" height="182" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="2"><img name="news_r2_c1" src="images/news_r2_c1.jpg" width="261" height="70" border="0" id="news_r2_c1" alt="" /></td>
   <td colspan="5"><img name="news_r2_c3" src="images/news_r2_c3.jpg" width="763" height="70" border="0" id="news_r2_c3" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="70" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="2" rowspan="7" valign="top" style="height:57px"><a href="LabNews.aspx"><img name="news_r3_c1" src="images/news_r3_c1.jpg" width="261" height="57" border="0" id="news_r3_c1" alt="" /></a><a href="ResearchNews.aspx"><br />
     <img name="news_r6_c1" src="images/news_r6_c1.jpg" width="261" height="51" border="0" id="news_r6_c1" alt="" /></a><a href="ResultNews.aspx"><br />
     <img name="news_r7_c1" src="images/news_r7_c1.jpg" width="261" height="58" border="0" id="news_r7_c1" alt="" /></a></td>
   <td colspan="5" rowspan="7" valign="top" style="padding-top:15px;" id="articleList">
    
        <asp:Literal ID="ArticalList" runat="server" 
            OnLoad="ArticalList_Load"></asp:Literal>                        </td>
   <td><img src="images/spacer.gif" width="1" height="22" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img src="images/spacer.gif" width="1" height="11" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img src="images/spacer.gif" width="1" height="24" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img src="images/spacer.gif" width="1" height="51" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img src="images/spacer.gif" width="1" height="58" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img src="images/spacer.gif" width="1" height="467" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img src="images/spacer.gif" width="1" height="19" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="5"><img name="news_r10_c1" src="images/news_r10_c1.jpg" width="716" height="68" border="0" id="news_r10_c1" alt="" /></td>
   <td colspan="2"><img name="news_r10_c6" src="images/news_r10_c6.jpg" width="308" height="68" border="0" id="news_r10_c6" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="68" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img name="news_r11_c1" src="images/news_r11_c1.jpg" width="63" height="74" border="0" id="news_r11_c1" alt="" /></td>
   <td colspan="6"><img name="news_r11_c2" src="images/news_r11_c2.jpg" width="961" height="74" border="0" id="news_r11_c2" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="74" border="0" alt="" /></td>
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
