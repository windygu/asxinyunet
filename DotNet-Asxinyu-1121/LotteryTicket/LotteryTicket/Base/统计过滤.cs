using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LotteryTicket
{
    /// <summary>
    /// 规律统计与过滤
    /// </summary>
    public static class StatisticalFilter
    {
        #region 规则比较通用方法，输入比较规则和数据源
        /// <summary>
        /// 规则比较：1对1和1对多
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="rule">数据源相应的比较规则</param>
        /// <returns>是否符合规则:符合为True,否则False</returns>
        public static bool CompareRuleOO(this IEnumerable<int> source, Rule rule)
        {            
            int res = rule.OOSelector(source.ToArray ());//结果
            return GetCompareResult(res, rule);
        }

        /// <summary>
        /// 规则比较：多对多,多对1
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="rule">数据源相应的比较规则</param>
        /// <returns>是否符合规则:符合为True,否则False</returns>
        public static bool CompareRuleMO(this IEnumerable<int[]> source, Rule rule)
        {
            int res = rule.MOSelector (source.ToArray ());//结果
            return GetCompareResult(res, rule);
        }
        static bool GetCompareResult(int res, Rule rule)
        {
            switch (rule.CompareRule)
            {
                case CompareType.Equal://相等比较第一个
                    return res == rule.RuleParams.FloorLimit;
                case CompareType.RangeLimite:
                    return (res >= rule.RuleParams.FloorLimit) && (res <= rule.RuleParams.CeilLimit);
                case CompareType.LessThanLimite:
                    return res <= rule.RuleParams.FloorLimit;
                case CompareType.GreaterThanLimite:
                    return res >= rule.RuleParams.FloorLimit;
                case CompareType.InList:
                    return rule.RuleParams.CompList.Contains(res);
                case CompareType.NotInList:
                    return !rule.RuleParams.CompList.Contains(res);
                default:
                    return false;
            }
        }
        #endregion

        #region 统计值出现在指定范围的频率--单个指标频率
        /// <summary>
        /// TODO:特殊的验证和过滤解决
        /// </summary>
        public static double Static_单个指标频率(this IEnumerable<int[]> source,Rule rule)
        {            
            //TODO:增加是特殊模式下时的处理
            return ((double)source.Where(n => n.CompareRuleOO(rule)).Count()) / ((double)source.Count());           
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
            //TODO:增加是特殊模式下时的处理
            return source.Where(n => n.CompareRuleOO(rule));
        }
        #endregion
    }


    /// <summary>
    /// 其他特殊指标频率 Static_S
    /// </summary>
    public static class OtherIndexStatic
    {
        #region 跨度不重复的概率
        public static double Static_S跨度不重复(this IEnumerable<int[]> source)
        {
            Hashtable ht = new Hashtable();
            foreach (int[] item in source)
            {
                string s = item.ListToString();
                if (!ht.ContainsKey(s)) ht.Add(s, "");//不包含则添加                
            }
            return ((double)ht.Count) / ((double)source.Count());
        }
        #endregion
    }
    
    /// <summary>
    /// 其他特殊指标过滤:Filter_S
    /// </summary>
    public static class OtherIndexFilter
    {
        #region 跨度过滤—过滤掉历史所有出现的跨度列表
        /// <summary>
        /// 过滤掉历史所有出现的跨度列表
        /// </summary>
        /// <param name="source">需要过滤的数据</param>
        /// <param name="paramsValue">rule.RuleParams.ParamsValue 第一个参数为所需要过滤的数据的期数</param>
        public static IEnumerable<int[]> Filter_S跨度不重复(this IEnumerable<int[]> source, Rule rule)
        {
            //每次都获取数据，重新计算所有的跨度列表
            int[][] data = TwoColorBall.GetRedBallData(Convert.ToInt32(rule.RuleParams.ParamsValue));
            Hashtable ht = new Hashtable();
            foreach (int[] item in data)
            {
                string s = item.ListToString();
                if (!ht.ContainsKey(s)) ht.Add(s, "");//不包含则添加                
            }
            return source.Where(n => !ht.ContainsKey(n.ListToString()));
        }
        #endregion
    }
}