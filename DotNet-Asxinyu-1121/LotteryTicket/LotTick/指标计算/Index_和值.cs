using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    /// <summary>
    /// 红色号码和值
    /// </summary>
    public class Index_红和值 : LotIndex
    {       
        public override int[] GetAllValue(LotTickData[] data)
        {
            return data.Select(n => n.NormalData.Sum()).ToArray();
        }        
        public override LotTick.LotTickData[] GetFilterResult(LotTickData[] data)
        {
            return data.Where(n => (n.NormalData.Sum()).GetCompareResult(this.RuleInfoParams)).ToArray();
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            return GetAllValue(data).GetCompareResult(this.RuleInfoParams);
        }
    }
}