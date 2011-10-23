<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inquiries_GetGroupAttributeCode.aspx.cs" Inherits="WebUI.inquiries_GetGroupAttributeCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>GetGroupAttributeCode</title>
    <style type="text/css">


p.p0{
margin:0pt;
margin-bottom:0.0001pt;
margin-bottom:0pt;
margin-top:0pt;
text-align:justify;
font-size:10.5000pt; font-family:'Calibri'; }
        .style1
        {
            font-size: medium;
        }
        .style2
        {
            font-size: large;
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
                    <td>
                        <p class="p0" style="font-weight: bold; text-align: center">
                            &nbsp;</p>
                        <p class="p0" style="font-weight: bold; text-align: center">
                            &nbsp;</p>
                        <p class="p0" style="font-weight: bold; text-align: center">
                            <span style="mso-spacerun:'yes'; font-size:14.0000pt; font-family:'Calibri'; ">
                            PMeS:&nbsp;Prediction&nbsp;of&nbsp;methylation&nbsp;sites&nbsp;based&nbsp;on&nbsp;</span></p>
                        <p class="p0" style="font-weight: bold; text-align: center">
                            <span style="mso-spacerun:'yes'; font-size:14.0000pt; font-family:'Calibri'; ">
                            enhanced&nbsp;feature&nbsp;encoding&nbsp;scheme</span></p>
                      </td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
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
                  
                  <table width="100%" cellspacing="0" cellpadding="12" bgcolor="#DFF0FF">
                  <tr>
                    <td height="20" align="right">
                        <table style="width:100%;">
                            <tr><td colspan="2" align="center" class="style2"><span class="style2">Input the sequences in Fasta format: (</span><a 
                                    href="ooo/PMeS.html" target="_new"><span class="style2">Example</span></a><span 
                                    class="style2">):</span></td></tr>
                            <tr>
                                <td style="width:200px" align="right">&nbsp;</td>
                                <td align="left" class="style2">
                                    <p class="p0">
                                        <span class="style2" style="mso-spacerun: 'yes'; font-family: 'Calibri';">
                                        Please&nbsp;select&nbsp;which&nbsp;type&nbsp;of&nbsp;residues&nbsp;need&nbsp;to&nbsp;be&nbsp;predicted</span><span 
                                            class="style2" style="mso-spacerun: 'yes'; font-family: '宋体';">：</span></p>
                                    <span class="style1">
                                    <asp:RadioButton ID="rdbK" runat="server" Checked="True" Text="Lysine(K)" 
                                        GroupName="ab" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdbR" runat="server" Text="Arginine(R)" GroupName="ab" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton ID="rdbKR" runat="server" Text="Lysine(K) and Arginine(R)" 
                                        GroupName="ab" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Sequence:</td>
                                <td align="left">                                    
                                    <asp:TextBox ID="txtInput" runat="server" Height="192px" TextMode="MultiLine" Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">&nbsp;</td>
                                <td align="left" valign="top" class="style1"><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" Width="63px" /></td>
                            </tr>
                             <tr>
                                <td align="right">
                                        <span style="mso-spacerun:'yes'; font-family:'宋体'; ">T</span><span 
                                            style="mso-spacerun: 'yes'; font-family: 'Calibri'; text-align: right;">hreshold:</span></td>
                                <td align="left">                                    
                                                              <asp:DropDownList ID="thresholdValue" runat="server" Height="16px" Width="77px">
                                                                  <asp:ListItem Selected="True">0.5</asp:ListItem>
                                                                  <asp:ListItem>0.6</asp:ListItem>
                                                                  <asp:ListItem>0.7</asp:ListItem>
                                                                  <asp:ListItem>0.8</asp:ListItem>
                                                                  <asp:ListItem>0.9</asp:ListItem>
                                                              </asp:DropDownList>
                                                          </td>
                            </tr>
                            <tr>
                                <td align="right">Output:</td>
                                <td align="left"><asp:Literal ID="ltlResult" runat="server"></asp:Literal></td>
                            </tr>
                         </table>
                      </td>
                  </tr>
                  </table>
               </td>
            </tr>
      <tr>
        <td style="text-align: left">&nbsp;<br />
            <br />
            Window size -7 to +7 is employed to consturct the prediction&nbsp; model&nbsp; 
            PMeS. Users can submit&nbsp; one or&nbsp; multiple human or other species 
            protein sequences in FASTA format to the system and select which type of 
            residues (R or K) need to be predicted.The system efficiently returns the 
            predictions,including protein name,the position of site, flanking amino acids 
            and predicted result.</td>
      </tr>
      <tr>
        <td style="text-align: left">&nbsp;</td>
      </tr>
    </table>
	</div>
    </form>
</body>
</html>
