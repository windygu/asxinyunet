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
    public partial class inquiries_GetAllWaccAndACFvalue : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            thresholdValue.SelectedIndex = 1;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Calculate();          
        }
        void test ()
        {
            string[] allText = ProteidCharacter.SplitStringsByEnter(txtInput.Text);//输入分割
            double[][] res = new double[allText.Length][];
            for (int i = 0; i < allText.Length; i++)
            {
                res[i] = ProteidCharacter.GetOneWaccAndACFvalue (allText[i], 8);
            }
            DotNet.Tools.ConverterAlgorithm.ConvertToExcel<double>(res, @"D:\WSM-Plam.xls", "test");
        }
        private void Calculate()
        {
            double thold = double.Parse(thresholdValue.Text.Trim());
            string text = txtInput.Text;
            string[] strNames;
            string[] serials = ProteidCharacter.SplitStringsByEnter(text, out strNames);
            string output = ProteidSvmTest.GetTableHeader();
            for (int i = 0; i < serials.Length; i++)
            {
                int[] pos;
                string[] sequences;
                double[] probValue;
                double[][] CharacterValue = ProteidCharacter.NewGetAllWaccAndACFvalue(text, 19, 'C', 8, out sequences, out pos);
                double totalResult = ProteidSvmTest.GetSvmPredictResult(_default.modelList[1], CharacterValue, out probValue);
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
    }       
}