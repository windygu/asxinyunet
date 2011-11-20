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
using System.Threading;
using System.Collections.Generic;

namespace SvmNet
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("**********************************************");
			Console.WriteLine("网站参数配置程序:");
			Console.WriteLine("警告：运行此程序之前，先停止服务器网站的运行");
			Console.WriteLine("注意：由于训练集的不同，时间可能比较长     ");
			Console.WriteLine("**********************************************");
			bool flag = true ;
			while (flag )
			{
                WriteMode();
                int mode = Convert.ToInt32(Console.ReadLine());
                if (mode <0 || mode >8)
                {
                    Console.Clear();
                    continue;
                }
                if (mode ==8)
                {
                    flag = false;
                    return;
                }
                if (mode == 1)
                {
                    flag = false;
                    ProteidSvmTest.CalculateAllSvmTestMode();
                    Console.Clear();
                }
                else
                {                   
                    Console.Write("请输入当前模型的参数 C:");
                    double C = Convert.ToDouble(Console.ReadLine());
                    Console.Write("请输入当前模型的参数 G:");
                    double G = Convert.ToDouble(Console.ReadLine());
                    ProteidSvmTest.CalculateSingleSvmTestMode(mode, C, G);
                    Console.Clear();
                }
                Console.WriteLine("-----------------------");
                Console.WriteLine("计算完成，请继续");
                Console.WriteLine("-----------------------");
			}            
            Console.WriteLine("**********************************************");
			Console.Write("计算完成,请手动关闭此程序");
			Console.ReadKey(true);
		}

        public static void WriteMode()
        {
            Console.WriteLine("所有运行模式:");
            Console.WriteLine("1.直接根据文件名称和参数文件计算所有模型");
            Console.WriteLine("2.单独计算WSM-Plam-Train模型");
            Console.WriteLine("3.单独计算Ace-Pred-Train模型");
            Console.WriteLine("4.单独计算PMeS-R-Train模型");
            Console.WriteLine("5.单独计算PMeS-K-Train模型");
            Console.WriteLine("6.单独计算DLMLA-methyllysine-Train模型");
            Console.WriteLine("7.单独计算DLMLA-acetyllysine-Train模型");
            Console.WriteLine("7.单独计算PredSulSite-Trai模型");
            Console.WriteLine("8.退出程序");
            Console.Write("请根据实际选择运行模式:");
        }
	}	
}
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