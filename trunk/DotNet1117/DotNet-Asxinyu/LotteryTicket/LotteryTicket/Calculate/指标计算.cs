/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:00
 * 
 *
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LotteryTicket
{
    /// <summary>
    /// 指标计算:单个指标和所有指标,采用扩展方法实现
    /// </summary>
    public static class IndexCalculate
    {
        #region 常量
        /// <summary>
        /// 质数集合
        /// </summary>
        public static readonly int[] PrimeNumbers = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
        #endregion

        #region 和值与数据密度
        /// <summary>
        /// 计算和值
        /// </summary>
        public static int Index_Sum(this IEnumerable<int> source)
        {
            return source.Sum();
        }
        #endregion

        #region 跨度
        /// <summary>
        /// 计算最大跨度
        /// </summary>
        public static int Index_MaxSpan(this IEnumerable<int> source)
        {
            return source.Last() - source.First();
        }

        /// <summary>
        /// 计算跨度列表
        /// </summary>
        public static int[] Index_SpanList(this IEnumerable<int> source)
        {
            int[] list = source.ToArray();
            int[] res = new int[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                res[i] = list[i + 1] - list[i];
            }
            return res;
        }

        /// <summary>
        /// 最小跨度
        /// </summary>
        public static int Index_MinSpan(this IEnumerable<int> source)
        {
            int[] res = Index_SpanList(source);
            return res.Min();//返回最小值
        }

        /// <summary>
        /// 跨度和值
        /// </summary>
        public static int Index_SpanSum(this IEnumerable<int> source)
        {
            int[] res = Index_SpanList(source);
            return res.Sum();
        }
        #endregion

        #region AC值
        /// <summary>
        /// Ac值=差值个数-(6-1)
        /// </summary>
        public static int Index_AcValue(this IEnumerable<int> source)
        {
            int[] data = source.ToArray();
            ArrayList list = new ArrayList();
            int temp;
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = i + 1; j < data.Length; j++)
                {
                    temp = data[j] - data[i];
                    if (!list.Contains(temp))
                    {
                        list.Add(temp);
                    }
                }
            }
            return list.Count - (data.Length - 1);
        }
        #endregion

        #region 多期号码出现的重复号码
        /// <summary>
        /// 多期数据中,出现重复号码的个数
        /// </summary>		
        public static int Index_ManyNoOfNewCount(this IEnumerable<int[]> source)
        {
            ArrayList al = new ArrayList();
            int count = 0;
            foreach (var item in source)
            {
                foreach (var s in item)
                {
                    if (!al.Contains(s)) { al.Add(s); }
                    else { count++; }
                }
            }
            return count;
        }
        #endregion

        #region 统计次数与频率 FrequCount FrequPrecent
        /// <summary>
        /// 计算在所有当前数据中，号码出现的频率(百分比)
        /// </summary>
        public static double[] FrequPrecent(this IEnumerable<int[]> source, int maxNumber = 33)
        {
            //先从最后一列找出最大值,确定出现的最大数字
            int[] numbers = new int[maxNumber];
            foreach (var item in source)
            {
                foreach (var s in item)
                {
                    numbers[s + 1]++;
                }
            }
            int allNumbers = numbers.Sum();
            return numbers.Select(n => ((double)n) / ((double)allNumbers)).ToArray();
        }
        #endregion

        #region 每期最长的连续号码个数,2个2连续算3
        /// <summary>
        /// 每期最长的连续号码个数,2个2连续算3
        /// </summary>	
        public static int Index_ContinuousCount(this IEnumerable<int> source)
        {
            int[] res = source.Index_SpanList();
            int count = res.Where(n => n == 1).Count();//计算==1的个数			
            return count + 1;
        }
        #endregion

        #region 质数个数计算
        /// <summary>
        /// 每期质数的个数
        /// </summary>		
        public static int Index_PrimeCount(this IEnumerable<int> source)
        {
            return source.Index_GetRepeatNumbers(PrimeNumbers);            
        }
        #endregion

        #region 偶数个数计算
        /// <summary>
        /// 计算每期的偶数的个数
        /// </summary>
        public static int Index_EvenNumber(this IEnumerable<int> source)
        {
            return source.Where(n => ((int)n) % 2 == 0).Count();
        }
        #endregion

        #region 求余来计算覆盖的范围的个数
        /// <summary>
        /// 求余来计算覆盖的范围的个数,0到L-1出现的个数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="L">求余参数,默认18</param>
        /// <returns>在此参数下的所有出现数字</returns>
        public static int Index_CoverCount(this IEnumerable<int> source,int L = 18)
        {
            return source.Select(n => ((int)n) % L).Distinct().Count();
        }
        #endregion

        #region 获取2个序列的重复号码个数
        /// <summary>
        /// 获取2个序列的重复号码个数
        /// </summary>
        /// <returns>返回重复号码的个数</returns>
        public static int Index_GetRepeatNumbers(this IEnumerable<int> source, IEnumerable<int> compareSouce)
        {
            int count = 0;
            foreach (int item in source)
            {
                foreach (int s in compareSouce)
                {
                    if (item == s) { count++; break; }
                    if (item < s) { break; }//后面的已经比其越来越大了
                }
            }
            return count;
        }
        #endregion

        #region 获取邻号出现的个数
        /// <summary>
        /// 获取上期的邻号在当前期出现的个数
        /// </summary>
        /// <param name="source">本期数据</param>
        /// <param name="LastSouce">上期数据或者指定期数据</param>
        /// <returns>上期邻号在本期出现的个数</returns>
        public static int Index_NeighbourNumberCount(this IEnumerable<int> source, IEnumerable<int> LastSouce)
        {
            int count = 0;
            double temp = 0;
            foreach (int item in source )
            {
                foreach (int cur in LastSouce )
                {
                    temp = Math.Abs(item - cur);
                    if (temp == 1 || temp == 32) count++;
                }
            }
            return count;
        }
        #endregion
    }
}