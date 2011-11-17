﻿/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-11-17
 * 时间: 16:08
 * 
 * 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

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
		/// 多期数据中,出现重复号码的个数
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
	
	/// <summary>
	/// 项目常规帮助类
	/// </summary>
	public class LotTicketHelper
	{
		#region  文本文件的规则解析:界面上动态添加规则，并更新到文本。最后还是通过文本的规则来解析，结果记录方便
		/// <summary>
		/// 解析规则文本
		/// </summary>
		/// <param name="ruleFilePath">规则文件路径</param>
		/// <returns>规则列表</returns>
		public static List<string> GetRuleListFormFile(string ruleFilePath)
		{
			List<string> ruleList = new List<string>();//规则列表
			using (StreamReader sr = new StreamReader(ruleFilePath))
			{
				string line = null;
				while ((line = sr.ReadLine()) != null)
				{
					if (line.StartsWith("#") || (line.Length < 5))
					{
						continue;
					}
					ruleList.Add(line);//添加
				}
			}
			return ruleList;
		}

		/// <summary>
		/// 根据规则列表解析规则
		/// </summary>
		/// <param name="ruleList">规则数组列表</param>
		/// <returns>规则字符串数组</returns>
		public static string[][] ParseRuleList(List<string> ruleList)
		{
			string[][] res = new string[ruleList.Count][];
			//TODO:解析文本，增加一个特殊规则的处理，特殊规则的处理，到最底层处理
			//先：分割
			for (int i = 0; i <ruleList.Count ; i++)
			{
				List<string> strList = new List<string>();
				string[] temp = ruleList [i].Split (':') ;
				if (temp.Length==4) //只能有3个
				{
					if (temp[3].Contains("#"))
					{
						res[i] = new string[6];
						string[] t = temp[3].Split('#');//再次分割
						res[i][0] = temp[0].Trim();
						res[i][1] = temp[1].Trim();
						res[i][2] = temp[2].Trim();
						res[i][3] = t[0].Trim ();
						res[i][4] = t[1].Trim();
						res[i][5] = t[2].Trim();
					}
					else
					{
						res[i] = new string[4];
						res[i][0] = temp[0].Trim();
						res[i][1] = temp[1].Trim();
						res[i][2] = temp[2].Trim();
						res[i][3] = temp[3].Trim();
					}
				}
			}
			return res;
		}

		//拼接字符串
		public static string CombStringArr(string[] str)
		{
			if (str.Length == 4)
			{
				return str[0] + ":" + str[1] + ":" + str[2] + ":" + str[3];
			}
			else
			{
				return str[0] + ":" + str[1] + ":" + str[2] + ":" + str[3] +"#"+str [4]+"#"+str [5];
			}
		}
		#endregion
		
		#region 生成文件名和验证文件是否合法
		/// <summary>
		/// 验证文件是否合法
		/// </summary>
		/// <param name="filePath">文件全路径名称:根据名称和内容验证其合法性</param>
		/// <returns>True 合法文件 ; False 非法文件</returns>
		public static bool FileValidation(string filePath)
		{
			//TODO:需要设计相应的规则,并在生成时就确定
			return true;
		}
		
		/// <summary>
		/// 根据原始规则文件名以及其他信息得到合法的最终文件名
		/// </summary>
		/// <param name="origFilePath">原始的临时文件</param>
		/// <returns >合法的文件名</returns>
		public static string GetRigthFileName(string origFilePath)
		{
			//TODO:加密,根据硬件、时间、以及规则来生成
			return "";
		}
		#endregion

		#region 根据预测规则文件,进行数据过滤,得到预测数据,并保存到文件
		/// <summary>
		///  根据预测规则文件,进行数据过滤,得到预测数据,并保存到文件
		/// </summary>
		/// <param name="ruleFilePath">规则文件名称</param>
		/// <param name="saveFilePath">保存文件名称</param>
		public static void GetPredictDataByRule(string ruleFilePath,string saveFilePath)
		{
			List<string >  ruleArr = new List<string > () ;
			#region 读取数据并处理
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
		#endregion

		#region 从文件读取预测数据
		/// <summary>
		/// 从文件读取预测数据
		/// </summary>
		/// <param name="dataFilePath">文件名称</param>
		/// <returns>预测文件中的数据集合</returns>
		public static double[][] GetPredictDataFormFile(string dataFilePath)
		{
			//TODO:文件验证，文件名唯一，需要验证
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
		#endregion

		#region 验证实际预测结果的收获
		/// <summary>
		/// 验证实际预测结果的收获
		/// </summary>
		/// <param name="dataFilePath">实际预测文件路径名称</param>
		/// <param name="prizedata">实际中奖数据</param>
		/// <returns>实际收益(按照所有预测文件单注计算)</returns>
		public static double ValidatePrizes(string dataFilePath , double[] prizedata)
		{
			//TODO:循环数据 与 正确号码进行对比,确定奖等级
			//直接调用彩票类的兑奖计算
			double[][] data = GetPredictDataFormFile (dataFilePath ) ;
			return TwoColorBall.GetAllPrizeReward (prizedata,data ) ;
		}

		/// <summary>
		/// 验证实际预测结果的收获
		/// </summary>
		/// <param name="dataFilePath">实际预测文件路径名称</param>
		/// <param name="prizedata">实际中奖数据</param>
		/// <returns>实际收益(按照所有预测文件单注计算)</returns>
		public static double ValidatePrizes(double[][] predictData, double[] prizedata)
		{
			return TwoColorBall.GetAllPrizeReward(prizedata, predictData);
		}
		#endregion
		
		#region 过滤处理
		/// <summary>
		/// 生成双色球全部数据,默认过滤指标：3连号及以上、和值、跨度
		/// </summary>
		/// <param name="fileName">最终号码存储的文件名</param>
		public static List<double[]> InitialFilterData(double[] deleteNumbers,int latestNos = 5,int repeatNumbers =2)
		{
			double[] data = new double[33] ;//初始化所有号码
			List <double > listNumbers = new List<double> () ;
			//初始化
			for (int i = 0; i < data.Length ; i++) {listNumbers.Add ((double )(i + 1)) ;}
			//杀号处理
			for (int i = 0; i < deleteNumbers.Length ; i++) {listNumbers.Remove (deleteNumbers[i ]) ;}
			//迭代获取所有组合序列,并对每个序列进行判断
			List<double[]> res = new List<double[]> () ;
			foreach (Combination combom in new Combination(data.Length ,6).Rows)
			{
				double[] curComb= Combination.Permute (combom, data).ToArray () ;
				//杀组合，参数为最近的期数和最大重复数,也可以单独杀
				if (latestNos >0) //最近的期数
				{
					//先获取需要杀号的数据
					bool temp = true ;
					double[][] deleteNos = TwoColorBall.GetRedBallData (latestNos ) ;
					for (int i = 0; i < deleteNos.GetLength ( 0 ); i++)
					{
						if (IndexCalculate.GetRepeatNumbers (curComb,deleteNos [i])>=repeatNumbers )
						{
							temp = false ;
							break ;
						}
					}
					if (temp ) res.Add (curComb ) ;//符合要求则添加
				}
			}
			return res ;
		}
		#endregion
		
		#region 杀组合
		/// <summary>
		/// 杀组合,杀掉一组序列中所有指定的组合
		/// </summary>
		/// <param name="origData">原始序列</param>
		/// <param name="deleteNumber">需要排除的序列组合</param>
		/// <param name="numbers">组合数</param>
		public static void DeleteCombinationNumbers(List<double[]> origData,
		                                            double[] deleteNumber,int numbers)
		{
//			List<int > flag = new List<int > () ;
//			for (int i = 0; i < origData.Count ; i++)
//			{
//				if (IndexCalculate.GetRepeatNumbers (element,deleteNumber )>=numbers )
//				{
//					flag.Add (i ) ;//将位置添加到序列,统一删除
//				}
//			}
			origData.RemoveAll (delegate (double[] cur){
			                    	return IndexCalculate.GetRepeatNumbers (cur ,deleteNumber )>=numbers? true:false;});
		}
		/// <summary>
		///  杀组合,杀掉一组序列中所有指定的组合
		/// </summary>
		/// <param name="origData">原始序列</param>
		/// <param name="combStr">组合,-分隔每个数字，逗号分隔2个组合：2-3-4,3-6-8</param>
		public static void DeleteCombinationNumbers(List<double[]> origData,string combStr)
		{
			string[] numStr = combStr.Split (',');
			for (int i = 0; i < numStr.Length ; i++) {
				double[] temp = GetSpliteNumbers (numStr [i ]) ;
				DeleteCombinationNumbers(origData,temp ,temp.Length ) ;
			}
		}
		/// <summary>
		/// 分隔字符串，获得一组序列,逗号分隔
		/// </summary>
		/// <param name="combStr"></param>
		/// <returns></returns>
		public static double[] GetSpliteNumbers(string combStr)
		{
			string[] numStr = combStr.Split ('-') ;
			List<double > numbers = new List<double> () ;
			for (int i = 0; i < numStr.Length ; i++) {
				numbers.Add (Convert.ToDouble (numbers [i ])) ;
			}
			return numbers.ToArray () ;
		}
		#endregion
	}
}