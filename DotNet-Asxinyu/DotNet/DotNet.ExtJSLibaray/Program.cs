/*
 * 由SharpDevelop创建。
 * 用户： 董斌辉
 * 日期: 2012-5-16
 * 时间: 17:40
 * 
 * 开发过程：基于ExtJS的对象代码生成类库,为模板生成使用
 * 
 * 2012-05-16  根据Efs框架的设计思想，以及Xcode强大的模板功能，有了这一想法，将逐步完善
 */



namespace DotNet.ExtJSLibaray
{
	using System;
	using System.IO ;
	using System.Text ;
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine (Layout.GetOneLayout (0,"布局测试","",200));
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}