using System.Linq;
using System.Collections.Generic;

namespace LotTick
{
    #region 红奇偶序列  需要比较参数
    /// <summary>
    /// 红奇偶序列 最近几期相同的个数
    /// </summary>
    public class Index_红奇偶序列: Index_红多期基类 
    {
        public override int[] GetAllValue(LotTickData[] data)
        {
            int[] res = new int[data.Length - this.RuleInfoParams.NeedRows];
            string[] str = data.Select(n => n.NormalData.ParitySequence()).ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                List<string> temp = new List<string>();
                for (int j = i; j < i + this.RuleInfoParams.NeedRows; j++)
                {
                    temp.Add (str[j]);//多期的号码添加到一起后再计算比较
                }
                res[i] = temp.FindAll(n => n == str[i + this.RuleInfoParams.NeedRows]).Count();
            }
            return res;
        }

        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            //过滤的时候，要针对All，把所有的数据都传入进来,向构造序列
            List<string> cur = new List<string>();            
            foreach (var item in NeedData)
            {                
                cur.Add(item.NormalData.ParitySequence());
            }
            return data.Where(n =>cur.FindAll(k=>k==n.NormalData.ParitySequence()).Count().GetCompareResult(this.RuleInfoParams)).ToArray();
        }        
    }
    #endregion

    #region 红素合序列  需要比较参数
    /// <summary>
    /// 红素合序列 与前几期相同的个数
    /// </summary>
    public class Index_红素合序列 : Index_红多期基类
    {
        public override int[] GetAllValue(LotTickData[] data)
        {
            int[] res = new int[data.Length - this.RuleInfoParams.NeedRows];
            string[] str = data.Select(n => n.NormalData.PrimesSequence()).ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                List<string> temp = new List<string>();
                for (int j = i; j < i + this.RuleInfoParams.NeedRows; j++)
                {
                    temp.Add(str[j]);//多期的号码添加到一起后再计算比较
                }
                res[i] = temp.FindAll(n => n == str[i + this.RuleInfoParams.NeedRows]).Count();
            }
            return res;
        }

        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            //过滤的时候，要针对All，把所有的数据都传入进来,向构造序列
            List<string> cur = new List<string>();
            foreach (var item in NeedData)
            {
                cur.Add(item.NormalData.PrimesSequence());
            }
            return data.Where(n => cur.FindAll(k => k == n.NormalData.PrimesSequence()).Count().GetCompareResult(this.RuleInfoParams)).ToArray();
        }     
    }
    #endregion

    #region 红奇偶素合序列,需要比较参数
    /// <summary>
    /// 红奇偶素合序列 最近几期 相同的个数
    /// </summary>
    public class Index_红奇偶素合序列 : Index_红多期基类
    {
        public override int[] GetAllValue(LotTickData[] data)
        {
            int[] res = new int[data.Length - this.RuleInfoParams.NeedRows];
            string[] str = data.Select(n => n.NormalData.ParitySequence ()+ n.NormalData.PrimesSequence()).ToArray();
            for (int i = 0; i < res.Length; i++)
            {
                List<string> temp = new List<string>();
                for (int j = i; j < i + this.RuleInfoParams.NeedRows; j++)
                {
                    temp.Add(str[j]);//多期的号码添加到一起后再计算比较
                }
                res[i] = temp.FindAll(n => n == str[i + this.RuleInfoParams.NeedRows]).Count();
            }
            return res;
        }

        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            //过滤的时候，要针对All，把所有的数据都传入进来,向构造序列
            List<string> cur = new List<string>();
            foreach (var item in NeedData)
            {
                cur.Add(item.NormalData.PrimesSequence());
            }
            return data.Where(n => cur.FindAll(k => k == (n.NormalData.ParitySequence ()+n.NormalData.PrimesSequence()))
                .Count().GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
    #endregion
}