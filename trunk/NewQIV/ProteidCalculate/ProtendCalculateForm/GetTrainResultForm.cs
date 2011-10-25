using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Text;
using ProteidCalculate;
using System.Windows.Forms;

namespace ProtendCalculateForm
{
    public partial class GetTrainResultForm : Form
    {
        public GetTrainResultForm()
        {
            InitializeComponent();
        }
        string[] names;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFile.Multiselect = true;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                txtFolderPath.Text = OpenFile.FileName;
                names = OpenFile.FileNames;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        private void btnAllOK_Click(object sender, EventArgs e)
        {
            if (txtFolderPath.Text != "")
            {
                //计算
                Calculate() ;
            }
        }

        //        Ace-Pred
        //DLMLA
        //PMeS
        //PredSulSite
        //WSM-Plam
        void Calculate()
        {
            for (int i = 0; i < names.Length; i++)
            {
                StreamReader sr = new StreamReader(names[i]);
                string text = sr.ReadToEnd();
                sr.Close();
                string[] allText = ProteidCharacter.SplitStringsByEnter(text);//输入分割
                double[][] res = new double[allText.Length][];
                if (combName.Text.Contains("Ace-Pred"))
                {
                    for (int j = 0; j < allText.Length; j++)
                    {
                        res[j ] = ProteidCharacter.NewGetOneAcePred(allText[j ], 5)[0];
                    }
                }
                else if (combName.Text.Contains("DLMLA"))
                {
                    for (int j = 0; j < allText.Length; j++)
                    {
                        res[j ] = ProteidCharacter.GetOneDLMLA(allText[j ], 13, 5)[0];
                    }
                }
                else if (combName.Text.Contains("PMeS"))
                {
                    for (int j = 0; j < allText.Length; j++)
                    {                      
                        res[j] = ProteidCharacter.NewGetOneGroupAttribute(allText[i], 7);
                    }
                }
                else if (combName.Text.Contains("PredSulSite"))
                {

                    for (int j = 0; j < allText.Length; j++)
                    {                        
                        res[j ] = ProteidCharacter.GetOnePredSulsite(allText[j ], 9, 5)[0];
                    }
                }
                else if (combName.Text.Contains("WSM-Plam"))
                {
                    for (int j = 0; j < allText.Length; j++)
                    {
                        res[j ] = ProteidCharacter.GetOneWaccAndACFvalue(allText[j ], 8);
                    }
                }
                string saveFileName = names[i].Split('.')[0] + ".xls";                
                DotNet.Tools.ConverterAlgorithm.ConvertToExcel<double>(res, saveFileName, "test");
            }
            MessageBox.Show("计算完成！");
        }
    }
}
