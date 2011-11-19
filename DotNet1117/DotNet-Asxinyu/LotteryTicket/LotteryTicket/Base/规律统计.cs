﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryTicket
{
    /// <summary>
    /// 规律统计与过滤 TODO:进一步完善比较方法和类型,比如删除指定的
    /// </summary>
    public static class StatisticalFilter
    {
        #region 规则比较通用方法，输入比较规则和数据源
        /// <summary>
        /// 规则比较
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="rule">数据源相应的比较规则</param>
        /// <returns>是否符合规则:符合为True,否则False</returns>
        public static bool CompareRule(this IEnumerable<int> source, Rule rule)
        {
            int res = rule.Selector(source.ToArray ());//结果
            switch (rule.CompareRule)
            {
                case CompareType.Equal://相等比较第一个
                    return res == rule.FloorLimit;                    
                case CompareType.RangeLimite:
                    return (res >= rule.FloorLimit )&&(res <= rule.CeilLimit ) ;
                case CompareType.LessThanLimite:
                    return res <= rule.FloorLimit;
                case CompareType.GreaterThanLimite:
                    return res >= rule.FloorLimit;
                default:
                    return false;
            }        
        }
        #endregion

        #region 统计值出现在指定范围的频率
        public static double Static_单个指标频率(this IEnumerable<int[]> source,Rule rule)
        {
            return ((double)source.Where(n => n.CompareRule(rule)).Count()) / ((double)source.Count());           
        }
        #endregion  

        #region 范围过滤：只保留对应规则的数据
        /// <summary>
        /// 范围过滤：只保留对应规则的数据
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="rule">保留规则</param>
        /// <returns>符合条件的集合</returns>
        public static IEnumerable<int[]> Filter_范围过滤(this IEnumerable<int[]> source,Rule rule)
        {
            return source.Where(n => n.CompareRule(rule));
        }
        #endregion
    }

    /// <summary>
    /// 验证过滤
    /// </summary>
    public static class Validate
    {
        #region 排除指定值过滤：删除指标值等于列表中数据的序列
        /// <summary>
        /// 删除指标值等于列表中数据的序列
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="selector">统计值的计算函数</param>
        /// <param name="deleteList">删除列表</param>
        public static IEnumerable<int[]> Filter_删除指定值过滤(this IEnumerable<int[]> source, System.Func<int[], int> selector,
            int[] deleteList)
        {            
            return (from n in source
                    let sum = selector(n)
                    where (!deleteList.Contains (sum))//包含指定值的不选择，也就是删除
                    select n);
        }
        #endregion
    }
}
