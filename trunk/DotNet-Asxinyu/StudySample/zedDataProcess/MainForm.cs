using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;
using zedDataProcess .AnalysisChart ;

namespace zedDataProcess
{
	public partial class MainForm :  System .Windows .Forms .Form 
	{
		public static byte[] arr = ReadData .GetData () ;
		
		public MainForm()
		{
			InitializeComponent();
		}		
		void MainFormLoad(object sender, EventArgs e)
		{          
		}		
		void 均值与线性复杂度ToolStripMenuItemClick(object sender, EventArgs e)
		{
			MeanAndLinComplex meanComplexform = new MeanAndLinComplex () ;
			meanComplexform .Show () ;
		}
		
		void 退出ToolStripMenuItemClick(object sender, EventArgs e)
		{
			Application .Exit () ;
		}
		
		void 单个数字频数分析ToolStripMenuItemClick(object sender, EventArgs e)
		{
			SingleNumCycle singleCycleForm = new SingleNumCycle () ;
			singleCycleForm .Show () ;
		}
		
		void 每个数字周期分析ToolStripMenuItemClick(object sender, EventArgs e)
		{
			EveryNumCycle everyNumForm = new EveryNumCycle () ;
			everyNumForm .Show () ;
		}
		
		void 单个数相同周期ToolStripMenuItemClick(object sender, EventArgs e)
		{
			OneNumSameCycle oneSameForm = new OneNumSameCycle () ;
			oneSameForm .Show () ;
		}
		
		void 两个数相同周期ToolStripMenuItemClick(object sender, EventArgs e)
		{
			TwoNumSameCycle twoSameForm = new TwoNumSameCycle () ;
			twoSameForm .Show () ;
		}
		
		void 三个数相同周期ToolStripMenuItemClick(object sender, EventArgs e)
		{
			ThreeSameCycle threeSameForm = new ThreeSameCycle ();
			threeSameForm .Show () ;
		}
		
		void TwoSameInOneToolStripMenuItemClick(object sender, EventArgs e)
		{
			TwoSameInOneForm twoSamainoneForm = new TwoSameInOneForm () ;
			twoSamainoneForm .Show () ;
		}
	
		
		void 测试ToolStripMenuItemClick(object sender, EventArgs e)
		{
			EveryNoCycle myform1 = new EveryNoCycle (1) ;
			myform1 .Show () ;
		}
		
		void ToolStripMenuItem2Click(object sender, EventArgs e)
		{
			EveryNoCycle myform2 = new EveryNoCycle (2) ;
			myform2 .Show () ;
		}
		
		void ToolStripMenuItem3Click(object sender, EventArgs e)
		{
			EveryNoCycle myform1 = new EveryNoCycle (3) ;
			myform1 .Show () ;
		}
		
		void ToolStripMenuItem4Click(object sender, EventArgs e)
		{
			EveryNoCycle myform1 = new EveryNoCycle (4) ;
			myform1 .Show () ;
		}
		
		void ToolStripMenuItem5Click(object sender, EventArgs e)
		{
			EveryNoCycle myform1 = new EveryNoCycle (5) ;
			myform1 .Show () ;
		}
		
		void ToolStripMenuItem6Click(object sender, EventArgs e)
		{
			EveryNoCycle myform1 = new EveryNoCycle (6) ;
			myform1 .Show () ;
		}
		
		void ToolStripMenuItem7Click(object sender, EventArgs e)
		{
			EveryNoCycle myform1 = new EveryNoCycle (7) ;
			myform1 .Show () ;
		}
		
		void ToolStripMenuItem8Click(object sender, EventArgs e)
		{
			EveryNoCycle myform1 = new EveryNoCycle (8) ;
			myform1 .Show () ;
		}
		
		void ToolStripMenuItem9Click(object sender, EventArgs e)
		{
			EveryNoCycle myform1 = new EveryNoCycle (9) ;
			myform1 .Show () ;
		}
		
		void ToolStripMenuItem10Click(object sender, EventArgs e)
		{
			EveryNoCycle myform1 = new EveryNoCycle (0) ;
			myform1 .Show () ;
		}
		
		void 最近2次的冗余度ToolStripMenuItemClick(object sender, EventArgs e)
		{
			string str1 = "最近2次的冗余度" ;
			string str2 = "最近2次所包含的不相同的数字" ;
			FormModel myform = new FormModel (DataProcess .SimilerInRecent ,str1 ,str2 ,
			                                  2,2) ;
			myform .Show () ;
		}
		
		void 最近3次的冗余度ToolStripMenuItemClick(object sender, EventArgs e)
		{
			string str1 = "最近3次的冗余度" ;
			string str2 = "最近3次所包含的不相同的数字" ;
			FormModel myform = new FormModel (DataProcess .SimilerInRecent ,str1 ,str2 ,
			                                  3,2) ;
			myform .Show () ;
		}
		
		void 最近4次的冗余度ToolStripMenuItemClick(object sender, EventArgs e)
		{
//			string str1 = "最近4次的冗余度" ;
//			string str2 = "最近4次所包含的不相同的数字" ;
//			FormModel myform = new FormModel (DataProcess .SimilerInRecent ,str1 ,str2 ,
//			                                  4,2) ;
//			myform .Show () ;
			
		}
	}
}
