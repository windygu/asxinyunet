using System;
using System.Collections ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LotteryTicket.Common;

namespace LotteryTicket.Validate
{
	#region 测试类
	/// <summary>
	/// 验证和预测类的测试
	/// </summary>
	public class VFTest
	{
		/// <summary>
		/// 所以测试
		/// </summary>
		/// <param name="length">验证的数据的长度</param>
		public static void TestAll(int length = 20)
		{
			double[][] data = TwoColorBall.GetRedBallData(length);			
			SumVF sumvf = new SumVF();
			SpanCountVF spanVF = new SpanCountVF () ;
//			Console.WriteLine(
//				sumvf.Validate(data, FilterRuleType.RangeLimite, new double[] { 65, 145 }).ToString());
			Console.WriteLine (
				spanVF.Validate (data).ToString ()) ;
		}
	}
	#endregion

	//TODO:这个过滤规则：传入的条件是保存记录的条件
	#region 和值范围验证和过滤
	/// <summary>
	/// 和值范围验证和过滤
	/// </summary>
	public class SumVF : IValidateFilter
	{
		/// <summary>
		/// 和值范围过滤
		/// </summary>
		/// <param name="origData">原始数据序列</param>
		/// <param name="ruleType">过滤过程中的数据比较类型,默认为区间</param>
		/// <param name="paramValues">参数数组:第一个参数为和值下限，第二个参数为和值上线.闭区间比较</param>
		public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                          double[] conditons = null, params object[] paramValues)
		{
			origData.RemoveAll(delegate(double[] cur)
			                   {
			                   	double sum = (double)IndexCalculate.CalculateIndex(cur, IndexNameType.A_Sum);
			                   	return !BaseRuleCompare.RuleCompare(ruleType, sum, conditons);
			                   });
		}
		/// <summary>
		/// 和值验证，验证一段时期内和值满足某一条件的概率
		/// </summary>
		/// <param name="data">序列</param>
		/// <param name="ruleType">对比类型</param>
		/// <param name="conditons">条件</param>
		/// <param name="rows">需要的行数,此处为0</param>
		/// <param name="paramValues">其他参数</param>
		/// <returns>指定条件的概率</returns>
		public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                       double[] conditons = null, int rows = 0, params object[] paramValues) //验证
		{
			bool[] res = PredictMethodsValidate.PredictValidate(data, IndexNameType.A_Sum, conditons, ruleType, rows);
			return ValidateMethods.GetRateReuslt(res);
		}
	}
	#endregion

	#region 最大跨度范围验证和过滤
	/// <summary>
	/// 最大跨度范围验证和过滤
	/// </summary>
	public class MaxSpanVF : IValidateFilter
	{
		/// <summary>
		/// 最大跨度范围过滤
		/// </summary>
		/// <param name="origData">原始数据序列</param>
		/// <param name="ruleType">过滤过程中的数据比较类型,默认为区间</param>
		/// <param name="conditons">参数数组:第一个参数为下限，第二个参数为上限.闭区间比较</param>
		public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                          double[] conditons = null, params object[] paramValues)
		{
			origData.RemoveAll(delegate(double[] cur)
			                   {
			                   	double maxSpan = (double)IndexCalculate.CalculateIndex(cur, IndexNameType.A_MaxSpan);
			                   	return !BaseRuleCompare.RuleCompare(ruleType, maxSpan, conditons);
			                   });
		}
		/// <summary>
		/// 最大跨度验证，验证一段时期内最大跨度满足某一条件的概率
		/// </summary>
		/// <param name="data">序列</param>
		/// <param name="ruleType">对比类型</param>
		/// <param name="conditons">条件</param>
		/// <param name="rows">需要的行数,此处为0</param>
		/// <param name="paramValues">其他参数</param>
		/// <returns>指定条件的概率</returns>
		public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                       double[] conditons = null, int rows = 0, params object[] paramValues) //验证
		{
			bool[] res = PredictMethodsValidate.PredictValidate(data, IndexNameType.A_MaxSpan, conditons, ruleType, rows);
			return ValidateMethods.GetRateReuslt(res);
		}
	}
	#endregion

	#region 最小跨度范围验证和过滤
	/// <summary>
	/// 最小跨度范围验证和过滤
	/// </summary>
	public class MinSpanVF : IValidateFilter
	{
		/// <summary>
		/// 最小跨度过滤
		/// </summary>
		/// <param name="origData">原始数据序列</param>
		/// <param name="ruleType">过滤过程中的数据比较类型,默认为区间</param>
		/// <param name="conditons">参数数组:第一个参数为和值下限，第二个参数为和值上限.闭区间比较</param>
		public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                          double[] conditons = null, params object[] paramValues)
		{
			origData.RemoveAll(delegate(double[] cur)
			                   {
			                   	double minSpan = (double)IndexCalculate.CalculateIndex(cur, IndexNameType.A_MinSpan);
			                   	return !BaseRuleCompare.RuleCompare(ruleType, minSpan, conditons);
			                   });
		}
		/// <summary>
		/// 最小跨度验证，验证一段时期内最小跨度满足某一条件的概率
		/// </summary>
		/// <param name="data">序列</param>
		/// <param name="ruleType">对比类型</param>
		/// <param name="conditons">条件</param>
		/// <param name="rows">需要的行数,此处为0</param>
		/// <param name="paramValues">其他参数</param>
		/// <returns>指定条件的概率</returns>
		public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                       double[] conditons = null, int rows = 0, params object[] paramValues) //验证
		{
			bool[] res = PredictMethodsValidate.PredictValidate(data, IndexNameType.A_MinSpan, conditons, ruleType, rows);
			return ValidateMethods.GetRateReuslt(res);
		}
	}
	#endregion

	#region 多期数目的验证和过滤---排除不可用
	#endregion

	#region 重复数个数验证和过滤
	/// <summary>
	/// 每一期号码与前若干期号码每期号码重复个数的最大值,用于判断组合出现的情况，组合杀号
	/// </summary>
	public class RepeatNumbersVF : IValidateFilter
	{
		/// <summary>
		/// 重复数个数范围过滤
		/// </summary>
		/// <param name="origData">原始数据序列</param>
		/// <param name="ruleType">过滤过程中的数据比较类型,默认为区间</param>
		/// <param name="conditons">条件,这里默认为空</param>
		/// <param name="paramValues">参数数组:为最近几期的实际数据,用于和当前的预测值进行对比,直接传入一个double[][]数组</param>
		public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.LessThanLimite,
		                          double[] conditons = null, params object[] paramValues)
		{
			double[][] compValues = (double[][])paramValues[0];
			origData.RemoveAll(delegate(double[] cur)
			                   {
			                   	for (int i = 0; i < compValues.Length; i++)
			                   	{
			                   		int count = IndexCalculate.GetRepeatNumbers(cur, compValues[i]);
			                   		//一个不符合即可以删除
			                   		if (!BaseRuleCompare.RuleCompare(ruleType, count, new double[] { (double)count })) return true;
			                   	}
			                   	return false;
			                   });
		}
		/// <summary>
		/// 重复数个数验证，验证一段时期内重复数个数的最大值满足条件的概率
		/// </summary>
		/// <param name="data">序列</param>
		/// <param name="ruleType">对比类型</param>
		/// <param name="conditons">条件</param>
		/// <param name="rows">需要的行数,此处为5</param>
		/// <param name="paramValues">其他参数</param>
		/// <returns>指定条件的概率</returns>
		public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                       double[] conditons = null, int rows = 5, params object[] paramValues) //验证
		{
			//单独写算法
			//然后再循环比较,先将所有结果一一对比，然后再根据期数去判断
			Dictionary<string, int> dic = new Dictionary<string, int>();
			for (int i = 0; i < data.GetLength(0) - 1; i++)
			{
				for (int j = i + 1; j < data.GetLength(0); j++)
				{
					dic.Add(i.ToString() + "-" + j.ToString(), IndexCalculate.GetRepeatNumbers(data[i], data[j]));
				}
			}
			int L = data.GetLength(0) - rows + 1;
			bool[] res = new bool[L];
			for (int i = 0; i < L; i++)//将连续的几期，逐一比较
			{
				bool temp = false;//标记符，默认为false
				for (int j = i + 1; j < i + rows; j++)
				{
					if (dic[i.ToString() + "-" + j.ToString()] >= (int)conditons[0])//说明不满足要求
					{
						temp = true; break;
					}
					if (temp) { break; }//如果不满足,也跳出循环
				}
				res[i] = !temp;
			}
			return ValidateMethods.GetRateReuslt(res);
		}
	}
	#endregion

	#region 最大连续号码验证和过滤
	public class ContinuousCountVF : IValidateFilter
	{
		/// <summary>
		/// 最大连续号码过滤
		/// </summary>
		/// <param name="origData">原始数据序列</param>
		/// <param name="ruleType">过滤过程中的数据比较类型,默认为区间</param>
		/// <param name="conditons">参数数组:第一个参数为下限，第二个参数为上线.闭区间比较</param>
		public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                          double[] conditons = null, params object[] paramValues)
		{
			origData.RemoveAll(delegate(double[] cur)
			                   {
			                   	double Count = (double)IndexCalculate.CalculateIndex(cur, IndexNameType.A_ContinuousCount);
			                   	return !BaseRuleCompare.RuleCompare(ruleType, Count, conditons);
			                   });
		}
		/// <summary>
		/// 最大连续号码验证，验证一段时期内和值满足某一条件的概率
		/// </summary>
		/// <param name="data">序列</param>
		/// <param name="ruleType">对比类型</param>
		/// <param name="conditons">条件</param>
		/// <param name="rows">需要的行数,此处为0</param>
		/// <param name="paramValues">其他参数</param>
		/// <returns>指定条件的概率</returns>
		public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.LessThanLimite,
		                       double[] conditons = null, int rows = 0, params object[] paramValues) //验证
		{
			//获取测试数据
			bool[] res = PredictMethodsValidate.PredictValidate(data, IndexNameType.A_ContinuousCount,
			                                                    conditons, ruleType);
			return ValidateMethods.GetRateReuslt(res);
		}
	}
	#endregion

	#region 上期的邻号在下期出现的个数
	public class NeighbourNumberVF : IValidateFilter
	{
		/// <summary>
		/// 邻号数目过滤
		/// </summary>
		/// <param name="origData">原始数据序列</param>
		/// <param name="ruleType">过滤过程中的数据比较类型,默认为区间</param>
		/// <param name="conditons">参数数组:第一个参数为邻号数</param>
		/// <param name="paramValues">第一个参数为double[]，即上一期的数据</param>
		public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.LessThanLimite,
		                          double[] conditons = null, params object[] paramValues)
		{
			double[] temp = (double[])paramValues[0];
			origData.RemoveAll(delegate(double[] cur)
			                   {
			                   	double Count = (double)IndexCalculate.NeighbourNumberCount(temp, cur);
			                   	return !BaseRuleCompare.RuleCompare(ruleType, Count, conditons);
			                   });
		}
		/// <summary>
		///邻号数目验证，验证一段时期内邻号满足某一条件的概率
		/// </summary>
		/// <param name="data">序列</param>
		/// <param name="ruleType">对比类型</param>
		/// <param name="conditons">条件，邻号数</param>
		/// <param name="rows">需要的行数,此处为1</param>
		/// <param name="paramValues">其他参数</param>
		/// <returns>指定条件的概率</returns>
		public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.LessThanLimite,
		                       double[] conditons = null, int rows = 1, params object[] paramValues)
		{
			double[] count = new double[data.Length - rows];
			for (int i = 0; i < count.Length; i++)
			{
				count[i] = (double)IndexCalculate.NeighbourNumberCount(data[i], data[i + 1]);//相邻期验证
			}
			//获取测试数据TOTO:更改比较方法,提高效率，一一比较，重复调用
			bool[] res = count.Select(n => BaseRuleCompare.RuleCompare(ruleType, n, conditons)).ToArray();
			return ValidateMethods.GetRateReuslt(res);
		}
	}
	#endregion

	#region 验证所有期内 跨度列表重复出现的总次数，不用过滤,参考指标
	/// <summary>
	/// 跨度列表重复出现的总次数
	/// </summary>
	public class SpanCountVF:IValidateFilter
	{
		/// <summary>
		/// 跨度列表重复过滤:不实现
		/// </summary>
		public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.LessThanLimite,
		                          double[] conditons = null, params object[] paramValues)
		{
			return ;
		}
		/// <summary>
		///跨度列表重复出现的次数
		/// </summary>
		/// <param name="data">序列</param>
		/// <param name="ruleType">对比类型</param>
		/// <param name="conditons">条件，邻号数</param>
		/// <param name="rows">需要的行数,此处为1</param>
		/// <param name="paramValues">其他参数</param>
		/// <returns>出现的概率</returns>
		public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.LessThanLimite,
		                       double[] conditons = null, int rows = 1, params object[] paramValues)
		{
			List<double[]> spanList = data.Select (n=>(double[])PerNoIndexCalculate.C_SpanList (n )).ToList ();
			Dictionary <double[],string> dic = new Dictionary<double[], string> () ;
			Hashtable ht = new Hashtable(spanList.Count ) ;
			for (int i = 0; i < spanList.Count ; i++) {
				string str = GetDoubleString (spanList [i ]) ;//转换为字符串
				if(!ht.ContainsKey(str ))
					ht.Add(str ,"") ;
			}
			return (double )ht.Count ;//总数目
		}
		private string GetDoubleString(double[] str )
		{
			string res = "" ;
			foreach (double  element in str ) {
				res  += element.ToString () ;
			}
			return res  ;
		}
	}
	#endregion

	#region 质合比
	/// <summary>
	/// 质数个数验证,也可以看做质数个数验证.
	/// </summary>
	public class PrimeNumberCountVF:IValidateFilter 
	{
		/// <summary>
		/// 质数个数过滤
		/// </summary>
		/// <param name="origData">原始数据序列</param>
		/// <param name="ruleType">过滤过程中的数据比较类型,默认为区间</param>
		///<param name="conditons" >条件，需要保留的质数个数条件,上下限</param>
		public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                          double[] conditons = null, params object[] paramValues)
		{
			origData.RemoveAll (n=> !BaseRuleCompare.RuleCompare (
				ruleType,(double )PerNoIndexCalculate.A_PrimeCount (n ),conditons ));
		}
		/// <summary>
		/// 质数个数验证，验证一段时期内质数个数满足某一条件的概率
		/// </summary>
		/// <param name="data">序列</param>
		/// <param name="ruleType">对比类型</param>
		/// <param name="conditons">条件</param>
		/// <param name="rows">需要的行数,此处为0</param>
		/// <param name="paramValues">其他参数</param>
		/// <returns>指定条件的概率</returns>
		public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                       double[] conditons = null, int rows = 0, params object[] paramValues) //验证
		{
//			bool[] res = PredictMethodsValidate.PredictValidate(data, IndexNameType.A_Sum, conditons, ruleType, rows);
			bool[] res = data.Select (n=>BaseRuleCompare.RuleCompare (
				ruleType,(double )PerNoIndexCalculate.A_PrimeCount (n ),conditons )).ToArray ();
			return ValidateMethods.GetRateReuslt(res);
		}
	}
	#endregion

	#region 奇偶比
	/// <summary>
	/// 偶数个数过滤与验证,也可以看做奇偶比
	/// </summary>
	public class EvenNumberVF:IValidateFilter 
	{
		/// <summary>
		/// 偶数个数过滤
		/// </summary>
		/// <param name="origData">原始数据序列</param>
		/// <param name="ruleType">过滤过程中的数据比较类型,默认为区间</param>
		///<param name="conditons" >条件，需要保留的偶数个数条件,上下限</param>
		public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                          double[] conditons = null, params object[] paramValues)
		{
			origData.RemoveAll (n=> !BaseRuleCompare.RuleCompare (
				ruleType,(double )PerNoIndexCalculate.A_EvenNumber(n ),conditons ));
		}
		/// <summary>
		/// 偶数个数验证，验证一段时期内偶数个数满足某一条件的概率
		/// </summary>
		/// <param name="data">序列</param>
		/// <param name="ruleType">对比类型</param>
		/// <param name="conditons">条件</param>
		/// <param name="rows">需要的行数,此处为0</param>
		/// <param name="paramValues">其他参数</param>
		/// <returns>指定条件的概率</returns>
		public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.RangeLimite,
		                       double[] conditons = null, int rows = 0, params object[] paramValues) //验证
		{
			bool[] res = data.Select (n=>BaseRuleCompare.RuleCompare (
				ruleType,(double )PerNoIndexCalculate.A_EvenNumber (n ),conditons )).ToArray ();
			return ValidateMethods.GetRateReuslt(res);
		}
	}
	#endregion

	#region 求余覆盖范围
    /// <summary>
	/// 通过求余来计算覆盖的范围 
	/// </summary>
    public class CoverVF : IValidateFilter
    {
        /// <summary>
        /// 通过求余来计算覆盖的范围来过滤
        /// </summary>
        /// <param name="origData">原始数据序列</param>
        /// <param name="ruleType">过滤过程中的数据比较类型,默认为区间</param>
        ///<param name="conditons" >条件，求余参数，以及覆盖范围的个数：第一二个为上下限，第三个为求余参数</param>
        public void FilterNumbers(List<double[]> origData, FilterRuleType ruleType = FilterRuleType.RangeLimite,
                                  double[] conditons = null, params object[] paramValues)
        {
            //对比规则,求余参数L，0-L-1，出现的个数
            int L = (int)conditons[2];
            origData.RemoveAll(n => !BaseRuleCompare.RuleCompare(
                ruleType, (double)PerNoIndexCalculate.A_CoverCount(n, L), conditons));
        }
        /// <summary>
        /// 通过求余来计算覆盖的范围来验证概率
        /// </summary>
        /// <param name="data">序列</param>
        /// <param name="ruleType">对比类型</param>
        /// <param name="conditons">条件，求余参数，以及覆盖范围的个数：第一二个为上下限，第三个为求余参数</param>
        /// <param name="rows">需要的行数,此处为0</param>
        /// <param name="paramValues">其他参数</param>
        /// <returns>指定条件的概率</returns>
        public double Validate(double[][] data, FilterRuleType ruleType = FilterRuleType.RangeLimite,
                               double[] conditons = null, int rows = 0, params object[] paramValues) //验证
        {
            int L = (int)conditons[2];
            bool[] res = data.Select(n => BaseRuleCompare.RuleCompare(
                ruleType, (double)PerNoIndexCalculate.A_CoverCount(n,L ), conditons)).ToArray();
            return ValidateMethods.GetRateReuslt(res);
        }
    }
	#endregion

	#region 新旧跳比

	#endregion

	#region 和值与前几期不同的概率，杀单个和值
	#endregion

	#region 旋转矩阵
	#endregion

	//http://taobao.starlott.com/ssq/hqyl.html
	//http://taobao.starlott.com/ssq/hzyl.html
	//新旧跳比
	//奇号连：前后两个号间隔为2，且号码都是奇数，这样的号码的组数，例如：01，03，07，09 ，11，19则奇号连续为3，即01-03，07-09。
	//偶号连：前后两个号间隔为2，且号码都是偶数，这样的号码的组数，例如：02，04，08，10 ，12，20则偶号连续为3，即02-04，08-10。
}