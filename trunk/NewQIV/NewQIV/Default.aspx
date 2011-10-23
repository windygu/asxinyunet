<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs"  Inherits="WebUI._default"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Home</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
body {
	margin-top: 0px;
	margin-bottom: 0px;
}
</style>
</head>
<body style="background-color:#8c8c8c">
    <form id="form1" runat="server">
    <div>
    
<table width="1024" border="0" align="center" cellpadding="0" cellspacing="0" style="display: inline-table; background-color:#FFFFFF;">
<!-- fwtable fwsrc="未命名" fwpage="页面 1" fwbase="index.jpg" fwstyle="Dreamweaver" fwdocid = "1356389920" fwnested="0" -->
  <tr>
   <td><img src="images/spacer.gif" width="139" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="694" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="191" height="1" border="0" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="1" border="0" alt="" /></td>
  </tr>

  <tr>
   <td colspan="3"><img src="images/index_r1_c1.jpg" alt="" name="index_r1_c1" width="1024" height="178" border="0" usemap="#index_r1_c1Map" id="index_r1_c1" /></td>
   <td><img src="images/spacer.gif" width="1" height="178" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="3"><img name="index_r2_c1" src="images/index_r2_c1.jpg" width="1024" height="30" border="0" id="index_r2_c1" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="30" border="0" alt="" /></td>
  </tr>
  <tr>
   <td><img name="index_r3_c1" src="images/index_r3_c1.jpg" width="139" height="314" border="0" id="index_r3_c1" alt="" /></td>
   <td style="background-image: url('images/index_r3_c2.jpg'); background-repeat: no-repeat" 
          valign="top">
       <br />
       <br />
       <br />
       <br />
       <asp:Literal ID="ltlAboutUs" runat="server" onload="ltlAboutUs_Load"></asp:Literal>
      </td>
   <td><img name="index_r3_c3" src="images/index_r3_c3.jpg" width="191" height="314" border="0" id="index_r3_c3" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="314" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="3"><img name="index_r4_c1" src="images/index_r4_c1.jpg" width="1024" height="59" border="0" id="index_r4_c1" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="59" border="0" alt="" /></td>
  </tr>
  <tr>
   <td height="306" colspan="3" bgcolor="#F9F9F9"><table width="800"  height="200" border="0" align="center" cellpadding="0" cellspacing="0">
     <tr>
       <td>
        <div id=demo style="overflow:hidden;height:200px;width:800px;"><table align=left 
cellpadding=0 cellspace=0 border=0><tr><td id=demo1 valign=top><img src="images/a1.jpg" ><img 
src="images/a2.jpg"><img src="images/a3.jpg"><img src="images/a4.jpg"><img src="images/a5.jpg"><img 
src="images/a6.jpg"></td><td id=demo2 valign=top></td></tr></table></div> 
  
<script> 
var speed=30 
demo2.innerHTML=demo1.innerHTML 
function Marquee(){ 
if(demo2.offsetWidth-demo.scrollLeft<=0) 
demo.scrollLeft-=demo1.offsetWidth 
else{ 
demo.scrollLeft++ 
} 
} 
var MyMar=setInterval(Marquee,speed) 
demo.onmouseover=function() {clearInterval(MyMar)} 
demo.onmouseout=function() {MyMar=setInterval(Marquee,speed)} 
</script>
       </td>
     </tr>
   </table></td>
   <td><img src="images/spacer.gif" width="1" height="306" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="3"><img name="index_r6_c1" src="images/index_r6_c1.jpg" width="1024" height="72" border="0" id="index_r6_c1" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="72" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="3"><img name="index_r7_c1" src="images/index_r7_c1.jpg" width="1024" height="86" border="0" id="index_r7_c1" alt="" /></td>
   <td><img src="images/spacer.gif" width="1" height="86" border="0" alt="" /></td>
  </tr>
  <tr>
   <td colspan="3"><img name="index_r8_c1" src="images/index_r8_c1.jpg" width="1024" height="74" border="0" id="index_r8_c1" alt="" /></td>
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
