/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-11
 * Time: 21:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

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
		public static void SumRelevantValidate()
		{
			
		}
		#endregion
	}
}
