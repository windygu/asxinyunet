/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-3-14
 * Time: 13:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace LotteryTicket
{
	#region 彩票类型基类
	public class BaseLotTickClass
	{
		public LotTickType lotTickType ;//彩票类型
		public string lotTickName ;     //彩票名称
		public string lotTickRemark ;   //彩票说明，比如规则
		public int allBallNumber ;      //开奖总球个数
		public int RedBallNumber ;      //开奖红球个数
		public int BlueBallNumber ;     //开奖蓝球个数
		public int RedNumRangeLimite ;  //红球范围上限，下限根据类型，从1或者0开始
		public int BlueNumRangeLimite ; //蓝球范围上限	
		public int[][] LotTickDatas ;    //彩票数据
		public int[][] redlotTickNoAfterFilt ;//过滤期号和日期后的数据号码		
		//过滤到期号及日期，得到处理前的数据
		//考虑增加一个控制开关和属性，可以动态调整计算的期数
		//比如，只计算最近的50期的和值，但是计算所有期的数字频率
		public bool IsAllDataUsed = true ;//是否计算所有数据,默认为true
		public int CurrentDataNumbers ; //当前所计算的数据期数，最近		
	}
	#endregion
	
	/// <summary>
	/// 获取网络彩票数据接口
	/// </summary>
	interface IGetWebLotTickData
	{
		void GetAllHistoryData(int pages) ;//获取所有历史数据
		void UpdateRecentData (int pages) ;//更新最新数据
	}
	
	/// <summary>
	/// 获取彩票数据类基类
	/// </summary>
	public class BaseGetLotTicData
	{
	    
	}
}
