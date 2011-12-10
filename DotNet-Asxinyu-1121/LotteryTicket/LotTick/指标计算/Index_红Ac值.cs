using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// Index_红Ac值
    /// </summary>
    public class Index_红Ac值 : LotIndex
    {       
        public override int[] GetAllValue(LotTickData[] data)
        {
            return data.Select(n => n.NormalData.Last()-n.NormalData.First ()).ToArray();
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            return data.Where(n => (n.NormalData.Last() - n.NormalData.First()).GetCompareResult(this.RuleInfoParams)).ToArray();
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            return GetAllValue(data).GetCompareResult(this.RuleInfoParams);
        }
    }
}