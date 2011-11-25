using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LotteryTicket
{
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
        public static IEnumerable<int[]> Filter_S跨度不重复(this IEnumerable<int[]> source,Rule rule)
        {
            //每次都获取数据，重新计算所有的跨度列表
            int[][] data = TwoColorBall.GetRedBallData(Convert.ToInt32(rule.RuleParams.ParamsValue));
            Hashtable ht = new Hashtable();
            foreach (int[] item in data )
            {
                string s = item.ListToString();
                if (!ht.ContainsKey(s)) ht.Add(s, "");//不包含则添加                
            }
            return source.Where(n => !ht.ContainsKey(n.ListToString()));
        }
        #endregion
        
    }
}