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
using DotNet.Tools ;

namespace LotteryTicket
{
	/// <summary>
	/// 数据过滤与数据分析保存
	/// </summary>
	public class DataFilter
	{
		//根据预测规则文件,进行数据过滤,得到预测数据,并保持到文件
		public static void GetPredictDataByRule(string ruleFilePath,string saveFilePath)
		{
			List<string >  ruleArr = new List<string > () ;
			
			#region 读取数据 并 处理
			//读取测试规则列表,将规则保存到字符串数组中
			using(StreamReader sr = new StreamReader (ruleFilePath ))
			{
				string str = "" ;
				while ((str =sr.ReadLine ())!=null )
				{
					if (!str.StartsWith ("#")) {
						//不是以#开头的为规则
						ruleArr.Add (str ) ;//添加
					}
				}
			}
			string[][] ruleStr = new string[ruleArr.Count ][] ;//存储规则名称,2列
			double[][] ruleParmas = new double[ruleArr.Count ][] ;//存储对应规则的参数列表
			int count = 0 ;
			foreach (string  element in ruleArr ) {
				string[] temp = element.Split (':') ;
				ruleStr [count ] = new string[]{temp [0],temp[1]} ;
				ruleParmas [count ] = temp [2].ConvertStrToDoubleList (',') ;
			}
			#endregion
			
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
		
		//从文件读取预测数据
		//TODO:文件验证，文件名唯一，需要验证
		public static double[][] GetPredictDataFormFile(string dataFilePath)
		{
			//规则类似测试文件,读取，方便更改
			List<string >  dataArr = new List<string >() ;		
			
			// 读取数据 并 处理
		   //首先读取测试的数据文件结果,保存到数据:每一行一期,蓝号放在最后 " ," 为分隔符
			using(StreamReader sr = new StreamReader (dataFilePath ))
			{
				string str = "" ;
				while ((str =sr.ReadLine ())!=null )
				{
					if (str !="") {
						dataArr .Add (str ) ;//添加测试数据
					}
				}
			}			
			double[][] testData = new double[dataArr.Count ][] ;;
			int count = 0 ;
			foreach (string element in dataArr ) {
				testData [count ++] = element.ConvertStrToDoubleList (',') ;
			}
			return testData ;
		}
		
		//验证实际预测结果的收获
		public static double ValidatePrizes(string dataFilePath , double[] prizedata)
		{			
			//TODO:循环数据 与 正确号码进行对比,确定奖等级
			//直接调用彩票类的兑奖计算		
			double[][] data = GetPredictDataFormFile (dataFilePath ) ;
			return TwoColorBall.GetAllPrizeReward (prizedata,data ) ;
		}
	}
}