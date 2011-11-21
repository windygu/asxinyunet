using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	/// 有2个数字相同的间隔
	/// </summary>
	public partial class TwoNumSameCycle : Form
	{
		public TwoNumSameCycle()
		{
			InitializeComponent();
		}
		
		void TwoNumSameCycleLoad(object sender, EventArgs e)
		{
			string str1 = "有2个数字相同的间隔 ";
			string str2 = "间隔" ;
			formProcess .CreateGeneralChart (zedGraphControl1 ,DataProcess.TwoInterval ,
			                                 str1,str2 ) ;
		}
	}
}
