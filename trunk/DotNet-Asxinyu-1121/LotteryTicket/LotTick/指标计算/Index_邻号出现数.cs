using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    /// <summary>
    /// 上期的邻号出现个数（红球）
    /// </summary>
    public class Index_红邻号出现数 : LotIndex
    {
        public override int[] GetAllValue(LotTickData[] data)
        {         
            int[] res = new int[data.Length  - this.RuleInfoParams.NeedRows]; 
            for (int i = 0; i < res.Length ; i++)
            {
                res[i] = data[i + 1].NormalData.Index_S邻号出现个数(data[i].NormalData );
            }
            return res;
        }
        public override LotTick.LotTickData[] GetFilterResult(LotTickData[] data)
        {
            LotTickData lastData = data[data.Length - 1];
            return data.Where(n => (n.NormalData.Index_S邻号出现个数(lastData.NormalData )).
                GetCompareResult (this.RuleInfoParams)).ToArray();
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            return GetAllValue(data).Select(n => n.GetCompareResult(this.RuleInfoParams)).ToArray();
        }
    }
}