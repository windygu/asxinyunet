﻿
namespace LotTick
{
    /// <summary>
    ///连号个数-修改完成
    /// </summary>
    public class Index_红连号个数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            int count = 0;
            for (int i = 0; i < data.NormalData .Length - 1; i++)
            {
                if (data.NormalData [i + 1] - data.NormalData [i] == 1) count++;
            }
            return count;
        }       
    }

    /// <summary>
    /// Index_红求余覆盖数
    /// </summary>
    public class Index_红求余覆盖数 : LotIndex
    {
        int L;

        /// <summary>
        /// 需要自定义的长度L
        /// </summary>        
        public Index_红求余覆盖数(RuleInfo ruleInfo, bool isDeleteMode = false)
        {
            this.RuleInfoParams = ruleInfo;
            IsDeleteNumberMode = isDeleteMode;
            if (ruleInfo.CondtionParams.ParamsValue != null)
            {
                L = Convert.ToInt32(ruleInfo.CondtionParams.ParamsValue);
            }
            else
            {
                L = 17;
            }
        }
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Select(n => ((int)n) % L).Distinct().Count();
        }
    }
}