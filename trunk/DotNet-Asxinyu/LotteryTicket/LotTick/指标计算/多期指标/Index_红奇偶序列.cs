using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 红奇偶序列 是否与以前相同
    /// </summary>
    public class Index_红奇偶序列: Index_红多期基类 
    {
        //根据需要计算的行数来循环计算,输入数据已经考虑了所需行
        public override int[] GetAllValue(LotTickData[] data)
        {
            int[] res = new int[data.Length  - this.RuleInfoParams.NeedRows]; 
            for (int i = 0; i < res.Length ; i++)
            {
                res[i] = data[i + 1].NormalData.Index_S邻号出现个数(data[i].NormalData );
            }
            return res;
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {  //LotTickData lastData = NeedData[0 ];去需要的第一个个数据来进行对比计算
            return data.Where(n => (n.NormalData.Index_S邻号出现个数(NeedData[0].NormalData)).
                GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
}