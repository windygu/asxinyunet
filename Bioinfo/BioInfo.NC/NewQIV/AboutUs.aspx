<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="WebUI.AboutUs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>About Us</title>
</head>
<body style="background-color:#8c8c8c">
    <form id="form1" runat="server">
    <div>
    
<table width="1024" border="0" align="center" cellpadding="0" cellspacing="0" style="display: inline-table; background-color:#FFFFFF;">
<!-- fwtable fwsrc="未命名" fwpage="页面 1" fwbase="About.jpg" fwstyle="Dreamweaver" fwdocid = "969737018" fwnested="0" -->
  <tr>
   <td><img src="images/spacer.gif" width="139" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="186" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="64" height="1" border="0" alt="" /></td>
   <td width="508"><img src="images/spacer.gif" width="508" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="11" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="116" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="1" border="0" alt="" /></td>
  </tr>

  <tr>
   <td colspan="6"><img src="images/index_r1_c1.jpg" alt="" name="index_r1_c1" width="1024" height="178" border="0" usemap="#index_r1_c1Map" id="index_r1_c1" /></td>
   <td><img src="images/spacer.gif" width="1" height="159" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="6"><img name="About_r2_c1" src="images/About_r2_c1.jpg" width="1024" height="49" border="0" id="About_r2_c1" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="49" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img name="About_r3_c1" src="images/About_r3_c1.jpg" width="139" height="321" border="0" id="About_r3_c1" alt="" /></td>
   <td colspan="4" 
          style="background-image: url('images/About_r3_c2.jpg'); background-repeat: no-repeat" 
          valign="top">
       <br />
       <br />
       <br />
       <br />
       <asp:Literal ID="ltlAbout" runat="server" onload="ltlAbout_Load"></asp:Literal>
      </td>
   <td><img name="About_r3_c6" src="images/About_r3_c6.jpg" width="116" height="321" border="0" id="About_r3_c6" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="321" border="0" alt="" /></td>
  </tr>
  <tr>
   <td rowspan="3" bgcolor="#F9F9F9">&nbsp;</td>
   <td height="434"  background="images/About_r4_c2.jpg"colspan="2" rowspan="3" 
          bgcolor="#F9F9F9" valign="top">
       <br />
       <br />
       <br />
       <br />
       <asp:Literal ID="ltlContact" runat="server" onload="ltlContact_Load"></asp:Literal>
      </td>
   <td colspan="3" bgcolor="#F9F9F9">&nbsp;</td>
   <td><img src="images/spacer.gif" width="1" height="110" border="0" alt="" /></td>
  </tr>
  <tr>
   <td height="270" colspan="3" bgcolor="#F9F9F9"><table width="100%%" border="0" cellspacing="0" cellpadding="0">
     <tr>
       <td align="left"><iframe width="507" height="269" frameborder="1" scrolling="no" 
               marginheight="0" marginwidth="0" 
               src="http://maps.google.com/?ie=UTF8&amp;ll=28.65832,115.807185&amp;spn=0.010017,0.021801&amp;z=15&amp;output=embed" 
               id="I1" name="I1"></iframe><br /><small><a href="http://maps.google.com/?ie=UTF8&amp;ll=28.65832,115.807185&amp;spn=0.010017,0.021801&amp;z=15&amp;source=embed" style="color:#0000FF;text-align:left"></small></td>
     </tr>
   </table></td>
   <td><img src="images/spacer.gif" width="1" height="270" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="3" bgcolor="#F9F9F9">&nbsp;</td>
   <td><img src="images/spacer.gif" width="1" height="54" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="6"><img name="About_r7_c1" src="images/About_r7_c1.jpg" width="1024" height="86" border="0" id="About_r7_c1" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="86" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="6"><img name="About_r14_c1" src="images/About_r14_c1.jpg" width="1024" height="74" border="0" id="About_r14_c1" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="74" border="0" alt="" /></td>
  </tr>
</table>
<map name="index_r1_c1Map" id="index_r1_c1Map">
  <area shape="rect" coords="903,103,982,140" href="AboutUs.aspx" />
  <area shape="rect" coords="796,103,875,140" href="http://www.ncu.edu.cn" />
  <area shape="rect" coords="697,104,776,141" href="members.aspx" />
  <area shape="rect" coords="596,102,675,139" href="Services.aspx" />
<area shape="rect" coords="493,102,572,139" href="LabNews.aspx" /><area shape="rect" coords="397,103,476,140" href="default.aspx" /></map>
    
    </div>
    </form>
</body>
</html>
