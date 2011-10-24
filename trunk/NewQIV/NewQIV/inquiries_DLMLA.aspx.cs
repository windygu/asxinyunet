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
    public partial class inquiries_DLMLA : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Test();//计算特征值      M 4 A 5      
            //if (rdbA.Checked)
            //{
            //    Calculate(_default.modelList[5], "acetyllysine");
            //}
            //else if (rdbM.Checked)
            //{
            //    Calculate(_default.modelList[4], "methylated lysine");
            //}
            //else if (rdbMA.Checked)
            //{
            //    CalculateMA();
            //}
        }

        private void Calculate(Model model,string name)
        {
            //  double[][] t = ProteidCharacter.GetOneDLMLA(sequences[j], 13, 5);
            double thold = double.Parse(thresholdValue.Text.Trim());
            string[] strNames;
            string[] serials = ProteidCharacter.SplitStringsByEnter(txtInput.Text, out strNames);
            string output = ProteidSvmTest.GetTableHeaderOfAddOne();
            for (int i = 0; i < serials.Length; i++)
            {
                int[] pos;              
                string[] sequences;
                double[] probValue;
                double[][] CharacterValue = ProteidCharacter.NewDLMLA (serials[i], 13, 'K', 5,out sequences, out pos);
                double totalResult = ProteidSvmTest.GetSvmPredictResult(model, CharacterValue, out probValue);
                for (int j = 0; j < probValue.Length; j++)
                {
                    if (probValue[j] >= thold)
                    {
                        output += ProteidSvmTest.GetHtmlResultDisplayCode(strNames[i], pos[j].ToString(),
                            sequences[j], probValue[j].ToString("F6"), "330099", name);
                    }
                }
            }
            output += ProteidSvmTest.GetTableTail();
            ltlResult.Text = output;
        }

        private void CalculateMA()
        { // M-K,R-A
            double thold = double.Parse(thresholdValue.Text.Trim());
            string[] strNames;//序列的名称
            string[] serials = ProteidCharacter.SplitStringsByEnter(txtInput.Text, out strNames);
            string output = ProteidSvmTest.GetTableHeader();
            for (int i = 0; i < serials.Length; i++)
            {
                int[] posK;//目标字符串所在在位置
                string[] sequencesK;//截取的子序列
                double[] probValueK;//概率值
                double[][] CharacterValueK = ProteidCharacter.NewDLMLA(serials[i], 13, 'K',5, out sequencesK, out posK);
                double totalResultK = ProteidSvmTest.GetSvmPredictResult(_default.modelList[4], CharacterValueK, out probValueK);
                //同时计算R
                int[] posR;//目标字符串所在在位置
                string[] sequencesR;//截取的子序列
                double[] probValueR;//概率值
                double[][] CharacterValueR = ProteidCharacter.NewDLMLA(serials[i], 15, 'K',5, out sequencesR, out posR);
                double totalResultR = ProteidSvmTest.GetSvmPredictResult(_default.modelList[5], CharacterValueR, out probValueR);

                //先对结果进行过滤，然后排序
                List<int> cutOutput = new List<int>();
                Dictionary<int, string> dic = new Dictionary<int, string>();
                for (int j = 0; j < probValueK.Length; j++)
                {
                    if (probValueK[j] >= thold)
                    {
                        string temp = ProteidSvmTest.GetHtmlResultDisplayCode(strNames[i], posK[j].ToString(),
                           sequencesK[j], probValueK[j].ToString("F6"), "330099", "methylated lysine");
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
                         sequencesR[j], probValueR[j].ToString("F6"), "009933", "acetyllysine");
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

        void Test()
        {
            //计算特征值
            string[] allText = ProteidCharacter.SplitStringsByEnter(txtInput.Text);//输入分割
            double[][] res = new double[allText.Length][];
            for (int i = 0; i < allText.Length; i++)
            {
                res[i] = ProteidCharacter.GetOneDLMLA (allText[i], 13, 5)[0];
            }
            DotNet.Tools.ConverterAlgorithm.ConvertToExcel<double>(res, @"D:\DLMLA.xls", "test");
        }
    }
}