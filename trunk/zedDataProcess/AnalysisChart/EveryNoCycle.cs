using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	/// Description of test.
	/// </summary>
	public partial class EveryNoCycle : Form
	{
		byte m ;
		public EveryNoCycle(byte mvalue)
		{
			m = mvalue ;
			InitializeComponent();
		}
		
		
		void TestLoad(object sender, EventArgs e)
		{
			string str1 = "����"+m .ToString () +"���";
			string str2 = "���" ;			
			formProcess .CreateGeneralChart (zedGraphControl1 ,
			                                 DataProcess .SingleCycle , m ,str1,str2 ) ;
		}		
	}
}