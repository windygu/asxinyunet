<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inquiries_GetAllSeqCharacter.aspx.cs" Inherits="WebUI.inquiries_GetAllSeqCharacter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>GetAllSeqCharacter</title>
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
                    <th rowspan="2"><font size="+2">BIOINFO: </font> </th>
                    <td><font size="4pt">Predictionof proteins structure and types</font></td>
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
                  <tr>
                    <td height="20" align="right">
                        <table 
                                style="width:100%;">
                            <tr>
                                <td colspan="2" align="center"><span style="text-align:center;">Input the sequences in Fasta format: (<a href="ooo/example.html" target="_new">Example</a>):&nbsp;</span></td>
                            </tr>
                            <tr>
                                <td style="width:100px" align="right">
                        Wavelet name:</td>
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
        <td><br />
            <b>Reference</b>:<br />
          <br />
          <p>1. J. D. Qiu, X.Y. Sun, J. H. Huang, R. P. Liang, Prediction of the types of membrane proteins based on discrete wavelet transform and support vector machines, Protein J. 29 (2010b) 114-119.<br />
            2. J. D. Qiu, J. H. Huang, R. P. Liang, X. Q. Lu, Prediction of G-protein-coupled receptor classes based on the concept of Chou's pseudo amino acid composition: An approach from discrete wavelet transform, Anal Biochem. 390 (2009b) 68-73.<br />
            3. Shaoping Shi, Jianding Qiu*, Xingyu Sun, Jianhua Huang, Shuyun Huang, Shengbao Suo, Ruping Liang, Li Zhang. Identify submitochondria and subchloroplast locations with pseudo amino acid composition: approach from the strategy of discrete wavelet transform feature extraction, BBA - Molecular Cell Research, 2011, 1813: 424-430. <br />
            4. J. D. Qiu , S. H. Luo , J. H. Huang , X. Y. Sun , R. P. Liang , Predicting subcellular location of apoptosis proteins based on wavelet transform and support vector machine, Amino Acids 38 (2010c) 1201-1208.<br />
            5. J. D. Qiu, S. H. Luo, J. H. Huang, R.P. Liang, Using support vector machines to distinguish enzymes: approached by incorporating wavelet transform, J Theor Biol. 256 (2009c) 625-631.<br />
            6. J. D. Qiu, J. H. Huang, S. P. Shi, R. P. Liang, Using the concept of Chou's pseudo amino acid composition to predict enzyme family classes: an approach with support vector machine based on discrete wavelet transform, Protein Peptide Lett. 17 (2010a) 715-722.<br />
            7. J. D. Qiu, S. H. Luo, J. H. Huang, R. P. Liang, Using support vector machines for prediction of protein structural classes based on discrete wavelet transform, J. Comput Chem. 30 (2009a) 1344-1350.<br />
            <br />
          </p>
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
