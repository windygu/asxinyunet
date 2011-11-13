/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-3-14
 * Time: 13:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LotteryTicket
{
	#region 指标名称类型枚举
	public enum IndexNameType
	{
		//  A   []  --->  1个结果
		//  B   [][]  --->  1个结果
		//  C   []  --->  []多个结果	
		//  D   [][]  --->[]多个结果		
		//  F   统计规律常数类指标
		
		/// <summary>
		/// 自身数字,只支持[] -->[],主要用于胆号和杀号
		/// </summary>
		C_SelfNumber ,		
	
		A_PM001 ,
		A_PM002 ,
			
		/// <summary>
		/// 和值,返回1个double类型
		/// </summary>
		A_Sum ,
		
		/// <summary>
		/// 最大跨度,返回1个double类型
		/// </summary>
		A_MaxSpan ,
		
		/// <summary>
		/// 最小跨度,返回1个double类型
		/// </summary>
		A_MinSpan ,
		
		/// <summary>
		/// 跨度列表,返回1个double[]类型
		/// </summary>
		C_SpanList ,
				
		/// <summary>
		/// 跨度和值,返回1个double类型
		/// </summary>
		A_SpanSum ,
		
		/// <summary>
		/// Ac值，返回1个double类型
		/// </summary>
		A_AcValue ,
		
		/// <summary>                       
		/// 跨度密度,返回1个double类型
		/// </summary>
		A_SpanDensity ,
		
		/// <summary>
		/// 数据密度,返回1个double类型
		/// </summary>
		A_DataDensity ,		
		
		/// <summary>
		/// 多期中重复号码出现的个数
		/// </summary>
		B_ManyNoOfNewCount ,
		
		/// <summary>
		/// 每期最长的连续号码,2个2连续算3
		/// </summary>
		A_ContinuousCount 
	}
	#endregion
	
	#region 彩票类型枚举
	/// <summary>
	/// 彩票类型
	/// </summary>
	public enum LotTickType
	{
		/// <summary>
		/// 排列型,如32选5，选出几个数字，没有顺序
		/// </summary>
		Range ,
		
		/// <summary>
		/// 数字型,如3D，选出一个整数，号码不能变顺序
		/// </summary>
		Number
	}
	#endregion		
}
