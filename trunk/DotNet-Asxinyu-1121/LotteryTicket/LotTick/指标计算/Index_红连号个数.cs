using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
}