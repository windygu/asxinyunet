/*
 * Created by SharpDevelop.
 * User: dbh
 * Date: 2012/8/16 星期四
 * Time: 9:33
 * 
 * 2个基本的例子，得到Magic矩阵和简单的绘图
 */
using System;
//添加MWArray的命名空间引用
using MathWorks.MATLAB.NET.Arrays ;
using MathWorks.MATLAB.NET.Utility ;
//添加Matlab中生成的dll的引用
using Demo1 ;

namespace Demo_1
{
	class Program
	{
		public static void Main(string[] args)
		{
			//实例化一个类，注意类名和Matlab中编译时的类名是一样的			
			DemoMagic dm= new DemoMagic ();
			MWArray N = 5 ;//输入参数，注意类型
			//调用方法，注意方法名，和M函数一样，可以查看其它重载方法
			MWArray result = dm.Demo_GetMagicSquare (N );
			//看看断点查看结果
			string s = result.ToString ();			
			Console.WriteLine (result );//输出结果
			Console.WriteLine ("------------------------------");
			Console.WriteLine (s );//对比看输出的结果
			
			//绘图
			DemoFigure df = new DemoFigure ();
			MWArray x = (MWNumericArray )new double []{1,2,3,4,5};
			MWArray y = (MWNumericArray )new double []{4.6,5.2,3.8,1.3,8.9};
			df.Demo_DrawGraph (x,y );		
		
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}