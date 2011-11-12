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
	/// 计算单期单个指标，以及所有数据的单个指标计算
	/// </summary>
	public static class IndexCalculate
	{	
		#region 根据类型名称和数据计算指标(单期指标)
		/// <summary>
        /// 根据类型名称和输入数据计算相应数据,需要进行的数据在外部传入
		/// </summary>
		/// <param name="data">数据(单期)</param>
		/// <param name="typeName">指标名称:根据名称来判断数据类别</param>
		/// <returns>该数据集合在指定的指标下计算的结果</returns>
		public static object CalculateIndex(object data,IndexNameType typeName)
		{
			//TODO:分别针对ABCD不同类型，输入数据可能不一样进行处理
			Type t = typeof (PerNoIndexCalculate);			
			MethodInfo mi = t.GetMethod (typeName.ToString ()) ;
			//invoke,传入数组参数
			return  mi.Invoke (null ,new object []{data }) ;
		}
	    #endregion

        #region	计算所有数据集指标的值(多期指标)
        /// <summary>
        /// 计算多期数据的指标，需要指标名称以及每计算一期所需要的行数,默认1行
        /// </summary>
        /// <param name="data">多期数据:可能为一维数组或者2维交错数组</param>
        /// <param name="typeName">指标名称:根据名称来判断数据类别</param>
        /// <param name="needRows">计算一次所需要的行数(需依赖的期数),默认为1</param>
        /// <returns>计算结果:结果类型根据名称来判断</returns>
		public static object CalculateAllData(object data,IndexNameType typeName ,int needRows = 1 )
		{
			string name = typeName.ToString () ;
			char ct = name[0] ;
			if ((ct == 'B')||(ct == 'D'))
			{
                return CalculateAllDataBD(data, typeName, needRows);
			}
			else if ((ct == 'A')||(ct == 'C'))
			{
				return CalculateAllDataAC (data,typeName) ;
			}
			return null ;
		}
		
		/// <summary>
        /// 计算多期BD类型的指标,需要输入所需的行
		/// </summary>
		/// <param name="data">多期数据</param>
        /// <param name="typeName">指标名称(BD类):根据名称来判断数据类别</param>
        /// <param name="needRows">计算一次所需要的行数(需依赖的期数),默认为1</param>
        /// <returns>计算结果:结果类型根据名称来判断</returns>
		public static object CalculateAllDataBD(object data,IndexNameType typeName ,int needRows = 1 )
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
                    for (int j = 0; j < needRows; j++)
					{
						sn [j ] = args [i +j ] ;
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
						sn [j ] = args [i +j ] ;
					}
					res [i ] = (double[]) mi.Invoke (null ,new object []{sn }) ;
				}
				return res ;
			}			
			else 
				return null ;
		}
		
        /// <summary>
        /// 计算多期AC类型的指标,需要输入所需的行
        /// </summary>
        /// <param name="data">多期数据</param>
        /// <param name="typeName">指标名称(AC类):根据名称来判断数据类别</param>
        /// <returns>计算结果:结果类型根据名称来判断</returns>
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