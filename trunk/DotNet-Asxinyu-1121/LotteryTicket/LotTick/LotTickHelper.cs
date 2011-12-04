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
        public static bool[] GetCompareResult(this int[] data,CompareParams compConditon,ECompareType compType)
        {
            switch (compType)
            {
                case ECompareType.Equal://相等比较第一个
                    return data.Select(n => n == compConditon.FloorLimit).Where (n=>n).ToArray();
                case ECompareType.RangeLimite:
                    return data.Select(n => (n >= compConditon.FloorLimit) && (n <= compConditon.CeilLimit)).Where(n => n).ToArray();
                case ECompareType.LessThanLimite:
                    return data.Select(n => n <= compConditon.FloorLimit).Where(n => n).ToArray();
                case ECompareType.GreaterThanLimite:
                    return data.Select(n => n >= compConditon.FloorLimit).Where(n => n).ToArray();
                case ECompareType.InList:
                    return data.Select(n => compConditon.CompList.Contains(n)).Select(n => n).ToArray();
                case ECompareType.NotInList:
                    return data.Select(n => !compConditon.CompList.Contains(n)).Select(n => n).ToArray();                  
                default:
                    return data.Select(n=>false ).ToArray ();
            }
        }
        #endregion
    }
}
