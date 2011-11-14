using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	/// 有1个数字相同的间隔
	/// </summary>
	public partial class OneNumSameCycle : Form
	{
		public OneNumSameCycle()
		{
			InitializeComponent();		
		}
		
		void OneNumSameCycleLoad(object sender, EventArgs e)
		{		
			string str1 = "有1个数字相同的间隔 ";
			string str2 = "间隔" ;
			formProcess .CreateGeneralChart (zedGraphControl1 ,DataProcess .OneInterval ,
			                                 str1,str2 ) ;

		}
	}
}
