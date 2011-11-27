/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:00
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LotteryTicket
{
    //指标计算说明：分为3类
    //OOIndexCalculate类，特征是方法名称包含 Index_OO，  是单期数据计算得到单个结果
    //MMIndexCalculate类，特征是方法名称包含 Index_MM ，是多期数据计算得到的单个结果列表
    //OMIndexCalculate类，OM指标计算 Index_OM，当期数据计算得到结果列表
    //MOIndexCalculate类，MO指标计算 Index_MO，多期数据计算单个结果，多期数据
    //OtherIndexCalculate类，特征是方法名称包含 Index_SP ，是其他类型的数据计算结果，单独分析，一对多和多对多结果

    #region OO指标计算 Index_OO
    /// <summary>
    /// 指标计算:OO类单个指标，1对1实现:Index_
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
        public static int Index_OO和值(this int[] source)
        {
            return source.Sum();
        }
        #endregion

        #region 跨度
        /// <summary>
        /// 最大跨度:一个投注结果中最大号码与最小号码之差
        /// </summary>
        public static int Index_OO最大跨度(this int[] source)
        {
            return source.Last() - source.First();
        }
        /// <summary>
        /// 跨度和值
        /// </summary>
        public static int Index_跨度和值(this int[] source)
        {
            int[] res = source.Index_SP跨度列表();
            return res.Sum();
        }
        #endregion

        #region AC值
        /// <summary>
        /// Ac值=差值个数-(6-1)
        /// </summary>
        public static int Index_OOAc值(this int[] data)
        {            
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

        #region 每期最长的连续号码数
        /// <summary>
        /// 每期最长的连续号码数
        /// </summary>	
        public static int Index_OO最长连续号码数(this int[] data)
        {           
            int count = 0;
            int maxCount = 0;
            for (int i = data.Length - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
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
        public static int Index_OO质数个数(this int[] source)
        {
            return source.Index_S2个序列的重复号码个数(PrimeNumbers);
        }
        #endregion

        #region 偶数个数计算
        /// <summary>
        /// 计算每期的偶数的个数
        /// </summary>
        public static int Index_OO偶数个数(this int[] source)
        {
            return source.Where(n => ((int)n) % 2 == 0).Count();
        }
        #endregion

        #region 求余来计算覆盖的范围的个数---L自定义，需要调整
        /// <summary>
        /// 求余来计算覆盖的范围的个数,0到L-1出现的个数
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="L">求余参数,默认18</param>
        /// <returns>在此参数下的所有出现数字</returns>
        public static int Index_OO求余覆盖个数(this int[] source)
        {
            return source.Select(n => ((int)n) % 18).Distinct().Count();
        }
        #endregion

        #region 大号个数:号码值大于等于17的投注号码个数
        /// <summary>
        /// 大号个数:号码值大于等于指定值的投注号码个数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="BigNumber">大号号码下限,默认为17</param>      
        public static int Index_OO大号个数(this int[] source)
        {
            return source.Where(n => n >= 17).Count();
        }
        #endregion

        #region 尾数和值：一个投注结果中所有号码尾数（个位）之和
        /// <summary>
        /// 尾数和值
        /// </summary>
        public static int Index_OO尾数和值(this int[] source)
        {
            //对10求余即为尾数，求和
            return source.Select(n => n % 10).Sum();
        }
        #endregion

        #region 奇号连续个数：一个投注结果中，如果一个号码为奇号，其前一个号码也为奇号，则为一个奇号连续
        /// <summary>
        /// 奇号连续个数
        /// </summary>
        public static int Index_OO奇号连续个数(this int[] source)
        {
            bool[] res = source.Select(n => n % 2 == 1).ToArray();//是否是奇数
            int count = 0;
            for (int i = 0; i < res.Length - 1; i++)
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
        public static int Index_OO偶号连续个数(this int[] source)
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
        public static int Index_OO最大邻号间距(this int[] source)
        {
            return source.Index_SP跨度列表().Max();
        }
        #endregion

        #region 最小邻号间距:一个投注结果中所有相邻两个彩球号码之差的最小值
        /// <summary>
        /// 最小邻号间距
        /// </summary>
        public static int Index_OO最小邻号间距(this int[] source)
        {
            return source.Index_SP跨度列表().Min();
        }
        #endregion

        #region 连号个数:投注结果中后一个号码与前一个号码相差为1就是连号
        /// <summary>
        /// 连号个数
        /// </summary>
        public static int Index_OO连号个数(this int[] data)
        {            
            int count = 0;
            for (int i = 0; i < data.Length; i++)
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
        public static int Index_OO连号组数(this int[] data)
        {           
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
        public static int Index_OO尾数组数(this int[] source)
        {
            return source.Select(n => n % 10).Distinct().Count();
        }
        #endregion
    }
    #endregion

    #region OM指标计算 Index_OM
    public static class OMIndexCalculate
    {

    }
    #endregion

    #region MM指标计算 Index_MM
    /// <summary>
    /// 单个指标，多对一：多组数据计算结果实现，Index_MM
    /// </summary>
    public static class MMIndexCalculate
    {
        #region 多期号码出现数列表
        /// <summary>
        /// 多期数据中,出现重复号码的个数,列表:
        /// </summary>		
        public static int[] Index_MM多期重复数(this int[][] data,RuleInfo rule)
        {
            int NeedRows = rule.NumbersCount;
            int count = data.GetLength (0) - NeedRows + 1;//结果的总数
            int[] res = new int[count];            
            for (int i = 0; i < count; i++)
            {
                IEnumerable<int> union = data[i];
                for (int j = i; j < i + NeedRows; j++)
                {
                    union = union.Union(data[j]);
                }
                res[i] = NeedRows * data[0].Length - union.Count();//重复数=总数-当期剩余数
            }
            return res;
        }
        #endregion

        #region 邻号出现数列表
        /// <summary>
        /// 上(i)期的邻号在本期出现的个数
        /// </summary>
        public static int[] Index_MM邻号出现数(this int[][] data, RuleInfo rule)
        {
            int NeedRows = rule.NumbersCount;
            int count = data.GetLength (0) - NeedRows + 1;
            int[] res = new int[count];           
            for (int i = 0; i < count ; i++)
            {
                res[i] = data[i+NeedRows -1].Index_上期邻号出现个数(data[i]);
            }
            return res;
        }
        #endregion
    }
    #endregion   

    #region MO指标计算 Index_MO  //很少，几乎没有
    public static class MOIndexCalculate
    {        
        //public static int[] Index_MO(this IEnumerable<int[]> source, int NeedRows)
        //{}
    }
    #endregion    
}