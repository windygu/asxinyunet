using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	/// һ�γ���������ͬ��������
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
			string str1 = "ÿ����2����ͬ������ ";
          	string str2 = "���" ;
			formProcess .CreateGeneralChart (zedGraphControl1 ,DataProcess.TwoSameInOne,
			                                 str1,str2 ) ;
		}
	}
}
