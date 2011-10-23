using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using ProteidCalculate;
using cn.buddy;

namespace WebUI
{
    public partial class Ace_Pred : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //SVM.NET类库的测试
        void SvmTest()
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            #region
            string testFilePath = @"C:\QIV\XLJ\PTM\Ace-Pred.xls";
            double thold = 0.9999;

            string text = txtInput.Text;
            string[] strNames;
            string[] serials = ProteidCharacter.SplitStringsByEnter(text, out strNames);
            string output = "<table cellspacing=\"0\" cellpadding=\"0\" style=\"border-collapse:collapse; border:1px solid #333;\">";
            output += "<tr><td width='200' align='center' style=\"border:1px solid #333;\">Protein</td><td width='200' align='center' style=\"border:1px solid #333;\">Position of site</td><td width='300' align='center' style=\"border:1px solid #333;\">Sequence</td>";
            output += "<td width='200' align='center' style=\"border:1px solid #333;\">Predicted Result</td></tr>";
            for (int i = 0; i < serials.Length; i++)
            {
                int[] pos;
                string[] sequences = ProteidCharacter.GetCentrlString(serials[i], 11, Convert.ToChar(this.txtDestChar.Text), out pos);// Convert.ToInt32(this.txtStrLength.Text)
                for (int j = 0; j < sequences.Length; j++)
                {
                    double[][] t = ProteidCharacter.GetOneAce_Pred(sequences[j], 11, 5);
                    double score = 1 - ProteidCharacter.SvmTest(testFilePath, t, 2, 0.5);
                    //if ((score >= thold) && (score < 1.1))
                    //{
                    output += "<tr>";
                    output += "<td align='center' style=\"border:1px solid #333;\">";
                    output += strNames[i];
                    output += "</td>";
                    output += "<td align='center' style=\"border:1px solid #333;\">";
                    output += pos[j].ToString();
                    output += "</td>";
                    output += "<td align='center' style=\"border:1px solid #333;\">";
                    output += ProteidCharacter.GetHtmlCodeByString(sequences[j], "330099");
                    output += "</td>";
                    output += "<td align='center' style=\"border:1px solid #333;\">";
                    output += "Predicted Site"; //score.ToString();
                    output += "</td>";
                    output += "</tr>";
                    //}
                }
            }
            output += "</table>";
            output += "<br />";
            output += "<br />";
            ltlResult.Text = output;
            #endregion

            #region
            //string testFilePath = @"C:\QIV\XLJ\PTM\DLMLA.xls";
            // double thold = 0.9999;
            //     string text = txtInput.Text;
            //     string[] strNames;
            //     string[] serials = ProteidCharacter.SplitStringsByEnter(text, out strNames);

            //     string output = "<table cellspacing=\"0\" cellpadding=\"0\" style=\"border-collapse:collapse; border:1px solid #333;\">";
            //     output += "<tr><td width='200' align='center' style=\"border:1px solid #333;\">Protein</td><td width='200' align='center' style=\"border:1px solid #333;\">Position of site</td><td width='300' align='center' style=\"border:1px solid #333;\">Sequence</td>";
            //     output += "<td width='200' align='center' style=\"border:1px solid #333;\">Predicted Result</td></tr>";
            //     for (int i = 0; i < serials.Length; i++)
            //     {
            //         int[] pos;
            //         string[] sequences = ProteidCharacter.GetCentrlString(serials[i],13, Convert.ToChar(this.txtDestChar.Text), out pos);//Convert.ToInt32(this.txtStrLength.Text)
            //         for (int j = 0; j < sequences.Length; j++)
            //         {
            //             double[][] t = ProteidCharacter.GetOneDLMLA(sequences[j ],13, 5);
            //             double score = 1 - ProteidCharacter.SvmTest(testFilePath, t, 8192, 0.00048828125);
            //             if ((score >= thold)&&(score <1.1))
            //             {
            //                 output += "<tr>";
            //                 output += "<td align='center' style=\"border:1px solid #333;\">";
            //                 output += strNames[i]; //output += (i + 1).ToString();
            //                 output += "</td>";
            //                 output += "<td align='center' style=\"border:1px solid #333;\">";
            //                 output += pos[j].ToString();
            //                 output += "</td>";
            //                 output += "<td align='center' style=\"border:1px solid #333;\">";
            //                 output += ProteidCharacter.GetHtmlCodeByString(sequences[j], "330099"); //output += sequences[j].ToString();
            //                 output += "</td>";
            //                 output += "<td align='center' style=\"border:1px solid #333;\">";
            //                 output += "Predicted Site";//score.ToString();//  sequences[j].ToString();
            //                 output += "</td>";
            //                 output += "</tr>";
            //             }
            //         }
            //     }
            //     output += "</table>";
            //     output += "<br />";
            //     output += "<br />";
            //     ltlResult.Text = output;
            #endregion 
        }
    }
}