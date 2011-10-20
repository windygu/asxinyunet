/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-17
 * Time: 22:08
 * 
 * 用于获取实时的彩票开奖数据
 */
using System;

namespace LotteryTicketData
{
	enum AllType
	{
		AA,
		BB,
		CC			
	}
	
	class Program
	{
		public static void Main(string[] args)
		{
			string conStr = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=LotteryTicket.mdb" ;
			GetSSQDataFromWeb data = new GetSSQDataFromWeb (conStr ) ;
			data.UpdateRecentData (5) ;
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}