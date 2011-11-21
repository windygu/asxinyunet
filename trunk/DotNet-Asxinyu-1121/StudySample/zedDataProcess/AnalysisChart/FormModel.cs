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
		/// ģ�崰��
		/// </summary>
		/// <param name="sample"></param>
		/// <param name="s1">ͼ�����Ϸ�������ʾ������</param>
		/// <param name="s2">��������ʾ������</param>
		/// <param name="typeNo">���ࣺ1Ϊ1��������ί�����ͣ�2Ϊ2��������ί������</param>
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