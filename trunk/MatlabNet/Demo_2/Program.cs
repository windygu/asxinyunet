/*
 * Created by SharpDevelop.
 * User: dbh
 * Date: 2012/8/20 星期一
 * Time: 10:35
 * 
 * 直接调用Matlab MCR内置函数的实验，2012a版本，不需要密钥等其他东东
 */
using System;
using System.Reflection;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace Demo_2
{
	public class TestDemo
	{
		public static MWMCR Mcr ;
		static TestDemo ()
		{
			if (MWMCR.MCRAppInitialized)
			{				
				Assembly assembly= Assembly.GetExecutingAssembly();
				string ctfFilePath= assembly.Location;
				int lastDelimiter= ctfFilePath.LastIndexOf(@"\");
				ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));
				Mcr= new MWMCR("Demo1",ctfFilePath, true );
			}
			else
			{
				throw new ApplicationException("MWArray assembly could not be initialized");
			}
		}
	}
	
	class Program
	{
		public static void Main(string[] args)
		{
            int[,] a = new int[1, 3] { { 1, 2, 3 } };
            Array b = a;
            int[] k = (int[])b;
            //MWNumericArray a = new double[] { 1, 2, 3, 4, 5, 6 };
            //MWArray x1 = (MWNumericArray)(new double[] { 2.3, 1.6, 5.6, 7.8, 0.6, 6.3 });
            //MWNumericArray x = new MWNumericArray(2, 3, new double[] { 2.3, 1.6, 5.6, 7.8, 0.6, 6.3 });
            ////double[] y = new double []{2.3,1.6,5.6,7.8,0.6,6.3};
            //MWNumericArray t = (MWNumericArray)TestDemo.Mcr.EvaluateFunction("sort", x);//直接调用函数
            //Array k = x.ToArray();        
            //double[,] a = (double[,]) t.ToArray (MWArrayComponent.Real);			
		    //Array b =(double[])((MWNumericArray)t).ToVector (MWArrayComponent.Real);//不能转换的原因			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}