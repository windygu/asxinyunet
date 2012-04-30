using System.Drawing;
/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:13
 * 
 * 基本绘图类库
 */
using ZedGraph;

namespace LottAnalysis.GraphForm
{
	/// <summary>
	/// 绘图程序
	/// </summary>	
	public class BaseGraphClass
	{
		public static void CreateChartForInt(ZedGraphControl zgc ,int[] data,
		                                     string titleName ,string lblName,
		                                     Color color,SymbolType symType )
		{
			double[] res = new double[data.Length ] ;
			for (int i = 0 ; i <data.Length ; i ++)
			{
				res [i ] = (double )data [i ] ;
			}
			CreateChartForDouble(zgc ,res , titleName ,lblName ,color ,symType ) ;
		}
		
		public static void CreateChartForDouble(ZedGraphControl zgc ,double[] data,
		                                     string titleName ,string lblName,
		                                     Color color,SymbolType symType )
		{
			GraphPane mypan = zgc.GraphPane ;
			mypan .Title.Text = titleName ;
			mypan .XAxis .Title .IsVisible = false ;
			mypan .YAxis .Title .IsVisible = false ;
			PointPairList list = new PointPairList();
			for (int i = 0; i < data.Length ; i++)
			{
				double x =(double ) i;
				double y1 = data[i];
				list.Add(x, y1);
			}
			mypan .Y2Axis .IsVisible = true ;
			mypan .XAxis .MajorGrid .IsVisible = true ;
			mypan .YAxis .MajorGrid .IsVisible = true ;
			mypan .XAxis .MinorGrid .IsVisible = true ;
			mypan .YAxis .MinorGrid .IsVisible = true ;
			LineItem myItem = mypan.AddCurve(lblName ,list ,color,symType);
			zgc.AxisChange();
		}
	}
}
