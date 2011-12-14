
using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	///3个数字相同间隔
	/// </summary>
	public partial class ThreeSameCycle : Form
	{
		public ThreeSameCycle()
		{
			InitializeComponent();
		}
		void ThreeSameCycleLoad(object sender, EventArgs e)
		{	         
			string str1 = "有3个数字相同间隔";
			string str2 = "间隔" ;
			formProcess .CreateGeneralChart (zedGraphControl1 ,DataProcess.ThreeInterval ,
			                                 str1,str2 ) ;
		}
	}
}
