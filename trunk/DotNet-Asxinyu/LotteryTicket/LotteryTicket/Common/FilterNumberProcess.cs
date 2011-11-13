/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-19
 * Time: 17:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO ;

namespace LotteryTicket.Common
{
	/// <summary>
	///数据过滤处理
	/// </summary>
    public class FilterNumberProcess
	{
		/// <summary>
        /// 生成双色球全部数据,过滤掉3连号，均值小于12 和大于23的，跨度小于14的
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="args"></param>
		/// <param name="fileLength"></param>
        public static void InitialFilterData(string fileName, int[] args, int fileLength)
		{           

		}
	}
}