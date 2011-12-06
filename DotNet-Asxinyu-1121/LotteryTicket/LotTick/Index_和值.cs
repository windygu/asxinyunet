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
        public Index_和值(RuleInfo ruleInfo)
        {
            this.RuleInfoParams = ruleInfo;
            this.ResultType = EIndexResultType.Single;         
        }
        public override int[] GetAllValue(int[][] data)
        {
            //只计算所需要的行
            if (data.GetLength(0) < RuleInfoParams.CalcuteRows )
                throw new Exception(string.Format(ErrorInfo.Error_001, data.GetLength(0), RuleInfoParams.CalcuteRows ));
            return data.Select(n => n.Sum()).ToArray ();
        }
        public override int GetOneResult(int[] data)
        {
            return data.Sum();
        }
        public override int[][] GetFilterResult(int[][] data)
        {
            return base.GetFilterResult(data);
        }
    }
}
