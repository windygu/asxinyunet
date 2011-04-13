/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-5
 * Time: 7:33
 * 
 * 统计结果计算,根据框架内指标或者对个别不在框架内的特殊,重新实现
 */
using System;
using System.Collections;

namespace LotteryTicket
{
	/// <summary>
	/// 框架计算类,根据指标计算出统计规律,是构建预测方案的重要依据
	/// </summary>
	public class StaticsResult
	{	
		//多期内相同数字列表,计算重复的周期
		public static void CalcateRepeateNumber(double[][] data,int needLength)
		{
			double[][] result = (double[][])IndexCalculate.CalculateAllData (data,IndexNameType.D_ManyNosList,
			                                 new int[]{needLength }) ;
		}		
		
		#region 分段匹配		
		/// <summary>
		/// 分段匹配测试
		/// </summary>
		/// <param name="data">测试曙数据</param>
		/// <param name="sections">分段模式</param>
		public static int[][] SectionMathch(double[][] data , double[][] sections)
		{
			//返回每期覆盖到的段的个数
			Hashtable ht = new Hashtable () ;
			for (int i = 0; i < sections.Length ; i++) 
			{
				for (int j = 0; j < sections[i ].Length ; j++) 
				{
					ht.Add (sections[i ][j ],i ) ;//以号码为key，对应的段号位值
				}				
			}
			//记录结果数组,存储每一期出现的对应段的个数
			int[][] res = new int[data.Length ][] ;
			for (int i = 0; i < data.Length ; i++) //每期计算
			{
				res [i ] = new int[sections.Length ] ;
				for (int j = 0; j < data [i].Length ; j++) {
					int location = (int )ht[data [i ][j ]] ;
					res [i ][location ] ++ ;
				}
			}
			return res ;
		}
		
		public static int[] SectionMathchResult(double[][] data,double[][] sections)
		{
			int[][] matchRes = SectionMathch (data,sections ) ;
			//寻找零的个数
			int[] res = new int[data.Length ] ;
			for (int i = 0; i < matchRes.Length ; i++) {
				int count = 0 ;
				for (int j = 0; j < matchRes[i].Length ; j++) {
					//统计0的个数
					if (matchRes[i][j]==0) {
						count ++ ;
					}
					res [i ] = sections.Length - count ;
				}
			}
			return res ;
		}
		
		//统计每种模式结果的比例
		public static double[] SectionMathchRate(double[][] data,double[][] sections)
		{
			int[] mathRes = SectionMathchResult (data,sections ) ;
			double[] res = new double[sections.Length ] ;
			int[] resCount = new int[sections.Length ] ;
			for (int i = 0; i < mathRes.Length ; i++) {
				resCount [mathRes [i ]-1] ++ ;
			}
			for (int j = 0; j < resCount.Length ; j++) {
				res[j ] = ((double )resCount [j ])/( (double )data .Length  ) ;
			}
			return res ;
		}
		#endregion
		
		#region 数据频率
		public static double[] Frequency(double[][] data)
		{
			int[] count = new int[33] ;
			for (int i = 0; i < data.Length ; i++)
			{
				for (int j = 0; j < data [i].Length ; j++) 
				{
					count [(int )data [i][j]-1] ++ ;
				}
			}
			double[] res = new double[count.Length ] ;
			for (int i = 0; i < res.Length ; i++) {
				res [i ] = ((double )count [i ])/((double )data.Length*6 ) ;
			}
			return res ;
		}
		#endregion
		
	}
}