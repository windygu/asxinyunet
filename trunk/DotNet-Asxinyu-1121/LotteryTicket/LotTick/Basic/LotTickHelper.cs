using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCode;

namespace LotTick
{
    /// <summary>
    /// 彩票帮助类,存储和实现通用的信息和方法
    /// </summary>
    public static class LotTickHelper
    {
        #region 常量
        /// <summary>
        /// 1-33以内的质数集合
        /// </summary>
        public static readonly int[] PrimeNumbers = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
        #endregion

        #region 根据规则和参数对目标进行比较
        /// <summary>
        /// 根据规则和数据，判断是否满足要求
        /// </summary>
        /// <param name="source">数据</param>
        /// <param name="rule">规则信息</param>
        /// <returns>结果列表,包括了所有的指标类型</returns>    
        public static bool[] GetCompareResult(this int[] data,RuleInfo ruleInfo)
        {
            switch (ruleInfo.CompareRule)
            {
                case ECompareType.Equal://相等比较第一个
                    return data.Select(n => n == ruleInfo.CondtionParams.FloorLimit).Where(n => n).ToArray();
                case ECompareType.RangeLimite:
                    return data.Select(n => (n >= ruleInfo.CondtionParams.FloorLimit) && (n <= ruleInfo.CondtionParams.CeilLimit)).Where(n => n).ToArray();
                case ECompareType.LessThanLimite:
                    return data.Select(n => n <= ruleInfo.CondtionParams.FloorLimit).Where(n => n).ToArray();
                case ECompareType.GreaterThanLimite:
                    return data.Select(n => n >= ruleInfo.CondtionParams.FloorLimit).Where(n => n).ToArray();
                case ECompareType.InList:
                    return data.Select(n => ruleInfo.CondtionParams.CompList.Contains(n)).Select(n => n).ToArray();
                case ECompareType.NotInList:
                    return data.Select(n => !ruleInfo.CondtionParams.CompList.Contains(n)).Select(n => n).ToArray();                  
                default:
                    return data.Select(n=>false ).ToArray ();
            }
        }

        public static bool GetCompareResult(this int data, RuleInfo ruleInfo)
        {
            switch (ruleInfo.CompareRule)
            {
                case ECompareType.Equal://相等比较第一个
                    return data == ruleInfo.CondtionParams.FloorLimit;
                case ECompareType.RangeLimite:
                    return (data >= ruleInfo.CondtionParams.FloorLimit) && (data <= ruleInfo.CondtionParams.CeilLimit) ;
                case ECompareType.LessThanLimite:
                    return data<= ruleInfo.CondtionParams.FloorLimit ;
                case ECompareType.GreaterThanLimite:
                    return data >= ruleInfo.CondtionParams.FloorLimit ;
                case ECompareType.InList:
                    return ruleInfo.CondtionParams.CompList.Contains(data );
                case ECompareType.NotInList:
                    return !ruleInfo.CondtionParams.CompList.Contains(data );
                default:
                    return false;
            }
        }
        #endregion

        #region 获取所有的方法类型和比较类型
        /// <summary>
        /// 加入OM,特殊验证方法,其他指标的名字，通过前缀区分来区分
        /// </summary>
        public static string[] GetAllIndexFuncNames()
        {
            List<tb_IndexInfo > allRules = tb_IndexInfo.FindAll();
            return allRules.Select(n => n.IndexName).ToArray();
        }      
        /// <summary>
        /// 获取枚举类型的所有枚举值
        /// </summary>
        public static List<string> GetAllEnumNames<T>()
        {
            return Enum.GetNames(typeof(T)).ToList();
        }
        #endregion            
    }
}
