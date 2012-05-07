using System.Linq;
using System.Collections.Generic;
namespace LotTick
{
    #region 红多期基类
    /// <summary>
    /// 红多期基类
    /// </summary>
    public class Index_红多期基类 : LotIndex
    {
        public override int[] GetAllValue(LotTickData[] data)
        {
            return base.GetAllValue(data);
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            return base.GetFilterResult(data, NeedData);
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            return GetAllValue(data).Select(n => n.GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
    #endregion

    #region 多期出现的次数，专门针对 序列类型的指标，最近几期相同的个数
    public class Index_红多期序列基类 : Index_红多期基类
    {
        public override int[] GetAllValue(LotTickData[] data)
        {
            int[] res = new int[data.Length - this.RuleInfoParams.NeedRows];
            string[] str = data.Select(n => GetSequence(n)).ToArray();
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
        //获取序列的方法
        public virtual string GetSequence(LotTickData data)
        {
            return data.NormalData.ToString();
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            //过滤的时候，要针对All，把所有的数据都传入进来,向构造序列
            List<string> cur = new List<string>();
            foreach (var item in NeedData)
            {
                cur.Add(GetSequence(item));
            }
            return data.Where(n => cur.FindAll(k => k == GetSequence(n))
                .Count().GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
    #endregion
}