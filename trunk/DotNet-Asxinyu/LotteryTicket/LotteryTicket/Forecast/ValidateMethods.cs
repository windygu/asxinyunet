/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-11
 * Time: 21:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using LotteryTicket.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LotteryTicket.ValidateResult
{
	/// <summary>
	/// 预测方法验证
	/// </summary>
	public static class ValidateMethods
    { 
        #region 公共方法
        /// <summary>
		/// 统计bool数组中True的比例,即正确率
		/// </summary>		
		public static double GetRateReuslt(bool[] result)
		{
			int sum = 0 ;
			foreach (bool element in result ) 
			{
				if (element ) 
				{
					sum ++ ;
				}
			}
			return ((double)sum)/((double)result.Length ) ;
		}      
		#endregion
		
		#region 和值相关的验证
	    /// <summary>
        /// 验证和值在一定范围的比例
	    /// </summary>
	    /// <param name="data">需要验证的数据期数</param>
	    /// <param name="conditions">和值范围</param>
	    /// <returns>和值在此范围的比例</returns>
		public static double SumInRangeLimiteValidate(double[][] data, double[] conditions)
		{
			//获取测试数据			
			bool[] res = PredictMethodsValidate.PredictValidate(data ,IndexNameType.A_Sum ,conditions,
			                                                     FilterRuleType.RangeLimite,0) ;
			return GetRateReuslt (res ) ;
		}			
		#endregion
		
		#region 跨度相关验证
        /// <summary>
        /// 最大跨度范围验证
        /// </summary>
        /// <param name="data">需要验证的数据期数</param>
        /// <param name="conditons">跨度范围</param>
        /// <returns>跨度在此范围的比例</returns>
		public static double MaxSpanInRangeLimiteValidate(double[][] data,double[] conditons)
		{
			bool[] res =PredictMethodsValidate .PredictValidate (data ,IndexNameType.A_MaxSpan ,conditons,
			                                                     FilterRuleType.RangeLimite,0) ;
			return GetRateReuslt (res ) ;
		}
		/// <summary>
        /// 最小跨度范围验证
		/// </summary>
        /// <param name="data">需要验证的数据期数</param>
        /// <param name="conditons">跨度范围</param>
        /// <returns>跨度在此范围的比例</returns>
		public static double MinSpanInRangeLimiteValidate(double[][] data,double[] conditons)
		{
			bool[] res =PredictMethodsValidate .PredictValidate (data ,IndexNameType.A_MinSpan ,conditons,
			                                                     FilterRuleType.RangeLimite,0) ;
			return GetRateReuslt (res ) ;
		}	
		#endregion
		
		#region 多期验证
        /// <summary>
        /// 最近几期号码重复出现的个数
        /// </summary>
        /// <param name="data">需要验证的数据期数</param>      
        /// <param name="conditons">条件</param>
        /// <param name="rows">比较的期数</param>
        /// <param name="ruleType">验证规则类型,默认为区间验证</param>
        /// <returns>满足指定条件的概率</returns>
		public static double LatestValidate(double[][] data,double[] conditons,int rows,FilterRuleType ruleType = FilterRuleType.RangeLimite)
		{
			bool[] res =PredictMethodsValidate.PredictValidate (data ,IndexNameType.B_ManyNoOfNewCount,
                                                                conditons, ruleType , rows);
			return GetRateReuslt (res ) ;
		}
		#endregion		

        #region 跨度列表验证
        /// <summary>
        /// 验证最近期的跨度列表不相同的概率，测试正确
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="rows">验证的行数</param>
        /// <returns>返回指定期内与当前期不同的概率</returns>
        public static double SpanListValidate(double[][] data ,int rows)
        {
            //单独写算法			       
            double[][] spanList = new double[data.GetLength(0)][];
            for (int i = 0; i <spanList.Length ; i++)
            {
                //先计算每一期的列表
                spanList[i ] = (double[])IndexCalculate.CalculateIndex(data[i], IndexNameType.C_SpanList );
            }
            //然后再循环比较,先将所有结果一一对比，然后再根据期数去判断
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            for (int i = 0; i < spanList.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < spanList.GetLength(0); j++)
                {
                    dic.Add(i.ToString() +"-"+j .ToString (),BaseRuleCompare.RuleCompare
                        (FilterRuleType.EqualAll, spanList[i], spanList[j]));
                }
            }
            int L = spanList.GetLength(0)-rows +1 ;
            bool[] res = new bool[L ];
            for (int i = 0; i <L ; i++)//将连续的几期，逐一比较
            {
                bool temp = false;//标记符，默认为false
                for (int j = i+1 ; j <i +rows ; j++)
                {                   
                    if (dic[i.ToString() + "-" + j.ToString()])//完全相同，则说明是不满足
                    {
                        temp = true ; break ;
                    }                                           
                    if (temp) { break; }//如果不满足,也跳出循环
                }
                res[i] =!temp;
            }
            return GetRateReuslt(res);
        }
        #endregion
        
        #region 综合验证, 验证上述几个算法是否编码正确
        public static void ComprehensiveValidate()
		{
            int[] dataLenAll = {5,10,20,50,100,200,500,1000 };
            int[] dataLenLimit = {1,2,3,4,5,6};            
            for (int i = 0; i < dataLenAll.Length ; i++)
            {
   
            }
            double[][] data = TwoColorBall.GetRedBallData(10);
            //double res = SumInRangeLimiteValidate(data, new double[] {65,145});
            //double res1 = MaxSpanInRangeLimiteValidate(data, new double[] {15,30});
            //double res2 = MinSpanInRangeLimiteValidate(data, new double[] {1,1});
            //double res3 = LatestValidate(data, new double[] { 2 }, 3, FilterRuleType.LessThanLimite);
            double res4 = SpanListValidate(data,5);
            //Console.WriteLine(res.ToString());
            //Console.WriteLine(res1.ToString());
            //Console.WriteLine(res2.ToString());
            //Console.WriteLine(res3.ToString());
            Console.WriteLine(res4.ToString());
		}
		#endregion

        #region 文本解释规则进行验证
        /// <summary>
        /// 根据文本规则进行方法验证,并将结果输入到文本中
        /// </summary>
        /// <param name="ruleFilePath">规则文件路径</param>
        public static void ValidateRuleFile(string ruleFilePath)
        {
            List<string> ruleList = TxtParse.GetRuleListFormFile(ruleFilePath);//原始规则
            string[][] ruleStr = TxtParse.ParseRuleList(ruleList);//解析后的规则字符串,每行一个规则,没列为参数列表
            using (StreamWriter sw = new StreamWriter(DateTime.Now.ToShortDateString (),false ))
            {
                //调用方法进行计算
                for (int i = 0; i < ruleStr.Length; i++)
                {
                    //基本参数的转化,类型不同

                    //依次计算,并写入结果
                    sw.WriteLine(TxtParse.CombStringArr (ruleStr [i ]));
                    //结果
                    sw.WriteLine();
                }
            }
        }        
        #endregion
    }
}