using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	/// ��1��������ͬ�ļ��
	/// </summary>
	public partial class OneNumSameCycle : Form
	{
		public OneNumSameCycle()
		{
			InitializeComponent();		
		}
		
		void OneNumSameCycleLoad(object sender, EventArgs e)
		{		
			string str1 = "��1��������ͬ�ļ�� ";
			string str2 = "���" ;
			formProcess .CreateGeneralChart (zedGraphControl1 ,DataProcess .OneInterval ,
			                                 str1,str2 ) ;

		}
	}
}
