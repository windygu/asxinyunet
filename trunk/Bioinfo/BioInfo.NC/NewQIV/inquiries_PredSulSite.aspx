﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inquiries_PredSulSite.aspx.cs" Inherits="WebUI.inquiries_PredSulSite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PredSulSite</title>
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
            height: 18px;
        }
        .style4
        {
            font-size: medium;
        }
        .style5
        {
            font-size: x-large;
        }
        .style6
        {
            font-size: 16pt;
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
                    <th><font size="+2">
                        <span style="mso-spacerun: 'yes'; font-weight: bold; font-family: 'Times New Roman';">
                        PredSulSite</span>: </font> </th>
                    <td class="style4">
                        <p class="p0" style="margin-bottom: 0pt; margin-top: 0pt; text-align: center;">
                            <span class="style5" 
                                style="mso-spacerun: 'yes'; font-weight: bold; font-family: 'Times New Roman';">
                            &nbsp;</span><span class="style6" 
                                
                                style="mso-spacerun: 'yes'; font-weight: bold; font-family: 'Times New Roman'; text-align: center;">Prediction&nbsp;of&nbsp;tyrosine&nbsp;sulfation&nbsp;sites&nbsp;with&nbsp;multiple&nbsp;features&nbsp;and&nbsp;analysis<o:p></o:p></span></p>
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
                            <tr><td colspan="2" align="center">Input the sequences in Fasta format: (s in Fasta format: (<a 
                                    href="ooo/SulSite.html" target="_new">Example</a>):</td></tr>
                            <tr>
                                <td style="width:200px" align="right">&nbsp;</td>
                                <td align="left">
                &nbsp;</td>
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
        </td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td style="text-align: left">Window size -4 to +4 is employed in the prediction 
            model PredSulSite. Users can submit their uncharacterized protein sequences in 
            FASTA format. The predictions are presented in a diagram that includes protein 
            name, the position of site, flanking amino acids and SVM Probability. <br />
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
