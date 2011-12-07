using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    /// <summary>
    /// 序列和值
    /// </summary>
    public class Index_和值 : LotIndex
    {       
        public override int[] GetAllValue(LotTickData[] data)
        {
            //只计算所需要的行
            if (data.GetLength(0) < RuleInfoParams.CalcuteRows )
                throw new Exception(string.Format(ErrorInfo.Error_001, data.GetLength(0), RuleInfoParams.CalcuteRows ));
            switch (this.RuleInfoParams.CurrentMode )
            {
                case EIndexMode.Normal:
                    return data.Select(n => n.NormalData.Sum()).ToArray();                    
                case EIndexMode.Special:
                    return data.Select(n => n.SpecialData).ToArray();
                case EIndexMode.Mix:
                    return data.Select(n => n.NormalData.Sum() + n.SpecialData).ToArray();
                default:
                    return null;
            }            
        }        
        public override LotTick.LotTickData[] GetFilterResult(LotTickData[] data)
        {
             if (data.GetLength(0) < RuleInfoParams.CalcuteRows )
                throw new Exception(string.Format(ErrorInfo.Error_001, data.GetLength(0), RuleInfoParams.CalcuteRows ));
             switch (this.RuleInfoParams.CurrentMode)
             {
                 case EIndexMode.Normal:
                     return data.Where(n => (n.NormalData.Sum()).GetCompareResult(this.RuleInfoParams)).ToArray();
                 case EIndexMode.Special:
                     return data.Where(n => (n.SpecialData).GetCompareResult(this.RuleInfoParams)).ToArray();
                 case EIndexMode.Mix:
                     return data.Where(n => (n.NormalData.Sum() + n.SpecialData).GetCompareResult(this.RuleInfoParams)).ToArray();
                 default:
                     return null;
             }
        }
        public override bool[] GetValidateResult(LotTickData[] data)
        {
            if (data.GetLength(0) < RuleInfoParams.CalcuteRows)
                throw new Exception(string.Format(ErrorInfo.Error_001, data.GetLength(0), RuleInfoParams.CalcuteRows));
            return GetAllValue(data).GetCompareResult(this.RuleInfoParams);
        }
    }
}