<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inquiries_Ace_Pred.aspx.cs" Inherits="WebUI.inquiries_Ace_Pred" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ace_Pred</title>
    <style type="text/css">
        .style1
        {
            height: 19px;
            text-align: left;
        }

p.p0{
margin:0pt;
text-align:center;
font-size:10.5000pt; font-family:'宋体'; }
        .style3
        {
            font-size: large;
        }
        .style4
        {
            font-size: 16pt;
            text-align: center;
            font-weight: bold;
            font-family: "Times New Roman", Times, serif;
        }
        .style5
        {
            font-size: 16pt;
            font-weight: bold;
            font-family: "Times New Roman", Times, serif;
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
                    <td class="style4"><font size="4pt">
                        <p class="p0" style="margin-bottom: 0pt; margin-top: 0pt; text-align: center;">
                            <span class="style5" style="mso-spacerun: 'yes'; ">
                            Combining&nbsp;information-entropy&nbsp;and&nbsp;multi-feature&nbsp;to
                            </span><span class="style3" style="mso-spacerun: 'yes'; font-family: '宋体';">
                            <span class="style5" 
                                style="mso-spacerun: 'yes'; ">identify</span></span><span 
                                class="style5" style="mso-spacerun: 'yes'; ">&nbsp;protein</span></p>
                        </font></td>
                  </tr>
                  <tr>
                    <td class="style4">
                        <p class="p0">
                            <span class="style5" style="mso-spacerun: 'yes'; ">
                            &nbsp;&nbsp;lysine&nbsp;acetylation&nbsp;sites&nbsp;on&nbsp;the&nbsp;basis&nbsp;of&nbsp;their&nbsp;sequences</span><span 
                                style="mso-spacerun:'yes'; font-weight:bold; font-size:14.0000pt; font-family:'宋体'; "><o:p></o:p></span></p>
                      </td>
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
                            <tr><td colspan="2" align="center">Input the sequences in Fasta format: (ces in Fasta format: (<a 
                                    href="ooo/Ace-Pred.html" target="_new">Example</a>):</td></tr>
                            <tr>
                                <td style="width:200px" align="right">&nbsp;</td>
                                <td align="left">
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Sequence:</td>
                                <td align="left">                                    
                                    <asp:TextBox ID="txtInput" runat="server" Height="192px" TextMode="MultiLine" Width="700px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">&nbsp;</td>
                                <td align="left">                                    
                                    <asp:Button ID="Button1" 
                                        runat="server" onclick="Button1_Click" Text="Submit" Width="63px" 
                                        style="height: 26px" Height="26px" /></td>
                                                      </tr>
                            <tr>                                
                                <td align="left" valign="top" class="style1">
                                    <p class="p0" style="text-align: right; font-size: medium;">
                                        <span style="mso-spacerun:'yes'; font-family:'宋体'; ">T</span><span 
                                            style="mso-spacerun: 'yes'; font-family: 'Calibri'; text-align: right;">hreshold:</span></p>
                                                          </td>
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
        </td>
      </tr>
      <tr>
        <td class="style1">
            <br />
            <br />
            Window size -7 to +7 is employed to consturct the prediction&nbsp; model&nbsp; 
            PMeS. Users can submit&nbsp; one or&nbsp; multiple human or other species 
            protein sequences in FASTA format to the system and select which type of 
            residues (R or K) need to be predicted.The system efficiently returns the 
            predictions,including protein name,the position of site, flanking amino acids 
            and predicted result.</td>
      </tr>
      <tr>
        <td><br />
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
