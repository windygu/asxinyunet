/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-19
 * Time: 21:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using Kw.Combinatorics;

namespace LotteryTicket
{
	/// <summary>
	/// 数据过滤与数据分析保存
	/// </summary>
	public class DataFilter
	{
		public static void GetPredictData(string filePath)
		{
			//保存到数据文件,每行一组
			Combination com = new Combination(33,6) ;			
			var res = com.Rows ;
			foreach (var s in res )
			{
				//先得到组号码组
				foreach (var element in s ) {
					Console.Write (element.ToString () +"  ") ;
				}
				Console.WriteLine () ;
			}
			Console.WriteLine (com.Rank .ToString ());
		}
		
		//验证实际预测结果的收获
		public static void ValidatePrizes(string dataFilePath,string ruleFilePath)
		{
			//规则类似测试文件,读取，方便更改
			
			//首先读取测试的数据文件结果,保存到数据:每一行一期,蓝号放在最后 " ," 为分隔符
			List<var>  dataArr = new List<double >() ;
			double[][] testData ;
			using(StreamReader sr = new StreamReader (dataFilePath ))
			{
				string str = "" ;
				while ((str =sr.ReadLine ())!=null )
				{
					
				}
			}
			//读取测试规则列表,将规则保存到字符串数组中
		}
	}
}