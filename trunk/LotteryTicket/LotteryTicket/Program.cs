/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-17
 * Time: 22:11
 * 
 * 开发计划
 * 
 * 将统计数据指标结果最后全部转换为double型,统一,方便统一计算处理  ？？再考虑一下必要性
 * 
 * TODO:1.完善B D类测试数据与测试程序;
 *      2.对测试程序中的相关方法进行改进,重构,例如:获取整理测试数据方法,根据字符串获取测试数据等
 * 
 *      3.将预测类分为：规律测试后类  和  规律验证类
 *             规律测试：是每一期 或 前几期的规律进行分析验证
 *             预测方法验证：是上一期或者几期 组合的预测方法 预测到下一期的结果
 * 
 * 
 * 彩票处理程序类库
 * 
 * 2011-04-11 晚上预测类，修改为规律测试与预测方法验证
 * 2011-04-05 完成与修改测试程序小错误,以及预测方法的改进,可以自定义输入对比条件,简化某些指标的验证过程
 * 2011-03-24 完成所有预测方法数据的计算与正确率对比,修改程序与测试,同通过第一个单元测试
 * 2011-03-21 完成单个指标所有数据计算的测试,主要是AC类,完成测试框架和测试数据格式
 * 2011-03-19 完成单个指标计算的测试,主要是AC类别。完成测试框架,测试数据格式等
 * 2011-03-17 建立NUnit单元测试框架,测试发现潜在的几个重大指标计算错误
 * 2011-03-16 设计预测统计数据集合类.预测分为指标计算与对比数据计算
 * 2011-03-14 将预测指标与统计指标统一 
 * 2011-03-10 优化指标统计与预测类结构,特别是杀号和胆号 
 * 2011-03-01 完成指标名称类型枚举,以及指标静态计算类 
 * 2010-02-28 重新规划软件系统结构,采用反射，动态调用相关方法进行计算 
 * 2011-02-21 完成数据过滤器接口,并实现求和与跨度过滤类. 
 * 2011-02-20 完善获取中奖数据类和接口.完成双色球数据采集,
 *            确定指标统计与指标计算类
 * 2011-02-19 确定文件存储结构,生成初始所有排列数据,存入文本文件,方便过滤 
 * 2011-02-18 确定基本程序架构，接口实现彩票类计算，采用委托实现指标的计算
 *            思路来自NewLief群网友帮助。建立双色球彩票类。
 *            完成和值与跨度2个检测指标
 *            改用交错数组存储数据和结果
 *            增加计算期数属性，可以动态调整需要计算的数据期数
 * 2011-02-17 开始整理程序结构，彩票基类、枚举类型等
 * 2010-02-10 编写从网页获取数据的基本类库,用于结果采集存储
 * 2010-02-05 产生基本思路和想法 
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using LotteryTicket.ValidateResult;
using DotNet.Tools;

namespace LotteryTicket
{
	class Program
	{
		public static void Main(string[] args)
		{			
			double[][] data= TwoColorBall.GetRedBallData (200) ;
			double[][] sections = new double[5][] ;
			sections [0] = new double[] {1,2,3,4,5,6,7};
			sections [1] = new double[] {8,9,10,11,12,13,14};
			sections [2] = new double[] {15,16,17,18,19,20,21};
			sections [3] = new double[] {22,23,24,25,26,27,28};
			sections [4] = new double[] {29,30,31,32,33};
//			double[][] res = StaticsResult.ValidateAllSections  ( ; double[] res = 
			StaticsResult.ValidateRandomSections (data,new int[5]{7,6,7,6,7},33) ;
//			double[] res = StaticsResult.Frequency (data,33 ) ;
//			foreach (double   element in res ) {
//				Console.WriteLine (element.ToString ()) ;
//			}
//			double[][] result = (double[][])IndexCalculate.CalculateAllData (data,IndexNameType.D_ManyNosList,
//			                                 new int[]{2 }) ;			
//			double[][] res = StaticsResult.CalcateRepeateNumber (data ,2) ;
			//Console.WriteLine (ValidateMethods.LatestValidate (data)) ;
//			Console.Write("Press any key to continue . . . ");
//			while (true )
//			{
//				Console.Write ("输入条件：") ;
//				double[] condition = Console.ReadLine ().ConvertStrToDoubleList (',') ;
//				double res = PredictMethodsValidate.GetValidateResult
//					(data,condition,IndexNameType.B_ManyNoOfNewCount  ,FilterRuleType.RangeLimite,4) ;
//				Console.WriteLine ("结果："+res.ToString ()) ;
//			}
			Console.ReadKey(true);
		}
	}
}