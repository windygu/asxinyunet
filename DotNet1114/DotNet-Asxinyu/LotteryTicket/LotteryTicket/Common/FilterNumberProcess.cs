/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-19
 * Time: 17:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic ;
using System.IO ;

namespace LotteryTicket.Common
{
	/// <summary>
	///数据过滤处理
	/// </summary>
	public class FilterNumberProcess
	{
		#region 过滤处理
		/// <summary>
		/// 生成双色球全部数据,默认过滤指标：3连号及以上、和值、跨度
		/// </summary>
		/// <param name="fileName">最终号码存储的文件名</param>
		public static List<double[]> InitialFilterData(double[] deleteNumbers,int latestNos = 5,int repeatNumbers =2)
		{
			double[] data = new double[33] ;//初始化所有号码
			List <double > listNumbers = new List<double> () ;
			//初始化
			for (int i = 0; i < data.Length ; i++) {listNumbers.Add ((double )(i + 1)) ;}
			//杀号处理
			for (int i = 0; i < deleteNumbers.Length ; i++) {listNumbers.Remove (deleteNumbers[i ]) ;}
			//迭代获取所有组合序列,并对每个序列进行判断
			List<double[]> res = new List<double[]> () ;
			foreach (Combination combom in new Combination(data.Length ,6).Rows)
			{
				double[] curComb= Combination.Permute (combom, data).ToArray () ;
				//杀组合，参数为最近的期数和最大重复数,也可以单独杀
				if (latestNos >0) //最近的期数
				{
					//先获取需要杀号的数据
					bool temp = true ;
					double[][] deleteNos = TwoColorBall.GetRedBallData (latestNos ) ;
					for (int i = 0; i < deleteNos.GetLength ( 0 ); i++)
					{
						if (IndexCalculate.GetRepeatNumbers (curComb,deleteNos [i])>=repeatNumbers )
						{
							temp = false ;
							break ;
						}
					}
					if (temp ) res.Add (curComb ) ;//符合要求则添加
				}
			}
			return res ;
		}
		#endregion
		
		#region 杀组合
		/// <summary>
		/// 杀组合,杀掉一组序列中所有指定的组合
		/// </summary>
		/// <param name="origData">原始序列</param>
		/// <param name="deleteNumber">需要排除的序列组合</param>
		/// <param name="numbers">组合数</param>
		public static void DeleteCombinationNumbers(List<double[]> origData,
		                                            double[] deleteNumber,int numbers)
		{
//			List<int > flag = new List<int > () ;
//			for (int i = 0; i < origData.Count ; i++)
//			{
//				if (IndexCalculate.GetRepeatNumbers (element,deleteNumber )>=numbers )
//				{
//					flag.Add (i ) ;//将位置添加到序列,统一删除
//				}
//			}
			origData.RemoveAll (delegate (double[] cur){
			                    	return IndexCalculate.GetRepeatNumbers (cur ,deleteNumber )>=numbers? true:false;});
		}
		/// <summary>
		///  杀组合,杀掉一组序列中所有指定的组合
		/// </summary>
		/// <param name="origData">原始序列</param>
		/// <param name="combStr">组合,-分隔每个数字，逗号分隔2个组合：2-3-4,3-6-8</param>
		public static void DeleteCombinationNumbers(List<double[]> origData,string combStr)
		{
			string[] numStr = combStr.Split (',');
			for (int i = 0; i < numStr.Length ; i++) {
				double[] temp = GetSpliteNumbers (numStr [i ]) ;
				DeleteCombinationNumbers(origData,temp ,temp.Length ) ;
			}
		}
		/// <summary>
		/// 分隔字符串，获得一组序列,逗号分隔
		/// </summary>
		/// <param name="combStr"></param>
		/// <returns></returns>
		public static double[] GetSpliteNumbers(string combStr)
		{
			string[] numStr = combStr.Split ('-') ;
			List<double > numbers = new List<double> () ;
			for (int i = 0; i < numStr.Length ; i++) {
				numbers.Add (Convert.ToDouble (numbers [i ])) ;
			}
			return numbers.ToArray () ;
		}
		#endregion
	}
}