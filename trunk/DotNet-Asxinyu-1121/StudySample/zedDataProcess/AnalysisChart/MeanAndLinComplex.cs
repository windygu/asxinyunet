using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	/// 均值与线性复杂度分析
	/// </summary>
	public partial class MeanAndLinComplex : Form
	{
		public MeanAndLinComplex()
		{			
			InitializeComponent();		
		}
		
		void MeanAndLinComplexLoad(object sender, EventArgs e)
		{
			 //均值与线性复杂度
            this .zedGraphControl1 .GraphPane .Title .Text = "均值与线性复杂度" ;
            this .zedGraphControl1 .GraphPane .XAxis .Title .IsVisible = false ;
            this .zedGraphControl1 .GraphPane .YAxis .Title .IsVisible = false ;
			PointPairList list1=new PointPairList () ; 
			PointPairList list2=new PointPairList () ; 	
			double[] mean = DataProcess.MeanOfArray (MainForm .arr ) ;
			int[] complex = DataProcess .LinearComplex (MainForm.arr ) ;
			for ( int i=0; i<mean .Length ; i++ )
			{
				int x = i ;
				double y1 =mean [i ];				
				list1.Add( x, y1 );
				list2 .Add (x ,complex [i ]);
			}
			LineItem myItem1 = zedGraphControl1 .GraphPane .AddCurve ("均值",list1 ,Color .Red  ,SymbolType.Diamond );
			LineItem myCurve = zedGraphControl1 .GraphPane .AddCurve ("线性复杂度",list2 ,Color.Coral ,SymbolType.Default );
			this.zedGraphControl1.AxisChange();
		}
	}
}
