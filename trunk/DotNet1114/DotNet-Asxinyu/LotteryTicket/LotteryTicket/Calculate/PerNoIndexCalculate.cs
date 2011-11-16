/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:00
 * 
 *
 */
using System;
using System.Collections ;
using System.Collections.Generic ;
using System.Linq;

namespace LotteryTicket
{	
	/// <summary>
	/// 单个指标计算
	/// </summary>
	public class PerNoIndexCalculate
	{
		/// <summary>
		/// 质数集合
		/// </summary>
		public static readonly double[] PrimeNumbers =new double[] {2,3,5,7,11,13,17,19,23,29,31};
		
		#region 自身数据
		public static object C_SelfNumber(object args)
		{          
			return args ;
		}
		#endregion
				
		#region 和值与数据密度
		/// <summary>
		/// 计算和值
		/// </summary>
		public static object A_Sum(object args)
		{			
            return ((double[])args).Sum();//返回和值
		}
		
		/// <summary>
		/// 数据密度:和值/极差
		/// </summary>
		public static object A_DataDensity(object args)
		{
            return ((double[])args).Sum()/((double)A_MaxSpan(args));
		}
		#endregion
		
		#region 跨度
		/// <summary>
		/// 计算最大跨度
		/// </summary>
		public static object A_MaxSpan(object args)
		{
			double[] data = (double[])args ;
			return (data[data.Length -1] - data [0]) ;
		}
		
		/// <summary>
		/// 计算跨度列表
		/// </summary>
		public static object C_SpanList(object args)
		{
			double[] data = (double[])args ;
			double[] res = new double[data.Length -1 ] ;//少一个
			for (int i = 0 ; i <res.Length ; i ++) 
			{
				res [i ] = data [i +1]-data [i ] ;
			}
			return res ;
		}
		
		/// <summary>
		/// 最小跨度
		/// </summary>
		public static object A_MinSpan(object args)
		{
            double[] res = (double[])C_SpanList(args);
            return res.Min();//返回最小值
		}
		
		/// <summary>
		/// 跨度和值
		/// </summary>
		public static object A_SpanSum(object args)
		{	
			double[] res = (double[])C_SpanList (args );
            return res.Sum();
		}
		
		/// <summary>
		/// 跨度密度:跨度和/最大跨度
		/// </summary>
		public static object A_SpanDensity(object args)
		{
			double spansum =(double ) A_SpanSum (args ) ;
			double max = (double ) A_MaxSpan (args ) ;
			return spansum /max ;
		}
		#endregion
		
		#region AC值
		/// <summary>
		/// Ac值=差值个数-(6-1)
		/// </summary>
		public static object A_AcValue(object args)
		{
			double[] data = (double[])args ;
			ArrayList list = new ArrayList () ;
			double temp ;
			for (int i = 0 ; i <data.Length -1 ; i ++)
			{
				for (int j = i +1 ; j <data.Length ; j ++)
				{
					temp = data [j ] - data [i ] ;
					if (!list.Contains (temp ))
					{
						list.Add (temp ) ;
					}
				}
			}
			return (double )(list.Count -(data.Length -1)) ;
		}
		#endregion
		
		#region 多期号码
        /// <summary>
        /// 多期号码中，号码所有出现的个数，去掉重复的
        /// </summary>        
		public static object B_ManyNoCounts(object args)
		{
			double[][] data = (double[][])args ;//多期数据
			ArrayList al = new ArrayList ();
			for (int i = 0 ; i <data.Length ; i ++)
			{
				for (int j=0 ; j <data[0].Length ; j ++)
				{
					if (!al.Contains(data[i][j]))
					{
						al.Add (data[i][j]);
					}
				}
			}
			return (double )al.Count ;
		}
		/// <summary>
        /// 多期数据中,出现重复号码的个数
		/// </summary>		
		public static object B_ManyNoOfNewCount(object args)
		{
			double[][] data = (double[][])args ;//多期数据
            int count = 0;
			ArrayList al = new ArrayList ();
			for (int i = 0 ; i <data.GetLength (0) ; i ++)
			{
				for (int j=0 ; j <data[0].Length ; j ++)
				{
                    if (!al.Contains(data[i][j])) { al.Add(data[i][j]); }
                    else { count++; }
				}
			}
			return (double )count ;
		}
		/// <summary>
        /// 多期相同的数据列表？？？
		/// </summary>	
		public static object D_ManyNosList(object args)
		{
			double[][] data = (double[][])args ;//多期数据
			ArrayList al = new ArrayList ();
			for (int i = 0 ; i <data.Length -1 ; i ++)
			{
				for (int j=0 ; j <data[0].Length ; j ++)
				{
					if (!al.Contains (data[i][j]))
					{
						al.Add (data[i][j]);
					}
				}
			}
			ArrayList resList = new ArrayList () ;
			for (int i = 0; i < data[0].Length ; i++)
			{
				if (al.Contains (data[data.Length -1][i ]))
				{
					resList .Add (data[data.Length -1][i ]) ;
				}
			}
			double[] d = (double[])resList.ToArray(typeof (double )) ;
			return d ;
		}
		#endregion
		
		#region 统计次数与频率 FrequCount FrequPrecent
		/// <summary>
		/// 计算在当前期内出现的次数
		/// </summary>
		public static object FrequCount(int[][] args)
		{
			//先从最后一列找出最大值,确定出现的最大数字
			int max = args [0][args[0].Length-1] ;
			for (int i = 0 ; i <args.Length ; i ++ )
			{
				if (args [i ][args [0].Length -1]>max )
				{
					max = args [i ][args [0].Length -1] ;
				}
			}
			int[] count = new int[max ] ;
			for (int i = 0 ; i <args.Length ; i ++ )
			{
				for (int j = 0 ; j <args[0].Length ; j ++)
				{
					count[args [i ][j ]-1] ++ ;
				}
			}
			return count ;
		}
		
		/// <summary>
		/// 计算百分比频率
		/// </summary>
		public static object FrequPrecent(int[][] args)
		{
			int[] count = (int[])FrequCount (args ) ;
			double[] res = new double[count .Length ] ;
			for (int i = 0 ; i <res.Length ; i ++)
			{
				res [i ] = ((double )count [i ])/((double )args .Length);
			}
			return res ;
		}
		#endregion		
		
		#region PM001A
		/// <summary>
		/// 利用PM001算法计算预期结果
		/// 当期开奖号码大小顺序第一位与第六位的差，计算的结果在下一期有可能不出
		/// </summary>
		public static object A_PM001(object args)
		{
			double[] data = (double[])args ;
			return (double ) PerNoIndexCalculate.A_MaxSpan  (data ) ;//跨度			
		}
		#endregion
		
		#region PM002A
		/// <summary>
		/// 当期开奖号码大小顺序第二位与第三位的差，计算的结果在下一期有可能不出
		/// </summary>
		public static object A_PM002(object args)
		{
			double[] data = (double[])args ;
			return data [2]-data [1] ;
		}
		#endregion
		
		#region 每期最长的连续号码个数,2个2连续算3
		/// <summary>
		/// 每期最长的连续号码个数,2个2连续算3
		/// </summary>	
		public static double A_ContinuousCount(double[] args)
		{
			double[] res = (double[])C_SpanList (args ) ;//计算跨度
            int count = res.Where(n => n == 1).Count();//计算==1的个数			
			return (double)(count +1) ;
		}
		#endregion
		
		#region 质数个数计算
		/// <summary>
		/// 每期质数的个数
		/// </summary>		
		public static int A_PrimeCount(double[] args)
		{
			return IndexCalculate.GetRepeatNumbers (PrimeNumbers,args ) ;
		}
		#endregion
		
		#region 偶数个数计算
		/// <summary>
		/// 计算每期的偶数的个数
		/// </summary>
		public static int A_EvenNumber(double[] args)
		{
			return args.Where (n=>((int )n )%2 ==0).Count ();
		}
		#endregion

        #region 求余来计算覆盖的范围的个数
        /// <summary>
        ///  求余来计算覆盖的范围的个数,0到L-1出现的个数
        /// </summary>
        /// <param name="args">数据</param>
        /// <param name="L">求余参数</param>
        /// <returns>出现的个数</returns>
        public static int A_CoverCount(double[] args, int L)
        {
            return args.Select(n => ((int)n) % L).Distinct().Count();
        }
        #endregion
    }
}