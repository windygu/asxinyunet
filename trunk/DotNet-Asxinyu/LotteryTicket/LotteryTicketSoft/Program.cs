﻿#region 开发进度
/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-17
 * Time: 22:11
 * 
 * 开发计划
 * 
 * 彩票处理程序类库
 * 
 * 修改更新逻辑：每次更新数据库后，保存到日志中。下次进行对比，确定更新数据的期数
 *          TODO:过滤速度很慢，需要对规则窗体的计算过程进行优化，例如中间保存
 *               考虑将蓝球验证以及混合验证加入进去，验证模式
 *               基本算法的测试
 *               将没种验证的结果都列出来，然后进行统一比较(交叉验证)
 *          下次数据库需要修改的东西：增加验证模式字段：杀蓝，杀红，混合,双色球的期号数据类型改为整形
 *                                  增加媒体杀号历史记录表,分析总结
 *      
 * 目前主要工作:增加方案的保存和读取，以增加初始的读取和计算速度，先设计结构
 * 
 * 
 * 2012-03-07 新版本基本通过，新的架构，增加异步调用方式.结构更加清晰,速度更加快
 * 2011-11-30 考虑对验证模型进一步修改,方便对指标进行分类验证和数据挖掘
 *            注意一下原则：验证中的数据格式不是传入多少数据,而是需要得到多少结果；
 *                         所需行是指除本行以外的最邻近的行的数据
 * 2011-11-26 考虑到规则和验证的复杂性，还是将将结果进行分分类，分为4类
 *            发现影响速度的重大问题,将IEnumerable<int[]>扩展方法全部改为int[]
 *            完成交叉验证，修改一些计算的Bug
 * 2011-11-25 数据规则展示控件基本完成，基本指标的验证计算功能完成，还需完善其他类型指标的计算
 * 2011-11-22 全面考虑各种验证和过滤功能。
 * 2011-11-21 取消18日的数据库改进,开始进行规则类的显示及数据库保存。
 * 2011-11-19 指标名称更改为中文，便于理解。结合500w彩票软件进行，无需重复开发功能。增加自己的特殊功能而已。
 * 2011-11-18 重大改进基本完成,整理之后，利用Linq特性，大大简化程序结构。整合完善彩票类，数据接口
 * 2011-11-17 整个架构重新设计，重新设计数据库，更改程序架构，改进比较算法类为泛型类
 *            重大改进：将指标计算类升级为泛型扩展方法类，以便在后续的计算过程中采用Linq技术
 * 2011-11-16 根据相关网站经验和改进，完成多个验证和过滤算法，进一步丰富数据特征的验证
 * 2011-11-15 整体项目采用Linq技术进行重构升级,以增加完善处理逻辑,增加邻号验证和过滤
 * 2011-11-14 继续完善杀号方法和验证方法,将验证和过滤升级为接口,更容易操作
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
using System.Windows.Forms;

namespace LottAnalysis
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
