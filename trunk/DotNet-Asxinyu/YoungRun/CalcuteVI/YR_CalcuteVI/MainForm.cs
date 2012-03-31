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
		public MainForm()
		{
			InitializeComponent();			
			combTemp.SelectedIndex = 0 ;
			combTemp1.SelectedIndex = 0 ;
		}
		
		void BtnOKClick(object sender, EventArgs e)
		{
			if (txtV40.Text =="")
			{
				epVI.SetError (txtV40 ,"不能为空");
				return ;
			}
			if (txtV100 .Text =="")
			{
				epVI.SetError (txtV100,"不能为空");
				return ;
			}
			epVI.Clear () ;
			txtVI .Text =LubeCalculateHelper.CalcuteVIAccordGB(Convert.ToDouble (txtV40 .Text.Trim ()),
			                         Convert.ToDouble (txtV100 .Text .Trim ())).ToString ();
		}
		#region 函数			
		public static double CalcuateMixV(double KV1,double KV2,double percent,int i)
		{
			int[] Kvalue = new int[]{4,2} ;   //40度和100度的k值
			int K = Kvalue[i ] ;
			double x1 = percent /100 ;
			return Math.Round(100*(Math.Exp(Math.Log(KV2+K)*Math.Exp(x1*Math.Log (Math.Log (KV1+K)/Math.Log (KV2+K))))-K))/100;
		}
		
		public static double CalcuateMixVs(double KV1,double KV2,double KV,int i)
		{
			int[] Kvalue = new int[]{4,2} ;   //40度和100度的k值
			int K = Kvalue[i ] ;
			double a=Math.Log (KV+K);
			double b=Math.Log (KV1+K);
			double c=Math.Log (KV2+K);
			return Math.Round(10000*(Math.Log(a/c)/Math.Log(b/c)))/100;
		}
		#endregion
		void BtnResetClick(object sender, EventArgs e)
		{
			txtV40.Text ="";
			txtV100 .Text="";
			txtVI .Text ="" ;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			txtVa.Text = "" ;
			txtVb .Text = "" ;
			txtPer.Text = "" ;
			combTemp.SelectedIndex = 0 ;
			txtResult .Text = "" ;
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			txtV1.Text = "" ;
			txtV2.Text = "" ;
			txtV .Text = "" ;
			combTemp1.SelectedIndex = 0 ;
			txtPer1.Text = "" ;
			txtPer2 .Text = "" ;
		}
		
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
                txtResult.Text = CalcuateMixV(Convert.ToDouble(txtVa.Text),
                                              Convert.ToDouble(txtVb.Text),
                                              Convert.ToDouble(txtPer.Text),
                                              combTemp.SelectedIndex).ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
		}       
		
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
			double res = CalcuateMixVs (Convert.ToDouble (txtV1.Text ),
			                            Convert.ToDouble (txtV2.Text ),
			                            Convert.ToDouble (txtV.Text ) ,
			                            combTemp1.SelectedIndex ) ;
			txtPer1.Text = res.ToString () ;
			txtPer2.Text = (100 - res ).ToString () ;
		}
	}
}
