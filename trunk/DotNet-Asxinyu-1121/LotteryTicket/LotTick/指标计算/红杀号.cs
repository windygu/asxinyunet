using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 红色号码和值
    /// </summary>
    public class Index_红杀号 : LotIndex
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
        public override List<int> DeleteNumbers(List<int> initialList, LotTickData[] data)
        {
            List<int> delete = GetDeleteNumberList(data);
            return initialList.Except(delete).ToList ();
        }
        private List<int> GetDeleteNumberList(LotTickData[] data)
        {
            return data[data.Length -1].NormalData.ToList (); 
        }
    }
}