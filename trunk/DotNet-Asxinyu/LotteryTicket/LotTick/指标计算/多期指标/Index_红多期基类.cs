using System.Linq;
using System.Collections.Generic;
namespace LotTick
{
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
}