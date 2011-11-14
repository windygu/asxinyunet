/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-5
 * Time: 9:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using LotteryTicket.Validate;
using DotNet.Tools;

namespace LotteryTicketSoft.GraphForm
{
	/// <summary>
	/// 数据预测窗体
	/// </summary>
	public partial class DataPredict : Form
	{
		public DataPredict()
		{			
			InitializeComponent();
		}
		
		void BtnCalculateClick(object sender, EventArgs e)
		{
			double[] contions = txtConditions.Text.Trim().ConvertStrToDoubleList(',') ;
			int needCount = Convert.ToInt32 (txtDataCount.Text) ;			
			double[][] data = TwoColorBall.GetRedBallData (200) ;
			bool[] resBool =  PredictMethodsValidate.PredictValidate(data,IndexNameType.A_Sum,contions ,
			                                         FilterRuleType.RangeLimite ,1 );
			int sum = 0 ;
			foreach (bool a in resBool ) 
			{
				if (a  )
				{
					sum ++ ;
				}
			}
			MessageBox.Show ((((double )sum)/(double )resBool.Length).ToString ()) ;
		}
	}
}