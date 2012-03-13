using System.Collections.Generic;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 杀号基类:
    /// 杀号直接进行过滤和验证操作，不需要进行单个的计算
    /// </summary>
    public class Index_Base杀号 : LotIndex
    {
        public Index_Base杀号(RuleInfo ruleInfo)
        {
            this.RuleInfoParams = ruleInfo;
            this.IsDeleteNumberMode = true;//默认为杀号模式
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            //验证杀号是否准确
            return GetAllValue(data).GetCompareResult(this.RuleInfoParams);
        }
        public override LotTickData[] GetFilterResult(LotTickData[] data, LotTickData[] NeedData = null)
        {
            return base.GetFilterResult(data, NeedData);
        }
        //public override List<int> DeleteNumbers(List<int> initialList, LotTickData[] data)
        //{
        //    List<int> delete = GetDeleteNumberList(data);
        //    return initialList.Except(delete).ToList ();
        //}
        //private List<int> GetDeleteNumberList(LotTickData[] data)
        //{
        //    return data[data.Length -1].NormalData.ToList (); 
        //}
    }
}