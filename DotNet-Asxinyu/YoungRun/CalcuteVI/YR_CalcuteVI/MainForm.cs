/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2010-8-24
 * Time: 11:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace YR_CalcuteVI
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
    {
        #region 公共方法
        public MainForm()
		{
			InitializeComponent();			
			combTemp.SelectedIndex = 0 ;
			combTemp1.SelectedIndex = 0 ;
            comboBox1.SelectedIndex = 0;
		}
        public void SetControlOnlyValue(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == '.' || e.KeyChar == '-');
            if (!e.Handled)
                (sender as TextBox).Tag = (sender as TextBox).Text;//记录最后一次正确输入
        }
        #endregion

        #region 粘度指数计算 和重置
        void BtnOKClick(object sender, EventArgs e)
		{
            if (comboBox1.SelectedIndex == 0)
            {
                if (txtV40.Text == "")
                {
                    epVI.SetError(txtV40, "不能为空");
                    return;
                }
                if (txtV100.Text == "")
                {
                    epVI.SetError(txtV100, "不能为空");
                    return;
                }
                epVI.Clear();
                txtVI.Text = LubeCalculateHelper.CalcuteVIAccordGB(Convert.ToDouble(txtV40.Text.Trim()),
                                         Convert.ToDouble(txtV100.Text.Trim())).ToString();
            }
            else
            {
                if (txtV40.Text == "")
                {
                    epVI.SetError(txtV40, "不能为空");
                    return;
                }
                if (txtVI .Text == "")
                {
                    epVI.SetError(txtVI , "不能为空");
                    return;
                }
                epVI.Clear();
                txtV100 .Text = LubeCalculateHelper.CalcuteV100ByVIAndV40 (Convert.ToDouble(txtV40.Text.Trim()),
                                         Convert.ToInt32 (txtVI.Text.Trim())).ToString();
            }
		}
        void BtnResetClick(object sender, EventArgs e)
        {
            txtV40.Text = "";
            txtV100.Text = "";
            txtVI.Text = "";
            comboBox1.SelectedIndex = 0;
        }
        #endregion 

        #region 调和粘度计算 和重置
        void Button2Click(object sender, EventArgs e)
		{
			if (txtVa.Text =="")
			{
				epVI.SetError (txtVa ,"不能为空");
				return ;
			}
			if (txtVb .Text =="")
			{
				epVI.SetError (txtVb,"不能为空");
				return ;
			}
			if (txtPer.Text =="")
			{
				epVI.SetError (txtPer ,"不能为空");
				return ;
			}			
			epVI.Clear () ;
            try
            {
                txtResult.Text =LubeCalculateHelper. CalcuateMixV(Convert.ToDouble(txtVa.Text),
                                              Convert.ToDouble(txtVb.Text),
                                              Convert.ToDouble(txtPer.Text),
                                              combTemp.SelectedIndex).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
		}
        void Button1Click(object sender, EventArgs e)
        {
            txtVa.Text = "";
            txtVb.Text = "";
            txtPer.Text = "";
            combTemp.SelectedIndex = 0;
            txtResult.Text = "";
        }
        #endregion

        #region 调和比例计算 和重置
        void Button4Click(object sender, EventArgs e)
		{
			if (txtV1.Text =="")
			{
				epVI.SetError (txtV1 ,"不能为空");
				return ;
			}
			if (txtV2 .Text =="")
			{
				epVI.SetError (txtV2,"不能为空");
				return ;
			}
			if (txtV .Text =="")
			{
				epVI.SetError (txtV ,"不能为空");
				return ;
			}				
			epVI.Clear () ;
			double res =LubeCalculateHelper.CalcuateMixVs (Convert.ToDouble (txtV1.Text ),
			                            Convert.ToDouble (txtV2.Text ),
			                            Convert.ToDouble (txtV.Text ) ,
			                            combTemp1.SelectedIndex ) ;
			txtPer1.Text = res.ToString () ;
			txtPer2.Text = (100 - res ).ToString () ;
        }
        void Button3Click(object sender, EventArgs e)
        {
            txtV1.Text = "";
            txtV2.Text = "";
            txtV.Text = "";
            combTemp1.SelectedIndex = 0;
            txtPer1.Text = "";
            txtPer2.Text = "";
        }
        #endregion 

        #region 粘温计算 和重置
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text =="")
            {
                epVI.SetError(textBox4, "V40不能为空");
                return;
            }
            if (textBox3.Text =="")
            {
                epVI.SetError(textBox3, "V100不能为空");
                return;
            }
            if (textBox2.Text =="")
            {
                epVI.SetError(textBox2, "指定温度");
                return;
            }
            textBox5.Text = LubeCalculateHelper.GetTempVtByV400V100(Convert.ToDouble(textBox4.Text),
                Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox2.Text)).ToString ();

        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
        }
        #endregion      
    }
}