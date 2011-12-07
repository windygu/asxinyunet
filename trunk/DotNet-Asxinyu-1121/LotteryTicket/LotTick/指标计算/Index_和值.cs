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
        public override int GetOneResult(int[] data)
        {
            return data.Sum();
        }
        public override int[][] GetFilterResult(int[][] data)
        {
            return data.Where(n => (n.Sum().GetCompareResult(this.RuleInfoParams))).ToArray();
        }
        public override bool[] GetValidateResult(int[][] data)
        {
            return data.Select(n => (n.Sum().GetCompareResult(this.RuleInfoParams))).ToArray();
        }
    }
}