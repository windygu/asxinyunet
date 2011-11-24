using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections;

namespace LotteryTicket
{
    /// <summary>
    /// 其他特殊指标频率 Static_S
    /// </summary>
    public static class OtherIndexStatic
    {
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
    }
    /// <summary>
    /// 其他特殊指标过滤:Filter_S
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
            return source.Where(n => !ht.ContainsKey(n.ListToString()));
        }
    }
}
