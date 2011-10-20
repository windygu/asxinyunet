/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:00
 * 
 *数据统计分析
 */
using System;
using System.Collections ;

namespace LotteryTicket
{	
	/// <summary>
	/// 每期指标计算静态类
	/// </summary>
	public class PerNoIndexCalculate
	{				
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
			double[] data = (double[])args ;
			double sum = 0 ;
			foreach(double a in data )
				sum += a ;
			return sum ;
		}
		
		/// <summary>
		/// 数据密度:和值/极差
		/// </summary>
		public static object A_DataDensity(object args)
		{
			return ((double )A_Sum(args ))/((double )A_MaxSpan(args )) ;
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
			double[] data = (double[])args ;
			double[] res = (double[])C_SpanList (data ) ;
			double temp = res [0 ] ;
			foreach (double a in res )
			{
				if (temp > a )
				{
					temp = a ;
				}
			}
			return temp ;
		}
		
		/// <summary>
		/// 跨度和值
		/// </summary>
		public static object A_SpanSum(object args)
		{
			double[] data = (double[])args ;
			double sum = 0 ;
			double[] res = (double[])C_SpanList (data );
			foreach (double a in res )
				sum += a ;
			return sum ;
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
		//多期中旧号出现的个数
		public static object B_ManyNoOfNewCount(object args)
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
			int count = 0 ;
			for (int i = 0; i < data[0].Length ; i++)
			{
				if (al.Contains (data[data.Length -1][i ]))
				{
					count ++ ;
				}
			}
			return (double )count ;
		}
		//多期相同的数据列表
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
		/// <param name="args"></param>
		/// <returns></returns>
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
	}
}