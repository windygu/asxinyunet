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
using System.Collections.Generic;
using System.Collections.ObjectModel ;
using System.Security.Cryptography ;

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
		public static double[] Frequency(double[][] data,int numbers)
		{
			int[] count = new int[numbers ] ;
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
		
		#region 动态进行模式的筛选
		/// <summary>
		/// 验证所有的随机模式,进行匹配，得到结果
		/// </summary>
		/// <param name="data"></param>
		/// <param name="numbers"></param>
		public static void  ValidateAllSections(double[][] data,int numbers)
		{
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider () ;
			byte[] curLocate = new Byte[1] ;
		}
		
		public static void  GetDynamicSections(double[][] data,int numbers)
		{
			//先将所有组合存储到SortedDictionary中
			SortedDictionary<string , int> allComb = new SortedDictionary<string ,int> () ;
			for (int i = 1; i <= numbers -1 ; i++) {
				for (int j = i +1; j <= numbers ; j++) {
					allComb.Add (((int)i).ToString ()+"-"+((int )j ).ToString (),0) ;
				}
			}
			for (int i = 0; i < data.Length ; i++) {
				for (int j = 0 ; j < data[i].Length -1 ; j++) {
					for (int k = j +1 ; k <data [i ].Length ; k++) {
						string sn = ((int)data [i][j]).ToString ()+"-"+((int)data [i ][k ]).ToString () ;
						allComb[sn ] = allComb[sn ]+1 ;
					}
				}
			}
			//对结果进行排序,每次找出一个最大值,删除,再进行
			System.Collections.Generic.SortedList<int,CombFrequce> sortRes = 
				new System.Collections.Generic.SortedList <int,CombFrequce>();
			for (int i = 0; i < allComb.Count -80 ; i++) 
			{
				foreach (DictionaryEntry  element in allcom) {
					
				}
			}
		}
		public class CombFrequce
		{
			private string combName ;
			
			public string CombName {
				get { return combName; }
				set { combName = value; }
			}
			private int combCount ;
			
			public int CombCount {
				get { return combCount; }
				set { combCount = value; }
			}
			public CombFrequce (string name,int count)
			{
				combName = name ;
				combCount = count ;
			}
		
		}
		#endregion
		
	}
}