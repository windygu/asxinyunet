using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using ProteidCalculate;

namespace WebUI
{
    public partial class inquiries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string text = txtInput.Text;
            double[][] res = ProteidCharacter.GetAllSeqCharacter(text, this.txtWaveName.Text);
            string output = "";

            for (int i = 0; i < res.Length; i++)
            {
                output += "第" + (i + 1).ToString() + "条结果：";
                for (int j = 0; j < res[i].Length; j++)
                {
                    output += res[i][j].ToString() + "   ";
                }
                output += "\r\n";
            }

            txtOutput.Text = output;
        }
    }
}
