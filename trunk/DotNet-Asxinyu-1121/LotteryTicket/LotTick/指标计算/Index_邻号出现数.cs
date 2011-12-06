using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    /// <summary>
    /// 上期的邻号出现个数
    /// </summary>
    public class Index_邻号出现数 : LotIndex
    {
        public Index_邻号出现数(RuleInfo ruleInfo)
        {
            this.RuleInfoParams = ruleInfo;
            this.CurrentMode = EIndexMode.Special ;         
        }
        public override int[] GetAllValue(LotTickData[] data)
        {
            //只计算所需要的行
            if (data.GetLength(0) < RuleInfoParams.CalcuteRows )
                throw new Exception(string.Format(ErrorInfo.Error_001, data.GetLength(0), RuleInfoParams.CalcuteRows ));               
            int[] res = new int[data.GetLength(0) - this.RuleInfoParams.NeedRows]; 
            for (int i = 0; i < res.Length ; i++)
            {
                res[i] = data[i + 1].NormalData.Index_S邻号出现个数(data[i].NormalData );
            }
            return res;
        }
        public override int[][] GetFilterResult(int[][] data)
        {
            //只需要最近的期数数据即可
            int[] lastData = data[data.GetLength(0) - 1];
            return data.Where(n => (n.Index_S邻号出现个数(lastData)).
                GetCompareResult (this.RuleInfoParams)).ToArray();
        }
        //public override bool[] GetValidateResult(int[][] data)
        //{
        //    return GetAllValue(data).Select(n => n.GetCompareResult(this.RuleInfoParams)).ToArray();
        //}
    }
}