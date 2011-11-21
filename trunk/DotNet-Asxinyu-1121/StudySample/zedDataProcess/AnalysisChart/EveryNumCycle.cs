using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph ;

namespace zedDataProcess.AnalysisChart
{
	/// <summary>
	/// 单个数字出现的周期间隔
	/// </summary>
	public partial class EveryNumCycle : Form
	{
		public EveryNumCycle()
		{
			InitializeComponent();
		}
		
		void EveryNumCycleLoad(object sender, EventArgs e)
		{
			MasterPane myMaster = zedGraphControl1 .MasterPane ;			
			myMaster.PaneList.Clear();
			myMaster.Title.Text = "MasterPane Test";
			myMaster.Title.IsVisible = true;
			myMaster.Fill = new Fill( Color.White, Color.MediumSlateBlue, 45.0F );
			int[][] everyRes = DataProcess .AllSingleCycle (MainForm .arr ) ;
			for ( int j=0; j< 10; j++ )
			{
				GraphPane myPane = new GraphPane();
				myPane.Title.Text = "My Test Graph #" + (j+1).ToString();
				myPane.XAxis.Title.Text = "X Axis";
				myPane.YAxis.Title.Text = "Y Axis";
				//myPane.Fill = new Fill( Color.White, Color.LightYellow, 45.0F );
				//myPane.BaseDimension = 6.0F;
				PointPairList list = new PointPairList();
				for ( int i=0; i < everyRes [j ].Length ; i++ )
				{
					int x = i ;
					int y = everyRes [j ][i ] ;
					list.Add( x, y );
				}
				LineItem myCurve = myPane.AddCurve( "label" + j.ToString(),list, Color.Red, SymbolType.Diamond );
				myMaster.Add( myPane );
			}
			using ( Graphics g = this.CreateGraphics() )
			{
				 myMaster .SetLayout( g, PaneLayout.SquareColPreferred );
			}
		}
	}
}