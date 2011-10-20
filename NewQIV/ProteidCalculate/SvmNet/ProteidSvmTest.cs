/*
 * 由SharpDevelop创建。
 * 用户： 董斌辉
 * 日期: 2011-10-15
 * 时间: 11:09
 * 
 * 
 * 2011-10-15 对SVM.NET程序包结构清楚，开始对其进行优化，提高速度，减少无用的IO操作：
 *            1.编写符合该项目的SVM.NET通用方法 GetSvmPredictResult
 *            2.为提高网站读写速度，对SVM.NET训练集进行了优化，不用每次都去进行转换和计算
 *            3.对SVM.NET类库进行了整理，优化了IO操作，不必要每次都存储到txt文件，然后读取转换，大大节省转换时间
 *            4.对项目以前的一些计算方法进行优化，提高操作速度，特别是字符串分割提取
 *            5.准备采用缓存和数据库技术来存储计算过的序列，这样为以后大规模计算提供帮助，这样对已经计算的序列就可以
 *              直接读取结果，而不需要重复计算，浪费计算能力
 * 2011-10-14 开始进行实例测试，在项目组的配合下，经过多次测试，逐步了解与掌握了SVM.NET的使用和原理
 *            并成功的使用基本的测试数据，进行了初步的测试，效果较好
 * 2011-10-13 寻找网上资源，对SVM.NET程序包进行了解
 * 2011-10-12 开始整理SVM.NET文件,熟悉基本功能
 */
using System;
using SVM ;

namespace SvmNet
{
	/// <summary>
	/// 蛋白质SVM测试
	/// </summary>
	public class ProteidSvmTest
	{
		#region SVM.NET类库的使用及整理
		/// <summary>
		/// Svm.NET计算序列预测结果，直接根据模型来计算
		/// </summary>
		/// <param name="C">C值</param>
		/// <param name="Gamma">G值</param>
		/// <param name="Probability">概率值</param>
		/// <returns>预测值</returns>
		public static double GetSvmPredictResult(Model trainModel,string testDataFileName,out double[] Probability)
		{
			Problem test = Problem.Read(testDataFileName);
			return Prediction.Predict(test,trainModel,out Probability ) ;
		}
        //直接输入数据格式
        public static double GetSvmPredictResult(Model trainModel, double[][] testData,out double[] Probability)
        {
            Problem test = Problem.ReadForTestData(testData);
            return Prediction.Predict(test, trainModel, out Probability);
        }

		/// <summary>
		/// 根据训练集的文件路径来计算预测结果
		/// </summary>
		/// <param name="trainDataFileName"></param>
		/// <param name="testDataFileName"></param>
		/// <param name="C"></param>
		/// <param name="Gamma"></param>
		/// <param name="Probability"></param>
		/// <returns></returns>
		public static double GetSvmPredictResult(string trainDataFileName,string testDataFileName,double C,double Gamma,out double[] Probability)
		{
			Model trainModel = GetTrainingModel(trainDataFileName,C,Gamma ) ;
			Problem test = Problem.Read(testDataFileName);
			return Prediction.Predict(test,trainModel,out Probability ) ;
		}
		/// <summary>
		/// 根据训练集，得到训练的模型，固定起来，便于加快计算速度
		/// </summary>
		/// <returns></returns>
		public static Model GetTrainingModel(string trainDataFileName,double C,double Gamma)
		{
			Problem train = Problem.Read(trainDataFileName);
			Parameter parameters = new Parameter();
			parameters.C = C ;
			parameters.Gamma = Gamma ;
			parameters.Probability = true ;//设置输出概率值
			return Training.Train(train, parameters);
		}
        /// <summary>
        /// 默认去掉0
        /// </summary>
        /// <param name="trainDataFileName"></param>
        /// <param name="testDataFileName"></param>
        /// <param name="C"></param>
        /// <param name="Gamma"></param>
        /// <param name="Probability"></param>
        /// <returns></returns>
		public static double TestMode(string trainDataFileName,string testDataFileName,double C,double Gamma,out double[] Probability)
		{
			Problem test = Problem.ReadForSpecial(testDataFileName);
			Problem train = Problem.ReadForSpecial(trainDataFileName);
			Parameter parameters = new Parameter();
			parameters.C = C ;
			parameters.Gamma = Gamma ;
			parameters.Probability = true ;//设置输出概率值	
			Model trainModel = Training.Train(train, parameters);
			return Prediction.Predict(test,trainModel,out Probability ) ;
		}
		#endregion
		
		#region 辅助代码 对序列着色突出显示
		//红色 #33300 蓝色 #000099  K用#009933，指定字母的颜色用#CC3333
        public static string GetHtmlCodeByString(string str, string colorChar,string colorPoint,string comColor,int[] arrList)
        {
            //【2，3,4,5,7,9,10,11,12,14,15,17,19,20,21】
           // int[] arrList = new int[] {2,3,4,5,7,9,10,12,14,15,17,19,20,21};
            bool[] conditon = new bool[str.Length ];         
            for (int i = 0; i < arrList.Length ; i++)
            {
                conditon[arrList[i]-1] = true;
            }
            string[] res = new string[conditon.Length];
            for (int i = 0; i <conditon.Length ; i++)
            {
                if (conditon[i])
                {
                    res [i ] = "<font color='#" + colorChar + "'><b>" + str[i ] + "</b></font>";
                }
                else
                {
                    res[i] = "<font color='#" + comColor + "'><b>" + str[i] + "</b></font>";
                }
            }
            int a =(int )((str.Length - 1) * 0.5);
            string linkStr = "";
            for (int i = 0; i < a ; i++)
            {
                linkStr += res[i];
            }
            linkStr = linkStr + "-" + "<font color='#" + colorPoint + "'><b>" + str[a] + "</b></font>" + "-";
            for (int i = a+1 ; i < str.Length ; i++)
            {
                linkStr += res[i];
            }
            return linkStr;
        }
        #endregion
		
		#region 废弃的测试代码
//			Problem train = Problem.Read("data.txt"); //"a2a.txt"  train.txt
//			RangeTransform range = RangeTransform.Compute(train);
		//            train = range.Scale(train);
//			Problem test = Problem.Read("data.txt");	//"a2a.t"  test.txt
//			test = range.Scale(test);
//			RangeTransform range2 = RangeTransform.Compute(test);
		//test = range2.Scale(test);
//			Parameter parameters = new Parameter();
//
//			double C;
//			double Gamma;
//			ParameterSelection.Grid(train, parameters, "params.txt", out C, out Gamma);
//			parameters.C = C ;
//			parameters.Gamma = Gamma ;
//			parameters.C = 32768 ;
//			parameters.Gamma = 0.001953125;
//			parameters.C = 8192 ;
//			parameters.Gamma = 3.05176e-005 ;
//			parameters.Probability = true ;
//			Model model = Training.Train(train, parameters);
//			Console.WriteLine ("---------------");
//			Console.WriteLine ("Result:"+Prediction.Predict(test, "results.txt", model, true ).ToString ());
//			Console.WriteLine ("C:"+parameters.C.ToString ()) ;
//			Console.WriteLine ("Gamma:"+parameters.Gamma.ToString ()) ;
		#endregion
	}
}