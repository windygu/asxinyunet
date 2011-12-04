using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public static bool GetCompareResult(this int[] res,CompareParams compConditon,ECompareType compType)
        {
            switch (compType)
            {
                case ECompareType.Equal://相等比较第一个
                    return res == compConditon.FloorLimit;
                case ECompareType.RangeLimite:
                    return (res >= RuleParams.FloorLimit) && (res <= rule.RuleParams.CeilLimit);
                case ECompareType.LessThanLimite:
                    return res <= RuleParams.FloorLimit;
                case ECompareType.GreaterThanLimite:
                    return res >= RuleParams.FloorLimit;
                case ECompareType.InList:
                    return RuleParams.CompList.Contains(res);
                case ECompareType.NotInList:
                    return !RuleParams.CompList.Contains(res);
                default:
                    return false;
            }
        }
        #endregion
    }
}
