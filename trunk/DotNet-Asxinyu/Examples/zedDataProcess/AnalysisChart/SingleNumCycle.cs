/*
 * Created by SharpDevelop.
 * User: dbh
 * Date: 2008-5-25
 * Time: 10:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	///  �������ֳ��ֵ�Ƶ�ʷ���
	/// </summary>
	public partial class SingleNumCycle : Form
	{
		public SingleNumCycle()
		{
			InitializeComponent();
		}
		
		void SingleNumCycleLoad(object sender, EventArgs e)
		{
			string str1 = "�������ֳ��ֵĴ���";
			string str2 = "���" ;
			formProcess .CreateGeneralChart (zedGraphControl1 ,DataProcess .FrequCount ,
			                                 str1,str2 ) ;	
			
		}
	}
}
