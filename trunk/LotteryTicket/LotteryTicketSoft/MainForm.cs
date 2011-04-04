/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:10
 * 
 * 软件GUI工具
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LotteryTicket ;
using LotteryTicketData ;
using LotteryTicketSoft.GraphForm ;

namespace LotteryTicketSoft
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{			
			InitializeComponent();	
			textBox1.Text ="11,12.5,14,20,21.5,23,30";
		}
		
		void Button1Click(object sender, EventArgs e)
		{			
			int[][] data = TwoColorBall.GetRedBallData () ;
			string[] s=textBox1.Text.Trim ().Split (',');			
			double[] limite = new double[s.Length ] ;
			for (int i=0; i<limite.Length ;i ++ )//11,12.5,14,20,21.5,23,30   8,13,18,23,27 
			{
				limite [i ] = Convert.ToDouble (s[i ]) ;
			}
//			double[] sum = IndexStatics.FrequPrecentStatics ()  ;//(double [])IndexCalculate.Mean(data ) ;
//			BaseGraphClass.CreateChartForDouble (zedGraphControl1,sum,"测试","和值") ;
//			zedGraphControl1.Refresh () ;
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			zedGraphControl1.GraphPane.CurveList.RemoveRange (0,zedGraphControl1.GraphPane.CurveList.Count ) ;
			zedGraphControl1.Refresh () ;
		}
		
		void Button3Click(object sender, EventArgs e)
		{
			
		}
	}
}
