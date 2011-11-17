using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	/// ��2��������ͬ�ļ��
	/// </summary>
	public partial class TwoNumSameCycle : Form
	{
		public TwoNumSameCycle()
		{
			InitializeComponent();
		}
		
		void TwoNumSameCycleLoad(object sender, EventArgs e)
		{
			string str1 = "��2��������ͬ�ļ�� ";
			string str2 = "���" ;
			formProcess .CreateGeneralChart (zedGraphControl1 ,DataProcess.TwoInterval ,
			                                 str1,str2 ) ;
		}
	}
}
