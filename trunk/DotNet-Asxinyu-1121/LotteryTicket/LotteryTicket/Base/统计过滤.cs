using System;
using System.Linq;
using System.Collections;

namespace LotteryTicket
{
    #region 统计规律，所有规则
    /// <summary>
    /// 规律统计与过滤
    /// </summary>
    public static class StatisticalFilter
    {
        #region 统计值出现在指定范围的频率--单个指标频率
        /// <summary>
        /// 单个指标统计
        /// </summary>
        public static bool[] Static_单个指标频率(this int[][] source, RuleInfo rule)
        {
            //先根据Rule中的规则类别，反射加载选择器Selector
            //根据规则和选择器Selector进行计算
            Type t = GetTypeByEnumName(rule.CurIndexType);
            MethodInfo cur = t.GetMethod(rule.IndexSelectorName);
            switch (rule.CurIndexType)
            {
                case IndexType.OO:
                    var selector = (Func<int[], int>)Delegate.CreateDelegate(typeof(Func<int[], int>), cur);
                    var temp = source.Select(n => selector(n)).ToArray();//中间迭代每次计算一期数据
                    return temp.Select(n => GetCompareResult(n, rule)).ToArray () ;
                case IndexType.MM:
                    var selectorMM = (Func<int[][], RuleInfo, int[]>)Delegate.CreateDelegate
                        (typeof(Func<int[][], RuleInfo, int[]>), cur);
                    var tempMM = selectorMM(source, rule);//一次计算
                    return tempMM.Select(n => GetCompareResult(n, rule)).ToArray ();
                case IndexType.MO://实现过程还没有
                    var selectorMO = (Func<int[][], int[]>)Delegate.CreateDelegate
                     (typeof(Func<int[][], int[]>), cur);
                    var tempMO = selectorMO(source);//一次计算
                    return tempMO.Select(n => GetCompareResult(n, rule)).ToArray ();
                case IndexType.OM:
                    var selectorOM = (Func<int[][], int[]>)Delegate.CreateDelegate
                  (typeof(Func<int[][], int[]>), cur);
                    var tempOM = selectorOM(source);//一次计算
                    return tempOM.Select(n => GetCompareResult(n, rule)).ToArray();
                case IndexType.Specail:
                    var selectorS = (Func<int[][], RuleInfo, bool[]>)Delegate.CreateDelegate
                 (typeof(Func<int[][], RuleInfo, double>), cur);
                    return selectorS(source, rule);//直接返回结果
                case IndexType.None:
                    return null ;
                default:
                    return null ;
            }
        }
        //根据枚举类型获取对应的指标类类型
        public static Type GetTypeByEnumName(IndexType indexType)
        {
            switch (indexType)
            {
                case IndexType.OO:
                    return typeof(OOIndexCalculate);
                case IndexType.MM:
                    return typeof(MMIndexCalculate);
                case IndexType.MO:
                    return typeof(MOIndexCalculate);
                case IndexType.OM:
                    return typeof(OMIndexCalculate);
                case IndexType.Specail:
                    return typeof(OtherIndexStatic);
                case IndexType.None:
                    return null;
                default:
                    return null;
            }
        }
        /// <summary>
        /// 根据规则和数据，判断是否满足要求
        /// </summary>
        /// <param name="source">数据</param>
        /// <param name="rule">规则信息</param>
        /// <returns>结果列表,包括了所有的指标类型</returns>    
        public static bool GetCompareResult(int res, RuleInfo rule)
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

        #region 范围过滤：只保留对应规则的数据
        /// <summary>
        /// 范围过滤：只保留对应规则的数据
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="rule">保留规则</param>
        /// <returns>符合条件的集合</returns>
        public static int[][] Filter_范围过滤(this int[][] source, RuleInfo rule)
        {
            //先根据Rule中的规则类别，反射加载选择器Selector
            //根据规则和选择器Selector进行计算
            Type t = GetTypeByEnumName(rule.CurIndexType);
            MethodInfo cur = t.GetMethod(rule.IndexSelectorName);
            switch (rule.CurIndexType)
            {
                //出了OO，其他的过滤都在OtherIndexFilter
                case IndexType.OO:
                    var selector = (Func<int[], int>)Delegate.CreateDelegate(typeof(Func<int[], int>), cur);
                    var temp = source.Select(n => selector(n)).ToArray();//中间迭代每次计算一期数据
                    return source.Where(n => GetCompareResult(selector(n), rule)).ToArray();
                case IndexType.None:
                    return source;
                default://  其他类都到这里
                    var selectorS = (Func<int[][], RuleInfo, int[][]>)Delegate.CreateDelegate
                       (typeof(Func<int[][], RuleInfo, int[][]>), typeof(OtherIndexFilter).GetMethod("Filter_S" +
                           rule.IndexSelectorName.Substring(8)));
                    return selectorS(source, rule);
            }
        }
        #endregion
    }
    #endregion

    #region 其他特殊指标统计
    /// <summary>
    /// 其他特殊指标频率 Static_S
    /// </summary>
    public static class OtherIndexStatic
    {
        #region 跨度不重复的概率---一次技术所有
        public static double Static_S跨度不重复(this int[][] source, RuleInfo rule)
        {
            Hashtable ht = new Hashtable();
            foreach (int[] item in source)
            {
                string s = item.Index_SP跨度列表().ListToString();
                if (!ht.ContainsKey(s)) ht.Add(s, "");//不包含则添加                
            }
            return ((double)ht.Count) / ((double)source.Count());
        }
        #endregion
    }
    #endregion

    #region 其他特殊指标过滤
    /// <summary>
    /// 其他特殊指标过滤:Filter_S
    /// </summary>
    /// 
    public static class OtherIndexFilter
    {
        #region Index_MM类指标的过滤
        #region 多期重复数
        public static int[][] Filter_S多期重复数(this int[][] source, RuleInfo rule)
        {
            //先根据rule规则中的定义的需要行数据，取出数据库中最近的几期数据
            int[][] data = TwoColorBall.GetLatestRedBallData(rule.NumbersCount - 1);
            return source.Where(n => StatisticalFilter.GetCompareResult(data.重复数(n), rule)).ToArray();
        }
        public static int 重复数(this int[][] source, int[] data)
        {
            for (int i = 0; i < source.Count(); i++)
            {
                data = data.Union(source[i]).ToArray();
            }
            return data.Count();
        }
        #endregion

        #region 邻号出现数
        public static int[][] Filter_S邻号出现数(this int[][] source, RuleInfo rule)
        {
            //先根据rule规则中的定义的需要行数据，取出数据库中最近的第几期数据来与之对比，确定邻号数
            int[] data = TwoColorBall.GetLatestRedBallData(rule.NumbersCount)[0];
            return source.Where(n => StatisticalFilter.GetCompareResult(n.Index_上期邻号出现个数(data), rule)).ToArray();
        }
        #endregion
        #endregion

        #region 跨度过滤—过滤掉历史所有出现的跨度列表
        /// <summary>
        /// 过滤掉历史所有出现的跨度列表
        /// </summary>
        /// <param name="source">需要过滤的数据</param>
        /// <param name="paramsValue">rule.RuleParams.ParamsValue 第一个参数为所需要过滤的数据的期数</param>
        public static int[][] Filter_S跨度不重复(this int[][] source, RuleInfo rule)
        {
            //每次都获取数据，重新计算所有的跨度列表
            int[][] data = TwoColorBall.GetRedBallData(-1);
            Hashtable ht = new Hashtable();
            foreach (int[] item in data)
            {
                string s = item.Index_SP跨度列表().ListToString();
                if (!ht.ContainsKey(s)) ht.Add(s, "");//不包含则添加                
            }
            return source.Where(n => !ht.ContainsKey(n.Index_SP跨度列表().ListToString())).ToArray();
        }
        #endregion
    }
    #endregion
}