/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-11
 * Time: 21:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.SqlServer.Server;

namespace LotteryTicket.ValidateResult
{
	/// <summary>
	/// 预测方法验证
	/// </summary>
	public static class ValidateMethods
	{
		#region 公共方法		
		/// <summary>
		/// 统计bool数组中True的比例,即正确率
		/// </summary>		
		public static double GetRateReuslt(bool[] result)
		{
			int sum = 0 ;
			foreach (bool element in result ) 
			{
				if (element ) 
				{
					sum ++ ;
				}
			}
			return ((double)sum)/((double)result.Length ) ;
		}
		#endregion
		
		#region 和值相关的验证
		//验证和值在一定范围的比例
		public static double SumInRangeLimite(double[][] data, double[] conditions)
		{
			//获取测试数据			
			bool[] res = PredictMethodsValidate.PredictValidate(data ,IndexNameType.A_Sum ,conditions,
			                                                     FilterRuleType.RangeLimite,0) ;
			return GetRateReuslt (res ) ;
		}			
		#endregion
		
		#region 跨度相关验证
		public static double MaxSpanInRangeLimite(double[][] data,double[] conditons)
		{
			bool[] res =PredictMethodsValidate .PredictValidate (data ,IndexNameType.A_MaxSpan ,conditons,
			                                                     FilterRuleType.RangeLimite,0) ;
			return GetRateReuslt (res ) ;
		}
		
		public static double MinSpanInRangeLimite(double[][] data,double[] conditons)
		{
			bool[] res =PredictMethodsValidate .PredictValidate (data ,IndexNameType.A_MinSpan ,conditons,
			                                                     FilterRuleType.RangeLimite,0) ;
			return GetRateReuslt (res ) ;
		}
		
	
		#endregion
		
		#region 多期验证
		public static double LatestValidate(double[][] data)
		{
			bool[] res =PredictMethodsValidate.PredictValidate (data ,IndexNameType.B_ManyNoOfNewCount,
			                                                    new double[]{1,3},FilterRuleType.RangeLimite,6) ;
			return GetRateReuslt (res ) ;
		}
		#endregion
		
		#region 综合验证
		public static double ComprehensiveValidate(double[][] data)
		{
			bool[][] res = new bool[5][] ;
			res[0] = PredictMethodsValidate.PredictValidate(data ,IndexNameType.A_Sum ,new double []{65,145},
			                                                     FilterRuleType.RangeLimite,0) ;
			res[1] =PredictMethodsValidate .PredictValidate (data ,IndexNameType.A_MaxSpan ,new double []{15,32},
			                                                     FilterRuleType.RangeLimite,0) ;
			res[2] =PredictMethodsValidate .PredictValidate (data ,IndexNameType.A_MinSpan ,new double []{1,3},
			                                                     FilterRuleType.RangeLimite,0) ;
			res[3] =PredictMethodsValidate.PredictValidate (data ,IndexNameType.A_SpanSum ,new double []{16,32},
			                                                            FilterRuleType.RangeLimite ,0) ;
			res[4] =PredictMethodsValidate.PredictValidate(data,IndexNameType.A_AcValue ,new double []{5,10},
			                                                            FilterRuleType.RangeLimite,0) ;
			return GetResult (res ) ;
		}
		
		public static double GetResult(bool[][] data)
		{
			int count = 0 ;
			for (int i = 0; i < data[0].Length ; i++)
			{
				for (int j = 0; j < data.Length ; j++)
				{
					if (!data [j] [i ])
					{
						count ++ ;
						break ;
					}
				}				
			}
			return ((double )(data[0].Length -count) )/((double )data[0].Length ) ;
		}
		#endregion		
	}
}