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
	///数据的预处理
	/// </summary>
	public class DataProcess
	{
		//生成双色球全部数据,过滤掉3连号，均值小于12 和大于23的，跨度小于14的
		public static void GetCombListToTxtFile(string fileName,int[] args,int fileLength)
		{
            Combination com = new Combination(33, 6);
            var res = com.Rows;
            using (StreamWriter sw = new StreamWriter (fileName ))
            {
                foreach (Combination s in res)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        //添加到数组

                    }                   
                }               
            }		
		}
	}
}