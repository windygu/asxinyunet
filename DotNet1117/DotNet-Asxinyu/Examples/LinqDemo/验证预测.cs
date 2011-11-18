/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-3-3
 * Time: 14:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Reflection ;

namespace LotteryTicket
{
	/// <summary>
	/// 预测方法验证
	/// </summary>
    public class ValidatePredict
	{	
		/// <summary>
		/// 验证单个方法与方法之间的预测情况(所有数据)
		/// </summary>
		/// <param name="args">所有数据</param>
		/// <param name="origIndexType">原始数据指标类型</param>
		/// <param name="compIndexType">说要对比的数据指标类型</param>
		/// <param name="ruleType">对比规则类型</param>
		/// <param name="needCounts">所需行</param>
		/// <returns>方法预测的正确性</returns>
		public static bool[] PredictValidate(double[][] args ,IndexNameType origIndexType,
		                                     IndexNameType compIndexType,
		                                     FilterRuleType ruleType,int needCounts=0)
		{
			bool[] res ;
			Type t = typeof (IndexCalculate ) ;
			MethodInfo origMi = t.GetMethod ("CalculateAllData") ;
			//比较的双方数据肯定是数组
			//TODO:需要 考虑指标为字符串时的对比情况
			//TODO:A,C类型的指标计算只得到单个数据			
			//根据预测指标的类型,可能数据长度不一致;B、D类型要根据当前所需行数来进行一个判断转换			
			res = new bool[args.Length -needCounts  ] ;			
			char origCt = origIndexType.ToString ()[0];
			char compCt = compIndexType.ToString ()[0];
			object origData = origMi.Invoke(null ,new object []{args ,origIndexType,new int[]{needCounts}}) ;
			object compData = origMi.Invoke(null ,new object []{args ,compIndexType,new int[]{needCounts}}) ;
			MethodInfo mi1 = typeof (BaseRuleCompare ).GetMethod ("RuleCompare") ;
			bool oAC = (origCt =='A')||(origCt =='B') ;
			bool cAC = (compCt =='A')||(compCt =='B') ;
			bool oBD = (origCt =='C')||(origCt =='D') ;
			bool cBD = (compCt =='C')||(compCt =='D') ;
			if (oAC && cAC)//都是AC
			{
				double[] orig = (double[])origData ;
				double[] comp = (double[])compData ;
				for (int i = 0 ; i < res .Length -1; i ++ )
				{
					res[i ]=(bool )mi1.Invoke (null,new object []{ruleType,
					                                       	new double[]{orig[i]},new double[]{comp[i+needCounts]}});
				}
			} 
			else if(oAC && cBD )
			{
				double[] orig = (double[])origData ;
				double[][] comp = (double[][])compData ;
				for (int i = 0 ; i < res .Length -1; i ++ )
				{
					res[i ]=(bool )mi1.Invoke (null,new object []{ruleType,
					                                       	new double[]{orig[i]},
					                                       	comp[i+needCounts]}) ;
				}
			}
			else if(oBD && cAC )
			{
				double[][] orig = (double[][])origData ;
				double[] comp = (double[])compData ;
				for (int i = 0 ; i < res .Length - 1 ; i ++ )
				{
					res[i]=(bool )mi1.Invoke (null,new object []{ruleType,
					                                       	orig [i ],new double []{comp[i+needCounts]}});
				}
			}
			else if(oBD && cBD )
			{
				double[][] orig = (double[][])origData ;
				double[][] comp = (double[][])compData ;
				for (int i = 0 ; i < res .Length ; i ++ )
				{
					res[i ]=(bool )mi1.Invoke (null,new object []{ruleType,
					                                       	orig [i ],comp[i+needCounts]});
				}
			}
			else{}
			return res ;
		}
		
		/// <summary>
        /// 直接传入对比条件,用于一些特殊的规律预测
		/// </summary>
        /// <param name="args">所有数据</param>
        /// <param name="origIndexType">原始数据指标类型</param>
		/// <param name="Conditions">指定的条件</param>
        /// <param name="ruleType">对比规则类型</param>
		/// <param name="needCounts">指标计算所需的行数</param>
        /// <returns>方法预测的正确性</returns>
		public static bool[] PredictValidate(double[][] args ,IndexNameType origIndexType,
		                                     double[] Conditions, 
		                                     FilterRuleType ruleType,int needCounts =0 )
		{
			bool[] res ;
			Type t = typeof (IndexCalculate ) ;
			MethodInfo origMi = t.GetMethod ("CalculateAllData") ;
			//比较的双方数据肯定是数组
			//TODO:需要 考虑指标为字符串时的对比情况
			//TODO:A,C类型的指标计算只得到单个数据			
			//根据预测指标的类型,可能数据长度不一致;B、D类型要根据当前所需行数来进行一个判断转换
			res = new bool[args.Length -needCounts ] ;			
			char origCt = origIndexType.ToString ()[0];
			object origData = origMi.Invoke(null ,new object []{args ,origIndexType,needCounts}) ;
			MethodInfo mi1 = typeof (BaseRuleCompare ).GetMethod ("RuleCompare") ;
			if ((origCt == 'A')||(origCt == 'B'))//A B
			{
				double[] orig = (double[])origData ;				
				for (int i = 0 ; i < res .Length -1; i ++ )
				{
					res[i ]=(bool )mi1.Invoke (null,new object []{ruleType,new double[]{orig[i]},Conditions});
				}
			} 
			else if((origCt == 'C')||(origCt == 'D'))
			{
				double[] orig = (double[])origData ;			
				for (int i = 0 ; i < res .Length -1; i ++ )
				{
					res[i ]=(bool )mi1.Invoke (null,new object []{ruleType,new double[]{orig[i]},Conditions}) ;
				}
			}
			else{}
			return res ;
		}
	
		public static double GetValidateResult(double[][] data,double[] conditions,IndexNameType indexType,
		                                       FilterRuleType ruleType,int needLength = 0 )
		{
			bool[] res = PredictMethodsValidate .PredictValidate 
				(data , indexType ,conditions,ruleType,needLength) ;
			return GetRateReuslt (res ) ;
		}
			#region 公共方法
		/// <summary>
		/// 统计bool数组中True的比例,即正确率
		/// </summary>		
		public static double GetRateReuslt(bool[] result)
		{
            int sum = result.Where(n => n == true).Count();
			return ((double)sum)/((double)result.Length ) ;
		}
		#endregion
	}
}