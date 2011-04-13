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
	}
}