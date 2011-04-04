/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-18
 * Time: 21:06
 * 
 *  指标计算静态类
 */
using System;
using System.Collections.Generic ;
using System.Reflection ;

namespace LotteryTicket
{
	/// <summary>
	/// 所有数据指标计算静态类
	/// </summary>
	public static class IndexCalculate
	{	
		#region 根据类型名称和数据计算指标,单期指标
		/// <summary>
		/// 根据类型名称和输入数据计算相应数据,需要进行的数据在外部传入
		/// </summary>
		public static object CalculateIndex(object data,IndexNameType typeName)
		{
			//TODO:分别针对ABCD不同类型，输入数据可能不一样进行处理
			Type t = typeof (PerNoIndexCalculate);			
			MethodInfo mi = t.GetMethod (typeName.ToString ()) ;
			//invoke,传入数组参数
			return  mi.Invoke (null ,new object []{data }) ;
		}
	    #endregion
	    
		#region	计算所有数据集指标的值
		public static object CalculateAllData(object data,IndexNameType typeName ,params int[] needRows)
		{
			string name = typeName.ToString () ;
			char ct = name[0] ;
			if ((ct == 'B')||(ct == 'D'))
			{
				return CalculateAllDataBD (data,typeName,needRows [0]) ;
			}
			else if ((ct == 'A')||(ct == 'C'))
			{
				return CalculateAllDataAC (data,typeName) ;
			}
			return null ;
		}
		
		/// <summary>
		/// 计算整个数据集的某一指标,需要输入所需的行
		/// </summary>		
		public static object CalculateAllDataBD(object data,IndexNameType typeName ,int needRows )
		{
			Type t = typeof (PerNoIndexCalculate) ;
			string name = typeName.ToString () ;
			MethodInfo mi = t.GetMethod (name) ;
			char ct = name[0] ;
			double[][] args = (double[][]) data ;
			int min = 0 ;
			int max = args.Length - needRows ;//确认？
			if (ct =='B')
			{				
				double[] res = new double[args.Length -needRows + 1 ] ;
				//invoke,传入数组参数
				for (int i = min ; i <= max; i ++ )
				{
					double[][] sn = new double[needRows ][] ;
					for (int j = 0 ; j <sn.Length ; j ++)
					{
						sn [j ] = args [min +j ] ;
					}
					res [i ] = (double) mi.Invoke (null ,new object []{sn }) ;
				}
				return res ;
			}
			else if (ct == 'D')			
			{
				double[][] res = new double[args.Length -needRows +1][] ;
				//invoke,传入数组参数
				for (int i = min ; i < max; i ++ )
				{
					double[][] sn = new double[needRows ][] ;
					for (int j = 0 ; j <sn.Length ; j ++)
					{
						sn [j ] = args [min +j ] ;
					}
					res [i ] = (double[]) mi.Invoke (null ,new object []{sn }) ;
				}
				return res ;
			}			
			else 
				return null ;
		}
		
		public static object CalculateAllDataAC(object data,IndexNameType typeName)
		{
			Type t = typeof (PerNoIndexCalculate) ;
			string name = typeName.ToString () ;
			MethodInfo mi = t.GetMethod (name) ;
			char ct = name[0] ;
			double[][] args = (double[][]) data ;
			if (ct =='A') //[] -- 1
			{				
				double[] res = new double[args.Length ] ;
				//invoke,传入数组参数
				for (int i = 0 ; i <args.Length ; i ++ )
				{
					res [i ] = (double) mi.Invoke (null ,new object []{args[i ]}) ;
				}
				return res ;
			}
			else if (ct == 'C' )	  //[] --- []
			{
				double[][] res = new double[args.Length ][] ;
				for (int i = 0 ; i <args.Length ; i ++)
				{
					//invoke,传入数组参数
					res [i ] = (double[]) mi.Invoke (null ,new object []{args [i ]}) ;
				}
				return res ;
			}			
			else 
				return null ;
		}
		#endregion
	}
}