
using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	///3��������ͬ���
	/// </summary>
	public partial class ThreeSameCycle : Form
	{
		public ThreeSameCycle()
		{
			InitializeComponent();
		}
		void ThreeSameCycleLoad(object sender, EventArgs e)
		{	         
			string str1 = "��3��������ͬ���";
			string str2 = "���" ;
			formProcess .CreateGeneralChart (zedGraphControl1 ,DataProcess.ThreeInterval ,
			                                 str1,str2 ) ;
		}
	}
}
