using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotteryTicket
{
    /// <summary>
    /// 规则类
    /// </summary>
    public class Rule
    {
        public int FloorLimit { get; set; }
        public int CeilLimit { get; set; } 
        public System.Func<int[], int> Selector { get; set; }
    }

    /// <summary>
    /// 规律统计
    /// </summary>
    public static class StatisticalRegularity
    {
        #region 统计值出现在指定范围的频率
        /// <summary>
        /// 统计值出现在指定范围的频率
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="selector">统计值的计算函数</param>
        /// <param name="floorLimit">范围下限</param>
        /// <param name="ceilLimit">范围上限</param>
        /// <returns>当前数据满足此范围的比例</returns>
        public static double Static_范围统计(this IEnumerable<int[]> source, System.Func<int[], int> selector,
            int floorLimit = 2, int ceilLimit = 10)
        {
            int count = (from n in source
                         let sum = selector (n ) 
                         where (sum >= floorLimit && sum <= ceilLimit)
                         select n).Count();
            return ((double)count) / ((double)source.Count());
        }
        #endregion

        #region 统计值小于指定值的频率
        /// <summary>
        /// 统计值小于指定值的频率
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="selector">统计值的计算函数</param>
        /// <param name="floorLimit">指定的值</param>
        /// <returns>当前数据指标小于指定值的比例</returns>
        public static double Static_小于统计(this IEnumerable<int[]> source, System.Func<int[], int> selector,
            int floorLimit = 0)
        {
            int count = (from n in source
                         let sum = selector(n)
                         where (sum < floorLimit)
                         select n).Count();
            return ((double)count) / ((double)source.Count());
        }
        #endregion

        #region 统计值大于指定值的频率
        /// <summary>
        /// 统计值大于指定值的频率
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="selector">统计值的计算函数</param>
        /// <param name="floorLimit">指定的值</param>
        /// <returns>当前数据指标大于指定值的比例</returns>
        public static double Static_大于统计(this IEnumerable<int[]> source, System.Func<int[], int> selector,
            int floorLimit = 0)
        {
            int count = (from n in source
                         let sum = selector(n)
                         where (sum > floorLimit)
                         select n).Count();
            return ((double)count) / ((double)source.Count());
        }
        #endregion              
    }

    /// <summary>
    /// 验证过滤
    /// </summary>
    public static class ValidateFilter
    {
        #region 范围过滤：只保留指标在此范围的数据
        /// <summary>
        /// 只保留指标在此范围的数据
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="selector">统计值的计算函数</param>
        /// <param name="floorLimit">范围下限</param>
        /// <param name="ceilLimit">范围上限</param>
        public static IEnumerable<int[]>  Filter_范围过滤(this IEnumerable<int[]> source, System.Func<int[], int> selector,
            int floorLimit = 2, int ceilLimit = 10)
        {
            return  (from n in source
                     let sum = selector(n)
                     where (sum >= floorLimit && sum <= ceilLimit)
                     select n) ;
        }
        #endregion

        #region 小于过滤：只保留指标小于指定值的数据
        /// <summary>
        /// 只保留指标小于指定值的数据
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="selector">统计值的计算函数</param>
        /// <param name="floorLimit">范围下限</param>
        public static IEnumerable<int[]> Filter_小于过滤(this IEnumerable<int[]> source, System.Func<int[], int> selector,
            int floorLimit = 1)
        {
            return (from n in source
                    let sum = selector(n)
                    where (sum < floorLimit)
                    select n);
        }
        #endregion

        #region 大于过滤：只保留指标大于指定值的数据
        /// <summary>
        /// 只保留指标大于指定值的数据
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="selector">统计值的计算函数</param>
        /// <param name="floorLimit">范围下限</param>
        public static IEnumerable<int[]> Filter_大于过滤(this IEnumerable<int[]> source, System.Func<int[], int> selector,
            int floorLimit = 1)
        {
            return (from n in source
                    let sum = selector(n)
                    where (sum < floorLimit)
                    select n);
        }
        #endregion

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
