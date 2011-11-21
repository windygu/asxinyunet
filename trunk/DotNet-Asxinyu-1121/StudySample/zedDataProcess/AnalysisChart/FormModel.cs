using System;
using System.Drawing;
using System.Windows.Forms;

namespace zedDataProcess.AnalysisChart
{
	public partial class FormModel : Form
	{		
		myDelegate mySample ;
		myDelegateTwo mySampleTwo ;
		string str1 = "" ;
		string str2 = "" ;
		byte type ;
		byte k ;
		/// <summary>
		/// 模板窗体
		/// </summary>
		/// <param name="sample"></param>
		/// <param name="s1">图形最上方中央显示的文字</param>
		/// <param name="s2">纵坐标显示的文字</param>
		/// <param name="typeNo">种类：1为1个参数的委托类型；2为2个参数的委托类型</param>
		public FormModel(myDelegate sample,string s1 ,string s2 , byte typeNo)
		{	
			mySample = sample ;
			str1 = s1 ;
			str2 = s2 ;
			type = typeNo ;
			InitializeComponent();
		}
		public FormModel(myDelegateTwo sample,string s1 ,string s2 ,byte k , byte typeNo)
		{	
			mySampleTwo  = sample ;
			str1 = s1 ;
			str2 = s2 ;
			type = typeNo ;
			this .k = k ;
			InitializeComponent();
		}
		void FormModelLoad(object sender, EventArgs e)
		{
			if (type == 1) 
			{
				formProcess .CreateGeneralChart (zedGraphControl1 ,
			                                 mySample ,str1,str2 ) ;
			}
			else if (type == 2 )
			{
				formProcess .CreateGeneralChart (zedGraphControl1 ,
			                                     mySampleTwo ,k ,str1,str2 ) ;
			}
		}
	}
}