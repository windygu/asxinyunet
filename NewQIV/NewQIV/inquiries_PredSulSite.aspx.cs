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
    public partial class inquiries_PredSulSite : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            thresholdValue.SelectedIndex = 1;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Test();//得到特征值
            Calcute();//预测计算            
        }

        //SVM预测计算
        private void Calcute()
        {  
            double thold = double.Parse(thresholdValue.Text.Trim());
            string[] strNames;
            string[] serials = ProteidCharacter.SplitStringsByEnter(txtInput.Text, out strNames);
            string output = ProteidSvmTest.GetTableHeader();
            for (int i = 0; i < serials.Length; i++)
            {
                int[] pos;                //NewPredSulSiteForOneSeq
                string[] sequences  ;//= ProteidCharacter.GetCentrlString(serials[i], 9, 'Y', out pos);
                double[] probValue;
                double[][] CharacterValue = ProteidCharacter.NewPredSulSiteForOneSeq(serials[i], 9, 'Y', 5, 
                    out sequences,out pos);
                double totalResult = ProteidSvmTest.GetSvmPredictResult(_default.modelList[6], CharacterValue, out probValue);
                for (int j = 0; j <probValue.Length ;j ++)
                {
                    if (sequences[j].Contains("O"))
                    {
                        continue;//屏蔽O的序列
                    }
                    if (probValue[j] >= thold) {
                        output += ProteidSvmTest.GetHtmlResultDisplayCode(strNames[i], pos[j].ToString(), 
                            sequences[j], probValue[j].ToString("F6"));
                    }
                }
            }
            output += ProteidSvmTest.GetTableTail();
            ltlResult.Text = output;
        }

        //计算特征值并存到Excel中       
        private void Test()
        {
            string[] allText = ProteidCharacter.SplitStringsByEnter(txtInput.Text);//输入分割
            double[][] res = new double[allText.Length][];
            for (int i = 0; i < allText.Length; i++)
            {
                res[i ] = ProteidCharacter.GetOnePredSulsite(allText [i ] , 9 , 5)[0];
            }
            DotNet.Tools.ConverterAlgorithm.ConvertToExcel<double>(res,  @"D:\PredSulSite.xls", "test");
        }      
    }
}