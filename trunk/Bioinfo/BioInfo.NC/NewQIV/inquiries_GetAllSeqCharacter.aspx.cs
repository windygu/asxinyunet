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
    public partial class inquiries_GetAllSeqCharacter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string output = "";

            string sequence = txtInput.Text;
            string waveName = this.txtWaveName.Text;

            double[][] testDataArray = ProteidCharacter.GetAllSeqCharacter(sequence, this.txtWaveName.Text);

            if (testDataArray.Length > 0)
            {
                int i = testDataArray.Length;
                int j = testDataArray[0].Length;

                double[,] testDataArray2 = new double[i, j];
                for (int tmpI = 0; tmpI < i; tmpI++)
                {
                    for (int tmpJ = 0; tmpJ < j; tmpJ++)
                    {
                        testDataArray2[tmpI, tmpJ] = testDataArray[tmpI][tmpJ];
                    }
                }
                
                //string testFilePath = @"C:\QIV\XLJ\enpred-svm.xls";
                string testFilePath = @"C:\QIV\XLJ\" + Request.QueryString["testFileName"];
                string testType = Request.QueryString["testType"];

                if (testType == "svm")
                {
                    output += "Error Rate: " + ProteidCharacter.SvmTest(testFilePath, testDataArray2,10,4).ToString();
                }
                else
                {
                    double[] classes = ProteidCharacter.KdTreeTest(testFilePath, testDataArray2);
                    output += "First Class: " + classes[0].ToString() + "<br />";
                    output += "Second Class: " + classes[1].ToString();
                }
            }
            output += "<br />";
            output += "<br />";

            string text = txtInput.Text;
            double[][] res = ProteidCharacter.GetAllSeqCharacter(text, this.txtWaveName.Text);

            output += FuncCommon.GetOutputTable(res);

            this.ltlResult.Text = output;
        }
    }
}
