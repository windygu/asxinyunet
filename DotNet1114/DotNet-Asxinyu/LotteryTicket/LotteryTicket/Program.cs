﻿#region 开发进度
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
 *      	//TODO:计算一定期内奇数与偶数的个数
 * 		    //一定期数内不重复的次数
 * 
 * 彩票处理程序类库
 * 
 * 修改更新逻辑：每次更新数据库后，保存到日志中。下次进行对比，确定更新数据的期数
 * 
 * 
 * 2011-11-13 修改组合生成方法,完成杀号和杀组合的过滤算法
 * 2011-11-12 对预测方法类，进行更新，测试及修改Bug
 * 2011-11-06 采用Xcode架构，对程序结果进行重新梳理，完善注释
 * 2011-11-05 中断半年后重新开始整理程序结构
 * 2011-04-26 数据库操作由动软代码生成器改为新生命组件；重新改写数据采集方法，采用HtmlAgilityPack采集数据
 * 2011-04-25 测试NewLife数据组件，完成基本的数据库操作
 * 2011-04-21 重构代码,便于新的需求和测试,并对类库框架进行进一步重构,方便处理其他类型
 * 2011-04-20 开始增加结果验证方法以及数据过滤器,根据规则文件依次进行过滤;采用.NET 4.0的默认参数特性,重构重载方法
 *            完成双色球彩票验证,兑奖计算类
 * 2011-04-19 模式筛选与匹配类，得到初步结果，还有待进一步分析
 * 2011-04-17 采用开源类库实现排列的选取，增加了方便和提高速度
 * 2011-04-14 将所有项目全部迁移到.NET 4.0,利用新的语言特性和类库,提高可读性和可维护性
 * 2011-04-11 完成预测类，修改为规律测试与预测方法验证
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
 #endregion

using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using DotNet.Tools;
using XCode;
using LotteryTicket.Validate ;
using NewLife.Reflection;
using XCode.DataAccessLayer;
using LotteryTicket.Data;
using LotteryTicket.Common;

namespace LotteryTicket
{
    class Program
    {
        public static void Main(string[] args)
        {
            //double[][] data= TwoColorBall.GetRedBallData (200) ;
            //double[][] sections = new double[5][] ;
            double[] data1 = new double[] {1,2,3,4,5,6};
            double[] data2 = new double[] {5,6,9,26,28,29};
            //sections [2] = new double[] {15,16,17,18,19,20,21};
            //sections [3] = new double[] {22,23,24,25,26,27,28};
            //sections [4] = new double[] {29,30,31,32,33};
            //String connStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=LotteryTicket.mdb;Persist Security Info=False;OLE DB Services=-1";
            //DAL.AddConnStr("LotTick", connStr, null, "access");
            //GetSSQDataFromWeb gs = new GetSSQDataFromWeb();
            //gs.GetAllHistoryData(64);
            ValidateMethods.ComprehensiveValidate();
//            Console.WriteLine ( ValidateMethods.GetRepeatNumbers (data1,data2 )) ;
            Console.ReadKey(true);
        }
        /// <summary>
        /// Combination类测试
        /// </summary>
        public static void CombinationTest()
        {
            int[] data = new int[] { 6, 7, 8, 9 };
            foreach (Combination combom in new Combination(4, 3).Rows)
            {
                foreach (int item in Combination.Permute(combom, data))
                    Console.Write(item.ToString () + " ");
                Console.WriteLine();
            }
        }
    }
}