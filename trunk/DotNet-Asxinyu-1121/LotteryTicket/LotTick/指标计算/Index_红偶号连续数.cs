using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 偶号连续数,修改完成
    /// </summary>
    public class Index_红偶号连续数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            bool[] res = data.NormalData.Select(n => n % 2 == 0).ToArray();
            int count = 0;
            for (int i = 0; i < res.Length - 1; i++)
            {
                if (res[i + 1] && res[i]) count++;
            }
            return count;
        }       
    }
}