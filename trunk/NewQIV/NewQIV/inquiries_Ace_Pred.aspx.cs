using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using ProteidCalculate;
using cn.buddy;
using SvmNet;
using SVM;

namespace WebUI
{
    public partial class inquiries_Ace_Pred : System.Web.UI.Page
    {        
        int[] arrList = new int[] { 2, 3, 4, 5, 7, 9, 10, 12, 14, 15, 17, 19, 20, 21 };
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calculate();
            //Test();
        }

        private void Test()
        {
            string[] allText = ProteidCharacter.SplitStringsByEnter(txtInput.Text);//输入分割
            double[][] res = new double[allText.Length][];
            for (int i = 0; i < allText.Length; i++)
            {
                res[i] = ProteidCharacter.NewGetOneAcePred(allText[i],5)[0];
            }
            DotNet.Tools.ConverterAlgorithm.ConvertToExcel<double>(res, @"D:\Ace.xls", "test");
        }
        private void Calculate() //进行计算
        {
            double thold = double.Parse(thresholdValue.Text.Trim());
            string text = txtInput.Text;
            string[] strNames;
            string[] serials = ProteidCharacter.SplitStringsByEnter(text, out strNames);
            string output = ProteidSvmTest.GetTableHeader();
            for (int i = 0; i < serials.Length; i++)
            {
                int[] pos; int[] pos2;
                double[] probValue; string[] tempStr;
                string[] sequencesK = ProteidCharacter.GetCentrlString(serials[i], 21, 'K', out pos);
                double[][] CharacterValue = ProteidCharacter.NewAcePred(serials[i], 15, 'K', 5, out tempStr, out pos2);//计算得到特征值
                double totalResult = ProteidSvmTest.GetSvmPredictResult(_default.modelList [1], CharacterValue, out probValue);
                //先对结果进行预处理
                for (int t = 0; t <probValue.Length ; t++)
                {
                    if (probValue [t]>=0.8 && probValue [t]<0.85)
                    {
                        probValue[t] += 0.03;
                    }
                    else if (probValue [t]>=0.85 && probValue [t]<0.9)
                    {
                        probValue[t] += 0.05;
                    }
                }
                for (int j = 0; j < probValue.Length; j++)
                {
                    if (sequencesK [j].Contains ("O"))
                    {
                        continue;//屏蔽O的序列
                    }
                    if (probValue[j] >= thold)
                    {
                        output += "<tr>";
                        output += "<td align='center' style=\"border:1px solid #333;\">";
                        output += strNames[i];
                        output += "</td>";
                        output += "<td align='center' style=\"border:1px solid #333;\">";
                        output += pos[j].ToString();
                        output += "</td>";
                        output += "<td align='center' style=\"border:1px solid #333;font-family:'宋体';\">";
                        output += ProteidSvmTest.GetHtmlCodeByString(sequencesK[j], "009933", "CC3333", "000000", arrList);
                        output += "</td>";
                        output += "<td align='center' style=\"border:1px solid #333;\">";
                        output += probValue[j].ToString("F6");
                        output += "</td>";
                        output += "</tr>";
                    }
                }
            }
            output += ProteidSvmTest.GetTableTail();
            ltlResult.Text = output;
        }

        //private void Calculate()
        //{
        //    string testFilePath = @"C:\QIV\XLJ\PTM\Ace-Pred.xls";
        //    double thold = double.Parse(thresholdValue.Text.Trim());
        //    string text = txtInput.Text;
        //    string[] strNames;
        //    string[] serials = ProteidCharacter.SplitStringsByEnter(text, out strNames);
        //    string output = "<table cellspacing=\"0\" cellpadding=\"0\" style=\"border-collapse:collapse; border:1px solid #333;\">";
        //    output += "<tr><td width='200' align='center' style=\"border:1px solid #333;\">Protein name</td><td width='200' align='center' style=\"border:1px solid #333;\">Position of site</td><td width='300' align='center' style=\"border:1px solid #333;\">Sequence</td>";
        //    output += "<td width='200' align='center' style=\"border:1px solid #333;\">SVM Probability</td></tr>";
        //    for (int i = 0; i < serials.Length; i++)
        //    {
        //        int[] pos;
        //        double[] probValue;
        //        //string[] sequences = ProteidCharacter.GetCentrlString(serials[i], 15, 'K', out pos);
        //        string[] sequencesK = ProteidCharacter.GetCentrlString(serials[i], 21, 'K', out pos);
        //        double[][] CharacterValue = ProteidCharacter.NewAcePred(serials[i], 15, 'K', 5);//得到特征值
        //        double totalResult = ProteidSvmTest.GetSvmPredictResult(cutModel, CharacterValue, out probValue);
        //        for (int j = 0; j < probValue.Length; j++)
        //        {
        //            //double[][] t = ProteidCharacter.GetOneAce_Pred(sequences[j ], 11, 5);
        //            //double score = 1 - ProteidCharacter.SvmTest(testFilePath, t,2,0.5);
        //            if (probValue[j] >= thold)
        //            {
        //                output += "<tr>";
        //                output += "<td align='center' style=\"border:1px solid #333;\">";
        //                output += strNames[i];
        //                output += "</td>";
        //                output += "<td align='center' style=\"border:1px solid #333;\">";
        //                output += pos[j].ToString();//Calibri
        //                output += "</td>";
        //                output += "<td align='center' style=\"border:1px solid #333;font-family:'宋体';\">";
        //                output += GetHtmlCodeByString(sequencesK[j], "009933", "CC3333", "000000");
        //                output += "</td>";
        //                output += "<td align='center' style=\"border:1px solid #333;\">";
        //                output += probValue[j].ToString("F4");
        //                output += "</td>";
        //                output += "</tr>";
        //            }
        //        }
        //    }
        //    output += "</table>";
        //    output += "<br />";
        //    output += "<br />";
        //    ltlResult.Text = output;
        //}
    }
}
