using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	/// 一次出现两个相同数字周期
	/// </summary>
	public partial class TwoSameInOneForm : Form
	{
		public TwoSameInOneForm()
		{
			InitializeComponent();
		}
		
		void ZedGraphControl1Load(object sender, EventArgs e)
		{			
		}
		
		void TwoSameInOneFormLoad(object sender, EventArgs e)
		{
			string str1 = "每组有2个相同的周期 ";
          	string str2 = "间隔" ;
			formProcess .CreateGeneralChart (zedGraphControl1 ,DataProcess.TwoSameInOne,
			                                 str1,str2 ) ;
		}
	}
}
