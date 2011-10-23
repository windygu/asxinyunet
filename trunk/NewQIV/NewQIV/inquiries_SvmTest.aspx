<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inquiries_SvmTest.aspx.cs" Inherits="WebUI.inquiries_SvmTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SvmTest</title>
    <style type="text/css">
        .style1
        {
            height: 58px;
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
	  
      <table width="1024" bgcolor="#F0F8FF" style="border-left:1px solid #808080;border-right:1px solid #808080; text-align:left" cellspacing="0" cellpadding="0">
      <tr>
        <td bgcolor="#DFF0FF" style="border-bottom:1px solid #A1A1A1" height="80"><table>
            <tr>
              <td><table width="720">
                  <tr>
                    <th rowspan="2"><font size="+2">Euk-mPLoc: </font> </th>
                    <td><font size="4pt">Prediction of palmitoylation site based on multiple</font></td>
                  </tr>
                  <tr>
                    <td><font size="4pt"> feature extraction methods and multiple classifier algorithms</font></td>
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
                        <table 
                                style="width:100%;">
                            <tr>
                                <td colspan="2" align="center">
                                    Input the <strong>eukaryotic</strong> protein sequence in <b> Fasta </b> format:</td>
                            </tr>
                            <tr>
                                <td style="width:100px" align="right">
                        Wave Name:</td>
                                <td align="left">
                                    <asp:TextBox ID="txtWaveName" runat="server" Width="800px">bior2.4</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                        Sequence:</td>
                                <td align="left">
                        <asp:TextBox ID="txtInput" runat="server" Height="192px" TextMode="MultiLine" 
            Width="800px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style1">
                                </td>
                                <td align="left" valign="top" class="style1">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
            Width="63px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Output:</td>
                                <td align="left">
                                    <asp:Literal ID="ltlResult" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            </table>
                        &nbsp;</td>
                  </tr>
                  <tr>
                    <td align="right">&nbsp;</td>
                  </tr>
              </table></td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td>&nbsp;&nbsp;</td>
      </tr>
      <tr>
        <td><b><font color='red'>Euk-mPLoc server has been updated to 2.0 version, for the 2.0 version, access a href='http://www.csbio.sjtu.edu.cn/bioinf/euk-multi-2/'>http://www.csbio.sjtu.edu.cn/bioinf/euk-multi-2/</a></b>.<br />
            <br />
            <b>Reference</b>:<br />
          <br />
          Kuo-Chen Chou and Hong-Bin Shen, &quot;Cell-PLoc: A package of web-servers for predicting subcellular localization of proteins in various organisms&quot;, <i>Nature Protocols</i>, 2008, <b>3</b>, 153-162.<br />
          <br />
          Kuo-Chen Chou and Hong-Bin Shen, &quot;Euk-mPLoc: A fusion classifier for large-scale eukaryotic protein subcellular location prediction by incorporating multiple sites&quot;, <em>J Proteome Res.</em> 2007, <b>6</b>, 1728 -1734.<br />
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
