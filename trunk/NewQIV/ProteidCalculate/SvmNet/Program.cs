/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-10-14
 * 时间: 9:26
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using SVM;
using System.Collections.Generic;

namespace SvmNet
{
	class Program
	{
		public static void Main(string[] args)
		{
            List<int> list = new List<int>();
            list.AddRange(new int[] {2,9,5,8,3,6,4 });
            list.Sort();

			
//			double[] res ;
//			double d = ProteidSvmTest.GetSvmPredictResult ("train1.txt","test1.txt",8192,0.000488281,out res ) ;
//			Console.WriteLine (d.ToString ()) ;
//			double d2 =ProteidSvmTest.TestMode ("train1.txt","test1.txt",8192,0.000488281,out res ) ;
//			Console.WriteLine (d2.ToString ()) ;
			
			#region 废弃的测试代码
//            Problem train = Problem.Read("data.txt"); //"a2a.txt"  train.txt		
//            Problem test = Problem.Read("data.txt");	//"a2a.t"  test.txt		
//            Parameter parameters = new Parameter();
//            double C;
//            double Gamma;
////			ParameterSelection.Grid(train, parameters, "params.txt", out C, out Gamma);
////			parameters.C = C ;
////			parameters.Gamma = Gamma ;
////			parameters.C = 32768 ;
////			parameters.Gamma = 0.001953125;
//            parameters.C = 8192 ;
//            parameters.Gamma = 3.05176e-005 ;
//            parameters.Probability = true ;
//            Model model = Training.Train(train, parameters);
//            Console.WriteLine ("---------------");
//            Console.WriteLine ("Result:"+Prediction.Predict(test, "results.txt", model, true ).ToString ());
//            Console.WriteLine ("C:"+parameters.C.ToString ()) ;
//            Console.WriteLine ("Gamma:"+parameters.Gamma.ToString ()) ;
		#endregion		
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	
	
}