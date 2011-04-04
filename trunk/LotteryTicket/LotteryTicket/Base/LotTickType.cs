/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-17
 * Time: 22:17
 * 
 *彩票类型的一些基本对象，接口，基类等
 */
using System;

namespace LotteryTicket
{
	
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

	//计算委托类型
	public delegate object CalculateHandler(int[][] args);
	
//	interface IFilter
//	{
//		bool IsSatisfy(int[] data , params object[] Conditons) ;
//	}
	
	/// <summary>
	/// 得到每组号码指标接口,单一指标
	/// </summary>
	interface IGetPerRecordIndex
	{
		double[] GetPerRecordIndex(int[] data) ;
	}
	
	/// <summary>
	/// 彩票红球计算接口
	/// </summary>
	public interface IRedLotTick
	{
		object Calculate(CalculateHandler calc );
	}	
}