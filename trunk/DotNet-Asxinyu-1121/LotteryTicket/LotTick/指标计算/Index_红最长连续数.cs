using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// Index_红最长连续数
    /// </summary>
    public class Index_红最长连续数 : LotIndex
    {
        //有错误，需改正
        public override int GetOneResult(LotTickData data)
        {
            int count = 0;
            int maxCount = 0;
            for (int i = data.NormalData .Length - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (data.NormalData[i] - data.NormalData[j] == 1) count++;
                    else
                    {
                        if (maxCount < count) { maxCount = count; }
                        count = 0;
                    }
                }
            }
            //可能最后一次循环很大
            if (maxCount < count) { maxCount = count; }
            return maxCount;
        }
    }
}