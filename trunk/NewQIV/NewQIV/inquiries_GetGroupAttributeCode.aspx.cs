using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using ProteidCalculate;
using cn.buddy;
using SVM;
using SvmNet;

namespace WebUI
{
    public partial class inquiries_GetGroupAttributeCode : System.Web.UI.Page
    {
        //Model cutModelK;
        //Model cutModelR;
        //string trainDataFileK = @"C:\DataSet\Ace-Pred-train.txt";
        //string trainDataFileR = @"C:\DataSet\Ace-Pred-train.txt";
        protected void Page_Load(object sender, EventArgs e)
        {
            //cutModelK = ProteidSvmTest.GetTrainingModel(trainDataFileK, 32768, 1);
            //cutModelR = ProteidSvmTest.GetTrainingModel(trainDataFileR, 32768, 1);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Test();
            if (rdbK.Checked)
            {
                CalculateK();
            }
            else if (rdbR.Checked)
            {
                CalculateR();
            }
            else if (rdbKR.Checked)
            {
                CalculateKR();
            }
            //R 2  k3
        }

        #region R
        /// <summary>
        /// 单独计算R时的预测值
        /// </summary>
        private void CalculateR()
        {
            double thold = double.Parse(thresholdValue.Text.Trim());
            string[] strNames;//序列的名称
            string[] serials = ProteidCharacter.SplitStringsByEnter(txtInput.Text, out strNames);
            string output = ProteidSvmTest.GetTableHeader();
            for (int i = 0; i < serials.Length; i++)
            {
                int[] pos;//目标字符串所在在位置
                string[] sequences;//截取的子序列 = ProteidCharacter.GetCentrlString(serials[i], 15, Convert.ToChar(testChar), out pos);
                double[] probValue;//概率值
                double[][] CharacterValue = ProteidCharacter.NewGetGroupAttributeCode(serials[i], 15, 'R', out sequences, out pos);
                double totalResult = ProteidSvmTest.GetSvmPredictResult(_default.modelList[2], CharacterValue, out probValue);
                for (int j = 0; j < probValue.Length; j++)
                {
                    if (probValue[j] >= thold)
                    {
                        output += ProteidSvmTest.GetHtmlResultDisplayCode(strNames[i], pos[j].ToString(),
                          sequences[j], probValue[j].ToString("F6"));
                    }
                }
            }
            output += ProteidSvmTest.GetTableTail();
            ltlResult.Text = output;
        }
        #endregion

        #region K
        /// <summary>
        /// 单独计算K时的预测值
        /// </summary>
        private void CalculateK()
        {
            double thold = double.Parse(thresholdValue.Text.Trim());
            string[] strNames;//序列的名称
            string[] serials = ProteidCharacter.SplitStringsByEnter(txtInput.Text, out strNames);
            string output = ProteidSvmTest.GetTableHeader();
            for (int i = 0; i < serials.Length; i++)
            {
                int[] pos;//目标字符串所在在位置
                string[] sequences;
                double[] probValue;//概率值
                double[][] CharacterValue = ProteidCharacter.NewGetGroupAttributeCode(serials[i], 15, 'K', out sequences, out pos);
                double totalResult = ProteidSvmTest.GetSvmPredictResult(_default.modelList[3], CharacterValue, out probValue);
                for (int j = 0; j < probValue.Length; j++)
                {
                    if (probValue[j] >= thold)
                    {
                        output += ProteidSvmTest.GetHtmlResultDisplayCode(strNames[i], pos[j].ToString(),
                           sequences[j], probValue[j].ToString("F6"));
                    }
                }
            }
            output += ProteidSvmTest.GetTableTail();
            ltlResult.Text = output;
        }
        #endregion

        #region R和K
        private void CalculateKR()
        {
            double thold = double.Parse(thresholdValue.Text.Trim());
            string[] strNames;//序列的名称
            string[] serials = ProteidCharacter.SplitStringsByEnter(txtInput.Text, out strNames);
            string output = ProteidSvmTest.GetTableHeader();
            for (int i = 0; i < serials.Length; i++)
            {
                int[] posK;//目标字符串所在在位置
                string[] sequencesK;//截取的子序列
                double[] probValueK;//概率值
                double[][] CharacterValueK = ProteidCharacter.NewGetGroupAttributeCode(serials[i], 15, 'K', out sequencesK, out posK);
                double totalResultK = ProteidSvmTest.GetSvmPredictResult(_default.modelList[3], CharacterValueK, out probValueK);
                //同时计算R
                int[] posR;//目标字符串所在在位置
                string[] sequencesR;//截取的子序列
                double[] probValueR;//概率值
                double[][] CharacterValueR = ProteidCharacter.NewGetGroupAttributeCode(serials[i], 15, 'R', out sequencesR, out posR);
                double totalResultR = ProteidSvmTest.GetSvmPredictResult(_default.modelList[2], CharacterValueR, out probValueR);

                //先对结果进行过滤，然后排序
                List<int> cutOutput = new List<int>();
                Dictionary<int, string> dic = new Dictionary<int, string>();
                for (int j = 0; j < probValueK.Length; j++)
                {
                    if (probValueK[j] >= thold)
                    {
                        string temp = ProteidSvmTest.GetHtmlResultDisplayCode(strNames[i], posK[j].ToString(),
                           sequencesK[j], probValueK[j].ToString("F6"));                        
                        cutOutput.Add(posK[j]);
                        dic.Add(posK[j], temp);
                    }
                }
                //
                for (int j = 0; j < probValueR.Length; j++)
                {
                    if (probValueR[j] >= thold)
                    {
                        string temp = ProteidSvmTest.GetHtmlResultDisplayCode(strNames[i], posR[j].ToString(),
                         sequencesR[j], probValueR[j].ToString("F6"), "009933");                        
                        cutOutput.Add(posR[j]);
                        dic.Add(posR[j], temp);
                    }
                }
                //对结果进行处理
                cutOutput.Sort();//先排序
                for (int r = 0; r < cutOutput.Count; r++)
                {
                    output += dic[cutOutput[r]];
                }
            }
            output += ProteidSvmTest.GetTableTail();
            ltlResult.Text = output;
        }
        #endregion

        #region 计算特征值
        private void Test()
        {
            string[] allText = ProteidCharacter.SplitStringsByEnter(txtInput.Text);//输入分割
            int[] len = new int[allText.Length];
            for (int i = 0; i < allText.Length ; i++)
            {
                len[i] = allText[i].Length;                
            }
            double[][] res = new double[allText.Length][];

            for (int i = 0; i < allText.Length; i++)
            {
                //if (!allText[i].Contains("APPGAKAGEKIFK"))
                //{
                    res[i] = ProteidCharacter.NewGetOneGroupAttribute(allText[i], 7);
                //}                
            }
            DotNet.Tools.ConverterAlgorithm.ConvertToExcel<double>(res, @"D:\PMeS-.xls", "test");
        }
        #endregion

        #region 废弃代码
        //private void Calculate()
        //{
        //    string testFilePath;
        //    double c, g;
        //    string testChar;
        //    if (rdbK.Checked)
        //    {
        //        testFilePath = @"C:\QIV\XLJ\PTM\PMES\K\PMES.xls";
        //        c = 1.0;
        //        g = 0.0035;
        //        testChar = "K";
        //    }
        //    else
        //    {
        //        testFilePath = @"C:\QIV\XLJ\PTM\PMES\R\PMES.xls";
        //        c = 8.0;
        //        g = 0.0078125;
        //        testChar = "R";
        //    }
        //    double thold = 0.999;
        //    string text = txtInput.Text;
        //    string[] strNames;
        //    string[] serials = ProteidCharacter.SplitStringsByEnter(text, out strNames);

        //    string output = "<table cellspacing=\"0\" cellpadding=\"0\" style=\"border-collapse:collapse; border:1px solid #333;\">";
        //    output += "<tr><td width='200' align='center' style=\"border:1px solid #333;\">Protein</td><td width='200' align='center' style=\"border:1px solid #333;\">Position of site</td><td width='300' align='center' style=\"border:1px solid #333;\">Sequence</td>";
        //    output += "<td width='200' align='center' style=\"border:1px solid #333;\">Predicted Result</td></tr>";
        //    for (int i = 0; i < serials.Length; i++)
        //    {
        //        int[] pos;
        //        string[] sequences = ProteidCharacter.GetCentrlString(serials[i], 15, Convert.ToChar(testChar), out pos);
        //        for (int j = 0; j < sequences.Length; j++)
        //        {
        //            double[][] t = ProteidCharacter.GetOneGroupAttribute(sequences[j], 7);
        //            double score = 1 - ProteidCharacter.SvmTest(testFilePath, t, c, g);
        //            if ((score >= thold) && (score < 1.1))
        //            {
        //                output += "<tr>";
        //                output += "<td align='center' style=\"border:1px solid #333;\">";
        //                output += strNames[i];
        //                output += "</td>";
        //                output += "<td align='center' style=\"border:1px solid #333;\">";
        //                output += pos[j].ToString();
        //                output += "</td>";
        //                output += "<td align='center' style=\"border:1px solid #333;\">";
        //                output += ProteidCharacter.GetHtmlCodeByString(sequences[j], "330099");
        //                output += "</td>";
        //                output += "<td align='center' style=\"border:1px solid #333;\">";
        //                output += "Predicted Site";// score.ToString();
        //                output += "</td>";
        //                output += "</tr>";
        //            }
        //        }
        //    }
        //    output += "</table>";
        //    output += "<br />";
        //    ltlResult.Text = output;
        //}
        #endregion
    }
}
