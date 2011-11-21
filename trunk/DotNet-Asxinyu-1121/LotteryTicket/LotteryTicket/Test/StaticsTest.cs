/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-5
 * Time: 7:33
 * 
 * 统计结果计算,根据框架内指标或者对个别不在框架内的特殊,重新实现
 * 
 * 主要用来进行一些工作的验证
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Cryptography;

namespace LotteryTicket
{
	/// <summary>
	/// 历史代码，淘汰框架计算类,根据指标计算出统计规律,是构建预测方案的重要依据
	/// </summary>
	class StaticsResult
	{			
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
					ht.Add (sections[i ][j ],i ) ;//以号码为key，对应的段号为值
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
		
		//得到数据匹配的结果,每一期中分配到段的个数
		public static int[] SectionMathchResult(double[][] data,double[][] sections)
		{
			int[][] matchRes = SectionMathch (data,sections ) ;
			//寻找零的个数
			int[] res = new int[data.Length ] ;
			for (int i = 0; i < matchRes.Length ; i++) 
			{
				int count = 0 ;
				for (int j = 0; j < matchRes[i].Length ; j++) 
				{
					//统计0的个数
					if (matchRes[i][j]==0)
					{
						count ++ ;
					}	
				}
				res [i ] = sections.Length - count ;
			}
			return res ;
		}
		
		//统计每种模式结果的比例
		public static double[] SectionMathchRate(double[][] data,double[][] sections)
		{
			int[] mathRes = SectionMathchResult (data,sections ) ;
			double[] res = new double[sections.Length ] ;
			int[] resCount = new int[sections.Length ] ;
			for (int i = 0; i < mathRes.Length ; i++)
			{
				resCount [mathRes [i ]-1] ++ ;
			}
			for (int j = 0; j < resCount.Length ; j++)
			{
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
		public static void ValidateRandomSections(double[][] data,int[] kCount,int numbers)
		{
			//for (int i = 0; i <1000; i++) {
			while (true ){
				double[][] section = GetRandomSections (kCount ,numbers ) ;
				double[] res = SectionMathchRate (data,section ) ;				
				if ((res [res.Length -1]>0.282)&&((res [res.Length -2])>0.45))
				{
					using(StreamWriter sw = new StreamWriter("a.txt",true ))
					{
						sw.WriteLine (res[res.Length -1].ToString () + ","+res [res.Length -2].ToString ()+","
						              +(res [res.Length -1]+res [res.Length -2]).ToString ()) ;
						
						for (int i = 0; i < section.Length ; i++) {
							string str= section [i][0].ToString () ;
							for (int j = 1; j < section[i].Length ; j++) {
								str += ("," + section [i][j ]) ;
							}
							sw.WriteLine (str ) ;
						}
						sw.WriteLine ("---------------------------");
					}
//					Console.WriteLine (res[res.Length -1].ToString () + ","+(res [res.Length -1]+res [res.Length -2]).ToString ()) ;
				}
			}			
		}
		
		/// <summary>
		/// 验证所有的随机模式,进行匹配，得到结果，kCount为分配的段数集合,numbers为号码的范围
		/// </summary>
		public static double[][]  GetRandomSections(int[] kCount , int numbers)
		{
			double[][] res = new double[kCount.Length ][] ;
			List<double > curlist = new List<double >() ;
			for (int i = 0; i <numbers ; i++) {
				curlist.Add (i +1) ;
			}
			for (int i = 0; i <kCount.Length -1 ; i++) {
				res[i ] = GetList (kCount [i ],curlist ) ;
			}
			res [kCount.Length  -1] = curlist.ToArray () ;
			return res ;
		}
		public static double[] GetList(int count ,List<double > curList)
		{
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider () ;
			byte[] curLocate = new Byte[1] ;
			double[] res = new double[count ]  ;
			for (int i = 0; i < count ; i++) {
				rng.GetBytes (curLocate ) ;
				int temp = (int )((curLocate[0])%curList.Count) ;
				res [i ] = curList[temp ] ;
				curList.RemoveAt (temp ) ;
			}
			return res ;
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
//			for (int i = 0; i < allComb.Count -80 ; i++) 
//			{
//				foreach (DictionaryEntry  element in allcom) {
//					
//				}
//			}
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