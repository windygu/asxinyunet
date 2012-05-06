using System.Linq;
using System.Collections.Generic;

namespace LotTick
{
    #region 红奇偶序列  不需要比较参数
    /// <summary>
    /// 红奇偶序列 最近几期不相同的概率
    /// </summary>
    public class Index_红奇偶序列: Index_红多期基类 
    {
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            //过滤的时候，要针对All，把所有的数据都传入进来,向构造序列
            Dictionary<string, string> cur = new Dictionary<string, string>();
            foreach (var item in NeedData)
            {
                string s = item.NormalData.ParitySequence() ;
                if (!cur.ContainsKey(s)) cur.Add(s, string.Empty);
            }
            return data.Where(n => !cur.ContainsKey(n.NormalData.ParitySequence())).ToArray();
        }
        //验证，直接单独进行
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            //一边计算，一边插入，一边统计
            List<string> list = new List<string>();
            bool[] res = new bool[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                string s = data[i].NormalData.ParitySequence();
                bool have = list.Exists(n => n == s);
                if (have) res[i] = false;
                else
                {
                    list.Add(s);
                    res[i] = true;
                }
            }
            return res;
        }
    }
    #endregion

    #region 红素合序列  不需要比较参数
    /// <summary>
    /// 红素合序列 是否与以前所有的相同
    /// </summary>
    public class Index_红素合序列 : Index_红多期基类
    {
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            //过滤的时候，要针对All，把所有的数据都传入进来,向构造序列
            Dictionary<string, string> cur = new Dictionary<string, string>();
            foreach (var item in NeedData)
            {
                string s = item.NormalData.PrimesSequence();
                if (!cur.ContainsKey(s)) cur.Add(s, string.Empty);
            }
            return data.Where(n => !cur.ContainsKey(n.NormalData.PrimesSequence())).ToArray();
        }
        //验证，直接单独进行
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            //一边计算，一边插入，一边统计
            List<string> list = new List<string>();
            bool[] res = new bool[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                string s = data[i].NormalData.PrimesSequence();
                bool have = list.Exists(n => n == s);
                if (have) res[i] = false;
                else
                {
                    list.Add(s);
                    res[i] = true;
                }
            }
            return res;
        }    
    }
    #endregion

    #region 红奇偶素合序列,不需要比较参数
    /// <summary>
    /// 红奇偶素合序列 最近几期 是否与以前所有的相同
    /// </summary>
    public class Index_红奇偶素合序列All : Index_红多期基类
    {
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            //过滤的时候，要针对All，把所有的数据都传入进来,向构造序列
            Dictionary<string, string> cur = new Dictionary<string, string>();
            foreach (var item in NeedData)
            {
                string s = item.NormalData.ParitySequence() + item.NormalData.PrimesSequence();
                if (!cur.ContainsKey(s)) cur.Add(s, string.Empty);
            }
            return data.Where(n => !cur.ContainsKey(n.NormalData.ParitySequence() +
                n.NormalData.PrimesSequence())).ToArray();
        }
        //验证，直接单独进行
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            //一边计算，一边插入，一边统计
            List<string> list = new List<string>();
            bool[] res = new bool[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                string s = data[i].NormalData.ParitySequence() + data[i].NormalData.PrimesSequence();
                bool have = list.Exists(n => n == s);
                if (have) res[i] = false;
                else
                {
                    list.Add(s);
                    res[i] = true;
                }
            }
            return res;
        }
    }
    #endregion
}