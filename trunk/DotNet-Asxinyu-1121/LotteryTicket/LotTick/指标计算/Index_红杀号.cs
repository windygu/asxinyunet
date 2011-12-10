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
        public Index_红杀号(RuleInfo ruleInfo)
        {
            this.RuleInfoParams = ruleInfo;
            this.IsDeleteNumberMode = true;//默认为杀号模式
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            //验证杀号是否准确
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