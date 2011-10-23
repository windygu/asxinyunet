<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inquiries2.aspx.cs" Inherits="WebUI.inquiries2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>inquiries2</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
body {
	background-color: #999;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
	  <div align="center">
      <img src="images/index_r1_c1.jpg" alt="" name="index_r1_c1" width="1024" height="178" border="0" usemap="#index_r1_c1Map" id="index_r1_c1" />
      <map name="index_r1_c1Map" id="index_r1_c1Map">
        <area shape="rect" coords="903,103,982,140" href="AboutUs.aspx" />
        <area shape="rect" coords="796,103,875,140" href="http://www.ncu.edu.cn" />
        <area shape="rect" coords="697,104,776,141" href="members.aspx" />
        <area shape="rect" coords="596,102,675,139" href="Services.aspx" />
        <area shape="rect" coords="493,102,572,139" href="LabNews.aspx" />
        <area shape="rect" coords="397,103,476,140" href="default.aspx" />
      </map>
	  
    <table width="1024" bgcolor="#F0F8FF" style="border-left:1px solid #808080;border-right:1px solid #808080" cellspacing="0" cellpadding="0">
      <tr>
        <td bgcolor="#DFF0FF" style="border-bottom:1px solid #A1A1A1" height="80"><table>
            <tr>
              <td><table width="1000">
                  <tr>
                    <th rowspan="2"><font size="+2">BIOINFO: </font> </th>
                    <td align="left"><font size="4pt">Prediction of protein modification sites
 </font></td>
                  </tr>
                  <tr>
                    <td align="left">&nbsp;</td>
                  </tr>
              </table></td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td valign="top" align="center"><table width="1000" cellspacing="0" cellpadding="0">
            <tr>
              <td height="25" style="border-left:1px #A1A1A1"></td>
            </tr>
            <tr>
              <td height="280" style="border:1px solid #A1A1A1"><table width="100%" cellspacing="0" cellpadding="12" bgcolor="#DFF0FF">
                  <input type="hidden" name="mode" value="string" />
                  <tr>
                    <td height="20" align="right">
                        <div style="text-align:center;">Input the sequences in Fasta format: (<a href="ooo/example.html" target="_new">Example</a>):&nbsp;<br /></div>
                        Window length:
                        <asp:TextBox ID="txtStrLength" runat="server" Width="800px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvStrLength" runat="server" 
                            ControlToValidate="txtStrLength" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtStrLength" Display="Dynamic" 
                            ErrorMessage="Require An Integer" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        <br />
                        Predictive site:
                        <asp:TextBox ID="txtDestChar" runat="server" Width="800px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDestChar" runat="server" 
                            ControlToValidate="txtDestChar" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtDestChar" Display="Dynamic" 
                            ErrorMessage="Require A Character" ValidationExpression="\w{1}"></asp:RegularExpressionValidator>
                      </td>
                  </tr>
                  <tr>
                    <td style="padding-top:0px" align="right">
                        Sequence:
                        <asp:TextBox ID="txtInput" runat="server" Height="192px" TextMode="MultiLine" 
            Width="800px"></asp:TextBox>
                      </td>
                  </tr>
                  <tr>
                    <td align="center">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
            Width="63px" />
    &nbsp;</td>
                  </tr>
                  <tr>
                    <td align="right">Output:
        <asp:TextBox ID="txtOutput" runat="server" Height="149px" Width="800px" TextMode="MultiLine"></asp:TextBox>
                      </td>
                  </tr>
              </table></td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td>&nbsp;&nbsp;</td>
      </tr>
      <tr>
        <td align="left"><br />
          <br />
          <br />
        </td>
      </tr>
      <tr>
        <td></td>
      </tr>
    </table>
	</div>
    </form>
</body>
</html>
