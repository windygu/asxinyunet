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
    /// 指标计算:OM类单个指标，1对1和1对多的实现
    /// </summary>
    public static class OOIndexCalculate
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
        public static int Index_和值(this IEnumerable<int> source)
        {
            return source.Sum();
        }
        #endregion

        #region 跨度
        /// <summary>
        /// 最大跨度:一个投注结果中最大号码与最小号码之差
        /// </summary>
        public static int Index_最大跨度(this IEnumerable<int> source)
        {
            return source.Last() - source.First();
        }
        /// <summary>
        /// 跨度和值
        /// </summary>
        public static int Index_跨度和值(this IEnumerable<int> source)
        {
            int[] res = OtherIndexCalculate.Index_S跨度列表(source);
            return res.Sum();
        }
        #endregion

        #region AC值
        /// <summary>
        /// Ac值=差值个数-(6-1)
        /// </summary>
        public static int Index_Ac值(this IEnumerable<int> source)
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
        public static int Index_多期重复号码数(this IEnumerable<int[]> source)
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
        public static double[] Index_号码频率(this IEnumerable<int[]> source, int maxNumber = 33)
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

        #region 每期最长的连续号码数
        /// <summary>
        /// 每期最长的连续号码数
        /// </summary>	
        public static int Index_最长连续号码数(this IEnumerable<int> source)
        {
            int[] data = source.ToArray();
            int count = 0;
            int maxCount = 0;
            for (int i = data.Length -1; i > 0; i--)
            {
                for (int j = i -1; j >= 0 ; j--)
                {
                    if (data[i] - data[j] == 1) count++;
                    else 
                    {
                        if (maxCount < count) { maxCount = count; } 
                        count = 0; 
                    }
                }
            }
            //可能最后一次循环很大
            if (maxCount < count) { maxCount = count; } 
            return maxCount;
        }
        #endregion

        #region 质数个数计算
        /// <summary>
        /// 每期质数的个数
        /// </summary>		
        public static int Index_质数个数(this IEnumerable<int> source)
        {
            return source.Index_2个序列的重复号码个数(PrimeNumbers);            
        }
        #endregion

        #region 偶数个数计算
        /// <summary>
        /// 计算每期的偶数的个数
        /// </summary>
        public static int Index_偶数个数(this IEnumerable<int> source)
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
        public static int Index_求余覆盖个数(this IEnumerable<int> source,int L = 18)
        {
            return source.Select(n => ((int)n) % L).Distinct().Count();
        }
        #endregion

        #region 获取2个序列的重复号码个数
        /// <summary>
        /// 获取2个序列的重复号码个数
        /// </summary>
        /// <returns>返回重复号码的个数</returns>
        public static int Index_2个序列的重复号码个数(this IEnumerable<int> source, IEnumerable<int> compareSouce)
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
        public static int Index_上期邻号出现个数(this IEnumerable<int> source, IEnumerable<int> LastSouce)
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

        #region 大号个数:号码值大于等于17的投注号码个数
        /// <summary>
        /// 大号个数:号码值大于等于指定值的投注号码个数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="BigNumber">大号号码下限,默认为17</param>      
        public static int Index_大号个数(this IEnumerable<int> source,int BigNumber = 17)
        {
            return source.Where(n =>n >=BigNumber ).Count();
        }
        #endregion

        #region 尾数和值：一个投注结果中所有号码尾数（个位）之和
        /// <summary>
        /// 尾数和值
        /// </summary>
        public static int Index_尾数和值(this IEnumerable<int> source)
        {
            //对10求余即为尾数，求和
            return source.Select(n => n % 10).Sum();
        }
        #endregion

        #region 奇号连续个数：一个投注结果中，如果一个号码为奇号，其前一个号码也为奇号，则为一个奇号连续
        /// <summary>
        /// 奇号连续个数
        /// </summary>
        public static int Index_奇号连续个数(this IEnumerable<int> source)
        {            
            bool[] res = source.Select (n=>n %2 ==1).ToArray () ;//是否是奇数
            int count = 0;
            for (int i = 0; i < res.Length -1 ; i++)
            {
                if (res[i + 1] && res[i]) count++;
            }
            return count;
        }
        #endregion

        #region 偶号连续个数:一个投注结果中，如果一个号码为偶号，其前一个号码也为偶号，则为一个偶号连续；
        /// <summary>
        /// 偶号连续个数
        /// </summary>
        public static int Index_偶号连续个数(this IEnumerable<int> source)
        {
            bool[] res = source.Select(n => n % 2 == 0).ToArray();//是否是奇数
            int count = 0;
            for (int i = 0; i < res.Length - 1; i++)
            {
                if (res[i + 1] && res[i]) count++;
            }
            return count;
        }
        #endregion

        #region 最大邻号间距:一个投注结果中所有相邻两个彩球号码之差的最大值
        /// <summary>
        /// 最大邻号间距
        /// </summary>
        public static int Index_最大邻号间距(this IEnumerable<int> source)
        {
            return source.Index_S跨度列表 ().Max () ;            
        }
        #endregion

        #region 最小邻号间距:一个投注结果中所有相邻两个彩球号码之差的最小值
        /// <summary>
        /// 最小邻号间距
        /// </summary>
        public static int Index_最小邻号间距(this IEnumerable<int> source)
        {
            return source.Index_S跨度列表().Min();
        }
        #endregion

        #region 连号个数:投注结果中后一个号码与前一个号码相差为1就是连号
        /// <summary>
        /// 连号个数
        /// </summary>
        public static int Index_连号个数(this IEnumerable<int> source)
        {
            int[] data = source.ToArray();
            int count = 0;
            for (int i = 0; i < data.Length ; i++)
            {
                if (data[i + 1] - data[i] == 1) count++;
            }
            return count;
        }
        #endregion

        #region 连号组数:一个投注结果中出现连号的组数
        /// <summary>
        /// 连号个数
        /// </summary>
        public static int Index_连号组数(this IEnumerable<int> source)
        {
            int[] data = source.ToArray();
            int count = 0;
            bool flag = false;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i + 1] - data[i] == 1)
                {
                    if (flag)//只第一次加
                    {
                        count++;
                        flag = true;
                    }
                }
                else { flag = false; }
            }
            return count;
        }
        #endregion

        #region 尾数组数:一个投注结果中不同尾数的组数
        /// <summary>
        /// 尾数组数
        /// </summary>
        public static int Index_尾数组数(this IEnumerable<int> source)
        {
            return source.Select(n => n % 10).Distinct().Count();
        }
        #endregion        
    }

    /// <summary>
    /// 单个指标：多组数据计算结果实现
    /// </summary>
    public static class MOIndexCalculate
    {

    }

    /// <summary>
    /// 其他特殊指标计算
    /// </summary>
    public static class OtherIndexCalculate
    {
        /// <summary>
        /// 计算跨度列表
        /// </summary>
        public static int[] Index_S跨度列表(this IEnumerable<int> source)
        {
            int[] list = source.ToArray();
            int[] res = new int[list.Length];
            for (int i = 0; i < list.Length; i++)
            {
                res[i] = list[i + 1] - list[i];
            }
            return res;
        }
    }

    /// <summary>
    /// 其他特殊指标频率
    /// </summary>
    public static class OtherIndexStatic
    {
        public static double Static_S跨度不重复(this IEnumerable<int[]> source)
        {            
            Hashtable ht = new Hashtable();
            foreach (int[] item in source )
            {
                string s = item.ListToString();
                if (!ht.ContainsKey(s)) ht.Add(s, "");//不包含则添加                
            }
            return ((double )ht.Count )/((double)source.Count ());
        }
    }
    /// <summary>
    /// 其他特殊指标过滤
    /// </summary>
    public static class OtherIndexFilter
    {
        /// <summary>
        /// 过滤掉跨度列表在HashTable中的对象
        /// </summary>
        /// <param name="source"></param>
        /// <param name="paramsValue">参数：第一个为HashTable</param>
        public static IEnumerable<int[]> Filter_S跨度不重复(this IEnumerable<int[]> source, object[] paramsValue)
        {
            Hashtable ht = (Hashtable)paramsValue[0];
            return source.Where (n=>ht.ContainsKey (
        }
    }
}